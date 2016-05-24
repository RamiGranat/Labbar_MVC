using Lab4._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4._1.Controllers
{
    public class TwentyOneAjaxController : Controller
    {
        // GET: TwentyOneAjax
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Game()
        {
            TwentyOneAjaxModel.CurrentNumber = 0;
            TwentyOneAjaxModel.SetStartPlayer();
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
            ViewBag.result= TwentyOneAjaxModel.ErroMessage("You must choose an option!");
            return View();
        }
    }
}