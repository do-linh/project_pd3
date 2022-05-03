using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotelManager.Common
{
    public class UserLogin
    {
        public long userID { get; set; }
        public string UserName { get; set; }
        public string fullname { get; set; }
        public string FullName { get; set; }
        public string GroupID { set; get; }
        public string avatar { get; set; }
    }
}