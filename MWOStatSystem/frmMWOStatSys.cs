/*
 *   MWOStatScraper is a tool to gather and process personal match data from 
 *   the MWOMercs website, for the game MechWarrior Online.
 * 
 *   Copyright (C) 2014  {Ray}
 *
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>
 *   
 *   This license applies only to the source code files in this project that are
 *   required to compile/use this program. All included libraries required
 *   for SqlServerCompact to run remain under their original licenses and
 *   all copyrights remain with their original creators. The files are only
 *   included in this project/application for runtime distribution purposes
 *   on systems that do not have SqlServerCompact installed directly.
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlServerCe;
using System.Windows.Forms.DataVisualization.Charting;
using MWOStatSystem.Support_Classes;
using IntelligentStreaming.SharpTools;
using System.Text.RegularExpressions;
using System.Collections;
using System.Resources;
using MWOStatSystem.Properties;
using BrightIdeasSoftware;

namespace MWOStatSystem
{

    public partial class frmMWOStatSys : Form
    {

        public static string sPassword = "";
        public static string sUserId = "";

        // gets set to true when you click "test" button. otherwise we're going after the web!
        private bool bTesting = false; 
        private bool bScrapesToFile = false;
        private bool bSuspendClicks = false;
        private bool bNeedSeed = false;
        private bool bLoggedIn = false;
        private bool bLoading = true;

        private clMechMatch clCurrentMech = null;

        private LoginDetails myLogin = null;
        private MatchCollection m1;

        // HTTP class vars, to use over various scrapes..
        private string locationHeader = "";
        private HTTPWorker m_http = null;
        private HttpWebResponse rsp = null;

        // list of links we're going to scrape...
        private const string sLoginURL = "https://mwomercs.com/login";
        private const string sPostURL = "https://mwomercs.com/do/login";
        private const string sMechURL = "https://mwomercs.com/profile/stats?type=mech";
        private const string sWeaponsURL = "https://mwomercs.com/profile/stats?type=weapon";
        //private const string sPilotURL = "https://mwomercs.com/profile/stats?type=pilot";
        private const string sMapURL = "https://mwomercs.com/profile/stats?type=map";
        private const string sModeURL = "https://mwomercs.com/profile/stats?type=mode";

        private string sMechs = "";
        private string sWeapons = "";
        //private string sPilots;
        private string sMaps = "";
        private string sModes = "";

        private int iTimer = 0;

        private Logger Log = null; 
        private Parsers Parser = null;


        SqlCeResultSet rs;

        private MWO_DB m_myDB = null;

        private clModeProcessor Modes = null;
        private clMechProcessor Mechs = null;
        private clMapProcessor Maps = null;
        private clWeaponProcessor Weapons = null;

        private List<int> lstLoadedMechs = new List<int>();
        private List<clSingleMatch> lstMatchHistory = new List<clSingleMatch>();

        private ResourceManager rm = Resources.ResourceManager;

        //DataTable dtMechList;

        // a magic bit, found on the web.. makes sure we appear as authenticated when we don't actually have a certificate to verify against.
        private static bool CertificateValidationCallBack( object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslErrors )
        {
            return true;
        }

        // constructor..
        public frmMWOStatSys()
        {

            InitializeComponent();
            ServicePointManager.ServerCertificateValidationCallback = CertificateValidationCallBack;

        }

        private void frmMWOStatSys_Load( object sender, EventArgs e )
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                m_myDB = new MWO_DB();

                m_http = new HTTPWorker();

                Log = new Logger();
                Parser = new Parsers();

                restoreSettings(); // needs to be up here if we want to log initialization..

                Modes = new clModeProcessor( ref m_myDB, ref Log, ref bNeedSeed );
                Maps = new clMapProcessor( ref m_myDB, ref Log, ref bNeedSeed );
                Mechs = new clMechProcessor( ref m_myDB, ref Log, ref bNeedSeed );
                Weapons = new clWeaponProcessor( ref m_myDB, ref Log, ref bNeedSeed );

                Color cGreen = Color.FromArgb(150, Color.LimeGreen);
                Color cRed = Color.FromArgb( 100, Color.Red );
                Color cBlue = Color.FromArgb( 150, Color.DodgerBlue );
                Color cYellow = Color.FromArgb( 150, Color.Goldenrod );

                // default colors are putting red on hits and green on misses, but I'd prefer to flip them
                chtAccuracy.ApplyPaletteColors();
                chtAccuracy.Palette = ChartColorPalette.None;
                chtEffective.Palette = ChartColorPalette.None;
                chtExpCbills.Palette = ChartColorPalette.None;
                chtAccuracy.Series[0].Color = cGreen;
                chtAccuracy.Series[1].Color = cRed;
                chtEffective.Series[0].Color = cYellow;
                chtEffective.Series[1].Color = cGreen;
                chtEffective.Series[2].Color = cBlue;
                chtExpCbills.Series[0].Color = cYellow;
                chtExpCbills.Series[1].Color = cGreen;
                chtExpCbills.Series[2].Color = cRed;
                chtAccuracy.Series[0]["DrawingStyle"] = "Cylinder";
                chtAccuracy.Series[1]["DrawingStyle"] = "Cylinder";
                chtExpCbills.Series[2]["DrawingStyle"] = "Cylinder";

                lblCurrentMech.Visible = false;

                vFillMechList();
 
                verifyLoginCredentials();

                olvMatchHistory.RowFormatter = delegate(OLVListItem olvi)
                {
                    clSingleMatch Match = (clSingleMatch)olvi.RowObject;
                    if (Match.bWin)
                        olvi.BackColor = Color.PaleGreen;
                    else
                        olvi.BackColor = Color.PaleVioletRed;
                };

            }
            catch ( Exception ex )
            {
                Cursor = Cursors.Default;
                MessageBox.Show( "Failed to initialize form: " + ex.Message );
                Application.Exit();
            }

        } // end of Load

        private void restoreSettings()
        {
            mnuLog1.Checked = false;

            switch (Properties.Settings.Default.LogLevel)
            {
                case 1:
                    mnuLog1.Checked = true;
                    mnuLog1_Click(null, null);
                    break;
                case 2:
                    mnuLog2.Checked = true;
                    mnuLog2_Click(null, null);
                    break;
                case 3:
                    mnuLog3.Checked = true;
                    mnuLog3_Click(null, null);
                    break;
                case 4:
                    mnuLog4.Checked = true;
                    mnuLog4_Click(null, null);
                    break;
            } // end of setting log level

            //Log.setErrorLevel = Properties.Settings.Default.LogLevel;

            mnuLogToFile.Checked = Properties.Settings.Default.LogToFile;
            mnuScrapesToFile.Checked = Properties.Settings.Default.ScrapeToFile;
            cbMG.Checked = Properties.Settings.Default.HideWeapMG;
            cbLRM.Checked = Properties.Settings.Default.HideWeapLRM;
            cbAM.Checked = Properties.Settings.Default.HideWeapAMS;
            cbNARC.Checked = Properties.Settings.Default.HideWeapNARC;
            cbTAG.Checked = Properties.Settings.Default.HideWeapTAG;

            cbZoom.Checked = Properties.Settings.Default.ChartDisplayZoomed;
            nmbScrapeFreq.Value = Properties.Settings.Default.AutoScrapeFreq;
            nmbMatches.Value = Properties.Settings.Default.MatchDisplayCount;

        }

        private void btnStart_Click( object sender, EventArgs e )
        {
            if ( ( sPassword.Length <= 0 ) || ( sUserId.Length <= 0 ) )
            {
                rs = m_myDB.ResultSet("select userid, password from login");  

                rs.ReadFirst(); // only 1 row, later we'll need a while loop and the ordinals seem to be the position in the return query

                sUserId = rs.GetString( 0 );
                sPassword = rs.GetString( 1 );

                rs.Close();

                if ( ( sPassword.Length <= 0 ) || ( sUserId.Length <= 0 ) )
                {
                    MessageBox.Show( "Can't start processing until you run the login info button..", "Must provide credentials" );
                    return;
                }
            }

            // now we can try to do some web stuff, we have user credentials to work with..
            // NOTE: we do a GET first, to get an initial new cookie that is needed when we do
            // our POST to the /do/login page. If there is no GET first, you fail to login..
            m_http = new HTTPWorker();
            m_http.Url = sLoginURL;
            m_http.Type = HTTPRequestType.Get;

            m_http.RequestObject.AllowAutoRedirect = false;
            try
            {
                Log.doIt( 3, "Sending request for login page.." );
                rsp = m_http.SendRequest();
            }
            catch ( WebException ex )
            {
                Log.doIt(1, ex.Message);
                btnShowError.UseVisualStyleBackColor = false;
                btnShowError.BackColor = Color.Red;
                return;
            }

            Log.doIt( 3, "Server response code from initial 'send request': " + rsp.StatusCode );
            Log.doIt( 3, "Response status desc: " + rsp.StatusDescription + "::" + rsp.ResponseUri );

            m_http.Url = sPostURL;
            m_http.RequestObject.AllowAutoRedirect = true;
            m_http.Type = HTTPRequestType.Post;
            m_http.AddValue( "email", sUserId );
            m_http.AddValue( "password", sPassword );

            try
            {
                Log.doIt( 3, "Sending UserID and Password.." );
                rsp = m_http.SendRequest();
            }
            catch ( WebException ex )
            {
                Log.doIt(1, ex.Message);
                btnShowError.UseVisualStyleBackColor = false;
                btnShowError.BackColor = Color.Red;

                return;
            }

            Log.doIt( 3, "Server response status code from sending password/email: " + rsp.StatusCode );
            Log.doIt( 3, "Response status desc: " + rsp.StatusDescription + "::" + "response URI: " + rsp.ResponseUri );
            Log.doIt( 4, "page text from http worker class: " + m_http.ResponseText ); // full page that came back..

            // we have success at this point, but the sample test code seems to be bullshit..
            if ( rsp.StatusCode == HttpStatusCode.OK )
            {
                // once we log in, we are at our profile page.. if we failed to login, the URI is for the login page
                // and contains "login"
                if ( rsp.ResponseUri.ToString().Contains( "login" ) )
                {
                    Log.doIt( 1, "Your login details were wrong." );
                    Log.doIt( 3, "Response URI: " + rsp.ResponseUri.ToString() );
                    btnShowError.UseVisualStyleBackColor = false;
                    btnShowError.BackColor = Color.Red;
                    return;
                }

                locationHeader = rsp.GetResponseHeader( "Location" );

                Log.doIt( 1, "Logged in successfully" );
                btnShowError.UseVisualStyleBackColor = false;
                btnShowError.BackColor = Color.Green;

                //btnScrapeIt_Click(this, null);
                bLoggedIn = true;
                return;

            }

            if ( rsp.StatusCode != HttpStatusCode.Found )
            {
                Log.doIt(1, string.Format( "Got unexpected status code '{0}' when trying to login.", rsp.StatusCode ));
                btnShowError.UseVisualStyleBackColor = false;
                btnShowError.BackColor = Color.Red;
                return;
            }

        } // end of btnStart_Click, logging in code..

        private void btnSetLogin_Click( object sender, EventArgs e )
        {
            sUserId = "";
            sPassword = "";

            if ( myLogin == null )
                myLogin = new LoginDetails( ref m_myDB );

            myLogin.ShowDialog();

        }

        /// <summary>
        /// Gonna scrape all the pages from here
        /// </summary>
        /// <param name="sender">Object from OS</param>
        /// <param name="e">Event Args from OS</param>
        private void btnScrapeIt_Click( object sender, EventArgs e )
        {

            clSingleMatch stMatch  = new clSingleMatch();

            // So..
            // baseline checking happens in the initialization of the processors/individual classes.. If any of them were not
            // seeded, we will use the scrape data as our "new" data and seed the baseline as we go..

            // Clicking the test button will have us read from local files..

            Cursor = Cursors.WaitCursor;
            btnScrapeIt.Enabled = false;

            if ( bTesting )
            {
                Log.doIt( 1, "Scraping from files since we're testing" );
                fillGridsFromFiles();
            }
            else
            {
                Log.doIt( 1, "Starting Scrape" );

                try
                {
                    Log.doIt( 1, "Logged in, going to scrape.." );

                    doScrape( sModeURL, ref sModes, "Mode" );
                    dgModes.DataSource = Parser.Convert( sModes ).Tables[0];

                    doScrape( sMechURL, ref sMechs, "Mech" );
                    dgMechs.DataSource = Parser.Convert( sMechs ).Tables[0];

                    doScrape( sWeaponsURL, ref sWeapons, "Weapons" );
                    dgWeapons.DataSource = Parser.Convert( sWeapons ).Tables[0];

                    doScrape( sMapURL, ref sMaps, "Maps" );
                    dgMaps.DataSource = Parser.Convert( sMaps ).Tables[0];
                }
                catch ( Exception ex )
                {
                    MessageBox.Show( "Failed to perform scrape as intended..: " + ex.Message );
                    Cursor = Cursors.Default;
                    btnScrapeIt.Enabled = true;
                    return;
                }
            }


            Log.doIt( 2, "Finished pulling web pages.." );

            // this happens when we intentionally dump all our data. It implies this scrape should only be put
            // back into our baseline tables, no processing of match should happen, just processing of scraped data
            if ( bNeedSeed )
            {
                if ( MessageBox.Show( "We seem to need to seed the baseline with this scrape, would you like to do that?",
                    "Invalid baseline found..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning ) == DialogResult.No )
                {
                    Cursor = Cursors.Default;
                    btnScrapeIt.Enabled = true;
                    return;
                }

                Log.doIt( 1, "Seeding base tables, flag indicates manual dump of baseline data.." );

                // we do it again because we might have only been missing 1 table during startup.. to make sure -everything- gets
                // a clean seed, we dump them here..
                m_myDB.clearAllBaseTables(); 

                //Modes.ClearSeed();
                Modes.SetBaselines( ref dgModes );

                //Maps.ClearSeed();
                Maps.SetBaselines( ref dgMaps );

               // Mechs.ClearSeed();
                Mechs.SetBaselines( ref dgMechs );

               // Weapons.ClearSeed();
                Weapons.SetBaselines( ref dgWeapons );

                Log.doIt( 2, "Finished seeding baselines.." );

                // dump our trackers, make them reload clean from the newly stuffed baseline tables..
                Modes = null;
                Maps = null;
                Mechs = null;
                Weapons = null;

                bNeedSeed = false; // reset it, let them tell us if we have a problem..

                Modes = new clModeProcessor( ref m_myDB, ref Log, ref bNeedSeed );
                Maps = new clMapProcessor( ref m_myDB, ref Log, ref bNeedSeed );
                Mechs = new clMechProcessor( ref m_myDB, ref Log, ref bNeedSeed );
                Weapons = new clWeaponProcessor( ref m_myDB, ref Log, ref bNeedSeed );

                Cursor = Cursors.Default;

                if ( bNeedSeed )
                {
                    MessageBox.Show( "Serious problems.. just seeded the baseline tables after a scrape, but we still think someone\n" +
                        "needs baseline info.. guess we'll bail and someone needs to debug this.." );
                    Application.Exit();
                }

                btnScrapeIt.Enabled = true;
                return;

            }

            // now we tell each management object to process their data. If we find anything of a "new match"
            // while parsing, we will fill in the match data at the manager level. Once we're done, we will tell
            // each class to fill our match object, which they will do with their internally tracked data.. If we
            // find anything missing BEFORE we get to weapons, we'll have to get the "unknown id" from the database
            // and use that in our match. I don't like having unknown states, but it's the most straight forward
            // way to process the data..

            // passing in by REF because we don't want to keep making new copies of these tables..
            Log.doIt( 1, "Processing match info..." );

            bool bNewMatch = false;

            Modes.processModes( ref dgModes );
            if ( !Modes.FoundMatch() )
            {
                // FOR NOW, we will just bail if we couldn't find a new mode.. However, the below logic SHOULD work
                // if we want to keep trying to process and gather as much as we can, bailing if we haven't found any
                // matches by the time we get to weapon processing.
                Log.doIt( 1, "Failed to find a match.. exiting processing.." );
                Cursor = Cursors.Default;
                btnScrapeIt.Enabled = true;
                return;

                // hmm.. something might be broke, but we'll continue on and use the "unknown" for the mode. This also
                // means we won't have access to CBills for the match..

                //TODO: Uncomment the below code if you want to attempt to find matches on MORE than just the "mode changed" logic.
                //  -- code commented out to get rid of warning at compile time.
                //rs = m_myDB.ResultSet( "select modeid from mode where name = 'Unknown'" );
                //if ( !rs.HasRows )
                //{
                //    m_myDB.Insert( "insert into mode(name) values('Unknown')" );
                //    rs = m_myDB.ResultSet( "select modeid from mode where name = 'Unknown'" );
                //}

                //int.TryParse( rs.GetString( 0 ), out stMatch.iMode );
            }
            else
            {
                bNewMatch = true;
            }

            Maps.processMaps( ref dgMaps );
            if ( !Maps.FoundMatch() )
            {
                // hmm.. something might be broke, but we'll continue on and use the "unknown" for the mode. This also
                // means we won't have access to CBills for the match..
                rs = m_myDB.ResultSet( "select mapid from maps where name = 'Unknown'" );
                if ( !rs.HasRows )
                {
                    m_myDB.Insert( "insert into maps(name) values('Unknown')" );
                    rs = m_myDB.ResultSet( "select mapid from maps where name = 'Unknown'" );
                }

                int.TryParse( rs.GetString( 0 ), out stMatch.iMap );

            }
            else
            {
                bNewMatch = true;
            }

            Mechs.processMechs( ref dgMechs );
            if ( !Mechs.FoundMatch() )
            {
                // hmm.. something might be broke, but we'll continue on and use the "unknown" for the mode. This also
                // means we won't have access to CBills for the match..
                rs = m_myDB.ResultSet( "select mechid from mechs where fullname = 'Unknown'" );
                if ( !rs.HasRows )
                {
                    Log.doIt( 1, "Failed to find a MECH for this match, perhaps PGI forgot how to update stats again!" );

                    m_myDB.Insert( "insert into mechs(fullname) values('Unknown')" );
                    rs = m_myDB.ResultSet( "select mechid from mechs where fullname = 'Unknown'" );
                }

                int.TryParse( rs.GetString( 0 ), out stMatch.iMech );

            }
            else
            {
                bNewMatch = true;
            }

            // now we do some actual match stuff.. since all of the previous managers reported having a match (or having their
            // IDs set to Unknown), we will process the weapons, then fill our match object from all the manager's prepared data..
            if ( bNewMatch )
            {
                Weapons.processWeapons( ref dgWeapons );
            }
            else
            {
                Log.doIt( 1, "No match found before we got to WEAPONS.. not processing weapons.." );
                Modes.ReSeed();
                Maps.ReSeed();
                Mechs.ReSeed();
                Weapons.ReSeed();
                iTimer = 0;
                pbNextScrape.Value = 0;
                Cursor = Cursors.Default;
                btnScrapeIt.Enabled = true;
                return;
            }

            // Now that we're here, we have match data to insert into the match table, send in our match object into
            // each part to build the match, insert the match, then have the weapons shove it's data into the
            // matchdetails table..

            Modes.fillMatch( ref stMatch );
            Maps.fillMatch( ref stMatch );
            Mechs.fillMatch( ref stMatch );

            Log.doIt( 2, "Inserting match into database.." );
            m_myDB.InsertMatch( ref stMatch ); // this will FILL IN our match id after it pushes the data to the Match table..

            // now that we have the match ID from putting the base match in the database, have the weapon manager put all the
            // found weapons in the details table, with our new match id
            Log.doIt( 2, "Putting weapons in match detials.." );
            stMatch.iDamage = Weapons.fillMatch( stMatch.iMatchId );

            // now we reseed everything..
            Log.doIt( 2, "Re-Seeding our managers with scraped data.." );
            Modes.ReSeed();
            Maps.ReSeed();
            Mechs.ReSeed();
            Weapons.ReSeed();

            iTimer = 0;
            pbNextScrape.Value = 0;

            Log.doIt( 1, "Finished parsing, match processed!" );
            btnShowError.UseVisualStyleBackColor = false;
            btnShowError.BackColor = Color.Green;

            // if we run a new mech for the first time, we need to dump our list and rebuild it.
            if ( !lstLoadedMechs.Contains(stMatch.iMech) )
            {
                Log.doIt(1, "Found new mech, rebuilding the tab control list");
                tabMechInfo.Controls.Clear();
                vFillMechList();                
            }

            vUpdateLastMechMatch(ref stMatch);

            Cursor = Cursors.Default;
            btnScrapeIt.Enabled = true;

        } // End of Scrape processing/button click

        /// <summary>
        /// Updates the MechMatchDetail object that matches the newly scraped match
        /// </summary>
        /// <param name="clMatch">
        /// Match info object for our last match; gives us the mech and matchid for stat gathering
        /// </param>
        private void vUpdateLastMechMatch(ref clSingleMatch clMatch)
        {
            Log.doIt(2, "Updating last Mech's match info..");

            Cursor = Cursors.WaitCursor;
            tcCharts.SelectedIndex = 0; // set the active tab to our mech list..

            try
            {
                foreach (clMechMatch clTmp in tabMechInfo.Controls)
                {

                    if (clTmp.MechId == clMatch.iMech)
                    {
                        clTmp.LastMatch(ref clMatch);
                        clTmp.SetHighlight();

                        // when we're updating the same mech from two scrapes in a row, don't click.. clicking closes
                        // an open group..
                        if ((clCurrentMech != null) && (clCurrentMech.MechId == clTmp.MechId))
                        {
                            if (clTmp.Expanded == true)
                            {
                                tabMechInfo.ScrollControlIntoView(clTmp);
                            }
                            else
                            {
                                clTmp.ExpandButton.PerformClick();
                            }
                        }
                        else
                        {
                            if (clCurrentMech != null)
                            {
                                clCurrentMech.Active = false;
                            }

                            clCurrentMech = clTmp;
                            clCurrentMech.Active = true;
                            lblCurrentMech.Text = clCurrentMech.Caption;
                            clTmp.ExpandButton.PerformClick();
                        }
                    }
                    else
                    {
                        clTmp.ClearHighlight();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.doIt(1, "Got an exception trying to update last match?");
                Log.doIt(1, ex.Message);
            }

            Cursor = Cursors.Default;
        }

        private void fillGridsFromFiles()
        {
            StreamReader sr;

            sr = new StreamReader( @"C:\temp\mech.txt" );
            sMechs = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
            sr = null;
            miniParse( ref sMechs );
            dgMechs.DataSource = Parser.Convert( sMechs ).Tables[0];

            sr = new StreamReader( @"C:\temp\weapon.txt" );
            sWeapons = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
            sr = null;
            miniParse( ref sWeapons );
            dgWeapons.DataSource = Parser.Convert( sWeapons ).Tables[0];

            sr = new StreamReader( @"C:\temp\map.txt" );
            sMaps = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
            sr = null;
            miniParse( ref sMaps );
            dgMaps.DataSource = Parser.Convert( sMaps ).Tables[0];

            sr = new StreamReader( @"C:\temp\mode.txt" );
            sModes = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
            sr = null;
            miniParse( ref sModes );
            dgModes.DataSource = Parser.Convert( sModes ).Tables[0];

        }

        private void vFillMechList()
        {
            Cursor = Cursors.WaitCursor;

            bLoading = true;
            clMechMatch clMM;
            clSingleMatch stMatch = new clSingleMatch();

            DataTable dt = null;

            lstLoadedMechs.Clear();

            while (tabMechInfo.Controls.Count > 0)
            {
                clMM = (clMechMatch)tabMechInfo.Controls[tabMechInfo.Controls.Count - 1];
                tabMechInfo.Controls.Remove(clMM);
                clMM.Dispose();
                clMM = null;
            }

            rs = m_myDB.ResultSet("select MechId, fullname from mechs where mechid in (select distinct mech from match) order by fullname desc");

            while ( rs.Read() )
            {
                int iMechId = (int)rs.GetValue(0);

                clMM = new clMechMatch(iMechId, rs.GetString(1), tabMechInfo.Width, ref m_myDB);
                clMM.MechImage = (Image)rm.GetObject(clMM.MechDesignation.Replace("-", "_").ToLower());

                // to force our new sizes from our own event that makes sure only one groupbox is expanded at at time..
                clMM.Expand += new EventHandler(clMechMatch_Expand);
                clMM.Expanded = false; 

                clMM.YesImage = (Image)rm.GetObject("check");
                clMM.NoImage = (Image)rm.GetObject("x");

                // get the last match for this mech..
                int iMatchId = m_myDB.iNumValReturn("select max(matchid) from match where mech = " + iMechId);

                stMatch.LoadMatch(ref m_myDB, iMatchId);

                clMM.SeedMatch(ref stMatch); 

                tabMechInfo.Controls.Add(clMM);
                lstLoadedMechs.Add(clMM.MechId);
            }

            // Not exactly sure how to reset the resultset, so just make the query again.. should be fast anyway..
            rs = m_myDB.ResultSet("select MechId, fullname from mechs where mechid in (select distinct mech from match) order by fullname");
            dt = Parser.ResultSetToDataTable(rs, ref Log);

            cbMechList.ValueMember = "MechId";
            cbMechList.DisplayMember = "fullname";
            cbMechList.DataSource = dt;

            cbMechList.SelectedIndex = -1; // unselect everything..

            bLoading = false;
            Cursor = Cursors.Default;
        } // end of FillMechList..
      
        private void btnTest_Click( object sender, EventArgs e )
        {
            bTesting = true;
            //btnScrapeIt.PerformClick();
            btnScrapeIt_Click( this, null );
            return;

        }

        private void doScrape( string URL, ref string result, string sType )
        {

            // The first time we run this, we aren't logged in. No point in trying to play with error bits
            // when we don't need to. However, if we LOSE the login we won't know it, so we'll get the "login?return"
            // bit when we try to scrape, so we'll worry about re-logging in at that point.
            if ( !bLoggedIn )
            {
                //btnStart.PerformClick(); // if button is hidden or disabled, this isn't working..
                btnStart_Click( this, null );

                if ( !bLoggedIn )
                {
                    Log.doIt( 1, "Failed to log in on our first pass.. something is wrong, going to bail.." );
                    throw new Exception( "Failed to log in on first attempt..?" );
                }
            }

            m_http.Url = URL;
            m_http.Type = HTTPRequestType.Get;
            m_http.RequestObject.AllowAutoRedirect = true;

            try
            {
                rsp = m_http.SendRequest();
            }
            catch ( WebException ex )
            {
                Log.doIt(1, ex.Message);
                btnShowError.BackColor = Color.Red;
                return;
            }

            int iCount = 0;

            while ( rsp.ResponseUri.ToString().Contains( "login?return" ) && ( iCount++ < 10 ) )
            {
                // this means we failed to make a valid request, the Uri is now asking for a login and
                // we have big problems since we did a login when we entered this page (if we needed one)..
                Log.doIt( 2, "Seems we weren't logged in, waiting 1/2 a second and trying again" );
                System.Threading.Thread.Sleep( 500 );
                btnStart_Click( this, EventArgs.Empty );
            }

            if ( iCount >= 10 )
            {
                MessageBox.Show( "Failed to connect? .. bailing.. " );
                throw new Exception("Failed to login after 10 attempts.. .bailing (someone should debug this)");
            }


            m1 = Regex.Matches( m_http.ResponseText, @"(?<=<tbody[^>]*>).*?(?=</tbody>)", RegexOptions.Singleline );

            //rtbPage.Clear();
            result = "<table>\n";
            string txt;
            foreach ( Match m in m1 )
            {
                txt = m.ToString().Replace( '\t', ' ' );
                result += "  " + txt.Trim();
            }
            result += "\n</table>";

            if ( bScrapesToFile )
            {
                string sFileName = sType + "_" + DateTime.Now.ToString( "MMddyyyyHHmmssfff" ) + ".html";
                string sFileDir = System.Environment.CurrentDirectory + "\\Scrapes";

                if ( !Directory.Exists( sFileDir ) )
                    Directory.CreateDirectory( sFileDir );

                StreamWriter sw = new StreamWriter(sFileDir + "\\" + sFileName, true);
                sw.Write( result );
                sw.Flush();
                sw.Close();

            }

        }

        private void miniParse( ref string sHTML )
        {
            string result;
            string txt;


            m1 = Regex.Matches( sHTML, @"(?<=<tbody[^>]*>).*?(?=</tbody>)", RegexOptions.Singleline );

            //rtbPage.Clear();
            result = "<table>\n";

            foreach ( Match m in m1 )
            {
                txt = m.ToString().Replace( '\t', ' ' );
                result += "  " + txt.Trim();
            }

            result += "\n</table>";

            sHTML = result;
        }

        private void btnShowError_Click( object sender, EventArgs e )
        {
            Log.frmShow();
            btnShowError.UseVisualStyleBackColor = true;
            btnShowError.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// Checks the database to see if there is a userid and password stored. If so, we move on.. if not we'll prompt for
        ///  credentials (might remove this, some people might not like it.. but can't connect without them and don't really like
        ///  the idea of having them hard coded either).
        /// </summary>
        private void verifyLoginCredentials()
        {

            if ( m_myDB.CountTable("login") == 0 )
            {
                // bNoLogin is true by default.. if we have no credentials, we'll run the login window before we allow
                // scraping to start. If they refuse to provide login data, we refuse to run.
                MessageBox.Show( "You have no login credentials in the database. Please click on the"
                    + " Login button and provide your user ID and Password so this application can get"
                    + " your MWO statistics from your stat profile pages." );
                return;
            }

            // we have data in the database.. grab it to move on..
            rs = m_myDB.ResultSet( "select userid, password from login" );

            rs.ReadFirst();
            // only 1 row, later we'll need a while loop and the ordinals seem to be the position in the return query
            sUserId = rs.GetString( 0 );
            sPassword = rs.GetString( 1 );

            rs.Close();

        }

        private void btnCheckLogin_Click( object sender, EventArgs e )
        {

            if ( m_myDB.CountTable("login") == 0 )
            {
                MessageBox.Show( "Seems no login credentials are present.. Use the Login Info button to fix that.." );
                return;
            }

            rs = m_myDB.ResultSet( "select userid, password from login" );

            rs.ReadFirst(); // only 1 row, later we'll need a while loop and the ordinals seem to be the position in the return query
            //int ordUser = rs.GetOrdinal( "userid" );
            //int ordPass = rs.GetOrdinal( "password" );
            //sUserId = rs.GetString( ordUser );
            //sPassword = rs.GetString( ordPass );
            sUserId = rs.GetString( 0 );
            sPassword = rs.GetString( 1 );

            rs.Close();

            MessageBox.Show( "Your login credentials are presently set to:\n\n"
                             + "sUserId: " + sUserId + "\nsPassword: " + sPassword + "\n\nTo change these, use the" +
                             " Login Info button" );
        }

        private void frmMWOStatSys_Shown( object sender, EventArgs e )
        {
            // Log on to the website right off the bat..
            //if ( MessageBox.Show( "Would you like to initiate a web logon before we get started?\n\n(Saying no doesn't hurt anything)",
            //    "Preemptive logon", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes )
            //{
            //    btnStart_Click( this, EventArgs.Empty );
            //}

            bLoading = false;
            tabMechInfo.Focus();
            Cursor = Cursors.Default;
            //FillCharts(); // I turned this on when I was testing setting the active mech/match during load, to play with the panel colors..

        }

        private void frmMWOStatSys_FormClosing( object sender, FormClosingEventArgs e )
        {
            m_myDB.CloseConnections();

            Properties.Settings.Default.LogToFile = mnuLogToFile.Checked;
            Properties.Settings.Default.ScrapeToFile = mnuScrapesToFile.Checked;
            Properties.Settings.Default.HideWeapMG = mnuMG.Checked;
            Properties.Settings.Default.HideWeapLRM = mnuLRM.Checked;
            Properties.Settings.Default.HideWeapAMS = mnuAM.Checked;
            Properties.Settings.Default.HideWeapNARC = mnuNARC.Checked;
            Properties.Settings.Default.HideWeapTAG = mnuTAG.Checked;

            Properties.Settings.Default.ChartDisplayZoomed = cbZoom.Checked;
            Properties.Settings.Default.AutoScrapeFreq = nmbScrapeFreq.Value;
            Properties.Settings.Default.MatchDisplayCount = nmbMatches.Value;

            Properties.Settings.Default.Save();

        }

        private void timer1_Tick( object sender, EventArgs e )
        {
            // we'll check the web every 5 minutes by default.. successful matches tend to last longer, and even if you
            // quit the first match, either it will end/post while you're playing or it will hang until after you're 
            // out of the new one.. we'll have a button for manual scraping (to see if a match posted)..
            if ( iTimer++ >= (nmbScrapeFreq.Value * 60) )
            {
                iTimer = 0;
                btnScrapeIt_Click( this, e );
                return;
            }

            pbNextScrape.Value = iTimer;
        }

        private void btnClear_Click( object sender, EventArgs e )
        {
            m_myDB.clearAllBaseTables();
            bNeedSeed = true;
        }

        private void cbAutoScrape_CheckedChanged( object sender, EventArgs e )
        {
            if ( cbAutoScrape.Checked )
            {
                timer1.Start();
                btnScrapeIt_Click( null, null );
            }
            else
            {
                timer1.Stop();
                iTimer = 0; 
                pbNextScrape.Value = 0;
            }
        }

        private void FillCharts( )
        {
            // if we're loading our box, just bail.. no point in filling charts if we're not actually
            // selecting a mech
            if ((bLoading)  || ((clCurrentMech != null) && (clCurrentMech.MechId == -1)))
            {
                return;
            }

            try
            {
                Log.doIt(3, "Starting building of chart select queries.." );
                DataTable dt;
                string sExcludeWeaps = "";
                string sJustExclWeapNums = "";
                string sCommand = "";

                if( mnuAM.Checked )
                {
                    Log.doIt(3, "Found Anti-Missile checked.." );
                    rs = m_myDB.ResultSet( "select weaponid from weapons where name = 'ANTI-MISSILE SYSTEM' or name like '%AMS'" );
                    while ( rs.Read() )
                    {
                        sExcludeWeaps += rs.GetValue( 0 ) + ",";
                    }
                }

                // multiple types, need all the numbers.. do an execute resultset and read through all the numbers, putting them in the string
                if ( mnuLRM.Checked )
                {
                    Log.doIt(3, "Found LRM checked.." );
                    rs = m_myDB.ResultSet( "select weaponid from weapons where name like '%LRM%'" );
                    while ( rs.Read() )
                    {
                        sExcludeWeaps +=  rs.GetValue( 0 ) + ",";
                    }
                }

                if ( mnuMG.Checked )
                {
                    Log.doIt( 3, "Found Machine Guns checked.." );
                    rs = m_myDB.ResultSet("select weaponid from weapons where name like '%MACHINE GUN'");
                    while (rs.Read())
                    {
                        sExcludeWeaps += rs.GetValue(0) + ",";
                    }
                }

                if ( mnuTAG.Checked )
                {
                    Log.doIt( 3, "Found TAG checked.." );
                    rs = m_myDB.ResultSet("select weaponid from weapons where name like '%TAG'");
                    while (rs.Read())
                    {
                        sExcludeWeaps += rs.GetValue(0) + ",";
                    }
                }

                if ( mnuNARC.Checked )
                {
                    Log.doIt( 3, "Found NARC checked.." );

                    rs = m_myDB.ResultSet("select weaponid from weapons where name like '%NARC'");
                    while (rs.Read())
                    {
                        sExcludeWeaps += rs.GetValue(0) + ",";
                    }

                }

                if ( sExcludeWeaps.EndsWith( "," ) )
                {
                    Log.doIt( 3, "Found trailing , in exclude list" );
                    sExcludeWeaps = sExcludeWeaps.Remove( sExcludeWeaps.LastIndexOf( ',' ) );
                }

                if ( sExcludeWeaps.Length > 0 )
                {
                    sJustExclWeapNums = sExcludeWeaps; // before we mess with the string, just numbers..
                    sExcludeWeaps = " AND (MatchDetails.Weapon NOT IN (" + sExcludeWeaps + ")) ";
                }

                Log.doIt( 3, "exclusion list..: |" + sExcludeWeaps + "|" );

                sCommand = "SELECT SUM(MatchDetails.Hits) AS Expr1, SUM(MatchDetails.Misses) AS Expr2, " +
                    "SUM(MatchDetails.DmgDone) AS Expr3, Weapons.Name as weap, Match.Date FROM  Match INNER JOIN  MatchDetails ON " +
                    "Match.MatchId = MatchDetails.MatchId INNER JOIN Weapons ON MatchDetails.Weapon = Weapons.WeaponId " +
                    "WHERE (Match.matchid in (select top (" + (int)nmbMatches.Value +") matchid from match where mech = " + 
                      clCurrentMech.MechId + " order by matchid desc))" + sExcludeWeaps + " GROUP BY Match.MatchId, " +
                    "Weapons.Name, Match.Date ORDER BY Match.Date DESC";

                Log.doIt(3, "Chart select, hits/misses: " + sCommand );
                dt = Parser.ResultSetToDataTable( m_myDB.ResultSet( sCommand ), ref Log );
                dt = Parser.ReverseRowsInDataTable( dt );

                chtAccuracy.DataSource = dt;

                //chtAccuracy.Series["Hits"].XValueMember = "MatchId";
                chtAccuracy.Series["Hits"].YValueMembers = "Expr1";
                chtAccuracy.Series["Hits"].XValueMember = "Weap";
                chtAccuracy.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                //chtAccuracy.Series["Misses"].XValueMember = "MatchId";
                chtAccuracy.Series["Misses"].YValueMembers = "Expr2";
                chtAccuracy.ChartAreas[0].CursorX.IsUserEnabled = true;
                chtAccuracy.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                chtAccuracy.ChartAreas[0].AxisX.ScaleView.Zoomable = true;


                chtAccuracy.DataBind();

                sCommand = "SELECT MatchDetails.DmgDone AS YourDamage, " +
                    "(Weapons.MaxDmg * MatchDetails.Hits) AS MaxDmg, (Weapons.MaxDmg * (MatchDetails.Hits + MatchDetails.Misses)) as Theoretical, " +
                    " weapons.name as weap, match.date FROM Match INNER JOIN MatchDetails " +
                    "ON Match.MatchId = MatchDetails.MatchId INNER JOIN Weapons ON MatchDetails.Weapon = Weapons.WeaponId " +
                    " WHERE (Match.matchid in (select top (" + (int)nmbMatches.Value +") matchid from match where mech = " + 
                      clCurrentMech.MechId + " order by matchid desc))" + sExcludeWeaps + " GROUP BY match.date, weapons.name, " +
                    " MatchDetails.DmgDone, Weapons.MaxDmg, matchdetails.hits, matchdetails.misses order by match.date desc";

                Log.doIt( 3, "Chart select, effective: " + sCommand );

                dt = Parser.ResultSetToDataTable( m_myDB.ResultSet( sCommand ), ref Log );
                dt = Parser.ReverseRowsInDataTable( dt );

                chtEffective.DataSource = dt;
                chtEffective.Series["MaxPossible"].YValueMembers = "MaxDmg";
                chtEffective.Series["MaxPossible"].XValueMember = "Weap";
                chtEffective.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                chtEffective.Series["YourDamage"].YValueMembers = "YourDamage";
                chtEffective.Series["Theoretical"].YValueMembers = "Theoretical";

                chtEffective.DataBind();

                sCommand = "select top(" + (int)nmbMatches.Value + ") a.exp, a.cbills, sum(b.dmgdone) as dmg, a.date from " +
                    "match a inner join matchdetails b on a.matchid = b.matchid where mech = " + clCurrentMech.MechId + 
                    " group by date, exp, cbills order by date desc";

                Log.doIt( 3, "Chart select, exp and cbills: " + sCommand );

                dt = Parser.ResultSetToDataTable( m_myDB.ResultSet( sCommand ), ref Log );
                dt = Parser.ReverseRowsInDataTable( dt );

                chtExpCbills.DataSource = dt;
                chtExpCbills.Series["Exp"].YValueMembers = "exp";
                chtExpCbills.Series["cBills"].YValueMembers = "cbills";
                chtExpCbills.Series["Damage"].YValueMembers = "dmg";
                //chtExpCbills.Series["Exp"].XValueMember = "date";
                //chtExpCbills.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

                chtExpCbills.DataBind();

                //dgStats.DataSource = dt;


            }
            catch ( Exception ex )
            {
                MessageBox.Show( "Error in index changed? .. " + ex.Message );
            }
        }

        private void mnuLogToFile_CheckedChanged(object sender, EventArgs e)
        {
            // Currently, only log window messages will go to file.. 
            if (mnuLogToFile.Checked)
            {
                Log.bToFile = true;
            }
            else
            {
                Log.bToFile = false;
            }

        }

        private void cbZoom_CheckedChanged( object sender, EventArgs e )
        {
            if ( !cbZoom.Checked )
            {
                chtAccuracy.ChartAreas[0].AxisX.ScaleView.ZoomReset( 0 );
                chtEffective.ChartAreas[0].AxisX.ScaleView.ZoomReset( 0 );
                chtExpCbills.ChartAreas[0].AxisX.ScaleView.ZoomReset( 0 );
                return;
            }

            int iCols = 0;
            // box just got checked..
            iCols = chtAccuracy.Series[0].Points.Count;
            chtAccuracy.ChartAreas[0].AxisX.ScaleView.Zoom( ( iCols - 10 ) <0? 0:iCols-10, chtAccuracy.Series[0].Points.Count );
            iCols = chtEffective.Series[0].Points.Count;
            chtEffective.ChartAreas[0].AxisX.ScaleView.Zoom( ( iCols - 10 ) <0? 0:iCols-10, chtEffective.Series[0].Points.Count );
            iCols = chtExpCbills.Series[0].Points.Count;
            chtExpCbills.ChartAreas[0].AxisX.ScaleView.Zoom( ( iCols - 10 ) < 0? 0:iCols-10, chtExpCbills.Series[0].Points.Count );

        }

        private void mnuLog1_Click( object sender, EventArgs e )
        {
            mnuLog2.Checked = false;
            mnuLog3.Checked = false;
            mnuLog4.Checked = false;
            Log.setErrorLevel = 1;

            Properties.Settings.Default.LogLevel = 1;

        }

        private void mnuLog2_Click( object sender, EventArgs e )
        {
            mnuLog1.Checked = false;
            mnuLog3.Checked = false;
            mnuLog4.Checked = false;
            Log.setErrorLevel = 2;

            Properties.Settings.Default.LogLevel = 2;
        }

        private void mnuLog3_Click( object sender, EventArgs e )
        {
            mnuLog1.Checked = false;
            mnuLog2.Checked = false;
            mnuLog4.Checked = false;
            Log.setErrorLevel = 3;

            Properties.Settings.Default.LogLevel = 3;

        }

        private void mnuLog4_Click( object sender, EventArgs e )
        {
            mnuLog1.Checked = false;
            mnuLog2.Checked = false;
            mnuLog3.Checked = false;
            Log.setErrorLevel = 4;

            Properties.Settings.Default.LogLevel = 4;
        }

        private void mnuMG_Click( object sender, EventArgs e )
        {
            bSuspendClicks = true;
            // we base our weapon exclusion on the menu, not the check box.. calling the chart updating
            // before setting the checkbox is fine..
            FillCharts();
            cbMG.Checked = mnuMG.Checked;
            bSuspendClicks = false;
        }

        private void mnuLRM_Click(object sender, EventArgs e)
        {
            bSuspendClicks = true;
            FillCharts();
            cbLRM.Checked = mnuLRM.Checked;
            bSuspendClicks = false;
        }

        private void mnuAM_Click(object sender, EventArgs e)
        {
            bSuspendClicks = true;
            FillCharts();
            cbAM.Checked = mnuAM.Checked;
            bSuspendClicks = false;
        }

        private void mnuTAG_Click(object sender, EventArgs e)
        {
            bSuspendClicks = true;
            FillCharts();
            cbTAG.Checked = mnuTAG.Checked;
            bSuspendClicks = false;
        }

        private void mnuNARC_Click(object sender, EventArgs e)
        {
            bSuspendClicks = true;
            FillCharts();
            cbNARC.Checked = mnuNARC.Checked;
            bSuspendClicks = false;
        }

        private void mnuScrapesToFile_CheckedChanged(object sender, EventArgs e)
        {
            if (mnuScrapesToFile.Checked)
                bScrapesToFile = true;
            else
                bScrapesToFile = false;
        }

        private void cbMG_CheckedChanged( object sender, EventArgs e )
        {
            // the menu CLICK will also rebuild the charts.. we don't want to call that a second time, nor
            // do we want to change the menu value if that's where we came from.. only set the menu checked state
            // and rebuild chart data if we were clicked directly..
            if ( !bSuspendClicks )
            {
                mnuMG.Checked = cbMG.Checked;
                FillCharts();
            }
        }

        private void cbLRM_CheckedChanged( object sender, EventArgs e )
        {
            if ( !bSuspendClicks )
            {
                mnuLRM.Checked = cbLRM.Checked;
                FillCharts();
            }

        }

        private void cbAM_CheckedChanged( object sender, EventArgs e )
        {
            if ( !bSuspendClicks )
            {
                mnuAM.Checked = cbAM.Checked;
                FillCharts();
            }
        }

        private void cbTAG_CheckedChanged( object sender, EventArgs e )
        {
            if ( !bSuspendClicks )
            {
                mnuTAG.Checked = cbTAG.Checked;
                FillCharts();
            }
        }

        private void cbNARC_CheckedChanged( object sender, EventArgs e )
        {
            if ( !bSuspendClicks )
            {
                mnuNARC.Checked = cbNARC.Checked;
                FillCharts();
            }
        }

        private void nmbScrapeFreq_ValueChanged( object sender, EventArgs e )
        {
            pbNextScrape.Maximum = (int)nmbScrapeFreq.Value * 60;
        }

        private void btnTryLogon_Click( object sender, EventArgs e )
        {
            btnStart_Click( this, e );
            if ( !bLoggedIn )
            {
                MessageBox.Show( "Failed logon test.." );
            }
        }

        private void clMechMatch_Expand(object sender, EventArgs e)
        {
            clMechMatch tmp = null;
            foreach (clMechMatch ctrl in tabMechInfo.Controls)
            {
                if (ctrl == sender)
                    tmp = ctrl;
                else
                    ctrl.Expanded = false;

                ctrl.Refresh();
            }

            if (tmp != null)
            {
                tmp.Expanded = tmp.Expanded;
                //iCurrentMech = tmp.MechId;
                if (clCurrentMech != null)
                    clCurrentMech.Active = false;
                clCurrentMech = tmp;
                clCurrentMech.Active = true;
                lblCurrentMech.Text = clCurrentMech.Caption;
                tabMechInfo.ScrollControlIntoView(tmp);
                tmp.Refresh();
            }

            FillCharts(); // since we have a new active mech, fill his charts..
            tabMechInfo.Focus();
        }

        private void tcCharts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // don't show the active mech label on the main mech list, or on the tab page
            // that lets them change which mech they're looking at for the histories..
            if ( (tcCharts.SelectedIndex == 0) || (tcCharts.SelectedIndex == 4) )
            {
                lblCurrentMech.Visible = false;
                // only set focus when they go to the main mech tab..
                if (tcCharts.SelectedIndex == 0)
                {
                    tabMechInfo.Focus();
                }

                if (clCurrentMech != null)
                {
                    cbMechList.SelectedValue = clCurrentMech.MechId;
                }

            }
            else
            {
                lblCurrentMech.Visible = true;
            }
        }

        private void cbMechList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // we only want to get histories when the histories tab is selected..
            if ((bLoading) || (tcCharts.SelectedIndex != 4))
                return;

            lblWins.Text = "---";
            lblLosses.Text = "---";
            lblKills.Text = "---";
            lblDeaths.Text = "---";
            lblMatchCount.Text = "----";
            lblCBills.Text = "------";

            pnlMechSelect.Refresh();
            Application.DoEvents();

            vLoadHistories();
        }

        private void vLoadHistories()
        {
            // fill the match history tab page with all the matches for this mech.
            Cursor = Cursors.WaitCursor;
            long lWins = 0;
            long lKills = 0;
            long lDeaths = 0;
            long lMatchCount = 0;
            long lCBills = 0;

            //clStatPanel clTmp;
            clSingleMatch clTmp;

            // we have to manually retrieve and dispose our stat panels, or we burn up user objects quite quickly.
            //while (flpMatches.Controls.Count > 0)
            //{
            //    clTmp = (clStatPanel)flpMatches.Controls[flpMatches.Controls.Count - 1];
            //    flpMatches.Controls.Remove(clTmp);
            //    clTmp.Dispose();
            //    clTmp = null;
            //}

            olvMatchHistory.ClearObjects();
            lstMatchHistory.Clear();

            //flpMatches.Refresh();
            //Application.DoEvents(); // try to clear the panel sooner/faster..

            // get all the histories for the currently selected mech..
            rs = m_myDB.ResultSet("select c.name as Map, d.name as Mode, a.kills, a.Death, a.WinLoss, a.Exp, a.cBills, a.duration, a.date, " +
                " case when sum(b.dmgdone) is null then 0 else sum(b.dmgdone) end as Damage, " +
                " case when sum(b.hits) is null then 0 else sum(b.hits) end as Hits, " +
                " case when sum(b.misses) is null then 0 else sum(b.misses) end as Misses " +
                " from Match a left join matchdetails b on a.matchid = b.matchid " +
                " join maps c on a.map = c.mapid " +
                " join mode d on a.mode = d.modeid " +
                " where a.Mech = " + cbMechList.SelectedValue +
                " group by a.matchid, c.name, d.name, kills, death, winloss, exp, cbills, duration, date" +
                " order by a.matchid desc");

            int iKills = 0;
            int iCBills = 0;
            bool bWin = false;
            bool bDeath = false;

            while (rs.Read())
            {
                iKills = (int)rs.GetByte(2);
                iCBills = (int)rs.GetValue(6);
                bWin = ((char)rs.GetString(4)[0]) == 'W'? true : false;
                bDeath = rs.GetBoolean(3);

                //clTmp = new clStatPanel();
                clTmp = new clSingleMatch();
                //clTmp.YesImage = (Image)rm.GetObject("check");
                //clTmp.NoImage = (Image)rm.GetObject("x");
                //clTmp.Map = (string)rs.GetValue(0);
                clTmp.sMap = (string)rs.GetValue(0);
                //clTmp.Mode = (string)rs.GetValue(1);
                clTmp.sMode = (string)rs.GetValue(1);
                //clTmp.Kills = iKills;
                clTmp.iKills = iKills;
                //clTmp.Lived = !bDeath;
                clTmp.bDeath = bDeath;
                //clTmp.Win= bWin;
                clTmp.bWin = bWin;
                //clTmp.Exp = (int)rs.GetInt16(5);
                clTmp.iExp = (int)rs.GetInt16(5);
                //clTmp.cBills = iCBills;
                clTmp.iCBills = iCBills;
                ////clTmp.iDuration = (int)rs.GetInt16(7);
                //clTmp.Date = (DateTime)rs.GetDateTime(8);
                clTmp.dtDate = (DateTime)rs.GetDateTime(8);
                //clTmp.Damage = ((int)rs.GetValue(9)).ToString();
                clTmp.iDamage = (int)rs.GetValue(9);
                //clTmp.Hits = (int)rs.GetValue(10);
                clTmp.iHits = (int)rs.GetValue(10);
                //clTmp.Misses = (int)rs.GetValue(11);
                clTmp.iMisses = (int)rs.GetValue(11);

                //clTmp.Dock = DockStyle.Top;

                //flpMatches.Controls.Add(clTmp);
                lstMatchHistory.Add(clTmp);

                lMatchCount++;
                lKills += iKills;
                lCBills += iCBills;
                if (bWin)
                    lWins++;
                if (bDeath)
                    lDeaths++;
            }

            lblWins.Text = lWins.ToString();
            lblKills.Text = lKills.ToString();
            lblMatchCount.Text = lMatchCount.ToString();
            lblDeaths.Text = lDeaths.ToString();
            lblCBills.Text = string.Format("{0:#,###}", lCBills);
            lblLosses.Text = (lMatchCount - lWins).ToString();

            olvMatchHistory.SetObjects(lstMatchHistory);
            olvMatchHistory.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            ResumeLayout();
            //flpMatches.Focus();
            olvMatchHistory.Focus();

            Cursor = Cursors.Default;
        }
    }

}
