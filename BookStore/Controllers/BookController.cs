using BookStore.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        BookContext db2 = new BookContext();
        public ActionResult BookIndex()
        {
            List<Book> books = db2.Books.Include("Author").ToList();
            ViewBag.Books = books;
            return View();
        }

        [HttpPost]
        public ActionResult LoadUp(Book book)
        {
            var books = db2.Books.Where(a => a.Name.Equals(book.Name) && a.Author.Name.Equals(book.Author.Name)).FirstOrDefault();
            if (books != null) 
            {
                return RedirectToRoute(new { controller = "Book", action = "BookIndex" });
            }

            Author author = db2.Authors.Where(a => a.Name.Equals(book.Author.Name)).FirstOrDefault();
            if (author != null)
            {
                book.Author = author;
            }

            db2.Books.Add(book);
            db2.SaveChanges();
            return RedirectToRoute(new { controller = "Book", action = "BookIndex" });
        }

        public ActionResult AuthorIndex()
        {
            List<Author> authors = db2.Authors.ToList();
            ViewBag.Author = authors;
            return View();
        }
        
    }
}