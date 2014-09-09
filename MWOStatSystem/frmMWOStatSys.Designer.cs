namespace MWOStatSystem
{
    partial class frmMWOStatSys
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel2 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMWOStatSys));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSetLogin = new System.Windows.Forms.Button();
            this.btnScrapeIt = new System.Windows.Forms.Button();
            this.dgMechs = new System.Windows.Forms.DataGridView();
            this.btnTest = new System.Windows.Forms.Button();
            this.dgWeapons = new System.Windows.Forms.DataGridView();
            this.dgMaps = new System.Windows.Forms.DataGridView();
            this.dgModes = new System.Windows.Forms.DataGridView();
            this.btnShowError = new System.Windows.Forms.Button();
            this.btnCheckLogin = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.pbNextScrape = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAutoScrape = new System.Windows.Forms.CheckBox();
            this.tcCharts = new System.Windows.Forms.TabControl();
            this.tabMechInfo = new System.Windows.Forms.TabPage();
            this.tabAccuracy = new System.Windows.Forms.TabPage();
            this.chtAccuracy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabEffective = new System.Windows.Forms.TabPage();
            this.chtEffective = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabExpAndCbills = new System.Windows.Forms.TabPage();
            this.chtExpCbills = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabFullHistory = new System.Windows.Forms.TabPage();
            this.olvMatchHistory = new BrightIdeasSoftware.ObjectListView();
            this.olvColWin = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColLived = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColKills = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCoDamage = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvCoHits = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColMisses = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColExp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColCBills = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColMap = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColMode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pnlMechSelect = new System.Windows.Forms.Panel();
            this.lblLosses = new System.Windows.Forms.Label();
            this.lblLossesHeader = new System.Windows.Forms.Label();
            this.lblCBills = new System.Windows.Forms.Label();
            this.lblCBillsHeader = new System.Windows.Forms.Label();
            this.lblDeaths = new System.Windows.Forms.Label();
            this.lblDeathsHeader = new System.Windows.Forms.Label();
            this.lblMatchCount = new System.Windows.Forms.Label();
            this.lblKills = new System.Windows.Forms.Label();
            this.lblWins = new System.Windows.Forms.Label();
            this.lblMatchCountHeader = new System.Windows.Forms.Label();
            this.lblKillsHeader = new System.Windows.Forms.Label();
            this.lblWinsHeader = new System.Windows.Forms.Label();
            this.lblMechSelection = new System.Windows.Forms.Label();
            this.cbMechList = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuLogLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLog1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLog2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLog3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLog4 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileLoggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScrapesToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.hideWeaponsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMG = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLRM = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAM = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTAG = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNARC = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClearBaseTables = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTestWithFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.nmbMatches = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cbZoom = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbNARC = new System.Windows.Forms.CheckBox();
            this.cbTAG = new System.Windows.Forms.CheckBox();
            this.cbAM = new System.Windows.Forms.CheckBox();
            this.cbLRM = new System.Windows.Forms.CheckBox();
            this.cbMG = new System.Windows.Forms.CheckBox();
            this.nmbScrapeFreq = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnTryLogon = new System.Windows.Forms.Button();
            this.lblCurrentMech = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgMechs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgWeapons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMaps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgModes)).BeginInit();
            this.tcCharts.SuspendLayout();
            this.tabAccuracy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtAccuracy)).BeginInit();
            this.tabEffective.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtEffective)).BeginInit();
            this.tabExpAndCbills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtExpCbills)).BeginInit();
            this.tabFullHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvMatchHistory)).BeginInit();
            this.pnlMechSelect.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmbMatches)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmbScrapeFreq)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(108, 665);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(209, 43);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Make Login Request";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSetLogin
            // 
            this.btnSetLogin.Location = new System.Drawing.Point(550, 2);
            this.btnSetLogin.Name = "btnSetLogin";
            this.btnSetLogin.Size = new System.Drawing.Size(126, 23);
            this.btnSetLogin.TabIndex = 2;
            this.btnSetLogin.Text = "Login Info";
            this.toolTip1.SetToolTip(this.btnSetLogin, "Brings up the credential entry screen.");
            this.btnSetLogin.UseVisualStyleBackColor = true;
            this.btnSetLogin.Click += new System.EventHandler(this.btnSetLogin_Click);
            // 
            // btnScrapeIt
            // 
            this.btnScrapeIt.Location = new System.Drawing.Point(12, 40);
            this.btnScrapeIt.Name = "btnScrapeIt";
            this.btnScrapeIt.Size = new System.Drawing.Size(166, 43);
            this.btnScrapeIt.TabIndex = 3;
            this.btnScrapeIt.Text = "Scrape MWO Stats";
            this.toolTip1.SetToolTip(this.btnScrapeIt, "Logs in to the website and scrapes stats from your profile page.");
            this.btnScrapeIt.UseVisualStyleBackColor = true;
            this.btnScrapeIt.Click += new System.EventHandler(this.btnScrapeIt_Click);
            // 
            // dgMechs
            // 
            this.dgMechs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMechs.Location = new System.Drawing.Point(54, 604);
            this.dgMechs.Name = "dgMechs";
            this.dgMechs.Size = new System.Drawing.Size(48, 49);
            this.dgMechs.TabIndex = 4;
            this.dgMechs.Visible = false;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(323, 665);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(171, 46);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "Test With Files";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // dgWeapons
            // 
            this.dgWeapons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWeapons.Location = new System.Drawing.Point(54, 659);
            this.dgWeapons.Name = "dgWeapons";
            this.dgWeapons.Size = new System.Drawing.Size(48, 49);
            this.dgWeapons.TabIndex = 7;
            this.dgWeapons.Visible = false;
            // 
            // dgMaps
            // 
            this.dgMaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMaps.Location = new System.Drawing.Point(0, 604);
            this.dgMaps.Name = "dgMaps";
            this.dgMaps.Size = new System.Drawing.Size(48, 49);
            this.dgMaps.TabIndex = 8;
            this.dgMaps.Visible = false;
            // 
            // dgModes
            // 
            this.dgModes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgModes.Location = new System.Drawing.Point(0, 659);
            this.dgModes.Name = "dgModes";
            this.dgModes.Size = new System.Drawing.Size(48, 49);
            this.dgModes.TabIndex = 9;
            this.dgModes.Visible = false;
            // 
            // btnShowError
            // 
            this.btnShowError.Location = new System.Drawing.Point(682, 2);
            this.btnShowError.Name = "btnShowError";
            this.btnShowError.Size = new System.Drawing.Size(126, 23);
            this.btnShowError.TabIndex = 10;
            this.btnShowError.Text = "Show Log Window";
            this.toolTip1.SetToolTip(this.btnShowError, "Shows the logging window so you can see the log contents if not being scraped to " +
        "file.");
            this.btnShowError.UseVisualStyleBackColor = true;
            this.btnShowError.Click += new System.EventHandler(this.btnShowError_Click);
            // 
            // btnCheckLogin
            // 
            this.btnCheckLogin.Location = new System.Drawing.Point(814, 1);
            this.btnCheckLogin.Name = "btnCheckLogin";
            this.btnCheckLogin.Size = new System.Drawing.Size(146, 23);
            this.btnCheckLogin.TabIndex = 11;
            this.btnCheckLogin.Text = "Check Login Credentials";
            this.toolTip1.SetToolTip(this.btnCheckLogin, "Shows the login info that will be used during scrape requests..");
            this.btnCheckLogin.UseVisualStyleBackColor = true;
            this.btnCheckLogin.Click += new System.EventHandler(this.btnCheckLogin_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(287, 636);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "clear tables";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pbNextScrape
            // 
            this.pbNextScrape.Location = new System.Drawing.Point(223, 79);
            this.pbNextScrape.Maximum = 300;
            this.pbNextScrape.Name = "pbNextScrape";
            this.pbNextScrape.Size = new System.Drawing.Size(149, 23);
            this.pbNextScrape.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Next Scrape Indicator";
            // 
            // cbAutoScrape
            // 
            this.cbAutoScrape.AutoSize = true;
            this.cbAutoScrape.Location = new System.Drawing.Point(223, 37);
            this.cbAutoScrape.Name = "cbAutoScrape";
            this.cbAutoScrape.Size = new System.Drawing.Size(85, 17);
            this.cbAutoScrape.TabIndex = 15;
            this.cbAutoScrape.Text = "Auto Scrape";
            this.toolTip1.SetToolTip(this.cbAutoScrape, "If checked, the program will automatically scrape for stats at the interval (in m" +
        "inutes) given in the Frequency selector.");
            this.cbAutoScrape.UseVisualStyleBackColor = true;
            this.cbAutoScrape.CheckedChanged += new System.EventHandler(this.cbAutoScrape_CheckedChanged);
            // 
            // tcCharts
            // 
            this.tcCharts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcCharts.Controls.Add(this.tabMechInfo);
            this.tcCharts.Controls.Add(this.tabAccuracy);
            this.tcCharts.Controls.Add(this.tabEffective);
            this.tcCharts.Controls.Add(this.tabExpAndCbills);
            this.tcCharts.Controls.Add(this.tabFullHistory);
            this.tcCharts.Location = new System.Drawing.Point(4, 108);
            this.tcCharts.Name = "tcCharts";
            this.tcCharts.SelectedIndex = 0;
            this.tcCharts.Size = new System.Drawing.Size(939, 536);
            this.tcCharts.TabIndex = 16;
            this.tcCharts.SelectedIndexChanged += new System.EventHandler(this.tcCharts_SelectedIndexChanged);
            // 
            // tabMechInfo
            // 
            this.tabMechInfo.AutoScroll = true;
            this.tabMechInfo.Location = new System.Drawing.Point(4, 22);
            this.tabMechInfo.Name = "tabMechInfo";
            this.tabMechInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabMechInfo.Size = new System.Drawing.Size(931, 510);
            this.tabMechInfo.TabIndex = 3;
            this.tabMechInfo.Text = "Mech View";
            this.tabMechInfo.UseVisualStyleBackColor = true;
            // 
            // tabAccuracy
            // 
            this.tabAccuracy.Controls.Add(this.chtAccuracy);
            this.tabAccuracy.Location = new System.Drawing.Point(4, 22);
            this.tabAccuracy.Name = "tabAccuracy";
            this.tabAccuracy.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccuracy.Size = new System.Drawing.Size(931, 510);
            this.tabAccuracy.TabIndex = 0;
            this.tabAccuracy.Text = "Hits And Misses";
            this.tabAccuracy.UseVisualStyleBackColor = true;
            // 
            // chtAccuracy
            // 
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Inclination = 50;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.Area3DStyle.Rotation = 15;
            chartArea1.Area3DStyle.WallWidth = 3;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chtAccuracy.ChartAreas.Add(chartArea1);
            this.chtAccuracy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtAccuracy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            legend1.Name = "Legend1";
            this.chtAccuracy.Legends.Add(legend1);
            this.chtAccuracy.Location = new System.Drawing.Point(3, 3);
            this.chtAccuracy.Name = "chtAccuracy";
            this.chtAccuracy.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.Label = "#VAL";
            series1.Legend = "Legend1";
            series1.Name = "Hits";
            series1.XValueMember = "Weapon";
            series1.YValueMembers = "Hits";
            series2.ChartArea = "ChartArea1";
            series2.IsValueShownAsLabel = true;
            series2.Label = "#VAL";
            series2.Legend = "Legend1";
            series2.Name = "Misses";
            series2.YValueMembers = "Misses";
            this.chtAccuracy.Series.Add(series1);
            this.chtAccuracy.Series.Add(series2);
            this.chtAccuracy.Size = new System.Drawing.Size(925, 504);
            this.chtAccuracy.TabIndex = 0;
            this.chtAccuracy.Text = "Accuracy";
            // 
            // tabEffective
            // 
            this.tabEffective.Controls.Add(this.chtEffective);
            this.tabEffective.Location = new System.Drawing.Point(4, 22);
            this.tabEffective.Name = "tabEffective";
            this.tabEffective.Padding = new System.Windows.Forms.Padding(3);
            this.tabEffective.Size = new System.Drawing.Size(931, 510);
            this.tabEffective.TabIndex = 1;
            this.tabEffective.Text = "Effectiveness";
            this.tabEffective.UseVisualStyleBackColor = true;
            // 
            // chtEffective
            // 
            chartArea2.Area3DStyle.Enable3D = true;
            chartArea2.Area3DStyle.Inclination = 50;
            chartArea2.Area3DStyle.IsRightAngleAxes = false;
            chartArea2.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea2.Area3DStyle.Rotation = 15;
            chartArea2.Area3DStyle.WallWidth = 3;
            chartArea2.Name = "ChartArea1";
            this.chtEffective.ChartAreas.Add(chartArea2);
            this.chtEffective.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chtEffective.Legends.Add(legend2);
            this.chtEffective.Location = new System.Drawing.Point(3, 3);
            this.chtEffective.Name = "chtEffective";
            this.chtEffective.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series3.ChartArea = "ChartArea1";
            series3.IsValueShownAsLabel = true;
            series3.Label = "#VAL";
            series3.Legend = "Legend1";
            series3.Name = "Theoretical";
            series4.ChartArea = "ChartArea1";
            series4.IsValueShownAsLabel = true;
            series4.Label = "#VAL";
            series4.Legend = "Legend1";
            series4.Name = "MaxPossible";
            series4.XValueMember = "Weapon";
            series4.YValueMembers = "MaxDmg";
            series5.ChartArea = "ChartArea1";
            series5.IsValueShownAsLabel = true;
            series5.Label = "#VAL";
            series5.Legend = "Legend1";
            series5.Name = "YourDamage";
            series5.YValueMembers = "YourDamage";
            this.chtEffective.Series.Add(series3);
            this.chtEffective.Series.Add(series4);
            this.chtEffective.Series.Add(series5);
            this.chtEffective.Size = new System.Drawing.Size(925, 504);
            this.chtEffective.TabIndex = 2;
            this.chtEffective.Text = "Effectiveness";
            // 
            // tabExpAndCbills
            // 
            this.tabExpAndCbills.Controls.Add(this.chtExpCbills);
            this.tabExpAndCbills.Location = new System.Drawing.Point(4, 22);
            this.tabExpAndCbills.Name = "tabExpAndCbills";
            this.tabExpAndCbills.Padding = new System.Windows.Forms.Padding(3);
            this.tabExpAndCbills.Size = new System.Drawing.Size(931, 510);
            this.tabExpAndCbills.TabIndex = 2;
            this.tabExpAndCbills.Text = "Exp and cBills";
            this.tabExpAndCbills.UseVisualStyleBackColor = true;
            // 
            // chtExpCbills
            // 
            chartArea3.Area3DStyle.Enable3D = true;
            chartArea3.Area3DStyle.Inclination = 50;
            chartArea3.Area3DStyle.IsRightAngleAxes = false;
            chartArea3.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea3.Area3DStyle.Rotation = 15;
            chartArea3.Area3DStyle.WallWidth = 3;
            chartArea3.AxisX.CustomLabels.Add(customLabel1);
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX2.CustomLabels.Add(customLabel2);
            chartArea3.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX2.LineColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX2.MajorGrid.Enabled = false;
            chartArea3.Name = "ChartArea1";
            this.chtExpCbills.ChartAreas.Add(chartArea3);
            this.chtExpCbills.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chtExpCbills.Legends.Add(legend3);
            this.chtExpCbills.Location = new System.Drawing.Point(3, 3);
            this.chtExpCbills.Name = "chtExpCbills";
            this.chtExpCbills.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series6.ChartArea = "ChartArea1";
            series6.IsValueShownAsLabel = true;
            series6.Label = "#VAL";
            series6.Legend = "Legend1";
            series6.Name = "cBills";
            series7.ChartArea = "ChartArea1";
            series7.IsValueShownAsLabel = true;
            series7.Label = "#VAL";
            series7.Legend = "Legend1";
            series7.Name = "Exp";
            series8.ChartArea = "ChartArea1";
            series8.IsValueShownAsLabel = true;
            series8.Label = "#VAL";
            series8.Legend = "Legend1";
            series8.Name = "Damage";
            this.chtExpCbills.Series.Add(series6);
            this.chtExpCbills.Series.Add(series7);
            this.chtExpCbills.Series.Add(series8);
            this.chtExpCbills.Size = new System.Drawing.Size(925, 504);
            this.chtExpCbills.TabIndex = 0;
            this.chtExpCbills.Text = "chart1";
            // 
            // tabFullHistory
            // 
            this.tabFullHistory.AutoScroll = true;
            this.tabFullHistory.Controls.Add(this.olvMatchHistory);
            this.tabFullHistory.Controls.Add(this.pnlMechSelect);
            this.tabFullHistory.Location = new System.Drawing.Point(4, 22);
            this.tabFullHistory.Name = "tabFullHistory";
            this.tabFullHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabFullHistory.Size = new System.Drawing.Size(931, 510);
            this.tabFullHistory.TabIndex = 4;
            this.tabFullHistory.Text = "All Matches";
            this.toolTip1.SetToolTip(this.tabFullHistory, "Full match history for the Active Mech");
            this.tabFullHistory.UseVisualStyleBackColor = true;
            // 
            // olvMatchHistory
            // 
            this.olvMatchHistory.AllColumns.Add(this.olvColWin);
            this.olvMatchHistory.AllColumns.Add(this.olvColLived);
            this.olvMatchHistory.AllColumns.Add(this.olvColKills);
            this.olvMatchHistory.AllColumns.Add(this.olvCoDamage);
            this.olvMatchHistory.AllColumns.Add(this.olvCoHits);
            this.olvMatchHistory.AllColumns.Add(this.olvColMisses);
            this.olvMatchHistory.AllColumns.Add(this.olvColExp);
            this.olvMatchHistory.AllColumns.Add(this.olvColCBills);
            this.olvMatchHistory.AllColumns.Add(this.olvColMap);
            this.olvMatchHistory.AllColumns.Add(this.olvColMode);
            this.olvMatchHistory.AllColumns.Add(this.olvColDate);
            this.olvMatchHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColWin,
            this.olvColLived,
            this.olvColKills,
            this.olvCoDamage,
            this.olvCoHits,
            this.olvColMisses,
            this.olvColExp,
            this.olvColCBills,
            this.olvColMap,
            this.olvColMode,
            this.olvColDate});
            this.olvMatchHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.olvMatchHistory.EmptyListMsg = "No matches found?";
            this.olvMatchHistory.EmptyListMsgFont = new System.Drawing.Font("Monotype Corsiva", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvMatchHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvMatchHistory.GridLines = true;
            this.olvMatchHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.olvMatchHistory.Location = new System.Drawing.Point(3, 51);
            this.olvMatchHistory.MultiSelect = false;
            this.olvMatchHistory.Name = "olvMatchHistory";
            this.olvMatchHistory.SelectAllOnControlA = false;
            this.olvMatchHistory.SelectColumnsOnRightClick = false;
            this.olvMatchHistory.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.olvMatchHistory.ShowGroups = false;
            this.olvMatchHistory.ShowSortIndicators = false;
            this.olvMatchHistory.Size = new System.Drawing.Size(925, 456);
            this.olvMatchHistory.SortGroupItemsByPrimaryColumn = false;
            this.olvMatchHistory.TabIndex = 0;
            this.olvMatchHistory.UseCompatibleStateImageBehavior = false;
            this.olvMatchHistory.View = System.Windows.Forms.View.Details;
            // 
            // olvColWin
            // 
            this.olvColWin.AspectName = "bWin";
            this.olvColWin.CellPadding = null;
            this.olvColWin.Groupable = false;
            this.olvColWin.IsEditable = false;
            this.olvColWin.MinimumWidth = 40;
            this.olvColWin.Text = "Win";
            // 
            // olvColLived
            // 
            this.olvColLived.AspectName = "bDeath";
            this.olvColLived.CellPadding = null;
            this.olvColLived.Groupable = false;
            this.olvColLived.IsEditable = false;
            this.olvColLived.MinimumWidth = 40;
            this.olvColLived.Text = "Lived";
            // 
            // olvColKills
            // 
            this.olvColKills.AspectName = "iKills";
            this.olvColKills.CellPadding = null;
            this.olvColKills.Groupable = false;
            this.olvColKills.IsEditable = false;
            this.olvColKills.MinimumWidth = 40;
            this.olvColKills.Text = "Kills";
            // 
            // olvCoDamage
            // 
            this.olvCoDamage.AspectName = "iDamage";
            this.olvCoDamage.AspectToStringFormat = "{0:#,##0}";
            this.olvCoDamage.CellPadding = null;
            this.olvCoDamage.Groupable = false;
            this.olvCoDamage.IsEditable = false;
            this.olvCoDamage.MinimumWidth = 75;
            this.olvCoDamage.Text = "Damage";
            this.olvCoDamage.Width = 75;
            // 
            // olvCoHits
            // 
            this.olvCoHits.AspectName = "iHits";
            this.olvCoHits.AspectToStringFormat = "{0:#,##0}";
            this.olvCoHits.CellPadding = null;
            this.olvCoHits.Groupable = false;
            this.olvCoHits.IsEditable = false;
            this.olvCoHits.MinimumWidth = 60;
            this.olvCoHits.Text = "Hits";
            // 
            // olvColMisses
            // 
            this.olvColMisses.AspectName = "iMisses";
            this.olvColMisses.AspectToStringFormat = "{0:#,##0}";
            this.olvColMisses.CellPadding = null;
            this.olvColMisses.Groupable = false;
            this.olvColMisses.IsEditable = false;
            this.olvColMisses.MinimumWidth = 65;
            this.olvColMisses.Text = "Misses";
            this.olvColMisses.Width = 65;
            // 
            // olvColExp
            // 
            this.olvColExp.AspectName = "iExp";
            this.olvColExp.CellPadding = null;
            this.olvColExp.Groupable = false;
            this.olvColExp.IsEditable = false;
            this.olvColExp.MinimumWidth = 60;
            this.olvColExp.Text = "EXP";
            // 
            // olvColCBills
            // 
            this.olvColCBills.AspectName = "iCBills";
            this.olvColCBills.AspectToStringFormat = "{0:#,###}";
            this.olvColCBills.CellPadding = null;
            this.olvColCBills.Groupable = false;
            this.olvColCBills.IsEditable = false;
            this.olvColCBills.MinimumWidth = 60;
            this.olvColCBills.Text = "C-Bills";
            // 
            // olvColMap
            // 
            this.olvColMap.AspectName = "sMap";
            this.olvColMap.CellPadding = null;
            this.olvColMap.Groupable = false;
            this.olvColMap.IsEditable = false;
            this.olvColMap.MinimumWidth = 60;
            this.olvColMap.Text = "Map";
            // 
            // olvColMode
            // 
            this.olvColMode.AspectName = "sMode";
            this.olvColMode.CellPadding = null;
            this.olvColMode.Groupable = false;
            this.olvColMode.IsEditable = false;
            this.olvColMode.MinimumWidth = 60;
            this.olvColMode.Text = "Mode";
            // 
            // olvColDate
            // 
            this.olvColDate.AspectName = "dtDate";
            this.olvColDate.AspectToStringFormat = "{0:MM/dd/yyyy - h:mm tt}";
            this.olvColDate.CellPadding = null;
            this.olvColDate.FillsFreeSpace = true;
            this.olvColDate.Groupable = false;
            this.olvColDate.IsEditable = false;
            this.olvColDate.MinimumWidth = 150;
            this.olvColDate.Text = "Date Played";
            this.olvColDate.Width = 150;
            // 
            // pnlMechSelect
            // 
            this.pnlMechSelect.Controls.Add(this.lblLosses);
            this.pnlMechSelect.Controls.Add(this.lblLossesHeader);
            this.pnlMechSelect.Controls.Add(this.lblCBills);
            this.pnlMechSelect.Controls.Add(this.lblCBillsHeader);
            this.pnlMechSelect.Controls.Add(this.lblDeaths);
            this.pnlMechSelect.Controls.Add(this.lblDeathsHeader);
            this.pnlMechSelect.Controls.Add(this.lblMatchCount);
            this.pnlMechSelect.Controls.Add(this.lblKills);
            this.pnlMechSelect.Controls.Add(this.lblWins);
            this.pnlMechSelect.Controls.Add(this.lblMatchCountHeader);
            this.pnlMechSelect.Controls.Add(this.lblKillsHeader);
            this.pnlMechSelect.Controls.Add(this.lblWinsHeader);
            this.pnlMechSelect.Controls.Add(this.lblMechSelection);
            this.pnlMechSelect.Controls.Add(this.cbMechList);
            this.pnlMechSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMechSelect.Location = new System.Drawing.Point(3, 3);
            this.pnlMechSelect.Name = "pnlMechSelect";
            this.pnlMechSelect.Size = new System.Drawing.Size(925, 48);
            this.pnlMechSelect.TabIndex = 0;
            // 
            // lblLosses
            // 
            this.lblLosses.AutoSize = true;
            this.lblLosses.Location = new System.Drawing.Point(91, 28);
            this.lblLosses.Name = "lblLosses";
            this.lblLosses.Size = new System.Drawing.Size(19, 13);
            this.lblLosses.TabIndex = 13;
            this.lblLosses.Text = "----";
            // 
            // lblLossesHeader
            // 
            this.lblLossesHeader.AutoSize = true;
            this.lblLossesHeader.Location = new System.Drawing.Point(83, 8);
            this.lblLossesHeader.Name = "lblLossesHeader";
            this.lblLossesHeader.Size = new System.Drawing.Size(40, 13);
            this.lblLossesHeader.TabIndex = 12;
            this.lblLossesHeader.Text = "Losses";
            // 
            // lblCBills
            // 
            this.lblCBills.Location = new System.Drawing.Point(696, 28);
            this.lblCBills.Name = "lblCBills";
            this.lblCBills.Size = new System.Drawing.Size(75, 13);
            this.lblCBills.TabIndex = 11;
            this.lblCBills.Text = "------";
            this.lblCBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCBillsHeader
            // 
            this.lblCBillsHeader.AutoSize = true;
            this.lblCBillsHeader.Location = new System.Drawing.Point(716, 8);
            this.lblCBillsHeader.Name = "lblCBillsHeader";
            this.lblCBillsHeader.Size = new System.Drawing.Size(35, 13);
            this.lblCBillsHeader.TabIndex = 10;
            this.lblCBillsHeader.Text = "C-Bills";
            // 
            // lblDeaths
            // 
            this.lblDeaths.Location = new System.Drawing.Point(187, 28);
            this.lblDeaths.Name = "lblDeaths";
            this.lblDeaths.Size = new System.Drawing.Size(25, 13);
            this.lblDeaths.TabIndex = 9;
            this.lblDeaths.Text = "----";
            this.lblDeaths.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDeathsHeader
            // 
            this.lblDeathsHeader.AutoSize = true;
            this.lblDeathsHeader.Location = new System.Drawing.Point(180, 8);
            this.lblDeathsHeader.Name = "lblDeathsHeader";
            this.lblDeathsHeader.Size = new System.Drawing.Size(41, 13);
            this.lblDeathsHeader.TabIndex = 8;
            this.lblDeathsHeader.Text = "Deaths";
            // 
            // lblMatchCount
            // 
            this.lblMatchCount.Location = new System.Drawing.Point(608, 28);
            this.lblMatchCount.Name = "lblMatchCount";
            this.lblMatchCount.Size = new System.Drawing.Size(49, 13);
            this.lblMatchCount.TabIndex = 7;
            this.lblMatchCount.Text = "----";
            this.lblMatchCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKills
            // 
            this.lblKills.Location = new System.Drawing.Point(137, 28);
            this.lblKills.Name = "lblKills";
            this.lblKills.Size = new System.Drawing.Size(25, 13);
            this.lblKills.TabIndex = 6;
            this.lblKills.Text = "----";
            this.lblKills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWins
            // 
            this.lblWins.AutoSize = true;
            this.lblWins.Location = new System.Drawing.Point(48, 28);
            this.lblWins.Name = "lblWins";
            this.lblWins.Size = new System.Drawing.Size(19, 13);
            this.lblWins.TabIndex = 5;
            this.lblWins.Text = "----";
            // 
            // lblMatchCountHeader
            // 
            this.lblMatchCountHeader.AutoSize = true;
            this.lblMatchCountHeader.Location = new System.Drawing.Point(594, 8);
            this.lblMatchCountHeader.Name = "lblMatchCountHeader";
            this.lblMatchCountHeader.Size = new System.Drawing.Size(75, 13);
            this.lblMatchCountHeader.TabIndex = 4;
            this.lblMatchCountHeader.Text = "Total Matches";
            // 
            // lblKillsHeader
            // 
            this.lblKillsHeader.AutoSize = true;
            this.lblKillsHeader.Location = new System.Drawing.Point(138, 8);
            this.lblKillsHeader.Name = "lblKillsHeader";
            this.lblKillsHeader.Size = new System.Drawing.Size(25, 13);
            this.lblKillsHeader.TabIndex = 3;
            this.lblKillsHeader.Text = "Kills";
            // 
            // lblWinsHeader
            // 
            this.lblWinsHeader.AutoSize = true;
            this.lblWinsHeader.Location = new System.Drawing.Point(45, 8);
            this.lblWinsHeader.Name = "lblWinsHeader";
            this.lblWinsHeader.Size = new System.Drawing.Size(31, 13);
            this.lblWinsHeader.TabIndex = 2;
            this.lblWinsHeader.Text = "Wins";
            // 
            // lblMechSelection
            // 
            this.lblMechSelection.AutoSize = true;
            this.lblMechSelection.Location = new System.Drawing.Point(404, 8);
            this.lblMechSelection.Name = "lblMechSelection";
            this.lblMechSelection.Size = new System.Drawing.Size(81, 13);
            this.lblMechSelection.TabIndex = 1;
            this.lblMechSelection.Text = "Mech Selection";
            // 
            // cbMechList
            // 
            this.cbMechList.FormattingEnabled = true;
            this.cbMechList.Location = new System.Drawing.Point(336, 24);
            this.cbMechList.Name = "cbMechList";
            this.cbMechList.Size = new System.Drawing.Size(216, 21);
            this.cbMechList.TabIndex = 0;
            this.cbMechList.SelectedIndexChanged += new System.EventHandler(this.cbMechList_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogLevel,
            this.fileLoggingToolStripMenuItem,
            this.hideWeaponsToolStripMenuItem,
            this.utilitiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(4, 1);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(319, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuLogLevel
            // 
            this.mnuLogLevel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLog1,
            this.mnuLog2,
            this.mnuLog3,
            this.mnuLog4});
            this.mnuLogLevel.Name = "mnuLogLevel";
            this.mnuLogLevel.Size = new System.Drawing.Size(69, 20);
            this.mnuLogLevel.Text = "Log Level";
            // 
            // mnuLog1
            // 
            this.mnuLog1.Checked = true;
            this.mnuLog1.CheckOnClick = true;
            this.mnuLog1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuLog1.Name = "mnuLog1";
            this.mnuLog1.Size = new System.Drawing.Size(80, 22);
            this.mnuLog1.Text = "1";
            this.mnuLog1.Click += new System.EventHandler(this.mnuLog1_Click);
            // 
            // mnuLog2
            // 
            this.mnuLog2.CheckOnClick = true;
            this.mnuLog2.Name = "mnuLog2";
            this.mnuLog2.Size = new System.Drawing.Size(80, 22);
            this.mnuLog2.Text = "2";
            this.mnuLog2.Click += new System.EventHandler(this.mnuLog2_Click);
            // 
            // mnuLog3
            // 
            this.mnuLog3.CheckOnClick = true;
            this.mnuLog3.Name = "mnuLog3";
            this.mnuLog3.Size = new System.Drawing.Size(80, 22);
            this.mnuLog3.Text = "3";
            this.mnuLog3.Click += new System.EventHandler(this.mnuLog3_Click);
            // 
            // mnuLog4
            // 
            this.mnuLog4.CheckOnClick = true;
            this.mnuLog4.Name = "mnuLog4";
            this.mnuLog4.Size = new System.Drawing.Size(80, 22);
            this.mnuLog4.Text = "4";
            this.mnuLog4.Click += new System.EventHandler(this.mnuLog4_Click);
            // 
            // fileLoggingToolStripMenuItem
            // 
            this.fileLoggingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogToFile,
            this.mnuScrapesToFile});
            this.fileLoggingToolStripMenuItem.Name = "fileLoggingToolStripMenuItem";
            this.fileLoggingToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.fileLoggingToolStripMenuItem.Text = "File Logging";
            // 
            // mnuLogToFile
            // 
            this.mnuLogToFile.CheckOnClick = true;
            this.mnuLogToFile.Name = "mnuLogToFile";
            this.mnuLogToFile.Size = new System.Drawing.Size(149, 22);
            this.mnuLogToFile.Text = "Log To File";
            this.mnuLogToFile.ToolTipText = "This will start logging to files, including the scraped HTML, for debugging.";
            this.mnuLogToFile.CheckedChanged += new System.EventHandler(this.mnuLogToFile_CheckedChanged);
            // 
            // mnuScrapesToFile
            // 
            this.mnuScrapesToFile.CheckOnClick = true;
            this.mnuScrapesToFile.Name = "mnuScrapesToFile";
            this.mnuScrapesToFile.Size = new System.Drawing.Size(149, 22);
            this.mnuScrapesToFile.Text = "Scrapes to File";
            this.mnuScrapesToFile.CheckedChanged += new System.EventHandler(this.mnuScrapesToFile_CheckedChanged);
            // 
            // hideWeaponsToolStripMenuItem
            // 
            this.hideWeaponsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMG,
            this.mnuLRM,
            this.mnuAM,
            this.mnuTAG,
            this.mnuNARC});
            this.hideWeaponsToolStripMenuItem.Name = "hideWeaponsToolStripMenuItem";
            this.hideWeaponsToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.hideWeaponsToolStripMenuItem.Text = "Hide Weapons";
            // 
            // mnuMG
            // 
            this.mnuMG.Checked = true;
            this.mnuMG.CheckOnClick = true;
            this.mnuMG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuMG.Name = "mnuMG";
            this.mnuMG.Size = new System.Drawing.Size(150, 22);
            this.mnuMG.Text = "Machine Guns";
            this.mnuMG.Click += new System.EventHandler(this.mnuMG_Click);
            // 
            // mnuLRM
            // 
            this.mnuLRM.Checked = true;
            this.mnuLRM.CheckOnClick = true;
            this.mnuLRM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuLRM.Name = "mnuLRM";
            this.mnuLRM.Size = new System.Drawing.Size(150, 22);
            this.mnuLRM.Text = "LRMs";
            this.mnuLRM.Click += new System.EventHandler(this.mnuLRM_Click);
            // 
            // mnuAM
            // 
            this.mnuAM.Checked = true;
            this.mnuAM.CheckOnClick = true;
            this.mnuAM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuAM.Name = "mnuAM";
            this.mnuAM.Size = new System.Drawing.Size(150, 22);
            this.mnuAM.Text = "Anti-Missile";
            this.mnuAM.Click += new System.EventHandler(this.mnuAM_Click);
            // 
            // mnuTAG
            // 
            this.mnuTAG.Checked = true;
            this.mnuTAG.CheckOnClick = true;
            this.mnuTAG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuTAG.Name = "mnuTAG";
            this.mnuTAG.Size = new System.Drawing.Size(150, 22);
            this.mnuTAG.Text = "TAG";
            this.mnuTAG.Click += new System.EventHandler(this.mnuTAG_Click);
            // 
            // mnuNARC
            // 
            this.mnuNARC.Checked = true;
            this.mnuNARC.CheckOnClick = true;
            this.mnuNARC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuNARC.Name = "mnuNARC";
            this.mnuNARC.Size = new System.Drawing.Size(150, 22);
            this.mnuNARC.Text = "NARC";
            this.mnuNARC.Click += new System.EventHandler(this.mnuNARC_Click);
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClearBaseTables,
            this.mnuLogIn,
            this.mnuTestWithFiles});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // mnuClearBaseTables
            // 
            this.mnuClearBaseTables.Name = "mnuClearBaseTables";
            this.mnuClearBaseTables.Size = new System.Drawing.Size(181, 22);
            this.mnuClearBaseTables.Text = "Clear base* tables";
            this.mnuClearBaseTables.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // mnuLogIn
            // 
            this.mnuLogIn.Name = "mnuLogIn";
            this.mnuLogIn.Size = new System.Drawing.Size(181, 22);
            this.mnuLogIn.Text = "Make Login Request";
            this.mnuLogIn.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // mnuTestWithFiles
            // 
            this.mnuTestWithFiles.Name = "mnuTestWithFiles";
            this.mnuTestWithFiles.Size = new System.Drawing.Size(181, 22);
            this.mnuTestWithFiles.Text = "Test With Files";
            this.mnuTestWithFiles.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // nmbMatches
            // 
            this.nmbMatches.Location = new System.Drawing.Point(434, 101);
            this.nmbMatches.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmbMatches.Name = "nmbMatches";
            this.nmbMatches.Size = new System.Drawing.Size(39, 20);
            this.nmbMatches.TabIndex = 18;
            this.nmbMatches.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(480, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Number of matches to graph";
            // 
            // cbZoom
            // 
            this.cbZoom.AutoSize = true;
            this.cbZoom.Location = new System.Drawing.Point(638, 107);
            this.cbZoom.Name = "cbZoom";
            this.cbZoom.Size = new System.Drawing.Size(119, 17);
            this.cbZoom.TabIndex = 20;
            this.cbZoom.Text = "Zoom Chart Results";
            this.cbZoom.UseVisualStyleBackColor = true;
            this.cbZoom.CheckedChanged += new System.EventHandler(this.cbZoom_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbNARC);
            this.groupBox1.Controls.Add(this.cbTAG);
            this.groupBox1.Controls.Add(this.cbAM);
            this.groupBox1.Controls.Add(this.cbLRM);
            this.groupBox1.Controls.Add(this.cbMG);
            this.groupBox1.Location = new System.Drawing.Point(434, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 64);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hide Weapons";
            // 
            // cbNARC
            // 
            this.cbNARC.AutoSize = true;
            this.cbNARC.Checked = true;
            this.cbNARC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNARC.Location = new System.Drawing.Point(303, 29);
            this.cbNARC.Name = "cbNARC";
            this.cbNARC.Size = new System.Drawing.Size(56, 17);
            this.cbNARC.TabIndex = 4;
            this.cbNARC.Text = "NARC";
            this.cbNARC.UseVisualStyleBackColor = true;
            this.cbNARC.CheckedChanged += new System.EventHandler(this.cbNARC_CheckedChanged);
            // 
            // cbTAG
            // 
            this.cbTAG.AutoSize = true;
            this.cbTAG.Checked = true;
            this.cbTAG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTAG.Location = new System.Drawing.Point(248, 29);
            this.cbTAG.Name = "cbTAG";
            this.cbTAG.Size = new System.Drawing.Size(48, 17);
            this.cbTAG.TabIndex = 3;
            this.cbTAG.Text = "TAG";
            this.cbTAG.UseVisualStyleBackColor = true;
            this.cbTAG.CheckedChanged += new System.EventHandler(this.cbTAG_CheckedChanged);
            // 
            // cbAM
            // 
            this.cbAM.AutoSize = true;
            this.cbAM.Checked = true;
            this.cbAM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAM.Location = new System.Drawing.Point(164, 29);
            this.cbAM.Name = "cbAM";
            this.cbAM.Size = new System.Drawing.Size(78, 17);
            this.cbAM.TabIndex = 2;
            this.cbAM.Text = "Anti-Missile";
            this.cbAM.UseVisualStyleBackColor = true;
            this.cbAM.CheckedChanged += new System.EventHandler(this.cbAM_CheckedChanged);
            // 
            // cbLRM
            // 
            this.cbLRM.AutoSize = true;
            this.cbLRM.Checked = true;
            this.cbLRM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLRM.Location = new System.Drawing.Point(104, 29);
            this.cbLRM.Name = "cbLRM";
            this.cbLRM.Size = new System.Drawing.Size(54, 17);
            this.cbLRM.TabIndex = 1;
            this.cbLRM.Text = "LRMs";
            this.cbLRM.UseVisualStyleBackColor = true;
            this.cbLRM.CheckedChanged += new System.EventHandler(this.cbLRM_CheckedChanged);
            // 
            // cbMG
            // 
            this.cbMG.AutoSize = true;
            this.cbMG.Checked = true;
            this.cbMG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMG.Location = new System.Drawing.Point(7, 29);
            this.cbMG.Name = "cbMG";
            this.cbMG.Size = new System.Drawing.Size(95, 17);
            this.cbMG.TabIndex = 0;
            this.cbMG.Text = "Machine Guns";
            this.cbMG.UseVisualStyleBackColor = true;
            this.cbMG.CheckedChanged += new System.EventHandler(this.cbMG_CheckedChanged);
            // 
            // nmbScrapeFreq
            // 
            this.nmbScrapeFreq.Location = new System.Drawing.Point(307, 34);
            this.nmbScrapeFreq.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nmbScrapeFreq.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmbScrapeFreq.Name = "nmbScrapeFreq";
            this.nmbScrapeFreq.Size = new System.Drawing.Size(36, 20);
            this.nmbScrapeFreq.TabIndex = 22;
            this.toolTip1.SetToolTip(this.nmbScrapeFreq, "Minutes between scrapes.");
            this.nmbScrapeFreq.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmbScrapeFreq.ValueChanged += new System.EventHandler(this.nmbScrapeFreq_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Frequency";
            this.toolTip1.SetToolTip(this.label3, "Minutes between scrapes.");
            // 
            // btnTryLogon
            // 
            this.btnTryLogon.Location = new System.Drawing.Point(875, 37);
            this.btnTryLogon.Name = "btnTryLogon";
            this.btnTryLogon.Size = new System.Drawing.Size(85, 23);
            this.btnTryLogon.TabIndex = 24;
            this.btnTryLogon.Text = "Try Logon..";
            this.toolTip1.SetToolTip(this.btnTryLogon, "Calls the \"start\" routine, attempts to make a login to the website");
            this.btnTryLogon.UseVisualStyleBackColor = true;
            this.btnTryLogon.Click += new System.EventHandler(this.btnTryLogon_Click);
            // 
            // lblCurrentMech
            // 
            this.lblCurrentMech.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentMech.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblCurrentMech.Location = new System.Drawing.Point(949, 130);
            this.lblCurrentMech.MaximumSize = new System.Drawing.Size(27, 510);
            this.lblCurrentMech.Name = "lblCurrentMech";
            this.lblCurrentMech.Size = new System.Drawing.Size(27, 510);
            this.lblCurrentMech.TabIndex = 25;
            this.lblCurrentMech.Text = "TESTINGMECH - TST-XX1";
            this.lblCurrentMech.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMWOStatSys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(995, 647);
            this.Controls.Add(this.lblCurrentMech);
            this.Controls.Add(this.btnTryLogon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nmbScrapeFreq);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbZoom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nmbMatches);
            this.Controls.Add(this.tcCharts);
            this.Controls.Add(this.cbAutoScrape);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbNextScrape);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCheckLogin);
            this.Controls.Add(this.btnShowError);
            this.Controls.Add(this.dgModes);
            this.Controls.Add(this.dgMaps);
            this.Controls.Add(this.dgWeapons);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.dgMechs);
            this.Controls.Add(this.btnScrapeIt);
            this.Controls.Add(this.btnSetLogin);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1010, 685);
            this.Name = "frmMWOStatSys";
            this.Text = "MWO Stat Grabber";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMWOStatSys_FormClosing);
            this.Load += new System.EventHandler(this.frmMWOStatSys_Load);
            this.Shown += new System.EventHandler(this.frmMWOStatSys_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgMechs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgWeapons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMaps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgModes)).EndInit();
            this.tcCharts.ResumeLayout(false);
            this.tabAccuracy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtAccuracy)).EndInit();
            this.tabEffective.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtEffective)).EndInit();
            this.tabExpAndCbills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtExpCbills)).EndInit();
            this.tabFullHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvMatchHistory)).EndInit();
            this.pnlMechSelect.ResumeLayout(false);
            this.pnlMechSelect.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmbMatches)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmbScrapeFreq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSetLogin;
        private System.Windows.Forms.Button btnScrapeIt;
        private System.Windows.Forms.DataGridView dgMechs;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.DataGridView dgWeapons;
        private System.Windows.Forms.DataGridView dgMaps;
        private System.Windows.Forms.DataGridView dgModes;
        private System.Windows.Forms.Button btnShowError;
        private System.Windows.Forms.Button btnCheckLogin;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ProgressBar pbNextScrape;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbAutoScrape;
        private System.Windows.Forms.TabControl tcCharts;
        private System.Windows.Forms.TabPage tabAccuracy;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtAccuracy;
        private System.Windows.Forms.TabPage tabEffective;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuLogLevel;
        private System.Windows.Forms.ToolStripMenuItem fileLoggingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuLogToFile;
        private System.Windows.Forms.NumericUpDown nmbMatches;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtEffective;
        private System.Windows.Forms.CheckBox cbZoom;
        private System.Windows.Forms.ToolStripMenuItem hideWeaponsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuMG;
        private System.Windows.Forms.ToolStripMenuItem mnuLRM;
        private System.Windows.Forms.ToolStripMenuItem mnuAM;
        private System.Windows.Forms.ToolStripMenuItem mnuTAG;
        private System.Windows.Forms.ToolStripMenuItem mnuNARC;
        private System.Windows.Forms.ToolStripMenuItem mnuLog1;
        private System.Windows.Forms.ToolStripMenuItem mnuLog2;
        private System.Windows.Forms.ToolStripMenuItem mnuLog3;
        private System.Windows.Forms.ToolStripMenuItem mnuScrapesToFile;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuClearBaseTables;
        private System.Windows.Forms.ToolStripMenuItem mnuLogIn;
        private System.Windows.Forms.ToolStripMenuItem mnuTestWithFiles;
        private System.Windows.Forms.TabPage tabExpAndCbills;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtExpCbills;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbNARC;
        private System.Windows.Forms.CheckBox cbTAG;
        private System.Windows.Forms.CheckBox cbAM;
        private System.Windows.Forms.CheckBox cbLRM;
        private System.Windows.Forms.CheckBox cbMG;
        private System.Windows.Forms.NumericUpDown nmbScrapeFreq;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem mnuLog4;
        private System.Windows.Forms.Button btnTryLogon;
        private System.Windows.Forms.TabPage tabMechInfo;
        private System.Windows.Forms.Label lblCurrentMech;
        private System.Windows.Forms.TabPage tabFullHistory;
        private System.Windows.Forms.Panel pnlMechSelect;
        private System.Windows.Forms.Label lblMechSelection;
        private System.Windows.Forms.ComboBox cbMechList;
        //private System.Windows.Forms.FlowLayoutPanel flpMatches;
        private System.Windows.Forms.Label lblMatchCount;
        private System.Windows.Forms.Label lblKills;
        private System.Windows.Forms.Label lblWins;
        private System.Windows.Forms.Label lblMatchCountHeader;
        private System.Windows.Forms.Label lblKillsHeader;
        private System.Windows.Forms.Label lblWinsHeader;
        private System.Windows.Forms.Label lblDeaths;
        private System.Windows.Forms.Label lblDeathsHeader;
        private System.Windows.Forms.Label lblCBills;
        private System.Windows.Forms.Label lblCBillsHeader;
        private System.Windows.Forms.Label lblLosses;
        private System.Windows.Forms.Label lblLossesHeader;
        private BrightIdeasSoftware.ObjectListView olvMatchHistory;
        private BrightIdeasSoftware.OLVColumn olvColWin;
        private BrightIdeasSoftware.OLVColumn olvColLived;
        private BrightIdeasSoftware.OLVColumn olvColKills;
        private BrightIdeasSoftware.OLVColumn olvCoDamage;
        private BrightIdeasSoftware.OLVColumn olvCoHits;
        private BrightIdeasSoftware.OLVColumn olvColMisses;
        private BrightIdeasSoftware.OLVColumn olvColExp;
        private BrightIdeasSoftware.OLVColumn olvColCBills;
        private BrightIdeasSoftware.OLVColumn olvColMap;
        private BrightIdeasSoftware.OLVColumn olvColMode;
        private BrightIdeasSoftware.OLVColumn olvColDate;
    }
}

