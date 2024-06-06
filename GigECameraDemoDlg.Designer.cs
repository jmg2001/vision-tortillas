
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
            this.virtualTriggerBtn = new System.Windows.Forms.Button();
            this.processImageBtn = new System.Windows.Forms.Button();
            this.triggerModeBtn = new System.Windows.Forms.Button();
            this.viewModeBtn = new System.Windows.Forms.Button();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.btnSetPointManual = new System.Windows.Forms.Button();
            this.btnSetPointLocal = new System.Windows.Forms.Button();
            this.btnSetPointPLC = new System.Windows.Forms.Button();
            this.GroupActualTargetSize = new System.Windows.Forms.GroupBox();
            this.txtProductSetted = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.minDiameterUnitsTxt = new System.Windows.Forms.Label();
            this.maxDiameterUnitsTxt = new System.Windows.Forms.Label();
            this.Txt_MinDiameter = new System.Windows.Forms.TextBox();
            this.Label54 = new System.Windows.Forms.Label();
            this.Label55 = new System.Windows.Forms.Label();
            this.Txt_MaxDiameter = new System.Windows.Forms.TextBox();
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
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.txtValidObjects = new System.Windows.Forms.Label();
            this.txtEquivalentDiameterUnits = new System.Windows.Forms.Label();
            this.txtEquivalentDiameter = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnFreezeFrame = new System.Windows.Forms.Button();
            this.txtAvgMinDiameterUnits = new System.Windows.Forms.Label();
            this.txtAvgMaxDiameterUnits = new System.Windows.Forms.Label();
            this.txtAvgDiameterUnits = new System.Windows.Forms.Label();
            this.avg_diameter = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAvgMinD = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAvgMaxD = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtControlDiameterUnits = new System.Windows.Forms.Label();
            this.txtControlDiameter = new System.Windows.Forms.Label();
            this.configurationPage = new System.Windows.Forms.TabPage();
            this.gbShapeIndicator = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCompacityHoleLimit = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.Txt_MaxCompacity = new System.Windows.Forms.TextBox();
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
            this.Txt_Threshold = new System.Windows.Forms.TextBox();
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
            this.label4 = new System.Windows.Forms.Label();
            this.advancedPage = new System.Windows.Forms.TabPage();
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
            this.euFactorTxt = new System.Windows.Forms.Label();
            this.aboutPage = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainTabs = new System.Windows.Forms.TabControl();
            this.imagePage = new System.Windows.Forms.TabPage();
            this.boxOriginal = new System.Windows.Forms.GroupBox();
            this.boxProcess = new System.Windows.Forms.GroupBox();
            this.tablePage = new System.Windows.Forms.TabPage();
            this.productsPage = new System.Windows.Forms.TabPage();
            this.GroupBox13 = new System.Windows.Forms.GroupBox();
            this.Label47 = new System.Windows.Forms.Label();
            this.Chk_Right_Side = new System.Windows.Forms.CheckBox();
            this.Txt_Tag = new System.Windows.Forms.TextBox();
            this.Chk_Digital_Knife = new System.Windows.Forms.CheckBox();
            this.GroupBox10 = new System.Windows.Forms.GroupBox();
            this.CmbProducts = new System.Windows.Forms.ComboBox();
            this.Cmd_Save = new System.Windows.Forms.Button();
            this.GroupBox9 = new System.Windows.Forms.GroupBox();
            this.btnModifyProduct = new System.Windows.Forms.Button();
            this.btnRestoreProduct = new System.Windows.Forms.Button();
            this.cmbProductUnits = new System.Windows.Forms.ComboBox();
            this.CmdAdd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.CmdUpdate = new System.Windows.Forms.Button();
            this.txtMinDProductUnits = new System.Windows.Forms.Label();
            this.txtMaxDProductUnits = new System.Windows.Forms.Label();
            this.CmdDelete = new System.Windows.Forms.Button();
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
            this.trendPage = new System.Windows.Forms.TabPage();
            this.trendChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            this.configurationPage.SuspendLayout();
            this.gbShapeIndicator.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.GB_Threshold.SuspendLayout();
            this.boxROI.SuspendLayout();
            this.boxUnits.SuspendLayout();
            this.advancedPage.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.aboutPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mainTabs.SuspendLayout();
            this.imagePage.SuspendLayout();
            this.boxOriginal.SuspendLayout();
            this.tablePage.SuspendLayout();
            this.productsPage.SuspendLayout();
            this.GroupBox13.SuspendLayout();
            this.GroupBox10.SuspendLayout();
            this.GroupBox9.SuspendLayout();
            this.trendPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trendChart)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(807, 25);
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
            this.GroupBox1.Controls.Add(this.virtualTriggerBtn);
            this.GroupBox1.Controls.Add(this.processImageBtn);
            this.GroupBox1.Controls.Add(this.triggerModeBtn);
            this.GroupBox1.Controls.Add(this.viewModeBtn);
            this.GroupBox1.Font = new System.Drawing.Font("Alef", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(3, 4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(444, 144);
            this.GroupBox1.TabIndex = 66;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Operation Controls";
            // 
            // txtPlcTrigger
            // 
            this.txtPlcTrigger.AutoSize = true;
            this.txtPlcTrigger.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtPlcTrigger.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtPlcTrigger.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlcTrigger.Location = new System.Drawing.Point(116, 85);
            this.txtPlcTrigger.Name = "txtPlcTrigger";
            this.txtPlcTrigger.Size = new System.Drawing.Size(37, 18);
            this.txtPlcTrigger.TabIndex = 133;
            this.txtPlcTrigger.Text = "PLC";
            // 
            // txtLiveMode
            // 
            this.txtLiveMode.AutoSize = true;
            this.txtLiveMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtLiveMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLiveMode.Location = new System.Drawing.Point(116, 21);
            this.txtLiveMode.Name = "txtLiveMode";
            this.txtLiveMode.Size = new System.Drawing.Size(41, 18);
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
            this.txtFramesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtFramesCount.Location = new System.Drawing.Point(16, 27);
            this.txtFramesCount.Name = "txtFramesCount";
            this.txtFramesCount.Size = new System.Drawing.Size(14, 15);
            this.txtFramesCount.TabIndex = 131;
            this.txtFramesCount.Text = "0";
            // 
            // btnResetFrameCounter
            // 
            this.btnResetFrameCounter.BackColor = System.Drawing.Color.Silver;
            this.btnResetFrameCounter.Location = new System.Drawing.Point(93, 17);
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
            this.txtSoftwareTrigger.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoftwareTrigger.Location = new System.Drawing.Point(115, 114);
            this.txtSoftwareTrigger.Name = "txtSoftwareTrigger";
            this.txtSoftwareTrigger.Size = new System.Drawing.Size(94, 18);
            this.txtSoftwareTrigger.TabIndex = 125;
            this.txtSoftwareTrigger.Text = "SOFTWARE";
            // 
            // txtFrameMode
            // 
            this.txtFrameMode.AutoSize = true;
            this.txtFrameMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtFrameMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrameMode.Location = new System.Drawing.Point(116, 54);
            this.txtFrameMode.Name = "txtFrameMode";
            this.txtFrameMode.Size = new System.Drawing.Size(61, 18);
            this.txtFrameMode.TabIndex = 124;
            this.txtFrameMode.Text = "FRAME";
            // 
            // virtualTriggerBtn
            // 
            this.virtualTriggerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.virtualTriggerBtn.BackColor = System.Drawing.Color.Silver;
            this.virtualTriggerBtn.Location = new System.Drawing.Point(228, 81);
            this.virtualTriggerBtn.Name = "virtualTriggerBtn";
            this.virtualTriggerBtn.Size = new System.Drawing.Size(108, 55);
            this.virtualTriggerBtn.TabIndex = 74;
            this.virtualTriggerBtn.Text = "CAPTURE\r\nFRAME";
            this.virtualTriggerBtn.UseVisualStyleBackColor = false;
            this.virtualTriggerBtn.Click += new System.EventHandler(this.virtualTriggerBtn_Click);
            // 
            // processImageBtn
            // 
            this.processImageBtn.BackColor = System.Drawing.Color.Silver;
            this.processImageBtn.Location = new System.Drawing.Point(340, 81);
            this.processImageBtn.Name = "processImageBtn";
            this.processImageBtn.Size = new System.Drawing.Size(101, 55);
            this.processImageBtn.TabIndex = 73;
            this.processImageBtn.Text = "PROCESS FRAME";
            this.processImageBtn.UseVisualStyleBackColor = false;
            this.processImageBtn.Click += new System.EventHandler(this.processImageBtn_Click);
            // 
            // triggerModeBtn
            // 
            this.triggerModeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.triggerModeBtn.BackColor = System.Drawing.Color.Silver;
            this.triggerModeBtn.Location = new System.Drawing.Point(7, 80);
            this.triggerModeBtn.Name = "triggerModeBtn";
            this.triggerModeBtn.Size = new System.Drawing.Size(103, 55);
            this.triggerModeBtn.TabIndex = 72;
            this.triggerModeBtn.Text = "TRIGGER SOURCE";
            this.triggerModeBtn.UseVisualStyleBackColor = false;
            this.triggerModeBtn.Click += new System.EventHandler(this.triggerModeBtn_Click);
            // 
            // viewModeBtn
            // 
            this.viewModeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewModeBtn.BackColor = System.Drawing.Color.Silver;
            this.viewModeBtn.Font = new System.Drawing.Font("Alef", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewModeBtn.Location = new System.Drawing.Point(7, 19);
            this.viewModeBtn.Name = "viewModeBtn";
            this.viewModeBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.viewModeBtn.Size = new System.Drawing.Size(103, 55);
            this.viewModeBtn.TabIndex = 69;
            this.viewModeBtn.Text = "VIEW MODE";
            this.viewModeBtn.UseVisualStyleBackColor = false;
            this.viewModeBtn.Click += new System.EventHandler(this.Cmd_Trigger_Click);
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.btnSetPointManual);
            this.GroupBox8.Controls.Add(this.btnSetPointLocal);
            this.GroupBox8.Controls.Add(this.btnSetPointPLC);
            this.GroupBox8.Font = new System.Drawing.Font("Alef", 10F);
            this.GroupBox8.Location = new System.Drawing.Point(5, 361);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(444, 84);
            this.GroupBox8.TabIndex = 112;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "SetPoint Source";
            // 
            // btnSetPointManual
            // 
            this.btnSetPointManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetPointManual.BackColor = System.Drawing.Color.Silver;
            this.btnSetPointManual.Location = new System.Drawing.Point(289, 21);
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
            this.btnSetPointLocal.Location = new System.Drawing.Point(161, 21);
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
            this.btnSetPointPLC.Location = new System.Drawing.Point(38, 21);
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
            this.GroupActualTargetSize.Controls.Add(this.Txt_MinDiameter);
            this.GroupActualTargetSize.Controls.Add(this.Label54);
            this.GroupActualTargetSize.Controls.Add(this.Label55);
            this.GroupActualTargetSize.Controls.Add(this.Txt_MaxDiameter);
            this.GroupActualTargetSize.Font = new System.Drawing.Font("Alef", 10F);
            this.GroupActualTargetSize.Location = new System.Drawing.Point(5, 449);
            this.GroupActualTargetSize.Name = "GroupActualTargetSize";
            this.GroupActualTargetSize.Size = new System.Drawing.Size(259, 189);
            this.GroupActualTargetSize.TabIndex = 111;
            this.GroupActualTargetSize.TabStop = false;
            this.GroupActualTargetSize.Text = "Actual Target Sizes";
            // 
            // txtProductSetted
            // 
            this.txtProductSetted.AutoSize = true;
            this.txtProductSetted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductSetted.Location = new System.Drawing.Point(145, 37);
            this.txtProductSetted.Name = "txtProductSetted";
            this.txtProductSetted.Size = new System.Drawing.Size(33, 20);
            this.txtProductSetted.TabIndex = 98;
            this.txtProductSetted.Text = "NA";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 38);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 20);
            this.label17.TabIndex = 97;
            this.label17.Text = "Product:";
            // 
            // minDiameterUnitsTxt
            // 
            this.minDiameterUnitsTxt.AutoSize = true;
            this.minDiameterUnitsTxt.BackColor = System.Drawing.Color.Transparent;
            this.minDiameterUnitsTxt.Font = new System.Drawing.Font("Alef", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minDiameterUnitsTxt.Location = new System.Drawing.Point(207, 131);
            this.minDiameterUnitsTxt.Name = "minDiameterUnitsTxt";
            this.minDiameterUnitsTxt.Size = new System.Drawing.Size(46, 28);
            this.minDiameterUnitsTxt.TabIndex = 96;
            this.minDiameterUnitsTxt.Text = "mm";
            // 
            // maxDiameterUnitsTxt
            // 
            this.maxDiameterUnitsTxt.AutoSize = true;
            this.maxDiameterUnitsTxt.BackColor = System.Drawing.Color.Transparent;
            this.maxDiameterUnitsTxt.Font = new System.Drawing.Font("Alef", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxDiameterUnitsTxt.Location = new System.Drawing.Point(208, 76);
            this.maxDiameterUnitsTxt.Name = "maxDiameterUnitsTxt";
            this.maxDiameterUnitsTxt.Size = new System.Drawing.Size(46, 28);
            this.maxDiameterUnitsTxt.TabIndex = 95;
            this.maxDiameterUnitsTxt.Text = "mm";
            // 
            // Txt_MinDiameter
            // 
            this.Txt_MinDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_MinDiameter.Location = new System.Drawing.Point(82, 120);
            this.Txt_MinDiameter.MaxLength = 10;
            this.Txt_MinDiameter.Name = "Txt_MinDiameter";
            this.Txt_MinDiameter.Size = new System.Drawing.Size(123, 40);
            this.Txt_MinDiameter.TabIndex = 91;
            this.Txt_MinDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_MinDiameter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_MinDiameter_KeyPress);
            // 
            // Label54
            // 
            this.Label54.AutoSize = true;
            this.Label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label54.Location = new System.Drawing.Point(6, 133);
            this.Label54.Name = "Label54";
            this.Label54.Size = new System.Drawing.Size(60, 20);
            this.Label54.TabIndex = 89;
            this.Label54.Text = "Min D:";
            // 
            // Label55
            // 
            this.Label55.AutoSize = true;
            this.Label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label55.Location = new System.Drawing.Point(5, 80);
            this.Label55.Name = "Label55";
            this.Label55.Size = new System.Drawing.Size(64, 20);
            this.Label55.TabIndex = 88;
            this.Label55.Text = "Max D:";
            // 
            // Txt_MaxDiameter
            // 
            this.Txt_MaxDiameter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Txt_MaxDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_MaxDiameter.Location = new System.Drawing.Point(82, 65);
            this.Txt_MaxDiameter.MaxLength = 10;
            this.Txt_MaxDiameter.Name = "Txt_MaxDiameter";
            this.Txt_MaxDiameter.Size = new System.Drawing.Size(125, 40);
            this.Txt_MaxDiameter.TabIndex = 87;
            this.Txt_MaxDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_MaxDiameter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_MaxDiameter_KeyPress);
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
            this.GroupSelectGrid.Location = new System.Drawing.Point(271, 449);
            this.GroupSelectGrid.Name = "GroupSelectGrid";
            this.GroupSelectGrid.Size = new System.Drawing.Size(176, 189);
            this.GroupSelectGrid.TabIndex = 109;
            this.GroupSelectGrid.TabStop = false;
            this.GroupSelectGrid.Text = "Selected Grid";
            // 
            // grid_16
            // 
            this.grid_16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_16.BackColor = System.Drawing.Color.Silver;
            this.grid_16.Location = new System.Drawing.Point(92, 127);
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
            this.grid_12.Location = new System.Drawing.Point(19, 127);
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
            this.grid_6.Enabled = false;
            this.grid_6.Location = new System.Drawing.Point(19, 79);
            this.grid_6.Name = "grid_6";
            this.grid_6.Size = new System.Drawing.Size(67, 42);
            this.grid_6.TabIndex = 73;
            this.grid_6.Text = "4x4";
            this.grid_6.UseVisualStyleBackColor = false;
            this.grid_6.Visible = false;
            this.grid_6.Click += new System.EventHandler(this.grid_6_Click);
            // 
            // grid_5
            // 
            this.grid_5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_5.BackColor = System.Drawing.Color.Silver;
            this.grid_5.Enabled = false;
            this.grid_5.Location = new System.Drawing.Point(92, 76);
            this.grid_5.Name = "grid_5";
            this.grid_5.Size = new System.Drawing.Size(67, 42);
            this.grid_5.TabIndex = 72;
            this.grid_5.Text = "2x1x2";
            this.grid_5.UseVisualStyleBackColor = false;
            this.grid_5.Visible = false;
            this.grid_5.Click += new System.EventHandler(this.grid_5_Click);
            // 
            // grid_9
            // 
            this.grid_9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_9.BackColor = System.Drawing.Color.Silver;
            this.grid_9.Enabled = false;
            this.grid_9.Location = new System.Drawing.Point(92, 29);
            this.grid_9.Name = "grid_9";
            this.grid_9.Size = new System.Drawing.Size(67, 42);
            this.grid_9.TabIndex = 70;
            this.grid_9.Text = "2x2";
            this.grid_9.UseVisualStyleBackColor = false;
            this.grid_9.Visible = false;
            this.grid_9.Click += new System.EventHandler(this.grid_9_Click);
            // 
            // grid_4
            // 
            this.grid_4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grid_4.BackColor = System.Drawing.Color.Silver;
            this.grid_4.Location = new System.Drawing.Point(19, 31);
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
            this.dataGridView1.Size = new System.Drawing.Size(851, 379);
            this.dataGridView1.TabIndex = 117;
            // 
            // controlsTabs
            // 
            this.controlsTabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.controlsTabs.Controls.Add(this.mainControlPage);
            this.controlsTabs.Controls.Add(this.configurationPage);
            this.controlsTabs.Controls.Add(this.advancedPage);
            this.controlsTabs.Controls.Add(this.aboutPage);
            this.controlsTabs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.controlsTabs.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlsTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.controlsTabs.ItemSize = new System.Drawing.Size(58, 40);
            this.controlsTabs.Location = new System.Drawing.Point(807, 0);
            this.controlsTabs.Name = "controlsTabs";
            this.controlsTabs.Padding = new System.Drawing.Point(20, 3);
            this.controlsTabs.SelectedIndex = 0;
            this.controlsTabs.Size = new System.Drawing.Size(460, 876);
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
            this.mainControlPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainControlPage.Font = new System.Drawing.Font("Alef", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainControlPage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mainControlPage.Location = new System.Drawing.Point(4, 44);
            this.mainControlPage.Name = "mainControlPage";
            this.mainControlPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainControlPage.Size = new System.Drawing.Size(452, 828);
            this.mainControlPage.TabIndex = 0;
            this.mainControlPage.Text = "Operation";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.groupBox14);
            this.groupBox5.Controls.Add(this.txtEquivalentDiameterUnits);
            this.groupBox5.Controls.Add(this.txtEquivalentDiameter);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.btnFreezeFrame);
            this.groupBox5.Controls.Add(this.txtAvgMinDiameterUnits);
            this.groupBox5.Controls.Add(this.txtAvgMaxDiameterUnits);
            this.groupBox5.Controls.Add(this.txtAvgDiameterUnits);
            this.groupBox5.Controls.Add(this.avg_diameter);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.txtAvgMinD);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.txtAvgMaxD);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Font = new System.Drawing.Font("Alef", 10F);
            this.groupBox5.Location = new System.Drawing.Point(5, 149);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(442, 149);
            this.groupBox5.TabIndex = 115;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Frame Results";
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
            this.txtValidObjects.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtValidObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValidObjects.Location = new System.Drawing.Point(62, 22);
            this.txtValidObjects.Name = "txtValidObjects";
            this.txtValidObjects.Size = new System.Drawing.Size(24, 25);
            this.txtValidObjects.TabIndex = 127;
            this.txtValidObjects.Text = "0";
            // 
            // txtEquivalentDiameterUnits
            // 
            this.txtEquivalentDiameterUnits.AutoSize = true;
            this.txtEquivalentDiameterUnits.Font = new System.Drawing.Font("Alef", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquivalentDiameterUnits.Location = new System.Drawing.Point(376, 113);
            this.txtEquivalentDiameterUnits.Name = "txtEquivalentDiameterUnits";
            this.txtEquivalentDiameterUnits.Size = new System.Drawing.Size(36, 22);
            this.txtEquivalentDiameterUnits.TabIndex = 126;
            this.txtEquivalentDiameterUnits.Text = "mm";
            // 
            // txtEquivalentDiameter
            // 
            this.txtEquivalentDiameter.AutoSize = true;
            this.txtEquivalentDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtEquivalentDiameter.Location = new System.Drawing.Point(321, 113);
            this.txtEquivalentDiameter.Name = "txtEquivalentDiameter";
            this.txtEquivalentDiameter.Size = new System.Drawing.Size(18, 20);
            this.txtEquivalentDiameter.TabIndex = 0;
            this.txtEquivalentDiameter.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(184, 116);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 16);
            this.label14.TabIndex = 131;
            this.label14.Text = "SEQ Diameter:";
            // 
            // btnFreezeFrame
            // 
            this.btnFreezeFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFreezeFrame.BackColor = System.Drawing.Color.Silver;
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
            this.txtAvgMinDiameterUnits.Font = new System.Drawing.Font("Alef", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvgMinDiameterUnits.Location = new System.Drawing.Point(376, 85);
            this.txtAvgMinDiameterUnits.Name = "txtAvgMinDiameterUnits";
            this.txtAvgMinDiameterUnits.Size = new System.Drawing.Size(36, 22);
            this.txtAvgMinDiameterUnits.TabIndex = 125;
            this.txtAvgMinDiameterUnits.Text = "mm";
            // 
            // txtAvgMaxDiameterUnits
            // 
            this.txtAvgMaxDiameterUnits.AutoSize = true;
            this.txtAvgMaxDiameterUnits.Font = new System.Drawing.Font("Alef", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvgMaxDiameterUnits.Location = new System.Drawing.Point(376, 56);
            this.txtAvgMaxDiameterUnits.Name = "txtAvgMaxDiameterUnits";
            this.txtAvgMaxDiameterUnits.Size = new System.Drawing.Size(36, 22);
            this.txtAvgMaxDiameterUnits.TabIndex = 124;
            this.txtAvgMaxDiameterUnits.Text = "mm";
            // 
            // txtAvgDiameterUnits
            // 
            this.txtAvgDiameterUnits.AutoSize = true;
            this.txtAvgDiameterUnits.Font = new System.Drawing.Font("Alef", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvgDiameterUnits.Location = new System.Drawing.Point(376, 30);
            this.txtAvgDiameterUnits.Name = "txtAvgDiameterUnits";
            this.txtAvgDiameterUnits.Size = new System.Drawing.Size(36, 22);
            this.txtAvgDiameterUnits.TabIndex = 123;
            this.txtAvgDiameterUnits.Text = "mm";
            // 
            // avg_diameter
            // 
            this.avg_diameter.AutoSize = true;
            this.avg_diameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avg_diameter.Location = new System.Drawing.Point(321, 31);
            this.avg_diameter.Name = "avg_diameter";
            this.avg_diameter.Size = new System.Drawing.Size(18, 20);
            this.avg_diameter.TabIndex = 0;
            this.avg_diameter.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(184, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 16);
            this.label13.TabIndex = 122;
            this.label13.Text = "Avg Diameter:";
            // 
            // txtAvgMinD
            // 
            this.txtAvgMinD.AutoSize = true;
            this.txtAvgMinD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvgMinD.Location = new System.Drawing.Point(321, 85);
            this.txtAvgMinD.Name = "txtAvgMinD";
            this.txtAvgMinD.Size = new System.Drawing.Size(18, 20);
            this.txtAvgMinD.TabIndex = 0;
            this.txtAvgMinD.Text = "0";
            this.txtAvgMinD.Click += new System.EventHandler(this.txtAvgMinD_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(184, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 16);
            this.label11.TabIndex = 120;
            this.label11.Text = "Max Diameter:";
            // 
            // txtAvgMaxD
            // 
            this.txtAvgMaxD.AutoSize = true;
            this.txtAvgMaxD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvgMaxD.Location = new System.Drawing.Point(321, 57);
            this.txtAvgMaxD.Name = "txtAvgMaxD";
            this.txtAvgMaxD.Size = new System.Drawing.Size(18, 20);
            this.txtAvgMaxD.TabIndex = 0;
            this.txtAvgMaxD.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(184, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 16);
            this.label12.TabIndex = 121;
            this.label12.Text = "Min Diameter:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtControlDiameterUnits);
            this.groupBox2.Controls.Add(this.txtControlDiameter);
            this.groupBox2.Font = new System.Drawing.Font("Alef", 10F);
            this.groupBox2.Location = new System.Drawing.Point(5, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 49);
            this.groupBox2.TabIndex = 114;
            this.groupBox2.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(18, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(219, 20);
            this.label15.TabIndex = 132;
            this.label15.Text = "Process Control Diameter:";
            // 
            // txtControlDiameterUnits
            // 
            this.txtControlDiameterUnits.AutoSize = true;
            this.txtControlDiameterUnits.Font = new System.Drawing.Font("Alef", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControlDiameterUnits.Location = new System.Drawing.Point(353, 21);
            this.txtControlDiameterUnits.Name = "txtControlDiameterUnits";
            this.txtControlDiameterUnits.Size = new System.Drawing.Size(36, 22);
            this.txtControlDiameterUnits.TabIndex = 126;
            this.txtControlDiameterUnits.Text = "mm";
            // 
            // txtControlDiameter
            // 
            this.txtControlDiameter.AutoSize = true;
            this.txtControlDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControlDiameter.Location = new System.Drawing.Point(266, 18);
            this.txtControlDiameter.Name = "txtControlDiameter";
            this.txtControlDiameter.Size = new System.Drawing.Size(24, 25);
            this.txtControlDiameter.TabIndex = 0;
            this.txtControlDiameter.Text = "0";
            // 
            // configurationPage
            // 
            this.configurationPage.BackColor = System.Drawing.Color.LightSteelBlue;
            this.configurationPage.Controls.Add(this.gbShapeIndicator);
            this.configurationPage.Controls.Add(this.groupBox4);
            this.configurationPage.Controls.Add(this.GB_Threshold);
            this.configurationPage.Controls.Add(this.boxROI);
            this.configurationPage.Controls.Add(this.boxUnits);
            this.configurationPage.Font = new System.Drawing.Font("Alef", 10F);
            this.configurationPage.Location = new System.Drawing.Point(4, 44);
            this.configurationPage.Name = "configurationPage";
            this.configurationPage.Padding = new System.Windows.Forms.Padding(3);
            this.configurationPage.Size = new System.Drawing.Size(452, 828);
            this.configurationPage.TabIndex = 1;
            this.configurationPage.Text = "Config";
            // 
            // gbShapeIndicator
            // 
            this.gbShapeIndicator.Controls.Add(this.label21);
            this.gbShapeIndicator.Controls.Add(this.txtCompacityHoleLimit);
            this.gbShapeIndicator.Controls.Add(this.label20);
            this.gbShapeIndicator.Controls.Add(this.Txt_MaxCompacity);
            this.gbShapeIndicator.Location = new System.Drawing.Point(234, 272);
            this.gbShapeIndicator.Name = "gbShapeIndicator";
            this.gbShapeIndicator.Size = new System.Drawing.Size(210, 174);
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
            this.txtCompacityHoleLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompacityHoleLimit.Location = new System.Drawing.Point(106, 98);
            this.txtCompacityHoleLimit.MaxLength = 10;
            this.txtCompacityHoleLimit.Name = "txtCompacityHoleLimit";
            this.txtCompacityHoleLimit.Size = new System.Drawing.Size(98, 40);
            this.txtCompacityHoleLimit.TabIndex = 136;
            this.txtCompacityHoleLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // Txt_MaxCompacity
            // 
            this.Txt_MaxCompacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_MaxCompacity.Location = new System.Drawing.Point(106, 43);
            this.Txt_MaxCompacity.MaxLength = 10;
            this.Txt_MaxCompacity.Name = "Txt_MaxCompacity";
            this.Txt_MaxCompacity.Size = new System.Drawing.Size(98, 40);
            this.Txt_MaxCompacity.TabIndex = 129;
            this.Txt_MaxCompacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_MaxCompacity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_MaxCompacity_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.btnLogin);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.btnLogoff);
            this.groupBox4.Controls.Add(this.txtPassword);
            this.groupBox4.Controls.Add(this.txtUser);
            this.groupBox4.Location = new System.Drawing.Point(6, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(438, 187);
            this.groupBox4.TabIndex = 127;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Login";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(35, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(151, 33);
            this.label16.TabIndex = 126;
            this.label16.Text = "Password:";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.AutoSize = true;
            this.btnLogin.BackColor = System.Drawing.Color.Silver;
            this.btnLogin.Location = new System.Drawing.Point(75, 134);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(117, 42);
            this.btnLogin.TabIndex = 122;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(35, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 33);
            this.label10.TabIndex = 122;
            this.label10.Text = "User:";
            // 
            // btnLogoff
            // 
            this.btnLogoff.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogoff.AutoSize = true;
            this.btnLogoff.BackColor = System.Drawing.Color.Silver;
            this.btnLogoff.Location = new System.Drawing.Point(243, 132);
            this.btnLogoff.Name = "btnLogoff";
            this.btnLogoff.Size = new System.Drawing.Size(117, 42);
            this.btnLogoff.TabIndex = 124;
            this.btnLogoff.Text = "Logoff";
            this.btnLogoff.UseVisualStyleBackColor = false;
            this.btnLogoff.Click += new System.EventHandler(this.btnLogoff_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtPassword.Location = new System.Drawing.Point(217, 75);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(164, 35);
            this.txtPassword.TabIndex = 125;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUser
            // 
            this.txtUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtUser.Location = new System.Drawing.Point(217, 23);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(164, 35);
            this.txtUser.TabIndex = 124;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GB_Threshold
            // 
            this.GB_Threshold.Controls.Add(this.btnAutoThreshold);
            this.GB_Threshold.Controls.Add(this.btnManualThreshold);
            this.GB_Threshold.Controls.Add(this.Txt_Threshold);
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
            this.btnAutoThreshold.Location = new System.Drawing.Point(26, 48);
            this.btnAutoThreshold.Name = "btnAutoThreshold";
            this.btnAutoThreshold.Size = new System.Drawing.Size(86, 42);
            this.btnAutoThreshold.TabIndex = 123;
            this.btnAutoThreshold.Text = "Automatic";
            this.btnAutoThreshold.UseVisualStyleBackColor = false;
            this.btnAutoThreshold.Click += new System.EventHandler(this.btnAutoThreshold_Click);
            // 
            // btnManualThreshold
            // 
            this.btnManualThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnManualThreshold.AutoSize = true;
            this.btnManualThreshold.BackColor = System.Drawing.Color.Silver;
            this.btnManualThreshold.Location = new System.Drawing.Point(26, 109);
            this.btnManualThreshold.Name = "btnManualThreshold";
            this.btnManualThreshold.Size = new System.Drawing.Size(85, 42);
            this.btnManualThreshold.TabIndex = 122;
            this.btnManualThreshold.Text = "Manual";
            this.btnManualThreshold.UseVisualStyleBackColor = false;
            this.btnManualThreshold.Click += new System.EventHandler(this.btnManualThreshold_Click);
            // 
            // Txt_Threshold
            // 
            this.Txt_Threshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Txt_Threshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_Threshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Threshold.Location = new System.Drawing.Point(121, 83);
            this.Txt_Threshold.Name = "Txt_Threshold";
            this.Txt_Threshold.Size = new System.Drawing.Size(88, 40);
            this.Txt_Threshold.TabIndex = 12;
            this.Txt_Threshold.Text = "0";
            this.Txt_Threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Threshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Threshold_KeyPress);
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
            this.boxROI.Location = new System.Drawing.Point(6, 463);
            this.boxROI.Name = "boxROI";
            this.boxROI.Size = new System.Drawing.Size(438, 213);
            this.boxROI.TabIndex = 121;
            this.boxROI.TabStop = false;
            this.boxROI.Text = "ROI Definition";
            // 
            // btnDecrementRoiHeight
            // 
            this.btnDecrementRoiHeight.Font = new System.Drawing.Font("Alef", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrementRoiHeight.Location = new System.Drawing.Point(334, 127);
            this.btnDecrementRoiHeight.Name = "btnDecrementRoiHeight";
            this.btnDecrementRoiHeight.Size = new System.Drawing.Size(75, 48);
            this.btnDecrementRoiHeight.TabIndex = 134;
            this.btnDecrementRoiHeight.Text = "-";
            this.btnDecrementRoiHeight.UseVisualStyleBackColor = true;
            this.btnDecrementRoiHeight.Click += new System.EventHandler(this.btnDecrementRoiHeight_Click);
            // 
            // btnIncrementRoiHeight
            // 
            this.btnIncrementRoiHeight.Font = new System.Drawing.Font("Alef", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncrementRoiHeight.Location = new System.Drawing.Point(334, 74);
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
            this.txtRoiHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoiHeight.Location = new System.Drawing.Point(228, 98);
            this.txtRoiHeight.Name = "txtRoiHeight";
            this.txtRoiHeight.Size = new System.Drawing.Size(100, 49);
            this.txtRoiHeight.TabIndex = 132;
            this.txtRoiHeight.Text = "0";
            this.txtRoiHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRoiHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoiHeight_KeyPress);
            // 
            // btnDecrementRoiWidth
            // 
            this.btnDecrementRoiWidth.Font = new System.Drawing.Font("Alef", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrementRoiWidth.Location = new System.Drawing.Point(147, 127);
            this.btnDecrementRoiWidth.Name = "btnDecrementRoiWidth";
            this.btnDecrementRoiWidth.Size = new System.Drawing.Size(75, 48);
            this.btnDecrementRoiWidth.TabIndex = 131;
            this.btnDecrementRoiWidth.Text = "-";
            this.btnDecrementRoiWidth.UseVisualStyleBackColor = true;
            this.btnDecrementRoiWidth.Click += new System.EventHandler(this.btnDecrementRoiWidth_Click);
            // 
            // btnIncrementRoiWidth
            // 
            this.btnIncrementRoiWidth.Font = new System.Drawing.Font("Alef", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncrementRoiWidth.Location = new System.Drawing.Point(147, 74);
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
            this.label3.Location = new System.Drawing.Point(272, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 24);
            this.label3.TabIndex = 129;
            this.label3.Text = "ROI Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 24);
            this.label2.TabIndex = 128;
            this.label2.Text = "ROI Width";
            // 
            // txtRoiWidth
            // 
            this.txtRoiWidth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRoiWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoiWidth.Location = new System.Drawing.Point(41, 98);
            this.txtRoiWidth.Name = "txtRoiWidth";
            this.txtRoiWidth.Size = new System.Drawing.Size(100, 49);
            this.txtRoiWidth.TabIndex = 87;
            this.txtRoiWidth.Text = "0";
            this.txtRoiWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRoiWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoiWidth_KeyPress);
            // 
            // boxUnits
            // 
            this.boxUnits.Controls.Add(this.btnChangeUnitsInch);
            this.boxUnits.Controls.Add(this.btnChangeUnitsMm);
            this.boxUnits.Controls.Add(this.label4);
            this.boxUnits.Font = new System.Drawing.Font("Alef", 10F);
            this.boxUnits.Location = new System.Drawing.Point(6, 191);
            this.boxUnits.Name = "boxUnits";
            this.boxUnits.Size = new System.Drawing.Size(438, 72);
            this.boxUnits.TabIndex = 117;
            this.boxUnits.TabStop = false;
            this.boxUnits.Text = "Units";
            // 
            // btnChangeUnitsInch
            // 
            this.btnChangeUnitsInch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangeUnitsInch.AutoSize = true;
            this.btnChangeUnitsInch.BackColor = System.Drawing.Color.Silver;
            this.btnChangeUnitsInch.Location = new System.Drawing.Point(294, 21);
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
            this.btnChangeUnitsMm.Location = new System.Drawing.Point(177, 22);
            this.btnChangeUnitsMm.Name = "btnChangeUnitsMm";
            this.btnChangeUnitsMm.Size = new System.Drawing.Size(85, 42);
            this.btnChangeUnitsMm.TabIndex = 120;
            this.btnChangeUnitsMm.Text = "mm";
            this.btnChangeUnitsMm.UseVisualStyleBackColor = false;
            this.btnChangeUnitsMm.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 33);
            this.label4.TabIndex = 1;
            this.label4.Text = "Units:";
            // 
            // advancedPage
            // 
            this.advancedPage.BackColor = System.Drawing.Color.LightSteelBlue;
            this.advancedPage.Controls.Add(this.groupBox7);
            this.advancedPage.Controls.Add(this.groupBox6);
            this.advancedPage.Controls.Add(this.groupBox3);
            this.advancedPage.Font = new System.Drawing.Font("Alef", 10F);
            this.advancedPage.Location = new System.Drawing.Point(4, 44);
            this.advancedPage.Name = "advancedPage";
            this.advancedPage.Size = new System.Drawing.Size(452, 828);
            this.advancedPage.TabIndex = 2;
            this.advancedPage.Text = "Advanced";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnVideoSettings);
            this.groupBox7.Location = new System.Drawing.Point(7, 355);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(438, 88);
            this.groupBox7.TabIndex = 129;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Video Settings";
            // 
            // btnVideoSettings
            // 
            this.btnVideoSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVideoSettings.AutoSize = true;
            this.btnVideoSettings.BackColor = System.Drawing.Color.Silver;
            this.btnVideoSettings.Location = new System.Drawing.Point(111, 21);
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
            this.groupBox6.Location = new System.Drawing.Point(6, 183);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(438, 167);
            this.groupBox6.TabIndex = 119;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Process Variable Parameters";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 24);
            this.label6.TabIndex = 89;
            this.label6.Text = "Min Objects:";
            // 
            // txtMinBlobObjects
            // 
            this.txtMinBlobObjects.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMinBlobObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinBlobObjects.Location = new System.Drawing.Point(207, 105);
            this.txtMinBlobObjects.MaxLength = 5;
            this.txtMinBlobObjects.Name = "txtMinBlobObjects";
            this.txtMinBlobObjects.Size = new System.Drawing.Size(100, 44);
            this.txtMinBlobObjects.TabIndex = 88;
            this.txtMinBlobObjects.Text = "0";
            this.txtMinBlobObjects.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinBlobObjects.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinBlobObjects_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Alpha Constant:";
            // 
            // txtAlpha
            // 
            this.txtAlpha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAlpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlpha.Location = new System.Drawing.Point(207, 34);
            this.txtAlpha.MaxLength = 5;
            this.txtAlpha.Name = "txtAlpha";
            this.txtAlpha.Size = new System.Drawing.Size(100, 44);
            this.txtAlpha.TabIndex = 88;
            this.txtAlpha.Text = "0";
            this.txtAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAlpha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlpha_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCalibrateByHeight);
            this.groupBox3.Controls.Add(this.calibrateBtn);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.euFactorTxt);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(438, 174);
            this.groupBox3.TabIndex = 118;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Calibration";
            // 
            // btnCalibrateByHeight
            // 
            this.btnCalibrateByHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCalibrateByHeight.Location = new System.Drawing.Point(207, 30);
            this.btnCalibrateByHeight.Name = "btnCalibrateByHeight";
            this.btnCalibrateByHeight.Size = new System.Drawing.Size(192, 82);
            this.btnCalibrateByHeight.TabIndex = 8;
            this.btnCalibrateByHeight.Text = "Calibrate by Height";
            this.btnCalibrateByHeight.UseVisualStyleBackColor = true;
            this.btnCalibrateByHeight.Click += new System.EventHandler(this.btnCalibrateByHeight_Click);
            // 
            // calibrateBtn
            // 
            this.calibrateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.calibrateBtn.Location = new System.Drawing.Point(19, 30);
            this.calibrateBtn.Name = "calibrateBtn";
            this.calibrateBtn.Size = new System.Drawing.Size(182, 82);
            this.calibrateBtn.TabIndex = 4;
            this.calibrateBtn.Text = "Calibrate by Target";
            this.calibrateBtn.UseVisualStyleBackColor = true;
            this.calibrateBtn.Click += new System.EventHandler(this.calibrateButtom_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(108, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Calibration Factor:";
            // 
            // euFactorTxt
            // 
            this.euFactorTxt.AutoSize = true;
            this.euFactorTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.euFactorTxt.Location = new System.Drawing.Point(276, 129);
            this.euFactorTxt.Name = "euFactorTxt";
            this.euFactorTxt.Size = new System.Drawing.Size(35, 24);
            this.euFactorTxt.TabIndex = 7;
            this.euFactorTxt.Text = "1.0";
            // 
            // aboutPage
            // 
            this.aboutPage.BackColor = System.Drawing.Color.LightSteelBlue;
            this.aboutPage.Controls.Add(this.label19);
            this.aboutPage.Controls.Add(this.label18);
            this.aboutPage.Controls.Add(this.pictureBox1);
            this.aboutPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.aboutPage.Location = new System.Drawing.Point(4, 44);
            this.aboutPage.Name = "aboutPage";
            this.aboutPage.Size = new System.Drawing.Size(452, 828);
            this.aboutPage.TabIndex = 3;
            this.aboutPage.Text = "About";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(206, 102);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 25);
            this.label19.TabIndex = 2;
            this.label19.Text = "V1.0.0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(75, 133);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(309, 25);
            this.label18.TabIndex = 1;
            this.label18.Text = "@Copyright 2024 SIOS Ingeniería";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::DALSA.SaperaLT.Demos.NET.CSharp.GigECameraDemo.Properties.Resources.SIOS_LOGOTIPO_AZUL;
            this.pictureBox1.Location = new System.Drawing.Point(37, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(385, 67);
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
            this.mainTabs.Controls.Add(this.productsPage);
            this.mainTabs.Controls.Add(this.trendPage);
            this.mainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
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
            this.imagePage.Location = new System.Drawing.Point(4, 44);
            this.imagePage.Name = "imagePage";
            this.imagePage.Padding = new System.Windows.Forms.Padding(3);
            this.imagePage.Size = new System.Drawing.Size(1259, 828);
            this.imagePage.TabIndex = 0;
            this.imagePage.Text = "Camera View";
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
            this.tablePage.Text = "Metrics Table";
            this.tablePage.UseVisualStyleBackColor = true;
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
            this.productsPage.Text = "Products Catalog";
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
            this.Chk_Right_Side.Size = new System.Drawing.Size(197, 29);
            this.Chk_Right_Side.TabIndex = 100;
            this.Chk_Right_Side.Text = "Installed Right Side";
            this.Chk_Right_Side.UseVisualStyleBackColor = true;
            // 
            // Txt_Tag
            // 
            this.Txt_Tag.Location = new System.Drawing.Point(49, 24);
            this.Txt_Tag.MaxLength = 20;
            this.Txt_Tag.Name = "Txt_Tag";
            this.Txt_Tag.Size = new System.Drawing.Size(150, 30);
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
            this.Chk_Digital_Knife.Size = new System.Drawing.Size(134, 29);
            this.Chk_Digital_Knife.TabIndex = 95;
            this.Chk_Digital_Knife.Text = "Digital Knife";
            this.Chk_Digital_Knife.UseVisualStyleBackColor = true;
            // 
            // GroupBox10
            // 
            this.GroupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox10.Controls.Add(this.CmbProducts);
            this.GroupBox10.Controls.Add(this.Cmd_Save);
            this.GroupBox10.Location = new System.Drawing.Point(2, 2);
            this.GroupBox10.Name = "GroupBox10";
            this.GroupBox10.Size = new System.Drawing.Size(795, 69);
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
            // Cmd_Save
            // 
            this.Cmd_Save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cmd_Save.BackColor = System.Drawing.Color.Silver;
            this.Cmd_Save.Location = new System.Drawing.Point(322, 21);
            this.Cmd_Save.Name = "Cmd_Save";
            this.Cmd_Save.Size = new System.Drawing.Size(208, 42);
            this.Cmd_Save.TabIndex = 114;
            this.Cmd_Save.Text = "SELECT";
            this.Cmd_Save.UseVisualStyleBackColor = false;
            this.Cmd_Save.Click += new System.EventHandler(this.Cmd_Save_Click);
            // 
            // GroupBox9
            // 
            this.GroupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox9.Controls.Add(this.btnModifyProduct);
            this.GroupBox9.Controls.Add(this.btnRestoreProduct);
            this.GroupBox9.Controls.Add(this.cmbProductUnits);
            this.GroupBox9.Controls.Add(this.CmdAdd);
            this.GroupBox9.Controls.Add(this.label8);
            this.GroupBox9.Controls.Add(this.CmdUpdate);
            this.GroupBox9.Controls.Add(this.txtMinDProductUnits);
            this.GroupBox9.Controls.Add(this.txtMaxDProductUnits);
            this.GroupBox9.Controls.Add(this.CmdDelete);
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
            this.GroupBox9.Size = new System.Drawing.Size(795, 263);
            this.GroupBox9.TabIndex = 115;
            this.GroupBox9.TabStop = false;
            this.GroupBox9.Text = "Products Database";
            // 
            // btnModifyProduct
            // 
            this.btnModifyProduct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnModifyProduct.BackColor = System.Drawing.Color.Silver;
            this.btnModifyProduct.Location = new System.Drawing.Point(511, 165);
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
            this.btnRestoreProduct.Location = new System.Drawing.Point(511, 104);
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
            this.cmbProductUnits.Size = new System.Drawing.Size(121, 33);
            this.cmbProductUnits.TabIndex = 128;
            this.cmbProductUnits.SelectedIndexChanged += new System.EventHandler(this.cmbProductUnits_SelectedIndexChanged);
            // 
            // CmdAdd
            // 
            this.CmdAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmdAdd.BackColor = System.Drawing.Color.Silver;
            this.CmdAdd.Location = new System.Drawing.Point(511, 46);
            this.CmdAdd.Name = "CmdAdd";
            this.CmdAdd.Size = new System.Drawing.Size(115, 55);
            this.CmdAdd.TabIndex = 119;
            this.CmdAdd.Text = "ADD";
            this.CmdAdd.UseVisualStyleBackColor = false;
            this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 16);
            this.label8.TabIndex = 127;
            this.label8.Text = "Units:";
            // 
            // CmdUpdate
            // 
            this.CmdUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmdUpdate.BackColor = System.Drawing.Color.Silver;
            this.CmdUpdate.Enabled = false;
            this.CmdUpdate.Location = new System.Drawing.Point(635, 104);
            this.CmdUpdate.Name = "CmdUpdate";
            this.CmdUpdate.Size = new System.Drawing.Size(115, 114);
            this.CmdUpdate.TabIndex = 118;
            this.CmdUpdate.Text = "SAVE";
            this.CmdUpdate.UseVisualStyleBackColor = false;
            this.CmdUpdate.Click += new System.EventHandler(this.CmdUpdate_Click);
            // 
            // txtMinDProductUnits
            // 
            this.txtMinDProductUnits.AutoSize = true;
            this.txtMinDProductUnits.Font = new System.Drawing.Font("Alef", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinDProductUnits.Location = new System.Drawing.Point(235, 146);
            this.txtMinDProductUnits.Name = "txtMinDProductUnits";
            this.txtMinDProductUnits.Size = new System.Drawing.Size(36, 22);
            this.txtMinDProductUnits.TabIndex = 126;
            this.txtMinDProductUnits.Text = "mm";
            // 
            // txtMaxDProductUnits
            // 
            this.txtMaxDProductUnits.AutoSize = true;
            this.txtMaxDProductUnits.Font = new System.Drawing.Font("Alef", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxDProductUnits.Location = new System.Drawing.Point(235, 110);
            this.txtMaxDProductUnits.Name = "txtMaxDProductUnits";
            this.txtMaxDProductUnits.Size = new System.Drawing.Size(36, 22);
            this.txtMaxDProductUnits.TabIndex = 125;
            this.txtMaxDProductUnits.Text = "mm";
            // 
            // CmdDelete
            // 
            this.CmdDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmdDelete.BackColor = System.Drawing.Color.Silver;
            this.CmdDelete.Location = new System.Drawing.Point(632, 45);
            this.CmdDelete.Name = "CmdDelete";
            this.CmdDelete.Size = new System.Drawing.Size(118, 54);
            this.CmdDelete.TabIndex = 116;
            this.CmdDelete.Text = "DELETE";
            this.CmdDelete.UseVisualStyleBackColor = false;
            this.CmdDelete.Click += new System.EventHandler(this.CmdDelete_Click);
            // 
            // CmbGrid
            // 
            this.CmbGrid.FormattingEnabled = true;
            this.CmbGrid.Items.AddRange(new object[] {
            "2x2",
            "3x3",
            "4x4",
            "5"});
            this.CmbGrid.Location = new System.Drawing.Point(140, 179);
            this.CmbGrid.Name = "CmbGrid";
            this.CmbGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbGrid.Size = new System.Drawing.Size(121, 33);
            this.CmbGrid.TabIndex = 124;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 123;
            this.label9.Text = "Grid:";
            // 
            // Txt_Description
            // 
            this.Txt_Description.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_Description.Location = new System.Drawing.Point(160, 72);
            this.Txt_Description.MaxLength = 40;
            this.Txt_Description.Name = "Txt_Description";
            this.Txt_Description.Size = new System.Drawing.Size(324, 30);
            this.Txt_Description.TabIndex = 100;
            this.Txt_Description.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Code
            // 
            this.Txt_Code.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt_Code.Location = new System.Drawing.Point(160, 36);
            this.Txt_Code.MaxLength = 16;
            this.Txt_Code.Name = "Txt_Code";
            this.Txt_Code.Size = new System.Drawing.Size(197, 30);
            this.Txt_Code.TabIndex = 99;
            this.Txt_Code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_MinD
            // 
            this.Txt_MinD.Location = new System.Drawing.Point(160, 143);
            this.Txt_MinD.Name = "Txt_MinD";
            this.Txt_MinD.Size = new System.Drawing.Size(63, 30);
            this.Txt_MinD.TabIndex = 97;
            this.Txt_MinD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label31
            // 
            this.Label31.AutoSize = true;
            this.Label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label31.Location = new System.Drawing.Point(15, 145);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(102, 16);
            this.Label31.TabIndex = 95;
            this.Label31.Text = "Min Diameter:";
            // 
            // Label32
            // 
            this.Label32.AutoSize = true;
            this.Label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label32.Location = new System.Drawing.Point(15, 110);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(106, 16);
            this.Label32.TabIndex = 94;
            this.Label32.Text = "Max Diameter:";
            // 
            // Txt_MaxD
            // 
            this.Txt_MaxD.Location = new System.Drawing.Point(160, 108);
            this.Txt_MaxD.Name = "Txt_MaxD";
            this.Txt_MaxD.Size = new System.Drawing.Size(63, 30);
            this.Txt_MaxD.TabIndex = 93;
            this.Txt_MaxD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label27.Location = new System.Drawing.Point(15, 76);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(147, 16);
            this.Label27.TabIndex = 85;
            this.Label27.Text = "Product Description:";
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label28.Location = new System.Drawing.Point(15, 42);
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
            // trendPage
            // 
            this.trendPage.Controls.Add(this.trendChart);
            this.trendPage.Location = new System.Drawing.Point(4, 44);
            this.trendPage.Name = "trendPage";
            this.trendPage.Size = new System.Drawing.Size(1259, 828);
            this.trendPage.TabIndex = 3;
            this.trendPage.Text = "Trend";
            this.trendPage.UseVisualStyleBackColor = true;
            // 
            // trendChart
            // 
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
            this.Text = "STI";
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
            this.configurationPage.ResumeLayout(false);
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
            this.productsPage.ResumeLayout(false);
            this.GroupBox13.ResumeLayout(false);
            this.GroupBox13.PerformLayout();
            this.GroupBox10.ResumeLayout(false);
            this.GroupBox9.ResumeLayout(false);
            this.GroupBox9.PerformLayout();
            this.trendPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trendChart)).EndInit();
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
        internal System.Windows.Forms.Button triggerModeBtn;
        internal System.Windows.Forms.Button viewModeBtn;
        internal System.Windows.Forms.Button processImageBtn;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.GroupBox GroupActualTargetSize;
        internal System.Windows.Forms.TextBox Txt_MinDiameter;
        internal System.Windows.Forms.Label Label54;
        internal System.Windows.Forms.Label Label55;
        internal System.Windows.Forms.TextBox Txt_MaxDiameter;
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
        internal Button CmdAdd;
        internal Button CmdUpdate;
        internal GroupBox GroupBox10;
        internal ComboBox CmbProducts;
        internal Button CmdDelete;
        internal GroupBox GroupBox9;
        internal TextBox Txt_Description;
        internal TextBox Txt_Code;
        internal TextBox Txt_MinD;
        internal Label Label31;
        internal Label Label32;
        internal TextBox Txt_MaxD;
        internal Label Label27;
        internal Label Label28;
        internal Button Cmd_Save;
        internal GroupBox groupBox2;
        private Label avg_diameter;
        internal Button virtualTriggerBtn;
        private GroupBox boxUnits;
        private Label label4;
        private Button calibrateBtn;
        private Label minDiameterUnitsTxt;
        private Label maxDiameterUnitsTxt;
        private Label euFactorTxt;
        private Label label7;
        internal GroupBox boxROI;
        internal Label label9;
        private ComboBox CmbGrid;
        internal GroupBox GB_Threshold;
        internal TextBox Txt_Threshold;
        private Label txtAvgMinD;
        private Label txtAvgMaxD;
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
        private Label txtEquivalentDiameter;
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
        private PictureBox pictureBox1;
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
        private Label label18;
        private GroupBox gbShapeIndicator;
        internal TextBox Txt_MaxCompacity;
        internal Label label20;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripLabel lblPlcDataStatus;
        internal Button btnModifyProduct;
        internal Label label21;
        internal TextBox txtCompacityHoleLimit;
        private TabPage trendPage;
        private System.Windows.Forms.DataVisualization.Charting.Chart trendChart;
    }
}

