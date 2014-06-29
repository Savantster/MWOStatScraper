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
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MWOStatSystem.Support_Classes;


namespace MWOStatSystem
{
    public partial class LoginDetails : Form
    {
        private MWO_DB myDb;

        public LoginDetails(ref MWO_DB db)
        {
            InitializeComponent();
            // since we now put details directly into the DB, might as well let them close the form..
            //this.ControlBox = false; // no closing with the X, must put in details
            myDb = db;
        }

        private void btnSetVals_Click(object sender, EventArgs e)
        {
            if ( tbEmail.Text.Length <= 0 )
            {
                MessageBox.Show( "Must provide an email to log in with..", "Missing Email" );
                return;
            }

            if ( tbPass.Text.Length <= 0 )
            {
                MessageBox.Show( "Must provide a password to log in with...", "Missing Passowrd" );
                return;
            }

            // set the user/pass on the partent form.. this should work, we'll see :D

            if ( (int)myDb.CountTable("login") == 0 )
            {
                myDb.Insert( "insert into login(userid, password) values('" + tbEmail.Text + "', '" + tbPass.Text + "')" );
            }
            else
            {
                myDb.Insert( "update login set password = '" + tbPass.Text + "', userid = '" + tbEmail.Text + "'" );
            }

            this.Hide();
        }

        private void tbPass_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( e.KeyChar == (char)Keys.Return )
                btnSetVals_Click( this, null );
        }

    }
}
