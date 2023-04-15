﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using filmblog.Models;

namespace filmblog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Blog()
    {
        return View();
    }
    public IActionResult BlogArticle()
    {
        return View();
    }
    public IActionResult LightAbout()
    {
        return View();
    }
    public IActionResult LightBlog()
    {
        return View();
    }
    public IActionResult LightBlogArticle()
    {
        return View();
    }
    public IActionResult LightIndex()
    {
        return View();
    }
    public IActionResult LightContact()
    {
        return View();
    }
    public IActionResult Studio()
    {
        return View();
    }
    public IActionResult Team()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

