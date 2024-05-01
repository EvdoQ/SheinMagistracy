using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SheinMagistracy.Data;
using SheinMagistracy.Models;
using SheinMagistracy.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SheinMagistracy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            Exercise exercise = _db.Exercise.Include(u => u.Subject).OrderBy(u => u.Deadline).FirstOrDefault();
            return View(exercise);
        }

        public IActionResult Details()
        {
            Exercise exercise = _db.Exercise.Include(u => u.Subject).OrderBy(u => u.Deadline).FirstOrDefault();
            return View(exercise);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
