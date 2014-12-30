/*
 *   MWOStatScraper is a tool to gather and process personal match data from 
 *   the MWOMercs website, for the game MechWarrior Online.
 * 
 *   Copyright (C) 2014  {Ray}
 *   
 *   See the full license notification in the frmMWOStatSys.cs file
 */

using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWOStatSystem.Support_Classes
{
    class clMode
    {
        private MWO_DB m_myDb;
        private Logger Log;

        private bool bScraped = false;
        private bool bModeIsSeeded = false;

        private string m_sMode;
        private int m_iModeId;

        // Webscrape values
        private int iWebMatches = 0;
        private int iWebWins = 0;
        private int iWebLosses = 0;
        private long lWebExp = 0;
        private long lWebCBills = 0;

        // Baseline Values
        private int iBlMatches = 0;
        private int iBlWins = 0;
        private int iBlLosses = 0;
        private long lBlExp = 0;
        private long lBlCBills = 0;

        private int m_iMatchCBills = 0;

        public clMode( ref MWO_DB myDb, ref Logger lgLog )
        {
            m_myDb = myDb;
            Log = lgLog;
        }


        // Fills in our Baseline data.
        public void SeedIt( SqlCeResultSet rs )
        {
            // query used by the ModeProcessor to seed the result set. We're given the current row and expected
            // to fill in our structure with the data.

            // "select m.modeid, mode, matches, wins, losses, exp, cbills from basemode, mode m where m.name = mode" );
            //           (0)      (1)    (2)     (3)    (4)    (5)   (6)
            int.TryParse( rs.GetInt32( 0 ).ToString(), out m_iModeId );
            m_sMode = rs.GetString( 1 ).Trim();
            int.TryParse( rs.GetString( 2 ).Replace( ",", "" ), out iBlMatches );
            int.TryParse( rs.GetString( 3 ).Replace( ",", "" ), out iBlWins );
            int.TryParse( rs.GetString( 4 ).Replace( ",", "" ), out iBlLosses );
            long.TryParse( rs.GetString( 5 ).Replace( ",", "" ), out lBlExp );
            long.TryParse( rs.GetString( 6 ).Replace( ",", "" ), out lBlCBills );

            bModeIsSeeded = true; // new modes won't be seeded..

        } // end of SeedIt()


        // 0=mode, 1=matches, 2=wins, 3=losses, 4=ratio, 5=exp, 6=cbills
        public void ParseScrape( ref DataGridViewRow dvRow )
        {
            m_iMatchCBills = 0;

            string sScrapedMode = dvRow.Cells[0].Value.ToString().Trim();
            Log.doIt( 2, "Found Mode: (" + sScrapedMode + ") while parsing scraped data" );

            if ( (bModeIsSeeded) && (sScrapedMode.ToLower() != m_sMode.ToLower()) )
            {
                Log.doIt( 1, "ERROR: This row mode (" + sScrapedMode + ") does not match this tracking object's " +
                    "internal mode (" + m_sMode + ")!!!.. Exiting parse!" );
                return;
            }

            fillIt(ref dvRow);

            Log.doIt( 3, "Stats from Scraped Mode: " + sScrapedMode + ", Matches: " + iWebMatches.ToString() + ", Wins: " + 
                iWebWins.ToString() + ", Losses: " + iWebLosses.ToString() + ", Exp: " + lWebExp.ToString() + ", C-Bills: " + 
                lWebCBills.ToString() );


            // this means we are processing a NEW mode.. we need to move our data to the Bl vars and set our match info with
            // the data from the web..
            if ( !bModeIsSeeded )
            {
                if (m_myDb.iNumValReturn("select count(*) from mode where name = '" + sScrapedMode + "'") == 0)
                {
                    Log.doIt(1, "Found NEW Mode! Inserting it into the database and making this our baseline going forward.");

                    string sCommand = "insert into mode (name) values('" + sScrapedMode + "')";
                    Log.doIt(3, "Command used for insert: " + sCommand);

                    m_myDb.Insert(sCommand);
                }

                m_sMode = sScrapedMode;
                m_iModeId = m_myDb.iNumValReturn( "select modeid from mode where name = '" + sScrapedMode + "'" );

                m_iMatchCBills = (int)lWebCBills;
            }
            else // we had seed info, set our match used info  based on the parse..
            {
                m_iMatchCBills = (int)( lWebCBills - lBlCBills );
            }

            bScraped = true;

        } // end of parsing out the datagrid for this mode row..

        private void fillIt( ref DataGridViewRow dvRow )
        {
            int.TryParse( dvRow.Cells[1].Value.ToString().Replace( ",", "" ), out iWebMatches );
            int.TryParse( dvRow.Cells[2].Value.ToString().Replace( ",", "" ), out iWebWins );
            int.TryParse( dvRow.Cells[3].Value.ToString().Replace( ",", "" ), out iWebLosses );
            long.TryParse( dvRow.Cells[5].Value.ToString().Replace( ",", "" ), out lWebExp );
            long.TryParse( dvRow.Cells[6].Value.ToString().Replace( ",", "" ), out lWebCBills );

        }

        // called after we finish doing our match inserts..
        public void SetNewSeed()
        {
            if ( !bScraped )
            {
                Log.doIt( 1, "Hmm.. showing we haven't scraped for mode: " + m_sMode + ".. not going to move web values over.." );
                return;
            }

            Log.doIt( 3, "Moving web values to baseline values.." );

            iBlMatches = iWebMatches;
            iBlWins = iWebWins;
            iBlLosses = iWebLosses;
            lBlExp = lWebExp;
            lBlCBills = lWebCBills;

            // only do an update if we were already seeded.. if we dumped the data by hand, seeded = false, we later scrape and do the
            // inserts there.. then call re-seed/set new seed, which puts us here to move the scraped values to out baseline variable..
            // however, we don't need to update the rows that were just recently inserted..
            if (bModeIsSeeded)
            {
                string sCommand = "update basemode set matches='" + iBlMatches + "', wins='" + iBlWins + "', losses='" + iBlLosses + "', " +
                "exp='" + lBlExp + "', cbills='" + lBlCBills + "' where mode='" + m_sMode + "'";
                Log.doIt(2, "Using command to update baseline row: " + sCommand);

                m_myDb.Insert(sCommand, false);
            }
            else
            {
                if (m_myDb.iNumValReturn("select count(*) from basemode where mode = '" + m_sMode + "'") == 0)
                {
                    string sCommand = "insert into basemode(mode, matches, wins, losses, exp, cbills) values('" + m_sMode + "', '" +
                        iBlMatches + "', '" + iBlWins + "', '" + iBlLosses + "', '" + lBlExp + "', '" + lBlCBills + "')";
                    Log.doIt(2, "Using command to INSERT baseline row: " + sCommand);

                    m_myDb.Insert(sCommand, false);
                }
                else
                {
                    Log.doIt(1, "WTF! Found NEW scrape for " + m_sMode + ", but it is already in our baseline table??");
                }
            }

            bModeIsSeeded = true;
            bScraped = false;

            Log.doIt( 3, "Finished setting new mode baseline.." );

            iWebMatches = 0;
            iWebWins = 0;
            iWebLosses = 0;
            lWebExp = 0;
            lWebCBills = 0;

        } // end of setting new seed..

        // called when they dump the seed tables and we need to clear out our internal seeds as well..
        public void ClearVars()
        {
            bModeIsSeeded = false;
            bScraped = false;

            iWebMatches = 0;
            iWebWins = 0;
            iWebLosses = 0;
            lWebExp = 0;
            lWebCBills = 0;

            iBlMatches = 0;
            iBlWins = 0;
            iBlLosses = 0;
            lBlExp = 0;
            lBlCBills = 0;

            m_iMatchCBills = 0;
        }

        public void SetBaseline( ref DataGridViewRow dvRow )
        {
            string sScrapedMode = dvRow.Cells[0].Value.ToString().Trim();

            ClearVars();

            fillIt( ref dvRow );

            Log.doIt( 1, "Filling basemode table with new baseline info.." );

            string sCommand = " insert into BaseMode (Mode, Matches, Wins, Losses, Exp, CBills) " +
                    "values('" + sScrapedMode + "', '" + iWebMatches + "', '" + iWebWins + "', '" + iWebLosses + "'," +
                    "'" + lWebExp + "', '" + lWebCBills + "')";

            Log.doIt( 1, "Command used: " + sCommand );

            m_myDb.Insert( sCommand, false );

        }

        /// <summary>
        /// Property to get the name of this Mode isnstance
        /// </summary>
        public string Key
        {
            get { return m_sMode; }
        }

        // the ID to put in the match table
        public int iMatchMode
        {
            get { return m_iModeId; }
        }

        // at present, we trust the CBill numbers to be correct on the Mode stats.. if we find it isn't, we can
        // try to pull them from something else (perhaps Mechs).
        public int iMatchCBills
        {
            get { return m_iMatchCBills; }
        }

        /// <summary>
        /// Determines if this instance has match data in it or not.
        /// </summary>
        /// <returns>
        /// Will return true if any of the scraped data is different from our baseline data.. false if the scrape
        /// has exactly the same data we have in our tables.
        /// </returns>
        public bool bDataChanged()
        {
            if ( iWebMatches > iBlMatches )
                return true;

            if ( iWebWins > iBlWins )
                return true;

            if ( iWebLosses > iBlLosses )
                return true;

            if ( lWebExp > lBlExp )
                return true;

            if ( lWebCBills > lBlCBills )
                return true;

            return false;
        } // end of Found Match..

    } // end of class

} // end of namespace
