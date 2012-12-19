using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MysiseHelper
{
    public enum WebStatus
    {
        NotReady,
        RegularGrade,
        ExamFirst,
        ExamSecond
    }

    public class FillUtility
    {
        public static int FillRegular(WebBrowser Browser,IList<StudentMark> Students)
        {
            return FillDo(Browser, Students, 6);
        }

        private static int FillDo(WebBrowser Browser, IList<StudentMark> Students, int interval)
        {
            int finish = 0;
            HtmlElement marktable;

            HtmlElementCollection tables = Browser.Document.GetElementsByTagName("table");
            marktable = tables[tables.Count - 1].GetElementsByTagName("tbody")[0];
            if (marktable == null)
                return 0;

            foreach (StudentMark stu in Students)
            {
                for (int i = 0; i < marktable.Document.All.Count; i++)
                {
                    if (marktable.Document.All[i].InnerText == stu.SID)
                    {
                        marktable.Document.All[i + interval].InnerText = stu.Mark;
                        finish += 1;
                        continue;
                    }
                }
            }
            return finish;
        }

        public static int FillExamFirst(WebBrowser Browser,IList<StudentMark> Students)
        {
            return FillDo(Browser, Students, 10);
        }

        public static int FillExamSecond(WebBrowser Browser,IList<StudentMark> Students)
        {
            return FillDo(Browser, Students, 11);
        }

        /// <summary>
        /// 显示说明
        /// </summary>
        /// <param name="Browser">浏览器控件</param>
        public static void ShowHelp(WebBrowser Browser)
        {
            Browser.Document.OpenNew(true);
            StringBuilder htmltext = new StringBuilder();
            htmltext.Append("<html><body style=\"text-align:center\"><div style=\"width:800px; margin:0 auto; padding:auto; text-align:left\"><h2>华软登分助手使用说明:</h2><ol>");
            htmltext.Append("<li>首先选择服务器地址</li>");
            htmltext.Append("<li>再点击登分的类型</li>");
            htmltext.Append("<li>在浏览器区域中，登录系统，并选择需要登记的项目，直到浏览器显示学生名单</li>");
            htmltext.Append("<li>在操作区点击“载入Excel”。说明：</li>");
            htmltext.Append("<ul><li>目前只支持xls格式的EXCEL表格载入</li><li>Excel表格的表头样式必须按以下标准，09XXX前的\"0\"不能省略<br /><table border=\"1\"  bordercolor=\"#000000\" cellspacing=\"0\"><tr><th>学号</th><th>姓名</th><th>成绩</th></tr><tr><td>0987654321</td><td>张三</td><td>85.4</td></tr></table></li></ul></li>");
            htmltext.Append("<li>点击对应的登分按钮：平时成绩、考试1、考试2。等待软件自动填充</li>");
            htmltext.Append("<li>检查所有学生分数无误后，可以在浏览区域点击提交</li></ol>");
            htmltext.Append("<P><strong>本软件仅供测试用途，用户登记成绩请慎重检查，以免发生意外！！！</strong></P>");
            htmltext.Append("</div></body></html>");
            Browser.Document.Write(htmltext.ToString());

        }

        static string GetPageTitle(WebBrowser Browser)
        {
            string Title = string.Empty;
            HtmlElementCollection span = Browser.Document.GetElementsByTagName("span");
            if (span!=null)
            {
                Title = span[0].InnerText;
            }            
            return Title;
        }

        public static WebStatus GetPageStatus(WebBrowser Browser)
        {
            WebStatus status ;
            string title=GetPageTitle(Browser);            
            switch (title.Trim())
            {
                case "登平时成绩":
                    status = WebStatus.RegularGrade;
                    break;
                case "第一次登记成绩":
                    status = WebStatus.ExamFirst;
                    break;
                case "第二次登记成绩":
                    status = WebStatus.ExamSecond;
                    break;
                default:
                    status = WebStatus.NotReady;
                    break;
            }
            return status;
        }
    }
}
