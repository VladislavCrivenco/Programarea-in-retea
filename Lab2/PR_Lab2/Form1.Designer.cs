namespace PR_Lab2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.reportTreeForm2 = new PR_Lab2.ReportTreeForm();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total by Categories";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // reportTreeForm2
            // 
            this.reportTreeForm2.Location = new System.Drawing.Point(18, 50);
            this.reportTreeForm2.Name = "reportTreeForm2";
            this.reportTreeForm2.Size = new System.Drawing.Size(1000, 584);
            this.reportTreeForm2.TabIndex = 10;
            this.reportTreeForm2.Load += new System.EventHandler(this.reportTreeForm2_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1066, 642);
            this.Controls.Add(this.reportTreeForm2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "EvilApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ReportTreeForm reportTreeForm2;
        //private System.Windows.Forms.Label label2;
        //private System.Windows.Forms.DateTimePicker dateTimePicker1;
        //private System.Windows.Forms.DateTimePicker dateTimePicker2;
        //private System.Windows.Forms.Label label3;
        //private System.Windows.Forms.Button button1;
    }
}

