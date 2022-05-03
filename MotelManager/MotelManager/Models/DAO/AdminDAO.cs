using MotelManager.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotelManager.Models.DAO
{
    public class AdminDAO
    {
        private DBContext db = new DBContext();
        public int Login(string username, string password)
        {
            var res = db.Accounts.Where(x => x.username == username).FirstOrDefault();
            if(res == null)
            {
                return 0; //tai khoan khong ton tai
            }
            else
            {
                if(res.role == "admin")
                {
                    if (res.password == password)
                        return 1; // dang nhap thanh cong
                    else
                        return -2; // sai mat khau
                }
                else
                {
                    return -1; //tai khoan ko co quyen dang nhap
                }
            }
        }
        public Account GetByUserName(string name)
        {
            return db.Accounts.SingleOrDefault(x => x.username == name);
        }
    }
}