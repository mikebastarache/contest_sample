using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mm_contest.Controllers
{
    public class MessageController : Controller
    {
        //
        // GET: /Message/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Message/Registration
        public ActionResult RegistrationSuccessful()
        {
            return View();
        }

        //
        // GET: /Message/AccountCreationFailed
        public ActionResult AccountCreationFailed()
        {
            return View();
        }


        //
        // GET: /Message/AccountUpdateFailed
        public ActionResult AccountUpdateFailed()
        {
            return View();
        }


        //
        // GET: /Message/AlreadyEntered
        public ActionResult AlreadyEntered()
        {
            return View();
        }


        //
        // GET: /Message/BallotError
        public ActionResult BallotError()
        {
            return View();
        }


        //
        // GET: /Message/ContestClosed
        public ActionResult ContestClosed()
        {
            return View();
        }


        //
        // GET: /Message/ContestNotOpen
        public ActionResult ContestNotOpen()
        {
            return View();
        }

        //
        // GET: /Message/NotAgeOfMajority
        public ActionResult NotAgeOfMajority()
        {
            return View();
        }


        //
        // GET: /Message/SessionLost
        public ActionResult SessionLost()
        {
            return View();
        }


        //
        // GET: /Message/UserDoesNotExist
        public ActionResult UserDoesNotExist()
        {
            return View();
        }


    }
}
