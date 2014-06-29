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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWOStatSystem.Support_Classes
{
    public class MWO_DB
    {
        private SqlCeConnection con;
        private SqlCeCommand cmd;
        //private SqlCeResultSet rs;
        //private StreamWriter swTrans;
        //private string sTransDir = System.Environment.CurrentDirectory + "\\transactions";
        //private string sTransFile;

        public MWO_DB()
        {
            try
            {
                con = new SqlCeConnection( @"Data Source=|DataDirectory|\MWOStatSystemDB.sdf" );
                con.Open();

                cmd = new SqlCeCommand();
                cmd.Connection = con;

            }
            catch ( Exception ex )
            {
                throw new Exception( "Failed to connect to the database, can't continue.." + ex.Message );
            }

            // transactions aren't working as hoped.. there have been extra entries all through various bug fixes which has rendered
            // the trasaction processing invalid. Trying to use the existing transaction file(s) without manually cleaning up all the
            // mess will set all kinds of entries to wrong values and there's no point in having bad data in a recovery attempt.
            //try
            //{

            //    if ( !Directory.Exists( sTransDir ) )
            //    {
            //        Directory.CreateDirectory( sTransDir );
            //    }
            //    //" + DateTime.Now.ToString("MMddyyyyHHMMss") + "

            //    sTransFile = "MWO_match_inserts.sqlce";
            //    // if the file is here, see how big it is. If it's over a few megs, copy it off to an archive name and open the file
            //    // as new with the set identity text in it.. if it's small enough, just open it and continue putting insert lines in it.
            //    if ( File.Exists( sTransDir + "\\" + sTransFile ) )
            //    {
            //        FileInfo fi = new FileInfo( sTransDir + "\\" + sTransFile );
            //        if ( fi.Length > 1015800 ) // lets cut it and start new
            //        {
            //            string sDestFile = sTransDir + "\\MWO_Match_Inserts_" + DateTime.Now.ToString( "MMddyyyyHHMMss" ) + ".sqlce";
            //            File.Move( sTransDir + "\\" + sTransFile, sDestFile );
            //            swTrans = new StreamWriter( sTransDir + "\\" + sTransFile ); // start the file over
            //            swTrans.WriteLine( "set identity_insert match on;" );
            //            swTrans.WriteLine( "go" );
            //            swTrans.Flush();

            //        }
            //        else
            //        {
            //            swTrans = new StreamWriter( sTransDir + "\\" + sTransFile, true ); // open it for appending
            //        }
            //    }
            //    else
            //    {
            //        // new file being created..
            //        swTrans = new StreamWriter( sTransDir + "\\" + sTransFile ); // start the file over
            //        swTrans.WriteLine( "set identity_insert match on;" );
            //        swTrans.WriteLine( "go" );
            //        swTrans.Flush();
            //    }
            //}
            //catch ( Exception ex )
            //{
            //    throw new Exception( "Failed to initialize the Transaction file.. " + ex.Message );
            //}


        }

        public SqlCeResultSet ResultSet( string sCommand )
        {
            cmd.CommandText = sCommand;
            return cmd.ExecuteResultSet( ResultSetOptions.Scrollable );
        }

        public int CountTable( string sTable )
        {
            cmd.CommandText = "select count(*) from " + sTable;
            return (int)cmd.ExecuteScalar();
        }

        public int iNumValReturn( string sCommand )
        {
            cmd.CommandText = sCommand;
            return (int)cmd.ExecuteScalar();
        }

        /// <summary>
        /// Executes the command passed in, be it insert, update, delete, etc.
        /// </summary>
        /// <param name="sCommand">Command to execute on the database</param>
        /// <param name="bDumpToTrans">Optional parameter telling us if we should create a transaction log entry
        /// for this command.. we do NOT want to log things like inserts to the baseline tables during refresh, or
        /// updates when we shift parsing to baseline.</param>
        public void Insert( string sCommand, bool bDumpToTrans = true )
        {
            cmd.CommandText = sCommand;
            cmd.ExecuteNonQuery();

            // now put it in our transaction log..
            //if ( bDumpToTrans )
            //{
            //    swTrans.WriteLine( sCommand );
            //    swTrans.WriteLine( "GO" );
            //    swTrans.Flush();
            //}

        }

        public void clearAllBaseTables()
        {
            cmd.CommandText = "delete from basemap";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from basemechs";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from basemode";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from baseweaps";
            cmd.ExecuteNonQuery();
        }

        public void InsertMatch(ref clSingleMatch Match)
        {
            string sCommand = "insert into Match (mech, map, mode, kills, death, winloss, exp, cbills, duration, date) values(" +
                Match.iMech + ", " + Match.iMap + ", " + Match.iMode + ", " + Match.iKills + ", " + 
                ( Match.bDeath? 1:0 ) + ", '" + Match.cWinLoss + "', " + Match.iExp + ", " + Match.iCBills + ", " + Match.iDuration + 
                ", '" + DateTime.Now.ToString( "MM/dd/yyyy HH:mm:ss" ) + "')";

            this.Insert( sCommand );

            Match.iMatchId = this.iNumValReturn( "select max(MatchId) from Match" );

        }

        public void CloseConnections()
        {
            if ( con != null )
                con.Close();
            //if ( swTrans != null )
            //    swTrans.Close();
        }
    }

}
