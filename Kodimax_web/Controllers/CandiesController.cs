using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kodimax_web.Models;

namespace Kodimax_web.Controllers
{
    public class CandiesController : Controller
    {
        private KodimaxContext db = new KodimaxContext();

        // GET: Candies
        public ActionResult Index()
        {
            var candy = db.Candy.Include(c => c.TicketCandy);
            return View(candy.ToList());
        }

        // GET: Candies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candy candy = db.Candy.Find(id);
            if (candy == null)
            {
                return HttpNotFound();
            }
            return View(candy);
        }

        // GET: Candies/Create
        public ActionResult Create()
        {
            ViewBag.id_candy = new SelectList(db.TicketCandy, "id_ticket_candy", "id_ticket_candy");
            return View();
        }

        // POST: Candies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_candy,name,type,price")] Candy candy)
        {
            if (ModelState.IsValid)
            {
                db.Candy.Add(candy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_candy = new SelectList(db.TicketCandy, "id_ticket_candy", "id_ticket_candy", candy.id_candy);
            return View(candy);
        }

        // GET: Candies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candy candy = db.Candy.Find(id);
            if (candy == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_candy = new SelectList(db.TicketCandy, "id_ticket_candy", "id_ticket_candy", candy.id_candy);
            return View(candy);
        }

        // POST: Candies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_candy,name,type,price")] Candy candy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_candy = new SelectList(db.TicketCandy, "id_ticket_candy", "id_ticket_candy", candy.id_candy);
            return View(candy);
        }

        // GET: Candies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candy candy = db.Candy.Find(id);
            if (candy == null)
            {
                return HttpNotFound();
            }
            return View(candy);
        }

        // POST: Candies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candy candy = db.Candy.Find(id);
            db.Candy.Remove(candy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
