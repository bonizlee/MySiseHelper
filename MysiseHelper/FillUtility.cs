using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MysiseHelper
{
    #region 辅助类    
    /// <summary>
    /// 页面状态枚举
    /// </summary>
    public enum WebStatus
    {
        NotReady,
        RegularGrade,
        ExamFirst,
        ExamSecond
    }
    /// <summary>
    /// 完成填充数量的消息参数
    /// </summary>
    public class FillEventArgs : EventArgs
    {
        int _FinishCount;
        public int FinishCount
        {
            get { return this._FinishCount; }
        }

        public FillEventArgs()
        {
            this._FinishCount = 0;
        }

        public FillEventArgs(int count)
        {
            this._FinishCount = count;
        }
    }

    /// <summary>
    /// 页面状态改变消息参数
    /// </summary>
    public class WebStatusEventArgs:EventArgs
    {
        WebStatus _CurrentStatus;
       public WebStatus CurrentStatus{
           get { return _CurrentStatus; }
       }

        public WebStatusEventArgs(WebStatus status)
        {
            _CurrentStatus = status;
        }
    }

    /// <summary>
    /// 填充数目改变事件委托
    /// </summary>
    /// <param name="sender">发起者</param>
    /// <param name="e">已完成的填充个位</param>
    public delegate void FillCountChangeEventHandle(object sender, FillEventArgs e);

    /// <summary>
    /// 页面状态改变事件委托
    /// </summary>
    /// <param name="sender">发起者</param>
    /// <param name="e">更新的页面状态</param>
    public delegate void WebStatusChangeEventHandle(object sender, WebStatusEventArgs e);   
    #endregion

    public class FillUtility
    {
        #region 事件
        /// <summary>
        /// 页面状态改变
        /// </summary>
        public event WebStatusChangeEventHandle WebStatusChange;
        /// <summary>
        /// 填充的数量改变
        /// </summary>
        public event FillCountChangeEventHandle FillCountChange;
        #endregion

        #region 属性
        /// <summary>
        /// 当前页面状态
        /// </summary>
        WebStatus CurrentStatus;
        #endregion

        public FillUtility()
        {
            CurrentStatus = WebStatus.NotReady;
        }

        #region 内部操作方法
        /// <summary>
        /// 填充学生成绩
        /// </summary>
        /// <param name="Browser">浏览器</param>
        /// <param name="Students">学生列表</param>
        /// <param name="interval">Dom的间隔</param>
        /// <returns></returns>
        private int FillDo(WebBrowser Browser, IList<StudentMark> Students, int interval)
        {
            int finish = 0;
            HtmlElement marktable;

            HtmlElementCollection tables = Browser.Document.GetElementsByTagName("table");
            marktable = tables[tables.Count - 1].GetElementsByTagName("tbody")[0];
            if (marktable == null)
                return 0;

            foreach (StudentMark stu in Students)
            {
                int i = 90;
                for (; i < marktable.Document.All.Count; i++)
                {
                    if (marktable.Document.All[i].InnerText == stu.SID)
                    {
                        marktable.Document.All[i + interval].InnerText = stu.Mark;
                        finish += 1;
                        //若填写了一个学生，触发填写事件
                        FillCountChange(this, new FillEventArgs(finish));
                        i =i+interval+3;
                        continue;
                    }
                }
            }
            return finish;
        }


        /// <summary>
        ///  填充考查成绩
        /// </summary>
        /// <param name="Browser">浏览器</param>
        /// <param name="Students">学生名单</param>
        /// <param name="interval">第二次登分option从9开始</param>
        /// <returns></returns>
        private int FillKaoChaDo(WebBrowser Browser, IList<StudentMark> Students, int interval)
        {
            int finish = 0;
            HtmlElement marktable;

            HtmlElementCollection tables = Browser.Document.GetElementsByTagName("table");
            marktable = tables[tables.Count - 1].GetElementsByTagName("tbody")[0];
            if (marktable == null)
                return 0;

            foreach (StudentMark stu in Students)
            {
                int i = 89;
                for (; i < marktable.Document.All.Count; i++)
                {
                    if (marktable.Document.All[i].InnerText == stu.SID)
                    {
                        for (int j = 1; j <=6; j++)
                        {
                            if (marktable.Document.All[i + interval + j].InnerText == stu.Mark)
                                marktable.Document.All[i + interval + j].SetAttribute("selected", "true");
                        }
                        finish += 1;
                        //若填写了一个学生，触发填写事件
                        FillCountChange(this, new FillEventArgs(finish));
                        i += 17;
                        continue;
                    }
                }
            }
            return finish;
        }

        /// <summary>
        /// 获取页面的内容部分标题
        /// </summary>
        /// <param name="Browser"></param>
        /// <returns>标题字符串</returns>
        private string GetPageTitle(WebBrowser Browser)
        {
            string Title = string.Empty;
            HtmlElementCollection span = Browser.Document.GetElementsByTagName("span");
            if (span != null)
            {
                Title = span[0].InnerText;
            }
            return Title.Trim();
        }

        /// <summary>
        /// 计算页面有多少个Table，少于5个表示没有查询出学生数据
        /// </summary>
        /// <param name="Browser"></param>
        /// <returns></returns>
        private int CountPageTable(WebBrowser Browser)
        {
            HtmlElementCollection table = Browser.Document.GetElementsByTagName("table");

            return table.Count;
        }
        #endregion

        #region 公开方法

        /// <summary>
        /// 填写平时成绩
        /// </summary>
        /// <param name="Browser"></param>
        /// <param name="Students"></param>
        /// <returns></returns>
        public  int FillRegular(WebBrowser Browser,IList<StudentMark> Students)
        {
            return FillDo(Browser, Students, 6);//平时成绩页面学号与分数栏直接间隔6个DOM对象
        }        

        /// <summary>
        /// 填写第一次考试成绩
        /// </summary>
        /// <param name="Browser"></param>
        /// <param name="Students"></param>
        /// <returns></returns>
        public  int FillExamFirst(WebBrowser Browser,IList<StudentMark> Students)
        {
            if(IsKaoCha(Browser))
                return FillKaoChaDo(Browser, Students, 7);

            return FillDo(Browser, Students, 10);//考试成绩第一次登记页面学号与分数栏直接间隔10个DOM对象
            
        }

        /// <summary>
        /// 填写第二次考试成绩
        /// </summary>
        /// <param name="Browser"></param>
        /// <param name="Students"></param>
        /// <returns></returns>
        public  int FillExamSecond(WebBrowser Browser,IList<StudentMark> Students)
        {
            if(IsKaoCha(Browser))
                return FillKaoChaDo(Browser, Students, 8);
            
            return FillDo(Browser, Students, 11);//考试成绩第二次登记页面学号与分数栏直接间隔11个DOM对象            
        }

        public bool IsKaoCha(WebBrowser Browser)
        {
            HtmlElementCollection selecttag = Browser.Document.GetElementsByTagName("select");
            if(selecttag.Count>2)
                return true;
            return false;
        }

        /// <summary>
        /// 显示说明
        /// </summary>
        /// <param name="Browser">浏览器控件</param>
        public  void ShowHelp(WebBrowser Browser)
        {
            Browser.Document.OpenNew(true);
            StringBuilder htmltext = new StringBuilder();
            htmltext.Append("<html><body style=\"text-align:center\"><div style=\"width:800px; margin:0 auto; padding:auto; text-align:left\"><h2>华软登分助手（Ver 0.8.0）使用说明:</h2><ol>");
            htmltext.Append("<li>首先选择服务器地址</li>");
            htmltext.Append("<li>再点击登分的类型</li>");
            htmltext.Append("<li>在浏览器区域中，登录系统，并选择需要登记的项目，直到浏览器显示学生名单</li>");
            htmltext.Append("<li>在操作区点击“载入Excel”。说明：</li>");
            htmltext.Append("<ul><li>目前只支持xls格式的EXCEL表格载入</li><li>表名必须是sheet1</li><li>Excel表格的表头样式必须按以下标准，09XXX前的\"0\"不能省略。软件只查找\"学号\"一栏，若匹配则填入\"成绩\"的数据<br /><table border=\"1\"  bordercolor=\"#000000\" cellspacing=\"0\"><tr><th>学号</th><th>姓名</th><th>成绩</th></tr><tr><td>0987654321</td><td>张三</td><td>85.4</td></tr></table></li></ul>");
            htmltext.Append("<li>点击对应的登分按钮：平时成绩、考试1、考试2。等待软件自动填充</li>");
            htmltext.Append("<li>检查所有学生分数无误后，可以在浏览区域点击提交</li></ol>");
            htmltext.Append("<ul><li><b>0.8.0更新内容，支持考查课程的成绩登记。</b></li>");
            htmltext.Append("</ul>");
            htmltext.Append("<P><strong>本软件仅供测试用途，用户登记成绩请慎重检查，以免发生意外！！！</strong></P>");
            htmltext.Append("</div></body></html>");
            Browser.Document.Write(htmltext.ToString());
            WebStatusChange(this, new WebStatusEventArgs(WebStatus.NotReady));
        }        

        /// <summary>
        /// 更新页面状态
        /// </summary>
        /// <param name="Browser"></param>
        public  void GetPageStatus(WebBrowser Browser)
        {
            WebStatus status ;
            status = WebStatus.NotReady;
            string title=GetPageTitle(Browser);
            int tablecount = CountPageTable(Browser);//4 5
            switch (title.Trim())
            {
                case "登平时成绩":
                    if(tablecount>4)
                        status = WebStatus.RegularGrade;
                    break;
                case "第一次登记成绩":
                    if (tablecount > 4)
                        status = WebStatus.ExamFirst;
                    break;
                case "第二次登记成绩":
                    if (tablecount > 4)
                        status = WebStatus.ExamSecond;
                    break;
                default:
                    status = WebStatus.NotReady;
                    break;
            }

            //若新状态，触发状态改变事件
            if (CurrentStatus != status)
            {
                CurrentStatus = status;
                WebStatusChange(this, new WebStatusEventArgs(CurrentStatus));
            }            
        }
        #endregion
    }
}
