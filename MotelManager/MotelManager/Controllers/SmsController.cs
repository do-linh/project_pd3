using MotelManager.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Verify.V2.Service;

namespace MotelManager.Controllers
{
    public class SmsController : Controller
    {
        private DBContext db = new DBContext();

        private string accountSid = "AC7416a43269262f6beb85c5531d85f2e0";
        private string authToken = "f0ae07aec71f752e7e71b1bdb8a636ca";
        private string serviceSid = "VA46d042743673dc2c67678e82c98d1cef";
        // GET: Sms
        public ActionResult Index(int isChangePhone)
        {
            if(isChangePhone == 0)
            {
                var session = (MotelManager.Common.UserLogin)Session[MotelManager.Common.CommonConstants.USER_SESSION];
                Account user = db.Accounts.Find(session.userID);
                return View(user);
            }
            else
            {
                Account user = new Account();
                return View(user);
            }
        }
        [HttpPost]
        public ActionResult Verification(string newPhone)
        {
            var session = (MotelManager.Common.UserLogin)Session[MotelManager.Common.CommonConstants.USER_SESSION];
            Account user = db.Accounts.Find(session.userID);
            user.authority = 2;
            //user.phone = newPhone;
            user.authority = 2;
            db.SaveChanges();
            return RedirectToAction("EditProfile", "UserManager", new { username = session.UserName });
        }
        [HttpPost]
        public string sendOTP(string phone)
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            TwilioClient.Init(accountSid, authToken);
            CreateVerificationOptions options = new CreateVerificationOptions(serviceSid, phone, "sms");
            var verification = VerificationResource.Create(options);
            return verification.Status;
        }

        [HttpPost]
        public string verifyOTP(string phone, string OTP)
        {
            TwilioClient.Init(accountSid, authToken);
            var verificationCheck = VerificationCheckResource.Create(to: phone, code: OTP, pathServiceSid: serviceSid);
            return verificationCheck.Status;
        }
    }
}