
using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.SapClassGui;
using System.Windows.Forms;


namespace DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo
{
    partial class GigECameraDemoDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be
        ///     disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify the contents of
        /// this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GigECameraDemoDlg));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripLabel();
            this.StatusLabelInfo = new System.Windows.Forms.ToolStripLabel();
            this.StatusLabelInfoTrash = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PixelLabel = new System.Windows.Forms.ToolStripLabel();
            this.PixelDataValue = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.timeElapsedLabel = new System.Windows.Forms.ToolStripLabel();
            this.timeElapsed = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deviceTempLabel = new System.Windows.Forms.ToolStripLabel();
            this.deviceTemp = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lblUserLogged = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.lblLoggedRemainingTime = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.lblPlcDataStatus = new System.Windows.Forms.ToolStripLabel();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPlcTrigger = new System.Windows.Forms.Label();
            this.txtLiveMode = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.txtFramesCount = new System.Windows.Forms.Label();
            this.btnResetFrameCounter = new System.Windows.Forms.Button();
            this.txtSoftwareTrigger = new System.Windows.Forms.Label();
            this.txtFrameMode = new System.Windows.Forms.Label();
            this.btnVirtualTrigger = new System.Windows.Forms.Button();
            this.btnProcessImage = new System.Windows.Forms.Button();
            this.btnTriggerMode = new System.Windows.Forms.Button();
            this.btnViewMode = new System.Windows.Forms.Button();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.btnSetPointManual = new System.Windows.Forms.Button();
            this.btnSetPointLocal = new System.Windows.Forms.Button();
            this.btnSetPointPLC = new System.Windows.Forms.Button();
            this.GroupActualTargetSize = new System.Windows.Forms.GroupBox();
            this.txtProductSetted = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.minDiameterUnitsTxt = new System.Windows.Forms.Label();
            this.maxDiameterUnitsTxt = new System.Windows.Forms.Label();
            this.txtMinDiameter = new System.Windows.Forms.TextBox();
            this.Label54 = new System.Windows.Forms.Label();
            this.Label55 = new System.Windows.Forms.Label();
            this.txtMaxDiameter = new System.Windows.Forms.TextBox();
            this.GroupSelectGrid = new System.Windows.Forms.GroupBox();
            this.grid_16 = new System.Windows.Forms.Button();
            this.grid_12 = new System.Windows.Forms.Button();
            this.grid_6 = new System.Windows.Forms.Button();
            this.grid_5 = new System.Windows.Forms.Button();
            this.grid_9 = new System.Windows.Forms.Button();
            this.grid_4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.controlsTabs = new System.Windows.Forms.TabControl();
            this.mainControlPage = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.lblCV = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.txtValidObjects = new System.Windows.Forms.Label();
            this.txtEquivalentDiameterUnits = new System.Windows.Forms.Label();
            this.lblSEQDiameter = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnFreezeFrame = new System.Windows.Forms.Button();
            this.txtAvgMinDiameterUnits = new System.Windows.Forms.Label();
            this.txtAvgMaxDiameterUnits = new System.Windows.Forms.Label();
            this.txtAvgDiameterUnits = new System.Windows.Forms.Label();
            this.lblAvgDiameter = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblMinDiameter = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblMaxDiameter = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flagValidFrames = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.dplControlDiameter = new System.Windows.Forms.Button();
            this.txtControlDiameter = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.flagAlign = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.flagFH = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtControlDiameterUnits = new System.Windows.Forms.Label();
            this.configurationPage = new System.Windows.Forms.TabPage();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.btnLinesFilter = new System.Windows.Forms.Button();
            this.btn90DegDiameters = new System.Windows.Forms.Button();
            this.gbShapeIndicator = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCompacityHoleLimit = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtMaxCompacity = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLogoff = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.GB_Threshold = new System.Windows.Forms.GroupBox();
            this.btnAutoThreshold = new System.Windows.Forms.Button();
            this.btnManualThreshold = new System.Windows.Forms.Button();
            this.txtThreshold = new System.Windows.Forms.TextBox();
            this.boxROI = new System.Windows.Forms.GroupBox();
            this.btnDecrementRoiHeight = new System.Windows.Forms.Button();
            this.btnIncrementRoiHeight = new System.Windows.Forms.Button();
            this.txtRoiHeight = new System.Windows.Forms.TextBox();
            this.btnDecrementRoiWidth = new System.Windows.Forms.Button();
            this.btnIncrementRoiWidth = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoiWidth = new System.Windows.Forms.TextBox();
            this.boxUnits = new System.Windows.Forms.GroupBox();
            this.btnChangeUnitsInch = new System.Windows.Forms.Button();
            this.btnChangeUnitsMm = new System.Windows.Forms.Button();
            this.advancedPage = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtValidFramesLimit = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtAlign = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtFFH = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtFH = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnVideoSettings = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMinBlobObjects = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAlpha = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCalibrateByHeight = new System.Windows.Forms.Button();
            this.calibrateBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEuFactor = new System.Windows.Forms.Label();
            this.aboutPage = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainTabs = new System.Windows.Forms.TabControl();
            this.imagePage = new System.Windows.Forms.TabPage();
            this.boxOriginal = new System.Windows.Forms.GroupBox();
            this.boxProcess = new System.Windows.Forms.GroupBox();
            this.tablePage = new System.Windows.Forms.TabPage();
            this.trendPage = new System.Windows.Forms.TabPage();
            this.btnClearChart = new System.Windows.Forms.Button();
            this.trendChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.productsPage = new System.Windows.Forms.TabPage();
            this.GroupBox13 = new System.Windows.Forms.GroupBox();
            this.Label47 = new System.Windows.Forms.Label();
            this.Chk_Right_Side = new System.Windows.Forms.CheckBox();
            this.Txt_Tag = new System.Windows.Forms.TextBox();
            this.Chk_Digital_Knife = new System.Windows.Forms.CheckBox();
            this.GroupBox10 = new System.Windows.Forms.GroupBox();
            this.CmbProducts = new System.Windows.Forms.ComboBox();
            this.btnSelectProduct = new System.Windows.Forms.Button();
            this.GroupBox9 = new System.Windows.Forms.GroupBox();
            this.btnModifyProduct = new System.Windows.Forms.Button();
            this.btnRestoreProduct = new System.Windows.Forms.Button();
            this.cmbProductUnits = new System.Windows.Forms.ComboBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSaveProduct = new System.Windows.Forms.Button();
            this.txtMinDProductUnits = new System.Windows.Forms.Label();
            this.txtMaxDProductUnits = new System.Windows.Forms.Label();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.CmbGrid = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Txt_Description = new System.Windows.Forms.TextBox();
            this.Txt_Code = new System.Windows.Forms.TextBox();
            this.Txt_MinD = new System.Windows.Forms.TextBox();
            this.Label31 = new System.Windows.Forms.Label();
            this.Label32 = new System.Windows.Forms.Label();
            this.Txt_MaxD = new System.Windows.Forms.TextBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.Label28 = new System.Windows.Forms.Label();
            this.tmrMB = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            this.GroupActualTargetSize.SuspendLayout();
            this.GroupSelectGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.controlsTabs.SuspendLayout();
            this.mainControlPage.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.configurationPage.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.gbShapeIndicator.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.GB_Threshold.SuspendLayout();
            this.boxROI.SuspendLayout();
            this.boxUnits.SuspendLayout();
            this.advancedPage.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.aboutPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mainTabs.SuspendLayout();
            this.imagePage.SuspendLayout();
            this.boxOriginal.SuspendLayout();
            this.tablePage.SuspendLayout();
            this.trendPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trendChart)).BeginInit();
            this.productsPage.SuspendLayout();
            this.GroupBox13.SuspendLayout();
            this.GroupBox10.SuspendLayout();
            this.GroupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.StatusLabelInfo,
            this.StatusLabelInfoTrash,
            this.toolStripSeparator1,
            this.PixelLabel,
            this.PixelDataValue,
            this.toolStripSeparator2,
            this.timeElapsedLabel,
            this.timeElapsed,
            this.toolStripSeparator3,
            this.deviceTempLabel,
            this.deviceTemp,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.lblUserLogged,
            this.toolStripLabel2,
            this.lblLoggedRemainingTime,
            this.toolStripSeparator5,
            this.lblPlcDataStatus});
            this.toolStrip1.Location = new System.Drawing.Point(0, 851);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(787, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(45, 22);
            this.StatusLabel.Text = "Status :";
            this.StatusLabel.Visible = false;
            // 
            // StatusLabelInfo
            // 
            this.StatusLabelInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.StatusLabelInfo.Name = "StatusLabelInfo";
            this.StatusLabelInfo.Size = new System.Drawing.Size(49, 22);
            this.StatusLabelInfo.Text = "nothing";
            this.StatusLabelInfo.Visible = false;
            // 
            // StatusLabelInfoTrash
            // 
            this.StatusLabelInfoTrash.Name = "StatusLabelInfoTrash";
            this.StatusLabelInfoTrash.Size = new System.Drawing.Size(0, 22);
            this.StatusLabelInfoTrash.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator1.Visible = false;
            // 
            // PixelLabel
            // 
            this.PixelLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PixelLabel.Name = "PixelLabel";
            this.PixelLabel.Size = new System.Drawing.Size(38, 22);
            this.PixelLabel.Text = "Pixel :";
            this.PixelLabel.Visible = false;
            // 
            // PixelDataValue
            // 
            this.PixelDataValue.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PixelDataValue.Name = "PixelDataValue";
            this.PixelDataValue.Size = new System.Drawing.Size(92, 22);
            this.PixelDataValue.Text = "Data not avaible";
            this.PixelDataValue.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator2.Visible = false;
            // 
            // timeElapsedLabel
            // 
            this.timeElapsedLabel.Name = "timeElapsedLabel";
            this.timeElapsedLabel.Size = new System.Drawing.Size(152, 22);
            this.timeElapsedLabel.Text = "Time Elapsed in Last Frame:";
            // 
            // timeElapsed
            // 
            this.timeElapsed.Name = "timeElapsed";
            this.timeElapsed.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // deviceTempLabel
            // 
            this.deviceTempLabel.Name = "deviceTempLabel";
            this.deviceTempLabel.Size = new System.Drawing.Size(104, 22);
            this.deviceTempLabel.Text = "Device Temp. (°C):";
            // 
            // deviceTemp
            // 
            this.deviceTemp.Name = "deviceTemp";
            this.deviceTemp.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(76, 22);
            this.toolStripLabel1.Text = "User Logged:";
            // 
            // lblUserLogged
            // 
            this.lblUserLogged.Name = "lblUserLogged";
            this.lblUserLogged.Size = new System.Drawing.Size(66, 22);
            this.lblUserLogged.Text = "No Logged";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(96, 22);
            this.toolStripLabel2.Text = "Remaining Time:";
            // 
            // lblLoggedRemainingTime
            // 
            this.lblLoggedRemainingTime.Name = "lblLoggedRemainingTime";
            this.lblLoggedRemainingTime.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // lblPlcDataStatus
            // 
            this.lblPlcDataStatus.Name = "lblPlcDataStatus";
            this.lblPlcDataStatus.Size = new System.Drawing.Size(0, 22);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.txtPlcTrigger);
            this.GroupBox1.Controls.Add(this.txtLiveMode);
            this.GroupBox1.Controls.Add(this.groupBox15);
            this.GroupBox1.Controls.Add(this.txtSoftwareTrigger);
            this.GroupBox1.Controls.Add(this.txtFrameMode);
            this.GroupBox1.Controls.Add(this.btnVirtualTrigger);
            this.GroupBox1.Controls.Add(this.btnProcessImage);
            this.GroupBox1.Controls.Add(this.btnTriggerMode);
            this.GroupBox1.Controls.Add(this.btnViewMode);
            this.GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.GroupBox1.Location = new System.Drawing.Point(3, 4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(464, 144);
            this.GroupBox1.TabIndex = 66;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Operation Controls";
            // 
            // txtPlcTrigger
            // 
            this.txtPlcTrigger.AutoSize = true;
            this.txtPlcTrigger.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtPlcTrigger.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtPlcTrigger.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlcTrigger.Location = new System.Drawing.Point(116, 85);
            this.txtPlcTrigger.Name = "txtPlcTrigger";
            this.txtPlcTrigger.Size = new System.Drawing.Size(40, 23);
            this.txtPlcTrigger.TabIndex = 133;
            this.txtPlcTrigger.Text = "PLC";
            // 
            // txtLiveMode
            // 
            this.txtLiveMode.AutoSize = true;
            this.txtLiveMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtLiveMode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLiveMode.Location = new System.Drawing.Point(116, 21);
            this.txtLiveMode.Name = "txtLiveMode";
            this.txtLiveMode.Size = new System.Drawing.Size(45, 23);
            this.txtLiveMode.TabIndex = 132;
            this.txtLiveMode.Text = "LIVE";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.txtFramesCount);
            this.groupBox15.Controls.Add(this.btnResetFrameCounter);
            this.groupBox15.Location = new System.Drawing.Point(231, 19);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(207, 57);
            this.groupBox15.TabIndex = 131;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Frames Count";
            // 
            // txtFramesCount
            // 
            this.txtFramesCount.AutoSize = true;
            this.txtFramesCount.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtFramesCount.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtFramesCount.Location = new System.Drawing.Point(16, 27);
            this.txtFramesCount.Name = "txtFramesCount";
            this.txtFramesCount.Size = new System.Drawing.Size(17, 20);
            this.txtFramesCount.TabIndex = 131;
            this.txtFramesCount.Text = "0";
            // 
            // btnResetFrameCounter
            // 
            this.btnResetFrameCounter.BackColor = System.Drawing.Color.Silver;
            this.btnResetFrameCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetFrameCounter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetFrameCounter.Location = new System.Drawing.Point(95, 15);
            this.btnResetFrameCounter.Name = "btnResetFrameCounter";
            this.btnResetFrameCounter.Size = new System.Drawing.Size(103, 36);
            this.btnResetFrameCounter.TabIndex = 134;
            this.btnResetFrameCounter.Text = "RESET";
            this.btnResetFrameCounter.UseVisualStyleBackColor = false;
            this.btnResetFrameCounter.Click += new System.EventHandler(this.btnResetFrameCounter_Click);
            // 
            // txtSoftwareTrigger
            // 
            this.txtSoftwareTrigger.AutoSize = true;
            this.txtSoftwareTrigger.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtSoftwareTrigger.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSoftwareTrigger.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoftwareTrigger.Location = new System.Drawing.Point(115, 114);
            this.txtSoftwareTrigger.Name = "txtSoftwareTrigger";
            this.txtSoftwareTrigger.Size = new System.Drawing.Size(95, 23);
            this.txtSoftwareTrigger.TabIndex = 125;
            this.txtSoftwareTrigger.Text = "SOFTWARE";
            // 
            // txtFrameMode
            // 
            this.txtFrameMode.AutoSize = true;
            this.txtFrameMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtFrameMode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrameMode.Location = new System.Drawing.Point(116, 54);
            this.txtFrameMode.Name = "txtFrameMode";
            this.txtFrameMode.Size = new System.Drawing.Size(65, 23);
            this.txtFrameMode.TabIndex = 124;
            this.txtFrameMode.Text = "FRAME";
            // 
            // btnVirtualTrigger
            // 
            this.btnVirtualTrigger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVirtualTrigger.BackColor = System.Drawing.Color.Silver;
            this.btnVirtualTrigger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVirtualTrigger.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVirtualTrigger.Location = new System.Drawing.Point(228, 81);
            this.btnVirtualTrigger.Name = "btnVirtualTrigger";
            this.btnVirtualTrigger.Size = new System.Drawing.Size(108, 55);
            this.btnVirtualTrigger.TabIndex = 74;
            this.btnVirtualTrigger.Text = "CAPTURE\r\nFRAME";
            this.btnVirtualTrigger.UseVisualStyleBackColor = false;
            this.btnVirtualTrigger.Click += new System.EventHandler(this.virtualTriggerBtn_Click);
            // 
            // btnProcessImage
            // 
            this.btnProcessImage.BackColor = System.Drawing.Color.Silver;
            this.btnProcessImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcessImage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessImage.Location = new System.Drawing.Point(340, 81);
            this.btnProcessImage.Name = "btnProcessImage";
            this.btnProcessImage.Size = new System.Drawing.Size(101, 55);
            this.btnProcessImage.TabIndex = 73;
            this.btnProcessImage.Text = "PROCESS FRAME";
            this.btnProcessImage.UseVisualStyleBackColor = false;
            this.btnProcessImage.Click += new System.EventHandler(this.processImageBtn_Click);
            // 
            // btnTriggerMode
            // 
            this.btnTriggerMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTriggerMode.BackColor = System.Drawing.Color.Silver;
            this.btnTriggerMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTriggerMode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTriggerMode.Location = new System.Drawing.Point(7, 80);
            this.btnTriggerMode.Name = "btnTriggerMode";
            this.btnTriggerMode.Size = new System.Drawing.Size(103, 57);
            this.btnTriggerMode.TabIndex = 72;
            this.btnTriggerMode.Text = "TRIGGER SOURCE";
            this.btnTriggerMode.UseVisualStyleBackColor = false;
            this.btnTriggerMode.Click += new System.EventHandler(this.triggerModeBtn_Click);
            // 
            // btnViewMode
            // 
            this.btnViewMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnViewMode.BackColor = System.Drawing.Color.Silver;
            this.btnViewMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewMode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewMode.Location = new System.Drawing.Point(7, 19);
            this.btnViewMode.Name = "btnViewMode";
            this.btnViewMode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnViewMode.Size = new System.Drawing.Size(103, 58);
            this.btnViewMode.TabIndex = 69;
            this.btnViewMode.Text = "VIEW MODE";
            this.btnViewMode.UseVisualStyleBackColor = false;
            this.btnViewMode.Click += new System.EventHandler(this.Cmd_Trigger_Click);
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.btnSetPointManual);
            this.GroupBox8.Controls.Add(this.btnSetPointLocal);
            this.GroupBox8.Controls.Add(this.btnSetPointPLC);
            this.GroupBox8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GroupBox8.Location = new System.Drawing.Point(5, 439);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(462, 84);
            this.GroupBox8.TabIndex = 112;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "Product Specs Source";
            // 
            // btnSetPointManual
            // 
            this.btnSetPointManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetPointManual.BackColor = System.Drawing.Color.Silver;
            this.btnSetPointManual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetPointManual.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetPointManual.Location = new System.Drawing.Point(310, 21);
            this.btnSetPointManual.Name = "btnSetPointManual";
            this.btnSetPointManual.Size = new System.Drawing.Size(107, 49);
            this.btnSetPointManual.TabIndex = 128;
            this.btnSetPointManual.Text = "MANUAL";
            this.btnSetPointManual.UseVisualStyleBackColor = false;
            this.btnSetPointManual.Click += new System.EventHandler(this.btnSetPointManual_Click);
            // 
            // btnSetPointLocal
            // 
            this.btnSetPointLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetPointLocal.BackColor = System.Drawing.Color.Silver;
            this.btnSetPointLocal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetPointLocal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetPointLocal.Location = new System.Drawing.Point(182, 21);
            this.btnSetPointLocal.Name = "btnSetPointLocal";
            this.btnSetPointLocal.Size = new System.Drawing.Size(107, 49);
            this.btnSetPointLocal.TabIndex = 127;
            this.btnSetPointLocal.Text = "LOCAL";
            this.btnSetPointLocal.UseVisualStyleBackColor = false;
            this.btnSetPointLocal.Click += new System.EventHandler(this.btnSetPointLocal_Click);
            // 
            // btnSetPointPLC
            // 
            this.btnSetPointPLC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetPointPLC.BackColor = System.Drawing.Color.Silver;
            this.btnSetPointPLC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetPointPLC.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetPointPLC.Location = new System.Drawing.Point(59, 21);
            this.btnSetPointPLC.Name = "btnSetPointPLC";
            this.btnSetPointPLC.Size = new System.Drawing.Size(107, 49);
            this.btnSetPointPLC.TabIndex = 126;
            this.btnSetPointPLC.Text = "PLC";
            this.btnSetPointPLC.UseVisualStyleBackColor = false;
            this.btnSetPointPLC.Click += new System.EventHandler(this.btnSetPointPLC_Click);
            // 
            // GroupActualTargetSize
            // 
            this.GroupActualTargetSize.Controls.Add(this.txtProductSetted);
            this.GroupActualTargetSize.Controls.Add(this.label17);
            this.GroupActualTargetSize.Controls.Add(this.minDiameterUnitsTxt);
            this.GroupActualTargetSize.Controls.Add(this.maxDiameterUnitsTxt);
            this.GroupActualTargetSize.Controls.Add(this.txtMinDiameter);
            this.GroupActualTargetSize.Controls.Add(this.Label54);
            this.GroupActualTargetSize.Controls.Add(this.Label55);
            this.GroupActualTargetSize.Controls.Add(this.txtMaxDiameter);
            this.GroupActualTargetSize.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GroupActualTargetSize.Location = new System.Drawing.Point(5, 524);
            this.GroupActualTargetSize.Name = "GroupActualTargetSize";
            this.GroupActualTargetSize.Size = new System.Drawing.Size(268, 179);
            this.GroupActualTargetSize.TabIndex = 111;
            this.GroupActualTargetSize.TabStop = false;
            this.GroupActualTargetSize.Text = "Actual Target Sizes";
            // 
            // txtProductSetted
            // 
            this.txtProductSetted.AutoSize = true;
            this.txtProductSetted.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductSetted.Location = new System.Drawing.Point(121, 37);
            this.txtProductSetted.Name = "txtProductSetted";
            this.txtProductSetted.Size = new System.Drawing.Size(34, 21);
            this.txtProductSetted.TabIndex = 98;
            this.txtProductSetted.Text = "NA";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 38);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 21);
            this.label17.TabIndex = 97;
            this.label17.Text = "Product:";
            // 
            // minDiameterUnitsTxt
            // 
            this.minDiameterUnitsTxt.AutoSize = true;
            this.minDiameterUnitsTxt.BackColor = System.Drawing.Color.Transparent;
            this.minDiameterUnitsTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minDiameterUnitsTxt.Location = new System.Drawing.Point(209, 133);
            this.minDiameterUnitsTxt.Name = "minDiameterUnitsTxt";
            this.minDiameterUnitsTxt.Size = new System.Drawing.Size(40, 21);
            this.minDiameterUnitsTxt.TabIndex = 96;
            this.minDiameterUnitsTxt.Text = "mm";
            // 
            // maxDiameterUnitsTxt
            // 
            this.maxDiameterUnitsTxt.AutoSize = true;
            this.maxDiameterUnitsTxt.BackColor = System.Drawing.Color.Transparent;
            this.maxDiameterUnitsTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxDiameterUnitsTxt.Location = new System.Drawing.Point(209, 77);
            this.maxDiameterUnitsTxt.Name = "maxDiameterUnitsTxt";
            this.maxDiameterUnitsTxt.Size = new System.Drawing.Size(40, 21);
            this.maxDiameterUnitsTxt.TabIndex = 95;
            this.maxDiameterUnitsTxt.Text = "mm";
            // 
            // txtMinDiameter
            // 
            this.txtMinDiameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinDiameter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtMinDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinDiameter.Location = new System.Drawing.Point(79, 120);
            this.txtMinDiameter.MaxLength = 10;
            this.txtMinDiameter.Name = "txtMinDiameter";
            this.txtMinDiameter.Size = new System.Drawing.Size(125, 40);
            this.txtMinDiameter.TabIndex = 91;
            this.txtMinDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinDiameter.Click += new System.EventHandler(this.Txt_MinDiameter_Click);
            this.txtMinDiameter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_MinDiameter_KeyPress);
            // 
            // Label54
            // 
            this.Label54.AutoSize = true;
            this.Label54.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.Label54.Location = new System.Drawing.Point(4, 132);
            this.Label54.Name = "Label54";
            this.Label54.Size = new System.Drawing.Size(71, 25);
            this.Label54.TabIndex = 89;
            this.Label54.Text = "Min D:";
            // 
            // Label55
            // 
            this.Label55.AutoSize = true;
            this.Label55.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.Label55.Location = new System.Drawing.Point(3, 79);
            this.Label55.Name = "Label55";
            this.Label55.Size = new System.Drawing.Size(75, 25);
            this.Label55.TabIndex = 88;
            this.Label55.Text = "Max D:";
            // 
            // txtMaxDiameter
            // 
            this.txtMaxDiameter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMaxDiameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxDiameter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtMaxDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxDiameter.Location = new System.Drawing.Point(79, 62);
            this.txtMaxDiameter.MaxLength = 10;
            this.txtMaxDiameter.Name = "txtMaxDiameter";
            this.txtMaxDiameter.Size = new System.Drawing.Size(125, 40);
            this.txtMaxDiameter.TabIndex = 87;
            this.txtMaxDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMaxDiameter.Click += new System.EventHandler(this.Txt_MaxDiameter_Click);
            this.txtMaxDiameter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_MaxDiameter_KeyPress);
            // 
            // GroupSelectGrid
            // 
            this.GroupSelectGrid.Controls.Add(this.grid_16);
            this.GroupSelectGrid.Controls.Add(this.grid_12);
            this.GroupSelectGrid.Controls.Add(this.grid_6);
            this.GroupSelectGrid.Controls.Add(this.grid_5);
            this.GroupSelectGrid.Controls.Add(this.grid_9);
            this.GroupSelectGrid.Controls.Add(this.grid_4);
            this.GroupSelectGrid.Font = new System.Drawing.Font("Alef", 10F);
            this.GroupSelectGrid.Location = new System.Drawing.Point(286, 524);
            this.GroupSelectGrid.Name = "GroupSelectGrid";
            this.GroupSelectGrid.Size = new System.Drawing.Size(178, 179);
            this.GroupSelectGrid.TabIndex = 109;
            this.GroupSelectGrid.TabStop = false;
            this.GroupSelectGrid.Text = "Selected Grid";
            // 
            // grid_16
            // 
            this.grid_16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_16.BackColor = System.Drawing.Color.Silver;
            this.grid_16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.grid_16.Location = new System.Drawing.Point(92, 121);
            this.grid_16.Name = "grid_16";
            this.grid_16.Size = new System.Drawing.Size(67, 42);
            this.grid_16.TabIndex = 75;
            this.grid_16.Text = "2x3";
            this.grid_16.UseVisualStyleBackColor = false;
            this.grid_16.Visible = false;
            this.grid_16.Click += new System.EventHandler(this.Cmd_Program_6_Click);
            // 
            // grid_12
            // 
            this.grid_12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_12.BackColor = System.Drawing.Color.Silver;
            this.grid_12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.grid_12.Location = new System.Drawing.Point(19, 121);
            this.grid_12.Name = "grid_12";
            this.grid_12.Size = new System.Drawing.Size(67, 42);
            this.grid_12.TabIndex = 74;
            this.grid_12.Text = "3x4";
            this.grid_12.UseVisualStyleBackColor = false;
            this.grid_12.Visible = false;
            this.grid_12.Click += new System.EventHandler(this.Cmd_Program_5_Click);
            // 
            // grid_6
            // 
            this.grid_6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_6.BackColor = System.Drawing.Color.Silver;
            this.grid_6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.grid_6.Location = new System.Drawing.Point(19, 73);
            this.grid_6.Name = "grid_6";
            this.grid_6.Size = new System.Drawing.Size(67, 42);
            this.grid_6.TabIndex = 73;
            this.grid_6.Text = "4x4";
            this.grid_6.UseVisualStyleBackColor = false;
            this.grid_6.Click += new System.EventHandler(this.grid_6_Click);
            // 
            // grid_5
            // 
            this.grid_5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_5.BackColor = System.Drawing.Color.Silver;
            this.grid_5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.grid_5.Location = new System.Drawing.Point(92, 70);
            this.grid_5.Name = "grid_5";
            this.grid_5.Size = new System.Drawing.Size(67, 42);
            this.grid_5.TabIndex = 72;
            this.grid_5.Text = "2x1x2";
            this.grid_5.UseVisualStyleBackColor = false;
            this.grid_5.Click += new System.EventHandler(this.grid_5_Click);
            // 
            // grid_9
            // 
            this.grid_9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_9.BackColor = System.Drawing.Color.Silver;
            this.grid_9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.grid_9.Location = new System.Drawing.Point(92, 23);
            this.grid_9.Name = "grid_9";
            this.grid_9.Size = new System.Drawing.Size(67, 42);
            this.grid_9.TabIndex = 70;
            this.grid_9.Text = "2x2";
            this.grid_9.UseVisualStyleBackColor = false;
            this.grid_9.Click += new System.EventHandler(this.grid_9_Click);
            // 
            // grid_4
            // 
            this.grid_4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_4.BackColor = System.Drawing.Color.Silver;
            this.grid_4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.grid_4.Location = new System.Drawing.Point(19, 25);
            this.grid_4.Name = "grid_4";
            this.grid_4.Size = new System.Drawing.Size(67, 42);
            this.grid_4.TabIndex = 71;
            this.grid_4.Text = "3x3";
            this.grid_4.UseVisualStyleBackColor = false;
            this.grid_4.Click += new System.EventHandler(this.grid_4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 536);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 114;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(778, 379);
            this.dataGridView1.TabIndex = 117;
            // 
            // controlsTabs
            // 
            this.controlsTabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.controlsTabs.Controls.Add(this.mainControlPage);
            this.controlsTabs.Controls.Add(this.configurationPage);
            this.controlsTabs.Controls.Add(this.advancedPage);
            this.controlsTabs.Controls.Add(this.aboutPage);
            this.controlsTabs.Cursor = System.Windows.Forms.Cursors.Default;
            this.controlsTabs.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlsTabs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlsTabs.ItemSize = new System.Drawing.Size(58, 40);
            this.controlsTabs.Location = new System.Drawing.Point(787, 0);
            this.controlsTabs.Name = "controlsTabs";
            this.controlsTabs.Padding = new System.Drawing.Point(20, 3);
            this.controlsTabs.SelectedIndex = 0;
            this.controlsTabs.Size = new System.Drawing.Size(480, 876);
            this.controlsTabs.TabIndex = 118;
            // 
            // mainControlPage
            // 
            this.mainControlPage.BackColor = System.Drawing.Color.LightSteelBlue;
            this.mainControlPage.Controls.Add(this.groupBox5);
            this.mainControlPage.Controls.Add(this.GroupSelectGrid);
            this.mainControlPage.Controls.Add(this.groupBox2);
            this.mainControlPage.Controls.Add(this.GroupBox1);
            this.mainControlPage.Controls.Add(this.GroupBox8);
            this.mainControlPage.Controls.Add(this.GroupActualTargetSize);
            this.mainControlPage.Cursor = System.Windows.Forms.Cursors.Default;
            this.mainControlPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainControlPage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mainControlPage.Location = new System.Drawing.Point(4, 44);
            this.mainControlPage.Name = "mainControlPage";
            this.mainControlPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainControlPage.Size = new System.Drawing.Size(472, 828);
            this.mainControlPage.TabIndex = 0;
            this.mainControlPage.Text = "OPERATION";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.lblCV);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.groupBox14);
            this.groupBox5.Controls.Add(this.txtEquivalentDiameterUnits);
            this.groupBox5.Controls.Add(this.lblSEQDiameter);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.btnFreezeFrame);
            this.groupBox5.Controls.Add(this.txtAvgMinDiameterUnits);
            this.groupBox5.Controls.Add(this.txtAvgMaxDiameterUnits);
            this.groupBox5.Controls.Add(this.txtAvgDiameterUnits);
            this.groupBox5.Controls.Add(this.lblAvgDiameter);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.lblMinDiameter);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.lblMaxDiameter);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox5.Location = new System.Drawing.Point(5, 148);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(462, 149);
            this.groupBox5.TabIndex = 115;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Frame Results";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label25.Location = new System.Drawing.Point(382, 99);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(23, 21);
            this.label25.TabIndex = 135;
            this.label25.Text = "%";
            // 
            // lblCV
            // 
            this.lblCV.AutoSize = true;
            this.lblCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCV.Location = new System.Drawing.Point(321, 97);
            this.lblCV.Name = "lblCV";
            this.lblCV.Size = new System.Drawing.Size(18, 20);
            this.lblCV.TabIndex = 134;
            this.lblCV.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(211, 97);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(82, 20);
            this.label24.TabIndex = 133;
            this.label24.Text = "Var. Coeff:";
            // 
            // groupBox14
            // 
            this.groupBox14.BackColor = System.Drawing.Color.Transparent;
            this.groupBox14.Controls.Add(this.txtValidObjects);
            this.groupBox14.Location = new System.Drawing.Point(15, 25);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(143, 57);
            this.groupBox14.TabIndex = 132;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Valid Objects";
            // 
            // txtValidObjects
            // 
            this.txtValidObjects.AutoSize = true;
            this.txtValidObjects.BackColor = System.Drawing.Color.Transparent;
            this.txtValidObjects.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtValidObjects.Location = new System.Drawing.Point(59, 19);
            this.txtValidObjects.Name = "txtValidObjects";
            this.txtValidObjects.Size = new System.Drawing.Size(25, 30);
            this.txtValidObjects.TabIndex = 127;
            this.txtValidObjects.Text = "0";
            // 
            // txtEquivalentDiameterUnits
            // 
            this.txtEquivalentDiameterUnits.AutoSize = true;
            this.txtEquivalentDiameterUnits.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEquivalentDiameterUnits.Location = new System.Drawing.Point(376, 120);
            this.txtEquivalentDiameterUnits.Name = "txtEquivalentDiameterUnits";
            this.txtEquivalentDiameterUnits.Size = new System.Drawing.Size(38, 21);
            this.txtEquivalentDiameterUnits.TabIndex = 126;
            this.txtEquivalentDiameterUnits.Text = "mm";
            // 
            // lblSEQDiameter
            // 
            this.lblSEQDiameter.AutoSize = true;
            this.lblSEQDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSEQDiameter.Location = new System.Drawing.Point(321, 121);
            this.lblSEQDiameter.Name = "lblSEQDiameter";
            this.lblSEQDiameter.Size = new System.Drawing.Size(18, 20);
            this.lblSEQDiameter.TabIndex = 0;
            this.lblSEQDiameter.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(184, 119);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 20);
            this.label14.TabIndex = 131;
            this.label14.Text = "SEQ Diameter:";
            // 
            // btnFreezeFrame
            // 
            this.btnFreezeFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFreezeFrame.BackColor = System.Drawing.Color.Silver;
            this.btnFreezeFrame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFreezeFrame.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFreezeFrame.Location = new System.Drawing.Point(13, 84);
            this.btnFreezeFrame.Name = "btnFreezeFrame";
            this.btnFreezeFrame.Size = new System.Drawing.Size(145, 59);
            this.btnFreezeFrame.TabIndex = 129;
            this.btnFreezeFrame.Text = "FREEZE RESULTS";
            this.btnFreezeFrame.UseVisualStyleBackColor = false;
            this.btnFreezeFrame.Click += new System.EventHandler(this.btnFreezeFrame_Click);
            // 
            // txtAvgMinDiameterUnits
            // 
            this.txtAvgMinDiameterUnits.AutoSize = true;
            this.txtAvgMinDiameterUnits.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAvgMinDiameterUnits.Location = new System.Drawing.Point(376, 71);
            this.txtAvgMinDiameterUnits.Name = "txtAvgMinDiameterUnits";
            this.txtAvgMinDiameterUnits.Size = new System.Drawing.Size(38, 21);
            this.txtAvgMinDiameterUnits.TabIndex = 125;
            this.txtAvgMinDiameterUnits.Text = "mm";
            // 
            // txtAvgMaxDiameterUnits
            // 
            this.txtAvgMaxDiameterUnits.AutoSize = true;
            this.txtAvgMaxDiameterUnits.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAvgMaxDiameterUnits.Location = new System.Drawing.Point(376, 42);
            this.txtAvgMaxDiameterUnits.Name = "txtAvgMaxDiameterUnits";
            this.txtAvgMaxDiameterUnits.Size = new System.Drawing.Size(38, 21);
            this.txtAvgMaxDiameterUnits.TabIndex = 124;
            this.txtAvgMaxDiameterUnits.Text = "mm";
            // 
            // txtAvgDiameterUnits
            // 
            this.txtAvgDiameterUnits.AutoSize = true;
            this.txtAvgDiameterUnits.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAvgDiameterUnits.Location = new System.Drawing.Point(376, 16);
            this.txtAvgDiameterUnits.Name = "txtAvgDiameterUnits";
            this.txtAvgDiameterUnits.Size = new System.Drawing.Size(38, 21);
            this.txtAvgDiameterUnits.TabIndex = 123;
            this.txtAvgDiameterUnits.Text = "mm";
            // 
            // lblAvgDiameter
            // 
            this.lblAvgDiameter.AutoSize = true;
            this.lblAvgDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgDiameter.Location = new System.Drawing.Point(321, 17);
            this.lblAvgDiameter.Name = "lblAvgDiameter";
            this.lblAvgDiameter.Size = new System.Drawing.Size(18, 20);
            this.lblAvgDiameter.TabIndex = 0;
            this.lblAvgDiameter.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(184, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 20);
            this.label13.TabIndex = 122;
            this.label13.Text = "Avg Diameter:";
            // 
            // lblMinDiameter
            // 
            this.lblMinDiameter.AutoSize = true;
            this.lblMinDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinDiameter.Location = new System.Drawing.Point(321, 71);
            this.lblMinDiameter.Name = "lblMinDiameter";
            this.lblMinDiameter.Size = new System.Drawing.Size(18, 20);
            this.lblMinDiameter.TabIndex = 0;
            this.lblMinDiameter.Text = "0";
            this.lblMinDiameter.Click += new System.EventHandler(this.txtAvgMinD_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(184, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 20);
            this.label11.TabIndex = 120;
            this.label11.Text = "Max Diameter:";
            // 
            // lblMaxDiameter
            // 
            this.lblMaxDiameter.AutoSize = true;
            this.lblMaxDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxDiameter.Location = new System.Drawing.Point(321, 43);
            this.lblMaxDiameter.Name = "lblMaxDiameter";
            this.lblMaxDiameter.Size = new System.Drawing.Size(18, 20);
            this.lblMaxDiameter.TabIndex = 0;
            this.lblMaxDiameter.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(184, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 20);
            this.label12.TabIndex = 121;
            this.label12.Text = "Min Diameter:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.flagValidFrames);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.dplControlDiameter);
            this.groupBox2.Controls.Add(this.txtControlDiameter);
            this.groupBox2.Controls.Add(this.groupBox12);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtControlDiameterUnits);
            this.groupBox2.Font = new System.Drawing.Font("Alef", 10F);
            this.groupBox2.Location = new System.Drawing.Point(5, 301);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(462, 138);
            this.groupBox2.TabIndex = 114;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System Results";
            // 
            // flagValidFrames
            // 
            this.flagValidFrames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flagValidFrames.BackColor = System.Drawing.Color.Silver;
            this.flagValidFrames.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flagValidFrames.Enabled = false;
            this.flagValidFrames.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flagValidFrames.Location = new System.Drawing.Point(368, 92);
            this.flagValidFrames.Name = "flagValidFrames";
            this.flagValidFrames.Size = new System.Drawing.Size(76, 26);
            this.flagValidFrames.TabIndex = 136;
            this.flagValidFrames.Text = "0";
            this.flagValidFrames.UseVisualStyleBackColor = false;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(193, 94);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(98, 20);
            this.label33.TabIndex = 136;
            this.label33.Text = "Valid Frames";
            // 
            // dplControlDiameter
            // 
            this.dplControlDiameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dplControlDiameter.BackColor = System.Drawing.Color.Silver;
            this.dplControlDiameter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dplControlDiameter.Enabled = false;
            this.dplControlDiameter.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.dplControlDiameter.Location = new System.Drawing.Point(8, 79);
            this.dplControlDiameter.Name = "dplControlDiameter";
            this.dplControlDiameter.Size = new System.Drawing.Size(106, 44);
            this.dplControlDiameter.TabIndex = 136;
            this.dplControlDiameter.Text = "0";
            this.dplControlDiameter.UseVisualStyleBackColor = false;
            // 
            // txtControlDiameter
            // 
            this.txtControlDiameter.AutoSize = true;
            this.txtControlDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControlDiameter.Location = new System.Drawing.Point(34, 88);
            this.txtControlDiameter.Name = "txtControlDiameter";
            this.txtControlDiameter.Size = new System.Drawing.Size(26, 29);
            this.txtControlDiameter.TabIndex = 0;
            this.txtControlDiameter.Text = "0";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label23);
            this.groupBox12.Controls.Add(this.flagAlign);
            this.groupBox12.Controls.Add(this.label22);
            this.groupBox12.Controls.Add(this.flagFH);
            this.groupBox12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox12.Location = new System.Drawing.Point(174, 12);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(282, 120);
            this.groupBox12.TabIndex = 136;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Last 10 Frames";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(19, 51);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(141, 20);
            this.label23.TabIndex = 135;
            this.label23.Text = "Diameter Variation";
            // 
            // flagAlign
            // 
            this.flagAlign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flagAlign.BackColor = System.Drawing.Color.Silver;
            this.flagAlign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flagAlign.Enabled = false;
            this.flagAlign.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flagAlign.Location = new System.Drawing.Point(194, 49);
            this.flagAlign.Name = "flagAlign";
            this.flagAlign.Size = new System.Drawing.Size(76, 26);
            this.flagAlign.TabIndex = 131;
            this.flagAlign.Text = "0";
            this.flagAlign.UseVisualStyleBackColor = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(19, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(105, 20);
            this.label22.TabIndex = 134;
            this.label22.Text = "Holes Present";
            // 
            // flagFH
            // 
            this.flagFH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flagFH.BackColor = System.Drawing.Color.Silver;
            this.flagFH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flagFH.Enabled = false;
            this.flagFH.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flagFH.Location = new System.Drawing.Point(194, 21);
            this.flagFH.Name = "flagFH";
            this.flagFH.Size = new System.Drawing.Size(76, 24);
            this.flagFH.TabIndex = 129;
            this.flagFH.Text = "0";
            this.flagFH.UseVisualStyleBackColor = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(11, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(132, 42);
            this.label15.TabIndex = 132;
            this.label15.Text = "Process Control \r\nDiameter:";
            // 
            // txtControlDiameterUnits
            // 
            this.txtControlDiameterUnits.AutoSize = true;
            this.txtControlDiameterUnits.Font = new System.Drawing.Font("Alef", 14F);
            this.txtControlDiameterUnits.Location = new System.Drawing.Point(120, 94);
            this.txtControlDiameterUnits.Name = "txtControlDiameterUnits";
            this.txtControlDiameterUnits.Size = new System.Drawing.Size(46, 26);
            this.txtControlDiameterUnits.TabIndex = 126;
            this.txtControlDiameterUnits.Text = "mm";
            // 
            // configurationPage
            // 
            this.configurationPage.BackColor = System.Drawing.Color.LightSteelBlue;
            this.configurationPage.Controls.Add(this.groupBox16);
            this.configurationPage.Controls.Add(this.gbShapeIndicator);
            this.configurationPage.Controls.Add(this.groupBox4);
            this.configurationPage.Controls.Add(this.GB_Threshold);
            this.configurationPage.Controls.Add(this.boxROI);
            this.configurationPage.Controls.Add(this.boxUnits);
            this.configurationPage.Font = new System.Drawing.Font("Alef", 10F);
            this.configurationPage.Location = new System.Drawing.Point(4, 44);
            this.configurationPage.Name = "configurationPage";
            this.configurationPage.Padding = new System.Windows.Forms.Padding(3);
            this.configurationPage.Size = new System.Drawing.Size(472, 828);
            this.configurationPage.TabIndex = 1;
            this.configurationPage.Text = "CONFIG";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.btnLinesFilter);
            this.groupBox16.Controls.Add(this.btn90DegDiameters);
            this.groupBox16.Location = new System.Drawing.Point(6, 669);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(458, 100);
            this.groupBox16.TabIndex = 131;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Parameters";
            // 
            // btnLinesFilter
            // 
            this.btnLinesFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLinesFilter.AutoSize = true;
            this.btnLinesFilter.BackColor = System.Drawing.Color.Silver;
            this.btnLinesFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLinesFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLinesFilter.Location = new System.Drawing.Point(145, 38);
            this.btnLinesFilter.Name = "btnLinesFilter";
            this.btnLinesFilter.Size = new System.Drawing.Size(103, 42);
            this.btnLinesFilter.TabIndex = 126;
            this.btnLinesFilter.Text = "Lines Filter";
            this.btnLinesFilter.UseVisualStyleBackColor = false;
            this.btnLinesFilter.Click += new System.EventHandler(this.btnLinesFilter_Click);
            // 
            // btn90DegDiameters
            // 
            this.btn90DegDiameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn90DegDiameters.AutoSize = true;
            this.btn90DegDiameters.BackColor = System.Drawing.Color.Silver;
            this.btn90DegDiameters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn90DegDiameters.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn90DegDiameters.Location = new System.Drawing.Point(29, 38);
            this.btn90DegDiameters.Name = "btn90DegDiameters";
            this.btn90DegDiameters.Size = new System.Drawing.Size(86, 42);
            this.btn90DegDiameters.TabIndex = 125;
            this.btn90DegDiameters.Text = "DIA. 90°";
            this.btn90DegDiameters.UseVisualStyleBackColor = false;
            this.btn90DegDiameters.Click += new System.EventHandler(this.btn90DegDiameters_Click);
            // 
            // gbShapeIndicator
            // 
            this.gbShapeIndicator.Controls.Add(this.label21);
            this.gbShapeIndicator.Controls.Add(this.txtCompacityHoleLimit);
            this.gbShapeIndicator.Controls.Add(this.label20);
            this.gbShapeIndicator.Controls.Add(this.txtMaxCompacity);
            this.gbShapeIndicator.Location = new System.Drawing.Point(234, 272);
            this.gbShapeIndicator.Name = "gbShapeIndicator";
            this.gbShapeIndicator.Size = new System.Drawing.Size(230, 174);
            this.gbShapeIndicator.TabIndex = 130;
            this.gbShapeIndicator.TabStop = false;
            this.gbShapeIndicator.Text = "Shape Indicator Limits";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(11, 109);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 24);
            this.label21.TabIndex = 137;
            this.label21.Text = "Hole:";
            // 
            // txtCompacityHoleLimit
            // 
            this.txtCompacityHoleLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompacityHoleLimit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCompacityHoleLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompacityHoleLimit.Location = new System.Drawing.Point(106, 98);
            this.txtCompacityHoleLimit.MaxLength = 10;
            this.txtCompacityHoleLimit.Name = "txtCompacityHoleLimit";
            this.txtCompacityHoleLimit.Size = new System.Drawing.Size(98, 40);
            this.txtCompacityHoleLimit.TabIndex = 136;
            this.txtCompacityHoleLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCompacityHoleLimit.Click += new System.EventHandler(this.txtCompacityHoleLimit_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(11, 54);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(78, 24);
            this.label20.TabIndex = 135;
            this.label20.Text = "Round:";
            // 
            // txtMaxCompacity
            // 
            this.txtMaxCompacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaxCompacity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtMaxCompacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxCompacity.Location = new System.Drawing.Point(106, 43);
            this.txtMaxCompacity.MaxLength = 10;
            this.txtMaxCompacity.Name = "txtMaxCompacity";
            this.txtMaxCompacity.Size = new System.Drawing.Size(98, 40);
            this.txtMaxCompacity.TabIndex = 129;
            this.txtMaxCompacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMaxCompacity.Click += new System.EventHandler(this.Txt_MaxCompacity_Click);
            this.txtMaxCompacity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_MaxCompacity_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.btnLogin);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.btnLogoff);
            this.groupBox4.Controls.Add(this.txtPassword);
            this.groupBox4.Controls.Add(this.txtUser);
            this.groupBox4.Location = new System.Drawing.Point(6, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(458, 187);
            this.groupBox4.TabIndex = 127;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Login";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 21.75F);
            this.label16.Location = new System.Drawing.Point(35, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(142, 40);
            this.label16.TabIndex = 126;
            this.label16.Text = "Password:";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.AutoSize = true;
            this.btnLogin.BackColor = System.Drawing.Color.Silver;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Location = new System.Drawing.Point(85, 134);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(117, 42);
            this.btnLogin.TabIndex = 122;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 21.75F);
            this.label10.Location = new System.Drawing.Point(35, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 40);
            this.label10.TabIndex = 122;
            this.label10.Text = "User:";
            // 
            // btnLogoff
            // 
            this.btnLogoff.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogoff.AutoSize = true;
            this.btnLogoff.BackColor = System.Drawing.Color.Silver;
            this.btnLogoff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogoff.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLogoff.Location = new System.Drawing.Point(253, 132);
            this.btnLogoff.Name = "btnLogoff";
            this.btnLogoff.Size = new System.Drawing.Size(117, 42);
            this.btnLogoff.TabIndex = 124;
            this.btnLogoff.Text = "LOGOFF";
            this.btnLogoff.UseVisualStyleBackColor = false;
            this.btnLogoff.Click += new System.EventHandler(this.btnLogoff_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtPassword.Location = new System.Drawing.Point(227, 75);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(164, 35);
            this.txtPassword.TabIndex = 125;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
            // 
            // txtUser
            // 
            this.txtUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtUser.Location = new System.Drawing.Point(227, 23);
            this.txtUser.MaxLength = 20;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(164, 35);
            this.txtUser.TabIndex = 124;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUser.Click += new System.EventHandler(this.txtUser_Click);
            // 
            // GB_Threshold
            // 
            this.GB_Threshold.Controls.Add(this.btnAutoThreshold);
            this.GB_Threshold.Controls.Add(this.btnManualThreshold);
            this.GB_Threshold.Controls.Add(this.txtThreshold);
            this.GB_Threshold.Font = new System.Drawing.Font("Alef", 10F);
            this.GB_Threshold.Location = new System.Drawing.Point(6, 272);
            this.GB_Threshold.Name = "GB_Threshold";
            this.GB_Threshold.Size = new System.Drawing.Size(222, 174);
            this.GB_Threshold.TabIndex = 123;
            this.GB_Threshold.TabStop = false;
            this.GB_Threshold.Text = "Binary Threshold";
            // 
            // btnAutoThreshold
            // 
            this.btnAutoThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAutoThreshold.AutoSize = true;
            this.btnAutoThreshold.BackColor = System.Drawing.Color.Silver;
            this.btnAutoThreshold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoThreshold.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAutoThreshold.Location = new System.Drawing.Point(26, 48);
            this.btnAutoThreshold.Name = "btnAutoThreshold";
            this.btnAutoThreshold.Size = new System.Drawing.Size(86, 42);
            this.btnAutoThreshold.TabIndex = 123;
            this.btnAutoThreshold.Text = "AUTO";
            this.btnAutoThreshold.UseVisualStyleBackColor = false;
            this.btnAutoThreshold.Click += new System.EventHandler(this.btnAutoThreshold_Click);
            // 
            // btnManualThreshold
            // 
            this.btnManualThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnManualThreshold.AutoSize = true;
            this.btnManualThreshold.BackColor = System.Drawing.Color.Silver;
            this.btnManualThreshold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManualThreshold.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnManualThreshold.Location = new System.Drawing.Point(26, 109);
            this.btnManualThreshold.Name = "btnManualThreshold";
            this.btnManualThreshold.Size = new System.Drawing.Size(85, 42);
            this.btnManualThreshold.TabIndex = 122;
            this.btnManualThreshold.Text = "MANUAL";
            this.btnManualThreshold.UseVisualStyleBackColor = false;
            this.btnManualThreshold.Click += new System.EventHandler(this.btnManualThreshold_Click);
            // 
            // txtThreshold
            // 
            this.txtThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThreshold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThreshold.Location = new System.Drawing.Point(121, 83);
            this.txtThreshold.MaxLength = 3;
            this.txtThreshold.Name = "txtThreshold";
            this.txtThreshold.Size = new System.Drawing.Size(88, 40);
            this.txtThreshold.TabIndex = 12;
            this.txtThreshold.Text = "0";
            this.txtThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtThreshold.Click += new System.EventHandler(this.Txt_Threshold_Click);
            this.txtThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Threshold_KeyPress);
            // 
            // boxROI
            // 
            this.boxROI.Controls.Add(this.btnDecrementRoiHeight);
            this.boxROI.Controls.Add(this.btnIncrementRoiHeight);
            this.boxROI.Controls.Add(this.txtRoiHeight);
            this.boxROI.Controls.Add(this.btnDecrementRoiWidth);
            this.boxROI.Controls.Add(this.btnIncrementRoiWidth);
            this.boxROI.Controls.Add(this.label3);
            this.boxROI.Controls.Add(this.label2);
            this.boxROI.Controls.Add(this.txtRoiWidth);
            this.boxROI.Location = new System.Drawing.Point(6, 450);
            this.boxROI.Name = "boxROI";
            this.boxROI.Size = new System.Drawing.Size(458, 213);
            this.boxROI.TabIndex = 121;
            this.boxROI.TabStop = false;
            this.boxROI.Text = "ROI Definition";
            // 
            // btnDecrementRoiHeight
            // 
            this.btnDecrementRoiHeight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDecrementRoiHeight.Font = new System.Drawing.Font("Alef", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrementRoiHeight.Location = new System.Drawing.Point(343, 127);
            this.btnDecrementRoiHeight.Name = "btnDecrementRoiHeight";
            this.btnDecrementRoiHeight.Size = new System.Drawing.Size(75, 48);
            this.btnDecrementRoiHeight.TabIndex = 134;
            this.btnDecrementRoiHeight.Text = "-";
            this.btnDecrementRoiHeight.UseVisualStyleBackColor = true;
            this.btnDecrementRoiHeight.Click += new System.EventHandler(this.btnDecrementRoiHeight_Click);
            // 
            // btnIncrementRoiHeight
            // 
            this.btnIncrementRoiHeight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncrementRoiHeight.Font = new System.Drawing.Font("Alef", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncrementRoiHeight.Location = new System.Drawing.Point(343, 74);
            this.btnIncrementRoiHeight.Name = "btnIncrementRoiHeight";
            this.btnIncrementRoiHeight.Size = new System.Drawing.Size(75, 48);
            this.btnIncrementRoiHeight.TabIndex = 133;
            this.btnIncrementRoiHeight.Text = "+";
            this.btnIncrementRoiHeight.UseVisualStyleBackColor = true;
            this.btnIncrementRoiHeight.Click += new System.EventHandler(this.btnIncrementRoiHeight_Click);
            // 
            // txtRoiHeight
            // 
            this.txtRoiHeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRoiHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoiHeight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtRoiHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoiHeight.Location = new System.Drawing.Point(238, 98);
            this.txtRoiHeight.MaxLength = 10;
            this.txtRoiHeight.Name = "txtRoiHeight";
            this.txtRoiHeight.Size = new System.Drawing.Size(100, 49);
            this.txtRoiHeight.TabIndex = 132;
            this.txtRoiHeight.Text = "0";
            this.txtRoiHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRoiHeight.Click += new System.EventHandler(this.txtRoiHeight_Click);
            this.txtRoiHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoiHeight_KeyPress);
            // 
            // btnDecrementRoiWidth
            // 
            this.btnDecrementRoiWidth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDecrementRoiWidth.Font = new System.Drawing.Font("Alef", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrementRoiWidth.Location = new System.Drawing.Point(156, 127);
            this.btnDecrementRoiWidth.Name = "btnDecrementRoiWidth";
            this.btnDecrementRoiWidth.Size = new System.Drawing.Size(75, 48);
            this.btnDecrementRoiWidth.TabIndex = 131;
            this.btnDecrementRoiWidth.Text = "-";
            this.btnDecrementRoiWidth.UseVisualStyleBackColor = true;
            this.btnDecrementRoiWidth.Click += new System.EventHandler(this.btnDecrementRoiWidth_Click);
            // 
            // btnIncrementRoiWidth
            // 
            this.btnIncrementRoiWidth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncrementRoiWidth.Font = new System.Drawing.Font("Alef", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncrementRoiWidth.Location = new System.Drawing.Point(156, 74);
            this.btnIncrementRoiWidth.Name = "btnIncrementRoiWidth";
            this.btnIncrementRoiWidth.Size = new System.Drawing.Size(75, 48);
            this.btnIncrementRoiWidth.TabIndex = 130;
            this.btnIncrementRoiWidth.Text = "+";
            this.btnIncrementRoiWidth.UseVisualStyleBackColor = true;
            this.btnIncrementRoiWidth.Click += new System.EventHandler(this.btnIncrementRoiWidth_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(284, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 24);
            this.label3.TabIndex = 129;
            this.label3.Text = "ROI Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 24);
            this.label2.TabIndex = 128;
            this.label2.Text = "ROI Width";
            // 
            // txtRoiWidth
            // 
            this.txtRoiWidth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRoiWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoiWidth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtRoiWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoiWidth.Location = new System.Drawing.Point(51, 98);
            this.txtRoiWidth.MaxLength = 10;
            this.txtRoiWidth.Name = "txtRoiWidth";
            this.txtRoiWidth.Size = new System.Drawing.Size(100, 49);
            this.txtRoiWidth.TabIndex = 87;
            this.txtRoiWidth.Text = "0";
            this.txtRoiWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRoiWidth.Click += new System.EventHandler(this.txtRoiWidth_Click);
            this.txtRoiWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoiWidth_KeyPress);
            // 
            // boxUnits
            // 
            this.boxUnits.Controls.Add(this.btnChangeUnitsInch);
            this.boxUnits.Controls.Add(this.btnChangeUnitsMm);
            this.boxUnits.Font = new System.Drawing.Font("Alef", 10F);
            this.boxUnits.Location = new System.Drawing.Point(6, 191);
            this.boxUnits.Name = "boxUnits";
            this.boxUnits.Size = new System.Drawing.Size(458, 72);
            this.boxUnits.TabIndex = 117;
            this.boxUnits.TabStop = false;
            this.boxUnits.Text = "Units";
            // 
            // btnChangeUnitsInch
            // 
            this.btnChangeUnitsInch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangeUnitsInch.AutoSize = true;
            this.btnChangeUnitsInch.BackColor = System.Drawing.Color.Silver;
            this.btnChangeUnitsInch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeUnitsInch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnChangeUnitsInch.Location = new System.Drawing.Point(238, 21);
            this.btnChangeUnitsInch.Name = "btnChangeUnitsInch";
            this.btnChangeUnitsInch.Size = new System.Drawing.Size(85, 42);
            this.btnChangeUnitsInch.TabIndex = 121;
            this.btnChangeUnitsInch.Text = "inch";
            this.btnChangeUnitsInch.UseVisualStyleBackColor = false;
            this.btnChangeUnitsInch.Click += new System.EventHandler(this.btnChangeUnitsInch_Click);
            // 
            // btnChangeUnitsMm
            // 
            this.btnChangeUnitsMm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangeUnitsMm.AutoSize = true;
            this.btnChangeUnitsMm.BackColor = System.Drawing.Color.Silver;
            this.btnChangeUnitsMm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeUnitsMm.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnChangeUnitsMm.Location = new System.Drawing.Point(121, 22);
            this.btnChangeUnitsMm.Name = "btnChangeUnitsMm";
            this.btnChangeUnitsMm.Size = new System.Drawing.Size(85, 42);
            this.btnChangeUnitsMm.TabIndex = 120;
            this.btnChangeUnitsMm.Text = "mm";
            this.btnChangeUnitsMm.UseVisualStyleBackColor = false;
            this.btnChangeUnitsMm.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // advancedPage
            // 
            this.advancedPage.BackColor = System.Drawing.Color.LightSteelBlue;
            this.advancedPage.Controls.Add(this.groupBox11);
            this.advancedPage.Controls.Add(this.groupBox7);
            this.advancedPage.Controls.Add(this.groupBox6);
            this.advancedPage.Controls.Add(this.groupBox3);
            this.advancedPage.Font = new System.Drawing.Font("Alef", 10F);
            this.advancedPage.Location = new System.Drawing.Point(4, 44);
            this.advancedPage.Name = "advancedPage";
            this.advancedPage.Size = new System.Drawing.Size(472, 828);
            this.advancedPage.TabIndex = 2;
            this.advancedPage.Text = "ADVANCED";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label35);
            this.groupBox11.Controls.Add(this.txtValidFramesLimit);
            this.groupBox11.Controls.Add(this.label30);
            this.groupBox11.Controls.Add(this.txtAlign);
            this.groupBox11.Controls.Add(this.label26);
            this.groupBox11.Controls.Add(this.txtFFH);
            this.groupBox11.Controls.Add(this.label29);
            this.groupBox11.Controls.Add(this.txtFH);
            this.groupBox11.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox11.Location = new System.Drawing.Point(6, 357);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(458, 248);
            this.groupBox11.TabIndex = 120;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Flags Parameters";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(43, 190);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(166, 25);
            this.label35.TabIndex = 93;
            this.label35.Text = "Val. Frames Limit:";
            // 
            // txtValidFramesLimit
            // 
            this.txtValidFramesLimit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtValidFramesLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValidFramesLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValidFramesLimit.Location = new System.Drawing.Point(251, 178);
            this.txtValidFramesLimit.MaxLength = 5;
            this.txtValidFramesLimit.Name = "txtValidFramesLimit";
            this.txtValidFramesLimit.Size = new System.Drawing.Size(100, 44);
            this.txtValidFramesLimit.TabIndex = 92;
            this.txtValidFramesLimit.Text = "0";
            this.txtValidFramesLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValidFramesLimit.Click += new System.EventHandler(this.txtValidFramesLimit_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(43, 140);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(186, 25);
            this.label30.TabIndex = 91;
            this.label30.Text = "Dia. Variation Limit:";
            // 
            // txtAlign
            // 
            this.txtAlign.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAlign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlign.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlign.Location = new System.Drawing.Point(251, 128);
            this.txtAlign.MaxLength = 5;
            this.txtAlign.Name = "txtAlign";
            this.txtAlign.Size = new System.Drawing.Size(100, 44);
            this.txtAlign.TabIndex = 90;
            this.txtAlign.Text = "0";
            this.txtAlign.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAlign.Click += new System.EventHandler(this.txtAlign_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(44, 90);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(199, 25);
            this.label26.TabIndex = 89;
            this.label26.Text = "Very Frequent Holes:";
            // 
            // txtFFH
            // 
            this.txtFFH.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFFH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFFH.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFFH.Location = new System.Drawing.Point(251, 78);
            this.txtFFH.MaxLength = 5;
            this.txtFFH.Name = "txtFFH";
            this.txtFFH.Size = new System.Drawing.Size(100, 44);
            this.txtFFH.TabIndex = 88;
            this.txtFFH.Text = "0";
            this.txtFFH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFFH.Click += new System.EventHandler(this.txtFFH_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(44, 39);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(145, 25);
            this.label29.TabIndex = 9;
            this.label29.Text = "Fequent Holes:";
            // 
            // txtFH
            // 
            this.txtFH.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFH.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFH.Location = new System.Drawing.Point(251, 28);
            this.txtFH.MaxLength = 5;
            this.txtFH.Name = "txtFH";
            this.txtFH.Size = new System.Drawing.Size(100, 44);
            this.txtFH.TabIndex = 88;
            this.txtFH.Text = "0";
            this.txtFH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFH.Click += new System.EventHandler(this.txtFH_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnVideoSettings);
            this.groupBox7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox7.Location = new System.Drawing.Point(7, 605);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(457, 88);
            this.groupBox7.TabIndex = 129;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Video Settings";
            // 
            // btnVideoSettings
            // 
            this.btnVideoSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVideoSettings.AutoSize = true;
            this.btnVideoSettings.BackColor = System.Drawing.Color.Silver;
            this.btnVideoSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVideoSettings.Location = new System.Drawing.Point(150, 21);
            this.btnVideoSettings.Name = "btnVideoSettings";
            this.btnVideoSettings.Size = new System.Drawing.Size(194, 55);
            this.btnVideoSettings.TabIndex = 124;
            this.btnVideoSettings.Text = "Video Settings";
            this.btnVideoSettings.UseVisualStyleBackColor = false;
            this.btnVideoSettings.Click += new System.EventHandler(this.btnVideoSettings_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.txtMinBlobObjects);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.txtAlpha);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox6.Location = new System.Drawing.Point(6, 183);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(458, 167);
            this.groupBox6.TabIndex = 119;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Process Variable Parameters";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(89, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 25);
            this.label6.TabIndex = 89;
            this.label6.Text = "Min Objects:";
            // 
            // txtMinBlobObjects
            // 
            this.txtMinBlobObjects.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMinBlobObjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinBlobObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinBlobObjects.Location = new System.Drawing.Point(253, 105);
            this.txtMinBlobObjects.MaxLength = 5;
            this.txtMinBlobObjects.Name = "txtMinBlobObjects";
            this.txtMinBlobObjects.Size = new System.Drawing.Size(100, 44);
            this.txtMinBlobObjects.TabIndex = 88;
            this.txtMinBlobObjects.Text = "0";
            this.txtMinBlobObjects.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinBlobObjects.Click += new System.EventHandler(this.txtMinBlobObjects_Click);
            this.txtMinBlobObjects.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinBlobObjects_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(61, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Filter Constant:";
            // 
            // txtAlpha
            // 
            this.txtAlpha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAlpha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlpha.Location = new System.Drawing.Point(253, 34);
            this.txtAlpha.MaxLength = 5;
            this.txtAlpha.Name = "txtAlpha";
            this.txtAlpha.Size = new System.Drawing.Size(100, 44);
            this.txtAlpha.TabIndex = 88;
            this.txtAlpha.Text = "0";
            this.txtAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAlpha.Click += new System.EventHandler(this.txtAlpha_Click);
            this.txtAlpha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlpha_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCalibrateByHeight);
            this.groupBox3.Controls.Add(this.calibrateBtn);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblEuFactor);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(458, 174);
            this.groupBox3.TabIndex = 118;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Calibration";
            // 
            // btnCalibrateByHeight
            // 
            this.btnCalibrateByHeight.BackColor = System.Drawing.Color.Silver;
            this.btnCalibrateByHeight.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalibrateByHeight.Location = new System.Drawing.Point(247, 30);
            this.btnCalibrateByHeight.Name = "btnCalibrateByHeight";
            this.btnCalibrateByHeight.Size = new System.Drawing.Size(192, 82);
            this.btnCalibrateByHeight.TabIndex = 8;
            this.btnCalibrateByHeight.Text = "Calibrate by Height";
            this.btnCalibrateByHeight.UseVisualStyleBackColor = false;
            this.btnCalibrateByHeight.Click += new System.EventHandler(this.btnCalibrateByHeight_Click);
            // 
            // calibrateBtn
            // 
            this.calibrateBtn.BackColor = System.Drawing.Color.Silver;
            this.calibrateBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calibrateBtn.Location = new System.Drawing.Point(34, 30);
            this.calibrateBtn.Name = "calibrateBtn";
            this.calibrateBtn.Size = new System.Drawing.Size(182, 82);
            this.calibrateBtn.TabIndex = 4;
            this.calibrateBtn.Text = "Calibrate by Target";
            this.calibrateBtn.UseVisualStyleBackColor = false;
            this.calibrateBtn.Click += new System.EventHandler(this.calibrateButtom_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.label7.Location = new System.Drawing.Point(131, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Calibration Factor:";
            // 
            // lblEuFactor
            // 
            this.lblEuFactor.AutoSize = true;
            this.lblEuFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lblEuFactor.Location = new System.Drawing.Point(303, 129);
            this.lblEuFactor.Name = "lblEuFactor";
            this.lblEuFactor.Size = new System.Drawing.Size(35, 24);
            this.lblEuFactor.TabIndex = 7;
            this.lblEuFactor.Text = "1.0";
            // 
            // aboutPage
            // 
            this.aboutPage.BackColor = System.Drawing.Color.LightSteelBlue;
            this.aboutPage.Controls.Add(this.label18);
            this.aboutPage.Controls.Add(this.label4);
            this.aboutPage.Controls.Add(this.label34);
            this.aboutPage.Controls.Add(this.label19);
            this.aboutPage.Controls.Add(this.pictureBox1);
            this.aboutPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.aboutPage.Location = new System.Drawing.Point(4, 44);
            this.aboutPage.Name = "aboutPage";
            this.aboutPage.Size = new System.Drawing.Size(472, 828);
            this.aboutPage.TabIndex = 3;
            this.aboutPage.Text = "ABOUT";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label18.Location = new System.Drawing.Point(24, 259);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(435, 140);
            this.label18.TabIndex = 6;
            this.label18.Text = resources.GetString("label18.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label4.Location = new System.Drawing.Point(27, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(416, 56);
            this.label4.TabIndex = 5;
            this.label4.Text = "Copyright © 2024 SIOS Ingeniería S.A. de C.V. \r\nAll Rights Reserved";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(28, 148);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(149, 28);
            this.label34.TabIndex = 4;
            this.label34.Text = "VERSION 1.0.0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(208, 110);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 28);
            this.label19.TabIndex = 2;
            this.label19.Text = "STI-TC";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo.Properties.Resources.SIOS_LOGOTIPO_AZUL_SIMPLE;
            this.pictureBox1.Location = new System.Drawing.Point(140, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // mainTabs
            // 
            this.mainTabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.mainTabs.Controls.Add(this.imagePage);
            this.mainTabs.Controls.Add(this.tablePage);
            this.mainTabs.Controls.Add(this.trendPage);
            this.mainTabs.Controls.Add(this.productsPage);
            this.mainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabs.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTabs.ItemSize = new System.Drawing.Size(42, 40);
            this.mainTabs.Location = new System.Drawing.Point(0, 0);
            this.mainTabs.Name = "mainTabs";
            this.mainTabs.Padding = new System.Drawing.Point(20, 3);
            this.mainTabs.SelectedIndex = 0;
            this.mainTabs.Size = new System.Drawing.Size(1267, 876);
            this.mainTabs.TabIndex = 119;
            // 
            // imagePage
            // 
            this.imagePage.BackColor = System.Drawing.SystemColors.Control;
            this.imagePage.Controls.Add(this.boxOriginal);
            this.imagePage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.imagePage.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.imagePage.Location = new System.Drawing.Point(4, 44);
            this.imagePage.Name = "imagePage";
            this.imagePage.Padding = new System.Windows.Forms.Padding(3);
            this.imagePage.Size = new System.Drawing.Size(1259, 828);
            this.imagePage.TabIndex = 0;
            this.imagePage.Text = "CAMERA VIEW";
            // 
            // boxOriginal
            // 
            this.boxOriginal.AutoSize = true;
            this.boxOriginal.Controls.Add(this.boxProcess);
            this.boxOriginal.Location = new System.Drawing.Point(0, 0);
            this.boxOriginal.Name = "boxOriginal";
            this.boxOriginal.Size = new System.Drawing.Size(640, 480);
            this.boxOriginal.TabIndex = 119;
            this.boxOriginal.TabStop = false;
            // 
            // boxProcess
            // 
            this.boxProcess.Location = new System.Drawing.Point(166, 120);
            this.boxProcess.Name = "boxProcess";
            this.boxProcess.Size = new System.Drawing.Size(332, 228);
            this.boxProcess.TabIndex = 0;
            this.boxProcess.TabStop = false;
            // 
            // tablePage
            // 
            this.tablePage.Controls.Add(this.dataGridView1);
            this.tablePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tablePage.Location = new System.Drawing.Point(4, 44);
            this.tablePage.Name = "tablePage";
            this.tablePage.Padding = new System.Windows.Forms.Padding(3);
            this.tablePage.Size = new System.Drawing.Size(1259, 828);
            this.tablePage.TabIndex = 1;
            this.tablePage.Text = "METRICS TABLE";
            this.tablePage.UseVisualStyleBackColor = true;
            // 
            // trendPage
            // 
            this.trendPage.Controls.Add(this.btnClearChart);
            this.trendPage.Controls.Add(this.trendChart);
            this.trendPage.Location = new System.Drawing.Point(4, 44);
            this.trendPage.Name = "trendPage";
            this.trendPage.Size = new System.Drawing.Size(1259, 828);
            this.trendPage.TabIndex = 3;
            this.trendPage.Text = "TREND";
            this.trendPage.UseVisualStyleBackColor = true;
            // 
            // btnClearChart
            // 
            this.btnClearChart.BackColor = System.Drawing.Color.Silver;
            this.btnClearChart.Location = new System.Drawing.Point(340, 499);
            this.btnClearChart.Name = "btnClearChart";
            this.btnClearChart.Size = new System.Drawing.Size(179, 55);
            this.btnClearChart.TabIndex = 120;
            this.btnClearChart.Text = "CLEAR CHART";
            this.btnClearChart.UseVisualStyleBackColor = false;
            this.btnClearChart.Click += new System.EventHandler(this.btnClearChart_Click);
            // 
            // trendChart
            // 
            this.trendChart.BorderlineColor = System.Drawing.Color.Black;
            this.trendChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.trendChart.BorderlineWidth = 2;
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX.LabelStyle.Format = "HH:mm:ss";
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.ScrollBar.Enabled = false;
            chartArea1.AxisY.Maximum = 300D;
            chartArea1.Name = "ChartArea1";
            this.trendChart.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.trendChart.Legends.Add(legend1);
            this.trendChart.Location = new System.Drawing.Point(0, 0);
            this.trendChart.Name = "trendChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.LegendText = "Max Diameter";
            series1.Name = "MaxDiameterSerie";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.trendChart.Series.Add(series1);
            this.trendChart.Size = new System.Drawing.Size(806, 480);
            this.trendChart.TabIndex = 0;
            this.trendChart.Text = "chart1";
            // 
            // productsPage
            // 
            this.productsPage.Controls.Add(this.GroupBox13);
            this.productsPage.Controls.Add(this.GroupBox10);
            this.productsPage.Controls.Add(this.GroupBox9);
            this.productsPage.Location = new System.Drawing.Point(4, 44);
            this.productsPage.Name = "productsPage";
            this.productsPage.Padding = new System.Windows.Forms.Padding(3);
            this.productsPage.Size = new System.Drawing.Size(1259, 828);
            this.productsPage.TabIndex = 2;
            this.productsPage.Text = "PRODUCTS CATALOG";
            this.productsPage.UseVisualStyleBackColor = true;
            // 
            // GroupBox13
            // 
            this.GroupBox13.Controls.Add(this.Label47);
            this.GroupBox13.Controls.Add(this.Chk_Right_Side);
            this.GroupBox13.Controls.Add(this.Txt_Tag);
            this.GroupBox13.Controls.Add(this.Chk_Digital_Knife);
            this.GroupBox13.Enabled = false;
            this.GroupBox13.Location = new System.Drawing.Point(15, 405);
            this.GroupBox13.Name = "GroupBox13";
            this.GroupBox13.Size = new System.Drawing.Size(486, 122);
            this.GroupBox13.TabIndex = 122;
            this.GroupBox13.TabStop = false;
            this.GroupBox13.Text = "Misc";
            this.GroupBox13.Visible = false;
            // 
            // Label47
            // 
            this.Label47.AutoSize = true;
            this.Label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label47.Location = new System.Drawing.Point(6, 25);
            this.Label47.Name = "Label47";
            this.Label47.Size = new System.Drawing.Size(39, 16);
            this.Label47.TabIndex = 93;
            this.Label47.Text = "Tag:";
            // 
            // Chk_Right_Side
            // 
            this.Chk_Right_Side.AutoSize = true;
            this.Chk_Right_Side.Location = new System.Drawing.Point(49, 72);
            this.Chk_Right_Side.Name = "Chk_Right_Side";
            this.Chk_Right_Side.Size = new System.Drawing.Size(199, 32);
            this.Chk_Right_Side.TabIndex = 100;
            this.Chk_Right_Side.Text = "Installed Right Side";
            this.Chk_Right_Side.UseVisualStyleBackColor = true;
            // 
            // Txt_Tag
            // 
            this.Txt_Tag.Location = new System.Drawing.Point(49, 24);
            this.Txt_Tag.MaxLength = 20;
            this.Txt_Tag.Name = "Txt_Tag";
            this.Txt_Tag.Size = new System.Drawing.Size(150, 34);
            this.Txt_Tag.TabIndex = 94;
            this.Txt_Tag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Chk_Digital_Knife
            // 
            this.Chk_Digital_Knife.AutoSize = true;
            this.Chk_Digital_Knife.Checked = true;
            this.Chk_Digital_Knife.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_Digital_Knife.Location = new System.Drawing.Point(299, 42);
            this.Chk_Digital_Knife.Name = "Chk_Digital_Knife";
            this.Chk_Digital_Knife.Size = new System.Drawing.Size(138, 32);
            this.Chk_Digital_Knife.TabIndex = 95;
            this.Chk_Digital_Knife.Text = "Digital Knife";
            this.Chk_Digital_Knife.UseVisualStyleBackColor = true;
            // 
            // GroupBox10
            // 
            this.GroupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox10.Controls.Add(this.CmbProducts);
            this.GroupBox10.Controls.Add(this.btnSelectProduct);
            this.GroupBox10.Location = new System.Drawing.Point(2, 2);
            this.GroupBox10.Name = "GroupBox10";
            this.GroupBox10.Size = new System.Drawing.Size(781, 69);
            this.GroupBox10.TabIndex = 117;
            this.GroupBox10.TabStop = false;
            this.GroupBox10.Text = "Products";
            // 
            // CmbProducts
            // 
            this.CmbProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CmbProducts.FormattingEnabled = true;
            this.CmbProducts.Location = new System.Drawing.Point(13, 31);
            this.CmbProducts.Name = "CmbProducts";
            this.CmbProducts.Size = new System.Drawing.Size(263, 28);
            this.CmbProducts.Sorted = true;
            this.CmbProducts.TabIndex = 106;
            // 
            // btnSelectProduct
            // 
            this.btnSelectProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelectProduct.BackColor = System.Drawing.Color.Silver;
            this.btnSelectProduct.Location = new System.Drawing.Point(390, 21);
            this.btnSelectProduct.Name = "btnSelectProduct";
            this.btnSelectProduct.Size = new System.Drawing.Size(208, 42);
            this.btnSelectProduct.TabIndex = 114;
            this.btnSelectProduct.Text = "SELECT";
            this.btnSelectProduct.UseVisualStyleBackColor = false;
            this.btnSelectProduct.Click += new System.EventHandler(this.Cmd_Save_Click);
            // 
            // GroupBox9
            // 
            this.GroupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox9.Controls.Add(this.btnModifyProduct);
            this.GroupBox9.Controls.Add(this.btnRestoreProduct);
            this.GroupBox9.Controls.Add(this.cmbProductUnits);
            this.GroupBox9.Controls.Add(this.btnAddProduct);
            this.GroupBox9.Controls.Add(this.label8);
            this.GroupBox9.Controls.Add(this.btnSaveProduct);
            this.GroupBox9.Controls.Add(this.txtMinDProductUnits);
            this.GroupBox9.Controls.Add(this.txtMaxDProductUnits);
            this.GroupBox9.Controls.Add(this.btnDeleteProduct);
            this.GroupBox9.Controls.Add(this.CmbGrid);
            this.GroupBox9.Controls.Add(this.label9);
            this.GroupBox9.Controls.Add(this.Txt_Description);
            this.GroupBox9.Controls.Add(this.Txt_Code);
            this.GroupBox9.Controls.Add(this.Txt_MinD);
            this.GroupBox9.Controls.Add(this.Label31);
            this.GroupBox9.Controls.Add(this.Label32);
            this.GroupBox9.Controls.Add(this.Txt_MaxD);
            this.GroupBox9.Controls.Add(this.Label27);
            this.GroupBox9.Controls.Add(this.Label28);
            this.GroupBox9.Location = new System.Drawing.Point(2, 81);
            this.GroupBox9.Name = "GroupBox9";
            this.GroupBox9.Size = new System.Drawing.Size(781, 263);
            this.GroupBox9.TabIndex = 115;
            this.GroupBox9.TabStop = false;
            this.GroupBox9.Text = "Products Database";
            // 
            // btnModifyProduct
            // 
            this.btnModifyProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnModifyProduct.BackColor = System.Drawing.Color.Silver;
            this.btnModifyProduct.Location = new System.Drawing.Point(504, 165);
            this.btnModifyProduct.Name = "btnModifyProduct";
            this.btnModifyProduct.Size = new System.Drawing.Size(115, 53);
            this.btnModifyProduct.TabIndex = 130;
            this.btnModifyProduct.Text = "MODIFY";
            this.btnModifyProduct.UseVisualStyleBackColor = false;
            this.btnModifyProduct.Click += new System.EventHandler(this.btnModifyProduct_Click);
            // 
            // btnRestoreProduct
            // 
            this.btnRestoreProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRestoreProduct.BackColor = System.Drawing.Color.Silver;
            this.btnRestoreProduct.Enabled = false;
            this.btnRestoreProduct.Location = new System.Drawing.Point(504, 104);
            this.btnRestoreProduct.Name = "btnRestoreProduct";
            this.btnRestoreProduct.Size = new System.Drawing.Size(115, 55);
            this.btnRestoreProduct.TabIndex = 129;
            this.btnRestoreProduct.Text = "RESTORE";
            this.btnRestoreProduct.UseVisualStyleBackColor = false;
            this.btnRestoreProduct.Click += new System.EventHandler(this.btnRestoreProduct_Click);
            // 
            // cmbProductUnits
            // 
            this.cmbProductUnits.FormattingEnabled = true;
            this.cmbProductUnits.Items.AddRange(new object[] {
            "mm",
            "inch"});
            this.cmbProductUnits.Location = new System.Drawing.Point(140, 215);
            this.cmbProductUnits.Name = "cmbProductUnits";
            this.cmbProductUnits.Size = new System.Drawing.Size(121, 36);
            this.cmbProductUnits.TabIndex = 128;
            this.cmbProductUnits.SelectedIndexChanged += new System.EventHandler(this.cmbProductUnits_SelectedIndexChanged);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddProduct.BackColor = System.Drawing.Color.Silver;
            this.btnAddProduct.Location = new System.Drawing.Point(504, 46);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(115, 55);
            this.btnAddProduct.TabIndex = 119;
            this.btnAddProduct.Text = "ADD";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.CmdAdd_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 16);
            this.label8.TabIndex = 127;
            this.label8.Text = "Units:";
            // 
            // btnSaveProduct
            // 
            this.btnSaveProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSaveProduct.BackColor = System.Drawing.Color.Silver;
            this.btnSaveProduct.Enabled = false;
            this.btnSaveProduct.Location = new System.Drawing.Point(628, 104);
            this.btnSaveProduct.Name = "btnSaveProduct";
            this.btnSaveProduct.Size = new System.Drawing.Size(115, 114);
            this.btnSaveProduct.TabIndex = 118;
            this.btnSaveProduct.Text = "SAVE";
            this.btnSaveProduct.UseVisualStyleBackColor = false;
            this.btnSaveProduct.Click += new System.EventHandler(this.CmdUpdate_Click);
            // 
            // txtMinDProductUnits
            // 
            this.txtMinDProductUnits.AutoSize = true;
            this.txtMinDProductUnits.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMinDProductUnits.Location = new System.Drawing.Point(235, 153);
            this.txtMinDProductUnits.Name = "txtMinDProductUnits";
            this.txtMinDProductUnits.Size = new System.Drawing.Size(38, 21);
            this.txtMinDProductUnits.TabIndex = 126;
            this.txtMinDProductUnits.Text = "mm";
            // 
            // txtMaxDProductUnits
            // 
            this.txtMaxDProductUnits.AutoSize = true;
            this.txtMaxDProductUnits.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMaxDProductUnits.Location = new System.Drawing.Point(235, 117);
            this.txtMaxDProductUnits.Name = "txtMaxDProductUnits";
            this.txtMaxDProductUnits.Size = new System.Drawing.Size(38, 21);
            this.txtMaxDProductUnits.TabIndex = 125;
            this.txtMaxDProductUnits.Text = "mm";
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteProduct.BackColor = System.Drawing.Color.Silver;
            this.btnDeleteProduct.Location = new System.Drawing.Point(625, 45);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(118, 54);
            this.btnDeleteProduct.TabIndex = 116;
            this.btnDeleteProduct.Text = "DELETE";
            this.btnDeleteProduct.UseVisualStyleBackColor = false;
            this.btnDeleteProduct.Click += new System.EventHandler(this.CmdDelete_Click);
            // 
            // CmbGrid
            // 
            this.CmbGrid.FormattingEnabled = true;
            this.CmbGrid.Items.AddRange(new object[] {
            "2x2",
            "3x3",
            "4x4",
            "2x1x5"});
            this.CmbGrid.Location = new System.Drawing.Point(140, 179);
            this.CmbGrid.Name = "CmbGrid";
            this.CmbGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbGrid.Size = new System.Drawing.Size(121, 36);
            this.CmbGrid.TabIndex = 124;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 123;
            this.label9.Text = "Grid:";
            // 
            // Txt_Description
            // 
            this.Txt_Description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_Description.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_Description.Location = new System.Drawing.Point(160, 72);
            this.Txt_Description.MaxLength = 40;
            this.Txt_Description.Name = "Txt_Description";
            this.Txt_Description.Size = new System.Drawing.Size(324, 34);
            this.Txt_Description.TabIndex = 100;
            this.Txt_Description.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Description.Click += new System.EventHandler(this.Txt_Description_Click);
            // 
            // Txt_Code
            // 
            this.Txt_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_Code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_Code.Location = new System.Drawing.Point(160, 36);
            this.Txt_Code.MaxLength = 16;
            this.Txt_Code.Name = "Txt_Code";
            this.Txt_Code.Size = new System.Drawing.Size(197, 34);
            this.Txt_Code.TabIndex = 99;
            this.Txt_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Code.Click += new System.EventHandler(this.Txt_Code_Click);
            // 
            // Txt_MinD
            // 
            this.Txt_MinD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_MinD.Location = new System.Drawing.Point(160, 143);
            this.Txt_MinD.Name = "Txt_MinD";
            this.Txt_MinD.Size = new System.Drawing.Size(63, 34);
            this.Txt_MinD.TabIndex = 97;
            this.Txt_MinD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_MinD.Click += new System.EventHandler(this.Txt_MinD_Click);
            // 
            // Label31
            // 
            this.Label31.AutoSize = true;
            this.Label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label31.Location = new System.Drawing.Point(15, 151);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(102, 16);
            this.Label31.TabIndex = 95;
            this.Label31.Text = "Min Diameter:";
            // 
            // Label32
            // 
            this.Label32.AutoSize = true;
            this.Label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label32.Location = new System.Drawing.Point(15, 118);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(106, 16);
            this.Label32.TabIndex = 94;
            this.Label32.Text = "Max Diameter:";
            // 
            // Txt_MaxD
            // 
            this.Txt_MaxD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_MaxD.Location = new System.Drawing.Point(160, 108);
            this.Txt_MaxD.Name = "Txt_MaxD";
            this.Txt_MaxD.Size = new System.Drawing.Size(63, 34);
            this.Txt_MaxD.TabIndex = 93;
            this.Txt_MaxD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_MaxD.Click += new System.EventHandler(this.Txt_MaxD_Click);
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label27.Location = new System.Drawing.Point(15, 82);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(147, 16);
            this.Label27.TabIndex = 85;
            this.Label27.Text = "Product Description:";
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label28.Location = new System.Drawing.Point(15, 48);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(105, 16);
            this.Label28.TabIndex = 84;
            this.Label28.Text = "Product Code:";
            // 
            // tmrMB
            // 
            this.tmrMB.Enabled = true;
            this.tmrMB.Interval = 1000;
            this.tmrMB.Tick += new System.EventHandler(this.tmrMB_Tick);
            // 
            // GigECameraDemoDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1267, 876);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.controlsTabs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainTabs);
            this.Name = "GigECameraDemoDlg";
            this.Text = "STI-TC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GigECameraDemoDlg_FormClosed);
            this.Load += new System.EventHandler(this.GigECameraDemoDlg_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.GroupBox8.ResumeLayout(false);
            this.GroupActualTargetSize.ResumeLayout(false);
            this.GroupActualTargetSize.PerformLayout();
            this.GroupSelectGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.controlsTabs.ResumeLayout(false);
            this.mainControlPage.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.configurationPage.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.gbShapeIndicator.ResumeLayout(false);
            this.gbShapeIndicator.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.GB_Threshold.ResumeLayout(false);
            this.GB_Threshold.PerformLayout();
            this.boxROI.ResumeLayout(false);
            this.boxROI.PerformLayout();
            this.boxUnits.ResumeLayout(false);
            this.boxUnits.PerformLayout();
            this.advancedPage.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.aboutPage.ResumeLayout(false);
            this.aboutPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mainTabs.ResumeLayout(false);
            this.imagePage.ResumeLayout(false);
            this.imagePage.PerformLayout();
            this.boxOriginal.ResumeLayout(false);
            this.tablePage.ResumeLayout(false);
            this.trendPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trendChart)).EndInit();
            this.productsPage.ResumeLayout(false);
            this.GroupBox13.ResumeLayout(false);
            this.GroupBox13.PerformLayout();
            this.GroupBox10.ResumeLayout(false);
            this.GroupBox9.ResumeLayout(false);
            this.GroupBox9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel StatusLabel;
        private System.Windows.Forms.ToolStripLabel StatusLabelInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel PixelLabel;
        private System.Windows.Forms.ToolStripLabel PixelDataValue;
        private System.Windows.Forms.ToolStripLabel StatusLabelInfoTrash;
        private ImageBox m_ImageBox;

        private SapAcqDevice m_AcqDevice;
        private SapBuffer m_Buffers;
        private SapGraphic m_Graphic;
        private SapAcqDeviceToBuf m_Xfer;
        private SapView m_View;
        private SapLocation m_ServerLocation;
        private string m_ConfigFileName;

        //System menu
        private SystemMenu m_SystemMenu;
        //index for "about this.." item im system menu
        private const int m_AboutID = 0x100;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnTriggerMode;
        internal System.Windows.Forms.Button btnViewMode;
        internal System.Windows.Forms.Button btnProcessImage;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.GroupBox GroupActualTargetSize;
        internal System.Windows.Forms.TextBox txtMinDiameter;
        internal System.Windows.Forms.Label Label54;
        internal System.Windows.Forms.Label Label55;
        internal System.Windows.Forms.TextBox txtMaxDiameter;
        internal System.Windows.Forms.GroupBox GroupSelectGrid;
        internal System.Windows.Forms.Button grid_16;
        internal System.Windows.Forms.Button grid_12;
        internal System.Windows.Forms.Button grid_6;
        internal System.Windows.Forms.Button grid_5;
        internal System.Windows.Forms.Button grid_4;
        internal System.Windows.Forms.Button grid_9;
        private Label label1;
        private DataGridView dataGridView1;
        private TabControl controlsTabs;
        private TabPage mainControlPage;
        private TabPage configurationPage;
        private TabControl mainTabs;
        private TabPage imagePage;
        private TabPage tablePage;
        private TabPage productsPage;
        internal GroupBox GroupBox13;
        internal Label Label47;
        internal CheckBox Chk_Right_Side;
        internal TextBox Txt_Tag;
        internal CheckBox Chk_Digital_Knife;
        internal Button btnAddProduct;
        internal Button btnSaveProduct;
        internal GroupBox GroupBox10;
        internal ComboBox CmbProducts;
        internal Button btnDeleteProduct;
        internal GroupBox GroupBox9;
        internal TextBox Txt_Description;
        internal TextBox Txt_Code;
        internal TextBox Txt_MinD;
        internal Label Label31;
        internal Label Label32;
        internal TextBox Txt_MaxD;
        internal Label Label27;
        internal Label Label28;
        internal Button btnSelectProduct;
        internal GroupBox groupBox2;
        private Label lblAvgDiameter;
        internal Button btnVirtualTrigger;
        private GroupBox boxUnits;
        private Button calibrateBtn;
        private Label minDiameterUnitsTxt;
        private Label maxDiameterUnitsTxt;
        private Label lblEuFactor;
        private Label label7;
        internal GroupBox boxROI;
        internal Label label9;
        private ComboBox CmbGrid;
        internal GroupBox GB_Threshold;
        internal TextBox txtThreshold;
        private Label lblMinDiameter;
        private Label lblMaxDiameter;
        private Label txtControlDiameter;
        internal Label label12;
        internal Label label11;
        internal Label label13;
        internal Label txtSoftwareTrigger;
        internal Label txtFrameMode;
        internal Button btnSetPointManual;
        internal Button btnSetPointLocal;
        internal Button btnSetPointPLC;
        internal GroupBox groupBox5;
        private Label txtAvgMinDiameterUnits;
        private Label txtAvgMaxDiameterUnits;
        private Label txtAvgDiameterUnits;
        private Label txtControlDiameterUnits;
        private Label txtMinDProductUnits;
        private Label txtMaxDProductUnits;
        internal Button btnChangeUnitsInch;
        internal Button btnChangeUnitsMm;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel timeElapsedLabel;
        private ToolStripLabel timeElapsed;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripLabel deviceTempLabel;
        private ToolStripLabel deviceTemp;
        internal Label label3;
        internal Label label2;
        private Button btnIncrementRoiWidth;
        private Button btnDecrementRoiWidth;
        private Button btnDecrementRoiHeight;
        private Button btnIncrementRoiHeight;
        internal TextBox txtRoiHeight;
        internal TextBox txtRoiWidth;
        internal Button btnFreezeFrame;
        private TabPage advancedPage;
        private GroupBox groupBox3;
        private Button btnCalibrateByHeight;
        private GroupBox groupBox6;
        internal TextBox txtAlpha;
        internal TextBox txtMinBlobObjects;
        internal Button btnAutoThreshold;
        internal Button btnManualThreshold;
        private Label txtEquivalentDiameterUnits;
        private Label lblSEQDiameter;
        private GroupBox boxOriginal;
        private GroupBox boxProcess;
        private Timer tmrMB;
        private ComboBox cmbProductUnits;
        internal Label label8;
        private Label txtValidObjects;
        internal Label label14;
        internal Label label15;
        private GroupBox groupBox14;
        internal Button btnResetFrameCounter;
        private GroupBox groupBox15;
        private Label txtFramesCount;
        private Label label5;
        private Label label6;
        private TabPage aboutPage;
        internal Label txtPlcTrigger;
        internal Label txtLiveMode;
        private Label label16;
        private Label label10;
        internal TextBox txtPassword;
        internal TextBox txtUser;
        internal Button btnLogoff;
        internal Button btnLogin;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel lblUserLogged;
        private ToolStripLabel toolStripLabel2;
        private ToolStripLabel lblLoggedRemainingTime;
        private GroupBox groupBox4;
        private GroupBox groupBox7;
        internal Button btnVideoSettings;
        internal Button btnRestoreProduct;
        internal Label txtProductSetted;
        internal Label label17;
        private Label label19;
        private GroupBox gbShapeIndicator;
        internal TextBox txtMaxCompacity;
        internal Label label20;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripLabel lblPlcDataStatus;
        internal Button btnModifyProduct;
        internal Label label21;
        internal TextBox txtCompacityHoleLimit;
        private TabPage trendPage;
        private System.Windows.Forms.DataVisualization.Charting.Chart trendChart;
        internal Button btnClearChart;
        internal Button flagAlign;
        internal Button flagFH;
        internal Label label23;
        internal Label label22;
        private Label lblCV;
        internal Label label24;
        private Label label25;
        private GroupBox groupBox11;
        private Label label26;
        internal TextBox txtFFH;
        private Label label29;
        internal TextBox txtFH;
        private Label label30;
        internal TextBox txtAlign;
        private GroupBox groupBox12;
        internal Button dplControlDiameter;
        internal Button flagValidFrames;
        internal Label label33;
        private PictureBox pictureBox1;
        private Label label34;
        private Label label18;
        private Label label4;
        private Label label35;
        internal TextBox txtValidFramesLimit;
        private GroupBox groupBox16;
        internal Button btn90DegDiameters;
        internal Button btnLinesFilter;
    }
}

