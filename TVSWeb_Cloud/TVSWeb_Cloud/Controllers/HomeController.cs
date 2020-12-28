using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TVSWeb_Cloud.Models;

namespace TVSWeb_Cloud.Controllers
{
    public class HomeController : Controller
    {
        Cloud_TVSWebEntities db = new Cloud_TVSWebEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Choosejava()
        {
            List<Question> qs = db.Questions.OrderBy(x => x.qsId).ToList();
            Session["java"] = 1;
            return View(qs);
        }
        public ActionResult Choosecsharp()
        {
            List<Question> qs = db.Questions.OrderBy(x => x.qsId).ToList();
            Session["csharp"] = 1;
            return View(qs);
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult CodeScreen(int id)
        {
            var qs = new List<Question>();
            Question question = new Question();
            foreach( Question q in qs)
            {
                if(q.qsId==id)
                {
                    question = q;
                    break;
                }    
                if(question==null)
                {
                    return HttpNotFound();
                }
            }    
            if (Session["java"] == null && Session["csharp"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(question);
        }
    }
}