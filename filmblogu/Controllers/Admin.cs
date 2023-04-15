using System;
using Microsoft.AspNetCore.Mvc;

namespace filmblogu.Controllers;

public class Admin
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Panel()
    {
        return View();
    }

    public IActionResult Guncelle()
    {
        return View();
    }
}

