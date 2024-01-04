namespace GoodEating
{
    partial class profileForm
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
            this.heightTextBoxUpdate = new System.Windows.Forms.TextBox();
            this.weightTextBoxUpdate = new System.Windows.Forms.MaskedTextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxManOrWoman = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.updatePasswordButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // heightTextBoxUpdate
            // 
            this.heightTextBoxUpdate.Location = new System.Drawing.Point(78, 187);
            this.heightTextBoxUpdate.Name = "heightTextBoxUpdate";
            this.heightTextBoxUpdate.Size = new System.Drawing.Size(110, 20);
            this.heightTextBoxUpdate.TabIndex = 0;
            // 
            // weightTextBoxUpdate
            // 
            this.weightTextBoxUpdate.Location = new System.Drawing.Point(78, 145);
            this.weightTextBoxUpdate.Name = "weightTextBoxUpdate";
            this.weightTextBoxUpdate.Size = new System.Drawing.Size(110, 20);
            this.weightTextBoxUpdate.TabIndex = 1;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(148, 101);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(29, 13);
            this.loginLabel.TabIndex = 4;
            this.loginLabel.Text = "login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ваш логин:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GoodEating.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(91, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(90, 318);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Вес";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Рост";
            // 
            // comboBoxManOrWoman
            // 
            this.comboBoxManOrWoman.FormattingEnabled = true;
            this.comboBoxManOrWoman.Items.AddRange(new object[] {
            "Мужчина",
            "Женщина"});
            this.comboBoxManOrWoman.Location = new System.Drawing.Point(64, 230);
            this.comboBoxManOrWoman.Name = "comboBoxManOrWoman";
            this.comboBoxManOrWoman.Size = new System.Drawing.Size(136, 21);
            this.comboBoxManOrWoman.TabIndex = 10;
            this.comboBoxManOrWoman.Text = "Укажите пол";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Пол";
            // 
            // updatePasswordButton
            // 
            this.updatePasswordButton.Location = new System.Drawing.Point(183, 12);
            this.updatePasswordButton.Name = "updatePasswordButton";
            this.updatePasswordButton.Size = new System.Drawing.Size(71, 38);
            this.updatePasswordButton.TabIndex = 12;
            this.updatePasswordButton.Text = "Изменить пароль";
            this.updatePasswordButton.UseVisualStyleBackColor = true;
            this.updatePasswordButton.Click += new System.EventHandler(this.updatePasswordButton_Click);
            // 
            // profileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 353);
            this.Controls.Add(this.updatePasswordButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxManOrWoman);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.weightTextBoxUpdate);
            this.Controls.Add(this.heightTextBoxUpdate);
            this.Name = "profileForm";
            this.Text = "profileForm";
            this.Load += new System.EventHandler(this.profileForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox heightTextBoxUpdate;
        private System.Windows.Forms.MaskedTextBox weightTextBoxUpdate;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxManOrWoman;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button updatePasswordButton;
    }
}