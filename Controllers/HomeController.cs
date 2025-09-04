using CrudProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudProjectOne.Controllers
{
    public class HomeController : Controller
    {
        private readonly CandidateDbContext context=new CandidateDbContext();
        public ActionResult Index()
        {
            List<CandidateDbModel> list =context.GetCandidateData();
            return View(list);

        }

        public ActionResult AddData()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddData(CandidateDbModel candidateDb)
        {
            if (ModelState.IsValid)
            {
                context.AddCandidate(candidateDb);
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }

        }

        public ActionResult Update(int id)
        {
            List<CandidateDbModel> candidateList =context.GetCandidateData();

            var row = candidateList.FirstOrDefault(c => c.Id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Update(CandidateDbModel dbModel,int id)
        {
            if(ModelState.IsValid)
            {
                context.UpdateData(dbModel,id);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}