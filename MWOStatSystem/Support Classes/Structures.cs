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

    #region Match data classes
    /// <summary>
    /// This structure will be filled in with various stat info from various pages so we can end up with 
    /// a picture of "a match". The ID will have to be pulled after insert, and will let the "details"
    /// processor know which match to insert with.
    /// </summary>
    public class clSingleMatch
    {
        public int iMatchId = -1;
        public int iMech = -1;
        public int iMap = -1;
        public int iMode = -1;
        public int iKills = -1;
        public bool bDeath = false;
        public char cWinLoss = 'X';
        public int iExp = 0;
        public int iCBills = 0;
        public int iDuration = 0;
        public DateTime? dtDate = null; // DateTime.Now;
    }

    #endregion -- Match data

    // holds the mech id, common name, and official designation of the mech
    public class clMechInfo
    {

        public int iMechId = -1;
        public string strMechName = "";
        public string strMechDesignation = "";

        public void Reset()
        {
            iMechId = -1;
            strMechDesignation = "";
            strMechName = "";
        }

        public void Names(string strNameFromDb)
        {
            if (strNameFromDb.ToLower().Contains("kit fox"))
            {
                strMechName = strNameFromDb.Substring(0, 7).Trim();
                strMechDesignation = strNameFromDb.Substring(8).Trim().Replace("(", "");
                strMechDesignation = strMechDesignation.Replace(")", "");
            }
            else
            {

                strMechName = strNameFromDb.Substring(0, strNameFromDb.IndexOf(' ')).Trim();
                strMechDesignation = strNameFromDb.Substring(strNameFromDb.IndexOf(' ') + 1).Trim();
            }

        }
    }
}
