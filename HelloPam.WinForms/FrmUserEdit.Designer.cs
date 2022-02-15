
namespace HelloPam.WinForms
{
    partial class FrmUserEdit
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
            this.TxtFullname = new System.Windows.Forms.TextBox();
            this.PbPicture = new System.Windows.Forms.PictureBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LlShowHidePassword = new System.Windows.Forms.LinkLabel();
            this.CbProfile = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LlRemovePicture = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PbPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtFullname
            // 
            this.TxtFullname.Location = new System.Drawing.Point(12, 37);
            this.TxtFullname.Name = "TxtFullname";
            this.TxtFullname.Size = new System.Drawing.Size(232, 31);
            this.TxtFullname.TabIndex = 0;
            // 
            // PbPicture
            // 
            this.PbPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbPicture.Location = new System.Drawing.Point(266, 37);
            this.PbPicture.Name = "PbPicture";
            this.PbPicture.Size = new System.Drawing.Size(232, 269);
            this.PbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbPicture.TabIndex = 1;
            this.PbPicture.TabStop = false;
            this.PbPicture.Click += new System.EventHandler(this.PbPicture_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.ForeColor = System.Drawing.Color.Green;
            this.BtnSave.Location = new System.Drawing.Point(266, 326);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(232, 35);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Full name";
            // 
            // LlShowHidePassword
            // 
            this.LlShowHidePassword.AutoSize = true;
            this.LlShowHidePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LlShowHidePassword.Location = new System.Drawing.Point(203, 171);
            this.LlShowHidePassword.Name = "LlShowHidePassword";
            this.LlShowHidePassword.Size = new System.Drawing.Size(41, 16);
            this.LlShowHidePassword.TabIndex = 4;
            this.LlShowHidePassword.TabStop = true;
            this.LlShowHidePassword.Text = "Show";
            this.LlShowHidePassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlShowHidePassword_LinkClicked);
            // 
            // CbProfile
            // 
            this.CbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbProfile.FormattingEnabled = true;
            this.CbProfile.Location = new System.Drawing.Point(12, 273);
            this.CbProfile.Name = "CbProfile";
            this.CbProfile.Size = new System.Drawing.Size(232, 33);
            this.CbProfile.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Username";
            // 
            // TxtUsername
            // 
            this.TxtUsername.Location = new System.Drawing.Point(12, 112);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(232, 31);
            this.TxtUsername.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Password";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(12, 190);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(232, 31);
            this.TxtPassword.TabIndex = 2;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Profile";
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Checked = true;
            this.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatus.Location = new System.Drawing.Point(12, 330);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(98, 29);
            this.chkStatus.TabIndex = 4;
            this.chkStatus.Text = "Enable";
            this.chkStatus.UseVisualStyleBackColor = true;
            this.chkStatus.CheckedChanged += new System.EventHandler(this.chkStatus_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Picture";
            // 
            // LlRemovePicture
            // 
            this.LlRemovePicture.AutoSize = true;
            this.LlRemovePicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LlRemovePicture.LinkColor = System.Drawing.Color.Red;
            this.LlRemovePicture.Location = new System.Drawing.Point(484, 16);
            this.LlRemovePicture.Name = "LlRemovePicture";
            this.LlRemovePicture.Size = new System.Drawing.Size(14, 16);
            this.LlRemovePicture.TabIndex = 5;
            this.LlRemovePicture.TabStop = true;
            this.LlRemovePicture.Text = "x";
            this.toolTip1.SetToolTip(this.LlRemovePicture, "Remove picture");
            this.LlRemovePicture.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlRemovePicture_LinkClicked);
            // 
            // FrmUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 381);
            this.Controls.Add(this.LlRemovePicture);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtUsername);
            this.Controls.Add(this.CbProfile);
            this.Controls.Add(this.LlShowHidePassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.PbPicture);
            this.Controls.Add(this.TxtFullname);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "FrmUserEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User edit";
            ((System.ComponentModel.ISupportInitialize)(this.PbPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtFullname;
        private System.Windows.Forms.PictureBox PbPicture;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LlShowHidePassword;
        private System.Windows.Forms.ComboBox CbProfile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel LlRemovePicture;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}