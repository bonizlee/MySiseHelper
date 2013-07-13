#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Xml.Linq;

namespace MysiseHelper
{   
    public partial class frmMain : Form
    {
        
        string NormalURI = @"http://class.sise.com.cn:7001/SISEWeb/";
        string SpecialURI = @"http://172.16.3.78:7001/SISEWeb/";
        
        string BaseURI = "";
        
        List<StudentMark> listStuent=new List<StudentMark>();
        FillUtility FillHelper = new FillUtility();        

        public frmMain()
        {
            InitializeComponent();

            InitializeProperties();
        }

        /// <summary>
        /// 初始化属性
        /// </summary>
        private void InitializeProperties()
        {           
            cbbUriType.SelectedIndex = 0;
            BaseURI = NormalURI;
            lblUrlType.Text = "正常网址 |";
            btnInput.Enabled = false;
            btnExamFirst.Enabled = false;
            btnExamSecond.Enabled = false;
            cbbUriType.SelectedIndexChanged += new EventHandler(cbbUriType_SelectedIndexChanged);
           
            pgbFinish.Maximum = 1;
            pgbFinish.Minimum = 0;

            //添加事件处理
            FillHelper.FillCountChange +=new FillCountChangeEventHandle(FillHelper_FillCountChange);
            FillHelper.WebStatusChange += new WebStatusChangeEventHandle(FillHelper_WebStatusChange);
        }

        /// <summary>
        /// 页面状态改变时，激活对应的按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FillHelper_WebStatusChange(object sender, WebStatusEventArgs e)
        {
            switch (e.CurrentStatus)
            {
                case WebStatus.NotReady:
                    lblWebStatus.Text = "请先进入登分页面 | ";
                    btnInput.Enabled = false;
                    btnExamFirst.Enabled = false;
                    btnExamSecond.Enabled = false;
                    break;
                case WebStatus.RegularGrade:
                    lblWebStatus.Text = "可以登记平时成绩 | ";
                    btnInput.Enabled = true;
                    btnExamFirst.Enabled = false;
                    btnExamSecond.Enabled = false;
                    break;
                case WebStatus.ExamFirst:
                    lblWebStatus.Text = "可以登记第一次考试成绩 | ";
                    btnInput.Enabled = false;
                    btnExamFirst.Enabled = true;
                    btnExamSecond.Enabled = false;
                    break;
                case WebStatus.ExamSecond:
                    lblWebStatus.Text = "可以登记第二次考试成绩 | ";
                    btnInput.Enabled = false;
                    btnExamFirst.Enabled = false;
                    btnExamSecond.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// 填充的人数变化，更新进度条和状态栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FillHelper_FillCountChange(object sender, FillEventArgs e)
        {
            pgbFinish.Value = e.FinishCount;
            lblFillCount.Text = string.Format(" 完成了{0}个学生的成绩填写", e.FinishCount);      
        }  

        /// <summary>
        /// 切换服务器地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cbbUriType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbbUriType.SelectedIndex)
            {
                case  0:
                    BaseURI = NormalURI;
                    lblUrlType.Text = "正常网址 | ";                   
                    break;
                case 1:
                    BaseURI = SpecialURI;
                    lblUrlType.Text = "选课期间网址 | ";                  
                    break;
            }
        }

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            brsMain.Navigate("about:blank");
            FillHelper.ShowHelp(brsMain);
        }

        private void toolBtnRegular_Click(object sender, EventArgs e)
        {
            string url = BaseURI + @"exam/registerExamResultAction.do?method=doSelectCourseCommonMain";
//#if debug
//            url = @"http://localhost/1.htm";
//#endif

            brsMain.Navigate(url);
        }

        /// <summary>
        /// 点击操作区的按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInput_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int finish=0;
            if (IsLoadExcel())
            {
                MessageBox.Show("未导入学生数据，无法登分");
                return;
            }

            switch (btn.Name)
            {
                case "btnInput":
                    finish=FillHelper.FillRegular(brsMain, listStuent);
                    break;

                case "btnExamFirst":
                    finish = FillHelper.FillExamFirst(brsMain, listStuent);
                    break;

                case "btnExamSecond":
                    finish = FillHelper.FillExamSecond(brsMain, listStuent);
                    break;

                default:
                    break;
            }            
            lblFillCount.Text = string.Format(" 完成了{0}个学生的成绩填写", finish);   
        }

        /// <summary>
        /// 判断是否已经加载学生数据
        /// </summary>
        /// <returns></returns>
        private bool IsLoadExcel()
        {
            return (listStuent == null || listStuent.Count == 0);
        }

        private void toolBtnFinal_Click(object sender, EventArgs e)
        {
            string url = BaseURI + @"exam/registerExamResultAction.do?method=doSelectCourseMain";

//#if DEBUG
            //url = @"http://localhost/1.htm";
            //url = @"http://localhost/first.htm";
//#endif          

            brsMain.Navigate(url);
        }

        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openExcel = new OpenFileDialog();
            openExcel.Filter = "Excel文件|*.xls";//;*.xlsx";
            if (openExcel.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int r=ExcelUtility.ReadFromExcel(openExcel.FileName, out listStuent);
                    lblLoadResult.Text = string.Format("载入{0}条数据",r);
                    pgbFinish.Maximum = r;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {           
            FillHelper.ShowHelp(brsMain);
        }

        private void brsMain_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            FillHelper.GetPageStatus(brsMain);           
        }         
    }
}
