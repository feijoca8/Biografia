﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biografia.Controllers
{
    public class ExperienciaProfissional : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
