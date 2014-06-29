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
    class clMap
    {
        private MWO_DB m_myDb = null;
        private Logger Log = null;

        private string sCommand = "";

        private bool bMapIsSeeded = false;
        private bool bScraped = false;

        private string sMap = "";
        private int iMapId = -1;

        private int iWebMatches = 0;
        private int iWebWins = 0;
        private int iWebLosses = 0;
        private int iWebDays = 0;
        private double dWebSeconds = 0;

        private int iBlMatches = 0;
        private int iBlWins = 0;
        private int iBlLosses = 0;
        private int iBlDays = 0;
        private double dBlSeconds = 0;

        public clMap( ref MWO_DB myDb, ref Logger lgLog )
        {
            m_myDb = myDb;
            Log = lgLog;
        }



        // 0=mapid, 1=map, 2=matches, 3=wins, 4=losses, 5=days, 6=seconds
        public void SeedIt( SqlCeResultSet rs )
        {
            int.TryParse( rs.GetInt32( 0 ).ToString(), out iMapId );
            sMap = rs.GetString( 1 ).Trim();

            int.TryParse( rs.GetString( 2 ).Replace( ",", "" ), out iBlMatches );
            int.TryParse( rs.GetString( 3 ).Replace( ",", "" ), out iBlWins );
            int.TryParse( rs.GetString( 4 ).Replace( ",", "" ), out iBlLosses );
            int.TryParse( rs.GetString( 5 ).Replace( ",", "" ), out iBlDays );
            double.TryParse( rs.GetString( 6 ).Replace( ",", "" ), out dBlSeconds );

            bMapIsSeeded = true;

        } // end of SeedIt

        // 0=map, 1=matches, 2=wins, 3=losses, 4=ratio, 5=time
        public void ParseScrape( ref DataGridViewRow dvRow )
        {
            string sScrapedMap = dvRow.Cells[0].Value.ToString().Trim();
            Log.doIt( 2, "Found Map: (" + sScrapedMap + ") while parsing scraped data" );

            if ( ( bMapIsSeeded ) && ( sScrapedMap.ToLower() != sMap.ToLower() ) )
            {
                Log.doIt( 1, "ERROR: This row mode (" + sScrapedMap + ") does not match this tracking object's " +
                    "internal mode (" + sMap + ")!!!.. Exiting parse!" );
                return;
            }

            fillIt( ref dvRow );

            Log.doIt( 3, "Stats from map: " + sScrapedMap + ", Matches: " + iWebMatches.ToString() + ", Wins: " + iWebWins.ToString() +
                ", Losses: " + iWebLosses.ToString() + ", Played time: Days: " + iWebDays.ToString() + ", Seconds: " + dWebSeconds.ToString() );


            // this means we are processing a NEW mode.. we need to move our data to the Bl vars and set our match info with
            // the data from the web..
            if ( !bMapIsSeeded )
            {
                if (m_myDb.iNumValReturn("select count(*) from maps where name = '" + sScrapedMap + "'") == 0)
                {

                    Log.doIt(1, "Found NEW Map! Inserting it into the database and making this our baseline going forward.");

                    sCommand = "insert into maps (name) values('" + sScrapedMap + "')";
                    Log.doIt(3, "Command used for insert: " + sCommand);

                    m_myDb.Insert(sCommand);
                }

                sMap = sScrapedMap;
                iMapId = m_myDb.iNumValReturn( "select mapid from maps where name = '" + sScrapedMap + "'" );

            }

            bScraped = true;

        } // end of ProcessScrape

        // called from both baseline processing and normal match parsing..
        private void fillIt( ref DataGridViewRow dvRow )
        {

            int.TryParse( dvRow.Cells[1].Value.ToString().Replace( ",", "" ), out iWebMatches );
            int.TryParse( dvRow.Cells[2].Value.ToString().Replace( ",", "" ), out iWebWins );
            int.TryParse( dvRow.Cells[3].Value.ToString().Replace( ",", "" ), out iWebLosses );

            string sDur = dvRow.Cells[5].Value.ToString();
            if ( sDur.Contains( "day" ) )
            {
                string sPart = "";

                Log.doIt( 3, "Found DAYS in map stats, parsing out substrings.." );

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

        }

        public void SetBaseline( ref DataGridViewRow oRow )
        {
            string sScrapedMap = oRow.Cells[0].Value.ToString().Trim();

            ClearVars();

            Log.doIt( 1, "Filling basewmap table with new baseline info.." );

            fillIt( ref oRow );

            sCommand = "insert into basemap (Map, Matches, Wins, Losses, Days, Seconds) values('" + sScrapedMap + "', '" + 
                    iWebMatches + "', '" + iWebWins + "', '" + iWebLosses + "', '" + iWebDays + "', '" + dWebSeconds + "')";

            Log.doIt( 1, "Command used: " + sCommand );

            m_myDb.Insert( sCommand, false );

            // prevent falling through the SetNewSeed code
            bScraped = false; 

        }


        public void SetNewSeed()
        {
            if ( !bScraped )
            {
                Log.doIt( 1, "Hmm.. showing we haven't scraped for map: " + sMap + ".. not going to move web values over.." );
                return;
            }

            Log.doIt( 3, "Moving web values to baseline values.." );

            iBlMatches = iWebMatches;
            iBlWins = iWebWins;
            iBlLosses = iWebLosses;
            iBlDays = iWebDays;
            dBlSeconds = dWebSeconds;

            // only do an update if we were already seeded.. if we dumped the data by hand, seeded = false, we later scrape and do the
            // inserts there.. then call re-seed/set new seed, which puts us here to move the scraped values to out baseline variable..
            // however, we don't need to update the rows that were just recently inserted..
            if (bMapIsSeeded)
            {
                string sCommand = "update basemap set matches='" + iBlMatches + "', wins='" + iBlWins + "', losses='" + iBlLosses + "', " +
                "Days='" + iBlDays + "', seconds='" + dBlSeconds + "' where map='" + sMap + "'";
                Log.doIt(2, "Using command to update baseline row: " + sCommand);

                m_myDb.Insert(sCommand, false);
            }
            else
            {
                if (m_myDb.iNumValReturn("select count(*) from basemap where map = '" + sMap + "'") == 0)
                {
                    string sCommand = "insert into basemap(map, matches, wins, losses, days, seconds) values('" + sMap + "', '" + iBlMatches + "', '" +
                        iBlWins + "', '" + iBlLosses + "', '" + iBlDays + "', '" + dBlSeconds + "')";
                    Log.doIt(2, "Using command to INSERT baseline row: " + sCommand);

                    m_myDb.Insert(sCommand, false);
                }
                else
                {
                    Log.doIt(1, "WTF!.. found new scrape of " + sMap + ", but it was already in our baseline??");
                }
            }

            bMapIsSeeded = true;
            bScraped = false;

            Log.doIt( 3, "Finished setting new mode baseline.." );

            iWebMatches = 0;
            iWebWins = 0;
            iWebLosses = 0;
            iWebDays = 0;
            dWebSeconds = 0;

        } // end of setting new seed..

        // called when they dump the seed tables and we need to clear out our internal seeds as well..
        public void ClearVars()
        {
            bMapIsSeeded = false;
            bScraped = false;

            iWebMatches = 0;
            iWebWins = 0;
            iWebLosses = 0;
            iWebDays = 0;
            dWebSeconds = 0;

            iBlMatches = 0;
            iBlWins = 0;
            iBlLosses = 0;
            iBlDays = 0;
            dBlSeconds = 0;
        }

        /// <summary>
        /// Property to get the name of this Mode isnstance
        /// </summary>
        public string Key
        {
            get { return sMap; }
        }

        // the ID to put in the match table
        public int iMatchMap
        {
            get { return iMapId; }
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

            if ( iWebDays > iBlDays )
                return true;

            if ( dWebSeconds > dBlSeconds )
                return true;

            return false;
        } // end of Found Match..

    }
}
