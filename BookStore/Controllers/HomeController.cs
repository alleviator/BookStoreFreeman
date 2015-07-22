using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Util;


namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
		// создаем контекст данных
        BookContext db = new BookContext();

        public ActionResult Index()
        {
			// получаем из бд все объекты Book
            IEnumerable<Book> books = db.Books;
			// передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Books = books;
			// возвращаем представление
            return View();
        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет мир!</h2>");
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
    [HttpPost]
    public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Спасибо," + purchase.Person + ", за покупку!";
        }

    public DateTime getToday()
        {
            return DateTime.Now;
        }

    public string Square()
        {
            double a = Double.Parse(Request.Params["a"]);
            double h = Double.Parse(Request.Params["h"]);
            double s = a * h / 2;
            string output = String.Format("<h2>Площадь треугольника с основанием {0} и высотой {1} равна {2:G} </h2>",a,h,s);
            return output;
        }
    }
}