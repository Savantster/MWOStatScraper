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
    class clMechProcessor
    {
        private Dictionary<string, clMech> dicMechs = null;
        private MWO_DB myDb = null;
        private Logger Log = null;
        private SqlCeResultSet rs;

        public clMechProcessor( ref MWO_DB db, ref Logger log, ref bool bNeedSeed )
        {
            Log = log;
            myDb = db;

            dicMechs = new Dictionary<string, clMech>();

            LoadBaselineData(ref bNeedSeed);

        }

        /// <summary>
        /// Fills the dictionary with clMode classes that are filled in with Baseline data from our database.
        /// </summary>
        private void LoadBaselineData(ref bool bNeedSeed)
        {
            clMech Mech = null;

            // skips the 'Unknown' mode since it won't exist in the baseline table
            rs = myDb.ResultSet( "select m.mechid, mech, matches, wins, losses, kills, deaths, damage, exp," +
                " days, seconds from basemechs, mechs m where m.fullname = mech");

            if ( !rs.HasRows )
            {
                Log.doIt( 1, "There are NO MECHS in our baseline data! It will be filled with the first scrape.." );
                // BEWARE the magic bit.. if we don't call SeedIt, the tracking class instance will not have it's seeded flag set, which means
                // we can track NEW scraped data when we process the web scrape..
                bNeedSeed = true;
                return;
            }

            while ( rs.Read() )
            {
                Mech = new clMech( ref myDb, ref Log );
                Mech.SeedIt( rs );
                dicMechs.Add( Mech.Key, Mech );
                Log.doIt( 2, "Found " + Mech.Key + " in basemech table, loaded it." );

            }

            Log.doIt( 2, "Found " + dicMechs.Count + " Modes in our baseline data." );

        }


        /// <summary>
        /// This method is expected to be called first. It will check the Mode scrape to see if it found any new matches based
        /// on the Mode data. If it finds a match, it will fill in the bits it knows about. 
        /// </summary>
        /// <param name="dgMechs">
        /// DataGrid from the web scrape. This is the data that will be compared against our Baseline data from our
        /// internal database.
        /// </param>
        /// <param name="Match">
        /// Match object to fill in from this processor class..
        /// </param>
        public void processMechs( ref DataGridView dgMechs )
        {
            //clSingleMatch Match = new clSingleMatch();
            DataGridViewRow oRow;
            clMech Mech;
            //clMode matchMode = null;
            string sMech;

            for(int i = 0; i < dgMechs.RowCount - 1; i++)
            {
                sMech = dgMechs.Rows[i].Cells[0].Value.ToString();
                oRow = dgMechs.Rows[i];

                if ( dicMechs.ContainsKey( sMech ) )
                {
                    Log.doIt( 3, "Found (" + sMech + ") in our seeded dictionary.. scraping it.." );
                    Mech = dicMechs[sMech];
                    Mech.ParseScrape( ref oRow);
                }
                else
                {
                    Log.doIt( 3, "Mech (" + sMech +") was MISSING from our seeded dictionary, processing and adding.." );
                    Mech = new clMech( ref myDb, ref Log );
                    Mech.ParseScrape( ref oRow );
                    dicMechs.Add( Mech.Key, Mech );
                }

            } // end of each row in our grid.. we run them all because we need to ensure good web data for our reseeding

        } // end of parsing

        public void fillMatch( ref clSingleMatch Match )
        {
            clMech Mech;
            bool bAlreadyFoundMatch = false;
            string strTestMech;

            foreach ( KeyValuePair<string, clMech> keyPair in dicMechs )
            {
                Mech = keyPair.Value;

                // TODO: cut out the broken KIT FOX duped reporting, only keep the one I own (the PRIME(I), the rest should be discarded)
                strTestMech = Mech.Key.ToString().ToLower().Trim();
                if ((strTestMech == "kit fox kfx-prime(g)") || (strTestMech == "kit fox kfx-prime"))
                {
                    // logging it so I remember to pull it out eventually..
                    Log.doIt(1, "Skipping dupes reported for Kit Fox: " + Mech.Key);
                    continue;
                }
                // commenting out the log level 1 dupe reporting for those I don't have Prime variants of.. no point
                // in mentioning them since I don't run Primes and their values shouldn't be changing any more.
                if ((strTestMech == "nova nva-prime(g)") || (strTestMech == "nova nva-prime(i)"))
                {
                    // same as above, don't process the mechs we don't own
                    Log.doIt(3, "Skipping dupes for Nova: " + Mech.Key);
                    continue;
                }

                if ((strTestMech == "dire wolf dwf-prime(g)") || (strTestMech == "dire wolf dwf-prime(i)"))
                {
                    Log.doIt(3, "Skipping dupes reported for Dire Wolf: " + Mech.Key);
                    continue;
                }

                if ((strTestMech == "adder adr-prime(g)") || (strTestMech == "adder adr-prime(i)"))
                {
                    Log.doIt(3, "Skipping dupes reported for Adder: " + Mech.Key);
                    continue;
                }

                if ((strTestMech == "stormcrow scr-prime(g)") || (strTestMech == "stormcrow scr-prime(i)"))
                {
                    Log.doIt(3, "Skipping dupes reported for Adder: " + Mech.Key);
                    continue;
                }

                if ( Mech.bDataChanged() )
                {
                    if ( bAlreadyFoundMatch )
                    {
                        Log.doIt( 1, "WHOA!... found another MECH (" + Mech.Key + ") for this match ?! .. find out what's going on!" );
                    }

                    Log.doIt( 2, "Loading mech match data from (" + Mech.Key + ").." );

                    Mech.LoadMatch( ref Match );
                    bAlreadyFoundMatch = true; // sanity checking.. should never find two mechs from a scrape, but you never know!

                } // end if this instance reported changed data..

            } // end for each mode we have

        } // end of Fill Match

        /// <summary>
        /// Tells each Mech object to reset it's seed based on current scrape data.
        /// </summary>
        public void ReSeed()
        {
            foreach (KeyValuePair<string, clMech> keyPair in dicMechs)
            {
                keyPair.Value.SetNewSeed();
            }
        } // end ReSeed..

        public void SetBaselines( ref DataGridView dgMechs )
        {
            DataGridViewRow oRow;
            clMech Mech;

            dicMechs.Clear();

            Mech = new clMech( ref myDb, ref Log );

            for ( int i = 0; i < dgMechs.RowCount - 1; i++ )
            {
                oRow = dgMechs.Rows[i];
                Mech.SetBaseline( ref oRow );
            }

        }

        public bool FoundMatch()
        {
            clMech Mech;

            foreach ( KeyValuePair<string, clMech> keyPair in dicMechs )
            {
                Mech = keyPair.Value;
                if ( Mech.bDataChanged() )
                    return true;
            }

            return false;

        } // end FoundMatch

    } // end of class
} // end of namespace..
