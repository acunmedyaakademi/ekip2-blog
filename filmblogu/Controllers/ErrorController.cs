﻿using Microsoft.AspNetCore.Mvc;

namespace filmblog.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
