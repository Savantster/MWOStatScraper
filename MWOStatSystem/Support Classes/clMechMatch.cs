
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms.Design;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using MWOStatSystem.Support_Classes;

[Designer(typeof(ExpandableGroupboxDesigner))]
public class clMechMatch : System.Windows.Forms.UserControl
{

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
    internal GroupBox groupBox1;
    internal ucRoundedPanel ucRoundedPanel1;
    internal Label label5;
    internal Label label6;
    internal PictureBox pictureBox1;
    internal Label label8;
    internal PictureBox pictureBox2;
    internal Label label10;
    internal Label label11;
    internal Label label12;
    internal Label label13;
    internal Label label14;
    internal Label label15;
    internal Label label16;
    internal GroupBox groupBox2;
    internal ucRoundedPanel ucRoundedPanel2;
    internal Label label17;
    internal Label label18;
    internal PictureBox pictureBox3;
    internal Label label19;
    internal PictureBox pictureBox4;
    internal Label label20;
    internal Label label21;
    internal Label label22;
    internal Label label23;
    internal Label label24;
    internal Label label25;
    internal Label label26;
    internal GroupBox groupBox3;
    internal ucRoundedPanel ucRoundedPanel3;
    internal Label label27;
    internal Label label28;
    internal PictureBox pictureBox5;
    internal Label label29;
    internal PictureBox pictureBox6;
    internal Label label30;
    internal Label label31;
    internal Label label32;
    internal Label label33;
    internal Label label34;
    internal Label label35;
    internal Label label36;
    internal GroupBox groupBox4;
    internal ucRoundedPanel ucRoundedPanel4;
    internal Label label37;
    internal Label label38;
    internal PictureBox pictureBox7;
    internal Label label39;
    internal PictureBox pictureBox8;
    internal Label label40;
    internal Label label41;
    internal Label label42;
    internal Label label43;
    internal Label label44;
    internal Label label45;
    internal Label label46;
    
    //Required by the Windows Form Designer

