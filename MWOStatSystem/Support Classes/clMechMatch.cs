
//using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//using System.ComponentModel;
//using System.ComponentModel.Design;
using System.Runtime.InteropServices;
//using System.Windows.Forms.Design;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using MWOStatSystem.Support_Classes;
using System.Data.SqlServerCe;

//[Designer(typeof(ExpandableGroupboxDesigner))]
public class clMechMatch : System.Windows.Forms.UserControl
{
    private MWO_DB m_myDB;
    private List<clSingleMatch> _lstMatchHistory = null;

    #region " Designer Generated (do not edit) "

    //UserControl overrides dispose to clean up the component list.
    [System.Diagnostics.DebuggerNonUserCode()]
    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
        }
        finally
        {
            base.Dispose(disposing);
        }
    }

    internal System.Windows.Forms.Panel pnlHeader;
    internal System.Windows.Forms.Button ExpandButton;
    internal System.Windows.Forms.Label lblCaption;

    internal System.Windows.Forms.PictureBox pbMech;
    internal ucRoundedPanel pnlStats;
    internal Label lblCBills;
    internal Label lblKills;
    internal PictureBox pbWin;
    internal Label Label9;
    internal PictureBox pbLived;
    internal Label Label3;
    internal Label lblExp;
    internal Label Label4;
    internal Label Label2;
    internal Label Label7;
    internal Label Label1;
    internal Label lblDamage;
    internal GroupBox gbLastMatch;
    internal GroupBox gbPM1;
    internal ucRoundedPanel ucRoundedPanel1;
    internal Label lblPM1cBills;
    internal Label lblPM1Kills;
    internal PictureBox pbPM1Win;
    internal Label label8;
    internal PictureBox pbPM1Live;
    internal Label label10;
    internal Label lblPM1Exp;
    internal Label label12;
    internal Label label13;
    internal Label label14;
    internal Label label15;
    internal Label lblPM1Damage;
    internal GroupBox gbPm2;
    internal ucRoundedPanel ucRoundedPanel2;
    internal Label lblPM2cBills;
    internal Label lblPM2Kills;
    internal PictureBox pbPM2Win;
    internal Label label19;
    internal PictureBox pbPM2Live;
    internal Label label20;
    internal Label lblPM2Exp;
    internal Label label22;
    internal Label label23;
    internal Label label24;
    internal Label label25;
    internal Label lblPM2Damage;
    internal GroupBox gbPM3;
    internal ucRoundedPanel ucRoundedPanel3;
    internal Label lblPM3cBills;
    internal Label lblPM3Kills;
    internal PictureBox pbPM3Win;
    internal Label label29;
    internal PictureBox pbPM3Live;
    internal Label label30;
    internal Label lblPM3Exp;
    internal Label label32;
    internal Label label33;
    internal Label label34;
    internal Label label35;
    internal Label lblPM3Damage;
    internal GroupBox gbPM4;
    internal ucRoundedPanel ucRoundedPanel4;
    internal Label lblPM4cBills;
    internal Label lblPM4Kills;
    internal PictureBox pbPM4Win;
    internal Label label39;
    internal PictureBox pbPM4Live;
    internal Label label40;
    internal Label lblPM4Exp;
    internal Label label42;
    internal Label label43;
    internal Label label44;
    internal Label label45;
    internal Label lblPM4Damage;
    
    //Required by the Windows Form Designer

    private System.ComponentModel.IContainer components;
    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.
    [System.Diagnostics.DebuggerStepThrough()]
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();

        this.pnlHeader = new System.Windows.Forms.Panel();
        this.ExpandButton = new System.Windows.Forms.Button();
        this.lblCaption = new System.Windows.Forms.Label();
        this.pbMech = new System.Windows.Forms.PictureBox();
        this.gbLastMatch = new System.Windows.Forms.GroupBox();
        this.gbPM1 = new System.Windows.Forms.GroupBox();
        this.gbPm2 = new System.Windows.Forms.GroupBox();
        this.gbPM3 = new System.Windows.Forms.GroupBox();
        this.gbPM4 = new System.Windows.Forms.GroupBox();
        this.ucRoundedPanel4 = new MWOStatSystem.Support_Classes.ucRoundedPanel();
        this.lblPM4cBills = new System.Windows.Forms.Label();
        this.lblPM4Kills = new System.Windows.Forms.Label();
        this.pbPM4Win = new System.Windows.Forms.PictureBox();
        this.label39 = new System.Windows.Forms.Label();
        this.pbPM4Live = new System.Windows.Forms.PictureBox();
        this.label40 = new System.Windows.Forms.Label();
        this.lblPM4Exp = new System.Windows.Forms.Label();
        this.label42 = new System.Windows.Forms.Label();
        this.label43 = new System.Windows.Forms.Label();
        this.label44 = new System.Windows.Forms.Label();
        this.label45 = new System.Windows.Forms.Label();
        this.lblPM4Damage = new System.Windows.Forms.Label();
        this.ucRoundedPanel3 = new MWOStatSystem.Support_Classes.ucRoundedPanel();
        this.lblPM3cBills = new System.Windows.Forms.Label();
        this.lblPM3Kills = new System.Windows.Forms.Label();
        this.pbPM3Win = new System.Windows.Forms.PictureBox();
        this.label29 = new System.Windows.Forms.Label();
        this.pbPM3Live = new System.Windows.Forms.PictureBox();
        this.label30 = new System.Windows.Forms.Label();
        this.lblPM3Exp = new System.Windows.Forms.Label();
        this.label32 = new System.Windows.Forms.Label();
        this.label33 = new System.Windows.Forms.Label();
        this.label34 = new System.Windows.Forms.Label();
        this.label35 = new System.Windows.Forms.Label();
        this.lblPM3Damage = new System.Windows.Forms.Label();
        this.ucRoundedPanel2 = new MWOStatSystem.Support_Classes.ucRoundedPanel();
        this.lblPM2cBills = new System.Windows.Forms.Label();
        this.lblPM2Kills = new System.Windows.Forms.Label();
        this.pbPM2Win = new System.Windows.Forms.PictureBox();
        this.label19 = new System.Windows.Forms.Label();
        this.pbPM2Live = new System.Windows.Forms.PictureBox();
        this.label20 = new System.Windows.Forms.Label();
        this.lblPM2Exp = new System.Windows.Forms.Label();
        this.label22 = new System.Windows.Forms.Label();
        this.label23 = new System.Windows.Forms.Label();
        this.label24 = new System.Windows.Forms.Label();
        this.label25 = new System.Windows.Forms.Label();
        this.lblPM2Damage = new System.Windows.Forms.Label();
        this.ucRoundedPanel1 = new MWOStatSystem.Support_Classes.ucRoundedPanel();
        this.lblPM1cBills = new System.Windows.Forms.Label();
        this.lblPM1Kills = new System.Windows.Forms.Label();
        this.pbPM1Win = new System.Windows.Forms.PictureBox();
        this.label8 = new System.Windows.Forms.Label();
        this.pbPM1Live = new System.Windows.Forms.PictureBox();
        this.label10 = new System.Windows.Forms.Label();
        this.lblPM1Exp = new System.Windows.Forms.Label();
        this.label12 = new System.Windows.Forms.Label();
        this.label13 = new System.Windows.Forms.Label();
        this.label14 = new System.Windows.Forms.Label();
        this.label15 = new System.Windows.Forms.Label();
        this.lblPM1Damage = new System.Windows.Forms.Label();
        this.pnlStats = new MWOStatSystem.Support_Classes.ucRoundedPanel();
        this.lblCBills = new System.Windows.Forms.Label();
        this.lblKills = new System.Windows.Forms.Label();
        this.pbWin = new System.Windows.Forms.PictureBox();
        this.Label9 = new System.Windows.Forms.Label();
        this.pbLived = new System.Windows.Forms.PictureBox();
        this.Label3 = new System.Windows.Forms.Label();
        this.lblExp = new System.Windows.Forms.Label();
        this.Label4 = new System.Windows.Forms.Label();
        this.Label2 = new System.Windows.Forms.Label();
        this.Label7 = new System.Windows.Forms.Label();
        this.Label1 = new System.Windows.Forms.Label();
        this.lblDamage = new System.Windows.Forms.Label();
        this.pnlHeader.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pbMech)).BeginInit();
        this.gbLastMatch.SuspendLayout();
        this.gbPM1.SuspendLayout();
        this.gbPm2.SuspendLayout();
        this.gbPM3.SuspendLayout();
        this.gbPM4.SuspendLayout();
        this.ucRoundedPanel4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pbPM4Win)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pbPM4Live)).BeginInit();
        this.ucRoundedPanel3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pbPM3Win)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pbPM3Live)).BeginInit();
        this.ucRoundedPanel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pbPM2Win)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pbPM2Live)).BeginInit();
        this.ucRoundedPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pbPM1Win)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pbPM1Live)).BeginInit();
        this.pnlStats.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pbWin)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pbLived)).BeginInit();
        this.SuspendLayout();
        // 
        // pnlHeader
        // 
        this.pnlHeader.Controls.Add(this.ExpandButton);
        this.pnlHeader.Controls.Add(this.lblCaption);
        this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlHeader.Location = new System.Drawing.Point(0, 0);
        this.pnlHeader.Name = "pnlHeader";
        this.pnlHeader.Size = new System.Drawing.Size(689, 21);
        this.pnlHeader.TabIndex = 0;
        this.pnlHeader.Click += new System.EventHandler(this.pnlHeader_Click);
        this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
        // 
        // ExpandButton
        // 
        this.ExpandButton.Location = new System.Drawing.Point(10, 2);
        this.ExpandButton.Name = "ExpandButton";
        this.ExpandButton.Size = new System.Drawing.Size(17, 17);
        this.ExpandButton.TabIndex = 0;
        this.ExpandButton.UseVisualStyleBackColor = true;
        this.ExpandButton.Click += new System.EventHandler(this.ExpandButton_Click);
        this.ExpandButton.Paint += new System.Windows.Forms.PaintEventHandler(this.ExpandButton_Paint);
        // 
        // lblCaption
        // 
        this.lblCaption.AutoSize = true;
        this.lblCaption.Location = new System.Drawing.Point(27, 3);
        this.lblCaption.Name = "lblCaption";
        this.lblCaption.Size = new System.Drawing.Size(0, 13);
        this.lblCaption.TabIndex = 0;
        this.lblCaption.Click += new System.EventHandler(this.lblCaption_Click);
        // 
        // pbMech
        // 
        this.pbMech.Location = new System.Drawing.Point(10, 27);
        this.pbMech.Name = "pbMech";
        this.pbMech.Size = new System.Drawing.Size(100, 100);
        this.pbMech.TabIndex = 1;
        this.pbMech.TabStop = false;
        this.pbMech.Click += new System.EventHandler(this.ExpandButton_Click);
        // 
        // gbLastMatch
        // 
        this.gbLastMatch.BackColor = System.Drawing.Color.Transparent;
        this.gbLastMatch.Controls.Add(this.pnlStats);
        this.gbLastMatch.Location = new System.Drawing.Point(116, 25);
        this.gbLastMatch.Name = "gbLastMatch";
        this.gbLastMatch.Size = new System.Drawing.Size(573, 95);
        this.gbLastMatch.TabIndex = 4;
        this.gbLastMatch.TabStop = false;
        this.gbLastMatch.Text = "Last Match Details";
        // 
        // gbPM1
        // 
        this.gbPM1.BackColor = System.Drawing.Color.Transparent;
        this.gbPM1.Controls.Add(this.ucRoundedPanel1);
        this.gbPM1.Location = new System.Drawing.Point(157, 133);
        this.gbPM1.Name = "gbPM1";
        this.gbPM1.Size = new System.Drawing.Size(532, 70);
        this.gbPM1.TabIndex = 5;
        this.gbPM1.TabStop = false;
        this.gbPM1.Text = "Previous Match Details";
        // 
        // gbPm2
        // 
        this.gbPm2.BackColor = System.Drawing.Color.Transparent;
        this.gbPm2.Controls.Add(this.ucRoundedPanel2);
        this.gbPm2.Location = new System.Drawing.Point(157, 209);
        this.gbPm2.Name = "gbPm2";
        this.gbPm2.Size = new System.Drawing.Size(532, 70);
        this.gbPm2.TabIndex = 6;
        this.gbPm2.TabStop = false;
        this.gbPm2.Text = "Next Previous Match Details";
        // 
        // gbPM3
        // 
        this.gbPM3.BackColor = System.Drawing.Color.Transparent;
        this.gbPM3.Controls.Add(this.ucRoundedPanel3);
        this.gbPM3.Location = new System.Drawing.Point(157, 285);
        this.gbPM3.Name = "gbPM3";
        this.gbPM3.Size = new System.Drawing.Size(532, 70);
        this.gbPM3.TabIndex = 7;
        this.gbPM3.TabStop = false;
        this.gbPM3.Text = "Next Previous Match Details";
        // 
        // gbPM4
        // 
        this.gbPM4.BackColor = System.Drawing.Color.Transparent;
        this.gbPM4.Controls.Add(this.ucRoundedPanel4);
        this.gbPM4.Location = new System.Drawing.Point(157, 361);
        this.gbPM4.Name = "gbPM4";
        this.gbPM4.Size = new System.Drawing.Size(532, 70);
        this.gbPM4.TabIndex = 8;
        this.gbPM4.TabStop = false;
        this.gbPM4.Text = "Next Previous Match Details";
        // 
        // ucRoundedPanel4
        // 
        this.ucRoundedPanel4.Controls.Add(this.lblPM4cBills);
        this.ucRoundedPanel4.Controls.Add(this.lblPM4Kills);
        this.ucRoundedPanel4.Controls.Add(this.pbPM4Win);
        this.ucRoundedPanel4.Controls.Add(this.label39);
        this.ucRoundedPanel4.Controls.Add(this.pbPM4Live);
        this.ucRoundedPanel4.Controls.Add(this.label40);
        this.ucRoundedPanel4.Controls.Add(this.lblPM4Exp);
        this.ucRoundedPanel4.Controls.Add(this.label42);
        this.ucRoundedPanel4.Controls.Add(this.label43);
        this.ucRoundedPanel4.Controls.Add(this.label44);
        this.ucRoundedPanel4.Controls.Add(this.label45);
        this.ucRoundedPanel4.Controls.Add(this.lblPM4Damage);
        this.ucRoundedPanel4.HighlightedBackColor = System.Drawing.Color.Empty;
        this.ucRoundedPanel4.Location = new System.Drawing.Point(3, 13);
        this.ucRoundedPanel4.Margin = new System.Windows.Forms.Padding(0);
        this.ucRoundedPanel4.Name = "ucRoundedPanel4";
        this.ucRoundedPanel4.Size = new System.Drawing.Size(529, 55);
        this.ucRoundedPanel4.TabIndex = 0;
        // 
        // lblPM4cBills
        // 
        this.lblPM4cBills.BackColor = System.Drawing.Color.Transparent;
        this.lblPM4cBills.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblPM4cBills.Location = new System.Drawing.Point(325, 18);
        this.lblPM4cBills.Name = "lblPM4cBills";
        this.lblPM4cBills.Size = new System.Drawing.Size(104, 29);
        this.lblPM4cBills.TabIndex = 16;
        this.lblPM4cBills.Text = "------";
        this.lblPM4cBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblPM4Kills
        // 
        this.lblPM4Kills.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblPM4Kills.Location = new System.Drawing.Point(106, 18);
        this.lblPM4Kills.Name = "lblPM4Kills";
        this.lblPM4Kills.Size = new System.Drawing.Size(41, 29);
        this.lblPM4Kills.TabIndex = 11;
        this.lblPM4Kills.Text = "--";
        this.lblPM4Kills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pbPM4Win
        // 
        this.pbPM4Win.Location = new System.Drawing.Point(9, 22);
        this.pbPM4Win.Name = "pbPM4Win";
        this.pbPM4Win.Size = new System.Drawing.Size(20, 20);
        this.pbPM4Win.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pbPM4Win.TabIndex = 7;
        this.pbPM4Win.TabStop = false;
        // 
        // label39
        // 
        this.label39.AutoSize = true;
        this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label39.Location = new System.Drawing.Point(358, 10);
        this.label39.Name = "label39";
        this.label39.Size = new System.Drawing.Size(29, 9);
        this.label39.TabIndex = 15;
        this.label39.Text = "C-Bills";
        // 
        // pbPM4Live
        // 
        this.pbPM4Live.Location = new System.Drawing.Point(60, 22);
        this.pbPM4Live.Name = "pbPM4Live";
        this.pbPM4Live.Size = new System.Drawing.Size(20, 20);
        this.pbPM4Live.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pbPM4Live.TabIndex = 8;
        this.pbPM4Live.TabStop = false;
        // 
        // label40
        // 
        this.label40.AutoSize = true;
        this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label40.Location = new System.Drawing.Point(117, 10);
        this.label40.Name = "label40";
        this.label40.Size = new System.Drawing.Size(20, 9);
        this.label40.TabIndex = 6;
        this.label40.Text = "Kills";
        // 
        // lblPM4Exp
        // 
        this.lblPM4Exp.BackColor = System.Drawing.Color.Transparent;
        this.lblPM4Exp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblPM4Exp.Location = new System.Drawing.Point(228, 18);
        this.lblPM4Exp.Name = "lblPM4Exp";
        this.lblPM4Exp.Size = new System.Drawing.Size(90, 29);
        this.lblPM4Exp.TabIndex = 14;
        this.lblPM4Exp.Text = "----";
        this.lblPM4Exp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label42
        // 
        this.label42.AutoSize = true;
        this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label42.Location = new System.Drawing.Point(171, 10);
        this.label42.Name = "label42";
        this.label42.Size = new System.Drawing.Size(41, 9);
        this.label42.TabIndex = 10;
        this.label42.Text = "Dammage";
        // 
        // label43
        // 
        this.label43.AutoSize = true;
        this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label43.Location = new System.Drawing.Point(57, 10);
        this.label43.Name = "label43";
        this.label43.Size = new System.Drawing.Size(27, 9);
        this.label43.TabIndex = 4;
        this.label43.Text = "Lived?";
        // 
        // label44
        // 
        this.label44.AutoSize = true;
        this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label44.Location = new System.Drawing.Point(260, 10);
        this.label44.Name = "label44";
        this.label44.Size = new System.Drawing.Size(20, 9);
        this.label44.TabIndex = 13;
        this.label44.Text = "EXP";
        // 
        // label45
        // 
        this.label45.AutoSize = true;
        this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label45.Location = new System.Drawing.Point(11, 10);
        this.label45.Name = "label45";
        this.label45.Size = new System.Drawing.Size(23, 9);
        this.label45.TabIndex = 2;
        this.label45.Text = "Win?";
        // 
        // lblPM4Damage
        // 
        this.lblPM4Damage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblPM4Damage.Location = new System.Drawing.Point(158, 18);
        this.lblPM4Damage.Name = "lblPM4Damage";
        this.lblPM4Damage.Size = new System.Drawing.Size(71, 29);
        this.lblPM4Damage.TabIndex = 12;
        this.lblPM4Damage.Text = "---";
        this.lblPM4Damage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ucRoundedPanel3
        // 
        this.ucRoundedPanel3.Controls.Add(this.lblPM3cBills);
        this.ucRoundedPanel3.Controls.Add(this.lblPM3Kills);
        this.ucRoundedPanel3.Controls.Add(this.pbPM3Win);
        this.ucRoundedPanel3.Controls.Add(this.label29);
        this.ucRoundedPanel3.Controls.Add(this.pbPM3Live);
        this.ucRoundedPanel3.Controls.Add(this.label30);
        this.ucRoundedPanel3.Controls.Add(this.lblPM3Exp);
        this.ucRoundedPanel3.Controls.Add(this.label32);
        this.ucRoundedPanel3.Controls.Add(this.label33);
        this.ucRoundedPanel3.Controls.Add(this.label34);
        this.ucRoundedPanel3.Controls.Add(this.label35);
        this.ucRoundedPanel3.Controls.Add(this.lblPM3Damage);
        this.ucRoundedPanel3.HighlightedBackColor = System.Drawing.Color.Empty;
        this.ucRoundedPanel3.Location = new System.Drawing.Point(3, 13);
        this.ucRoundedPanel3.Margin = new System.Windows.Forms.Padding(0);
        this.ucRoundedPanel3.Name = "ucRoundedPanel3";
        this.ucRoundedPanel3.Size = new System.Drawing.Size(529, 55);
        this.ucRoundedPanel3.TabIndex = 0;
        // 
        // lblPM3cBills
        // 
        this.lblPM3cBills.BackColor = System.Drawing.Color.Transparent;
        this.lblPM3cBills.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblPM3cBills.Location = new System.Drawing.Point(325, 18);
        this.lblPM3cBills.Name = "lblPM3cBills";
        this.lblPM3cBills.Size = new System.Drawing.Size(104, 29);
        this.lblPM3cBills.TabIndex = 16;
        this.lblPM3cBills.Text = "------";
        this.lblPM3cBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblPM3Kills
        // 
        this.lblPM3Kills.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblPM3Kills.Location = new System.Drawing.Point(106, 18);
        this.lblPM3Kills.Name = "lblPM3Kills";
        this.lblPM3Kills.Size = new System.Drawing.Size(41, 29);
        this.lblPM3Kills.TabIndex = 11;
        this.lblPM3Kills.Text = "--";
        this.lblPM3Kills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pbPM3Win
        // 
        this.pbPM3Win.Location = new System.Drawing.Point(9, 22);
        this.pbPM3Win.Name = "pbPM3Win";
        this.pbPM3Win.Size = new System.Drawing.Size(20, 20);
        this.pbPM3Win.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pbPM3Win.TabIndex = 7;
        this.pbPM3Win.TabStop = false;
        // 
        // label29
        // 
        this.label29.AutoSize = true;
        this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label29.Location = new System.Drawing.Point(358, 10);
        this.label29.Name = "label29";
        this.label29.Size = new System.Drawing.Size(29, 9);
        this.label29.TabIndex = 15;
        this.label29.Text = "C-Bills";
        // 
        // pbPM3Live
        // 
        this.pbPM3Live.Location = new System.Drawing.Point(60, 22);
        this.pbPM3Live.Name = "pbPM3Live";
        this.pbPM3Live.Size = new System.Drawing.Size(20, 20);
        this.pbPM3Live.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pbPM3Live.TabIndex = 8;
        this.pbPM3Live.TabStop = false;
        // 
        // label30
        // 
        this.label30.AutoSize = true;
        this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label30.Location = new System.Drawing.Point(117, 10);
        this.label30.Name = "label30";
        this.label30.Size = new System.Drawing.Size(20, 9);
        this.label30.TabIndex = 6;
        this.label30.Text = "Kills";
        // 
        // lblPM3Exp
        // 
        this.lblPM3Exp.BackColor = System.Drawing.Color.Transparent;
        this.lblPM3Exp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblPM3Exp.Location = new System.Drawing.Point(228, 18);
        this.lblPM3Exp.Name = "lblPM3Exp";
        this.lblPM3Exp.Size = new System.Drawing.Size(90, 29);
        this.lblPM3Exp.TabIndex = 14;
        this.lblPM3Exp.Text = "----";
        this.lblPM3Exp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label32
        // 
        this.label32.AutoSize = true;
        this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label32.Location = new System.Drawing.Point(171, 10);
        this.label32.Name = "label32";
        this.label32.Size = new System.Drawing.Size(41, 9);
        this.label32.TabIndex = 10;
        this.label32.Text = "Dammage";
        // 
        // label33
        // 
        this.label33.AutoSize = true;
        this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label33.Location = new System.Drawing.Point(57, 10);
        this.label33.Name = "label33";
        this.label33.Size = new System.Drawing.Size(27, 9);
        this.label33.TabIndex = 4;
        this.label33.Text = "Lived?";
        // 
        // label34
        // 
        this.label34.AutoSize = true;
        this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label34.Location = new System.Drawing.Point(260, 10);
        this.label34.Name = "label34";
        this.label34.Size = new System.Drawing.Size(20, 9);
        this.label34.TabIndex = 13;
        this.label34.Text = "EXP";
        // 
        // label35
        // 
        this.label35.AutoSize = true;
        this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label35.Location = new System.Drawing.Point(11, 10);
        this.label35.Name = "label35";
        this.label35.Size = new System.Drawing.Size(23, 9);
        this.label35.TabIndex = 2;
        this.label35.Text = "Win?";
        // 
        // lblPM3Damage
        // 
        this.lblPM3Damage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblPM3Damage.Location = new System.Drawing.Point(158, 18);
        this.lblPM3Damage.Name = "lblPM3Damage";
        this.lblPM3Damage.Size = new System.Drawing.Size(71, 29);
        this.lblPM3Damage.TabIndex = 12;
        this.lblPM3Damage.Text = "---";
        this.lblPM3Damage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ucRoundedPanel2
        // 
        this.ucRoundedPanel2.Controls.Add(this.lblPM2cBills);
        this.ucRoundedPanel2.Controls.Add(this.lblPM2Kills);
        this.ucRoundedPanel2.Controls.Add(this.pbPM2Win);
        this.ucRoundedPanel2.Controls.Add(this.label19);
        this.ucRoundedPanel2.Controls.Add(this.pbPM2Live);
        this.ucRoundedPanel2.Controls.Add(this.label20);
        this.ucRoundedPanel2.Controls.Add(this.lblPM2Exp);
        this.ucRoundedPanel2.Controls.Add(this.label22);
        this.ucRoundedPanel2.Controls.Add(this.label23);
        this.ucRoundedPanel2.Controls.Add(this.label24);
        this.ucRoundedPanel2.Controls.Add(this.label25);
        this.ucRoundedPanel2.Controls.Add(this.lblPM2Damage);
        this.ucRoundedPanel2.HighlightedBackColor = System.Drawing.Color.Empty;
        this.ucRoundedPanel2.Location = new System.Drawing.Point(3, 13);
        this.ucRoundedPanel2.Margin = new System.Windows.Forms.Padding(0);
        this.ucRoundedPanel2.Name = "ucRoundedPanel2";
        this.ucRoundedPanel2.Size = new System.Drawing.Size(526, 55);
        this.ucRoundedPanel2.TabIndex = 0;
        // 
        // lblPM2cBills
        // 
        this.lblPM2cBills.BackColor = System.Drawing.Color.Transparent;
        this.lblPM2cBills.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblPM2cBills.Location = new System.Drawing.Point(325, 18);
        this.lblPM2cBills.Name = "lblPM2cBills";
        this.lblPM2cBills.Size = new System.Drawing.Size(104, 29);
        this.lblPM2cBills.TabIndex = 16;
        this.lblPM2cBills.Text = "------";
        this.lblPM2cBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblPM2Kills
        // 
        this.lblPM2Kills.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblPM2Kills.Location = new System.Drawing.Point(106, 18);
        this.lblPM2Kills.Name = "lblPM2Kills";
        this.lblPM2Kills.Size = new System.Drawing.Size(41, 29);
        this.lblPM2Kills.TabIndex = 11;
        this.lblPM2Kills.Text = "--";
        this.lblPM2Kills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pbPM2Win
        // 
        this.pbPM2Win.Location = new System.Drawing.Point(9, 22);
        this.pbPM2Win.Name = "pbPM2Win";
        this.pbPM2Win.Size = new System.Drawing.Size(20, 20);
        this.pbPM2Win.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pbPM2Win.TabIndex = 7;
        this.pbPM2Win.TabStop = false;
        // 
        // label19
        // 
        this.label19.AutoSize = true;
        this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label19.Location = new System.Drawing.Point(358, 10);
        this.label19.Name = "label19";
        this.label19.Size = new System.Drawing.Size(29, 9);
        this.label19.TabIndex = 15;
        this.label19.Text = "C-Bills";
        // 
        // pbPM2Live
        // 
        this.pbPM2Live.Location = new System.Drawing.Point(60, 22);
        this.pbPM2Live.Name = "pbPM2Live";
        this.pbPM2Live.Size = new System.Drawing.Size(20, 20);
        this.pbPM2Live.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pbPM2Live.TabIndex = 8;
        this.pbPM2Live.TabStop = false;
        // 
        // label20
        // 
        this.label20.AutoSize = true;
        this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label20.Location = new System.Drawing.Point(117, 10);
        this.label20.Name = "label20";
        this.label20.Size = new System.Drawing.Size(20, 9);
        this.label20.TabIndex = 6;
        this.label20.Text = "Kills";
        // 
        // lblPM2Exp
        // 
        this.lblPM2Exp.BackColor = System.Drawing.Color.Transparent;
        this.lblPM2Exp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblPM2Exp.Location = new System.Drawing.Point(228, 18);
        this.lblPM2Exp.Name = "lblPM2Exp";
        this.lblPM2Exp.Size = new System.Drawing.Size(90, 29);
        this.lblPM2Exp.TabIndex = 14;
        this.lblPM2Exp.Text = "----";
        this.lblPM2Exp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label22
        // 
        this.label22.AutoSize = true;
        this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label22.Location = new System.Drawing.Point(171, 10);
        this.label22.Name = "label22";
        this.label22.Size = new System.Drawing.Size(41, 9);
        this.label22.TabIndex = 10;
        this.label22.Text = "Dammage";
        // 
        // label23
        // 
        this.label23.AutoSize = true;
        this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label23.Location = new System.Drawing.Point(57, 10);
        this.label23.Name = "label23";
        this.label23.Size = new System.Drawing.Size(27, 9);
        this.label23.TabIndex = 4;
        this.label23.Text = "Lived?";
        // 
        // label24
        // 
        this.label24.AutoSize = true;
        this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label24.Location = new System.Drawing.Point(260, 10);
        this.label24.Name = "label24";
        this.label24.Size = new System.Drawing.Size(20, 9);
        this.label24.TabIndex = 13;
        this.label24.Text = "EXP";
        // 
        // label25
        // 
        this.label25.AutoSize = true;
        this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label25.Location = new System.Drawing.Point(11, 10);
        this.label25.Name = "label25";
        this.label25.Size = new System.Drawing.Size(23, 9);
        this.label25.TabIndex = 2;
        this.label25.Text = "Win?";
        // 
        // lblPM2Damage
        // 
        this.lblPM2Damage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblPM2Damage.Location = new System.Drawing.Point(158, 18);
        this.lblPM2Damage.Name = "lblPM2Damage";
        this.lblPM2Damage.Size = new System.Drawing.Size(71, 29);
        this.lblPM2Damage.TabIndex = 12;
        this.lblPM2Damage.Text = "---";
        this.lblPM2Damage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ucRoundedPanel1
        // 
        this.ucRoundedPanel1.Controls.Add(this.lblPM1cBills);
        this.ucRoundedPanel1.Controls.Add(this.lblPM1Kills);
        this.ucRoundedPanel1.Controls.Add(this.pbPM1Win);
        this.ucRoundedPanel1.Controls.Add(this.label8);
        this.ucRoundedPanel1.Controls.Add(this.pbPM1Live);
        this.ucRoundedPanel1.Controls.Add(this.label10);
        this.ucRoundedPanel1.Controls.Add(this.lblPM1Exp);
        this.ucRoundedPanel1.Controls.Add(this.label12);
        this.ucRoundedPanel1.Controls.Add(this.label13);
        this.ucRoundedPanel1.Controls.Add(this.label14);
        this.ucRoundedPanel1.Controls.Add(this.label15);
        this.ucRoundedPanel1.Controls.Add(this.lblPM1Damage);
        this.ucRoundedPanel1.HighlightedBackColor = System.Drawing.Color.Empty;
        this.ucRoundedPanel1.Location = new System.Drawing.Point(3, 13);
        this.ucRoundedPanel1.Margin = new System.Windows.Forms.Padding(0);
        this.ucRoundedPanel1.Name = "ucRoundedPanel1";
        this.ucRoundedPanel1.Size = new System.Drawing.Size(526, 55);
        this.ucRoundedPanel1.TabIndex = 0;
        // 
        // lblPM1cBills
        // 
        this.lblPM1cBills.BackColor = System.Drawing.Color.Transparent;
        this.lblPM1cBills.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblPM1cBills.Location = new System.Drawing.Point(325, 18);
        this.lblPM1cBills.Name = "lblPM1cBills";
        this.lblPM1cBills.Size = new System.Drawing.Size(104, 29);
        this.lblPM1cBills.TabIndex = 16;
        this.lblPM1cBills.Text = "------";
        this.lblPM1cBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblPM1Kills
        // 
        this.lblPM1Kills.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblPM1Kills.Location = new System.Drawing.Point(106, 18);
        this.lblPM1Kills.Name = "lblPM1Kills";
        this.lblPM1Kills.Size = new System.Drawing.Size(41, 29);
        this.lblPM1Kills.TabIndex = 11;
        this.lblPM1Kills.Text = "--";
        this.lblPM1Kills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pbPM1Win
        // 
        this.pbPM1Win.Location = new System.Drawing.Point(9, 22);
        this.pbPM1Win.Name = "pbPM1Win";
        this.pbPM1Win.Size = new System.Drawing.Size(20, 20);
        this.pbPM1Win.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pbPM1Win.TabIndex = 7;
        this.pbPM1Win.TabStop = false;
        // 
        // label8
        // 
        this.label8.AutoSize = true;
        this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label8.Location = new System.Drawing.Point(358, 10);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(29, 9);
        this.label8.TabIndex = 15;
        this.label8.Text = "C-Bills";
        // 
        // pbPM1Live
        // 
        this.pbPM1Live.Location = new System.Drawing.Point(60, 22);
        this.pbPM1Live.Name = "pbPM1Live";
        this.pbPM1Live.Size = new System.Drawing.Size(20, 20);
        this.pbPM1Live.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pbPM1Live.TabIndex = 8;
        this.pbPM1Live.TabStop = false;
        // 
        // label10
        // 
        this.label10.AutoSize = true;
        this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label10.Location = new System.Drawing.Point(117, 10);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(20, 9);
        this.label10.TabIndex = 6;
        this.label10.Text = "Kills";
        // 
        // lblPM1Exp
        // 
        this.lblPM1Exp.BackColor = System.Drawing.Color.Transparent;
        this.lblPM1Exp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblPM1Exp.Location = new System.Drawing.Point(228, 18);
        this.lblPM1Exp.Name = "lblPM1Exp";
        this.lblPM1Exp.Size = new System.Drawing.Size(90, 29);
        this.lblPM1Exp.TabIndex = 14;
        this.lblPM1Exp.Text = "----";
        this.lblPM1Exp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label12
        // 
        this.label12.AutoSize = true;
        this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label12.Location = new System.Drawing.Point(171, 10);
        this.label12.Name = "label12";
        this.label12.Size = new System.Drawing.Size(41, 9);
        this.label12.TabIndex = 10;
        this.label12.Text = "Dammage";
        // 
        // label13
        // 
        this.label13.AutoSize = true;
        this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label13.Location = new System.Drawing.Point(57, 10);
        this.label13.Name = "label13";
        this.label13.Size = new System.Drawing.Size(27, 9);
        this.label13.TabIndex = 4;
        this.label13.Text = "Lived?";
        // 
        // label14
        // 
        this.label14.AutoSize = true;
        this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label14.Location = new System.Drawing.Point(260, 10);
        this.label14.Name = "label14";
        this.label14.Size = new System.Drawing.Size(20, 9);
        this.label14.TabIndex = 13;
        this.label14.Text = "EXP";
        // 
        // label15
        // 
        this.label15.AutoSize = true;
        this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label15.Location = new System.Drawing.Point(11, 10);
        this.label15.Name = "label15";
        this.label15.Size = new System.Drawing.Size(23, 9);
        this.label15.TabIndex = 2;
        this.label15.Text = "Win?";
        // 
        // lblPM1Damage
        // 
        this.lblPM1Damage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblPM1Damage.Location = new System.Drawing.Point(158, 18);
        this.lblPM1Damage.Name = "lblPM1Damage";
        this.lblPM1Damage.Size = new System.Drawing.Size(71, 29);
        this.lblPM1Damage.TabIndex = 12;
        this.lblPM1Damage.Text = "---";
        this.lblPM1Damage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pnlStats
        // 
        this.pnlStats.Controls.Add(this.lblCBills);
        this.pnlStats.Controls.Add(this.lblKills);
        this.pnlStats.Controls.Add(this.pbWin);
        this.pnlStats.Controls.Add(this.Label9);
        this.pnlStats.Controls.Add(this.pbLived);
        this.pnlStats.Controls.Add(this.Label3);
        this.pnlStats.Controls.Add(this.lblExp);
        this.pnlStats.Controls.Add(this.Label4);
        this.pnlStats.Controls.Add(this.Label2);
        this.pnlStats.Controls.Add(this.Label7);
        this.pnlStats.Controls.Add(this.Label1);
        this.pnlStats.Controls.Add(this.lblDamage);
        this.pnlStats.HighlightedBackColor = System.Drawing.Color.Empty;
        this.pnlStats.Location = new System.Drawing.Point(3, 13);
        this.pnlStats.Margin = new System.Windows.Forms.Padding(0);
        this.pnlStats.Name = "pnlStats";
        this.pnlStats.Size = new System.Drawing.Size(567, 79);
        this.pnlStats.TabIndex = 0;
        // 
        // lblCBills
        // 
        this.lblCBills.BackColor = System.Drawing.Color.Transparent;
        this.lblCBills.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblCBills.Location = new System.Drawing.Point(331, 32);
        this.lblCBills.Name = "lblCBills";
        this.lblCBills.Size = new System.Drawing.Size(104, 29);
        this.lblCBills.TabIndex = 16;
        this.lblCBills.Text = "------";
        this.lblCBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblKills
        // 
        this.lblKills.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblKills.Location = new System.Drawing.Point(106, 32);
        this.lblKills.Name = "lblKills";
        this.lblKills.Size = new System.Drawing.Size(41, 29);
        this.lblKills.TabIndex = 11;
        this.lblKills.Text = "--";
        this.lblKills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pbWin
        // 
        this.pbWin.Location = new System.Drawing.Point(9, 34);
        this.pbWin.Name = "pbWin";
        this.pbWin.Size = new System.Drawing.Size(30, 30);
        this.pbWin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pbWin.TabIndex = 7;
        this.pbWin.TabStop = false;
        // 
        // Label9
        // 
        this.Label9.AutoSize = true;
        this.Label9.Location = new System.Drawing.Point(364, 10);
        this.Label9.Name = "Label9";
        this.Label9.Size = new System.Drawing.Size(35, 13);
        this.Label9.TabIndex = 15;
        this.Label9.Text = "C-Bills";
        // 
        // pbLived
        // 
        this.pbLived.Location = new System.Drawing.Point(60, 34);
        this.pbLived.Name = "pbLived";
        this.pbLived.Size = new System.Drawing.Size(30, 30);
        this.pbLived.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.pbLived.TabIndex = 8;
        this.pbLived.TabStop = false;
        // 
        // Label3
        // 
        this.Label3.AutoSize = true;
        this.Label3.Location = new System.Drawing.Point(114, 10);
        this.Label3.Name = "Label3";
        this.Label3.Size = new System.Drawing.Size(25, 13);
        this.Label3.TabIndex = 6;
        this.Label3.Text = "Kills";
        // 
        // lblExp
        // 
        this.lblExp.BackColor = System.Drawing.Color.Transparent;
        this.lblExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblExp.Location = new System.Drawing.Point(230, 32);
        this.lblExp.Name = "lblExp";
        this.lblExp.Size = new System.Drawing.Size(90, 29);
        this.lblExp.TabIndex = 14;
        this.lblExp.Text = "----";
        this.lblExp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Label4
        // 
        this.Label4.AutoSize = true;
        this.Label4.Location = new System.Drawing.Point(165, 10);
        this.Label4.Name = "Label4";
        this.Label4.Size = new System.Drawing.Size(55, 13);
        this.Label4.TabIndex = 10;
        this.Label4.Text = "Dammage";
        // 
        // Label2
        // 
        this.Label2.AutoSize = true;
        this.Label2.Location = new System.Drawing.Point(57, 10);
        this.Label2.Name = "Label2";
        this.Label2.Size = new System.Drawing.Size(39, 13);
        this.Label2.TabIndex = 4;
        this.Label2.Text = "Lived?";
        // 
        // Label7
        // 
        this.Label7.AutoSize = true;
        this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label7.Location = new System.Drawing.Point(260, 10);
        this.Label7.Name = "Label7";
        this.Label7.Size = new System.Drawing.Size(28, 13);
        this.Label7.TabIndex = 13;
        this.Label7.Text = "EXP";
        // 
        // Label1
        // 
        this.Label1.AutoSize = true;
        this.Label1.Location = new System.Drawing.Point(11, 10);
        this.Label1.Name = "Label1";
        this.Label1.Size = new System.Drawing.Size(32, 13);
        this.Label1.TabIndex = 2;
        this.Label1.Text = "Win?";
        // 
        // lblDamage
        // 
        this.lblDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
        this.lblDamage.Location = new System.Drawing.Point(158, 32);
        this.lblDamage.Name = "lblDamage";
        this.lblDamage.Size = new System.Drawing.Size(71, 29);
        this.lblDamage.TabIndex = 12;
        this.lblDamage.Text = "---";
        this.lblDamage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // clMechMatch
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Transparent;
        this.Controls.Add(this.gbPM4);
        this.Controls.Add(this.gbPM3);
        this.Controls.Add(this.gbPm2);
        this.Controls.Add(this.gbPM1);
        this.Controls.Add(this.gbLastMatch);
        this.Controls.Add(this.pbMech);
        this.Controls.Add(this.pnlHeader);
        this.Name = "clMechMatch";
        this.Size = new System.Drawing.Size(689, 452);
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pbMech)).EndInit();
        this.gbLastMatch.ResumeLayout(false);
        this.gbPM1.ResumeLayout(false);
        this.gbPm2.ResumeLayout(false);
        this.gbPM3.ResumeLayout(false);
        this.gbPM4.ResumeLayout(false);
        this.ucRoundedPanel4.ResumeLayout(false);
        this.ucRoundedPanel4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pbPM4Win)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pbPM4Live)).EndInit();
        this.ucRoundedPanel3.ResumeLayout(false);
        this.ucRoundedPanel3.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pbPM3Win)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pbPM3Live)).EndInit();
        this.ucRoundedPanel2.ResumeLayout(false);
        this.ucRoundedPanel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pbPM2Win)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pbPM2Live)).EndInit();
        this.ucRoundedPanel1.ResumeLayout(false);
        this.ucRoundedPanel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pbPM1Win)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pbPM1Live)).EndInit();
        this.pnlStats.ResumeLayout(false);
        this.pnlStats.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pbWin)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pbLived)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    /// <summary>
    /// Fired when the control is Expanded or Collapsed.
    /// </summary>
    public event EventHandler Expand;

    #region " Properties "

    private bool m_bActive = false;
    public bool Active
    {
        get { return m_bActive; }
        set { m_bActive = value; }
    }

    private string _Caption;
    /// <summary>
    /// The text shown as the caption of the <see cref="clMechMatch" />.
    /// </summary>
    //[Browsable(true)]
    public string Caption
    {
        get { return _Caption; }
        set
        {
            _Caption = value;
            this.lblCaption.Text = value;
        }
    }

    private Color _BorderColor = Color.FromArgb(214, 213, 217);
    /// <summary>
    /// The color of the custom-drawn rounded border.
    /// </summary>
    //[DefaultValue(typeof(Color), "214, 213, 217")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set { _BorderColor = value; }
    }

    private bool _Expanded;
    /// <summary>
    /// True when the control is expanded.
    /// </summary>
    //[DefaultValue(true)]
    public bool Expanded
    {
        get { return _Expanded; }
        set
        {
            _Expanded = value;

            //Make sure we set the size correctly
            this.OnExpand();
        }
    }

    private Color _CaptionColor = Color.FromArgb(51, 94, 169);
    /// <summary>
    /// The ForeColor of the text shown as the caption of the <see cref="clMechMatch" />.
    /// </summary>
    //[DefaultValue(typeof(Color), "51, 94, 168")]
    public Color CaptionColor
    {
        get { return _CaptionColor; }
        set
        {
            _CaptionColor = value;

            this.lblCaption.ForeColor = _CaptionColor;
        }
    }

    private Size _ExpandedSize = new Size(200, 100);
    /// <summary>
    /// The Size of the <see cref="clMechMatch" /> when expanded. Should be set by resizing the control in the designer as usual.
    /// </summary>
    //[Browsable(false), DefaultValue(typeof(Size), "200, 100")]
    public Size ExpandedSize
    {
        get { return _ExpandedSize; }
        set { _ExpandedSize = value; }
    }

    private int _CollapsedMinSize = 130;
    /// <summary>
    /// The minimum size to collapse too, useful if you want to force some portion of the control to remain open even when collapsed
    /// </summary>
    //[DefaultValue(0)]
    public int CollapsedMinSize
    {
        get { return _CollapsedMinSize; }
        set { _CollapsedMinSize = value < pnlHeader.Height ? pnlHeader.Height : value; }
    }

    private bool _HeaderClickExpand = true;
    /// <summary>
    /// If True, expands / collapses the control when the header (caption) is clicked, instead of using the button only.
    /// </summary>
    //[DefaultValue(false)]
    public bool HeaderClickExpand
    {
        get { return _HeaderClickExpand; }
        set { _HeaderClickExpand = value; }
    }

    public Image MechImage
    {
        get { return pbMech.Image; }
        set { pbMech.Image = value; }
    }

    private int _MechId = -1;
    public int MechId
    {
        get { return _MechId; }
        set { _MechId = value; }
    }

    public bool Win
    {
        set
        {
            if (value)
            {
                pbWin.Image = _imgYes;
            }
            else
            {
                pbWin.Image = _imgNo;
            }
        }
    }

    public bool Lived
    {
        set
        {
            if (value)
            {
                pbLived.Image = _imgYes;
            }
            else
            {
                pbLived.Image = _imgNo;
            }
        }
    }

    public int Kills
    {
        set { lblKills.Text = value.ToString(); }
    }

    public string Damage
    {
        set
        {
                lblDamage.Text = string.Format("{0:#,###}", value);
        }
    }

    public int Exp
    {
        set { lblExp.Text = string.Format("{0:#,###}", value); }
    }
    
    public int cBills
    {
        set { lblCBills.Text = string.Format("{0:###,###}", value); }
    }

    private string m_strMechName = "";
    public string MechName
    {
        get { return m_strMechName; }
        set { m_strMechName = value; }
    }

    private string m_strMechDesignation = "";
    public string MechDesignation
    {
        get { return m_strMechDesignation; }
        set { m_strMechDesignation = value; }
    }

    private Image _imgYes;
    public Image YesImage
    {
        get { return _imgYes; }
        set { _imgYes = value; }
    }

    private Image _imgNo;
    public Image NoImage
    {
        get { return _imgNo; }
        set { _imgNo = value; }
    }

    #endregion

    #region " Constructor "
    public clMechMatch(int iMechId, string strNameFromDb, int iExpandedWidth, ref MWO_DB Db)
    {
        Paint += pnlContainer_Paint;
        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call.
        this.BorderColor = Color.FromArgb(214, 213, 217);
        this.Expanded = false;
        this.CaptionColor = Color.FromArgb(51, 94, 168);
        this.HeaderClickExpand = true;
        this.Dock = System.Windows.Forms.DockStyle.Top;

        // custom seeding for this class, as opposed to the basic expandable group box stuff..
        this.MechId = iMechId;
        vParseName(strNameFromDb); // seeds name and designation, do this before trying to use them!
        this.Caption = this.MechName + " - " + this.MechDesignation;
        this.ExpandedSize = new Size(iExpandedWidth, 445);
        this.m_myDB = Db;
        this.Size = new Size(200, 100);

        //this.lblCaption.Text = this.Caption;
        //this.lblCaption.ForeColor = this.CaptionColor;
    }
    #endregion

    #region " Methods "

    /// <summary>
    /// Changes the Size property of the control when it is expanded/collapsed.
    /// </summary>
    /// <remarks></remarks>
    public virtual void OnExpand()
    {
        if (this.Expanded)
        {
            this.Size = this.ExpandedSize;

            // if we haven't yet built their 5 match list, go do that..
            if (_lstMatchHistory == null)
                vGetHistory();
        }
        else
        {
            this.Size = new Size(pnlHeader.Width, _CollapsedMinSize);
        }
    }

    public void ClearHighlight()
    {
        pnlStats.HighlightedBackColor = Color.Transparent;
        Invalidate();
    }

    public void SetHighlight()
    {
        pnlStats.HighlightedBackColor = Color.BlueViolet;
        Invalidate();
    }

    /// <summary>
    /// Cleans up names for display only, they are tracked in the database just as they come
    /// off the webpage scrapes
    /// </summary>
    /// <param name="strName">Name as it came from the scrape and appears in the database</param>
    private void vParseName(string strName)
    {
        bool bFoundKit = strName.ToLower().Contains("kit fox");
        bool bFoundDire = strName.ToLower().Contains("dire wolf");

        // handle mechs with a space in the name itself differently than the rest
        if ( bFoundDire || bFoundKit )
        {
            if (bFoundKit)
            {
                MechName = strName.Substring(0, 7).Trim();
                MechDesignation = strName.Substring(8).Trim();
            }

            if (bFoundDire)
            {
                MechName = strName.Substring(0, 9).Trim();
                MechDesignation = strName.Substring(10).Trim();
            }
        }
        else
        {
            MechName = strName.Substring(0, strName.IndexOf(' ')).Trim();
            MechDesignation = strName.Substring(strName.IndexOf(' ') + 1).Trim();
        }

        // for display purposes, we want to remove the ( and ) from our designations so the
        // images can be found.
        if (MechDesignation.ToLower().Contains("prime"))
        {
            MechDesignation = MechDesignation.Replace("(", "").Replace(")", "").Trim();
        }
    }

    // called the first time they expand a mech. We'll get the last 5 matches
    // and fill the 4 'previous' match panels..
    private void vGetHistory()
    {
        clSingleMatch clMatch;

        SqlCeResultSet rs;

        rs = m_myDB.ResultSet("select top(5) matchid from match where mech = " + MechId + " order by matchid desc");

        _lstMatchHistory = new List<clSingleMatch>();

        while (rs.Read())
        {
            clMatch = new clSingleMatch();
            clMatch.LoadMatch(ref m_myDB, (int)(rs.GetValue(0)));
            _lstMatchHistory.Add(clMatch);

        } // end while we have match IDs to process

        vAdjustHistory(1);
        vAdjustHistory(2);
        vAdjustHistory(3);
        vAdjustHistory(4);

    } // end of vGetHistory()

    private void vAdjustHistory(int iLoc)
    {
        // sanity checking.. if we're asking for an update that's not in our list, just bail..
        if ((iLoc < 1) || (iLoc > _lstMatchHistory.Count - 1))
            return;

        clSingleMatch clMatch = _lstMatchHistory[iLoc];

        switch (iLoc)
        {
            case 0:
                break;
            case 1:
                // now we need to fill the "previous" panel..
                this.pbPM1Win.Image = clMatch.cWinLoss.ToString() == "W" ? _imgYes : _imgNo;
                this.pbPM1Live.Image = clMatch.bDeath ? _imgNo : _imgYes;
                this.lblPM1Kills.Text = clMatch.iKills.ToString();
                this.lblPM1Damage.Text = string.Format("{0:#,###}",clMatch.iDamage);
                this.lblPM1Exp.Text = string.Format("{0:#,###}", clMatch.iExp);
                this.lblPM1cBills.Text = string.Format("{0:###,###}", clMatch.iCBills);
                break;
            case 2:
                // now we need to fill the "previous" panel..
                this.pbPM2Win.Image = clMatch.cWinLoss.ToString() == "W" ? _imgYes : _imgNo;
                this.pbPM2Live.Image = clMatch.bDeath ? _imgNo : _imgYes;
                this.lblPM2Kills.Text = clMatch.iKills.ToString();
                this.lblPM2Damage.Text = string.Format("{0:#,###}", clMatch.iDamage);
                this.lblPM2Exp.Text = string.Format("{0:#,###}", clMatch.iExp);
                this.lblPM2cBills.Text = string.Format("{0:###,###}", clMatch.iCBills);
                break;
            case 3:
                // now we need to fill the "previous" panel..
                this.pbPM3Win.Image = clMatch.cWinLoss.ToString() == "W" ? _imgYes : _imgNo;
                this.pbPM3Live.Image = clMatch.bDeath ? _imgNo : _imgYes;
                this.lblPM3Kills.Text = clMatch.iKills.ToString();
                this.lblPM3Damage.Text = string.Format("{0:#,###}", clMatch.iDamage);
                this.lblPM3Exp.Text = string.Format("{0:#,###}", clMatch.iExp);
                this.lblPM3cBills.Text = string.Format("{0:###,###}", clMatch.iCBills);
                break;
            case 4:
                // now we need to fill the "previous" panel..
                this.pbPM4Win.Image = clMatch.cWinLoss.ToString() == "W" ? _imgYes : _imgNo;
                this.pbPM4Live.Image = clMatch.bDeath ? _imgNo : _imgYes;
                this.lblPM4Kills.Text = clMatch.iKills.ToString();
                this.lblPM4Damage.Text = string.Format("{0:#,###}", clMatch.iDamage);
                this.lblPM4Exp.Text = string.Format("{0:#,###}", clMatch.iExp);
                this.lblPM4cBills.Text = string.Format("{0:###,###}", clMatch.iCBills);
                break;
        } // end switch

    } // end updating the match history panels..

    /// <summary>
    /// Used to update our match tracking stuff. We will put the provided match into the main match
    /// slot, then update all the other previous match panels.
    /// </summary>
    /// <param name="clMatch"></param>
    public void LastMatch(ref clSingleMatch clMatch)
    {
        LoadMainMatch(ref clMatch);

        // if this was our first scrape, we'll end up reading everything in for all 5 matches. It's
        // one more read of a match, but it keeps it cleaner for maint going forward..
        if (_lstMatchHistory == null)
        {
            vGetHistory();
        }
        else
        {
            _lstMatchHistory.Insert(0, clMatch); // put it up front

            // So, we should have had 5 items in our list, and we just added one. Now we'll
            // remove from the back of the list until we only have 5 items left.
            while (_lstMatchHistory.Count > 5)
            {
                _lstMatchHistory.RemoveAt(_lstMatchHistory.Count - 1);
            }

            vAdjustHistory(1);
            vAdjustHistory(2);
            vAdjustHistory(3);
            vAdjustHistory(4);
        }
    }

    /// <summary>
    /// Used to initialize the class with a match. This will clear out our internal list and get us
    /// ready for updating per match going forward..
    /// </summary>
    /// <param name="clMatch">
    /// Single Match class that contains the information about the match we should use to seed with
    /// </param>
    public void SeedMatch(ref clSingleMatch clMatch)
    {
        LoadMainMatch(ref clMatch);
    }

    private void LoadMainMatch(ref clSingleMatch clMatch)
    {
        this.Win = clMatch.cWinLoss == 'W' ? true : false;
        this.Lived = !clMatch.bDeath;
        this.Kills = clMatch.iKills;
        this.Damage = clMatch.iDamage.ToString();
        this.Exp = clMatch.iExp;
        this.cBills = clMatch.iCBills;
    }
    #endregion

    #region " Events "

    private void ExpandButton_Click(System.Object sender, System.EventArgs e)
    {

        //Toggle the expansion
        this.Expanded = !this.Expanded;

        //Repaint the button
        ExpandButton.Invalidate();

        //Repaint the header
        pnlHeader.Invalidate();

        if (Expand != null)
        {
            Expand(this, EventArgs.Empty);
        }

    }

    //Makes sure we can't drag the control out when it is collapsed
    protected override void OnResize(System.EventArgs e)
    {
        base.OnResize(e);

        if (this.Expanded)
        {
            this.ExpandedSize = this.Size;
        }
        else
        {
            if (this.DesignMode)
            {
                this.Size = pnlHeader.Size;
                this.ExpandedSize = new Size(this.Size.Width, this.ExpandedSize.Height);
            }
        }

        gbLastMatch.Width = (this.Size.Width - gbLastMatch.Location.X - 8);
        pnlStats.Width = gbLastMatch.Width - this.Location.X - 8;

    }

    private void pnlHeader_Click(System.Object sender, System.EventArgs e)
    {
        if (this.HeaderClickExpand)
            ExpandButton.PerformClick();
    }

    private void lblCaption_Click(System.Object sender, System.EventArgs e)
    {
        if (this.HeaderClickExpand)
            ExpandButton.PerformClick();
    }

    #endregion

    #region " Drawing "

    private void pnlHeader_Paint(object sender, PaintEventArgs e)
    {
        Pen borderPen;
        if (this.Active)
            borderPen = new Pen(Color.Firebrick, 1);
        else
            borderPen = new Pen(this.BorderColor, 1);


        if (this.Expanded)
        {
            //Right of button/text
            e.Graphics.DrawLine(borderPen, this.lblCaption.Left + this.lblCaption.Width + 10, 11, this.Width - 4, 11);

            e.Graphics.DrawLine(borderPen, this.Width - 4, 12, this.Width - 3, 12);
            e.Graphics.DrawLine(borderPen, this.Width - 3, 13, this.Width - 2, 13);
            e.Graphics.DrawLine(borderPen, this.Width - 2, 14, this.Width - 2, this.Height);

            //Left of button
            e.Graphics.DrawLine(borderPen, 4, 11, 7, 11);

            e.Graphics.DrawLine(borderPen, 3, 12, 4, 12);
            e.Graphics.DrawLine(borderPen, 3, 13, 2, 13);
            e.Graphics.DrawLine(borderPen, 2, 14, 2, this.Height);
        }
        else
        {
            e.Graphics.DrawLine(borderPen, this.lblCaption.Left + this.lblCaption.Width + 10, 11, this.Width - 4, 11);
            e.Graphics.DrawLine(borderPen, this.Width - 4, 12, this.Width - 3, 12);
            e.Graphics.DrawLine(borderPen, this.Width - 3, 13, this.Width - 2, 13);

            e.Graphics.DrawLine(borderPen, 4, 11, 7, 11);
            e.Graphics.DrawLine(borderPen, 3, 12, 4, 12);
            e.Graphics.DrawLine(borderPen, 2, 13, 3, 13);
        }


        borderPen.Dispose();

    }

    private void pnlContainer_Paint(System.Object sender, System.Windows.Forms.PaintEventArgs e)
    {
        Pen borderPen;
        if (this.Active)
            borderPen = new Pen(Color.Firebrick, 1);
        else
            borderPen = new Pen(this.BorderColor, 1);

        e.Graphics.DrawLine(borderPen, 2, 13, 2, this.Height - 4);

        // right side vertical line
        e.Graphics.DrawLine(borderPen, this.Width - 2, 13, this.Width - 2, this.Height - 4);

        // bottom middle line, pre bend
        e.Graphics.DrawLine(borderPen, 4, this.Height - 1, this.Width - 4, this.Height - 1);

        // bottom left corner connection
        e.Graphics.DrawLine(borderPen, 3, this.Height - 2, 4, this.Height - 2);
        e.Graphics.DrawLine(borderPen, 2, this.Height - 3, 3, this.Height - 3);

        // bottom right corner
        e.Graphics.DrawLine(borderPen, this.Width - 4, this.Height - 2, this.Width - 3, this.Height - 2);
        e.Graphics.DrawLine(borderPen, this.Width - 3, this.Height - 3, this.Width - 2, this.Height - 3);


        borderPen.Dispose();

    }

    private void ExpandButton_Paint(System.Object sender, System.Windows.Forms.PaintEventArgs e)
    {
        e.Graphics.DrawLine(Pens.Black, 5, ExpandButton.Height / 2, ExpandButton.Width - 6, ExpandButton.Height / 2);
        if (!this.Expanded)
        {
            e.Graphics.DrawLine(Pens.Black, ExpandButton.Width / 2, 5, ExpandButton.Width / 2, ExpandButton.Height - 6);
        }
    }

    #endregion

}

