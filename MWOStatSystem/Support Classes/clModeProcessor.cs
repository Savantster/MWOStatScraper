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
    class clModeProcessor
    {
        private Dictionary<string, clMode> dicModes = null;
        private MWO_DB myDb = null;
        private Logger Log = null;
        private SqlCeResultSet rs;

        public clModeProcessor( ref MWO_DB db, ref Logger log, ref bool bNeedSeed )
        {
            Log = log;
            myDb = db;

            dicModes = new Dictionary<string, clMode>();

            LoadBaselineData(ref bNeedSeed);

        }

        /// <summary>
        /// Fills the dictionary with clMode classes that are filled in with Baseline data from our database.
        /// </summary>
        private void LoadBaselineData(ref bool bNeedSeed)
        {
            clMode Mode = null;

            // skips the 'Unknown' mode since it won't exist in the baseline table
            rs = myDb.ResultSet( "select m.modeid, mode, matches, wins, losses, exp, cbills from basemode, mode m where m.name = mode");

            if ( !rs.HasRows )
            {
                Log.doIt( 1, "There are NO MODES in our baseline data! It will be filled with the first scrape.." );
                // BEWARE the magic bit.. if we don't call SeedIt, the tracking class instance will not have it's seeded flag set, which means
                // we can track NEW scraped data when we process the web scrape..
                bNeedSeed = true;
                return;
            }

            while ( rs.Read() )
            {
                Mode = new clMode( ref myDb, ref Log );
                Mode.SeedIt( rs );
                dicModes.Add( Mode.Key, Mode );
                Log.doIt( 2, "Found " + Mode.Key + " in basemode table, loaded it." );

            }

            Log.doIt( 2, "Found " + dicModes.Count + " Modes in our baseline data." );

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
        public void processModes( ref DataGridView dgModes )
        {
            //clSingleMatch Match = new clSingleMatch();
            DataGridViewRow oRow;
            clMode Mode;
            //clMode matchMode = null;
            string sMode;

            for(int i = 0; i < dgModes.RowCount - 1; i++)
            {
                sMode = dgModes.Rows[i].Cells[0].Value.ToString();
                oRow = dgModes.Rows[i];

                if ( dicModes.ContainsKey( sMode ) )
                {
                    Mode = dicModes[sMode];
                    Mode.ParseScrape( ref oRow );
                }
                else
                {
                    Mode = new clMode( ref myDb, ref Log );
                    Mode.ParseScrape( ref oRow );
                    dicModes.Add( Mode.Key, Mode );
                }

            } // end of each row in our grid.. we run them all because we need to ensure good web data for our reseeding


        } // end of parsing

        public void fillMatch( ref clSingleMatch Match )
        {
            clMode Mode;
            bool bAlreadyFoundMatch = false;

            foreach ( KeyValuePair<string, clMode> keyPair in dicModes )
            {
                Mode = keyPair.Value;

                if(Mode.bDataChanged())
                {
                    if ( bAlreadyFoundMatch )
                    {
                        Log.doIt( 1, "WHOA!... found another MODE for this match ?! .. find out what's going on!" );
                    }

                    Match.iMode = Mode.iMatchMode;
                    Match.iCBills = Mode.iMatchCBills;
                    bAlreadyFoundMatch = true; // sanity checking.. should never find two Modes from a scrape, but you never know!

                } // end of if we found changed data..

            } // end for each mode we have

        } // end of Fill Match

        /// <summary>
        /// Tells each Mode object to reset it's seed based on current scrape data.
        /// </summary>
        public void ReSeed()
        {
            foreach (KeyValuePair<string, clMode> keyPair in dicModes)
            {
                keyPair.Value.SetNewSeed();
            }
        } // end ReSeed..

        public void SetBaselines( ref DataGridView dgModes)
        {
            DataGridViewRow oRow;
            clMode Mode;

            dicModes.Clear();

            Mode = new clMode( ref myDb, ref Log );

            for ( int i = 0; i < dgModes.RowCount - 1; i++ )
            {
                oRow = dgModes.Rows[i];
                Mode.SetBaseline( ref oRow );
            }

        }

        public bool FoundMatch()
        {
            clMode Mode;

            foreach ( KeyValuePair<string, clMode> keyPair in dicModes )
            {
                Mode = keyPair.Value;
                if ( Mode.bDataChanged() )
                    return true;
            }

            return false;
        }

    } // end of Mode processor class
} // end of namespace..
