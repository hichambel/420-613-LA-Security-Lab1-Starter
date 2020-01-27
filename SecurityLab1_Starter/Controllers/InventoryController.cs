using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Controllers
{
    [Authorize(Users = "testuser2")]
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            //var ex ="asdasdasd";

            //var exc = Server.GetLastError();

            var myException = filterContext.Exception;

            filterContext.ExceptionHandled = true;
            //Log the error!!
            Logger log = new Logger();
            log.LogToEventViewer(EventLogEntryType.Error, myException.Message);
            //Redirect or return a view, but not both.
            filterContext.Result = RedirectToAction("Index","Error");            Logger logg = new Logger();

            using (StreamWriter w = System.IO.File.AppendText("C:\\temp\\log.txt"))
            {
                log.LogToFile("Test", w);
            }
        }

        public ActionResult GenericError()
        {
            throw new DivideByZeroException();

        }

    }
}