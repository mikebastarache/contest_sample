using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Threading;
using System.Globalization;
using System.Web.WebPages;
using mm_contest.Classes;

namespace mm_contest
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalFilters.Filters.Add(new CheckApplicationStateAttribute());
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Set default values for all session variables
            Session["VoteStatus"] = false;
            Session["Minor"] = false;
            Session["Email"] = null;
            Session["Province"] = null;
            Session["YearOfBirth"] = null;
            Session["Dob"] = null;
            Session["friendId"] = null;
            Session["questionAnswer"] = "";

            //Sets culture based on URL
            string langName;

            if (Request.Url.Host == mm_contest.Properties.Settings.Default.Domain_Fr | Request.Url.Host == "")
                langName = "fr-CA";
            else
                langName = "en-CA";

            var ci = new CultureInfo(langName);
            Session["Culture"] = ci;

            //Check to see if GUID is passed from hyperlink
            if (!String.IsNullOrEmpty(Request.Params["guid"]))
                Session["Guid"] = Request.Params["guid"];

            //Set Session for Invitation ID if it exists in the QueryString
            if (!String.IsNullOrEmpty(Request.Params["id"]))
                Session["friendId"] = Request.Params["id"];
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            //It's important to check whether session object is ready
            if (HttpContext.Current.Session == null)
                return;

            var ci = (CultureInfo)Session["Culture"];

            //Checking first if there is no value in session 
            //and set default language 
            //this can happen for first user's request
            if (ci == null)
            {
                //Sets default culture to English invariant
                string langName = "en-CA";

                //Try to get values from Accept lang HTTP header
                if (HttpContext.Current.Request.UserLanguages != null && HttpContext.Current.Request.UserLanguages.Length != 0)
                {
                    try
                    {
                        //Gets accepted list 
                        langName = HttpContext.Current.Request.UserLanguages[0].Substring(0, 5);
                    }
                    catch
                    {
                    }
                }

                ci = new CultureInfo(langName);
                Session["Culture"] = ci;
            }

            //Finally setting culture for each request
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
        }

    }
}