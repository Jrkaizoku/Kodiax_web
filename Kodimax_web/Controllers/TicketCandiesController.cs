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
    public class TicketCandiesController : Controller
    {
        private KodimaxContext db = new KodimaxContext();

        // GET: TicketCandies
        public ActionResult Index()
        {
            var ticketCandy = db.TicketCandy.Include(t => t.Candy);
            return View(ticketCandy.ToList());
        }

        // GET: TicketCandies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketCandy ticketCandy = db.TicketCandy.Find(id);
            if (ticketCandy == null)
            {
                return HttpNotFound();
            }
            return View(ticketCandy);
        }

        // GET: TicketCandies/Create
        public ActionResult Create()
        {
            ViewBag.id_ticket_candy = new SelectList(db.Candy, "id_candy", "name");
            return View();
        }

        // POST: TicketCandies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ticket_candy,id_candy,total")] TicketCandy ticketCandy)
        {
            if (ModelState.IsValid)
            {
                db.TicketCandy.Add(ticketCandy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_ticket_candy = new SelectList(db.Candy, "id_candy", "name", ticketCandy.id_ticket_candy);
            return View(ticketCandy);
        }

        // GET: TicketCandies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketCandy ticketCandy = db.TicketCandy.Find(id);
            if (ticketCandy == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_ticket_candy = new SelectList(db.Candy, "id_candy", "name", ticketCandy.id_ticket_candy);
            return View(ticketCandy);
        }

        // POST: TicketCandies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ticket_candy,id_candy,total")] TicketCandy ticketCandy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketCandy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_ticket_candy = new SelectList(db.Candy, "id_candy", "name", ticketCandy.id_ticket_candy);
            return View(ticketCandy);
        }

        // GET: TicketCandies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketCandy ticketCandy = db.TicketCandy.Find(id);
            if (ticketCandy == null)
            {
                return HttpNotFound();
            }
            return View(ticketCandy);
        }

        // POST: TicketCandies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketCandy ticketCandy = db.TicketCandy.Find(id);
            db.TicketCandy.Remove(ticketCandy);
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
