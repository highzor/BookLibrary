using BookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HolderController : Controller
    {
        BookContext db = new BookContext();
        // GET: Holder
        public ActionResult HolderIndex()
        {
            List<Holder> holders = db.Holders.ToList();
            ViewBag.Holders = holders;
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Holder holder)
        {
            db.Holders.Add(holder);
            db.SaveChanges();
            return RedirectToRoute(new { controller = "Holder", action = "HolderIndex" });
        }
        
        public ActionResult Info(int holderId)
        {
            Holder holder = db.Holders.Find(holderId);
            var books = db.Books.Include("Holder").Include("Author").ToList();
            ViewBag.Holders = holder;
            ViewBag.Books = books;
            return View();
        }
    }
}