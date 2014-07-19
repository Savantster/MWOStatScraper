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
    class clWeaponProcessor
    {
        private Dictionary<string, clWeapon> dicWeapons = null;
        private MWO_DB myDb = null;
        private Logger Log = null;
        private SqlCeResultSet rs;

        public clWeaponProcessor( ref MWO_DB db, ref Logger log, ref bool bNeedSeed )
        {
            Log = log;
            myDb = db;

            dicWeapons = new Dictionary<string, clWeapon>();

            LoadBaselineData(ref bNeedSeed);
        } // end of constructor..

        /// <summary>
        /// Fills the dictionary with clWeapon classes that are filled in with Baseline data from our database.
        /// </summary>
        private void LoadBaselineData(ref bool bNeedSeed)
        {
            clWeapon Weapon = null;

            // skips the 'Unknown' mode since it won't exist in the baseline table
            rs = myDb.ResultSet( "select w.weaponid, weapon, matches, fired, hits, damage from baseweaps, weapons w where w.name = weapon" );

            if ( !rs.HasRows )
            {
                Log.doIt( 1, "There are NO WEAPONS in our baseline data! It will be filled with the first scrape.." );
                // BEWARE the magic bit.. if we don't call SeedIt, the tracking class instance will -not- have it's seeded flag set, which 
                // we need so we can track NEW scraped data when we process the web scrape..
                bNeedSeed = true;
                return;
            }

            while ( rs.Read() )
            {
                Weapon = new clWeapon( ref myDb, ref Log );
                Weapon.SeedIt( rs );
                dicWeapons.Add( Weapon.Key, Weapon );
                Log.doIt( 2, "Found " + Weapon.Key + " in baseweaps table, loaded it." );

            }

            Log.doIt( 2, "Found " + dicWeapons.Count + " Weapons in our baseline data." );

        } // end of Load Baseline

        // we'll brute force this. Going to dump all internal structures since we know the main application
        // dumped all data. We'll create a single weapon class and have it do all the parsing/inserting for
        // all weapons, then we'll return from here. The main program will have to know that after it calls
        // this method that the manager class must be dumped and made from scratch to properly seed all 
        // baseline data back into a scraping state.
        public void SetBaselines( ref DataGridView dgWeapons )
        {
            DataGridViewRow oRow;
            clWeapon Weapon;

            dicWeapons.Clear();

            Weapon = new clWeapon( ref myDb, ref Log );

            for ( int i = 0; i < dgWeapons.RowCount - 1; i++ )
            {
                oRow = dgWeapons.Rows[i];
                Weapon.SetBaseline( ref oRow );
            }

        }

        /// <summary>
        /// This method is expected to be called first. It will check the Weapon scrape to see if it found any new matches based
        /// on the Weapon data. If it finds a match, it will fill in the bits it knows about. 
        /// </summary>
        /// <param name="dgWeapons">
        /// DataGrid from the web scrape. This is the data that will be compared against our Baseline data from our
        /// internal database.
        /// </param>
        /// <param name="Match">
        /// Match object to fill in from this processor class..
        /// </param>
        public void processWeapons( ref DataGridView dgWeapons )
        {
            DataGridViewRow oRow;
            clWeapon Weapon;
            string sWeapon;

            for ( int i = 0; i < dgWeapons.RowCount - 1; i++ )
            {
                sWeapon = dgWeapons.Rows[i].Cells[0].Value.ToString();
                oRow = dgWeapons.Rows[i];

                if ( dicWeapons.ContainsKey(sWeapon) )
                {
                    Weapon = dicWeapons[sWeapon];
                    Weapon.ParseScrape( ref oRow );
                }
                else
                {
                    Weapon = new clWeapon( ref myDb, ref Log );
                    Weapon.ParseScrape( ref oRow );
                    dicWeapons.Add( Weapon.Key, Weapon );
                }

            } // end of each row in our grid.. we run them all because we need to ensure good web data for our reseeding

        } // end of parsing

        public decimal fillMatch( int iMatchId = -1 )
        {
            clWeapon Weapon;
            decimal dDamage = 0;

            if ( iMatchId == -1 )
            {
                Log.doIt( 1, "Hmm.. passed in an invalid match ID.. not going to insert these weapons.." );
                return 0;
            }

            foreach ( KeyValuePair<string, clWeapon> keyPair in dicWeapons )
            {
                Weapon = keyPair.Value;

                if ( Weapon.bDataChanged() )
                {
                   dDamage += Weapon.insertDetails( iMatchId );
                }
            }

            return dDamage;

        } // end of Fill Match

        /// <summary>
        /// Tells each Weapon object to reset it's seed based on current scrape data.
        /// </summary>
        public void ReSeed()
        {
            foreach ( KeyValuePair<string, clWeapon> keyPair in dicWeapons )
            {
                keyPair.Value.SetNewSeed();
            }

        } // end ReSeed..

    } // end of class

} // end of namespace
