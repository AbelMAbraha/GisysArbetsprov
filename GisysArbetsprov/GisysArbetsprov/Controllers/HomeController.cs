using GisysArbetsprov.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GisysArbetsprov.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {          
            return View();
        }
        public JsonResult GetConsultants()
        {
            var BonusPott = 5000;
            ConsultInformation consult = new ConsultInformation();
            List<ConsultInformation> list = new List<ConsultInformation>();
            var consultants = db.ConsultInformations.ToList();
            foreach (var item in consultants)
            {
                var editUser = db.ConsultInformations.Find(item.Id);
                if ((DateTime.Now - item.YearsOfEmployment).TotalDays < 365)
                {
                    editUser.Bonus = 0;
                }
                else
                {
                    editUser.Bonus = Convert.ToInt32(BonusPott * (((((DateTime.Now.Year - item.YearsOfEmployment.Year) / 10m) + 1) * item.Hours) / CreditPoint()));
                }
                db.Entry(editUser).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(consultants, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Index(ConsultInformation consInfo)
        {
            db.ConsultInformations.Add(new ConsultInformation { Name = consInfo.Name, Hours = consInfo.Hours, YearsOfEmployment = Convert.ToDateTime(consInfo.YearsOfEmployment.ToString("yyyy-MM-dd")) });
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.ConsultInformations.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(ConsultInformation consInfo)
        {
            var editConsultant = db.ConsultInformations.Find(consInfo.Id);
            editConsultant.Hours = consInfo.Hours;
            editConsultant.Name = consInfo.Name;
            editConsultant.YearsOfEmployment = Convert.ToDateTime(consInfo.YearsOfEmployment.ToString("yyyy-MM-dd"));
            db.Entry(editConsultant).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deleteConsultant = db.ConsultInformations.Find(id);
            db.ConsultInformations.Remove(deleteConsultant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public decimal CreditPoint()
        {
            decimal creditPoint = 0;
            var consultants = db.ConsultInformations.ToList();
            foreach (var item in consultants)
            {
                if ((DateTime.Now - item.YearsOfEmployment).TotalDays < 365)
                {
                    //creditPoint += item.Hours;
                }
                else
                {
                    creditPoint += (((DateTime.Now.Year - item.YearsOfEmployment.Year) / 10m) + 1) * item.Hours;
                }
            }
            return decimal.Truncate(creditPoint);
        }
    }
}