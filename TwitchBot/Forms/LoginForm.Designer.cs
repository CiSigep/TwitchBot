namespace TwitchBot.Forms
{
    partial class LoginForm
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
            this.UserLabel = new System.Windows.Forms.Label();
            this.OAuthLabel = new System.Windows.Forms.Label();
            this.UsernameText = new System.Windows.Forms.TextBox();
            this.OAuthText = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Location = new System.Drawing.Point(12, 9);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(102, 17);
            this.UserLabel.TabIndex = 0;
            this.UserLabel.Text = "Bot Username:";
            // 
            // OAuthLabel
            // 
            this.OAuthLabel.AutoSize = true;
            this.OAuthLabel.Location = new System.Drawing.Point(12, 36);
            this.OAuthLabel.Name = "OAuthLabel";
            this.OAuthLabel.Size = new System.Drawing.Size(77, 17);
            this.OAuthLabel.TabIndex = 1;
            this.OAuthLabel.Text = "Bot OAuth:";
            // 
            // UsernameText
            // 
            this.UsernameText.Location = new System.Drawing.Point(120, 6);
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(235, 22);
            this.UsernameText.TabIndex = 2;
            // 
            // OAuthText
            // 
            this.OAuthText.Location = new System.Drawing.Point(120, 36);
            this.OAuthText.Name = "OAuthText";
            this.OAuthText.Size = new System.Drawing.Size(235, 22);
            this.OAuthText.TabIndex = 3;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(280, 64);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 93);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.OAuthText);
            this.Controls.Add(this.UsernameText);
            this.Controls.Add(this.OAuthLabel);
            this.Controls.Add(this.UserLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Twitch Bot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Label OAuthLabel;
        private System.Windows.Forms.TextBox UsernameText;
        private System.Windows.Forms.TextBox OAuthText;
        private System.Windows.Forms.Button StartButton;
    }
}

