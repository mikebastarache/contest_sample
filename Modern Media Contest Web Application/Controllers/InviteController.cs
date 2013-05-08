using System;
using System.Web.Mvc;
using mm_contest.ViewModels;
using mm_contest.Web.Resources;
using MMContest;
using MMContest.Dal;
using MMContest.Models;

namespace mm_contest.Controllers
{
    public class InviteController : Controller
    {
        private readonly CrmContext _db = new CrmContext();
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly int _contestId = Properties.Settings.Default.ContestId;

        //
        // GET: /Invite/
        public ActionResult Index()
        {
            if (Session["Email"] == null)
                return RedirectToAction("SessionLost", "Message");

            MicrositeLogic contest = new MicrositeLogic();

            int userId = contest.GetUserId(Session["Email"].ToString());
            if (userId > 0)
            {
                int invitedFriendCount = contest.TotalFriendInvitations(_contestId, userId);
                int extraBallotCount = contest.TotalExtraFriendBallotsEarned(userId, _contestId);
                ViewBag.CountsContent = String.Format(_InviteResources.Invite_TotalFriends, invitedFriendCount, extraBallotCount);
            }
            return View();
        }

        // POST: /Invite/Index
        [HttpPost]
        public ActionResult Index(InviteViewModel model)
        {
            if (Session["Email"] == null)
                return RedirectToAction("SessionLost", "Message");

            MicrositeLogic contest = new MicrositeLogic();
            User user = contest.GetUser(Session["Email"].ToString());

            int invitedFriendCount = 0;
            int extraBallotCount = 0;
            ViewBag.CountsContent = String.Format(_InviteResources.Invite_TotalFriends, invitedFriendCount, extraBallotCount);

            if (!ModelState.IsValid)
            {
                invitedFriendCount = contest.TotalFriendInvitations(_contestId, user.UserId);
                extraBallotCount = contest.TotalExtraFriendBallotsEarned(user.UserId, _contestId);
                ViewBag.CountsContent = String.Format(_InviteResources.Invite_TotalFriends, invitedFriendCount, extraBallotCount);
                return View(model);
            }

            Guid invitationGuid = Guid.NewGuid();

            // CREATE Friend
            Friend newFriend = new Friend
            {
                FirstName = model.InviteFirstName,
                LastName = model.InviteLastName,
                Email = model.InviteEmail,
                ReferrerUserId = user.UserId,
                ContestId = _contestId,
                InvitationIdentifier = invitationGuid
            };

            //BUILD EMAIL
            string emailBody = _InviteResources.EmailBody_InviteFriend.Replace("[FIRSTNAME],", model.InviteFirstName);
            emailBody = emailBody.Replace("[INVITERFIRSTNAME]", user.FirstName);
            emailBody = emailBody.Replace("[GUID]", invitationGuid.ToString());
            emailBody = emailBody.Replace("[DOMAIN]", Properties.Settings.Default.ContestUrl_En);

            try{
                contest.CreateNewFriend(newFriend, "en-CA", Properties.Settings.Default.WebApiUri, "majesta", _InviteResources.EmailSubjectLine_InviteFriend,
                                    emailBody, _InviteResources.EmailHeader, _InviteResources.EmailFooter);
            }
            catch (Exception ae)
            {
                //REDIRECT TO GENERIC ERROR PAGE
                return RedirectToAction("Index", "Message", ae);
            }

            ViewBag.EmailStatus = _InviteResources.Invite_SentMsg.Replace("[FIRSTNAME]", model.InviteFirstName);
            invitedFriendCount = contest.TotalFriendInvitations(_contestId, user.UserId);
            extraBallotCount = contest.TotalExtraFriendBallotsEarned(user.UserId, _contestId);
            ViewBag.CountsContent = String.Format(_InviteResources.Invite_TotalFriends, invitedFriendCount, extraBallotCount);

            ModelState.Clear();
            return View();
        }

    }
}
