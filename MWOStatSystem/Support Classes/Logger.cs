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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWOStatSystem.Support_Classes
{
    class Logger
    {
        private frmError logit;
        private int m_errLvl = 1;
        private bool m_bToFile = false;
        private string m_sLogMsg = "";

        private StreamWriter _sw;

        public void doIt( int iLogLvl, string toWrite )
        {

            // only print if the message coming in is at or below current internal log level..
            if ( iLogLvl <= m_errLvl )
            {
                m_sLogMsg = DateTime.Now + " :: " + toWrite;
                //logit.rtbPage.Text +=  m_sLogMsg + "\n";

                // lets see if using the control's append is faster than updting the string and
                // then resetting the entire text. Not seeing performance issues when the log window
                // only has limited data, but on long debugging runs we can end up with a LOT of
                // text in there.. and it gets a little sluggish at that point.
                logit.rtbPage.AppendText(m_sLogMsg + "\n");

                if ( m_bToFile )
                {
                    _sw.WriteLine( m_sLogMsg );
                    _sw.Flush();
                }
            }

        }

        public Logger()
        {
            logit = new frmError();
            _sw = new StreamWriter( System.Environment.CurrentDirectory + "\\MWOStatSys.log", true );
        }

        public void frmShow()
        {
            if ( logit != null )
            {
                logit.Show();
                logit.BringToFront();
            }
        }

        public int setErrorLevel
        {
            get { return m_errLvl; }
            set { m_errLvl = value; }
        }

        public bool bToFile
        {
            get { return m_bToFile; }
            set { m_bToFile = value; }
        }

    }
}
