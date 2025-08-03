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
            openFileButton = new Button();
            panel1 = new Panel();
            label1 = new Label();
            pictureBox5 = new PictureBox();
            timingTo = new TextBox();
            timingFrom = new TextBox();
            SVFrom = new TextBox();
            SVTo = new TextBox();
            volumeFrom = new TextBox();
            volumeTo = new TextBox();
            timingLabel = new Label();
            SVLabel = new Label();
            volumeLabel = new Label();
            disableSV = new CheckBox();
            arithmeticButton = new RadioButton();
            geometricButton = new RadioButton();
            disableVolume = new CheckBox();
            includeBarline = new CheckBox();
            panel2 = new Panel();
            addButton = new Button();
            enableOffset = new CheckBox();
            offsetTextbox = new TextBox();
            msLabel = new Label();
            offsetLabel = new Label();
            backupFolderButton = new Button();
            swapTimingButton = new Button();
            swapSVButton = new Button();
            swapVolumeButton = new Button();
            isKiaiLabel = new Label();
            isKiaiButton = new CheckBox();
            isStartKiaiLabel = new Label();
            isStartKialButton = new CheckBox();
            isEndKialLabel = new Label();
            isEndKialButton = new CheckBox();
            modifyButton = new Button();
            removeButton = new Button();
            checkBox1 = new CheckBox();
            textBox1 = new TextBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            pictureBox6 = new PictureBox();
            pictureBox7 = new PictureBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            panel3 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // openFileButton
            // 
            openFileButton.BackColor = Color.DarkCyan;
            openFileButton.FlatStyle = FlatStyle.Flat;
            openFileButton.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            openFileButton.ForeColor = Color.Cyan;
            openFileButton.Location = new Point(130, 133);
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new Size(128, 39);
            openFileButton.TabIndex = 0;
            openFileButton.Text = "ファイルを開く";
            openFileButton.UseVisualStyleBackColor = false;
            openFileButton.Click += openFileButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(openFileButton);
            panel1.Controls.Add(pictureBox5);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(384, 216);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(2, 47);
            label1.Name = "label1";
            label1.Size = new Size(382, 83);
            label1.TabIndex = 1;
            label1.Text = "ファイルを選択してください";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = SystemColors.InactiveCaption;
            pictureBox5.Location = new Point(0, 0);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(384, 216);
            pictureBox5.TabIndex = 2;
            pictureBox5.TabStop = false;
            // 
            // timingTo
            // 
            timingTo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            timingTo.BorderStyle = BorderStyle.FixedSingle;
            timingTo.Location = new Point(276, 250);
            timingTo.Name = "timingTo";
            timingTo.Size = new Size(120, 23);
            timingTo.TabIndex = 2;
            // 
            // timingFrom
            // 
            timingFrom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            timingFrom.BorderStyle = BorderStyle.FixedSingle;
            timingFrom.ForeColor = SystemColors.WindowText;
            timingFrom.Location = new Point(93, 250);
            timingFrom.Name = "timingFrom";
            timingFrom.Size = new Size(120, 23);
            timingFrom.TabIndex = 3;
            // 
            // SVFrom
            // 
            SVFrom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SVFrom.BackColor = SystemColors.Window;
            SVFrom.BorderStyle = BorderStyle.FixedSingle;
            SVFrom.Location = new Point(93, 279);
            SVFrom.Name = "SVFrom";
            SVFrom.Size = new Size(120, 23);
            SVFrom.TabIndex = 4;
            // 
            // SVTo
            // 
            SVTo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SVTo.BorderStyle = BorderStyle.FixedSingle;
            SVTo.Location = new Point(276, 279);
            SVTo.Name = "SVTo";
            SVTo.Size = new Size(120, 23);
            SVTo.TabIndex = 5;
            // 
            // volumeFrom
            // 
            volumeFrom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            volumeFrom.BorderStyle = BorderStyle.FixedSingle;
            volumeFrom.Location = new Point(93, 308);
            volumeFrom.Name = "volumeFrom";
            volumeFrom.Size = new Size(120, 23);
            volumeFrom.TabIndex = 6;
            // 
            // volumeTo
            // 
            volumeTo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            volumeTo.BorderStyle = BorderStyle.FixedSingle;
            volumeTo.Location = new Point(276, 308);
            volumeTo.Name = "volumeTo";
            volumeTo.Size = new Size(120, 23);
            volumeTo.TabIndex = 7;
            // 
            // timingLabel
            // 
            timingLabel.AutoSize = true;
            timingLabel.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold);
            timingLabel.ForeColor = Color.White;
            timingLabel.Location = new Point(29, 250);
            timingLabel.Name = "timingLabel";
            timingLabel.Size = new Size(56, 20);
            timingLabel.TabIndex = 8;
            timingLabel.Text = "Timing";
            // 
            // SVLabel
            // 
            SVLabel.AutoSize = true;
            SVLabel.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold);
            SVLabel.ForeColor = Color.White;
            SVLabel.Location = new Point(29, 279);
            SVLabel.Name = "SVLabel";
            SVLabel.Size = new Size(27, 20);
            SVLabel.TabIndex = 9;
            SVLabel.Text = "SV";
            // 
            // volumeLabel
            // 
            volumeLabel.AutoSize = true;
            volumeLabel.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold);
            volumeLabel.ForeColor = Color.White;
            volumeLabel.Location = new Point(30, 308);
            volumeLabel.Name = "volumeLabel";
            volumeLabel.Size = new Size(61, 20);
            volumeLabel.TabIndex = 10;
            volumeLabel.Text = "Volume";
            // 
            // disableSV
            // 
            disableSV.Checked = true;
            disableSV.CheckState = CheckState.Checked;
            disableSV.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            disableSV.ForeColor = Color.White;
            disableSV.Location = new Point(14, 278);
            disableSV.Name = "disableSV";
            disableSV.Size = new Size(15, 24);
            disableSV.TabIndex = 12;
            disableSV.UseVisualStyleBackColor = true;
            disableSV.CheckedChanged += disableSV_CheckedChanged;
            // 
            // arithmeticButton
            // 
            arithmeticButton.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            arithmeticButton.ForeColor = Color.White;
            arithmeticButton.Location = new Point(0, 0);
            arithmeticButton.Name = "arithmeticButton";
            arithmeticButton.Size = new Size(52, 24);
            arithmeticButton.TabIndex = 14;
            arithmeticButton.TabStop = true;
            arithmeticButton.Text = "等差";
            arithmeticButton.UseVisualStyleBackColor = true;
            arithmeticButton.CheckedChanged += arithmeticButton_CheckedChanged;
            // 
            // geometricButton
            // 
            geometricButton.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            geometricButton.ForeColor = Color.White;
            geometricButton.Location = new Point(-1, 29);
            geometricButton.Name = "geometricButton";
            geometricButton.Size = new Size(58, 24);
            geometricButton.TabIndex = 15;
            geometricButton.TabStop = true;
            geometricButton.Text = "等比";
            geometricButton.UseVisualStyleBackColor = true;
            geometricButton.CheckedChanged += geometricButton_CheckedChanged;
            // 
            // disableVolume
            // 
            disableVolume.Checked = true;
            disableVolume.CheckState = CheckState.Checked;
            disableVolume.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            disableVolume.ForeColor = Color.White;
            disableVolume.Location = new Point(14, 308);
            disableVolume.Name = "disableVolume";
            disableVolume.Size = new Size(15, 24);
            disableVolume.TabIndex = 16;
            disableVolume.UseVisualStyleBackColor = true;
            disableVolume.CheckedChanged += disableVolume_CheckedChanged;
            // 
            // includeBarline
            // 
            includeBarline.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            includeBarline.ForeColor = Color.White;
            includeBarline.Location = new Point(83, 386);
            includeBarline.Name = "includeBarline";
            includeBarline.Size = new Size(136, 37);
            includeBarline.TabIndex = 17;
            includeBarline.Text = "ノーツが置かれていない小節線にもSVをつける";
            includeBarline.TextAlign = ContentAlignment.BottomLeft;
            includeBarline.UseVisualStyleBackColor = true;
            includeBarline.CheckedChanged += includeBarline_CheckedChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(arithmeticButton);
            panel2.Controls.Add(geometricButton);
            panel2.Location = new Point(12, 361);
            panel2.Name = "panel2";
            panel2.Size = new Size(57, 53);
            panel2.TabIndex = 18;
            // 
            // addButton
            // 
            addButton.BackColor = Color.DarkCyan;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            addButton.ForeColor = Color.Cyan;
            addButton.Location = new Point(12, 715);
            addButton.Name = "addButton";
            addButton.Size = new Size(189, 39);
            addButton.TabIndex = 2;
            addButton.Text = "追加";
            addButton.UseVisualStyleBackColor = false;
            // 
            // enableOffset
            // 
            enableOffset.AutoSize = true;
            enableOffset.Checked = true;
            enableOffset.CheckState = CheckState.Checked;
            enableOffset.Location = new Point(85, 366);
            enableOffset.Name = "enableOffset";
            enableOffset.Size = new Size(15, 14);
            enableOffset.TabIndex = 19;
            enableOffset.UseVisualStyleBackColor = true;
            enableOffset.CheckedChanged += enableOffset_CheckedChanged;
            // 
            // offsetTextbox
            // 
            offsetTextbox.BackColor = SystemColors.Window;
            offsetTextbox.BorderStyle = BorderStyle.FixedSingle;
            offsetTextbox.Location = new Point(163, 361);
            offsetTextbox.Name = "offsetTextbox";
            offsetTextbox.Size = new Size(40, 23);
            offsetTextbox.TabIndex = 20;
            // 
            // msLabel
            // 
            msLabel.AutoSize = true;
            msLabel.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            msLabel.ForeColor = Color.White;
            msLabel.Location = new Point(208, 366);
            msLabel.Name = "msLabel";
            msLabel.Size = new Size(23, 15);
            msLabel.TabIndex = 21;
            msLabel.Text = "ms";
            // 
            // offsetLabel
            // 
            offsetLabel.AutoSize = true;
            offsetLabel.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            offsetLabel.ForeColor = Color.White;
            offsetLabel.Location = new Point(105, 365);
            offsetLabel.Name = "offsetLabel";
            offsetLabel.Size = new Size(50, 15);
            offsetLabel.TabIndex = 22;
            offsetLabel.Text = "オフセット";
            // 
            // backupFolderButton
            // 
            backupFolderButton.BackColor = Color.DarkCyan;
            backupFolderButton.FlatStyle = FlatStyle.Flat;
            backupFolderButton.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            backupFolderButton.ForeColor = Color.Cyan;
            backupFolderButton.Location = new Point(207, 760);
            backupFolderButton.Name = "backupFolderButton";
            backupFolderButton.Size = new Size(189, 39);
            backupFolderButton.TabIndex = 23;
            backupFolderButton.Text = "バックアップフォルダ";
            backupFolderButton.UseVisualStyleBackColor = false;
            backupFolderButton.Click += backupFolderButton_Click;
            // 
            // swapTimingButton
            // 
            swapTimingButton.FlatAppearance.BorderColor = Color.Cyan;
            swapTimingButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            swapTimingButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            swapTimingButton.FlatStyle = FlatStyle.Flat;
            swapTimingButton.ForeColor = Color.Cyan;
            swapTimingButton.Location = new Point(212, 250);
            swapTimingButton.Name = "swapTimingButton";
            swapTimingButton.Size = new Size(64, 23);
            swapTimingButton.TabIndex = 24;
            swapTimingButton.Text = "⇔";
            swapTimingButton.UseVisualStyleBackColor = true;
            swapTimingButton.Click += swapTimingButton_Click;
            // 
            // swapSVButton
            // 
            swapSVButton.FlatAppearance.BorderColor = Color.Cyan;
            swapSVButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            swapSVButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            swapSVButton.FlatStyle = FlatStyle.Flat;
            swapSVButton.ForeColor = Color.Cyan;
            swapSVButton.Location = new Point(212, 279);
            swapSVButton.Name = "swapSVButton";
            swapSVButton.Size = new Size(64, 23);
            swapSVButton.TabIndex = 25;
            swapSVButton.Text = "⇔";
            swapSVButton.UseVisualStyleBackColor = true;
            swapSVButton.Click += swapSVButton_Click;
            // 
            // swapVolumeButton
            // 
            swapVolumeButton.FlatAppearance.BorderColor = Color.Cyan;
            swapVolumeButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            swapVolumeButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            swapVolumeButton.FlatStyle = FlatStyle.Flat;
            swapVolumeButton.ForeColor = Color.Cyan;
            swapVolumeButton.Location = new Point(212, 308);
            swapVolumeButton.Name = "swapVolumeButton";
            swapVolumeButton.Size = new Size(64, 23);
            swapVolumeButton.TabIndex = 26;
            swapVolumeButton.Text = "⇔";
            swapVolumeButton.UseVisualStyleBackColor = true;
            swapVolumeButton.Click += swapVolumeButton_Click;
            // 
            // isKiaiLabel
            // 
            isKiaiLabel.AutoSize = true;
            isKiaiLabel.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            isKiaiLabel.ForeColor = Color.White;
            isKiaiLabel.Location = new Point(268, 366);
            isKiaiLabel.Name = "isKiaiLabel";
            isKiaiLabel.Size = new Size(25, 15);
            isKiaiLabel.TabIndex = 28;
            isKiaiLabel.Text = "kiai";
            // 
            // isKiaiButton
            // 
            isKiaiButton.AutoSize = true;
            isKiaiButton.Location = new Point(248, 367);
            isKiaiButton.Name = "isKiaiButton";
            isKiaiButton.Size = new Size(15, 14);
            isKiaiButton.TabIndex = 27;
            isKiaiButton.UseVisualStyleBackColor = true;
            isKiaiButton.CheckedChanged += isKiaiButton_CheckedChanged;
            // 
            // isStartKiaiLabel
            // 
            isStartKiaiLabel.AutoSize = true;
            isStartKiaiLabel.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            isStartKiaiLabel.ForeColor = Color.White;
            isStartKiaiLabel.Location = new Point(332, 366);
            isStartKiaiLabel.Name = "isStartKiaiLabel";
            isStartKiaiLabel.Size = new Size(64, 15);
            isStartKiaiLabel.TabIndex = 30;
            isStartKiaiLabel.Text = "kiaiの始点?";
            // 
            // isStartKialButton
            // 
            isStartKialButton.AutoSize = true;
            isStartKialButton.Location = new Point(312, 367);
            isStartKialButton.Name = "isStartKialButton";
            isStartKialButton.Size = new Size(15, 14);
            isStartKialButton.TabIndex = 29;
            isStartKialButton.UseVisualStyleBackColor = true;
            isStartKialButton.CheckedChanged += isStartKialButton_CheckedChanged;
            // 
            // isEndKialLabel
            // 
            isEndKialLabel.AutoSize = true;
            isEndKialLabel.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            isEndKialLabel.ForeColor = Color.White;
            isEndKialLabel.Location = new Point(332, 396);
            isEndKialLabel.Name = "isEndKialLabel";
            isEndKialLabel.Size = new Size(64, 15);
            isEndKialLabel.TabIndex = 32;
            isEndKialLabel.Text = "kiaiの終点?";
            // 
            // isEndKialButton
            // 
            isEndKialButton.AutoSize = true;
            isEndKialButton.Location = new Point(312, 397);
            isEndKialButton.Name = "isEndKialButton";
            isEndKialButton.Size = new Size(15, 14);
            isEndKialButton.TabIndex = 31;
            isEndKialButton.UseVisualStyleBackColor = true;
            isEndKialButton.CheckedChanged += isEndKialButton_CheckedChanged;
            // 
            // modifyButton
            // 
            modifyButton.BackColor = Color.DarkCyan;
            modifyButton.FlatStyle = FlatStyle.Flat;
            modifyButton.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            modifyButton.ForeColor = Color.Cyan;
            modifyButton.Location = new Point(207, 715);
            modifyButton.Name = "modifyButton";
            modifyButton.Size = new Size(189, 39);
            modifyButton.TabIndex = 33;
            modifyButton.Text = "変更";
            modifyButton.UseVisualStyleBackColor = false;
            // 
            // removeButton
            // 
            removeButton.BackColor = Color.DarkCyan;
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            removeButton.ForeColor = Color.Cyan;
            removeButton.Location = new Point(12, 760);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(189, 39);
            removeButton.TabIndex = 34;
            removeButton.Text = "削除";
            removeButton.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            checkBox1.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            checkBox1.ForeColor = Color.White;
            checkBox1.Location = new Point(83, 425);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(136, 37);
            checkBox1.TabIndex = 35;
            checkBox1.Text = "ビートスナップ間隔でSVを置く";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(236, 433);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(40, 23);
            textBox1.TabIndex = 36;
            // 
            // label2
            // 
            label2.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label2.ForeColor = Color.White;
            label2.Location = new Point(219, 436);
            label2.Name = "label2";
            label2.Size = new Size(17, 20);
            label2.TabIndex = 37;
            label2.Text = "1/";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.d;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(12, 572);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(42, 42);
            pictureBox1.TabIndex = 39;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.k;
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(12, 615);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(42, 42);
            pictureBox2.TabIndex = 40;
            pictureBox2.TabStop = false;
            pictureBox2.MouseDown += pictureBox2_MouseDown;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.d;
            pictureBox3.InitialImage = (Image)resources.GetObject("pictureBox3.InitialImage");
            pictureBox3.Location = new Point(55, 572);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(42, 42);
            pictureBox3.TabIndex = 41;
            pictureBox3.TabStop = false;
            pictureBox3.MouseDown += pictureBox3_MouseDown;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.k;
            pictureBox4.InitialImage = (Image)resources.GetObject("pictureBox4.InitialImage");
            pictureBox4.Location = new Point(55, 615);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(42, 42);
            pictureBox4.TabIndex = 42;
            pictureBox4.TabStop = false;
            pictureBox4.MouseDown += pictureBox4_MouseDown;
            // 
            // label3
            // 
            label3.BackColor = Color.White;
            label3.Location = new Point(11, 544);
            label3.Name = "label3";
            label3.Size = new Size(87, 157);
            label3.TabIndex = 43;
            label3.Text = " ";
            // 
            // label4
            // 
            label4.BackColor = SystemColors.WindowText;
            label4.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label4.ForeColor = SystemColors.Window;
            label4.Location = new Point(55, 545);
            label4.Name = "label4";
            label4.Size = new Size(42, 26);
            label4.TabIndex = 45;
            label4.Text = "大音符";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = SystemColors.WindowText;
            label5.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label5.ForeColor = SystemColors.Window;
            label5.Location = new Point(12, 545);
            label5.Name = "label5";
            label5.Size = new Size(42, 26);
            label5.TabIndex = 46;
            label5.Text = "通常";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.slider;
            pictureBox6.InitialImage = Properties.Resources.slider;
            pictureBox6.Location = new Point(12, 658);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(42, 42);
            pictureBox6.TabIndex = 47;
            pictureBox6.TabStop = false;
            pictureBox6.MouseDown += pictureBox6_MouseDown;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = Properties.Resources.slider;
            pictureBox7.InitialImage = Properties.Resources.slider;
            pictureBox7.Location = new Point(55, 658);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(42, 42);
            pictureBox7.TabIndex = 48;
            pictureBox7.TabStop = false;
            pictureBox7.MouseDown += pictureBox7_MouseDown;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            radioButton1.ForeColor = Color.White;
            radioButton1.Location = new Point(11, 468);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(112, 19);
            radioButton1.TabIndex = 49;
            radioButton1.TabStop = true;
            radioButton1.Text = "BookMark上のみ";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            radioButton2.ForeColor = Color.White;
            radioButton2.Location = new Point(10, 493);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(82, 19);
            radioButton2.TabIndex = 50;
            radioButton2.TabStop = true;
            radioButton2.Text = "小節線のみ";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            radioButton3.ForeColor = Color.White;
            radioButton3.Location = new Point(10, 518);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(132, 19);
            radioButton3.TabIndex = 51;
            radioButton3.TabStop = true;
            radioButton3.Text = "特定のオブジェクトのみ";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // panel3
            // 
            panel3.Location = new Point(6, 468);
            panel3.Name = "panel3";
            panel3.Size = new Size(136, 69);
            panel3.TabIndex = 52;
            // 
            // osuTaikoSVTool
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 64, 64);
            ClientSize = new Size(408, 878);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(pictureBox7);
            Controls.Add(pictureBox6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(checkBox1);
            Controls.Add(removeButton);
            Controls.Add(modifyButton);
            Controls.Add(isEndKialLabel);
            Controls.Add(isEndKialButton);
            Controls.Add(isStartKiaiLabel);
            Controls.Add(isStartKialButton);
            Controls.Add(isKiaiLabel);
            Controls.Add(isKiaiButton);
            Controls.Add(swapVolumeButton);
            Controls.Add(swapSVButton);
            Controls.Add(swapTimingButton);
            Controls.Add(backupFolderButton);
            Controls.Add(offsetLabel);
            Controls.Add(msLabel);
            Controls.Add(offsetTextbox);
            Controls.Add(enableOffset);
            Controls.Add(addButton);
            Controls.Add(panel2);
            Controls.Add(includeBarline);
            Controls.Add(disableVolume);
            Controls.Add(disableSV);
            Controls.Add(volumeLabel);
            Controls.Add(SVLabel);
            Controls.Add(timingLabel);
            Controls.Add(volumeTo);
            Controls.Add(volumeFrom);
            Controls.Add(SVTo);
            Controls.Add(SVFrom);
            Controls.Add(timingFrom);
            Controls.Add(timingTo);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(panel3);
            ForeColor = Color.Black;
            Name = "osuTaikoSVTool";
            Text = "osuTaikoSVTool";
            Load += osuTaikoSVTool_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button openFileButton;
        private Panel panel1;
        private Label label1;
        private TextBox timingTo;
        private TextBox timingFrom;
        private TextBox SVFrom;
        private TextBox SVTo;
        private TextBox volumeFrom;
        private TextBox volumeTo;
        private Label timingLabel;
        private Label SVLabel;
        private Label volumeLabel;
        private CheckBox disableSV;
        private RadioButton arithmeticButton;
        private RadioButton geometricButton;
        private CheckBox disableVolume;
        private CheckBox includeBarline;
        private Panel panel2;
        private Button addButton;
        private CheckBox enableOffset;
        private TextBox offsetTextbox;
        private Label msLabel;
        private Label offsetLabel;
        private Button backupFolderButton;
        private Button swapTimingButton;
        private Button swapSVButton;
        private Button swapVolumeButton;
        private Label isKiaiLabel;
        private CheckBox isKiaiButton;
        private Label isStartKiaiLabel;
        private CheckBox isStartKialButton;
        private Label isEndKialLabel;
        private CheckBox isEndKialButton;
        private Button modifyButton;
        private Button removeButton;
        private CheckBox checkBox1;
        private TextBox textBox1;
        private Label label2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label label3;
        private Label label4;
        private Label label5;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private Panel panel3;
    }
}
