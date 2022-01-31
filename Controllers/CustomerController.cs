using Filters.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Controllers
{
    [SimpleMessage(Message = "A")]
    public class CustomerController : Controller
    {
        // GET: Customer
        /*
        [SimpleMessage(Message = "A", Order = 1)]
        [SimpleMessage(Message = "B", Order = 2)]
        */
        public string Index()
        {
            return "This is the Customer controller";
        }
        [CustomOverrideActionFilters]
        [SimpleMessage(Message = "B")]
        public string OtherAction()
        {
            return "This is the Other Action in the Customer controller";
        }
    }
}