/// <summary>
/// Designer class that enables the user to expand/collapse the <see cref="clMechMatch" /> control during Design-Time.
/// </summary>
/// <remarks></remarks>
//public class ExpandableGroupboxDesigner : ParentControlDesigner
//{

//    public override void Initialize(System.ComponentModel.IComponent component)
//    {
//        base.Initialize(component);

//        //Add an event handler for the button click event so we can update the control
//        Button btnExpand = ((clMechMatch)this.Control).ExpandButton;
//        btnExpand.Click += ExpandButtonClicked;
//    }

//    public void ExpandButtonClicked(object sender, EventArgs ev)
//    {
//        //Tell the designer to update the control
//        //If we don't do this, the selection rectangle would not update
//        this.RaiseComponentChanged(TypeDescriptor.GetProperties(this.Control)["Size"], null, null);
//    }

//    //This function enables us to click the button during design-time
//    protected override bool GetHitTest(System.Drawing.Point point)
//    {
//        Button btnExpand = ((clMechMatch)this.Control).ExpandButton;
//        if ((btnExpand.Bounds.Contains(this.Control.PointToClient(point))))
//        {
//            return true;
//        }
//        return base.GetHitTest(point);
//    }

//}

//=======================================================
//
// This code was originally ExpandableGroupBox in VB, I moved it
// directly into my project and converted it to CS so I didn't
// have to keep it as a separate project in the solution..
//
// note: it messed up the event handler hookups, I had to fix them
// by hand.. but most of the code converted very well, saved me a
// LOT of work..
//
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
