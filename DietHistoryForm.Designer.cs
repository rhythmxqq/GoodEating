namespace GoodEating
{
    partial class DietHistoryForm
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
            this.dateTimePickerInfo = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewInfoDay = new System.Windows.Forms.DataGridView();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfoDay)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerInfo
            // 
            this.dateTimePickerInfo.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaption;
            this.dateTimePickerInfo.Location = new System.Drawing.Point(90, 12);
            this.dateTimePickerInfo.Name = "dateTimePickerInfo";
            this.dateTimePickerInfo.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerInfo.TabIndex = 0;
            // 
            // dataGridViewInfoDay
            // 
            this.dataGridViewInfoDay.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewInfoDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInfoDay.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridViewInfoDay.Location = new System.Drawing.Point(12, 64);
            this.dataGridViewInfoDay.Name = "dataGridViewInfoDay";
            this.dataGridViewInfoDay.Size = new System.Drawing.Size(370, 150);
            this.dataGridViewInfoDay.TabIndex = 1;
            // 
            // PreviousButton
            // 
            this.PreviousButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PreviousButton.FlatAppearance.BorderSize = 0;
            this.PreviousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviousButton.Location = new System.Drawing.Point(12, 261);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(75, 23);
            this.PreviousButton.TabIndex = 2;
            this.PreviousButton.Text = "Previous";
            this.PreviousButton.UseVisualStyleBackColor = false;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click_1);
            this.PreviousButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PreviousButton_MouseMove);
            // 
            // NextButton
            // 
            this.NextButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.NextButton.FlatAppearance.BorderSize = 0;
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextButton.Location = new System.Drawing.Point(307, 261);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 3;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click_1);
            this.NextButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NextButton_MouseMove);
            // 
            // DietHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GoodEating.Properties.Resources.Screenshot_92;
            this.ClientSize = new System.Drawing.Size(394, 314);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.dataGridViewInfoDay);
            this.Controls.Add(this.dateTimePickerInfo);
            this.Name = "DietHistoryForm";
            this.Text = "DietHistoryForm";
            this.Load += new System.EventHandler(this.DietHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfoDay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerInfo;
        private System.Windows.Forms.DataGridView dataGridViewInfoDay;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
    }
}