using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class RentController : Controller
    {
        BookContext db3 = new BookContext();
        public ActionResult RentIndex()
        {
            var books = db3.Books.Include("Author").Include("Holder").ToList();
            var holders = db3.Holders.ToList();
            ViewBag.Books = books;
            ViewBag.Holders = holders;
            return View();
        }

        [HttpPost]
        public ActionResult RentMethod(int bookId, int holderId, string act)
        {
            Holder holder = db3.Holders.Find(holderId);
            Book book = db3.Books.Where(b => b.BookId == bookId).Include("Holder").FirstOrDefault();
            switch (act)
            {
                case "Отправить":
                    book.Holder.Add(holder);
                    break;
                case "Удалить":
                    book.Holder.Remove(holder);
                    break;
            }
            db3.SaveChanges();
            return RedirectToRoute(new { controller = "Rent", action = "RentIndex" });
        }
    }
}