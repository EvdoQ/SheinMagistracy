using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SheinMagistracy.Data;
using SheinMagistracy.Models;
using SheinMagistracy.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
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

        // GET
        public IActionResult Upsert(int? id)
        {
            ExerciseVM exerciseVM = new ExerciseVM()
            {
                Exercise = new Exercise(),
                SubjectSelectList = _db.Subject.Select(i => new SelectListItem
                { 
                    Text = i.SubjectName,
                    Value = i.Id.ToString()
                })
            };

            if (id == null)
            {
                //добавление
                return View(exerciseVM);
            }
            else
            {
                //обновление
                exerciseVM.Exercise = _db.Exercise.Find(id);
                if(exerciseVM.Exercise == null)
                {
                    return NotFound();
                }
                return View(exerciseVM);
            }
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ExerciseVM exerciseVM)
        {
            if(ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;
                if(exerciseVM.Exercise.Id == 0)
                {
                    //добавление
                    if (files.Count != 0)
                    {
                        string upload = webRootPath + WC.ImagePath;
                        string fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);

                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        exerciseVM.Exercise.Image = fileName + extension;
                    }
                    else
                    {
                        exerciseVM.Exercise.Image = null;
                    }
                    _db.Exercise.Add(exerciseVM.Exercise);
                }
                else
                {
                    //обновление
                    var exerciseFromDb = _db.Exercise.AsNoTracking().FirstOrDefault(u => u.Id ==  exerciseVM.Exercise.Id);
                    if (files.Count > 0 && exerciseFromDb.Image != null)
                    {
                        string upload = webRootPath + WC.ImagePath;
                        string fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);
                        var oldFile = Path.Combine(upload, exerciseFromDb.Image);
                        if (System.IO.File.Exists(oldFile))
                        {
                            System.IO.File.Delete(oldFile);
                        }
                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        exerciseVM.Exercise.Image = fileName + extension;
                    }
                    else
                    {
                        exerciseVM.Exercise.Image = exerciseFromDb.Image;
                    }
                    _db.Exercise.Update(exerciseVM.Exercise);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            exerciseVM.SubjectSelectList = _db.Subject.Select(i => new SelectListItem
            {
                Text = i.SubjectName,
                Value = i.Id.ToString()
            });

            return View(exerciseVM);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            // Жадная загрузка
            Exercise product = _db.Exercise.Include(u => u.Subject).FirstOrDefault(u => u.Id == id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Exercise.Find(id);
            if (obj == null)
                return NotFound();
            string upload = _webHostEnvironment.WebRootPath + WC.ImagePath;
            if (obj.Image != null)
            {
                var oldFile = Path.Combine(upload, obj.Image);
                if (System.IO.File.Exists(oldFile))
                {
                    System.IO.File.Delete(oldFile);
                }
            }
            _db.Exercise.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    } 
}
