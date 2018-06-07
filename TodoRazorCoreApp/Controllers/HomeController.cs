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

        public HomeController(ITaskContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
