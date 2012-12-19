namespace MysiseHelper
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUrlType = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWebStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFillCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.brsMain = new System.Windows.Forms.WebBrowser();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cbbUriType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnRegular = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnFinal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLoadResult = new System.Windows.Forms.Label();
            this.btnLoadExcel = new System.Windows.Forms.Button();
            this.btnExamSecond = new System.Windows.Forms.Button();
            this.btnExamFirst = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pgbFinish = new System.Windows.Forms.ToolStripProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.58333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.41667F));
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 701);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip1, 2);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUrlType,
            this.lblWebStatus,
            this.lblFillCount,
            this.pgbFinish});
            this.statusStrip1.Location = new System.Drawing.Point(0, 676);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUrlType
            // 
            this.lblUrlType.Name = "lblUrlType";
            this.lblUrlType.Size = new System.Drawing.Size(77, 20);
            this.lblUrlType.Text = "正常网址 |";
            // 
            // lblWebStatus
            // 
            this.lblWebStatus.Name = "lblWebStatus";
            this.lblWebStatus.Size = new System.Drawing.Size(129, 20);
            this.lblWebStatus.Text = "请先进入登分页面";
            // 
            // lblFillCount
            // 
            this.lblFillCount.Name = "lblFillCount";
            this.lblFillCount.Size = new System.Drawing.Size(165, 20);
            this.lblFillCount.Text = " | 完成了0个学生的填写";
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.brsMain);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1002, 538);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "浏览区";
            // 
            // brsMain
            // 
            this.brsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brsMain.Location = new System.Drawing.Point(3, 17);
            this.brsMain.MinimumSize = new System.Drawing.Size(20, 20);
            this.brsMain.Name = "brsMain";
            this.brsMain.Size = new System.Drawing.Size(996, 518);
            this.brsMain.TabIndex = 3;
            this.brsMain.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.brsMain_DocumentCompleted);
            // 
            // toolStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cbbUriType,
            this.toolStripSeparator2,
            this.toolBtnRegular,
            this.toolStripSeparator1,
            this.toolBtnFinal,
            this.toolStripSeparator3,
            this.btnHelp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 28);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(144, 25);
            this.toolStripLabel1.Text = "请选择服务器地址：";
            // 
            // cbbUriType
            // 
            this.cbbUriType.Items.AddRange(new object[] {
            "正常地址",
            "选课期间地址"});
            this.cbbUriType.Name = "cbbUriType";
            this.cbbUriType.Size = new System.Drawing.Size(121, 28);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolBtnRegular
            // 
            this.toolBtnRegular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBtnRegular.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnRegular.Image")));
            this.toolBtnRegular.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnRegular.Name = "toolBtnRegular";
            this.toolBtnRegular.Size = new System.Drawing.Size(73, 25);
            this.toolBtnRegular.Text = "平时成绩";
            this.toolBtnRegular.Click += new System.EventHandler(this.toolBtnRegular_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolBtnFinal
            // 
            this.toolBtnFinal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBtnFinal.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnFinal.Image")));
            this.toolBtnFinal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnFinal.Name = "toolBtnFinal";
            this.toolBtnFinal.Size = new System.Drawing.Size(73, 25);
            this.toolBtnFinal.Text = "期末考试";
            this.toolBtnFinal.Click += new System.EventHandler(this.toolBtnFinal_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(103, 25);
            this.btnHelp.Text = "再看一次说明";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLoadResult);
            this.groupBox1.Controls.Add(this.btnLoadExcel);
            this.groupBox1.Controls.Add(this.btnExamSecond);
            this.groupBox1.Controls.Add(this.btnExamFirst);
            this.groupBox1.Controls.Add(this.btnInput);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 90);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作区";
            // 
            // lblLoadResult
            // 
            this.lblLoadResult.AutoSize = true;
            this.lblLoadResult.Location = new System.Drawing.Point(20, 63);
            this.lblLoadResult.Name = "lblLoadResult";
            this.lblLoadResult.Size = new System.Drawing.Size(113, 20);
            this.lblLoadResult.TabIndex = 2;
            this.lblLoadResult.Text = "未载入Excel数据";
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Location = new System.Drawing.Point(9, 25);
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(87, 31);
            this.btnLoadExcel.TabIndex = 1;
            this.btnLoadExcel.Text = "载入Excel";
            this.btnLoadExcel.UseVisualStyleBackColor = true;
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // btnExamSecond
            // 
            this.btnExamSecond.Location = new System.Drawing.Point(298, 25);
            this.btnExamSecond.Name = "btnExamSecond";
            this.btnExamSecond.Size = new System.Drawing.Size(75, 31);
            this.btnExamSecond.TabIndex = 0;
            this.btnExamSecond.Text = "考试2";
            this.btnExamSecond.UseVisualStyleBackColor = true;
            this.btnExamSecond.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnExamFirst
            // 
            this.btnExamFirst.Location = new System.Drawing.Point(207, 25);
            this.btnExamFirst.Name = "btnExamFirst";
            this.btnExamFirst.Size = new System.Drawing.Size(75, 31);
            this.btnExamFirst.TabIndex = 0;
            this.btnExamFirst.Text = "考试1";
            this.btnExamFirst.UseVisualStyleBackColor = true;
            this.btnExamFirst.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(113, 25);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(75, 31);
            this.btnInput.TabIndex = 0;
            this.btnInput.Text = "平时成绩";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(401, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(604, 90);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "简要说明";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(328, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "4.点击操作区的对应按钮填分数，最后在浏览区提交";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "2.在浏览区登录，并导航到学生名单列表";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "3.载入登分的Excel表格，具体格式可查看说明";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "1.选择服务器地址，再点击需要登分类型";
            // 
            // pgbFinish
            // 
            this.pgbFinish.Name = "pgbFinish";
            this.pgbFinish.Size = new System.Drawing.Size(100, 19);
            this.pgbFinish.Step = 5;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 701);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1024, 740);
            this.Name = "frmMain";
            this.Text = "MySise登分助手-Beta";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUrlType;
        private System.Windows.Forms.WebBrowser brsMain;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolBtnRegular;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolBtnFinal;
        private System.Windows.Forms.ToolStripComboBox cbbUriType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.ToolStripStatusLabel lblFillCount;
        private System.Windows.Forms.Button btnLoadExcel;
        private System.Windows.Forms.Label lblLoadResult;
        private System.Windows.Forms.Button btnExamSecond;
        private System.Windows.Forms.Button btnExamFirst;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnHelp;
        private System.Windows.Forms.ToolStripStatusLabel lblWebStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripProgressBar pgbFinish;
    }
}