    private System.ComponentModel.IContainer components;
    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.
    [System.Diagnostics.DebuggerStepThrough()]
    private void InitializeComponent()
    {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.ExpandButton = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            this.pbMech = new System.Windows.Forms.PictureBox();
            this.gbLastMatch = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ucRoundedPanel4 = new MWOStatSystem.Support_Classes.ucRoundedPanel();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label39 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.ucRoundedPanel3 = new MWOStatSystem.Support_Classes.ucRoundedPanel();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label29 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.ucRoundedPanel2 = new MWOStatSystem.Support_Classes.ucRoundedPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.ucRoundedPanel1 = new MWOStatSystem.Support_Classes.ucRoundedPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.ucRoundedPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.ucRoundedPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.ucRoundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.ucRoundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.gbLastMatch.Size = new System.Drawing.Size(469, 95);
            this.gbLastMatch.TabIndex = 4;
            this.gbLastMatch.TabStop = false;
            this.gbLastMatch.Text = "Last Match Details";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.ucRoundedPanel1);
            this.groupBox1.Location = new System.Drawing.Point(157, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 70);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Last Match Details";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.ucRoundedPanel2);
            this.groupBox2.Location = new System.Drawing.Point(157, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(469, 70);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Last Match Details";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.ucRoundedPanel3);
            this.groupBox3.Location = new System.Drawing.Point(157, 285);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(469, 70);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Last Match Details";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.ucRoundedPanel4);
            this.groupBox4.Location = new System.Drawing.Point(157, 361);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(469, 70);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Last Match Details";
            // 
            // ucRoundedPanel4
            // 
            this.ucRoundedPanel4.Controls.Add(this.label37);
            this.ucRoundedPanel4.Controls.Add(this.label38);
            this.ucRoundedPanel4.Controls.Add(this.pictureBox7);
            this.ucRoundedPanel4.Controls.Add(this.label39);
            this.ucRoundedPanel4.Controls.Add(this.pictureBox8);
            this.ucRoundedPanel4.Controls.Add(this.label40);
            this.ucRoundedPanel4.Controls.Add(this.label41);
            this.ucRoundedPanel4.Controls.Add(this.label42);
            this.ucRoundedPanel4.Controls.Add(this.label43);
            this.ucRoundedPanel4.Controls.Add(this.label44);
            this.ucRoundedPanel4.Controls.Add(this.label45);
            this.ucRoundedPanel4.Controls.Add(this.label46);
            this.ucRoundedPanel4.HighlightedBackColor = System.Drawing.Color.Empty;
            this.ucRoundedPanel4.Location = new System.Drawing.Point(3, 13);
            this.ucRoundedPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.ucRoundedPanel4.Name = "ucRoundedPanel4";
            this.ucRoundedPanel4.Size = new System.Drawing.Size(460, 55);
            this.ucRoundedPanel4.TabIndex = 0;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(331, 18);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(104, 29);
            this.label37.TabIndex = 16;
            this.label37.Text = "125,000";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(106, 18);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(41, 29);
            this.label38.TabIndex = 11;
            this.label38.Text = "12";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(9, 22);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(20, 20);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 7;
            this.pictureBox7.TabStop = false;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(364, 10);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(29, 9);
            this.label39.TabIndex = 15;
            this.label39.Text = "C-Bills";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Location = new System.Drawing.Point(60, 22);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(20, 20);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 8;
            this.pictureBox8.TabStop = false;
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
            // label41
            // 
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(228, 18);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(90, 29);
            this.label41.TabIndex = 14;
            this.label41.Text = "1,500";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(158, 18);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(71, 29);
            this.label46.TabIndex = 12;
            this.label46.Text = "333";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucRoundedPanel3
            // 
            this.ucRoundedPanel3.Controls.Add(this.label27);
            this.ucRoundedPanel3.Controls.Add(this.label28);
            this.ucRoundedPanel3.Controls.Add(this.pictureBox5);
            this.ucRoundedPanel3.Controls.Add(this.label29);
            this.ucRoundedPanel3.Controls.Add(this.pictureBox6);
            this.ucRoundedPanel3.Controls.Add(this.label30);
            this.ucRoundedPanel3.Controls.Add(this.label31);
            this.ucRoundedPanel3.Controls.Add(this.label32);
            this.ucRoundedPanel3.Controls.Add(this.label33);
            this.ucRoundedPanel3.Controls.Add(this.label34);
            this.ucRoundedPanel3.Controls.Add(this.label35);
            this.ucRoundedPanel3.Controls.Add(this.label36);
            this.ucRoundedPanel3.HighlightedBackColor = System.Drawing.Color.Empty;
            this.ucRoundedPanel3.Location = new System.Drawing.Point(3, 13);
            this.ucRoundedPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.ucRoundedPanel3.Name = "ucRoundedPanel3";
            this.ucRoundedPanel3.Size = new System.Drawing.Size(460, 55);
            this.ucRoundedPanel3.TabIndex = 0;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(331, 18);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(104, 29);
            this.label27.TabIndex = 16;
            this.label27.Text = "125,000";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(106, 18);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 29);
            this.label28.TabIndex = 11;
            this.label28.Text = "12";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(9, 22);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 20);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(364, 10);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 9);
            this.label29.TabIndex = 15;
            this.label29.Text = "C-Bills";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(60, 22);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(20, 20);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 8;
            this.pictureBox6.TabStop = false;
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
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(228, 18);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(90, 29);
            this.label31.TabIndex = 14;
            this.label31.Text = "1,500";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(158, 18);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(71, 29);
            this.label36.TabIndex = 12;
            this.label36.Text = "333";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucRoundedPanel2
            // 
            this.ucRoundedPanel2.Controls.Add(this.label17);
            this.ucRoundedPanel2.Controls.Add(this.label18);
            this.ucRoundedPanel2.Controls.Add(this.pictureBox3);
            this.ucRoundedPanel2.Controls.Add(this.label19);
            this.ucRoundedPanel2.Controls.Add(this.pictureBox4);
            this.ucRoundedPanel2.Controls.Add(this.label20);
            this.ucRoundedPanel2.Controls.Add(this.label21);
            this.ucRoundedPanel2.Controls.Add(this.label22);
            this.ucRoundedPanel2.Controls.Add(this.label23);
            this.ucRoundedPanel2.Controls.Add(this.label24);
            this.ucRoundedPanel2.Controls.Add(this.label25);
            this.ucRoundedPanel2.Controls.Add(this.label26);
            this.ucRoundedPanel2.HighlightedBackColor = System.Drawing.Color.Empty;
            this.ucRoundedPanel2.Location = new System.Drawing.Point(3, 13);
            this.ucRoundedPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.ucRoundedPanel2.Name = "ucRoundedPanel2";
            this.ucRoundedPanel2.Size = new System.Drawing.Size(460, 55);
            this.ucRoundedPanel2.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(331, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 29);
            this.label17.TabIndex = 16;
            this.label17.Text = "125,000";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(106, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 29);
            this.label18.TabIndex = 11;
            this.label18.Text = "12";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(9, 22);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(364, 10);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 9);
            this.label19.TabIndex = 15;
            this.label19.Text = "C-Bills";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(60, 22);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 20);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
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
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(228, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(90, 29);
            this.label21.TabIndex = 14;
            this.label21.Text = "1,500";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(158, 18);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(71, 29);
            this.label26.TabIndex = 12;
            this.label26.Text = "333";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucRoundedPanel1
            // 
            this.ucRoundedPanel1.Controls.Add(this.label5);
            this.ucRoundedPanel1.Controls.Add(this.label6);
            this.ucRoundedPanel1.Controls.Add(this.pictureBox1);
            this.ucRoundedPanel1.Controls.Add(this.label8);
            this.ucRoundedPanel1.Controls.Add(this.pictureBox2);
            this.ucRoundedPanel1.Controls.Add(this.label10);
            this.ucRoundedPanel1.Controls.Add(this.label11);
            this.ucRoundedPanel1.Controls.Add(this.label12);
            this.ucRoundedPanel1.Controls.Add(this.label13);
            this.ucRoundedPanel1.Controls.Add(this.label14);
            this.ucRoundedPanel1.Controls.Add(this.label15);
            this.ucRoundedPanel1.Controls.Add(this.label16);
            this.ucRoundedPanel1.HighlightedBackColor = System.Drawing.Color.Empty;
            this.ucRoundedPanel1.Location = new System.Drawing.Point(3, 13);
            this.ucRoundedPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.ucRoundedPanel1.Name = "ucRoundedPanel1";
            this.ucRoundedPanel1.Size = new System.Drawing.Size(460, 55);
            this.ucRoundedPanel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(331, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 29);
            this.label5.TabIndex = 16;
            this.label5.Text = "125,000";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(106, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "12";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(364, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 9);
            this.label8.TabIndex = 15;
            this.label8.Text = "C-Bills";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(60, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
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
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(228, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 29);
            this.label11.TabIndex = 14;
            this.label11.Text = "1,500";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(158, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 29);
            this.label16.TabIndex = 12;
            this.label16.Text = "333";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.pnlStats.Size = new System.Drawing.Size(460, 79);
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
            this.lblCBills.Text = "125,000";
            this.lblCBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKills
            // 
            this.lblKills.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblKills.Location = new System.Drawing.Point(106, 32);
            this.lblKills.Name = "lblKills";
            this.lblKills.Size = new System.Drawing.Size(41, 29);
            this.lblKills.TabIndex = 11;
            this.lblKills.Text = "12";
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
            this.lblExp.Text = "1,500";
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
            this.lblDamage.Text = "333";
            this.lblDamage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clMechMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbLastMatch);
            this.Controls.Add(this.pbMech);
            this.Controls.Add(this.pnlHeader);
            this.Name = "clMechMatch";
            this.Size = new System.Drawing.Size(689, 452);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMech)).EndInit();
            this.gbLastMatch.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ucRoundedPanel4.ResumeLayout(false);
            this.ucRoundedPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ucRoundedPanel3.ResumeLayout(false);
            this.ucRoundedPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ucRoundedPanel2.ResumeLayout(false);
            this.ucRoundedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ucRoundedPanel1.ResumeLayout(false);
            this.ucRoundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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

    private string _Caption;
    /// <summary>
    /// The text shown as the caption of the <see cref="clMechMatch" />.
    /// </summary>
    [Browsable(true)]
    public string Caption
    {
        get { return _Caption; }
        set
        {
            _Caption = value;
            this.lblCaption.Text = value;
        }
    }

    private Color _BorderColor;
    /// <summary>
    /// The color of the custom-drawn rounded border.
    /// </summary>
    [DefaultValue(typeof(Color), "214, 213, 217")]
    public Color BorderColor
    {
        get { return _BorderColor; }
        set { _BorderColor = value; }
    }

    private bool _Expanded;
    /// <summary>
    /// True when the control is expanded.
    /// </summary>
    [DefaultValue(true)]
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

    private Color _CaptionColor;
    /// <summary>
    /// The ForeColor of the text shown as the caption of the <see cref="clMechMatch" />.
    /// </summary>
    [DefaultValue(typeof(Color), "51, 94, 168")]
    public Color CaptionColor
    {
        get { return _CaptionColor; }
        set
        {
            _CaptionColor = value;

            this.lblCaption.ForeColor = value;
        }
    }

    private Size _ExpandedSize;
    /// <summary>
    /// The Size of the <see cref="clMechMatch" /> when expanded. Should be set by resizing the control in the designer as usual.
    /// </summary>
    [Browsable(false), DefaultValue(typeof(Size), "200, 100")]
    public Size ExpandedSize
    {
        get { return _ExpandedSize; }
        set { _ExpandedSize = value; }
    }

    private int _CollapsedMinSize;
    /// <summary>
    /// The minimum size to collapse too, useful if you want to force some portion of the control to remain open even when collapsed
    /// </summary>
    [DefaultValue(0)]
    public int CollapsedMinSize
    {
        get { return _CollapsedMinSize; }
        set { _CollapsedMinSize = value < pnlHeader.Height ? pnlHeader.Height : value; }
    }

    private bool _HeaderClickExpand;
    /// <summary>
    /// If True, expands / collapses the control when the header (caption) is clicked, instead of using the button only.
    /// </summary>
    [DefaultValue(false)]
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

    public Image Win
    {
        set { pbWin.Image = value; }
    }

    public Image Lived
    {
        set { pbLived.Image = value; }
    }

    public int Kills
    {
        set { lblKills.Text = value.ToString(); }
    }

    public string Damage
    {
        set
        {
            if (value.Contains("."))
            {
                lblDamage.Text = string.Format("{0:#,###.##}", value);
            }
            else
            {
                lblDamage.Text = string.Format("{0:#,###}", value);
            }
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
    #endregion

    public clMechMatch()
    {
        Paint += pnlContainer_Paint;
        // This call is required by the Windows Form Designer.
        InitializeComponent();

        // Add any initialization after the InitializeComponent() call.
        this.BorderColor = Color.FromArgb(214, 213, 217);
        this.Expanded = false;
        this.CaptionColor = Color.FromArgb(51, 94, 168);
        this.HeaderClickExpand = true;

        this.Size = new Size(200, 100);

        this.lblCaption.Text = this.Caption;
        this.lblCaption.ForeColor = this.CaptionColor;
    }

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
        }
        else
        {
            this.Size = new Size(pnlHeader.Width, _CollapsedMinSize);
        }
    }

    public void ClearHighlight()
    {
        pnlStats.BackColor = Color.Transparent;
        Invalidate();
    }

    public void SetHighlight()
    {
        pnlStats.HighlightedBackColor = Color.BlueViolet;
        Invalidate();
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

        gbLastMatch.Width = (this.Size.Width - gbLastMatch.Location.X);
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
        using (Pen borderPen = new Pen(this.BorderColor, 1))
        {
            //Right of button/text
            //e.Graphics.DrawLine(borderPen, Me.lblCaption.Left + Me.lblCaption.Width + 10, 11, Me.Width - 4, 11)
            if (this.Expanded)
            {
                e.Graphics.DrawLine(borderPen, this.Width - 4, 12, this.Width - 3, 12);
                e.Graphics.DrawLine(borderPen, this.Width - 3, 13, this.Width - 2, 13);
                e.Graphics.DrawLine(borderPen, this.Width - 2, 14, this.Width - 2, this.Height);
            }

            //Left of button
            //e.Graphics.DrawLine(borderPen, 4, 11, 7, 11)
            if (this.Expanded)
            {
                e.Graphics.DrawLine(borderPen, 3, 12, 4, 12);
                e.Graphics.DrawLine(borderPen, 2, 13, 3, 13);
                e.Graphics.DrawLine(borderPen, 2, 14, 2, this.Height);
            }
        }
    }

    private void pnlContainer_Paint(System.Object sender, System.Windows.Forms.PaintEventArgs e)
    {
        using (Pen borderPen = new Pen(this.BorderColor, 1))
        {

            e.Graphics.DrawLine(borderPen, 2, 0, 2, this.Height - 4);
            e.Graphics.DrawLine(borderPen, this.Width - 2, 0, this.Width - 2, this.Height - 4);

            e.Graphics.DrawLine(borderPen, 4, this.Height - 1, this.Width - 4, this.Height - 1);

            e.Graphics.DrawLine(borderPen, 3, this.Height - 2, 4, this.Height - 2);
            e.Graphics.DrawLine(borderPen, 2, this.Height - 3, 3, this.Height - 3);

            e.Graphics.DrawLine(borderPen, this.Width - 4, this.Height - 2, this.Width - 3, this.Height - 2);
            e.Graphics.DrawLine(borderPen, this.Width - 3, this.Height - 3, this.Width - 2, this.Height - 3);
        }
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
public class ExpandableGroupboxDesigner : ParentControlDesigner
{

    public override void Initialize(System.ComponentModel.IComponent component)
    {
        base.Initialize(component);

        //Add an event handler for the button click event so we can update the control
        Button btnExpand = ((clMechMatch)this.Control).ExpandButton;
        btnExpand.Click += ExpandButtonClicked;
    }

    public void ExpandButtonClicked(object sender, EventArgs ev)
    {
        //Tell the designer to update the control
        //If we don't do this, the selection rectangle would not update
        this.RaiseComponentChanged(TypeDescriptor.GetProperties(this.Control)["Size"], null, null);
    }

    //This function enables us to click the button during design-time
    protected override bool GetHitTest(System.Drawing.Point point)
    {
        Button btnExpand = ((clMechMatch)this.Control).ExpandButton;
        if ((btnExpand.Bounds.Contains(this.Control.PointToClient(point))))
        {
            return true;
        }
        return base.GetHitTest(point);
    }

}

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
