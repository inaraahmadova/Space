﻿using Microsoft.AspNetCore.Mvc;

namespace SpaceWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
