using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MotelManager.Common;
using MotelManager.Models.EF;

namespace MotelManager.Models.DAO
{
    public class UserDAO
    {
        DBContext db = new DBContext();
        public int Login(string userName, string password)
        {
            var result = db.Accounts.SingleOrDefault(x => x.username == userName);
            if(result == null)
            {
                return 0;
            }
            else if (result.role == CommonConstants.USER_GROUP)
            {
                if (result.password == password)
                    if (result.status == true)
                        return 1;
                    else
                        return 3;
                else
                    return -2;
            }
            else
            {
                return -3;
            }
        }
        public int Register(Account model)
        {
            var user = db.Accounts.Where(x => x.username == model.username).FirstOrDefault();
            if(user == null)
            {
                var newUser = db.Accounts.Where(x => x.email == model.email).FirstOrDefault();
                if(newUser == null)
                {
                    var res = Insert(model);
                    if (res)
                        return 1;//Thanh cong
                    else
                        return 4; // loi
                }
                else
                {
                    return 3;//email da ton tai
                }
            }
            else
            {
                return 2;//username da ton tai
            }
        }
        public Account Update(Account model)
        {
            Account user = db.Accounts.Where(m => m.username == model.username).FirstOrDefault();
            user.fullname = model.fullname;
            user.email = model.email;
            if(model.avatar != null)
                user.avatar = model.avatar;
            if (model.phone != null)
                user.phone = model.phone;
            if (model.sex != null)
                user.sex = model.sex;
            if(model.ImageUpload != null)
            {
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(model.ImageUpload.InputStream))
                {
                    bytes = br.ReadBytes(model.ImageUpload.ContentLength);
                }
                user.avatarImage = bytes;
            }
            db.SaveChanges();
            return user;
        }

        public Account GetByID(int? id)
        {
            return db.Accounts.SingleOrDefault(x => x.account_id == id);
        }
        public Account GetByName(string name)
        {
            return db.Accounts.SingleOrDefault(x => x.username == name);
        }
        public bool Insert(Account entity)
        {
            try
            {
                db.Accounts.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CheckUserName(string userName)
        {
            return db.Accounts.Count(x => x.username == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Accounts.Count(x => x.email == email) > 0;
        }
        public bool CheckPass(string pass, string username)
        {
            try
            {
                Account user = db.Accounts.Where(x => x.username == username).FirstOrDefault();
                if (Encryptor.MD5Hash(pass) == user.password)
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }
        public bool ChangePass(string new_pass, string username)
        {
            try
            {
                Account user = db.Accounts.Where(x => x.username == username).FirstOrDefault();
                user.password = Encryptor.MD5Hash(new_pass);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}