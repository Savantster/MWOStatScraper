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
    class clMapProcessor
    {
        private Dictionary<string, clMap> dicMaps = null;
        private MWO_DB myDb = null;
        private Logger Log = null;
        private SqlCeResultSet rs;

        public clMapProcessor( ref MWO_DB db, ref Logger log, ref bool bNeedSeed )
        {
            Log = log;
            myDb = db;

            dicMaps = new Dictionary<string, clMap>();

            LoadBaselineData(ref bNeedSeed);

        }

        /// <summary>
        /// Fills the dictionary with clMode classes that are filled in with Baseline data from our database.
        /// </summary>
        private void LoadBaselineData(ref bool bNeedSeed)
        {
            clMap Map = null;

            // skips the 'Unknown' mode since it won't exist in the baseline table
            rs = myDb.ResultSet( "select m.mapid, map, matches, wins, losses, days, seconds from basemap, maps m where m.name = map");

            if ( !rs.HasRows )
            {
                Log.doIt( 1, "There are NO MAPS in our baseline data! It will be filled with the first scrape.." );
                // BEWARE the magic bit.. if we don't call SeedIt, the tracking class instance will not have it's seeded flag set, which means
                // we can track NEW scraped data when we process the web scrape..
                bNeedSeed = true;
                return;
            }

            while ( rs.Read() )
            {
                Map = new clMap( ref myDb, ref Log );
                Map.SeedIt( rs );
                dicMaps.Add( Map.Key, Map );
                Log.doIt( 2, "Found " + Map.Key + " in basemode table, loaded it." );

            }

            Log.doIt( 2, "Found " + dicMaps.Count + " Modes in our baseline data." );

        }


        /// <summary>
        /// This method is expected to be called first. It will check the Mode scrape to see if it found any new matches based
        /// on the Mode data. If it finds a match, it will fill in the bits it knows about. 
        /// </summary>
        /// <param name="dgModes">
        /// DataGrid from the web scrape. This is the data that will be compared against our Baseline data from our
        /// internal database.
        /// </param>
        /// <param name="Match">
        /// Match object to fill in from this processor class..
        /// </param>
        public void processMaps( ref DataGridView dgModes )
        {
            //clSingleMatch Match = new clSingleMatch();
            DataGridViewRow oRow;
            clMap Map;
            //clMode matchMode = null;
            string sMode;

            for(int i = 0; i < dgModes.RowCount - 1; i++)
            {
                sMode = dgModes.Rows[i].Cells[0].Value.ToString();
                oRow = dgModes.Rows[i];

                if ( dicMaps.ContainsKey( sMode ) )
                {
                    Map = dicMaps[sMode];
                    Map.ParseScrape( ref oRow);
                }
                else
                {
                    Map = new clMap( ref myDb, ref Log );
                    Map.ParseScrape( ref oRow );

                        dicMaps.Add( Map.Key, Map );
                }

            } // end of each row in our grid.. we run them all because we need to ensure good web data for our reseeding

        } // end of parsing

        public void fillMatch( ref clSingleMatch Match )
        {
            clMap Map;
            bool bAlreadyFoundMatch = false;

            foreach ( KeyValuePair<string, clMap> keyPair in dicMaps )
            {
                Map = keyPair.Value;

                if ( Map.bDataChanged() )
                {
                    if ( bAlreadyFoundMatch )
                    {
                        Log.doIt( 1, "WHOA!... found another MODE for this match ?! .. find out what's going on!" );
                    }

                    Match.iMap = Map.iMatchMap;
                    bAlreadyFoundMatch = true; // sanity checking.. should never find two Modes from a scrape, but you never know!

                } // end of if we found changed data..

            } // end for each mode we have

        } // end of Fill Match

        /// <summary>
        /// Tells each Map object to reset it's seed based on current scrape data.
        /// </summary>
        public void ReSeed()
        {
            foreach (KeyValuePair<string, clMap> keyPair in dicMaps)
            {
                keyPair.Value.SetNewSeed();
            }
        } // end ReSeed..

        public void SetBaselines( ref DataGridView dgMaps )
        {
            DataGridViewRow oRow;
            clMap Map;

            dicMaps.Clear();

            Map = new clMap( ref myDb, ref Log );

            for ( int i = 0; i < dgMaps.RowCount - 1; i++ )
            {
                oRow = dgMaps.Rows[i];
                Map.SetBaseline( ref oRow );
            }

        }

        public bool FoundMatch()
        {
            clMap Map;

            foreach ( KeyValuePair<string, clMap> keyPair in dicMaps )
            {
                Map = keyPair.Value;
                if ( Map.bDataChanged() )
                    return true;
            }

            return false;
        }

    }
}
