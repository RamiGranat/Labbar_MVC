using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Lab2_TwentyOne.Models;

namespace Lab2_TwentyOne.Controllers
{
    public class TwentyOneController : Controller
    {
        // GET: TwentyOne
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Game()
        {
            ViewBag.result = string.Empty;
            TwentyOneModel.CurrentNumber = 0;
            TwentyOneModel.SetStartPlayer();
            return View();
        }
        [HttpPost]
        public ActionResult Game(string buttonValue)
        {
            int choice;
            if (Request["choice"] != null)
            {
                choice = int.Parse(Request["choice"]);
                TwentyOneAjaxModel.CurrentNumber += choice;
                ViewBag.result = TwentyOneAjaxModel.HandleGameResults();
                return View();
            }
            else
                ViewBag.result = TwentyOneAjaxModel.ErroMessage("You must choose an option!");
            return View();
        }
    }
}
