using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Translator.Client.Models;
using Translator.Storing.Models;
using Translator.Storing.Repositories;

namespace Translator.Client.Controllers
{ 
  [Route("/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MessageRepository _mr = new MessageRepository();
        private readonly UserRepository _user = new UserRepository();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int userId)
        {
            ViewBag.UserId = userId;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MessageBoard()
        {
            //List<Message> allMessages = _mr.GetAllMessages();
            var userId = (int)HttpContext.Session.GetInt32("SessionKeyUserId");
            List<Message> allMessages = _user.GetAllMessagesTranslated(userId).Result;
            ViewBag.Messages = allMessages;
            return View();
        }
        [HttpPost]
        public IActionResult CreateMessage(MessageViewModel message)
        {
          if(ModelState.IsValid)
          {
            Message newMessage = new Message();
            newMessage.UserId = 1;
            newMessage.Content = message.Content;
            newMessage.MessageDateTime = DateTime.Now;
            _mr.Create(newMessage);
            return RedirectToAction("MessageBoard","Home");
          }
          return RedirectToAction("MessageBoard", "Home");
        }


        [HttpGet("{id}")]
        public IActionResult Message(int id)
        {
          ViewBag.MessageId = id;
          return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
