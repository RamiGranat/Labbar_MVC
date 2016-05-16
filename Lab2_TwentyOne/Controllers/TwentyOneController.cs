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

        int num = 0;
        int sum = 0;

        public ActionResult Game()
        {
            bool tryParse = int.TryParse(Request["text1"], out num);
            if (tryParse && num <= 2 && num > 0 && numberModel.num <= 21)
            {

                numberModel.num += num;
                if (numberModel.num == 21)
                {
                    ViewBag.Message = "You won";
                    numberModel.num = 0;
                }
                else if (numberModel.num > 21)
                {
                    ViewBag.Message = "You lost";
                }
                ViewBag.number = numberModel.num;


            }
            else
            {
                ViewBag.Message = "not valid data";
                ViewBag.number = numberModel.num = 0;
            }

            Random rnd = new Random();
            int computerNumber = rnd.Next(1, 2);
            numberModel.num += computerNumber;
            ViewBag.Message = "Datorn skrev:" + computerNumber.ToString();

            if (numberModel.num == 21)
            {
                ViewBag.Message = "Datorn förlorade";
                numberModel.num = 0;
            }
            return View();
        }
    }
}