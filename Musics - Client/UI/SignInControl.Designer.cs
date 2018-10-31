namespace Musics___Client.UI
{
    partial class SignInControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label confirmPasswordLabel;
            this.UIConfirmPassword = new System.Windows.Forms.TextBox();
            this.credentialControl = new Musics___Client.UI.CredentialControl();
            confirmPasswordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirmPasswordLabel
            // 
            confirmPasswordLabel.AutoSize = true;
            confirmPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            confirmPasswordLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            confirmPasswordLabel.Location = new System.Drawing.Point(17, 191);
            confirmPasswordLabel.Name = "confirmPasswordLabel";
            confirmPasswordLabel.Size = new System.Drawing.Size(184, 25);
            confirmPasswordLabel.TabIndex = 11;
            confirmPasswordLabel.Text = "Confirm password";
            // 
            // UIConfirmPassword
            // 
            this.UIConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UIConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UIConfirmPassword.Location = new System.Drawing.Point(22, 219);
            this.UIConfirmPassword.Name = "UIConfirmPassword";
            this.UIConfirmPassword.PasswordChar = '*';
            this.UIConfirmPassword.Size = new System.Drawing.Size(350, 33);
            this.UIConfirmPassword.TabIndex = 10;
            this.UIConfirmPassword.TextChanged += new System.EventHandler(this.UIConfirmPassword_TextChanged);
            // 
            // credentialControl
            // 
            this.credentialControl.Location = new System.Drawing.Point(3, 3);
            this.credentialControl.Name = "credentialControl";
            this.credentialControl.Size = new System.Drawing.Size(379, 185);
            this.credentialControl.TabIndex = 0;
            // 
            // SignInControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(confirmPasswordLabel);
            this.Controls.Add(this.UIConfirmPassword);
            this.Controls.Add(this.credentialControl);
            this.Name = "SignInControl";
            this.Size = new System.Drawing.Size(381, 267);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CredentialControl credentialControl;
        private System.Windows.Forms.TextBox UIConfirmPassword;
    }
}
