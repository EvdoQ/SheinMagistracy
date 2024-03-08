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
    }
}
