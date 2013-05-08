using System;
using System.Web.Mvc;
using MMContest;
using MMContest.Dal;
using MMContest.Models;
using mm_contest.ViewModels;
using mm_contest.Web.Resources;

namespace mm_contest.Controllers
{
    public class RegisterController : Controller
    {

        private readonly CrmContext _db = new CrmContext();
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly int _contestId = Properties.Settings.Default.ContestId;
        private readonly string _ballotSource = Properties.Settings.Default.BallotSource;


        //
        // GET: /Register/
        public ActionResult Index()
        {
            if (Session["Email"] == null)
                return RedirectToAction("SessionLost", "Message");
            
            ViewBag.Salutation = new SelectList(_db.Salutations, "Id", "SalutationEn");
            ViewBag.Province = Session["Culture"].ToString() == "fr-CA" ? new SelectList(_db.Provinces, "Abbreviation", "NameFR") : new SelectList(_db.Provinces, "Abbreviation", "NameEN");
            
            // CREATE User prefilled data
            UserViewModel userModel = new UserViewModel
            {
                OptIn = true
            };
            return View(userModel);
        }

        //
        // POST: /Registration/Index
        [HttpPost]
        public ActionResult Index(UserViewModel model)
        {
            if (Session["Email"] == null)
                return RedirectToAction("SessionLost", "Message");

            if (!ModelState.IsValid)
            {
                ViewBag.Salutation = new SelectList(_db.Salutations, "Id", "SalutationEn");
                ViewBag.Province = Session["Culture"].ToString() == "fr-CA" ? new SelectList(_db.Provinces, "Abbreviation", "NameFR") : new SelectList(_db.Provinces, "Abbreviation", "NameEN");
            
                // CREATE User prefilled data
                UserViewModel userModel = new UserViewModel
                {
                    OptIn = true
                };
                return View(userModel);
            }

            int? originalFriendId = null;
            if (model.OriginalFriendId > 0)
                originalFriendId = model.OriginalFriendId;

            //CREATE CONTEST OBJECT
            MicrositeLogic contest = new MicrositeLogic();

            // CREATE USER OBJECT
            User userObj = new User
            {
                Salutation = model.Salutation,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Address1 = model.Address1,
                Address2 = model.Address2,
                City = model.City,
                Province = model.Province,
                PostalCode = model.PostalCode,
                Telephone = model.Telephone,
                Language = model.Language,
                OptIn = model.OptIn,
                YearOfBirth = model.YearOfBirth,
                OriginalFriendId = originalFriendId,
                ContestSignupId = model.ContestSignupId,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            //TRY TO SEND REGISTRATION FORM DATA TO THE CONTEST LIBRARY
            try
            {
                string result = contest.Register(userObj, Properties.Settings.Default.WebApiUri, "royale");

                int userId = 0;

                if (result == "AccountUpdateSuccessful" || result == "AccountCreationSuccessful")
                {
                    userId = contest.GetUserId(model.Email);
                    if (userId == -1)
                    {
                        result = "UserDoesNotExist";
                    }
                }

                switch (result)
                {
                    case "AccountUpdateSuccessful":
                        //REGISTER USER INTO CONTEST
                        contest.CreateUserContestRegistration(userId, _contestId);

                        //AWARD 1 BALLOT
                        contest.CreateNewBallot(userId, _contestId, "Microsite", GetIpAddress());

                        //REDIRECT TO PAGE: THANKS or ACTIVITY
                        return RedirectToAction("RegistrationSuccessful", "Message");

                    case "AccountCreationSuccessful":
                        //REGISTER USER INTO CONTEST
                        contest.CreateUserContestRegistration(userId, _contestId);

                        //AWARD 1 BALLOT
                        contest.CreateNewBallot(userId, _contestId, "Microsite", GetIpAddress());

                        //REDIRECT TO PAGE: THANKS or ACTIVITY
                        return RedirectToAction("RegistrationSuccessful", "Message");

                    case "NotAgeOfMajority":
                        //REDIRECT TO NOT AGE OF MAJORITY PAGE
                        return RedirectToAction("NotAgeOfMajority", "Message", "NotAgeOfMajority");

                    case "UserDoesNotExist":
                        //REDIRECT TO USER DOES NOT EXIST PAGE
                        return RedirectToAction("UserDoesNotExist", "Message", "UserDoesNotExist");

                    case "AccountUpdateFailed":
                        //REDIRECT TO ACCOUNT UPDATE FAILED PAGE
                        return RedirectToAction("AccountUpdateFailed", "Message", "AccountUpdateFailed");

                    case "AccountCreationFailed":
                        //REDIRECT TO ACCOUNT CREATION FAILED PAGE
                        return RedirectToAction("AccountCreationFailed", "Message", "AccountCreationFailed");

                    default:
                        //REDIRECT TO GENERIC ERROR PAGE
                        return RedirectToAction("Index", "Message", "General");
                }
            }
            catch (Exception ae)
            {
                //REDIRECT TO GENERIC ERROR PAGE
                return RedirectToAction("Index", "Message", ae);
            }
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
