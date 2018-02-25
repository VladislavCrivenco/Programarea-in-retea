using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_Lab2
{
    public partial class ReportTreeForm : UserControl
    {
        public ReportTreeForm()
        {
            InitializeComponent();
        }

        private async void OnGenerate(object sender, EventArgs e)
        {
            DateTime from = dateFrom.Value;
            DateTime to = dateTo.Value;
            await m_tree.RefreshAsync(from, to);
        }

        private async void ReportTreeFormLoad(object sender, EventArgs e)
        {
            await m_tree.InitAsync();
        }

        private void DateFromOnClick(object sender, EventArgs e)
        {
            DateTime from = dateFrom.Value;
            DateTime to = dateTo.Value;
            if (from > to)
            {
                dateTo.Value = from;
            }
        }

        private void DateToOnClick(object sender, EventArgs e)
        {
            DateTime from = dateFrom.Value;
            DateTime to = dateTo.Value;

            if (to < from)
            {
                dateFrom.Value = to;
            }
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.label2 = new Label();
            this.dateFrom = new DateTimePicker();
            this.label3 = new Label();
            this.dateTo = new DateTimePicker();
            this.button1 = new Button();
            this.label4 = new Label();
            this.label5 = new Label();
            m_tree = new ReportTree();
            CommonTools.TreeListColumn treeListColumn1 = new CommonTools.TreeListColumn("name", "Name");
            CommonTools.TreeListColumn treeListColumn2 = new CommonTools.TreeListColumn("total", "Total");
            ((System.ComponentModel.ISupportInitialize)(this.m_tree)).BeginInit();

            this.SuspendLayout();

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(235, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "From";
            // 
            // dateFrom
            // 
            this.dateFrom.CalendarFont = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateFrom.Checked = false;
            this.dateFrom.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateFrom.Location = new System.Drawing.Point(290, 2);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(176, 28);
            this.dateFrom.TabIndex = 12;
            this.dateFrom.ValueChanged += new EventHandler(this.DateFromOnClick);
            this.dateFrom.MaxDate = DateTime.Today.Subtract(TimeSpan.FromDays(1));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(509, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "To";
            // 
            // dateTo
            //

            this.dateTo.CalendarFont = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTo.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTo.Location = new System.Drawing.Point(540, 2);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(180, 28);
            this.dateTo.TabIndex = 13;
            this.dateTo.ValueChanged += new EventHandler(this.DateToOnClick);
            this.dateTo.MaxDate = DateTime.Today;

            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(753, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 28);
            this.button1.TabIndex = 15;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.OnGenerate);

            treeListColumn1.HeaderFormat.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            treeListColumn1.AutoSize = true;
            treeListColumn2.AutoSizeRatio = 80f;

            treeListColumn2.CellFormat.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            treeListColumn2.HeaderFormat.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            treeListColumn2.AutoSize = true;
            treeListColumn2.AutoSizeRatio = 20f;

            this.m_tree.Columns.AddRange(new CommonTools.TreeListColumn[] {
                treeListColumn1,
                treeListColumn2});
            this.m_tree.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom)
                                                                        | AnchorStyles.Left)
                                                                       | AnchorStyles.Right)));
            this.m_tree.Cursor = Cursors.Arrow;
            this.m_tree.Images = null;
            this.m_tree.Location = new System.Drawing.Point(3, 53);
            this.m_tree.Name = "m_tree";
            this.m_tree.Size = new System.Drawing.Size(610, 239);
            this.m_tree.TabIndex = 0;
            this.m_tree.ViewOptions.BorderStyle = BorderStyle.FixedSingle;
            // 
            // TestTreeForm
            // 
            this.Load += new System.EventHandler(this.ReportTreeFormLoad);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_tree);
            this.Name = "TestTreeForm";
            this.Size = new System.Drawing.Size(616, 275);
            ((System.ComponentModel.ISupportInitialize)(this.m_tree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Label label1;
        private Label label2;
        private DateTimePicker dateFrom;
        private Label label3;
        private DateTimePicker dateTo;
        private Button button1;
        private Label label4;
        private Label label5;
        private ReportTree m_tree;
    }

}
