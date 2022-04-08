﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MusicPlaylist.Models;

namespace MusicPlaylist.Controllers;

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

    public IActionResult PlayList()
    {
        String token = Request.Cookies["token"];
        if (token == null)
        {
            return RedirectToAction("Index");
        }
        UserPlayLists userPlayLists = UserPlayLists.Instance;
        Playlist playlist = userPlayLists.GetPlayListByUserToken(token);
        if (playlist == null)
        {
            return RedirectToAction("Index");
        }
        return View(playlist);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}