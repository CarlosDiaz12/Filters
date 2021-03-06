using Filters.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // Using the Controller Filter Methods
        private Stopwatch timer;

        // [CustomAuth(true)]
        [Authorize(Users = "admin")]
        public string Index()
        {
            return "This is the Index action on the Home controller";
        }

        [GoogleAuth]
        public string List()
        {
            return "This is the List action on the Home controller";
        }
        // [RangeException]
        // Using the built-in HandleErrorAttribute Filter
        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")]
        public string RangeTest(int id)
        {
            if (id > 100)
            {
                return String.Format("The id value is: {0}", id);
            }
            else
            {
                throw new ArgumentOutOfRangeException("id", id, "");
            }
        }
        // Adding a New Action
        /* [CustomAction]
        [ProfileAction]
        [ProfileResult]
        [ProfileAll]
        */
        public string FilterTest()
        {
            return "This is the FilterTest action";
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }
        protected override void OnResultExecuted(ResultExecutedContext
        filterContext)
        {
            timer.Stop();
            filterContext.HttpContext.Response.Write(
                string.Format("<div>Total elapsed time: {0}</div>",
                    timer.Elapsed.TotalSeconds));
        }

    }
}