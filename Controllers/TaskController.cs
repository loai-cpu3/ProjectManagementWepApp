﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
       
    }
}
