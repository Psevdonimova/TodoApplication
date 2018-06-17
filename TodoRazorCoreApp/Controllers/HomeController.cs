using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoRazorCoreDomain.Context;
using TodoRazorCoreDomain.Helpers;
using TodoRazorCoreDomain.Models;
using TodoRazorCoreDomain.DTOs;

namespace TodoRazorCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskContext _context;
        private readonly IAutoMapper _autoMapper;
        static private int count = 0;
        static private int currentPage = 1;
        static private int pages = 1;
        static private int take = 0;
        const int skip = 3;
        static private int new_skip = 0;

        public HomeController(ITaskContext context, IAutoMapper autoMapper)
        {
            _context = context;
            _autoMapper = autoMapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CancelTask(int id)
        {
            _context.Get(id).TaskStatus = Status.Cancelled;
            ViewBag.Tasks = _context.GetRange(take, new_skip);
            return View("Index");
        }

        public IActionResult StartTask(int id)
        {
            _context.Get(id).TaskStatus = Status.Active;
            ViewBag.Tasks = _context.GetRange(take, new_skip);
            return View("Index");
        }

        public IActionResult CompleteTask(int id)
        {
            _context.Get(id).TaskStatus = Status.Completed;
            ViewBag.Tasks = _context.GetRange(take, new_skip);
            return View("Index");
        }

        public IActionResult ChangePage(int direction)
        {
            if (direction == -1 && pages > 1 && currentPage > 1)
            {
                currentPage--;
                take = skip;
            }
            else if (direction == 1 && pages > 1 && currentPage < pages)
            {
                currentPage++;
                if (currentPage == pages)
                {
                    take = pages * skip == count ? skip : (skip - (pages * skip - count));
                }
                else
                {
                    take = skip;
                }
            }
            new_skip = (currentPage - 1) * skip;
            ViewBag.Tasks = _context.GetRange(take, new_skip);
            return View("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                if (task.StartDate.Value > task.EndDate.Value)
                {
                    ModelState.AddModelError("EndgtStart", "Date of End can't be earlier, then date of Start");
                    return View();
                }
                count++;
                _context.AddNewTask(task);
                if ((count - 1) % skip == 0 && count > skip)
                {
                    pages = (count - 1) / skip + 1;
                }
                take = pages * skip == count ? skip : (skip - (pages * skip - count));
                new_skip = (pages - 1) * skip;
                currentPage = pages;
                ViewBag.Tasks = _context.GetRange(take, new_skip);
                return View("Index");
                }
                return View();
        }

        public IActionResult Update(int id)
        {
            //var dto = _autoMapper.MapToDTO(_context.Get(id));
            ViewBag.Task = _context.Get(id);
            return View(_context.Get(id));
        }

        [HttpPost]
        public IActionResult Update(Task task)
        {
            if (ModelState.IsValid)
            {
                var id = _context.Update(task);
                _context.AddNewTask(task);
                _context.Delete(id);
                /*var dto = _autoMapper.MapToDTO(task);
                _context.Delete(task.Id);
                _context.AddNewTask(dto);*/
                take = pages * skip == count ? skip : (skip - (pages * skip - count));
                new_skip = (pages - 1) * skip;
                currentPage = pages;
                ViewBag.Tasks = _context.GetRange(take, new_skip);
                return View("Index");
            }
            else
                return Update(task.Id);
        }
    }
}
//<span style='padding-left: 205px;'> </span>   
