using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SheinMagistracy.Data;
using SheinMagistracy.Models;
using System.Collections.Generic;
using System.Linq;

namespace SheinMagistracy.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExerciseController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Exercise> exerciseList = _db.Exercise;

            foreach(var obj in  exerciseList)
            {
                obj.Subject = _db.Subject.FirstOrDefault(u => u.Id == obj.SubjectId);
            }

            return View(exerciseList);
        }
    }
}
