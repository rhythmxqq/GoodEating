namespace GoodEating
{
    partial class Form2
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
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passwordtextBox = new System.Windows.Forms.TextBox();
            this.passwordCheckTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.weightTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.hightTextBox = new System.Windows.Forms.TextBox();
            this.buttonEnterReg = new System.Windows.Forms.Button();
            this.allergiaComboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(27, 47);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(100, 20);
            this.loginTextBox.TabIndex = 0;
            // 
            // passwordtextBox
            // 
            this.passwordtextBox.Location = new System.Drawing.Point(27, 97);
            this.passwordtextBox.Name = "passwordtextBox";
            this.passwordtextBox.PasswordChar = '*';
            this.passwordtextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordtextBox.TabIndex = 1;
            // 
            // passwordCheckTextBox
            // 
            this.passwordCheckTextBox.Location = new System.Drawing.Point(27, 135);
            this.passwordCheckTextBox.Name = "passwordCheckTextBox";
            this.passwordCheckTextBox.PasswordChar = '*';
            this.passwordCheckTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordCheckTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Повторите пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Аллергия";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Имя";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(162, 112);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(105, 20);
            this.nameTextBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(295, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Вес";
            // 
            // weightTextBox
            // 
            this.weightTextBox.Location = new System.Drawing.Point(298, 112);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(100, 20);
            this.weightTextBox.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(295, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Рост";
            // 
            // hightTextBox
            // 
            this.hightTextBox.Location = new System.Drawing.Point(298, 63);
            this.hightTextBox.Name = "hightTextBox";
            this.hightTextBox.Size = new System.Drawing.Size(100, 20);
            this.hightTextBox.TabIndex = 10;
            // 
            // buttonEnterReg
            // 
            this.buttonEnterReg.Location = new System.Drawing.Point(140, 207);
            this.buttonEnterReg.Name = "buttonEnterReg";
            this.buttonEnterReg.Size = new System.Drawing.Size(127, 23);
            this.buttonEnterReg.TabIndex = 16;
            this.buttonEnterReg.Text = "Зарегестрироваться";
            this.buttonEnterReg.UseVisualStyleBackColor = true;
            this.buttonEnterReg.Click += new System.EventHandler(this.buttonEnterReg_Click);
            // 
            // allergiaComboBox1
            // 
            this.allergiaComboBox1.FormattingEnabled = true;
            this.allergiaComboBox1.Items.AddRange(new object[] {
            "Мандарины",
            "Апельсины",
            "Грейпфрут",
            "Грецкий орех",
            "Свинина",
            "Ваниль",
            "Нет"});
            this.allergiaComboBox1.Location = new System.Drawing.Point(162, 63);
            this.allergiaComboBox1.Name = "allergiaComboBox1";
            this.allergiaComboBox1.Size = new System.Drawing.Size(105, 21);
            this.allergiaComboBox1.TabIndex = 17;
            this.allergiaComboBox1.Text = "Ваша аллергия";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 242);
            this.Controls.Add(this.allergiaComboBox1);
            this.Controls.Add(this.buttonEnterReg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.weightTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.hightTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordCheckTextBox);
            this.Controls.Add(this.passwordtextBox);
            this.Controls.Add(this.loginTextBox);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passwordtextBox;
        private System.Windows.Forms.TextBox passwordCheckTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox weightTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox hightTextBox;
        private System.Windows.Forms.Button buttonEnterReg;
        private System.Windows.Forms.ComboBox allergiaComboBox1;
    }
}