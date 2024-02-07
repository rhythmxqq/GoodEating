namespace GoodEating
{
    partial class UpdatePasswordForm
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
            this.firstPass = new System.Windows.Forms.TextBox();
            this.secondPass = new System.Windows.Forms.TextBox();
            this.changeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstPass
            // 
            this.firstPass.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.firstPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.firstPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstPass.Location = new System.Drawing.Point(49, 39);
            this.firstPass.Multiline = true;
            this.firstPass.Name = "firstPass";
            this.firstPass.PasswordChar = '*';
            this.firstPass.Size = new System.Drawing.Size(150, 28);
            this.firstPass.TabIndex = 0;
            // 
            // secondPass
            // 
            this.secondPass.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.secondPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.secondPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondPass.Location = new System.Drawing.Point(49, 93);
            this.secondPass.Multiline = true;
            this.secondPass.Name = "secondPass";
            this.secondPass.PasswordChar = '*';
            this.secondPass.Size = new System.Drawing.Size(150, 28);
            this.secondPass.TabIndex = 1;
            // 
            // changeButton
            // 
            this.changeButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.changeButton.FlatAppearance.BorderSize = 0;
            this.changeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeButton.Location = new System.Drawing.Point(59, 139);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(123, 23);
            this.changeButton.TabIndex = 2;
            this.changeButton.Text = "Сменить пароль";
            this.changeButton.UseVisualStyleBackColor = false;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            this.changeButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.changeButton_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(46, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Новый пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(46, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Повторите пароль";
            // 
            // UpdatePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GoodEating.Properties.Resources.Screenshot_92;
            this.ClientSize = new System.Drawing.Size(250, 174);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.secondPass);
            this.Controls.Add(this.firstPass);
            this.Name = "UpdatePasswordForm";
            this.Text = "UpdatePasswordForm";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UpdatePasswordForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstPass;
        private System.Windows.Forms.TextBox secondPass;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}