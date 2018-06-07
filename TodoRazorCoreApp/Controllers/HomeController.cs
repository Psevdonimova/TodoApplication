using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoRazorCoreDomain.Context;
using TodoRazorCoreDomain.Helpers;
using TodoRazorCoreDomain.Models;

namespace TodoRazorCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskContext _context;
        static private int count = 0;

        public HomeController(ITaskContext context)
        {
            _context = context;
        }

        //[HttpGet]
        public IActionResult Index()
        {
            /*_context.AddNewTask(new Task()
            {
                Title = "Title",
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            });
            _context.AddNewTask(new Task()
            {
                Title = "Title",
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            });
            _context.AddNewTask(new Task()
            {
                Title = "Title",
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            });*/

            ViewBag.Tasks = _context.GetRange(count, 0);
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Task task)
        {
            count++;
            _context.AddNewTask(task);
            return View();
        }
    }
}
