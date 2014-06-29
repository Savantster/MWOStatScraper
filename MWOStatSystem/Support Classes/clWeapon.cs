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
    /// Weapon data from scrape/base data
    /// </summary>

    class clWeapon
    {
        private MWO_DB m_myDb;
        private Logger Log;

        private string sCommand = "";

        private string sWeapon;
        private int iWeaponId = -1;

        // web stats
        private int iWebMatches = 0;
        private int iWebFired = 0;
        private int iWebHits = 0;
        private long lWebDamage = 0;

        // baseline stats
        private int iBlMatches = 0;
        private int iBlFired = 0;
        private int iBlHits = 0;
        private long lBlDamage = 0;

        private bool bWeaponIsSeeded = false;
        private bool bScraped = false;
        private bool m_bFoundMatch = false;

        // match stats, if match was found
        private int m_iMatchHits = 0;
        private int m_iMatchMisses = 0;
        private int m_iMatchDmg = 0;

        // The "weapon" grid view layout, by cell, is: 0=name, 1=matches, 2=fired, 3=hits, 4=accuracy, 5=time, 6=damage
        // we don't care about accuracy or time equipped..
        public clWeapon( ref MWO_DB myDb, ref Logger lgLog )
        {
            m_myDb = myDb;
            Log = lgLog;
        }

        // Fills in our Baseline data.
        public void SeedIt( SqlCeResultSet rs )
        {
            // query used by the ModeProcessor to seed the result set. We're given the current row and expected
            // to fill in our structure with the data.
            int.TryParse( rs.GetInt32( 0 ).ToString(), out iWeaponId );
            sWeapon = rs.GetString(1).Trim();
            Log.doIt( 2, "Found baseline weapon: " + sWeapon + " while parsing scraped/base data" );

            int.TryParse( rs.GetString( 2 ).ToString().Replace( ",", "" ), out iBlMatches );
            int.TryParse( rs.GetString( 3 ).ToString().Replace( ",", "" ), out iBlFired );
            int.TryParse( rs.GetString( 4 ).ToString().Replace( ",", "" ), out iBlHits );
            long.TryParse( rs.GetString( 5 ).ToString().Replace( ",", "" ), out lBlDamage );

            bWeaponIsSeeded = true; // new modes won't be seeded..

        } // end of SeedIt()

        // 0=Weapon, 1=Matches, 2=Fired, 3=Hits, 4=Accuracy, 5=Time Equip., 6=Damage
        public void ParseScrape( ref DataGridViewRow dvRow )
        {
            m_iMatchHits = 0;
            m_iMatchMisses = 0;
            m_iMatchDmg = 0;

            string sScrapedWeapon = dvRow.Cells[0].Value.ToString().Trim();
            Log.doIt( 2, "Found Weapon: " + sScrapedWeapon + " while parsing scraped data" );

            if ( ( bWeaponIsSeeded ) && ( sScrapedWeapon.ToLower() != sWeapon.ToLower() ) )
            {
                Log.doIt( 1, "ERROR: This row weapon (" + sScrapedWeapon + ") does not match this tracking object's " +
                    "internal weapon (" + sWeapon + ")!!!.. Exiting parse!" );
                return;
            }

            fillIt( ref dvRow );

            Log.doIt( 3, "Stats from Scraped weapon " + sScrapedWeapon + ": Matches: " + iWebMatches.ToString() + 
                ", Shots Fired: " + iWebFired.ToString() + ", Hits: " + iWebHits.ToString() + ", Damage: " + lWebDamage.ToString() );

            // in THEORY, if we found something new in the scrape data it means we never tracked it. However, PGI dumps the web stats on occasion
            // which means we can end up with a "new scrape", but still have the item in our main table. Therefore, we need to check the main
            // table before we do the insert or we'll have dupes.
            if ( !bWeaponIsSeeded )
            {
                if (m_myDb.iNumValReturn("select count(*) from weapons where name = '" + sScrapedWeapon + "'") == 0)
                {
                    // This weapon did not exist in the core tables.. we'll add it for future reference

                    Log.doIt(1, "Found NEW weapon (" + sScrapedWeapon + ").. inserting it into the reference tables..");

                    sCommand = "insert into weapons (name, primarytype, subtype, duration, maxdmg, description) " +
                            "values('" + sScrapedWeapon + "', 'unknown', 'unknown', 0, 0, 'unknown')";
                    Log.doIt(3, "Command used for insert: " + sCommand);

                    m_myDb.Insert(sCommand);
                    Log.doIt(1, "Added " + sScrapedWeapon + " to the database, you must update the stats/info" +
                                " for this weapon or your graphs/charts will not be accurate!");
                }

                sWeapon = sScrapedWeapon;
                iWeaponId = m_myDb.iNumValReturn("select weaponid from weapons where name = '" + sWeapon + "'");

                m_iMatchHits = iWebHits;
                m_iMatchMisses = iWebFired - iWebHits;

                if (m_iMatchMisses < 0)
                {
                    Log.doIt(1, "Found fucked up moron PGI tracking, misses is NEGATIVE.. clearing");
                    m_iMatchMisses = 0;
                }

                m_iMatchDmg = (int)lWebDamage;
            }
            else
            {
                m_iMatchHits = iWebHits - iBlHits;
                m_iMatchMisses = (iWebFired - iBlFired) - m_iMatchHits;
                m_iMatchDmg = (int)( lWebDamage - lBlDamage );
            }

            bScraped = true;

        } // end of parsing out datagrid..

        // since we need this data for 2 distinct modes (baseline creation and normal running), we might
        // as well have it in it's own space..
        private void fillIt( ref DataGridViewRow dvRow )
        {
            int.TryParse( dvRow.Cells[1].Value.ToString().Replace( ",", "" ), out iWebMatches );
            int.TryParse( dvRow.Cells[2].Value.ToString().Replace( ",", "" ), out iWebFired );
            int.TryParse( dvRow.Cells[3].Value.ToString().Replace( ",", "" ), out iWebHits );
            long.TryParse( dvRow.Cells[6].Value.ToString().Replace( ",", "" ), out lWebDamage );
        }

        // separate code for when we need to recreate baseline tables..
        public void SetBaseline( ref DataGridViewRow oRow )
        {
            string sScrapedWeapon = oRow.Cells[0].Value.ToString().Trim();

            ClearVars();

            Log.doIt( 1, "Filling baseweaps table with new baseline info.." );

            fillIt( ref oRow );

            sCommand = "insert into baseweaps (Weapon, Matches, Fired, Hits, Damage) values('" + sScrapedWeapon + "', '" + iWebMatches +
                    "', '" + iWebFired + "', '" + iWebHits + "', '" + lWebDamage + "')";

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
                Log.doIt( 1, "Hmm.. showing we haven't scraped for weapon: " + sWeapon + ".. not going to move web values over.." );
                return;
            }

            Log.doIt( 3, "Moving web values to baseline values.." );

            iBlMatches = iWebMatches;
            iBlFired = iWebFired;
            iBlHits = iWebHits;
            lBlDamage = lWebDamage;

            // only do an update if we were already seeded.. if we dumped the data by hand, seeded = false, we later scrape and do the
            // inserts there.. then call re-seed/set new seed, which puts us here to move the scraped values to out baseline variable..
            // however, we don't need to update the rows that were just recently inserted..
            if (bWeaponIsSeeded)
            {
                string sCommand = "update baseweaps set matches='" + iBlMatches + "', fired='" + iBlFired + "', hits='" + iBlHits + "', " +
                "damage='" + lBlDamage + "' where weapon='" + sWeapon + "'";
                Log.doIt(2, "Using command to update baseline row: " + sCommand);

                m_myDb.Insert(sCommand, false);
            }
            else // fixing logical bug.. if it wasn't seeded it means it wasn't in our baseline before.. but since it is NOW, we need
                 // to ADD this entry into our baseline data so it's there next time we come through. I don't know why we've not been
                 // failing on all scrapes after the first since the "update" above should have failed, but we never actually add new
                 // things to the base tables and it causes false "new thing found" calls (which also had a logical bug in that it
                 // presumed all "new found" in scrapes meant we never added it to our core tables before)
            {
                // first make sure it's not already in the baseweaps table.. it shouldn't be, but if it is we'll make a mess of things
                // if we dupe it there..
                if (m_myDb.iNumValReturn("select count(*) from baseweaps where weapon = '" + sWeapon + "'") == 0)
                {
                    string sCommand = "insert into baseweaps(weapon, matches, hits, fired, damage) values('" + sWeapon + "', '" + iBlMatches +
                        "', '" + iBlHits + "', '" + iBlFired + "', '" + lBlDamage + "')";
                    Log.doIt(2, "Using command to INSERT baseline row: " + sCommand);

                    m_myDb.Insert(sCommand, false);
                }
                else
                {
                    Log.doIt(1, "WTF.. new scrape of " + sWeapon + ", but we seem to have already HAD it in baseweaps??");
                }
            }

            bWeaponIsSeeded = true;
            bScraped = false;
            m_bFoundMatch = false; // don't forget to clear our internal tracker..

            Log.doIt( 3, "Finished setting new weapon baseline.." );

            iWebMatches = 0;
            iWebFired = 0;
            iWebHits = 0;
            lWebDamage = 0;

        } // end of SetNewSeed

        private void ClearVars()
        {
            bWeaponIsSeeded = false;
            bScraped = false;

            iWebMatches = 0;
            iWebFired = 0;
            iWebHits = 0;
            lWebDamage = 0;

            iBlMatches = 0;
            iBlFired = 0;
            iBlHits = 0;
            lBlDamage = 0;

            m_iMatchHits = 0;
            m_iMatchMisses = 0;
            m_iMatchDmg = 0;


        }

        /// <summary>
        /// Property to get the name of this weapon isnstance (we set it if we didn't have it in our tracking
        /// dictionary, which means it's a newly found weapon)
        /// </summary>
        public string Key
        {
            get { return sWeapon; }
            //set { sWeapon = value; }
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
            if ( m_bFoundMatch )
                return true;

            if ( iWebMatches > iBlMatches )
            {
                m_bFoundMatch = true;
                return true;
            }

            if ( iWebFired > iBlFired )
            {
                m_bFoundMatch = true;
                return true;
            }

            if ( iWebHits > iBlHits )
            {
                m_bFoundMatch = true;
                return true;
            }

            if ( lWebDamage > lBlDamage )
            {
                m_bFoundMatch = true;
                return true;
            }

            return false;
        } // end of bDataChanged

        public void insertDetails( int iMatchId )
        {
            if ( m_bFoundMatch )
            {
                Log.doIt( 1, sWeapon + ": Found for match: " + iMatchId + ", inserting row.." );

                string sCommand = "insert into matchdetails (matchid, weapon, hits, misses, dmgdone) " +
                    "values(" + iMatchId + ", " + iWeaponId + ", " + m_iMatchHits + ", " + m_iMatchMisses + ", " + m_iMatchDmg + ")";

                m_myDb.Insert( sCommand );
            }
            else
            {
                Log.doIt( 2, sWeapon + ": not found in match, not entering details to matchdetails table.." );
            }

        } // end of InsertDetails..

    } // end of weapon class

} // end of namespace..