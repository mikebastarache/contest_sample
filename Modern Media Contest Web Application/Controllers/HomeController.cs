using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MMContest;
using MMContest.Models;
using MMContest.Dal;
using System.Globalization;
using mm_contest.ViewModels;

namespace mm_contest.Controllers
{
    public class HomeController : Controller
    {
        private readonly CrmContext _db = new CrmContext();
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly int _contestId = Properties.Settings.Default.ContestId;

        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Home
        [HttpPost]
        public ActionResult Index(VerifyUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            //reset session variables
            Session["VoteStatus"] = false;
            Session["Minor"] = false;
            Session["Province"] = null;
            Session["YearOfBirth"] = null;
            Session["Dob"] = null;
            Session["friendId"] = null;
            Session["Email"] = null;

            var contest = new MicrositeLogic();

            switch (contest.EnterContest(model.Email, _contestId))
            {
                case "userDoesNotExistInCRM":
                    Session["Email"] = model.Email;
                    return RedirectToAction("Index", "Register");

                case "userHasNotEnteredThisContest":
                    Session["Email"] = model.Email;
                    return RedirectToAction("Index", "Register");

                case "userHasAlreadyEnteredToday":
                    return RedirectToAction("AlreadyEntered", "Message");

                default:
                    //User is already registered and is now ready for the next step, game, activity or thank you page.
                    Session["Email"] = model.Email;
                    return RedirectToAction("Index", "Invite");
            }
        }

        //
        // GET: /Home/Rules
        public ActionResult Rules()
        {
            return View();
        }

        //
        // GET: /Home/RulesPopUp
        public ActionResult RulesPopUp()
        {
            return View();
        }

        //
        // GET: /Home/PrivacyPolicy
        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        //
        // GET: /Home/PrivacyPolicyPopUp
        public ActionResult PrivacyPolicyPopUp()
        {
            return View();
        }

        //
        // GET: /Home/Prizes
        public ActionResult Prizes()
        {
            return View();
        }

        //
        // GET: /Language/
        public ActionResult Language(string language)
        {
            Session["Culture"] = new CultureInfo(language);

            return Request.UrlReferrer != null ? Redirect(Request.UrlReferrer.AbsolutePath.ToString(CultureInfo.InvariantCulture)) : null;
        }


        private string GetIpAddress()
        {
            // GET users IP address
            var ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipAddress))
            {
                var ipRange = ipAddress.Split(',');
                ipAddress = ipRange[0].Trim();
            }
            else
            {
                ipAddress = Request.ServerVariables["REMOTE_ADDR"];
            }

            return ipAddress;
        }

    }
}
