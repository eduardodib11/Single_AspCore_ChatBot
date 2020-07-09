﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using chatbot.Models;

namespace chatbot.Controllers
{
    public class HomeController : Controller
    {
        private readonly MemDbContext _context;

        public HomeController(MemDbContext memDbContext)
        {
            _context = memDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            cModel _model = new cModel();
            return View(_model);
        }

        [HttpPost]
        public IActionResult Index(cModel _model)
        {
            var _message = _context.Messages.FirstOrDefault(m => m.Question == _model.Input.ToUpper());

            if(_message != null)
            {
                _model.Textarea += "\n" + _message.Answer;
            }

            return View(_model);
        }

        public IActionResult Privacy(){
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
