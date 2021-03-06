using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class ProfileResultAttribute: FilterAttribute, IResultFilter
    {
        private Stopwatch timer;

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            timer.Stop();
            if (filterContext.Exception == null)
            {
                filterContext.HttpContext.Response.
                    Write(string.Format("<div>Action method elapsed time: {0:F6}</ div></br> ", timer.Elapsed.TotalSeconds));
            }
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }
    }
}