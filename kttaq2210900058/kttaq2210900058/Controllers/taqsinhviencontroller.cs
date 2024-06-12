using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using baiktragiuaki.Models;

namespace baiktragiuaki.Controllers
{
    public class taqSinhViensController : Controller
    {
        private QLDEntities db = new QLDEntities();

        // GET: taqSinhViens
        public ActionResult taqIndex()
        {
            var sinhVien = db.SinhVien.Include(s => s.Khoa);
            return View(sinhVien.ToList());
        }

        // GET: taqSinhViens/Details/5
        public ActionResult taqDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhVien.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: taqSinhViens/Create
        public ActionResult taqCreate()
        {
            ViewBag.MAKHOA = new SelectList(db.Khoa, "taqMAKHOA", "taqTENKHOA");
            return View();
        }

        // POST: taqSinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult taqCreate([Bind(Include = "taqMASV,taqHOSV,taqTENSV,taqPHAI,taqNS,taqMAKHOA")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.SinhVien.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAKHOA = new SelectList(db.Khoa, "htqMAKHOA", "taqTENKHOA", sinhVien.MAKHOA);
            return View(sinhVien);
        }

        // GET: taqSinhViens/Edit/5
        public ActionResult taqEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhVien.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAKHOA = new SelectList(db.Khoa, "taqMAKHOA", "taqTENKHOA", sinhVien.MAKHOA);
            return View(sinhVien);
        }

        // POST: taqSinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult taqEdit([Bind(Include = "htqMASV,taqHOSV,taqTENSV,taqPHAI,taqNS,taqMAKHOA")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;