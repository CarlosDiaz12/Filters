using Filters.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        [CustomAuth(false)]
        public string Index()
        {
            return "This is the Index action on the Home controller";
        }
    }
}