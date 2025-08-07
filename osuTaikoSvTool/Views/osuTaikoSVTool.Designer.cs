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
            btnOpenFile = new Button();
            pnlBeatmapInfoGroup = new Panel();
            lblFileName = new Label();
            pnlDragDropArea = new Panel();
            picDisplayBg = new PictureBox();
            txtTimingFrom = new TextBox();
            txtTimingTo = new TextBox();
            txtSvFrom = new TextBox();
            txtSvTo = new TextBox();
            txtVolumeFrom = new TextBox();
            txtVolumeTo = new TextBox();
            lblTiming = new Label();
            lblSv = new Label();
            lblVolume = new Label();
            chkSvEnable = new CheckBox();
            rdoArithmetic = new RadioButton();
            rdoGeometric = new RadioButton();
            chkEnableVolume = new CheckBox();
            chkEnableIncludeBarline = new CheckBox();
            pnlCalcurationTypeGroup = new Panel();
            btnAdd = new Button();
            chkEnableOffset = new CheckBox();
            txtOffset = new TextBox();
            lblMiliSecond = new Label();
            lblOffset = new Label();
            btnBackup = new Button();
            btnSwapTiming = new Button();
            btnSwapSv = new Button();
            btnSwapVolume = new Button();
            lblKiai = new Label();
            chkEnableKiai = new CheckBox();
            lblKiaiStart = new Label();
            chkEnableKiaiStart = new CheckBox();
            lblKiaiEnd = new Label();
            chkEnableKiaiEnd = new CheckBox();
            btnModify = new Button();
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
            rdoOnlyBookMark = new RadioButton();
            rdoOnlyBarline = new RadioButton();
            rdoOnlySpecificHitObject = new RadioButton();
            pnlSpecificGroup = new Panel();
            btnViewHistory = new Button();
            lblSpecificGridLine2 = new Label();
            picSpecificNormalSpinner = new PictureBox();
            pnlBeatmapInfoGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDisplayBg).BeginInit();
            pnlCalcurationTypeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalDong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalKa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherDong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherKa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherSlider).BeginInit();
            pnlSpecificGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalSpinner).BeginInit();
            SuspendLayout();
            // 
            // btnOpenFile
            // 
            btnOpenFile.AllowDrop = true;
            btnOpenFile.BackColor = Color.DarkCyan;
            btnOpenFile.FlatStyle = FlatStyle.Flat;
            btnOpenFile.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnOpenFile.ForeColor = Color.Cyan;
            btnOpenFile.Location = new Point(130, 133);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(128, 39);
            btnOpenFile.TabIndex = 0;
            btnOpenFile.Text = "ファイルを開く";
            btnOpenFile.UseVisualStyleBackColor = false;
            btnOpenFile.Click += btnOpenFile_Click;
            btnOpenFile.DragDrop += commonDragDrop;
            btnOpenFile.DragEnter += commonDragEnter;
            // 
            // pnlBeatmapInfoGroup
            // 
            pnlBeatmapInfoGroup.BackColor = SystemColors.ControlDarkDark;
            pnlBeatmapInfoGroup.Controls.Add(lblFileName);
            pnlBeatmapInfoGroup.Controls.Add(btnOpenFile);
            pnlBeatmapInfoGroup.Controls.Add(pnlDragDropArea);
            pnlBeatmapInfoGroup.Controls.Add(picDisplayBg);
            pnlBeatmapInfoGroup.Location = new Point(12, 12);
            pnlBeatmapInfoGroup.Name = "pnlBeatmapInfoGroup";
            pnlBeatmapInfoGroup.Size = new Size(384, 216);
            pnlBeatmapInfoGroup.TabIndex = 43;
            // 
            // lblFileName
            // 
            lblFileName.AllowDrop = true;
            lblFileName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblFileName.BackColor = Color.Transparent;
            lblFileName.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblFileName.ForeColor = Color.Gray;
            lblFileName.Location = new Point(2, 47);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(382, 83);
            lblFileName.TabIndex = 0;
            lblFileName.Text = "ファイルを選択してください";
            lblFileName.TextAlign = ContentAlignment.MiddleCenter;
            lblFileName.DragDrop += commonDragDrop;
            lblFileName.DragEnter += commonDragEnter;
            // 
            // pnlDragDropArea
            // 
            pnlDragDropArea.AllowDrop = true;
            pnlDragDropArea.BackColor = Color.Transparent;
            pnlDragDropArea.Location = new Point(0, 0);
            pnlDragDropArea.Name = "pnlDragDropArea";
            pnlDragDropArea.Size = new Size(384, 216);
            pnlDragDropArea.TabIndex = 1;
            pnlDragDropArea.DragDrop += commonDragDrop;
            pnlDragDropArea.DragEnter += commonDragEnter;
            // 
            // picDisplayBg
            // 
            picDisplayBg.BackColor = SystemColors.InactiveCaption;
            picDisplayBg.Location = new Point(0, 0);
            picDisplayBg.Name = "picDisplayBg";
            picDisplayBg.Size = new Size(384, 216);
            picDisplayBg.TabIndex = 2;
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
            // 
            // txtTimingTo
            // 
            txtTimingTo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtTimingTo.BorderStyle = BorderStyle.FixedSingle;
            txtTimingTo.Location = new Point(276, 250);
            txtTimingTo.Name = "txtTimingTo";
            txtTimingTo.Size = new Size(120, 23);
            txtTimingTo.TabIndex = 3;
            // 
            // txtSvFrom
            // 
            txtSvFrom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSvFrom.BackColor = SystemColors.Window;
            txtSvFrom.BorderStyle = BorderStyle.FixedSingle;
            txtSvFrom.Location = new Point(93, 279);
            txtSvFrom.Name = "txtSvFrom";
            txtSvFrom.Size = new Size(120, 23);
            txtSvFrom.TabIndex = 5;
            // 
            // txtSvTo
            // 
            txtSvTo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSvTo.BorderStyle = BorderStyle.FixedSingle;
            txtSvTo.Location = new Point(276, 279);
            txtSvTo.Name = "txtSvTo";
            txtSvTo.Size = new Size(120, 23);
            txtSvTo.TabIndex = 7;
            // 
            // txtVolumeFrom
            // 
            txtVolumeFrom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtVolumeFrom.BorderStyle = BorderStyle.FixedSingle;
            txtVolumeFrom.Location = new Point(93, 308);
            txtVolumeFrom.Name = "txtVolumeFrom";
            txtVolumeFrom.Size = new Size(120, 23);
            txtVolumeFrom.TabIndex = 9;
            // 
            // txtVolumeTo
            // 
            txtVolumeTo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtVolumeTo.BorderStyle = BorderStyle.FixedSingle;
            txtVolumeTo.Location = new Point(276, 308);
            txtVolumeTo.Name = "txtVolumeTo";
            txtVolumeTo.Size = new Size(120, 23);
            txtVolumeTo.TabIndex = 11;
            // 
            // lblTiming
            // 
            lblTiming.AutoSize = true;
            lblTiming.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold);
            lblTiming.ForeColor = Color.White;
            lblTiming.Location = new Point(29, 250);
            lblTiming.Name = "lblTiming";
            lblTiming.Size = new Size(56, 20);
            lblTiming.TabIndex = 42;
            lblTiming.Text = "Timing";
            // 
            // lblSv
            // 
            lblSv.AutoSize = true;
            lblSv.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold);
            lblSv.ForeColor = Color.White;
            lblSv.Location = new Point(29, 279);
            lblSv.Name = "lblSv";
            lblSv.Size = new Size(27, 20);
            lblSv.TabIndex = 41;
            lblSv.Text = "SV";
            // 
            // lblVolume
            // 
            lblVolume.AutoSize = true;
            lblVolume.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold);
            lblVolume.ForeColor = Color.White;
            lblVolume.Location = new Point(30, 308);
            lblVolume.Name = "lblVolume";
            lblVolume.Size = new Size(61, 20);
            lblVolume.TabIndex = 40;
            lblVolume.Text = "Volume";
            // 
            // chkSvEnable
            // 
            chkSvEnable.Checked = true;
            chkSvEnable.CheckState = CheckState.Checked;
            chkSvEnable.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            chkSvEnable.ForeColor = Color.White;
            chkSvEnable.Location = new Point(14, 278);
            chkSvEnable.Name = "chkSvEnable";
            chkSvEnable.Size = new Size(15, 24);
            chkSvEnable.TabIndex = 4;
            chkSvEnable.UseVisualStyleBackColor = true;
            chkSvEnable.CheckedChanged += chkSvEnable_CheckedChanged;
            // 
            // rdoArithmetic
            // 
            rdoArithmetic.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            rdoArithmetic.ForeColor = Color.White;
            rdoArithmetic.Location = new Point(0, 0);
            rdoArithmetic.Name = "rdoArithmetic";
            rdoArithmetic.Size = new Size(52, 24);
            rdoArithmetic.TabIndex = 12;
            rdoArithmetic.TabStop = true;
            rdoArithmetic.Text = "等差";
            rdoArithmetic.UseVisualStyleBackColor = true;
            rdoArithmetic.CheckedChanged += rdoArithmetic_CheckedChanged;
            // 
            // rdoGeometric
            // 
            rdoGeometric.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            rdoGeometric.ForeColor = Color.White;
            rdoGeometric.Location = new Point(-1, 29);
            rdoGeometric.Name = "rdoGeometric";
            rdoGeometric.Size = new Size(58, 24);
            rdoGeometric.TabIndex = 13;
            rdoGeometric.TabStop = true;
            rdoGeometric.Text = "等比";
            rdoGeometric.UseVisualStyleBackColor = true;
            rdoGeometric.CheckedChanged += rdoGeometric_CheckedChanged;
            // 
            // chkEnableVolume
            // 
            chkEnableVolume.Checked = true;
            chkEnableVolume.CheckState = CheckState.Checked;
            chkEnableVolume.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            chkEnableVolume.ForeColor = Color.White;
            chkEnableVolume.Location = new Point(14, 308);
            chkEnableVolume.Name = "chkEnableVolume";
            chkEnableVolume.Size = new Size(15, 24);
            chkEnableVolume.TabIndex = 8;
            chkEnableVolume.UseVisualStyleBackColor = true;
            chkEnableVolume.CheckedChanged += chkEnableVolume_CheckedChanged;
            // 
            // chkEnableIncludeBarline
            // 
            chkEnableIncludeBarline.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            chkEnableIncludeBarline.ForeColor = Color.White;
            chkEnableIncludeBarline.Location = new Point(70, 356);
            chkEnableIncludeBarline.Name = "chkEnableIncludeBarline";
            chkEnableIncludeBarline.Size = new Size(136, 37);
            chkEnableIncludeBarline.TabIndex = 14;
            chkEnableIncludeBarline.Text = "ノーツが置かれていない小節線にもSVをつける";
            chkEnableIncludeBarline.TextAlign = ContentAlignment.BottomLeft;
            chkEnableIncludeBarline.UseVisualStyleBackColor = true;
            // 
            // pnlCalcurationTypeGroup
            // 
            pnlCalcurationTypeGroup.Controls.Add(rdoArithmetic);
            pnlCalcurationTypeGroup.Controls.Add(rdoGeometric);
            pnlCalcurationTypeGroup.Location = new Point(12, 361);
            pnlCalcurationTypeGroup.Name = "pnlCalcurationTypeGroup";
            pnlCalcurationTypeGroup.Size = new Size(57, 53);
            pnlCalcurationTypeGroup.TabIndex = 39;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DarkCyan;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnAdd.ForeColor = Color.Cyan;
            btnAdd.Location = new Point(12, 715);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(189, 39);
            btnAdd.TabIndex = 31;
            btnAdd.Text = "追加";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // chkEnableOffset
            // 
            chkEnableOffset.AutoSize = true;
            chkEnableOffset.Checked = true;
            chkEnableOffset.CheckState = CheckState.Checked;
            chkEnableOffset.Location = new Point(69, 402);
            chkEnableOffset.Name = "chkEnableOffset";
            chkEnableOffset.Size = new Size(15, 14);
            chkEnableOffset.TabIndex = 15;
            chkEnableOffset.UseVisualStyleBackColor = true;
            chkEnableOffset.CheckedChanged += chkEnableOffset_CheckedChanged;
            // 
            // txtOffset
            // 
            txtOffset.BackColor = SystemColors.Window;
            txtOffset.BorderStyle = BorderStyle.FixedSingle;
            txtOffset.Location = new Point(146, 397);
            txtOffset.Name = "txtOffset";
            txtOffset.Size = new Size(40, 23);
            txtOffset.TabIndex = 16;
            // 
            // lblMiliSecond
            // 
            lblMiliSecond.AutoSize = true;
            lblMiliSecond.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            lblMiliSecond.ForeColor = Color.White;
            lblMiliSecond.Location = new Point(191, 402);
            lblMiliSecond.Name = "lblMiliSecond";
            lblMiliSecond.Size = new Size(23, 15);
            lblMiliSecond.TabIndex = 38;
            lblMiliSecond.Text = "ms";
            // 
            // lblOffset
            // 
            lblOffset.AutoSize = true;
            lblOffset.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            lblOffset.ForeColor = Color.White;
            lblOffset.Location = new Point(89, 401);
            lblOffset.Name = "lblOffset";
            lblOffset.Size = new Size(50, 15);
            lblOffset.TabIndex = 37;
            lblOffset.Text = "オフセット";
            // 
            // btnBackup
            // 
            btnBackup.BackColor = Color.DarkCyan;
            btnBackup.FlatStyle = FlatStyle.Flat;
            btnBackup.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnBackup.ForeColor = Color.Cyan;
            btnBackup.Location = new Point(207, 760);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(189, 39);
            btnBackup.TabIndex = 34;
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
            btnSwapTiming.Size = new Size(64, 23);
            btnSwapTiming.TabIndex = 2;
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
            btnSwapSv.Location = new Point(212, 279);
            btnSwapSv.Name = "btnSwapSv";
            btnSwapSv.Size = new Size(64, 23);
            btnSwapSv.TabIndex = 6;
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
            btnSwapVolume.Location = new Point(212, 308);
            btnSwapVolume.Name = "btnSwapVolume";
            btnSwapVolume.Size = new Size(64, 23);
            btnSwapVolume.TabIndex = 10;
            btnSwapVolume.Text = "⇔";
            btnSwapVolume.UseVisualStyleBackColor = true;
            btnSwapVolume.Click += btnSwapVolume_Click;
            // 
            // lblKiai
            // 
            lblKiai.AutoSize = true;
            lblKiai.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            lblKiai.ForeColor = Color.White;
            lblKiai.Location = new Point(89, 473);
            lblKiai.Name = "lblKiai";
            lblKiai.Size = new Size(25, 15);
            lblKiai.TabIndex = 36;
            lblKiai.Text = "kiai";
            // 
            // chkEnableKiai
            // 
            chkEnableKiai.AutoSize = true;
            chkEnableKiai.Location = new Point(69, 474);
            chkEnableKiai.Name = "chkEnableKiai";
            chkEnableKiai.Size = new Size(15, 14);
            chkEnableKiai.TabIndex = 19;
            chkEnableKiai.UseVisualStyleBackColor = true;
            chkEnableKiai.CheckedChanged += chkEnableKiai_CheckedChanged;
            // 
            // lblKiaiStart
            // 
            lblKiaiStart.AutoSize = true;
            lblKiaiStart.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            lblKiaiStart.ForeColor = Color.White;
            lblKiaiStart.Location = new Point(153, 473);
            lblKiaiStart.Name = "lblKiaiStart";
            lblKiaiStart.Size = new Size(64, 15);
            lblKiaiStart.TabIndex = 35;
            lblKiaiStart.Text = "kiaiの始点?";
            // 
            // chkEnableKiaiStart
            // 
            chkEnableKiaiStart.AutoSize = true;
            chkEnableKiaiStart.Location = new Point(133, 474);
            chkEnableKiaiStart.Name = "chkEnableKiaiStart";
            chkEnableKiaiStart.Size = new Size(15, 14);
            chkEnableKiaiStart.TabIndex = 20;
            chkEnableKiaiStart.UseVisualStyleBackColor = true;
            // 
            // lblKiaiEnd
            // 
            lblKiaiEnd.AutoSize = true;
            lblKiaiEnd.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            lblKiaiEnd.ForeColor = Color.White;
            lblKiaiEnd.Location = new Point(153, 503);
            lblKiaiEnd.Name = "lblKiaiEnd";
            lblKiaiEnd.Size = new Size(64, 15);
            lblKiaiEnd.TabIndex = 34;
            lblKiaiEnd.Text = "kiaiの終点?";
            // 
            // chkEnableKiaiEnd
            // 
            chkEnableKiaiEnd.AutoSize = true;
            chkEnableKiaiEnd.Location = new Point(133, 504);
            chkEnableKiaiEnd.Name = "chkEnableKiaiEnd";
            chkEnableKiaiEnd.Size = new Size(15, 14);
            chkEnableKiaiEnd.TabIndex = 21;
            chkEnableKiaiEnd.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            btnModify.BackColor = Color.DarkCyan;
            btnModify.FlatStyle = FlatStyle.Flat;
            btnModify.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnModify.ForeColor = Color.Cyan;
            btnModify.Location = new Point(207, 715);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(189, 39);
            btnModify.TabIndex = 32;
            btnModify.Text = "変更";
            btnModify.UseVisualStyleBackColor = false;
            btnModify.Click += btnModify_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.DarkCyan;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnRemove.ForeColor = Color.Cyan;
            btnRemove.Location = new Point(12, 760);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(189, 39);
            btnRemove.TabIndex = 33;
            btnRemove.Text = "削除";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // chkEnableBeatSnap
            // 
            chkEnableBeatSnap.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            chkEnableBeatSnap.ForeColor = Color.White;
            chkEnableBeatSnap.Location = new Point(69, 427);
            chkEnableBeatSnap.Name = "chkEnableBeatSnap";
            chkEnableBeatSnap.Size = new Size(124, 37);
            chkEnableBeatSnap.TabIndex = 17;
            chkEnableBeatSnap.Text = "ビートスナップ間隔でSVを置く";
            chkEnableBeatSnap.UseVisualStyleBackColor = true;
            chkEnableBeatSnap.CheckedChanged += chkEnableBeatSnap_CheckedChanged;
            // 
            // txtBeatSnap
            // 
            txtBeatSnap.BackColor = SystemColors.WindowFrame;
            txtBeatSnap.BorderStyle = BorderStyle.FixedSingle;
            txtBeatSnap.Enabled = false;
            txtBeatSnap.Location = new Point(210, 435);
            txtBeatSnap.Name = "txtBeatSnap";
            txtBeatSnap.Size = new Size(40, 23);
            txtBeatSnap.TabIndex = 18;
            // 
            // lblBeatSnap
            // 
            lblBeatSnap.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblBeatSnap.ForeColor = Color.White;
            lblBeatSnap.Location = new Point(193, 438);
            lblBeatSnap.Name = "lblBeatSnap";
            lblBeatSnap.Size = new Size(17, 20);
            lblBeatSnap.TabIndex = 33;
            lblBeatSnap.Text = "1/";
            // 
            // picSpecificNormalDong
            // 
            picSpecificNormalDong.Image = Properties.Resources.d;
            picSpecificNormalDong.InitialImage = (Image)resources.GetObject("picSpecificNormalDong.InitialImage");
            picSpecificNormalDong.Location = new Point(265, 449);
            picSpecificNormalDong.Name = "picSpecificNormalDong";
            picSpecificNormalDong.Size = new Size(42, 42);
            picSpecificNormalDong.TabIndex = 25;
            picSpecificNormalDong.TabStop = false;
            // 
            // picSpecificNormalKa
            // 
            picSpecificNormalKa.Image = Properties.Resources.k;
            picSpecificNormalKa.InitialImage = (Image)resources.GetObject("picSpecificNormalKa.InitialImage");
            picSpecificNormalKa.Location = new Point(265, 492);
            picSpecificNormalKa.Name = "picSpecificNormalKa";
            picSpecificNormalKa.Size = new Size(42, 42);
            picSpecificNormalKa.TabIndex = 27;
            picSpecificNormalKa.TabStop = false;
            // 
            // picSpecificFinisherDong
            // 
            picSpecificFinisherDong.Image = Properties.Resources.d;
            picSpecificFinisherDong.InitialImage = (Image)resources.GetObject("picSpecificFinisherDong.InitialImage");
            picSpecificFinisherDong.Location = new Point(308, 449);
            picSpecificFinisherDong.Name = "picSpecificFinisherDong";
            picSpecificFinisherDong.Size = new Size(42, 42);
            picSpecificFinisherDong.TabIndex = 26;
            picSpecificFinisherDong.TabStop = false;
            // 
            // picSpecificFinisherKa
            // 
            picSpecificFinisherKa.Image = Properties.Resources.k;
            picSpecificFinisherKa.InitialImage = (Image)resources.GetObject("picSpecificFinisherKa.InitialImage");
            picSpecificFinisherKa.Location = new Point(308, 492);
            picSpecificFinisherKa.Name = "picSpecificFinisherKa";
            picSpecificFinisherKa.Size = new Size(42, 42);
            picSpecificFinisherKa.TabIndex = 28;
            picSpecificFinisherKa.TabStop = false;
            // 
            // lblSpecificGridLine
            // 
            lblSpecificGridLine.BackColor = Color.White;
            lblSpecificGridLine.Location = new Point(264, 421);
            lblSpecificGridLine.Name = "lblSpecificGridLine";
            lblSpecificGridLine.Size = new Size(87, 157);
            lblSpecificGridLine.TabIndex = 44;
            lblSpecificGridLine.Text = " ";
            // 
            // lblSpecificFinisher
            // 
            lblSpecificFinisher.BackColor = SystemColors.WindowText;
            lblSpecificFinisher.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblSpecificFinisher.ForeColor = SystemColors.Window;
            lblSpecificFinisher.Location = new Point(308, 422);
            lblSpecificFinisher.Name = "lblSpecificFinisher";
            lblSpecificFinisher.Size = new Size(42, 26);
            lblSpecificFinisher.TabIndex = 32;
            lblSpecificFinisher.Text = "大音符";
            lblSpecificFinisher.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSpecificNormal
            // 
            lblSpecificNormal.BackColor = SystemColors.WindowText;
            lblSpecificNormal.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblSpecificNormal.ForeColor = SystemColors.Window;
            lblSpecificNormal.Location = new Point(265, 422);
            lblSpecificNormal.Name = "lblSpecificNormal";
            lblSpecificNormal.Size = new Size(42, 26);
            lblSpecificNormal.TabIndex = 31;
            lblSpecificNormal.Text = "通常";
            lblSpecificNormal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picSpecificNormalSlider
            // 
            picSpecificNormalSlider.Image = Properties.Resources.slider;
            picSpecificNormalSlider.InitialImage = Properties.Resources.slider;
            picSpecificNormalSlider.Location = new Point(265, 535);
            picSpecificNormalSlider.Name = "picSpecificNormalSlider";
            picSpecificNormalSlider.Size = new Size(42, 42);
            picSpecificNormalSlider.TabIndex = 29;
            picSpecificNormalSlider.TabStop = false;
            // 
            // picSpecificFinisherSlider
            // 
            picSpecificFinisherSlider.Image = Properties.Resources.slider;
            picSpecificFinisherSlider.InitialImage = Properties.Resources.slider;
            picSpecificFinisherSlider.Location = new Point(308, 535);
            picSpecificFinisherSlider.Name = "picSpecificFinisherSlider";
            picSpecificFinisherSlider.Size = new Size(42, 42);
            picSpecificFinisherSlider.TabIndex = 30;
            picSpecificFinisherSlider.TabStop = false;
            // 
            // rdoOnlyBookMark
            // 
            rdoOnlyBookMark.AutoSize = true;
            rdoOnlyBookMark.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoOnlyBookMark.ForeColor = Color.White;
            rdoOnlyBookMark.Location = new Point(4, 25);
            rdoOnlyBookMark.Name = "rdoOnlyBookMark";
            rdoOnlyBookMark.Size = new Size(112, 19);
            rdoOnlyBookMark.TabIndex = 23;
            rdoOnlyBookMark.Text = "BookMark上のみ";
            rdoOnlyBookMark.UseVisualStyleBackColor = true;
            rdoOnlyBookMark.CheckedChanged += rdoOnlyBookMark_CheckedChanged;
            // 
            // rdoOnlyBarline
            // 
            rdoOnlyBarline.AutoSize = true;
            rdoOnlyBarline.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoOnlyBarline.ForeColor = Color.White;
            rdoOnlyBarline.Location = new Point(4, 0);
            rdoOnlyBarline.Name = "rdoOnlyBarline";
            rdoOnlyBarline.Size = new Size(82, 19);
            rdoOnlyBarline.TabIndex = 22;
            rdoOnlyBarline.Text = "小節線のみ";
            rdoOnlyBarline.UseVisualStyleBackColor = true;
            rdoOnlyBarline.CheckedChanged += rdoOnlyBarline_CheckedChanged;
            // 
            // rdoOnlySpecificHitObject
            // 
            rdoOnlySpecificHitObject.AutoSize = true;
            rdoOnlySpecificHitObject.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoOnlySpecificHitObject.ForeColor = Color.White;
            rdoOnlySpecificHitObject.Location = new Point(263, 395);
            rdoOnlySpecificHitObject.Name = "rdoOnlySpecificHitObject";
            rdoOnlySpecificHitObject.Size = new Size(132, 19);
            rdoOnlySpecificHitObject.TabIndex = 24;
            rdoOnlySpecificHitObject.Text = "特定のオブジェクトのみ";
            rdoOnlySpecificHitObject.UseVisualStyleBackColor = true;
            rdoOnlySpecificHitObject.CheckedChanged += rdoOnlySpecificHitObject_CheckedChanged;
            // 
            // pnlSpecificGroup
            // 
            pnlSpecificGroup.Controls.Add(rdoOnlyBookMark);
            pnlSpecificGroup.Controls.Add(rdoOnlyBarline);
            pnlSpecificGroup.Location = new Point(259, 345);
            pnlSpecificGroup.Name = "pnlSpecificGroup";
            pnlSpecificGroup.Size = new Size(136, 74);
            pnlSpecificGroup.TabIndex = 45;
            // 
            // btnViewHistory
            // 
            btnViewHistory.BackColor = Color.DarkCyan;
            btnViewHistory.FlatStyle = FlatStyle.Flat;
            btnViewHistory.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnViewHistory.ForeColor = Color.Cyan;
            btnViewHistory.Location = new Point(12, 805);
            btnViewHistory.Name = "btnViewHistory";
            btnViewHistory.Size = new Size(189, 39);
            btnViewHistory.TabIndex = 46;
            btnViewHistory.Text = "履歴";
            btnViewHistory.UseVisualStyleBackColor = false;
            btnViewHistory.Click += btnViewHistory_Click;
            // 
            // lblSpecificGridLine2
            // 
            lblSpecificGridLine2.BackColor = Color.White;
            lblSpecificGridLine2.Location = new Point(264, 578);
            lblSpecificGridLine2.Name = "lblSpecificGridLine2";
            lblSpecificGridLine2.Size = new Size(44, 43);
            lblSpecificGridLine2.TabIndex = 47;
            lblSpecificGridLine2.Text = " ";
            // 
            // picSpecificNormalSpinner
            // 
            picSpecificNormalSpinner.BackgroundImage = Properties.Resources.spinner;
            picSpecificNormalSpinner.Location = new Point(265, 578);
            picSpecificNormalSpinner.Name = "picSpecificNormalSpinner";
            picSpecificNormalSpinner.Size = new Size(42, 42);
            picSpecificNormalSpinner.TabIndex = 48;
            picSpecificNormalSpinner.TabStop = false;
            // 
            // osuTaikoSVTool
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 64, 64);
            ClientSize = new Size(408, 878);
            Controls.Add(picSpecificNormalSpinner);
            Controls.Add(lblSpecificGridLine2);
            Controls.Add(btnViewHistory);
            Controls.Add(rdoOnlySpecificHitObject);
            Controls.Add(picSpecificFinisherSlider);
            Controls.Add(chkEnableIncludeBarline);
            Controls.Add(picSpecificNormalSlider);
            Controls.Add(lblSpecificNormal);
            Controls.Add(lblSpecificFinisher);
            Controls.Add(picSpecificFinisherKa);
            Controls.Add(picSpecificFinisherDong);
            Controls.Add(picSpecificNormalKa);
            Controls.Add(picSpecificNormalDong);
            Controls.Add(lblBeatSnap);
            Controls.Add(txtBeatSnap);
            Controls.Add(chkEnableBeatSnap);
            Controls.Add(btnRemove);
            Controls.Add(btnModify);
            Controls.Add(lblKiaiEnd);
            Controls.Add(chkEnableKiaiEnd);
            Controls.Add(lblKiaiStart);
            Controls.Add(chkEnableKiaiStart);
            Controls.Add(lblKiai);
            Controls.Add(chkEnableKiai);
            Controls.Add(btnSwapVolume);
            Controls.Add(btnSwapSv);
            Controls.Add(btnSwapTiming);
            Controls.Add(btnBackup);
            Controls.Add(lblOffset);
            Controls.Add(lblMiliSecond);
            Controls.Add(txtOffset);
            Controls.Add(chkEnableOffset);
            Controls.Add(btnAdd);
            Controls.Add(pnlCalcurationTypeGroup);
            Controls.Add(chkEnableVolume);
            Controls.Add(chkSvEnable);
            Controls.Add(lblVolume);
            Controls.Add(lblSv);
            Controls.Add(lblTiming);
            Controls.Add(txtVolumeTo);
            Controls.Add(txtVolumeFrom);
            Controls.Add(txtSvTo);
            Controls.Add(txtSvFrom);
            Controls.Add(txtTimingFrom);
            Controls.Add(txtTimingTo);
            Controls.Add(pnlBeatmapInfoGroup);
            Controls.Add(lblSpecificGridLine);
            Controls.Add(pnlSpecificGroup);
            ForeColor = Color.Black;
            Name = "osuTaikoSVTool";
            Text = "osuTaikoSVTool";
            Load += osuTaikoSVTool_Load;
            pnlBeatmapInfoGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picDisplayBg).EndInit();
            pnlCalcurationTypeGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalDong).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalKa).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherDong).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherKa).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherSlider).EndInit();
            pnlSpecificGroup.ResumeLayout(false);
            pnlSpecificGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalSpinner).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOpenFile;
        private Panel pnlBeatmapInfoGroup;
        private Label lblFileName;
        private TextBox txtTimingTo;
        private TextBox txtTimingFrom;
        private TextBox txtSvFrom;
        private TextBox txtSvTo;
        private TextBox txtVolumeFrom;
        private TextBox txtVolumeTo;
        private Label lblTiming;
        private Label lblSv;
        private Label lblVolume;
        private CheckBox chkSvEnable;
        private RadioButton rdoArithmetic;
        private RadioButton rdoGeometric;
        private CheckBox chkEnableVolume;
        private CheckBox chkEnableIncludeBarline;
        private Panel pnlCalcurationTypeGroup;
        private Button btnAdd;
        private CheckBox chkEnableOffset;
        private TextBox txtOffset;
        private Label lblMiliSecond;
        private Label lblOffset;
        private Button btnBackup;
        private Button btnSwapTiming;
        private Button btnSwapSv;
        private Button btnSwapVolume;
        private Label lblKiai;
        private CheckBox chkEnableKiai;
        private Label lblKiaiStart;
        private CheckBox chkEnableKiaiStart;
        private Label lblKiaiEnd;
        private CheckBox chkEnableKiaiEnd;
        private Button btnModify;
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
        private RadioButton rdoOnlyBookMark;
        private RadioButton rdoOnlyBarline;
        private RadioButton rdoOnlySpecificHitObject;
        private Panel pnlSpecificGroup;
        private Panel pnlDragDropArea;
        private Button btnViewHistory;
        private Label lblSpecificGridLine2;
        private PictureBox picSpecificNormalSpinner;
    }
}
