using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;

namespace MysiseHelper
{
   public class StudentMark:IEnumerable
    {
        public string SID { get; set; }
        public string SName { get; set; }
        public string MarkType { get; set; }
        public string Mark { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
