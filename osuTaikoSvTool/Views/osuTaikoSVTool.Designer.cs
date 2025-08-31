using System.Windows.Forms;

namespace osuTaikoSvTool
{
    partial class osuTaikoSVTool
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(osuTaikoSVTool));
            pnlBeatmapInfoGroup = new Panel();
            lblFileName = new Label();
            picDisplayBg = new PictureBox();
            txtTimingFrom = new TextBox();
            txtTimingTo = new TextBox();
            txtSvFrom = new TextBox();
            txtSvTo = new TextBox();
            txtVolumeFrom = new TextBox();
            txtVolumeTo = new TextBox();
            lblTiming = new Label();
            chkEnableSv = new CheckBox();
            rdoArithmetic = new RadioButton();
            rdoGeometric = new RadioButton();
            chkEnableVolume = new CheckBox();
            pnlCalcurationTypeGroup = new Panel();
            btnApply = new Button();
            chkEnableOffset = new CheckBox();
            txtOffset = new TextBox();
            lblMiliSecond = new Label();
            btnBackup = new Button();
            btnSwapTiming = new Button();
            btnSwapSv = new Button();
            btnSwapVolume = new Button();
            chkEnableKiai = new CheckBox();
            chkEnableKiaiStart = new CheckBox();
            chkEnableKiaiEnd = new CheckBox();
            btnRemove = new Button();
            chkEnableBeatSnap = new CheckBox();
            txtBeatSnap = new TextBox();
            lblBeatSnap = new Label();
            picSpecificNormalDong = new PictureBox();
            picSpecificNormalKa = new PictureBox();
            picSpecificFinisherDong = new PictureBox();
            picSpecificFinisherKa = new PictureBox();
            lblSpecificGridLine = new Label();
            lblSpecificFinisher = new Label();
            lblSpecificNormal = new Label();
            picSpecificNormalSlider = new PictureBox();
            picSpecificFinisherSlider = new PictureBox();
            btnViewHistory = new Button();
            lblSpecificGridLine2 = new Label();
            picSpecificNormalSpinner = new PictureBox();
            tabExecuteType = new TabControl();
            tabApplyPage = new TabPage();
            tabSetType = new TabControl();
            tabHitObjectsPage = new TabPage();
            rdoOnlyOutNotes = new RadioButton();
            rdoOnlyOnNotes = new RadioButton();
            chkApplyEndObject = new CheckBox();
            chkApplyStartObject = new CheckBox();
            pnlSpecificGroup = new Panel();
            rdoAllHitObjects = new RadioButton();
            rdoOnlyBarline = new RadioButton();
            rdoOnlyBookMark = new RadioButton();
            rdoOnlySpecificHitObject = new RadioButton();
            tabBeatSnap = new TabPage();
            tabRemovePage = new TabPage();
            chkEnableStartOffset = new CheckBox();
            txtStartOffset = new TextBox();
            lbllblMiliSecondRemove = new Label();
            lblCalculationType = new Label();
            btnSetTimingFrom = new Button();
            btnSetTimingTo = new Button();
            pnlRelativeSvGroup = new Panel();
            txtRelativeBaseSv = new TextBox();
            lblRelativeBaseSv = new Label();
            rdoRelativeMultiply = new RadioButton();
            rdoRelativeSum = new RadioButton();
            chkRelative = new CheckBox();
            pnlBeatmapInfoGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDisplayBg).BeginInit();
            pnlCalcurationTypeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalDong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalKa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherDong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherKa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalSpinner).BeginInit();
            tabExecuteType.SuspendLayout();
            tabApplyPage.SuspendLayout();
            tabSetType.SuspendLayout();
            tabHitObjectsPage.SuspendLayout();
            pnlSpecificGroup.SuspendLayout();
            tabBeatSnap.SuspendLayout();
            tabRemovePage.SuspendLayout();
            pnlRelativeSvGroup.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBeatmapInfoGroup
            // 
            pnlBeatmapInfoGroup.BackColor = SystemColors.ControlDarkDark;
            pnlBeatmapInfoGroup.Controls.Add(lblFileName);
            pnlBeatmapInfoGroup.Controls.Add(picDisplayBg);
            pnlBeatmapInfoGroup.Location = new Point(12, 12);
            pnlBeatmapInfoGroup.Name = "pnlBeatmapInfoGroup";
            pnlBeatmapInfoGroup.Size = new Size(384, 216);
            pnlBeatmapInfoGroup.TabIndex = 12;
            // 
            // lblFileName
            // 
            lblFileName.AllowDrop = true;
            lblFileName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblFileName.BackColor = Color.Transparent;
            lblFileName.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblFileName.ForeColor = Color.White;
            lblFileName.Location = new Point(1, 63);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(382, 90);
            lblFileName.TabIndex = 0;
            lblFileName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picDisplayBg
            // 
            picDisplayBg.BackColor = SystemColors.GrayText;
            picDisplayBg.Location = new Point(0, 0);
            picDisplayBg.Name = "picDisplayBg";
            picDisplayBg.Size = new Size(384, 216);
            picDisplayBg.TabIndex = 1;
            picDisplayBg.TabStop = false;
            // 
            // txtTimingFrom
            // 
            txtTimingFrom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtTimingFrom.BorderStyle = BorderStyle.FixedSingle;
            txtTimingFrom.ForeColor = SystemColors.WindowText;
            txtTimingFrom.Location = new Point(93, 250);
            txtTimingFrom.Name = "txtTimingFrom";
            txtTimingFrom.Size = new Size(120, 23);
            txtTimingFrom.TabIndex = 1;
            txtTimingFrom.TextAlign = HorizontalAlignment.Center;
            txtTimingFrom.Enter += txtTimingFrom_Enter;
            // 
            // txtTimingTo
            // 
            txtTimingTo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtTimingTo.BorderStyle = BorderStyle.FixedSingle;
            txtTimingTo.Location = new Point(276, 250);
            txtTimingTo.Name = "txtTimingTo";
            txtTimingTo.Size = new Size(120, 23);
            txtTimingTo.TabIndex = 2;
            txtTimingTo.TextAlign = HorizontalAlignment.Center;
            txtTimingTo.Enter += txtTimingTo_Enter;
            // 
            // txtSvFrom
            // 
            txtSvFrom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSvFrom.BackColor = SystemColors.Window;
            txtSvFrom.BorderStyle = BorderStyle.FixedSingle;
            txtSvFrom.Location = new Point(93, 308);
            txtSvFrom.Name = "txtSvFrom";
            txtSvFrom.Size = new Size(120, 23);
            txtSvFrom.TabIndex = 3;
            txtSvFrom.TextAlign = HorizontalAlignment.Center;
            txtSvFrom.Enter += txtSvFrom_Enter;
            // 
            // txtSvTo
            // 
            txtSvTo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSvTo.BorderStyle = BorderStyle.FixedSingle;
            txtSvTo.Location = new Point(276, 308);
            txtSvTo.Name = "txtSvTo";
            txtSvTo.Size = new Size(120, 23);
            txtSvTo.TabIndex = 4;
            txtSvTo.TextAlign = HorizontalAlignment.Center;
            txtSvTo.Enter += txtSvTo_Enter;
            // 
            // txtVolumeFrom
            // 
            txtVolumeFrom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtVolumeFrom.BorderStyle = BorderStyle.FixedSingle;
            txtVolumeFrom.Location = new Point(93, 337);
            txtVolumeFrom.Name = "txtVolumeFrom";
            txtVolumeFrom.Size = new Size(120, 23);
            txtVolumeFrom.TabIndex = 5;
            txtVolumeFrom.TextAlign = HorizontalAlignment.Center;
            txtVolumeFrom.Enter += txtVolumeFrom_Enter;
            // 
            // txtVolumeTo
            // 
            txtVolumeTo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtVolumeTo.BorderStyle = BorderStyle.FixedSingle;
            txtVolumeTo.Location = new Point(276, 337);
            txtVolumeTo.Name = "txtVolumeTo";
            txtVolumeTo.Size = new Size(120, 23);
            txtVolumeTo.TabIndex = 6;
            txtVolumeTo.TextAlign = HorizontalAlignment.Center;
            txtVolumeTo.Enter += txtVolumeTo_Enter;
            // 
            // lblTiming
            // 
            lblTiming.AutoSize = true;
            lblTiming.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold);
            lblTiming.ForeColor = Color.White;
            lblTiming.Location = new Point(29, 250);
            lblTiming.Name = "lblTiming";
            lblTiming.Size = new Size(56, 20);
            lblTiming.TabIndex = 12;
            lblTiming.Text = "Timing";
            // 
            // chkEnableSv
            // 
            chkEnableSv.Checked = true;
            chkEnableSv.CheckState = CheckState.Checked;
            chkEnableSv.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold);
            chkEnableSv.ForeColor = Color.White;
            chkEnableSv.Location = new Point(14, 307);
            chkEnableSv.Name = "chkEnableSv";
            chkEnableSv.Size = new Size(80, 24);
            chkEnableSv.TabIndex = 11;
            chkEnableSv.TabStop = false;
            chkEnableSv.Text = "SV";
            chkEnableSv.UseVisualStyleBackColor = true;
            chkEnableSv.CheckedChanged += chkEnableSv_CheckedChanged;
            // 
            // rdoArithmetic
            // 
            rdoArithmetic.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            rdoArithmetic.ForeColor = Color.White;
            rdoArithmetic.Location = new Point(14, 5);
            rdoArithmetic.Name = "rdoArithmetic";
            rdoArithmetic.Size = new Size(52, 24);
            rdoArithmetic.TabIndex = 0;
            rdoArithmetic.Text = "等差";
            rdoArithmetic.UseVisualStyleBackColor = true;
            rdoArithmetic.CheckedChanged += rdoArithmetic_CheckedChanged;
            // 
            // rdoGeometric
            // 
            rdoGeometric.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            rdoGeometric.ForeColor = Color.White;
            rdoGeometric.Location = new Point(14, 31);
            rdoGeometric.Name = "rdoGeometric";
            rdoGeometric.Size = new Size(58, 24);
            rdoGeometric.TabIndex = 1;
            rdoGeometric.Text = "等比";
            rdoGeometric.UseVisualStyleBackColor = true;
            rdoGeometric.CheckedChanged += rdoGeometric_CheckedChanged;
            // 
            // chkEnableVolume
            // 
            chkEnableVolume.Checked = true;
            chkEnableVolume.CheckState = CheckState.Checked;
            chkEnableVolume.Font = new Font("Yu Gothic UI", 10F, FontStyle.Bold);
            chkEnableVolume.ForeColor = Color.White;
            chkEnableVolume.Location = new Point(14, 337);
            chkEnableVolume.Name = "chkEnableVolume";
            chkEnableVolume.Size = new Size(80, 24);
            chkEnableVolume.TabIndex = 10;
            chkEnableVolume.TabStop = false;
            chkEnableVolume.Text = "Volume";
            chkEnableVolume.UseVisualStyleBackColor = true;
            chkEnableVolume.CheckedChanged += chkEnableVolume_CheckedChanged;
            // 
            // pnlCalcurationTypeGroup
            // 
            pnlCalcurationTypeGroup.BorderStyle = BorderStyle.Fixed3D;
            pnlCalcurationTypeGroup.Controls.Add(rdoArithmetic);
            pnlCalcurationTypeGroup.Controls.Add(rdoGeometric);
            pnlCalcurationTypeGroup.Location = new Point(14, 392);
            pnlCalcurationTypeGroup.Name = "pnlCalcurationTypeGroup";
            pnlCalcurationTypeGroup.Size = new Size(81, 66);
            pnlCalcurationTypeGroup.TabIndex = 9;
            // 
            // btnApply
            // 
            btnApply.BackColor = Color.DarkCyan;
            btnApply.FlatAppearance.BorderColor = Color.Cyan;
            btnApply.FlatAppearance.BorderSize = 2;
            btnApply.FlatStyle = FlatStyle.Flat;
            btnApply.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnApply.ForeColor = SystemColors.ControlLightLight;
            btnApply.Location = new Point(96, 235);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(189, 39);
            btnApply.TabIndex = 0;
            btnApply.TabStop = false;
            btnApply.Text = "実行";
            btnApply.UseVisualStyleBackColor = false;
            btnApply.Click += btnApply_Click;
            // 
            // chkEnableOffset
            // 
            chkEnableOffset.AutoSize = true;
            chkEnableOffset.Checked = true;
            chkEnableOffset.CheckState = CheckState.Checked;
            chkEnableOffset.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            chkEnableOffset.ForeColor = Color.White;
            chkEnableOffset.Location = new Point(184, 14);
            chkEnableOffset.Name = "chkEnableOffset";
            chkEnableOffset.Size = new Size(75, 21);
            chkEnableOffset.TabIndex = 3;
            chkEnableOffset.TabStop = false;
            chkEnableOffset.Text = "オフセット";
            chkEnableOffset.UseVisualStyleBackColor = true;
            chkEnableOffset.CheckedChanged += chkEnableOffset_CheckedChanged;
            // 
            // txtOffset
            // 
            txtOffset.BackColor = SystemColors.Window;
            txtOffset.BorderStyle = BorderStyle.FixedSingle;
            txtOffset.Location = new Point(295, 12);
            txtOffset.Name = "txtOffset";
            txtOffset.Size = new Size(40, 27);
            txtOffset.TabIndex = 4;
            txtOffset.TabStop = false;
            // 
            // lblMiliSecond
            // 
            lblMiliSecond.AutoSize = true;
            lblMiliSecond.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            lblMiliSecond.ForeColor = Color.White;
            lblMiliSecond.Location = new Point(340, 17);
            lblMiliSecond.Name = "lblMiliSecond";
            lblMiliSecond.Size = new Size(23, 15);
            lblMiliSecond.TabIndex = 5;
            lblMiliSecond.Text = "ms";
            // 
            // btnBackup
            // 
            btnBackup.BackColor = Color.DarkCyan;
            btnBackup.FlatAppearance.BorderColor = Color.Cyan;
            btnBackup.FlatAppearance.BorderSize = 2;
            btnBackup.FlatStyle = FlatStyle.Flat;
            btnBackup.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnBackup.ForeColor = SystemColors.ControlLightLight;
            btnBackup.Location = new Point(210, 868);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(189, 39);
            btnBackup.TabIndex = 8;
            btnBackup.TabStop = false;
            btnBackup.Text = "バックアップフォルダ";
            btnBackup.UseVisualStyleBackColor = false;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnSwapTiming
            // 
            btnSwapTiming.FlatAppearance.BorderColor = Color.Cyan;
            btnSwapTiming.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSwapTiming.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSwapTiming.FlatStyle = FlatStyle.Flat;
            btnSwapTiming.ForeColor = Color.Cyan;
            btnSwapTiming.Location = new Point(212, 250);
            btnSwapTiming.Name = "btnSwapTiming";
            btnSwapTiming.Size = new Size(65, 23);
            btnSwapTiming.TabIndex = 7;
            btnSwapTiming.TabStop = false;
            btnSwapTiming.Text = "⇔";
            btnSwapTiming.UseVisualStyleBackColor = true;
            btnSwapTiming.Click += btnSwapTiming_Click;
            // 
            // btnSwapSv
            // 
            btnSwapSv.FlatAppearance.BorderColor = Color.Cyan;
            btnSwapSv.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSwapSv.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSwapSv.FlatStyle = FlatStyle.Flat;
            btnSwapSv.ForeColor = Color.Cyan;
            btnSwapSv.Location = new Point(212, 308);
            btnSwapSv.Name = "btnSwapSv";
            btnSwapSv.Size = new Size(65, 23);
            btnSwapSv.TabIndex = 6;
            btnSwapSv.TabStop = false;
            btnSwapSv.Text = "⇔";
            btnSwapSv.UseVisualStyleBackColor = true;
            btnSwapSv.Click += btnSwapSv_Click;
            // 
            // btnSwapVolume
            // 
            btnSwapVolume.FlatAppearance.BorderColor = Color.Cyan;
            btnSwapVolume.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSwapVolume.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSwapVolume.FlatStyle = FlatStyle.Flat;
            btnSwapVolume.ForeColor = Color.Cyan;
            btnSwapVolume.Location = new Point(212, 337);
            btnSwapVolume.Name = "btnSwapVolume";
            btnSwapVolume.Size = new Size(65, 23);
            btnSwapVolume.TabIndex = 5;
            btnSwapVolume.TabStop = false;
            btnSwapVolume.Text = "⇔";
            btnSwapVolume.UseVisualStyleBackColor = true;
            btnSwapVolume.Click += btnSwapVolume_Click;
            // 
            // chkEnableKiai
            // 
            chkEnableKiai.AutoSize = true;
            chkEnableKiai.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            chkEnableKiai.ForeColor = Color.White;
            chkEnableKiai.Location = new Point(16, 14);
            chkEnableKiai.Name = "chkEnableKiai";
            chkEnableKiai.Size = new Size(47, 21);
            chkEnableKiai.TabIndex = 1;
            chkEnableKiai.TabStop = false;
            chkEnableKiai.Text = "kiai";
            chkEnableKiai.UseVisualStyleBackColor = true;
            chkEnableKiai.CheckedChanged += chkEnableKiai_CheckedChanged;
            // 
            // chkEnableKiaiStart
            // 
            chkEnableKiaiStart.AutoSize = true;
            chkEnableKiaiStart.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            chkEnableKiaiStart.ForeColor = Color.White;
            chkEnableKiaiStart.Location = new Point(158, 7);
            chkEnableKiaiStart.Name = "chkEnableKiaiStart";
            chkEnableKiaiStart.Size = new Size(90, 21);
            chkEnableKiaiStart.TabIndex = 5;
            chkEnableKiaiStart.TabStop = false;
            chkEnableKiaiStart.Text = "kiaiの始点?";
            chkEnableKiaiStart.UseVisualStyleBackColor = true;
            // 
            // chkEnableKiaiEnd
            // 
            chkEnableKiaiEnd.AutoSize = true;
            chkEnableKiaiEnd.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            chkEnableKiaiEnd.ForeColor = Color.White;
            chkEnableKiaiEnd.Location = new Point(158, 30);
            chkEnableKiaiEnd.Name = "chkEnableKiaiEnd";
            chkEnableKiaiEnd.Size = new Size(90, 21);
            chkEnableKiaiEnd.TabIndex = 4;
            chkEnableKiaiEnd.TabStop = false;
            chkEnableKiaiEnd.Text = "kiaiの終点?";
            chkEnableKiaiEnd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.DarkCyan;
            btnRemove.FlatAppearance.BorderColor = Color.Cyan;
            btnRemove.FlatAppearance.BorderSize = 2;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnRemove.ForeColor = SystemColors.ControlLightLight;
            btnRemove.Location = new Point(96, 235);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(189, 39);
            btnRemove.TabIndex = 10;
            btnRemove.TabStop = false;
            btnRemove.Text = "実行";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // chkEnableBeatSnap
            // 
            chkEnableBeatSnap.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            chkEnableBeatSnap.ForeColor = Color.White;
            chkEnableBeatSnap.Location = new Point(6, 6);
            chkEnableBeatSnap.Name = "chkEnableBeatSnap";
            chkEnableBeatSnap.Size = new Size(124, 37);
            chkEnableBeatSnap.TabIndex = 0;
            chkEnableBeatSnap.TabStop = false;
            chkEnableBeatSnap.Text = "ビートスナップ間隔でSVを置く";
            chkEnableBeatSnap.UseVisualStyleBackColor = true;
            chkEnableBeatSnap.CheckedChanged += chkEnableBeatSnap_CheckedChanged;
            // 
            // txtBeatSnap
            // 
            txtBeatSnap.BackColor = SystemColors.WindowFrame;
            txtBeatSnap.BorderStyle = BorderStyle.FixedSingle;
            txtBeatSnap.Enabled = false;
            txtBeatSnap.Location = new Point(288, 14);
            txtBeatSnap.Name = "txtBeatSnap";
            txtBeatSnap.Size = new Size(40, 27);
            txtBeatSnap.TabIndex = 2;
            txtBeatSnap.TabStop = false;
            // 
            // lblBeatSnap
            // 
            lblBeatSnap.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblBeatSnap.ForeColor = Color.White;
            lblBeatSnap.Location = new Point(271, 17);
            lblBeatSnap.Name = "lblBeatSnap";
            lblBeatSnap.Size = new Size(17, 20);
            lblBeatSnap.TabIndex = 1;
            lblBeatSnap.Text = "1/";
            // 
            // picSpecificNormalDong
            // 
            picSpecificNormalDong.Image = Properties.Resources.d;
            picSpecificNormalDong.InitialImage = (Image)resources.GetObject("picSpecificNormalDong.InitialImage");
            picSpecificNormalDong.Location = new Point(186, 8);
            picSpecificNormalDong.Name = "picSpecificNormalDong";
            picSpecificNormalDong.Size = new Size(42, 42);
            picSpecificNormalDong.TabIndex = 16;
            picSpecificNormalDong.TabStop = false;
            // 
            // picSpecificNormalKa
            // 
            picSpecificNormalKa.Image = Properties.Resources.k;
            picSpecificNormalKa.InitialImage = (Image)resources.GetObject("picSpecificNormalKa.InitialImage");
            picSpecificNormalKa.Location = new Point(229, 8);
            picSpecificNormalKa.Name = "picSpecificNormalKa";
            picSpecificNormalKa.Size = new Size(42, 42);
            picSpecificNormalKa.TabIndex = 15;
            picSpecificNormalKa.TabStop = false;
            // 
            // picSpecificFinisherDong
            // 
            picSpecificFinisherDong.Image = Properties.Resources.d;
            picSpecificFinisherDong.InitialImage = (Image)resources.GetObject("picSpecificFinisherDong.InitialImage");
            picSpecificFinisherDong.Location = new Point(186, 51);
            picSpecificFinisherDong.Name = "picSpecificFinisherDong";
            picSpecificFinisherDong.Size = new Size(42, 42);
            picSpecificFinisherDong.TabIndex = 12;
            picSpecificFinisherDong.TabStop = false;
            // 
            // picSpecificFinisherKa
            // 
            picSpecificFinisherKa.Image = Properties.Resources.k;
            picSpecificFinisherKa.InitialImage = (Image)resources.GetObject("picSpecificFinisherKa.InitialImage");
            picSpecificFinisherKa.Location = new Point(229, 51);
            picSpecificFinisherKa.Name = "picSpecificFinisherKa";
            picSpecificFinisherKa.Size = new Size(42, 42);
            picSpecificFinisherKa.TabIndex = 11;
            picSpecificFinisherKa.TabStop = false;
            // 
            // lblSpecificGridLine
            // 
            lblSpecificGridLine.BackColor = Color.White;
            lblSpecificGridLine.Location = new Point(158, 7);
            lblSpecificGridLine.Name = "lblSpecificGridLine";
            lblSpecificGridLine.Size = new Size(157, 87);
            lblSpecificGridLine.TabIndex = 17;
            lblSpecificGridLine.Text = " ";
            // 
            // lblSpecificFinisher
            // 
            lblSpecificFinisher.BackColor = SystemColors.WindowText;
            lblSpecificFinisher.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblSpecificFinisher.ForeColor = SystemColors.Window;
            lblSpecificFinisher.Location = new Point(159, 51);
            lblSpecificFinisher.Name = "lblSpecificFinisher";
            lblSpecificFinisher.Size = new Size(26, 42);
            lblSpecificFinisher.TabIndex = 9;
            lblSpecificFinisher.Text = "大音符";
            lblSpecificFinisher.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSpecificNormal
            // 
            lblSpecificNormal.BackColor = SystemColors.WindowText;
            lblSpecificNormal.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblSpecificNormal.ForeColor = SystemColors.Window;
            lblSpecificNormal.Location = new Point(159, 8);
            lblSpecificNormal.Name = "lblSpecificNormal";
            lblSpecificNormal.Size = new Size(26, 42);
            lblSpecificNormal.TabIndex = 7;
            lblSpecificNormal.Text = "通常";
            lblSpecificNormal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picSpecificNormalSlider
            // 
            picSpecificNormalSlider.Image = Properties.Resources.slider;
            picSpecificNormalSlider.InitialImage = Properties.Resources.slider;
            picSpecificNormalSlider.Location = new Point(272, 8);
            picSpecificNormalSlider.Name = "picSpecificNormalSlider";
            picSpecificNormalSlider.Size = new Size(42, 42);
            picSpecificNormalSlider.TabIndex = 10;
            picSpecificNormalSlider.TabStop = false;
            // 
            // picSpecificFinisherSlider
            // 
            picSpecificFinisherSlider.Image = Properties.Resources.slider;
            picSpecificFinisherSlider.InitialImage = Properties.Resources.slider;
            picSpecificFinisherSlider.Location = new Point(272, 51);
            picSpecificFinisherSlider.Name = "picSpecificFinisherSlider";
            picSpecificFinisherSlider.Size = new Size(42, 42);
            picSpecificFinisherSlider.TabIndex = 13;
            picSpecificFinisherSlider.TabStop = false;
            // 
            // btnViewHistory
            // 
            btnViewHistory.BackColor = Color.DarkCyan;
            btnViewHistory.Enabled = false;
            btnViewHistory.FlatAppearance.BorderColor = Color.Cyan;
            btnViewHistory.FlatAppearance.BorderSize = 2;
            btnViewHistory.FlatStyle = FlatStyle.Flat;
            btnViewHistory.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnViewHistory.ForeColor = SystemColors.ControlLightLight;
            btnViewHistory.Location = new Point(10, 868);
            btnViewHistory.Name = "btnViewHistory";
            btnViewHistory.Size = new Size(189, 39);
            btnViewHistory.TabIndex = 4;
            btnViewHistory.TabStop = false;
            btnViewHistory.Text = "履歴";
            btnViewHistory.UseVisualStyleBackColor = false;
            btnViewHistory.Click += btnViewHistory_Click;
            // 
            // lblSpecificGridLine2
            // 
            lblSpecificGridLine2.BackColor = Color.White;
            lblSpecificGridLine2.Location = new Point(315, 7);
            lblSpecificGridLine2.Name = "lblSpecificGridLine2";
            lblSpecificGridLine2.Size = new Size(43, 44);
            lblSpecificGridLine2.TabIndex = 14;
            lblSpecificGridLine2.Text = " ";
            // 
            // picSpecificNormalSpinner
            // 
            picSpecificNormalSpinner.BackgroundImage = Properties.Resources.spinner;
            picSpecificNormalSpinner.Location = new Point(315, 8);
            picSpecificNormalSpinner.Name = "picSpecificNormalSpinner";
            picSpecificNormalSpinner.Size = new Size(42, 42);
            picSpecificNormalSpinner.TabIndex = 8;
            picSpecificNormalSpinner.TabStop = false;
            // 
            // tabExecuteType
            // 
            tabExecuteType.Controls.Add(tabApplyPage);
            tabExecuteType.Controls.Add(tabRemovePage);
            tabExecuteType.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            tabExecuteType.ItemSize = new Size(195, 40);
            tabExecuteType.Location = new Point(8, 495);
            tabExecuteType.Name = "tabExecuteType";
            tabExecuteType.SelectedIndex = 0;
            tabExecuteType.Size = new Size(393, 343);
            tabExecuteType.SizeMode = TabSizeMode.Fixed;
            tabExecuteType.TabIndex = 3;
            tabExecuteType.TabStop = false;
            tabExecuteType.SelectedIndexChanged += tabExecuteType_SelectedIndexChanged;
            // 
            // tabApplyPage
            // 
            tabApplyPage.BackColor = Color.FromArgb(0, 64, 64);
            tabApplyPage.BorderStyle = BorderStyle.Fixed3D;
            tabApplyPage.Controls.Add(btnApply);
            tabApplyPage.Controls.Add(chkEnableKiai);
            tabApplyPage.Controls.Add(tabSetType);
            tabApplyPage.Controls.Add(chkEnableOffset);
            tabApplyPage.Controls.Add(txtOffset);
            tabApplyPage.Controls.Add(lblMiliSecond);
            tabApplyPage.ForeColor = Color.DarkCyan;
            tabApplyPage.Location = new Point(4, 44);
            tabApplyPage.Name = "tabApplyPage";
            tabApplyPage.Padding = new Padding(3);
            tabApplyPage.RightToLeft = RightToLeft.No;
            tabApplyPage.Size = new Size(385, 295);
            tabApplyPage.TabIndex = 0;
            tabApplyPage.Text = "適応";
            // 
            // tabSetType
            // 
            tabSetType.Controls.Add(tabHitObjectsPage);
            tabSetType.Controls.Add(tabBeatSnap);
            tabSetType.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            tabSetType.ItemSize = new Size(190, 40);
            tabSetType.Location = new Point(0, 50);
            tabSetType.Name = "tabSetType";
            tabSetType.SelectedIndex = 0;
            tabSetType.Size = new Size(383, 168);
            tabSetType.SizeMode = TabSizeMode.Fixed;
            tabSetType.TabIndex = 2;
            tabSetType.TabStop = false;
            tabSetType.SelectedIndexChanged += tabSetType_SelectedIndexChanged;
            // 
            // tabHitObjectsPage
            // 
            tabHitObjectsPage.BackColor = Color.FromArgb(0, 64, 64);
            tabHitObjectsPage.BorderStyle = BorderStyle.Fixed3D;
            tabHitObjectsPage.Controls.Add(rdoOnlyOutNotes);
            tabHitObjectsPage.Controls.Add(rdoOnlyOnNotes);
            tabHitObjectsPage.Controls.Add(chkApplyEndObject);
            tabHitObjectsPage.Controls.Add(chkApplyStartObject);
            tabHitObjectsPage.Controls.Add(chkEnableKiaiEnd);
            tabHitObjectsPage.Controls.Add(chkEnableKiaiStart);
            tabHitObjectsPage.Controls.Add(pnlSpecificGroup);
            tabHitObjectsPage.Controls.Add(lblSpecificNormal);
            tabHitObjectsPage.Controls.Add(picSpecificNormalSpinner);
            tabHitObjectsPage.Controls.Add(lblSpecificFinisher);
            tabHitObjectsPage.Controls.Add(picSpecificNormalSlider);
            tabHitObjectsPage.Controls.Add(picSpecificFinisherKa);
            tabHitObjectsPage.Controls.Add(picSpecificFinisherDong);
            tabHitObjectsPage.Controls.Add(picSpecificFinisherSlider);
            tabHitObjectsPage.Controls.Add(lblSpecificGridLine2);
            tabHitObjectsPage.Controls.Add(picSpecificNormalKa);
            tabHitObjectsPage.Controls.Add(picSpecificNormalDong);
            tabHitObjectsPage.Controls.Add(lblSpecificGridLine);
            tabHitObjectsPage.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            tabHitObjectsPage.ForeColor = Color.DarkCyan;
            tabHitObjectsPage.Location = new Point(4, 44);
            tabHitObjectsPage.Name = "tabHitObjectsPage";
            tabHitObjectsPage.Padding = new Padding(3);
            tabHitObjectsPage.RightToLeft = RightToLeft.No;
            tabHitObjectsPage.Size = new Size(375, 120);
            tabHitObjectsPage.TabIndex = 0;
            tabHitObjectsPage.Text = "Objectsのみ";
            // 
            // rdoOnlyOutNotes
            // 
            rdoOnlyOutNotes.AutoSize = true;
            rdoOnlyOutNotes.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoOnlyOutNotes.ForeColor = Color.White;
            rdoOnlyOutNotes.Location = new Point(158, 30);
            rdoOnlyOutNotes.Name = "rdoOnlyOutNotes";
            rdoOnlyOutNotes.Size = new Size(97, 19);
            rdoOnlyOutNotes.TabIndex = 0;
            rdoOnlyOutNotes.Text = "小節線上以外";
            rdoOnlyOutNotes.UseVisualStyleBackColor = true;
            rdoOnlyOutNotes.CheckedChanged += rdoOnlyOutNotes_CheckedChanged;
            // 
            // rdoOnlyOnNotes
            // 
            rdoOnlyOnNotes.AutoSize = true;
            rdoOnlyOnNotes.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoOnlyOnNotes.ForeColor = Color.White;
            rdoOnlyOnNotes.Location = new Point(158, 8);
            rdoOnlyOnNotes.Name = "rdoOnlyOnNotes";
            rdoOnlyOnNotes.Size = new Size(94, 19);
            rdoOnlyOnNotes.TabIndex = 1;
            rdoOnlyOnNotes.Text = "小節線上のみ";
            rdoOnlyOnNotes.UseVisualStyleBackColor = true;
            rdoOnlyOnNotes.CheckedChanged += rdoOnlyOnNotes_CheckedChanged;
            // 
            // chkApplyEndObject
            // 
            chkApplyEndObject.AutoSize = true;
            chkApplyEndObject.Checked = true;
            chkApplyEndObject.CheckState = CheckState.Checked;
            chkApplyEndObject.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            chkApplyEndObject.ForeColor = Color.White;
            chkApplyEndObject.Location = new Point(158, 30);
            chkApplyEndObject.Name = "chkApplyEndObject";
            chkApplyEndObject.Size = new Size(164, 21);
            chkApplyEndObject.TabIndex = 2;
            chkApplyEndObject.TabStop = false;
            chkApplyEndObject.Text = "終点にSV/Volumeを適応";
            chkApplyEndObject.UseVisualStyleBackColor = true;
            // 
            // chkApplyStartObject
            // 
            chkApplyStartObject.AutoSize = true;
            chkApplyStartObject.Checked = true;
            chkApplyStartObject.CheckState = CheckState.Checked;
            chkApplyStartObject.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            chkApplyStartObject.ForeColor = Color.White;
            chkApplyStartObject.Location = new Point(158, 7);
            chkApplyStartObject.Name = "chkApplyStartObject";
            chkApplyStartObject.Size = new Size(164, 21);
            chkApplyStartObject.TabIndex = 3;
            chkApplyStartObject.TabStop = false;
            chkApplyStartObject.Text = "始点にSV/Volumeを適応";
            chkApplyStartObject.UseVisualStyleBackColor = true;
            // 
            // pnlSpecificGroup
            // 
            pnlSpecificGroup.Controls.Add(rdoAllHitObjects);
            pnlSpecificGroup.Controls.Add(rdoOnlyBarline);
            pnlSpecificGroup.Controls.Add(rdoOnlyBookMark);
            pnlSpecificGroup.Controls.Add(rdoOnlySpecificHitObject);
            pnlSpecificGroup.Location = new Point(6, 6);
            pnlSpecificGroup.Name = "pnlSpecificGroup";
            pnlSpecificGroup.Size = new Size(136, 103);
            pnlSpecificGroup.TabIndex = 0;
            // 
            // rdoAllHitObjects
            // 
            rdoAllHitObjects.AutoSize = true;
            rdoAllHitObjects.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoAllHitObjects.ForeColor = Color.White;
            rdoAllHitObjects.Location = new Point(4, 4);
            rdoAllHitObjects.Name = "rdoAllHitObjects";
            rdoAllHitObjects.Size = new Size(115, 19);
            rdoAllHitObjects.TabIndex = 0;
            rdoAllHitObjects.Text = "すべてのHitObject";
            rdoAllHitObjects.UseVisualStyleBackColor = true;
            rdoAllHitObjects.CheckedChanged += rdoAllHitObjects_CheckedChanged;
            // 
            // rdoOnlyBarline
            // 
            rdoOnlyBarline.AutoSize = true;
            rdoOnlyBarline.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoOnlyBarline.ForeColor = Color.White;
            rdoOnlyBarline.Location = new Point(4, 28);
            rdoOnlyBarline.Name = "rdoOnlyBarline";
            rdoOnlyBarline.Size = new Size(61, 19);
            rdoOnlyBarline.TabIndex = 1;
            rdoOnlyBarline.Text = "小節線";
            rdoOnlyBarline.UseVisualStyleBackColor = true;
            rdoOnlyBarline.CheckedChanged += rdoOnlyBarline_CheckedChanged;
            // 
            // rdoOnlyBookMark
            // 
            rdoOnlyBookMark.AutoSize = true;
            rdoOnlyBookMark.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoOnlyBookMark.ForeColor = Color.White;
            rdoOnlyBookMark.Location = new Point(4, 53);
            rdoOnlyBookMark.Name = "rdoOnlyBookMark";
            rdoOnlyBookMark.Size = new Size(112, 19);
            rdoOnlyBookMark.TabIndex = 2;
            rdoOnlyBookMark.Text = "BookMark上のみ";
            rdoOnlyBookMark.UseVisualStyleBackColor = true;
            rdoOnlyBookMark.CheckedChanged += rdoOnlyBookMark_CheckedChanged;
            // 
            // rdoOnlySpecificHitObject
            // 
            rdoOnlySpecificHitObject.AutoSize = true;
            rdoOnlySpecificHitObject.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoOnlySpecificHitObject.ForeColor = Color.White;
            rdoOnlySpecificHitObject.Location = new Point(4, 78);
            rdoOnlySpecificHitObject.Name = "rdoOnlySpecificHitObject";
            rdoOnlySpecificHitObject.Size = new Size(132, 19);
            rdoOnlySpecificHitObject.TabIndex = 3;
            rdoOnlySpecificHitObject.Text = "特定のオブジェクトのみ";
            rdoOnlySpecificHitObject.UseVisualStyleBackColor = true;
            rdoOnlySpecificHitObject.CheckedChanged += rdoOnlySpecificHitObject_CheckedChanged;
            // 
            // tabBeatSnap
            // 
            tabBeatSnap.BackColor = Color.FromArgb(0, 64, 64);
            tabBeatSnap.BorderStyle = BorderStyle.Fixed3D;
            tabBeatSnap.Controls.Add(chkEnableBeatSnap);
            tabBeatSnap.Controls.Add(lblBeatSnap);
            tabBeatSnap.Controls.Add(txtBeatSnap);
            tabBeatSnap.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            tabBeatSnap.ForeColor = Color.DarkCyan;
            tabBeatSnap.Location = new Point(4, 44);
            tabBeatSnap.Name = "tabBeatSnap";
            tabBeatSnap.Padding = new Padding(3);
            tabBeatSnap.RightToLeft = RightToLeft.No;
            tabBeatSnap.Size = new Size(375, 120);
            tabBeatSnap.TabIndex = 1;
            tabBeatSnap.Text = "BeatSnap間隔";
            // 
            // tabRemovePage
            // 
            tabRemovePage.BackColor = Color.FromArgb(0, 64, 64);
            tabRemovePage.BorderStyle = BorderStyle.Fixed3D;
            tabRemovePage.Controls.Add(chkEnableStartOffset);
            tabRemovePage.Controls.Add(txtStartOffset);
            tabRemovePage.Controls.Add(lbllblMiliSecondRemove);
            tabRemovePage.Controls.Add(btnRemove);
            tabRemovePage.ForeColor = Color.DarkCyan;
            tabRemovePage.Location = new Point(4, 44);
            tabRemovePage.Name = "tabRemovePage";
            tabRemovePage.Padding = new Padding(3);
            tabRemovePage.Size = new Size(385, 295);
            tabRemovePage.TabIndex = 1;
            tabRemovePage.Text = "削除";
            // 
            // chkEnableStartOffset
            // 
            chkEnableStartOffset.AutoSize = true;
            chkEnableStartOffset.Checked = true;
            chkEnableStartOffset.CheckState = CheckState.Checked;
            chkEnableStartOffset.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            chkEnableStartOffset.ForeColor = Color.White;
            chkEnableStartOffset.Location = new Point(184, 14);
            chkEnableStartOffset.Name = "chkEnableStartOffset";
            chkEnableStartOffset.Size = new Size(112, 21);
            chkEnableStartOffset.TabIndex = 0;
            chkEnableStartOffset.TabStop = false;
            chkEnableStartOffset.Text = "始点のオフセット";
            chkEnableStartOffset.UseVisualStyleBackColor = true;
            // 
            // txtStartOffset
            // 
            txtStartOffset.BackColor = SystemColors.Window;
            txtStartOffset.BorderStyle = BorderStyle.FixedSingle;
            txtStartOffset.Location = new Point(295, 12);
            txtStartOffset.Name = "txtStartOffset";
            txtStartOffset.Size = new Size(40, 27);
            txtStartOffset.TabIndex = 1;
            txtStartOffset.TabStop = false;
            // 
            // lbllblMiliSecondRemove
            // 
            lbllblMiliSecondRemove.AutoSize = true;
            lbllblMiliSecondRemove.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            lbllblMiliSecondRemove.ForeColor = Color.White;
            lbllblMiliSecondRemove.Location = new Point(340, 17);
            lbllblMiliSecondRemove.Name = "lbllblMiliSecondRemove";
            lbllblMiliSecondRemove.Size = new Size(23, 15);
            lbllblMiliSecondRemove.TabIndex = 9;
            lbllblMiliSecondRemove.Text = "ms";
            // 
            // lblCalculationType
            // 
            lblCalculationType.AutoSize = true;
            lblCalculationType.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblCalculationType.ForeColor = Color.White;
            lblCalculationType.Location = new Point(20, 369);
            lblCalculationType.Name = "lblCalculationType";
            lblCalculationType.Size = new Size(69, 20);
            lblCalculationType.TabIndex = 2;
            lblCalculationType.Text = "計算方法";
            // 
            // btnSetTimingFrom
            // 
            btnSetTimingFrom.FlatAppearance.BorderColor = Color.Cyan;
            btnSetTimingFrom.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSetTimingFrom.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSetTimingFrom.FlatStyle = FlatStyle.Flat;
            btnSetTimingFrom.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnSetTimingFrom.ForeColor = SystemColors.Control;
            btnSetTimingFrom.ImageAlign = ContentAlignment.TopCenter;
            btnSetTimingFrom.Location = new Point(93, 272);
            btnSetTimingFrom.Name = "btnSetTimingFrom";
            btnSetTimingFrom.Size = new Size(120, 28);
            btnSetTimingFrom.TabIndex = 1;
            btnSetTimingFrom.TabStop = false;
            btnSetTimingFrom.Text = "Set Start Timing";
            btnSetTimingFrom.UseVisualStyleBackColor = true;
            btnSetTimingFrom.Click += btnSetTimingFrom_Click;
            // 
            // btnSetTimingTo
            // 
            btnSetTimingTo.FlatAppearance.BorderColor = Color.Cyan;
            btnSetTimingTo.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSetTimingTo.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSetTimingTo.FlatStyle = FlatStyle.Flat;
            btnSetTimingTo.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnSetTimingTo.ForeColor = SystemColors.Control;
            btnSetTimingTo.ImageAlign = ContentAlignment.TopCenter;
            btnSetTimingTo.Location = new Point(276, 272);
            btnSetTimingTo.Name = "btnSetTimingTo";
            btnSetTimingTo.Size = new Size(120, 28);
            btnSetTimingTo.TabIndex = 0;
            btnSetTimingTo.TabStop = false;
            btnSetTimingTo.Text = "Set End Timing";
            btnSetTimingTo.UseVisualStyleBackColor = true;
            btnSetTimingTo.Click += btnSetTimingTo_Click;
            // 
            // pnlRelativeSvGroup
            // 
            pnlRelativeSvGroup.BorderStyle = BorderStyle.Fixed3D;
            pnlRelativeSvGroup.Controls.Add(txtRelativeBaseSv);
            pnlRelativeSvGroup.Controls.Add(lblRelativeBaseSv);
            pnlRelativeSvGroup.Controls.Add(rdoRelativeMultiply);
            pnlRelativeSvGroup.Controls.Add(rdoRelativeSum);
            pnlRelativeSvGroup.Location = new Point(255, 393);
            pnlRelativeSvGroup.Name = "pnlRelativeSvGroup";
            pnlRelativeSvGroup.Size = new Size(140, 85);
            pnlRelativeSvGroup.TabIndex = 11;
            // 
            // txtRelativeBaseSv
            // 
            txtRelativeBaseSv.BackColor = SystemColors.Window;
            txtRelativeBaseSv.BorderStyle = BorderStyle.FixedSingle;
            txtRelativeBaseSv.Location = new Point(62, 29);
            txtRelativeBaseSv.Name = "txtRelativeBaseSv";
            txtRelativeBaseSv.Size = new Size(62, 23);
            txtRelativeBaseSv.TabIndex = 6;
            txtRelativeBaseSv.TabStop = false;
            txtRelativeBaseSv.Text = "0";
            txtRelativeBaseSv.TextAlign = HorizontalAlignment.Right;
            // 
            // lblRelativeBaseSv
            // 
            lblRelativeBaseSv.AutoSize = true;
            lblRelativeBaseSv.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblRelativeBaseSv.ForeColor = Color.White;
            lblRelativeBaseSv.Location = new Point(7, 33);
            lblRelativeBaseSv.Name = "lblRelativeBaseSv";
            lblRelativeBaseSv.Size = new Size(46, 15);
            lblRelativeBaseSv.TabIndex = 14;
            lblRelativeBaseSv.Text = "基礎SV";
            // 
            // rdoRelativeMultiply
            // 
            rdoRelativeMultiply.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            rdoRelativeMultiply.ForeColor = Color.White;
            rdoRelativeMultiply.Location = new Point(7, 3);
            rdoRelativeMultiply.Name = "rdoRelativeMultiply";
            rdoRelativeMultiply.Size = new Size(50, 24);
            rdoRelativeMultiply.TabIndex = 0;
            rdoRelativeMultiply.Text = "乗算";
            rdoRelativeMultiply.UseVisualStyleBackColor = true;
            rdoRelativeMultiply.CheckedChanged += rdoRelativeMultiply_CheckedChanged;
            // 
            // rdoRelativeSum
            // 
            rdoRelativeSum.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            rdoRelativeSum.ForeColor = Color.White;
            rdoRelativeSum.Location = new Point(7, 55);
            rdoRelativeSum.Name = "rdoRelativeSum";
            rdoRelativeSum.Size = new Size(50, 24);
            rdoRelativeSum.TabIndex = 1;
            rdoRelativeSum.Text = "加算";
            rdoRelativeSum.UseVisualStyleBackColor = true;
            rdoRelativeSum.CheckedChanged += rdoRelativeSum_CheckedChanged;
            // 
            // chkRelative
            // 
            chkRelative.AutoSize = true;
            chkRelative.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            chkRelative.ForeColor = Color.White;
            chkRelative.Location = new Point(258, 369);
            chkRelative.Name = "chkRelative";
            chkRelative.Size = new Size(118, 24);
            chkRelative.TabIndex = 13;
            chkRelative.Text = "相対速度変化";
            chkRelative.UseVisualStyleBackColor = true;
            chkRelative.CheckedChanged += chkRelative_CheckedChanged;
            // 
            // osuTaikoSVTool
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 64, 64);
            ClientSize = new Size(408, 938);
            Controls.Add(chkRelative);
            Controls.Add(pnlRelativeSvGroup);
            Controls.Add(btnSetTimingTo);
            Controls.Add(btnSetTimingFrom);
            Controls.Add(lblCalculationType);
            Controls.Add(tabExecuteType);
            Controls.Add(btnViewHistory);
            Controls.Add(btnSwapVolume);
            Controls.Add(btnSwapSv);
            Controls.Add(btnSwapTiming);
            Controls.Add(btnBackup);
            Controls.Add(pnlCalcurationTypeGroup);
            Controls.Add(chkEnableVolume);
            Controls.Add(chkEnableSv);
            Controls.Add(lblTiming);
            Controls.Add(txtVolumeTo);
            Controls.Add(txtVolumeFrom);
            Controls.Add(txtSvTo);
            Controls.Add(txtSvFrom);
            Controls.Add(txtTimingFrom);
            Controls.Add(txtTimingTo);
            Controls.Add(pnlBeatmapInfoGroup);
            ForeColor = Color.Black;
            Name = "osuTaikoSVTool";
            Text = "osuTaikoSVTool";
            Load += osuTaikoSVTool_Load;
            Shown += osuTaikoSVTool_Shown;
            pnlBeatmapInfoGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picDisplayBg).EndInit();
            pnlCalcurationTypeGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalDong).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalKa).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherDong).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherKa).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalSpinner).EndInit();
            tabExecuteType.ResumeLayout(false);
            tabApplyPage.ResumeLayout(false);
            tabApplyPage.PerformLayout();
            tabSetType.ResumeLayout(false);
            tabHitObjectsPage.ResumeLayout(false);
            tabHitObjectsPage.PerformLayout();
            pnlSpecificGroup.ResumeLayout(false);
            pnlSpecificGroup.PerformLayout();
            tabBeatSnap.ResumeLayout(false);
            tabBeatSnap.PerformLayout();
            tabRemovePage.ResumeLayout(false);
            tabRemovePage.PerformLayout();
            pnlRelativeSvGroup.ResumeLayout(false);
            pnlRelativeSvGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel pnlBeatmapInfoGroup;
        private Label lblFileName;
        private TextBox txtTimingTo;
        private TextBox txtTimingFrom;
        private TextBox txtSvFrom;
        private TextBox txtSvTo;
        private TextBox txtVolumeFrom;
        private TextBox txtVolumeTo;
        private Label lblTiming;
        private CheckBox chkEnableSv;
        private RadioButton rdoArithmetic;
        private RadioButton rdoGeometric;
        private CheckBox chkEnableVolume;
        private Panel pnlCalcurationTypeGroup;
        private Button btnApply;
        private CheckBox chkEnableOffset;
        private TextBox txtOffset;
        private Label lblMiliSecond;
        private Button btnBackup;
        private Button btnSwapTiming;
        private Button btnSwapSv;
        private Button btnSwapVolume;
        private CheckBox chkEnableKiai;
        private CheckBox chkEnableKiaiStart;
        private CheckBox chkEnableKiaiEnd;
        private Button btnRemove;
        private CheckBox chkEnableBeatSnap;
        private TextBox txtBeatSnap;
        private Label lblBeatSnap;
        private PictureBox picSpecificNormalDong;
        private PictureBox picSpecificNormalKa;
        private PictureBox picSpecificFinisherDong;
        private PictureBox picSpecificFinisherKa;
        private Label lblSpecificGridLine;
        private Label lblSpecificFinisher;
        private Label lblSpecificNormal;
        private PictureBox picDisplayBg;
        private PictureBox picSpecificNormalSlider;
        private PictureBox picSpecificFinisherSlider;
        private Button btnViewHistory;
        private Label lblSpecificGridLine2;
        private PictureBox picSpecificNormalSpinner;
        private TabControl tabExecuteType;
        private TabPage tabApplyPage;
        private TabPage tabRemovePage;
        private TabControl tabSetType;
        private TabPage tabHitObjectsPage;
        private TabPage tabBeatSnap;
        private Label lblCalculationType;
        private Button btnSetTimingFrom;
        private Button btnSetTimingTo;
        private CheckBox chkEnableStartOffset;
        private TextBox txtStartOffset;
        private Label lbllblMiliSecondRemove;
        private CheckBox chkApplyStartObject;
        private CheckBox chkApplyEndObject;
        private RadioButton rdoOnlyOutNotes;
        private RadioButton rdoOnlyOnNotes;
        private Panel pnlSpecificGroup;
        private RadioButton rdoAllHitObjects;
        private RadioButton rdoOnlyBarline;
        private RadioButton rdoOnlyBookMark;
        private RadioButton rdoOnlySpecificHitObject;
        private Panel pnlRelativeSvGroup;
        private RadioButton rdoRelativeMultiply;
        private RadioButton rdoRelativeSum;
        private CheckBox chkRelative;
        private Label lblRelativeBaseSv;
        private TextBox txtRelativeBaseSv;
    }
}
