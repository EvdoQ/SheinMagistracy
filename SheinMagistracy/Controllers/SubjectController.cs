using Microsoft.AspNetCore.Mvc;
using SheinMagistracy.Data;
using SheinMagistracy.Models;
using System.Collections;
using System.Collections.Generic;

namespace SheinMagistracy.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SubjectController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Subject> objList = _db.Subject;

            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subject subject) 
        { 
            if(ModelState.IsValid)
            {
                _db.Subject.Add(subject);
                _db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(subject);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
                return NotFound();

            var subject = _db.Subject.Find(id);
            if(subject == null)
                return NotFound();

            return View(subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _db.Subject.Update(subject);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var subject = _db.Subject.Find(id);
            if (subject == null)
                return NotFound();

            return View(subject);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var subject = _db.Subject.Find(id);
            if (subject == null)
                return NotFound();
            _db.Subject.Remove(subject);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
