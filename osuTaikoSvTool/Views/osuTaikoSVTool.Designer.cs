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
            chkEnableSv = new CheckBox();
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
            btnViewHistory = new Button();
            lblSpecificGridLine2 = new Label();
            picSpecificNormalSpinner = new PictureBox();
            tabExecuteType = new TabControl();
            tabAddPage = new TabPage();
            tabSetType = new TabControl();
            tabHitObjectsPage = new TabPage();
            pnlSpecificGroup = new Panel();
            rdoAllHitObjects = new RadioButton();
            rdoOnlyBookMark = new RadioButton();
            rdoOnlyBarline = new RadioButton();
            rdoOnlySpecificHitObject = new RadioButton();
            tabBeatSnap = new TabPage();
            tabModifyPage = new TabPage();
            chkEnableKiaiModify = new CheckBox();
            lblKiaiStartModify = new Label();
            lblKiaiModify = new Label();
            lblKiaiEndModify = new Label();
            chkEnableKiaiEndModify = new CheckBox();
            chkEnableKiaiStartModify = new CheckBox();
            pnlSpecificGroupModify = new Panel();
            rdoAllHitObjectsModify = new RadioButton();
            rdoOnlyBookMarkModify = new RadioButton();
            rdoOnlyBarlineModify = new RadioButton();
            rdoOnlySpecificHitObjectModify = new RadioButton();
            lblSpecificNormalModify = new Label();
            picSpecificNormalSpinnerModify = new PictureBox();
            chkEnableIncludeBarlineModify = new CheckBox();
            lblSpecificFinisherModify = new Label();
            picSpecificNormalSliderModify = new PictureBox();
            picSpecificFinisherKaModify = new PictureBox();
            picSpecificFinisherDongModify = new PictureBox();
            picSpecificFinisherSliderModify = new PictureBox();
            lblSpecificGridLine2Modify = new Label();
            picSpecificNormalKaModify = new PictureBox();
            picSpecificNormalDongModify = new PictureBox();
            lblSpecificGridLineModify = new Label();
            tabRemovePage = new TabPage();
            lblCalculationType = new Label();
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
            tabAddPage.SuspendLayout();
            tabSetType.SuspendLayout();
            tabHitObjectsPage.SuspendLayout();
            pnlSpecificGroup.SuspendLayout();
            tabBeatSnap.SuspendLayout();
            tabModifyPage.SuspendLayout();
            pnlSpecificGroupModify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalSpinnerModify).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalSliderModify).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherKaModify).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherDongModify).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherSliderModify).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalKaModify).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalDongModify).BeginInit();
            tabRemovePage.SuspendLayout();
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
            // chkEnableSv
            // 
            chkEnableSv.Checked = true;
            chkEnableSv.CheckState = CheckState.Checked;
            chkEnableSv.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            chkEnableSv.ForeColor = Color.White;
            chkEnableSv.Location = new Point(14, 278);
            chkEnableSv.Name = "chkEnableSv";
            chkEnableSv.Size = new Size(15, 24);
            chkEnableSv.TabIndex = 4;
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
            rdoGeometric.Location = new Point(14, 31);
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
            chkEnableIncludeBarline.Location = new Point(158, 8);
            chkEnableIncludeBarline.Name = "chkEnableIncludeBarline";
            chkEnableIncludeBarline.Size = new Size(192, 37);
            chkEnableIncludeBarline.TabIndex = 14;
            chkEnableIncludeBarline.Text = "ノーツが置かれていない小節線にもSVをつける";
            chkEnableIncludeBarline.TextAlign = ContentAlignment.BottomLeft;
            chkEnableIncludeBarline.UseVisualStyleBackColor = true;
            // 
            // pnlCalcurationTypeGroup
            // 
            pnlCalcurationTypeGroup.BorderStyle = BorderStyle.Fixed3D;
            pnlCalcurationTypeGroup.Controls.Add(rdoArithmetic);
            pnlCalcurationTypeGroup.Controls.Add(rdoGeometric);
            pnlCalcurationTypeGroup.Location = new Point(14, 363);
            pnlCalcurationTypeGroup.Name = "pnlCalcurationTypeGroup";
            pnlCalcurationTypeGroup.Size = new Size(81, 66);
            pnlCalcurationTypeGroup.TabIndex = 39;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DarkCyan;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnAdd.ForeColor = Color.Cyan;
            btnAdd.Location = new Point(96, 264);
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
            chkEnableOffset.Location = new Point(218, 17);
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
            txtOffset.Location = new Point(295, 12);
            txtOffset.Name = "txtOffset";
            txtOffset.Size = new Size(40, 27);
            txtOffset.TabIndex = 16;
            // 
            // lblMiliSecond
            // 
            lblMiliSecond.AutoSize = true;
            lblMiliSecond.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            lblMiliSecond.ForeColor = Color.White;
            lblMiliSecond.Location = new Point(340, 17);
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
            lblOffset.Location = new Point(238, 16);
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
            btnBackup.Location = new Point(210, 848);
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
            lblKiai.Location = new Point(36, 16);
            lblKiai.Name = "lblKiai";
            lblKiai.Size = new Size(25, 15);
            lblKiai.TabIndex = 36;
            lblKiai.Text = "kiai";
            // 
            // chkEnableKiai
            // 
            chkEnableKiai.AutoSize = true;
            chkEnableKiai.Location = new Point(16, 17);
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
            lblKiaiStart.Location = new Point(100, 16);
            lblKiaiStart.Name = "lblKiaiStart";
            lblKiaiStart.Size = new Size(64, 15);
            lblKiaiStart.TabIndex = 35;
            lblKiaiStart.Text = "kiaiの始点?";
            // 
            // chkEnableKiaiStart
            // 
            chkEnableKiaiStart.AutoSize = true;
            chkEnableKiaiStart.Location = new Point(80, 17);
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
            lblKiaiEnd.Location = new Point(100, 46);
            lblKiaiEnd.Name = "lblKiaiEnd";
            lblKiaiEnd.Size = new Size(64, 15);
            lblKiaiEnd.TabIndex = 34;
            lblKiaiEnd.Text = "kiaiの終点?";
            // 
            // chkEnableKiaiEnd
            // 
            chkEnableKiaiEnd.AutoSize = true;
            chkEnableKiaiEnd.Location = new Point(80, 47);
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
            btnModify.Location = new Point(96, 264);
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
            btnRemove.Location = new Point(96, 264);
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
            chkEnableBeatSnap.Location = new Point(6, 6);
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
            txtBeatSnap.Location = new Point(288, 14);
            txtBeatSnap.Name = "txtBeatSnap";
            txtBeatSnap.Size = new Size(40, 27);
            txtBeatSnap.TabIndex = 18;
            // 
            // lblBeatSnap
            // 
            lblBeatSnap.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblBeatSnap.ForeColor = Color.White;
            lblBeatSnap.Location = new Point(271, 17);
            lblBeatSnap.Name = "lblBeatSnap";
            lblBeatSnap.Size = new Size(17, 20);
            lblBeatSnap.TabIndex = 33;
            lblBeatSnap.Text = "1/";
            // 
            // picSpecificNormalDong
            // 
            picSpecificNormalDong.Image = Properties.Resources.d;
            picSpecificNormalDong.InitialImage = (Image)resources.GetObject("picSpecificNormalDong.InitialImage");
            picSpecificNormalDong.Location = new Point(186, 8);
            picSpecificNormalDong.Name = "picSpecificNormalDong";
            picSpecificNormalDong.Size = new Size(42, 42);
            picSpecificNormalDong.TabIndex = 25;
            picSpecificNormalDong.TabStop = false;
            // 
            // picSpecificNormalKa
            // 
            picSpecificNormalKa.Image = Properties.Resources.k;
            picSpecificNormalKa.InitialImage = (Image)resources.GetObject("picSpecificNormalKa.InitialImage");
            picSpecificNormalKa.Location = new Point(229, 8);
            picSpecificNormalKa.Name = "picSpecificNormalKa";
            picSpecificNormalKa.Size = new Size(42, 42);
            picSpecificNormalKa.TabIndex = 27;
            picSpecificNormalKa.TabStop = false;
            // 
            // picSpecificFinisherDong
            // 
            picSpecificFinisherDong.Image = Properties.Resources.d;
            picSpecificFinisherDong.InitialImage = (Image)resources.GetObject("picSpecificFinisherDong.InitialImage");
            picSpecificFinisherDong.Location = new Point(186, 51);
            picSpecificFinisherDong.Name = "picSpecificFinisherDong";
            picSpecificFinisherDong.Size = new Size(42, 42);
            picSpecificFinisherDong.TabIndex = 26;
            picSpecificFinisherDong.TabStop = false;
            // 
            // picSpecificFinisherKa
            // 
            picSpecificFinisherKa.Image = Properties.Resources.k;
            picSpecificFinisherKa.InitialImage = (Image)resources.GetObject("picSpecificFinisherKa.InitialImage");
            picSpecificFinisherKa.Location = new Point(229, 51);
            picSpecificFinisherKa.Name = "picSpecificFinisherKa";
            picSpecificFinisherKa.Size = new Size(42, 42);
            picSpecificFinisherKa.TabIndex = 28;
            picSpecificFinisherKa.TabStop = false;
            // 
            // lblSpecificGridLine
            // 
            lblSpecificGridLine.BackColor = Color.White;
            lblSpecificGridLine.Location = new Point(158, 7);
            lblSpecificGridLine.Name = "lblSpecificGridLine";
            lblSpecificGridLine.Size = new Size(157, 87);
            lblSpecificGridLine.TabIndex = 44;
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
            lblSpecificFinisher.TabIndex = 32;
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
            lblSpecificNormal.TabIndex = 31;
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
            picSpecificNormalSlider.TabIndex = 29;
            picSpecificNormalSlider.TabStop = false;
            // 
            // picSpecificFinisherSlider
            // 
            picSpecificFinisherSlider.Image = Properties.Resources.slider;
            picSpecificFinisherSlider.InitialImage = Properties.Resources.slider;
            picSpecificFinisherSlider.Location = new Point(272, 51);
            picSpecificFinisherSlider.Name = "picSpecificFinisherSlider";
            picSpecificFinisherSlider.Size = new Size(42, 42);
            picSpecificFinisherSlider.TabIndex = 30;
            picSpecificFinisherSlider.TabStop = false;
            // 
            // btnViewHistory
            // 
            btnViewHistory.BackColor = Color.DarkCyan;
            btnViewHistory.FlatStyle = FlatStyle.Flat;
            btnViewHistory.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnViewHistory.ForeColor = Color.Cyan;
            btnViewHistory.Location = new Point(10, 848);
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
            lblSpecificGridLine2.Location = new Point(315, 7);
            lblSpecificGridLine2.Name = "lblSpecificGridLine2";
            lblSpecificGridLine2.Size = new Size(43, 44);
            lblSpecificGridLine2.TabIndex = 47;
            lblSpecificGridLine2.Text = " ";
            // 
            // picSpecificNormalSpinner
            // 
            picSpecificNormalSpinner.BackgroundImage = Properties.Resources.spinner;
            picSpecificNormalSpinner.Location = new Point(315, 8);
            picSpecificNormalSpinner.Name = "picSpecificNormalSpinner";
            picSpecificNormalSpinner.Size = new Size(42, 42);
            picSpecificNormalSpinner.TabIndex = 48;
            picSpecificNormalSpinner.TabStop = false;
            // 
            // tabExecuteType
            // 
            tabExecuteType.Controls.Add(tabAddPage);
            tabExecuteType.Controls.Add(tabModifyPage);
            tabExecuteType.Controls.Add(tabRemovePage);
            tabExecuteType.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            tabExecuteType.ItemSize = new Size(130, 40);
            tabExecuteType.Location = new Point(8, 446);
            tabExecuteType.Name = "tabExecuteType";
            tabExecuteType.SelectedIndex = 0;
            tabExecuteType.Size = new Size(393, 372);
            tabExecuteType.SizeMode = TabSizeMode.Fixed;
            tabExecuteType.TabIndex = 49;
            tabExecuteType.SelectedIndexChanged += tabExecuteType_SelectedIndexChanged;
            // 
            // tabAddPage
            // 
            tabAddPage.BackColor = Color.FromArgb(0, 64, 64);
            tabAddPage.BorderStyle = BorderStyle.Fixed3D;
            tabAddPage.Controls.Add(btnAdd);
            tabAddPage.Controls.Add(chkEnableKiai);
            tabAddPage.Controls.Add(tabSetType);
            tabAddPage.Controls.Add(lblKiaiStart);
            tabAddPage.Controls.Add(chkEnableOffset);
            tabAddPage.Controls.Add(lblKiai);
            tabAddPage.Controls.Add(txtOffset);
            tabAddPage.Controls.Add(lblKiaiEnd);
            tabAddPage.Controls.Add(lblMiliSecond);
            tabAddPage.Controls.Add(chkEnableKiaiEnd);
            tabAddPage.Controls.Add(lblOffset);
            tabAddPage.Controls.Add(chkEnableKiaiStart);
            tabAddPage.ForeColor = Color.DarkCyan;
            tabAddPage.Location = new Point(4, 44);
            tabAddPage.Name = "tabAddPage";
            tabAddPage.Padding = new Padding(3);
            tabAddPage.RightToLeft = RightToLeft.No;
            tabAddPage.Size = new Size(385, 324);
            tabAddPage.TabIndex = 0;
            tabAddPage.Text = "追加";
            tabAddPage.Click += tabPage1_Click;
            // 
            // tabSetType
            // 
            tabSetType.Controls.Add(tabHitObjectsPage);
            tabSetType.Controls.Add(tabBeatSnap);
            tabSetType.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            tabSetType.ItemSize = new Size(190, 40);
            tabSetType.Location = new Point(0, 79);
            tabSetType.Name = "tabSetType";
            tabSetType.SelectedIndex = 0;
            tabSetType.Size = new Size(383, 168);
            tabSetType.SizeMode = TabSizeMode.Fixed;
            tabSetType.TabIndex = 50;
            tabSetType.SelectedIndexChanged += tabSetType_SelectedIndexChanged;
            // 
            // tabHitObjectsPage
            // 
            tabHitObjectsPage.BackColor = Color.FromArgb(0, 64, 64);
            tabHitObjectsPage.BorderStyle = BorderStyle.Fixed3D;
            tabHitObjectsPage.Controls.Add(pnlSpecificGroup);
            tabHitObjectsPage.Controls.Add(lblSpecificNormal);
            tabHitObjectsPage.Controls.Add(picSpecificNormalSpinner);
            tabHitObjectsPage.Controls.Add(chkEnableIncludeBarline);
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
            // pnlSpecificGroup
            // 
            pnlSpecificGroup.Controls.Add(rdoAllHitObjects);
            pnlSpecificGroup.Controls.Add(rdoOnlyBookMark);
            pnlSpecificGroup.Controls.Add(rdoOnlyBarline);
            pnlSpecificGroup.Controls.Add(rdoOnlySpecificHitObject);
            pnlSpecificGroup.Location = new Point(6, 6);
            pnlSpecificGroup.Name = "pnlSpecificGroup";
            pnlSpecificGroup.Size = new Size(136, 103);
            pnlSpecificGroup.TabIndex = 45;
            // 
            // rdoAllHitObjects
            // 
            rdoAllHitObjects.AutoSize = true;
            rdoAllHitObjects.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoAllHitObjects.ForeColor = Color.White;
            rdoAllHitObjects.Location = new Point(4, 4);
            rdoAllHitObjects.Name = "rdoAllHitObjects";
            rdoAllHitObjects.Size = new Size(115, 19);
            rdoAllHitObjects.TabIndex = 25;
            rdoAllHitObjects.Text = "すべてのHitObject";
            rdoAllHitObjects.UseVisualStyleBackColor = true;
            rdoAllHitObjects.CheckedChanged += rdoAllHitObjects_CheckedChanged;
            // 
            // rdoOnlyBookMark
            // 
            rdoOnlyBookMark.AutoSize = true;
            rdoOnlyBookMark.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoOnlyBookMark.ForeColor = Color.White;
            rdoOnlyBookMark.Location = new Point(4, 53);
            rdoOnlyBookMark.Name = "rdoOnlyBookMark";
            rdoOnlyBookMark.Size = new Size(112, 19);
            rdoOnlyBookMark.TabIndex = 23;
            rdoOnlyBookMark.Text = "BookMark上のみ";
            rdoOnlyBookMark.UseVisualStyleBackColor = true;
            // 
            // rdoOnlyBarline
            // 
            rdoOnlyBarline.AutoSize = true;
            rdoOnlyBarline.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoOnlyBarline.ForeColor = Color.White;
            rdoOnlyBarline.Location = new Point(4, 28);
            rdoOnlyBarline.Name = "rdoOnlyBarline";
            rdoOnlyBarline.Size = new Size(82, 19);
            rdoOnlyBarline.TabIndex = 22;
            rdoOnlyBarline.Text = "小節線のみ";
            rdoOnlyBarline.UseVisualStyleBackColor = true;
            // 
            // rdoOnlySpecificHitObject
            // 
            rdoOnlySpecificHitObject.AutoSize = true;
            rdoOnlySpecificHitObject.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoOnlySpecificHitObject.ForeColor = Color.White;
            rdoOnlySpecificHitObject.Location = new Point(4, 78);
            rdoOnlySpecificHitObject.Name = "rdoOnlySpecificHitObject";
            rdoOnlySpecificHitObject.Size = new Size(132, 19);
            rdoOnlySpecificHitObject.TabIndex = 24;
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
            // tabModifyPage
            // 
            tabModifyPage.BackColor = Color.FromArgb(0, 64, 64);
            tabModifyPage.BorderStyle = BorderStyle.Fixed3D;
            tabModifyPage.Controls.Add(chkEnableKiaiModify);
            tabModifyPage.Controls.Add(lblKiaiStartModify);
            tabModifyPage.Controls.Add(lblKiaiModify);
            tabModifyPage.Controls.Add(lblKiaiEndModify);
            tabModifyPage.Controls.Add(chkEnableKiaiEndModify);
            tabModifyPage.Controls.Add(chkEnableKiaiStartModify);
            tabModifyPage.Controls.Add(pnlSpecificGroupModify);
            tabModifyPage.Controls.Add(lblSpecificNormalModify);
            tabModifyPage.Controls.Add(picSpecificNormalSpinnerModify);
            tabModifyPage.Controls.Add(chkEnableIncludeBarlineModify);
            tabModifyPage.Controls.Add(lblSpecificFinisherModify);
            tabModifyPage.Controls.Add(picSpecificNormalSliderModify);
            tabModifyPage.Controls.Add(picSpecificFinisherKaModify);
            tabModifyPage.Controls.Add(picSpecificFinisherDongModify);
            tabModifyPage.Controls.Add(picSpecificFinisherSliderModify);
            tabModifyPage.Controls.Add(lblSpecificGridLine2Modify);
            tabModifyPage.Controls.Add(picSpecificNormalKaModify);
            tabModifyPage.Controls.Add(picSpecificNormalDongModify);
            tabModifyPage.Controls.Add(lblSpecificGridLineModify);
            tabModifyPage.Controls.Add(btnModify);
            tabModifyPage.ForeColor = Color.DarkCyan;
            tabModifyPage.Location = new Point(4, 44);
            tabModifyPage.Name = "tabModifyPage";
            tabModifyPage.Padding = new Padding(3);
            tabModifyPage.RightToLeft = RightToLeft.No;
            tabModifyPage.Size = new Size(385, 324);
            tabModifyPage.TabIndex = 1;
            tabModifyPage.Text = "変更";
            // 
            // chkEnableKiaiModify
            // 
            chkEnableKiaiModify.AutoSize = true;
            chkEnableKiaiModify.Location = new Point(16, 17);
            chkEnableKiaiModify.Name = "chkEnableKiaiModify";
            chkEnableKiaiModify.Size = new Size(15, 14);
            chkEnableKiaiModify.TabIndex = 62;
            chkEnableKiaiModify.UseVisualStyleBackColor = true;
            chkEnableKiaiModify.CheckedChanged += chkEnableKiaiModify_CheckedChanged;
            // 
            // lblKiaiStartModify
            // 
            lblKiaiStartModify.AutoSize = true;
            lblKiaiStartModify.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            lblKiaiStartModify.ForeColor = Color.White;
            lblKiaiStartModify.Location = new Point(100, 16);
            lblKiaiStartModify.Name = "lblKiaiStartModify";
            lblKiaiStartModify.Size = new Size(64, 15);
            lblKiaiStartModify.TabIndex = 66;
            lblKiaiStartModify.Text = "kiaiの始点?";
            // 
            // lblKiaiModify
            // 
            lblKiaiModify.AutoSize = true;
            lblKiaiModify.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            lblKiaiModify.ForeColor = Color.White;
            lblKiaiModify.Location = new Point(36, 16);
            lblKiaiModify.Name = "lblKiaiModify";
            lblKiaiModify.Size = new Size(25, 15);
            lblKiaiModify.TabIndex = 67;
            lblKiaiModify.Text = "kiai";
            // 
            // lblKiaiEndModify
            // 
            lblKiaiEndModify.AutoSize = true;
            lblKiaiEndModify.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            lblKiaiEndModify.ForeColor = Color.White;
            lblKiaiEndModify.Location = new Point(100, 46);
            lblKiaiEndModify.Name = "lblKiaiEndModify";
            lblKiaiEndModify.Size = new Size(64, 15);
            lblKiaiEndModify.TabIndex = 65;
            lblKiaiEndModify.Text = "kiaiの終点?";
            // 
            // chkEnableKiaiEndModify
            // 
            chkEnableKiaiEndModify.AutoSize = true;
            chkEnableKiaiEndModify.Location = new Point(80, 47);
            chkEnableKiaiEndModify.Name = "chkEnableKiaiEndModify";
            chkEnableKiaiEndModify.Size = new Size(15, 14);
            chkEnableKiaiEndModify.TabIndex = 64;
            chkEnableKiaiEndModify.UseVisualStyleBackColor = true;
            // 
            // chkEnableKiaiStartModify
            // 
            chkEnableKiaiStartModify.AutoSize = true;
            chkEnableKiaiStartModify.Location = new Point(80, 17);
            chkEnableKiaiStartModify.Name = "chkEnableKiaiStartModify";
            chkEnableKiaiStartModify.Size = new Size(15, 14);
            chkEnableKiaiStartModify.TabIndex = 63;
            chkEnableKiaiStartModify.UseVisualStyleBackColor = true;
            // 
            // pnlSpecificGroupModify
            // 
            pnlSpecificGroupModify.Controls.Add(rdoAllHitObjectsModify);
            pnlSpecificGroupModify.Controls.Add(rdoOnlyBookMarkModify);
            pnlSpecificGroupModify.Controls.Add(rdoOnlyBarlineModify);
            pnlSpecificGroupModify.Controls.Add(rdoOnlySpecificHitObjectModify);
            pnlSpecificGroupModify.Location = new Point(13, 73);
            pnlSpecificGroupModify.Name = "pnlSpecificGroupModify";
            pnlSpecificGroupModify.Size = new Size(136, 103);
            pnlSpecificGroupModify.TabIndex = 59;
            // 
            // rdoAllHitObjectsModify
            // 
            rdoAllHitObjectsModify.AutoSize = true;
            rdoAllHitObjectsModify.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoAllHitObjectsModify.ForeColor = Color.White;
            rdoAllHitObjectsModify.Location = new Point(4, 4);
            rdoAllHitObjectsModify.Name = "rdoAllHitObjectsModify";
            rdoAllHitObjectsModify.Size = new Size(115, 19);
            rdoAllHitObjectsModify.TabIndex = 25;
            rdoAllHitObjectsModify.Text = "すべてのHitObject";
            rdoAllHitObjectsModify.UseVisualStyleBackColor = true;
            rdoAllHitObjectsModify.CheckedChanged += rdoAllHitObjectsModify_CheckedChanged;
            // 
            // rdoOnlyBookMarkModify
            // 
            rdoOnlyBookMarkModify.AutoSize = true;
            rdoOnlyBookMarkModify.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoOnlyBookMarkModify.ForeColor = Color.White;
            rdoOnlyBookMarkModify.Location = new Point(4, 53);
            rdoOnlyBookMarkModify.Name = "rdoOnlyBookMarkModify";
            rdoOnlyBookMarkModify.Size = new Size(112, 19);
            rdoOnlyBookMarkModify.TabIndex = 23;
            rdoOnlyBookMarkModify.Text = "BookMark上のみ";
            rdoOnlyBookMarkModify.UseVisualStyleBackColor = true;
            // 
            // rdoOnlyBarlineModify
            // 
            rdoOnlyBarlineModify.AutoSize = true;
            rdoOnlyBarlineModify.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoOnlyBarlineModify.ForeColor = Color.White;
            rdoOnlyBarlineModify.Location = new Point(4, 28);
            rdoOnlyBarlineModify.Name = "rdoOnlyBarlineModify";
            rdoOnlyBarlineModify.Size = new Size(82, 19);
            rdoOnlyBarlineModify.TabIndex = 22;
            rdoOnlyBarlineModify.Text = "小節線のみ";
            rdoOnlyBarlineModify.UseVisualStyleBackColor = true;
            // 
            // rdoOnlySpecificHitObjectModify
            // 
            rdoOnlySpecificHitObjectModify.AutoSize = true;
            rdoOnlySpecificHitObjectModify.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            rdoOnlySpecificHitObjectModify.ForeColor = Color.White;
            rdoOnlySpecificHitObjectModify.Location = new Point(4, 78);
            rdoOnlySpecificHitObjectModify.Name = "rdoOnlySpecificHitObjectModify";
            rdoOnlySpecificHitObjectModify.Size = new Size(132, 19);
            rdoOnlySpecificHitObjectModify.TabIndex = 24;
            rdoOnlySpecificHitObjectModify.Text = "特定のオブジェクトのみ";
            rdoOnlySpecificHitObjectModify.UseVisualStyleBackColor = true;
            rdoOnlySpecificHitObjectModify.CheckedChanged += rdoOnlySpecificHitObjectModify_CheckedChanged;
            // 
            // lblSpecificNormalModify
            // 
            lblSpecificNormalModify.BackColor = SystemColors.WindowText;
            lblSpecificNormalModify.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblSpecificNormalModify.ForeColor = SystemColors.Window;
            lblSpecificNormalModify.Location = new Point(166, 75);
            lblSpecificNormalModify.Name = "lblSpecificNormalModify";
            lblSpecificNormalModify.Size = new Size(26, 42);
            lblSpecificNormalModify.TabIndex = 56;
            lblSpecificNormalModify.Text = "通常";
            lblSpecificNormalModify.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picSpecificNormalSpinnerModify
            // 
            picSpecificNormalSpinnerModify.BackgroundImage = Properties.Resources.spinner;
            picSpecificNormalSpinnerModify.Location = new Point(322, 75);
            picSpecificNormalSpinnerModify.Name = "picSpecificNormalSpinnerModify";
            picSpecificNormalSpinnerModify.Size = new Size(42, 42);
            picSpecificNormalSpinnerModify.TabIndex = 61;
            picSpecificNormalSpinnerModify.TabStop = false;
            // 
            // chkEnableIncludeBarlineModify
            // 
            chkEnableIncludeBarlineModify.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            chkEnableIncludeBarlineModify.ForeColor = Color.White;
            chkEnableIncludeBarlineModify.Location = new Point(165, 75);
            chkEnableIncludeBarlineModify.Name = "chkEnableIncludeBarlineModify";
            chkEnableIncludeBarlineModify.Size = new Size(192, 37);
            chkEnableIncludeBarlineModify.TabIndex = 49;
            chkEnableIncludeBarlineModify.Text = "ノーツが置かれていない小節線にもSVをつける";
            chkEnableIncludeBarlineModify.TextAlign = ContentAlignment.BottomLeft;
            chkEnableIncludeBarlineModify.UseVisualStyleBackColor = true;
            // 
            // lblSpecificFinisherModify
            // 
            lblSpecificFinisherModify.BackColor = SystemColors.WindowText;
            lblSpecificFinisherModify.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblSpecificFinisherModify.ForeColor = SystemColors.Window;
            lblSpecificFinisherModify.Location = new Point(166, 118);
            lblSpecificFinisherModify.Name = "lblSpecificFinisherModify";
            lblSpecificFinisherModify.Size = new Size(26, 42);
            lblSpecificFinisherModify.TabIndex = 57;
            lblSpecificFinisherModify.Text = "大音符";
            lblSpecificFinisherModify.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picSpecificNormalSliderModify
            // 
            picSpecificNormalSliderModify.Image = Properties.Resources.slider;
            picSpecificNormalSliderModify.InitialImage = Properties.Resources.slider;
            picSpecificNormalSliderModify.Location = new Point(279, 75);
            picSpecificNormalSliderModify.Name = "picSpecificNormalSliderModify";
            picSpecificNormalSliderModify.Size = new Size(42, 42);
            picSpecificNormalSliderModify.TabIndex = 54;
            picSpecificNormalSliderModify.TabStop = false;
            // 
            // picSpecificFinisherKaModify
            // 
            picSpecificFinisherKaModify.Image = Properties.Resources.k;
            picSpecificFinisherKaModify.InitialImage = (Image)resources.GetObject("picSpecificFinisherKaModify.InitialImage");
            picSpecificFinisherKaModify.Location = new Point(236, 118);
            picSpecificFinisherKaModify.Name = "picSpecificFinisherKaModify";
            picSpecificFinisherKaModify.Size = new Size(42, 42);
            picSpecificFinisherKaModify.TabIndex = 53;
            picSpecificFinisherKaModify.TabStop = false;
            // 
            // picSpecificFinisherDongModify
            // 
            picSpecificFinisherDongModify.Image = Properties.Resources.d;
            picSpecificFinisherDongModify.InitialImage = (Image)resources.GetObject("picSpecificFinisherDongModify.InitialImage");
            picSpecificFinisherDongModify.Location = new Point(193, 118);
            picSpecificFinisherDongModify.Name = "picSpecificFinisherDongModify";
            picSpecificFinisherDongModify.Size = new Size(42, 42);
            picSpecificFinisherDongModify.TabIndex = 51;
            picSpecificFinisherDongModify.TabStop = false;
            // 
            // picSpecificFinisherSliderModify
            // 
            picSpecificFinisherSliderModify.Image = Properties.Resources.slider;
            picSpecificFinisherSliderModify.InitialImage = Properties.Resources.slider;
            picSpecificFinisherSliderModify.Location = new Point(279, 118);
            picSpecificFinisherSliderModify.Name = "picSpecificFinisherSliderModify";
            picSpecificFinisherSliderModify.Size = new Size(42, 42);
            picSpecificFinisherSliderModify.TabIndex = 55;
            picSpecificFinisherSliderModify.TabStop = false;
            // 
            // lblSpecificGridLine2Modify
            // 
            lblSpecificGridLine2Modify.BackColor = Color.White;
            lblSpecificGridLine2Modify.Location = new Point(322, 74);
            lblSpecificGridLine2Modify.Name = "lblSpecificGridLine2Modify";
            lblSpecificGridLine2Modify.Size = new Size(43, 44);
            lblSpecificGridLine2Modify.TabIndex = 60;
            lblSpecificGridLine2Modify.Text = " ";
            // 
            // picSpecificNormalKaModify
            // 
            picSpecificNormalKaModify.Image = Properties.Resources.k;
            picSpecificNormalKaModify.InitialImage = (Image)resources.GetObject("picSpecificNormalKaModify.InitialImage");
            picSpecificNormalKaModify.Location = new Point(236, 75);
            picSpecificNormalKaModify.Name = "picSpecificNormalKaModify";
            picSpecificNormalKaModify.Size = new Size(42, 42);
            picSpecificNormalKaModify.TabIndex = 52;
            picSpecificNormalKaModify.TabStop = false;
            // 
            // picSpecificNormalDongModify
            // 
            picSpecificNormalDongModify.Image = Properties.Resources.d;
            picSpecificNormalDongModify.InitialImage = (Image)resources.GetObject("picSpecificNormalDongModify.InitialImage");
            picSpecificNormalDongModify.Location = new Point(193, 75);
            picSpecificNormalDongModify.Name = "picSpecificNormalDongModify";
            picSpecificNormalDongModify.Size = new Size(42, 42);
            picSpecificNormalDongModify.TabIndex = 50;
            picSpecificNormalDongModify.TabStop = false;
            // 
            // lblSpecificGridLineModify
            // 
            lblSpecificGridLineModify.BackColor = Color.White;
            lblSpecificGridLineModify.Location = new Point(165, 74);
            lblSpecificGridLineModify.Name = "lblSpecificGridLineModify";
            lblSpecificGridLineModify.Size = new Size(157, 87);
            lblSpecificGridLineModify.TabIndex = 58;
            lblSpecificGridLineModify.Text = " ";
            // 
            // tabRemovePage
            // 
            tabRemovePage.BackColor = Color.FromArgb(0, 64, 64);
            tabRemovePage.BorderStyle = BorderStyle.Fixed3D;
            tabRemovePage.Controls.Add(btnRemove);
            tabRemovePage.ForeColor = Color.DarkCyan;
            tabRemovePage.Location = new Point(4, 44);
            tabRemovePage.Name = "tabRemovePage";
            tabRemovePage.Padding = new Padding(3);
            tabRemovePage.Size = new Size(385, 324);
            tabRemovePage.TabIndex = 2;
            tabRemovePage.Text = "削除";
            // 
            // lblCalculationType
            // 
            lblCalculationType.AutoSize = true;
            lblCalculationType.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblCalculationType.ForeColor = Color.White;
            lblCalculationType.Location = new Point(20, 340);
            lblCalculationType.Name = "lblCalculationType";
            lblCalculationType.Size = new Size(69, 20);
            lblCalculationType.TabIndex = 50;
            lblCalculationType.Text = "計算方法";
            // 
            // osuTaikoSVTool
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 64, 64);
            ClientSize = new Size(408, 918);
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
            tabAddPage.ResumeLayout(false);
            tabAddPage.PerformLayout();
            tabSetType.ResumeLayout(false);
            tabHitObjectsPage.ResumeLayout(false);
            pnlSpecificGroup.ResumeLayout(false);
            pnlSpecificGroup.PerformLayout();
            tabBeatSnap.ResumeLayout(false);
            tabBeatSnap.PerformLayout();
            tabModifyPage.ResumeLayout(false);
            tabModifyPage.PerformLayout();
            pnlSpecificGroupModify.ResumeLayout(false);
            pnlSpecificGroupModify.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalSpinnerModify).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalSliderModify).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherKaModify).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherDongModify).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificFinisherSliderModify).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalKaModify).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSpecificNormalDongModify).EndInit();
            tabRemovePage.ResumeLayout(false);
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
        private CheckBox chkEnableSv;
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
        private Panel pnlDragDropArea;
        private Button btnViewHistory;
        private Label lblSpecificGridLine2;
        private PictureBox picSpecificNormalSpinner;
        private TabControl tabExecuteType;
        private TabPage tabAddPage;
        private TabPage tabModifyPage;
        private TabPage tabRemovePage;
        private Panel pnlSpecificGroup;
        private RadioButton rdoOnlyBookMark;
        private RadioButton rdoOnlyBarline;
        private RadioButton rdoOnlySpecificHitObject;
        private TabControl tabSetType;
        private TabPage tabHitObjectsPage;
        private TabPage tabBeatSnap;
        private RadioButton rdoAllHitObjects;
        private Label lblCalculationType;
        private CheckBox chkEnableKiaiModify;
        private Label lblKiaiStartModify;
        private Label lblKiaiModify;
        private Label lblKiaiEndModify;
        private CheckBox chkEnableKiaiEndModify;
        private CheckBox chkEnableKiaiStartModify;
        private Panel pnlSpecificGroupModify;
        private RadioButton rdoAllHitObjectsModify;
        private RadioButton rdoOnlyBookMarkModify;
        private RadioButton rdoOnlyBarlineModify;
        private RadioButton rdoOnlySpecificHitObjectModify;
        private Label lblSpecificNormalModify;
        private PictureBox picSpecificNormalSpinnerModify;
        private CheckBox chkEnableIncludeBarlineModify;
        private Label lblSpecificFinisherModify;
        private PictureBox picSpecificNormalSliderModify;
        private PictureBox picSpecificFinisherKaModify;
        private PictureBox picSpecificFinisherDongModify;
        private PictureBox picSpecificFinisherSliderModify;
        private Label lblSpecificGridLine2Modify;
        private PictureBox picSpecificNormalKaModify;
        private PictureBox picSpecificNormalDongModify;
        private Label lblSpecificGridLineModify;
    }
}
