namespace osuTaikoSvTool.Views
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            lblLanguage = new Label();
            lblMaxBackupCount = new Label();
            lblMaxHistoryCount = new Label();
            txtMaxBackupCount = new TextBox();
            txtHistoryCount = new TextBox();
            cmbLanguage = new ComboBox();
            btnSave = new Button();
            label1 = new Label();
            chkAdvanceMode = new CheckBox();
            SuspendLayout();
            // 
            // lblLanguage
            // 
            lblLanguage.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblLanguage.ForeColor = Color.White;
            lblLanguage.Location = new Point(12, 40);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(256, 23);
            lblLanguage.TabIndex = 0;
            lblLanguage.Text = "言語";
            lblLanguage.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMaxBackupCount
            // 
            lblMaxBackupCount.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblMaxBackupCount.ForeColor = Color.White;
            lblMaxBackupCount.Location = new Point(12, 100);
            lblMaxBackupCount.Name = "lblMaxBackupCount";
            lblMaxBackupCount.Size = new Size(256, 25);
            lblMaxBackupCount.TabIndex = 1;
            lblMaxBackupCount.Text = "バックアップの最大保持数";
            lblMaxBackupCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMaxHistoryCount
            // 
            lblMaxHistoryCount.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblMaxHistoryCount.ForeColor = Color.White;
            lblMaxHistoryCount.Location = new Point(12, 161);
            lblMaxHistoryCount.Name = "lblMaxHistoryCount";
            lblMaxHistoryCount.Size = new Size(256, 25);
            lblMaxHistoryCount.TabIndex = 2;
            lblMaxHistoryCount.Text = "入力履歴ファイルの最大保持数";
            lblMaxHistoryCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtMaxBackupCount
            // 
            txtMaxBackupCount.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            txtMaxBackupCount.Location = new Point(274, 100);
            txtMaxBackupCount.Name = "txtMaxBackupCount";
            txtMaxBackupCount.Size = new Size(180, 27);
            txtMaxBackupCount.TabIndex = 3;
            // 
            // txtHistoryCount
            // 
            txtHistoryCount.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            txtHistoryCount.Location = new Point(274, 160);
            txtHistoryCount.Name = "txtHistoryCount";
            txtHistoryCount.Size = new Size(180, 27);
            txtHistoryCount.TabIndex = 4;
            // 
            // cmbLanguage
            // 
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.ImeMode = ImeMode.Disable;
            cmbLanguage.Location = new Point(274, 40);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(180, 28);
            cmbLanguage.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom;
            btnSave.BackColor = Color.DarkCyan;
            btnSave.FlatAppearance.BorderColor = Color.Cyan;
            btnSave.FlatAppearance.BorderSize = 2;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Yu Gothic UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnSave.ForeColor = SystemColors.ControlLightLight;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(146, 278);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(189, 39);
            btnSave.TabIndex = 15;
            btnSave.TabStop = false;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 222);
            label1.Name = "label1";
            label1.Size = new Size(256, 25);
            label1.TabIndex = 16;
            label1.Text = "AdvanceMode";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // chkAdvanceMode
            // 
            chkAdvanceMode.Appearance = Appearance.Button;
            chkAdvanceMode.BackColor = Color.White;
            chkAdvanceMode.Font = new Font("MS UI Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 128);
            chkAdvanceMode.ForeColor = Color.Green;
            chkAdvanceMode.Location = new Point(273, 222);
            chkAdvanceMode.Name = "chkAdvanceMode";
            chkAdvanceMode.Size = new Size(25, 25);
            chkAdvanceMode.TabIndex = 17;
            chkAdvanceMode.TextAlign = ContentAlignment.MiddleCenter;
            chkAdvanceMode.UseVisualStyleBackColor = false;
            chkAdvanceMode.CheckedChanged += chkAdvanceMode_CheckedChanged;
            // 
            // SettingForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(0, 64, 64);
            ClientSize = new Size(466, 346);
            Controls.Add(chkAdvanceMode);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(cmbLanguage);
            Controls.Add(txtHistoryCount);
            Controls.Add(txtMaxBackupCount);
            Controls.Add(lblMaxHistoryCount);
            Controls.Add(lblMaxBackupCount);
            Controls.Add(lblLanguage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingForm";
            Text = "Setting";
            Load += SettingForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLanguage;
        private Label lblMaxBackupCount;
        private Label lblMaxHistoryCount;
        private TextBox txtMaxBackupCount;
        private TextBox txtHistoryCount;
        private ComboBox cmbLanguage;
        private Button btnSave;
        private Label label1;
        private CheckBox chkAdvanceMode;
    }
}