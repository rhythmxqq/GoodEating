namespace GoodEating
{
    partial class coachFormMain
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.idCoach = new System.Windows.Forms.Label();
            this.dataGridViewInfoAllProducts = new System.Windows.Forms.DataGridView();
            this.infoFats = new System.Windows.Forms.Label();
            this.infoCarbs = new System.Windows.Forms.Label();
            this.infoProteins = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfoAllProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(391, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пользователи";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Белки",
            "Жиры",
            "Углеводы"});
            this.comboBox2.Location = new System.Drawing.Point(15, 63);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Диеты";
            // 
            // idCoach
            // 
            this.idCoach.AutoSize = true;
            this.idCoach.Location = new System.Drawing.Point(12, 9);
            this.idCoach.Name = "idCoach";
            this.idCoach.Size = new System.Drawing.Size(60, 13);
            this.idCoach.TabIndex = 4;
            this.idCoach.Text = "ID tREnera";
            this.idCoach.Click += new System.EventHandler(this.idCoach_Click);
            // 
            // dataGridViewInfoAllProducts
            // 
            this.dataGridViewInfoAllProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInfoAllProducts.Location = new System.Drawing.Point(12, 102);
            this.dataGridViewInfoAllProducts.Name = "dataGridViewInfoAllProducts";
            this.dataGridViewInfoAllProducts.Size = new System.Drawing.Size(500, 184);
            this.dataGridViewInfoAllProducts.TabIndex = 5;
            // 
            // infoFats
            // 
            this.infoFats.AutoSize = true;
            this.infoFats.Location = new System.Drawing.Point(182, 66);
            this.infoFats.Name = "infoFats";
            this.infoFats.Size = new System.Drawing.Size(24, 13);
            this.infoFats.TabIndex = 6;
            this.infoFats.Text = "fats";
            // 
            // infoCarbs
            // 
            this.infoCarbs.AutoSize = true;
            this.infoCarbs.Location = new System.Drawing.Point(238, 66);
            this.infoCarbs.Name = "infoCarbs";
            this.infoCarbs.Size = new System.Drawing.Size(33, 13);
            this.infoCarbs.TabIndex = 7;
            this.infoCarbs.Text = "carbs";
            // 
            // infoProteins
            // 
            this.infoProteins.AutoSize = true;
            this.infoProteins.Location = new System.Drawing.Point(298, 66);
            this.infoProteins.Name = "infoProteins";
            this.infoProteins.Size = new System.Drawing.Size(44, 13);
            this.infoProteins.TabIndex = 8;
            this.infoProteins.Text = "proteins";
            // 
            // coachFormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 307);
            this.Controls.Add(this.infoProteins);
            this.Controls.Add(this.infoCarbs);
            this.Controls.Add(this.infoFats);
            this.Controls.Add(this.dataGridViewInfoAllProducts);
            this.Controls.Add(this.idCoach);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "coachFormMain";
            this.Text = "coachFormMain";
            this.Load += new System.EventHandler(this.coachFormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfoAllProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label idCoach;
        private System.Windows.Forms.DataGridView dataGridViewInfoAllProducts;
        private System.Windows.Forms.Label infoFats;
        private System.Windows.Forms.Label infoCarbs;
        private System.Windows.Forms.Label infoProteins;
    }
}