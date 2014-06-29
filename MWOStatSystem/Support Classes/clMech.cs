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
    /// <summary>
    /// Mech data from scrape/base data
    /// </summary>
    class clMech
    {
        private const int kSecInDay = 86400;

        private MWO_DB m_myDb;
        private Logger Log;

        private bool bMechIsSeeded = false;
        private bool bScraped = false;

        private string sCommand;
        // structure info..
        private string sMech = "";
        private int iMechId;

        // web data..
        private int iWebMatches = 0;
        private int iWebWins = 0;
        private int iWebLosses = 0;
        private int iWebKills = 0;
        private int iWebDeaths = 0;
        private long lWebDamage = 0;
        private long lWebExp = 0;
        private int iWebDays = 0;
        private double dWebSeconds = 0;

        // baseline data
        private int iBlMatches = 0;
        private int iBlWins = 0;
        private int iBlLosses = 0;
        private int iBlKills = 0;
        private int iBlDeaths = 0;
        private long lBlDamage = 0;
        private long lBlExp = 0;
        private int iBlDays = 0;
        private double dBlSeconds = 0;

        // match data..
        private char cMatchWinLoss = 'X';
        private bool bDiedThisMatch = false;
        private int iMatchKills = 0;
        private int iMatchXp = 0;
        private int iMatchDuration = 0;

        public clMech( ref MWO_DB myDb, ref Logger lgLog )
        {
            m_myDb = myDb;
            Log = lgLog;
        }

        // 0=mechid, 1=mech, 2=matches, 3=wins, 4=losses, 5=kills, 6=deaths, 7=damage, 8=xp, 9=Days, 10=seconds
        // we don't care about some of that, but might use it for match detection..
        public void SeedIt( SqlCeResultSet rs )
        {
            int.TryParse( rs.GetInt32( 0 ).ToString(), out iMechId );
            sMech = rs.GetString( 1 ).Trim();

            int.TryParse( rs.GetString( 2 ).Replace( ",", "" ), out iBlMatches );
            int.TryParse( rs.GetString( 3 ).Replace( ",", "" ), out iBlWins );
            int.TryParse( rs.GetString( 4 ).Replace( ",", "" ), out iBlLosses );
            int.TryParse( rs.GetString( 5 ).Replace( ",", "" ), out iBlKills );
            int.TryParse( rs.GetString( 6 ).Replace( ",", "" ), out iBlDeaths );
            long.TryParse( rs.GetString( 7 ).Replace( ",", "" ), out lBlDamage );
            long.TryParse( rs.GetString( 8 ).Replace( ",", "" ), out lBlExp );
            int.TryParse( rs.GetString( 9 ).Replace( ",", "" ), out iBlDays );
            double.TryParse( rs.GetString( 10 ).Replace( ",", "" ), out dBlSeconds );

            bMechIsSeeded = true; // new modes won't be seeded..

        }

        public void ParseScrape( ref DataGridViewRow dvRow )
        {
            cMatchWinLoss = 'X';
            bDiedThisMatch = false;
            iMatchKills = 0;
            iMatchXp = 0;
            iMatchDuration = 0;

            string sScrapedMech = dvRow.Cells[0].Value.ToString().Trim();
            Log.doIt( 2, "Found Mech: " + sScrapedMech + " while parsing scraped data" );

            if ( ( bMechIsSeeded ) && ( sScrapedMech.ToLower() != sMech.ToLower() ) )
            {
                Log.doIt( 1, "ERROR: This row mode (" + sScrapedMech + ") does not match this tracking object's " +
                    "internal mode (" + sMech + ")!!!.. Exiting parse!" );
                return;
            }

            fillIt( ref dvRow );

            string sDayString = iWebDays > 0? iWebDays.ToString() + " Days, ":"";

            Log.doIt( 3, "Stats from Web Mech: " + sScrapedMech + ", Matches: " + iWebMatches.ToString() + ", Wins: " + iWebWins.ToString() +
                ", Losses: " + iWebLosses.ToString() + ", Kills: " + iWebKills.ToString() + ", Deaths: " + iWebDeaths.ToString() +
                ", Damage: " + lWebDamage.ToString() + ", Exp: " + lWebExp.ToString()  + ", Duration: " + sDayString.ToString() + 
                dWebSeconds.ToString() );


            if ( !bMechIsSeeded )
            {
                if (m_myDb.iNumValReturn("select count(*) from mechs where fullname = '" + sScrapedMech + "'") == 0)
                {
                    Log.doIt(1, "Found NEW Mech (" + sScrapedMech + ")! Inserting it into the database and making this our baseline going forward.");

                    sCommand = "insert into mechs (fullname, weightclass) values('" + sScrapedMech + "', 'Unknown')";
                    Log.doIt(3, "Command used for insert: " + sCommand);

                    m_myDb.Insert(sCommand);

                }

                sMech = sScrapedMech;
                iMechId = m_myDb.iNumValReturn( "select mechid from mechs where fullname = '" + sScrapedMech + "'" );

                // set match info with web data
                cMatchWinLoss = ( iWebWins > 0 )? 'W' : 'L';
                iMatchKills = iWebKills;
                bDiedThisMatch = (iWebDeaths > 0)? true : false;
                iMatchXp = (int)lWebExp;
                iMatchDuration = (int)dWebSeconds;

            }
            else
            {
                // set match info with calculated data..
                cMatchWinLoss = ((iWebWins - iBlWins) > 0)? 'W':'L';
                iMatchKills = iWebKills - iBlKills;
                bDiedThisMatch = ((iWebDeaths - iBlDeaths) > 0)? true : false;
                iMatchXp = (int) (lWebExp - lBlExp);

                // since we track days from our scrapes.. if the days haven't changed, it's a straight difference in seconds..
                if ( iWebDays == iBlDays )
                {
                    iMatchDuration = (int)( dWebSeconds - dBlSeconds );
                }
                // but if we've crossed the day threshold for this scrape, we need to add web seconds to the 
                // "seconds left from our baseline until the end of that previous day"..
                else
                {
                    iMatchDuration = (int)( ( kSecInDay - dBlSeconds ) + dWebSeconds );
                }

            }

            bScraped = true;
        }

        public void SetBaseline( ref DataGridViewRow oRow )
        {
            string sScrapedMech = oRow.Cells[0].Value.ToString().Trim();

            ClearVars();

            Log.doIt( 1, "Filling basemech with info.." );

            fillIt( ref oRow );

            sCommand = "insert into basemechs (Mech, Matches, Wins, Losses, Kills, Deaths, Damage, Exp, Days, Seconds) " +
                    "values('" + sScrapedMech + "', '" + iWebMatches + "', '" + iWebWins + "', '" + iWebLosses + "', '" +iWebKills + "'," +
                    " '" + iWebDeaths + "', '" + lWebDamage + "', '" + lWebExp + "', '" + iWebDays + "', '" + dWebSeconds + "')";

            Log.doIt( 1, "Command used: " + sCommand );

            m_myDb.Insert( sCommand, false );

            // prevent falling through the SetNewSeed code
            bScraped = false; 

        }
        // called after we finish doing our match inserts..
        public void SetNewSeed()
        {
            if ( !bScraped )
            {
                Log.doIt( 1, "Hmm.. showing we haven't scraped for mode: " + sMech + ".. not going to move web values over.." );
                return;
            }

            Log.doIt( 3, "Moving web values to baseline values.." );

            iBlMatches = iWebMatches;
            iBlWins = iWebWins;
            iBlLosses = iWebLosses;
            iBlKills = iWebKills;
            iBlDeaths = iWebDeaths;
            lBlDamage = lWebDamage;
            lBlExp = lWebExp;
            iBlDays = iWebDays;
            dBlSeconds = dWebSeconds;

            // only do an update if we were already seeded.. if we dumped the data by hand, seeded = false, we later scrape and do the
            // inserts there.. then call re-seed/set new seed, which puts us here to move the scraped values to out baseline variable..
            // however, we don't need to update the rows that were just recently inserted..
            if (bMechIsSeeded)
            {
                string sCommand = "update basemechs set matches='" + iBlMatches + "', wins='" + iBlWins + "', losses='" + iBlLosses + "', " +
                "kills='" + iBlKills + "', deaths='" + iBlDeaths + "', damage='" + lBlDamage + "', exp='" + lBlExp + "', Days='" + iBlDays +
                "', seconds='" + dBlSeconds + "' where mech='" + sMech + "'";
                Log.doIt(2, "Using command to update baseline row: " + sCommand);

                m_myDb.Insert(sCommand, false);
            }
            else
            {
                if (m_myDb.iNumValReturn("select count(*) from basemechs where mech = '" + sMech + "'") == 0)
                {
                    string sCommand = "insert into basemechs(mech, matches, wins, losses, kills, deaths, damage, exp, days, seconds) values('" +
                       sMech + "', '" + iBlMatches + "', '" + iBlWins + "', '" + iBlLosses + "', '" + iBlKills + "', '" + iBlDeaths + "', '" +
                       lBlDamage + "', '" + lBlExp + "', '" + iBlDays + "', '" + dBlSeconds + "')";
                    Log.doIt(2, "Using command to INSERT baseline row: " + sCommand);

                    m_myDb.Insert(sCommand, false);
                }
                else
                {
                    Log.doIt(1, "WTF!.. found NEW scrape for mech " + sMech + ", but it was already in our baseline??");
                }
            }

            bMechIsSeeded = true;
            bScraped = false;

            Log.doIt( 3, "Finished setting new mech baseline.." );

            iWebMatches = 0;
            iWebWins = 0;
            iWebLosses = 0;
            iWebKills = 0;
            iWebDeaths = 0;
            lWebDamage = 0;
            lWebExp = 0;
            iWebDays = 0;
            dWebSeconds = 0;

        } // end of setting new seed..

        private void fillIt( ref DataGridViewRow dvRow )
        {

            int.TryParse( dvRow.Cells[1].Value.ToString().Replace( ",", "" ), out iWebMatches );
            int.TryParse( dvRow.Cells[2].Value.ToString().Replace( ",", "" ), out iWebWins );
            int.TryParse( dvRow.Cells[3].Value.ToString().Replace( ",", "" ), out iWebLosses );
            int.TryParse( dvRow.Cells[5].Value.ToString().Replace( ",", "" ), out iWebKills );
            int.TryParse( dvRow.Cells[6].Value.ToString().Replace( ",", "" ), out iWebDeaths );
            long.TryParse( dvRow.Cells[8].Value.ToString().Replace( ",", "" ), out lWebDamage );
            long.TryParse( dvRow.Cells[9].Value.ToString().Replace( ",", "" ), out lWebExp );

            string sDur = dvRow.Cells[10].Value.ToString();
            if ( sDur.Contains( "day" ) )
            {
                string sPart = "";

                Log.doIt( 3, "Found DAYS in mech stats, parsing out substrings.." );

                sPart = sDur.Substring( 0, sDur.IndexOf( "day" ) - 1 );

                int.TryParse( sPart, out iWebDays ); // should put number of days in here..
                // no matter if it's more than 9 days, or if there's an S in day(s).. we want the last 8 chars for
                // our timespan parse (total seconds of the max 24 hours, 59 minutes, 59 seconds)
                sDur = sDur.Substring( sDur.Length - 8 );

                dWebSeconds = TimeSpan.Parse( sDur ).TotalSeconds;

            }
            else
            {
                dWebSeconds = TimeSpan.Parse( sDur ).TotalSeconds;
            }

        } // end of fillIt

        public void ClearVars()
        {
            bMechIsSeeded = false;
            bScraped = false;

            iWebMatches = 0;
            iWebWins = 0;
            iWebLosses = 0;
            iWebKills = 0;
            iWebDeaths = 0;
            lWebDamage = 0;
            lWebExp = 0;
            iWebDays = 0;
            dWebSeconds = 0;

            // baseline data
            iBlMatches = 0;
            iBlWins = 0;
            iBlLosses = 0;
            iBlKills = 0;
            iBlDeaths = 0;
            lBlDamage = 0;
            lBlExp = 0;
            iBlDays = 0;
            dBlSeconds = 0;

            cMatchWinLoss = 'X';
            bDiedThisMatch = false;
            iMatchKills = 0;
            iMatchXp = 0;
            iMatchDuration = 0;

    }

        /// <summary>
        /// Property to get the name of this Mode isnstance
        /// </summary>
        public string Key
        {
            get { return sMech; }
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
            {
                Log.doIt( 3, "Showing MATCHES changed for this mech(" + Key + ").." );
                return true;
            }

            if ( iWebWins > iBlWins )
            {
                Log.doIt(3, "Showing WINS changed for this mech(" + Key + ")..");
                return true;
            }

            if ( iWebLosses > iBlLosses )
            {
                Log.doIt(3, "Showing LOSSES changed for this mech(" + Key + ")..");
                return true;
            }

            if ( iWebKills > iBlKills )
            {
                Log.doIt(3, "Showing KILLS changed for this mech(" + Key + ")..");
                return true;
            }

            if ( iWebDeaths > iBlDeaths )
            {
                Log.doIt(3, "Showing DEATHS changed for this mech(" + Key + ")..");
                return true;
            }

            if ( lWebDamage > lBlDamage )
            {
                Log.doIt(3, "Showing DAMAGE changed for this mech(" + Key + ")..");
                return true;
            }

            if ( lWebExp > lBlExp )
            {
                Log.doIt(3, "Showing EXP changed for this mech(" + Key + ")..");
                return true;
            }

            if ( iWebDays > iBlDays )
            {
                Log.doIt(3, "Showing DAYS (duration) changed for this mech(" + Key + ")..");
                return true;
            }

            if ( dWebSeconds > dBlSeconds )
            {
                Log.doIt(3, "Showing SECONDS (duration) changed for this mech(" + Key + ")..");
                return true;
            }

            return false;

        } // end of Found Match..

        public void LoadMatch( ref clSingleMatch Match )
        {
            Match.iMech = iMechId; 
            Match.cWinLoss = cMatchWinLoss;
            Match.bDeath = bDiedThisMatch;
            Match.iKills = iMatchKills;
            Match.iExp = iMatchXp;
            Match.iDuration = iMatchDuration;

        } // end of LoadMatch

    } // end of class

} // end of namespace
