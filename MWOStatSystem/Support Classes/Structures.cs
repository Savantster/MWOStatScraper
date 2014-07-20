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
        public int iDamage = 0;
        public DateTime? dtDate = null; // DateTime.Now;

        public void LoadMatch(ref MWO_DB dbCon, int iMatchId)
        {
            SqlCeResultSet rs;

            // note the LEFT join, and case statement.. had a match were no weapons were reported so no rows came back
            // and that broke things.. so the left join gets the row, but that gives NULL for the damage, so we need to 
            // put a case statement there (Sql CE doesn't support isnull(), so).. Looks to be working at present..
            rs = dbCon.ResultSet("select a.mech, a.map, a.mode, a.kills, a.Death, a.WinLoss, a.Exp, a.cBills, a.duration, a.date, " +
                " case when sum(b.dmgdone) is null then 0 else sum(b.dmgdone) end as Damage " +
                " from Match a left join matchdetails b on a.matchid = b.matchid where a.MatchId = " + iMatchId +
                " group by mech, map, mode, kills, death, winloss, exp, cbills, duration, date");

            rs.ReadFirst();

            this.Reset();

            this.iMatchId = iMatchId;
            this.iMech = (int)rs.GetValue(0);
            this.iMap = (int)rs.GetValue(1);
            this.iMode = (int)rs.GetValue(2);
            this.iKills = (int)rs.GetByte(3);
            this.bDeath = rs.GetBoolean(4);
            this.cWinLoss = (char)rs.GetString(5)[0];
            this.iExp = (int)rs.GetInt16(6);
            this.iCBills = (int)rs.GetValue(7);
            this.iDuration = (int)rs.GetInt16(8);
            this.dtDate = (DateTime)rs.GetDateTime(9);

            object tmp = rs.GetValue(10);
            if (tmp == null)
                this.iDamage = 0;
            else
                this.iDamage = (int)tmp;


        }

        public void Reset()
        {
            iMatchId = -1;
            iMech = -1;
            iMap = -1;
            iMode = -1;
            iKills = -1;
            bDeath = false;
            cWinLoss = 'X';
            iExp = 0;
            iCBills = 0;
            iDuration = 0;
            iDamage = 0;
            dtDate = null; // DateTime.Now;
        }
    }

    #endregion -- Match data

}
