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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWOStatSystem
{
    public partial class frmError : Form
    {
        private int iHeightAdjust = 60;

        public frmError()
        {
            InitializeComponent();
            this.ControlBox = false;
            //rtbPage.Width = this.Width - 30;
            rtbPage.Height = this.Height - btnClear.Height - iHeightAdjust;
        }

        private void rtbPage_Resize( object sender, EventArgs e )
        {
            //rtbPage.Width = this.Width - 30;
            rtbPage.Height = this.Height - btnClear.Height - iHeightAdjust;
        }

        private void btnHide_Click( object sender, EventArgs e )
        {
            this.Hide();
        }

        private void btnClear_Click( object sender, EventArgs e )
        {
            rtbPage.Clear();
            rtbPage.ClearUndo(); // memory leak if you don't clear this..
        }

        private void frmError_Shown( object sender, EventArgs e )
        {
            rtbPage.Height = this.Height - iHeightAdjust;
        }
    }
}
