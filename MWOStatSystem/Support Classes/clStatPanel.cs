using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWOStatSystem.Support_Classes
{


    class clStatPanel : System.Windows.Forms.UserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        internal System.Windows.Forms.GroupBox gbStatPanel;
        internal ucRoundedPanel pnlRoundStatHighlight;
        internal System.Windows.Forms.Label lblCBills;
        internal System.Windows.Forms.Label lblKills;
        internal System.Windows.Forms.PictureBox pbWin;
        internal System.Windows.Forms.Label lblCBillsHeader;
        internal System.Windows.Forms.PictureBox pbLived;
        internal System.Windows.Forms.Label lblKillHeader;
        internal System.Windows.Forms.Label lblExp;
        internal System.Windows.Forms.Label lblDamageHeader;
        internal System.Windows.Forms.Label lblLived;
        internal System.Windows.Forms.Label lblExpHeader;
        internal System.Windows.Forms.Label lblWin;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblModeHeader;
        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblMapHeader;
        private System.Windows.Forms.Label lblMisses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHits;
        private System.Windows.Forms.Label lblHitsHeader;
        internal System.Windows.Forms.Label lblDamage;
    
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.gbStatPanel = new System.Windows.Forms.GroupBox();
            this.pnlRoundStatHighlight = new MWOStatSystem.Support_Classes.ucRoundedPanel();
            this.lblMisses = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHits = new System.Windows.Forms.Label();
            this.lblHitsHeader = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblModeHeader = new System.Windows.Forms.Label();
            this.lblMap = new System.Windows.Forms.Label();
            this.lblMapHeader = new System.Windows.Forms.Label();
            this.lblCBills = new System.Windows.Forms.Label();
            this.lblKills = new System.Windows.Forms.Label();
            this.pbWin = new System.Windows.Forms.PictureBox();
            this.lblCBillsHeader = new System.Windows.Forms.Label();
            this.pbLived = new System.Windows.Forms.PictureBox();
            this.lblKillHeader = new System.Windows.Forms.Label();
            this.lblExp = new System.Windows.Forms.Label();
            this.lblDamageHeader = new System.Windows.Forms.Label();
            this.lblLived = new System.Windows.Forms.Label();
            this.lblExpHeader = new System.Windows.Forms.Label();
            this.lblWin = new System.Windows.Forms.Label();
            this.lblDamage = new System.Windows.Forms.Label();
            this.gbStatPanel.SuspendLayout();
            this.pnlRoundStatHighlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLived)).BeginInit();
            this.SuspendLayout();
            // 
            // gbStatPanel
            // 
            this.gbStatPanel.BackColor = System.Drawing.Color.Transparent;
            this.gbStatPanel.Controls.Add(this.pnlRoundStatHighlight);
            this.gbStatPanel.Location = new System.Drawing.Point(3, 3);
            this.gbStatPanel.Name = "gbStatPanel";
            this.gbStatPanel.Size = new System.Drawing.Size(820, 94);
            this.gbStatPanel.TabIndex = 5;
            this.gbStatPanel.TabStop = false;
            this.gbStatPanel.Text = "Match Details";
            // 
            // pnlRoundStatHighlight
            // 
            this.pnlRoundStatHighlight.Controls.Add(this.lblMisses);
            this.pnlRoundStatHighlight.Controls.Add(this.label1);
            this.pnlRoundStatHighlight.Controls.Add(this.lblHits);
            this.pnlRoundStatHighlight.Controls.Add(this.lblHitsHeader);
            this.pnlRoundStatHighlight.Controls.Add(this.lblMode);
            this.pnlRoundStatHighlight.Controls.Add(this.lblModeHeader);
            this.pnlRoundStatHighlight.Controls.Add(this.lblMap);
            this.pnlRoundStatHighlight.Controls.Add(this.lblMapHeader);
            this.pnlRoundStatHighlight.Controls.Add(this.lblCBills);
            this.pnlRoundStatHighlight.Controls.Add(this.lblKills);
            this.pnlRoundStatHighlight.Controls.Add(this.pbWin);
            this.pnlRoundStatHighlight.Controls.Add(this.lblCBillsHeader);
            this.pnlRoundStatHighlight.Controls.Add(this.pbLived);
            this.pnlRoundStatHighlight.Controls.Add(this.lblKillHeader);
            this.pnlRoundStatHighlight.Controls.Add(this.lblExp);
            this.pnlRoundStatHighlight.Controls.Add(this.lblDamageHeader);
            this.pnlRoundStatHighlight.Controls.Add(this.lblLived);
            this.pnlRoundStatHighlight.Controls.Add(this.lblExpHeader);
            this.pnlRoundStatHighlight.Controls.Add(this.lblWin);
            this.pnlRoundStatHighlight.Controls.Add(this.lblDamage);
            this.pnlRoundStatHighlight.HighlightedBackColor = System.Drawing.Color.Empty;
            this.pnlRoundStatHighlight.Location = new System.Drawing.Point(3, 13);
            this.pnlRoundStatHighlight.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRoundStatHighlight.Name = "pnlRoundStatHighlight";
            this.pnlRoundStatHighlight.Size = new System.Drawing.Size(814, 78);
            this.pnlRoundStatHighlight.TabIndex = 0;
            // 
            // lblMisses
            // 
            this.lblMisses.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblMisses.Location = new System.Drawing.Point(303, 32);
            this.lblMisses.Name = "lblMisses";
            this.lblMisses.Size = new System.Drawing.Size(53, 29);
            this.lblMisses.TabIndex = 24;
            this.lblMisses.Text = "-----";
            this.lblMisses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Misses";
            // 
            // lblHits
            // 
            this.lblHits.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblHits.Location = new System.Drawing.Point(239, 32);
            this.lblHits.Name = "lblHits";
            this.lblHits.Size = new System.Drawing.Size(45, 29);
            this.lblHits.TabIndex = 22;
            this.lblHits.Text = "-----";
            this.lblHits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHitsHeader
            // 
            this.lblHitsHeader.AutoSize = true;
            this.lblHitsHeader.Location = new System.Drawing.Point(248, 10);
            this.lblHitsHeader.Name = "lblHitsHeader";
            this.lblHitsHeader.Size = new System.Drawing.Size(25, 13);
            this.lblHitsHeader.TabIndex = 21;
            this.lblHitsHeader.Text = "Hits";
            // 
            // lblMode
            // 
            this.lblMode.Location = new System.Drawing.Point(702, 34);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(91, 23);
            this.lblMode.TabIndex = 20;
            this.lblMode.Text = "---";
            this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblModeHeader
            // 
            this.lblModeHeader.AutoSize = true;
            this.lblModeHeader.Location = new System.Drawing.Point(730, 10);
            this.lblModeHeader.Name = "lblModeHeader";
            this.lblModeHeader.Size = new System.Drawing.Size(34, 13);
            this.lblModeHeader.TabIndex = 19;
            this.lblModeHeader.Text = "Mode";
            // 
            // lblMap
            // 
            this.lblMap.Location = new System.Drawing.Point(583, 34);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(100, 23);
            this.lblMap.TabIndex = 18;
            this.lblMap.Text = "---";
            this.lblMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMapHeader
            // 
            this.lblMapHeader.AutoSize = true;
            this.lblMapHeader.Location = new System.Drawing.Point(620, 10);
            this.lblMapHeader.Name = "lblMapHeader";
            this.lblMapHeader.Size = new System.Drawing.Size(28, 13);
            this.lblMapHeader.TabIndex = 17;
            this.lblMapHeader.Text = "Map";
            // 
            // lblCBills
            // 
            this.lblCBills.BackColor = System.Drawing.Color.Transparent;
            this.lblCBills.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblCBills.Location = new System.Drawing.Point(466, 32);
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
            // lblCBillsHeader
            // 
            this.lblCBillsHeader.AutoSize = true;
            this.lblCBillsHeader.Location = new System.Drawing.Point(499, 10);
            this.lblCBillsHeader.Name = "lblCBillsHeader";
            this.lblCBillsHeader.Size = new System.Drawing.Size(35, 13);
            this.lblCBillsHeader.TabIndex = 15;
            this.lblCBillsHeader.Text = "C-Bills";
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
            // lblKillHeader
            // 
            this.lblKillHeader.AutoSize = true;
            this.lblKillHeader.Location = new System.Drawing.Point(114, 10);
            this.lblKillHeader.Name = "lblKillHeader";
            this.lblKillHeader.Size = new System.Drawing.Size(25, 13);
            this.lblKillHeader.TabIndex = 6;
            this.lblKillHeader.Text = "Kills";
            // 
            // lblExp
            // 
            this.lblExp.BackColor = System.Drawing.Color.Transparent;
            this.lblExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblExp.Location = new System.Drawing.Point(364, 32);
            this.lblExp.Name = "lblExp";
            this.lblExp.Size = new System.Drawing.Size(90, 29);
            this.lblExp.TabIndex = 14;
            this.lblExp.Text = "----";
            this.lblExp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDamageHeader
            // 
            this.lblDamageHeader.AutoSize = true;
            this.lblDamageHeader.Location = new System.Drawing.Point(165, 10);
            this.lblDamageHeader.Name = "lblDamageHeader";
            this.lblDamageHeader.Size = new System.Drawing.Size(55, 13);
            this.lblDamageHeader.TabIndex = 10;
            this.lblDamageHeader.Text = "Dammage";
            // 
            // lblLived
            // 
            this.lblLived.AutoSize = true;
            this.lblLived.Location = new System.Drawing.Point(57, 10);
            this.lblLived.Name = "lblLived";
            this.lblLived.Size = new System.Drawing.Size(39, 13);
            this.lblLived.TabIndex = 4;
            this.lblLived.Text = "Lived?";
            // 
            // lblExpHeader
            // 
            this.lblExpHeader.AutoSize = true;
            this.lblExpHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpHeader.Location = new System.Drawing.Point(394, 10);
            this.lblExpHeader.Name = "lblExpHeader";
            this.lblExpHeader.Size = new System.Drawing.Size(28, 13);
            this.lblExpHeader.TabIndex = 13;
            this.lblExpHeader.Text = "EXP";
            // 
            // lblWin
            // 
            this.lblWin.AutoSize = true;
            this.lblWin.Location = new System.Drawing.Point(11, 10);
            this.lblWin.Name = "lblWin";
            this.lblWin.Size = new System.Drawing.Size(32, 13);
            this.lblWin.TabIndex = 2;
            this.lblWin.Text = "Win?";
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
            // clStatPanel
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gbStatPanel);
            this.Name = "clStatPanel";
            this.Size = new System.Drawing.Size(825, 102);
            this.gbStatPanel.ResumeLayout(false);
            this.pnlRoundStatHighlight.ResumeLayout(false);
            this.pnlRoundStatHighlight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLived)).EndInit();
            this.ResumeLayout(false);

        }


        public clStatPanel()
        {
            InitializeComponent();
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

        public bool Win
        {
            set
            {
                if (value)
                {
                    pbWin.Image = _imgYes;
                    pnlRoundStatHighlight.HighlightedBackColor = Color.PaleGreen;
                }
                else
                {
                    pbWin.Image = _imgNo;
                    pnlRoundStatHighlight.HighlightedBackColor = Color.PaleVioletRed;
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

        public string Map
        {
            set { this.lblMap.Text = value; }
        }

        public string Mode
        {
            set { lblMode.Text = value; }
        }

        public int Hits
        {
            set { lblHits.Text = string.Format("{0:#,###}", value); }
        }

        public int Misses
        {
            set { lblMisses.Text = string.Format("{0:#,###}", value); }
        }

        public DateTime Date
        {
            set { gbStatPanel.Text = "Match played on: " + string.Format("{0:ddd, MMM d, yyyy - h:m tt}", value); }
        }

    }
}
