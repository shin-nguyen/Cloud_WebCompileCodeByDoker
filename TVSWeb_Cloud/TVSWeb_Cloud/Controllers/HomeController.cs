using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TVSWeb_Cloud.Models;
using System.Data.Entity;
using TVSWeb_Cloud.Models.dtos;

namespace TVSWeb_Cloud.Controllers
{
    public class HomeController : Controller
    {
        private TVSContext _context;

        public HomeController()
        {
            _context = new TVSContext();
            CommandPrompt.ExecuteCommand("docker run --rm -it -d -v " + ConfigurationDocker.StoragePathInHost + ":" + ConfigurationDocker.StoragePathInContainer + " --name " + ConfigurationDocker.MonoContainerName  + " mono");
            CommandPrompt.ExecuteCommand("docker run --rm -it -d -v " + ConfigurationDocker.StoragePathInHost + ":" + ConfigurationDocker.StoragePathInContainer + " --name " + ConfigurationDocker.OpenjdkContainerName + " openjdk");


        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Choosejava()
        {
            List<Question> questions = _context.Questions.Where(q => q.Type.Name == "java").ToList();
            return View(questions);
        }
        public ActionResult Choosecsharp()
        {
            List<Question> questions = _context.Questions.Where(q => q.Type.Name == "c#").ToList();
            return View(questions);
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult CodeScreen(int questionID)
        {
            var question = this._context.Questions.Include(q => q.Type).SingleOrDefault(q => q.QuestionID == questionID);

            if (question == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return View(new QuestionDto(question));
        }
    }
}