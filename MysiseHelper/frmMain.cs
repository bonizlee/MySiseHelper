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
        WebStatus CurrentStatus;
        List<StudentMark> listStuent=new List<StudentMark>();

        public event EventHandler WebStatusChange;

        public frmMain()
        {
            InitializeComponent();

            CurrentStatus = WebStatus.NotReady;
            cbbUriType.SelectedIndex = 0;
            BaseURI = SpecialURI;
            lblUrlType.Text = "正常网址 |";
            btnInput.Enabled = false;
            btnExamFirst.Enabled = false;
            btnExamSecond.Enabled = false;
            cbbUriType.SelectedIndexChanged += new EventHandler(cbbUriType_SelectedIndexChanged);
            this.WebStatusChange += new EventHandler(frmMain_WebStatusChange);
        }

        void frmMain_WebStatusChange(object sender, EventArgs e)
        {
            switch (CurrentStatus)
            {
                case WebStatus.NotReady:
                    lblWebStatus.Text = "请先进入登分页面";
                    btnInput.Enabled = false;
                    btnExamFirst.Enabled = false;
                    btnExamSecond.Enabled = false;
                    break;
                case WebStatus.RegularGrade:
                    lblWebStatus.Text = "可以登记平时成绩";
                    btnInput.Enabled = true;
                    btnExamFirst.Enabled = false;
                    btnExamSecond.Enabled = false;
                    break;
                case WebStatus.ExamFirst:
                    lblWebStatus.Text = "可以登记第一次考试成绩";
                    btnInput.Enabled = false;
                    btnExamFirst.Enabled = true;
                    btnExamSecond.Enabled = false;
                    break;
                case WebStatus.ExamSecond:
                    lblWebStatus.Text = "可以登记第二次考试成绩";
                    btnInput.Enabled = false;
                    btnExamFirst.Enabled = false;
                    btnExamSecond.Enabled = true;
                    break;                
            }
        }

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

        private void frmMain_Load(object sender, EventArgs e)
        {
            brsMain.Navigate("about:blank");
            FillUtility.ShowHelp(brsMain);
        }

        private void toolBtnRegular_Click(object sender, EventArgs e)
        {
            string url = BaseURI + @"exam/registerExamResultAction.do?method=doSelectCourseCommonMain";
//#if DEBUG
 //           url = @"http://localhost/s_do.htm";
//#endif
            

            brsMain.Navigate(url);
        }

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
                    finish=FillUtility.FillRegular(brsMain, listStuent);
                    break;

                case "btnExamFirst":
                    finish = FillUtility.FillExamFirst(brsMain, listStuent);
                    break;

                case "btnExamSecond":
                    finish = FillUtility.FillExamSecond(brsMain, listStuent);
                    break;

                default:
                    break;
            }            
            lblFillCount.Text = string.Format(" | 完成了{0}个学生的成绩填写", finish);            

        }

        private bool IsLoadExcel()
        {
            return (listStuent == null || listStuent.Count == 0);
        }

        private void toolBtnFinal_Click(object sender, EventArgs e)
        {
            string url = BaseURI + @"exam/registerExamResultAction.do?method=doSelectCourseMain";

//#if DEBUG
 //url = @"http://localhost/first.htm";
 //url = @"http://localhost/second.htm";
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            FillUtility.ShowHelp(brsMain);
        }

        private void brsMain_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebStatus temp= FillUtility.GetPageStatus(brsMain);
            if (CurrentStatus != temp)
            {
                CurrentStatus = temp;
                WebStatusChange(this, null);
            }
        }         
    }
}
