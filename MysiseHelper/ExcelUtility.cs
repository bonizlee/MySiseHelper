using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace MysiseHelper
{
   public class ExcelUtility
    {
       public static int  ReadFromExcel(string FileName,out List<StudentMark> Students)
       {
           Students = new List<StudentMark>();
           int count = 0;
           string Ext = System.IO.Path.GetExtension(FileName);
           string strConn;
           if(Ext==".xls")
            strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'", FileName);
           else
               strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data source={0};Extended Properties='Excel 12.0;HDR=Yes;IMEX=1'", FileName);
           OleDbConnection conn = new OleDbConnection(strConn);
           try
           {              
               conn.Open();
               string strExcel = "";
               OleDbDataAdapter myCommand = null;
               DataSet ds = null;
               strExcel = "select * from [Sheet1$]";
               myCommand = new OleDbDataAdapter(strExcel, strConn);
               ds = new DataSet();
               myCommand.Fill(ds, "Mark");
               DataTable dt = ds.Tables[0];
               if (dt != null && dt.Rows.Count > 0)
               {
                   foreach (DataRow item in dt.Rows)
                   {
                       Students.Add(new StudentMark()
                       {
                           SID = item["学号"].ToString(),
                           SName = item["姓名"].ToString(),
                           Mark = item["成绩"].ToString()
                       });
                       count++;
                   }
               }
               conn.Close();
           }
           catch (Exception ex)
           {
               conn.Close();
               throw ex;
           }
          
           return count;
       }
    }
}
