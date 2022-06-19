using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVC_CMS_App.Traits;
using MVC_CMS_App.Models;

namespace MVC_CMS_App
{
    public class PatientsController : Controller
    {
        DbConnection db = new DbConnection();
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePatient(Patients patient)
        {
            db.Patients.Add(patient);
            db.SaveChanges();
            return RedirectToAction("Index", "Patients");
        }
        [HttpPost]
        public bool Delete(int id){
            try
            {
                Patients patient = db.Patients.Where(s => s.Id == id).First();
                db.Patients.Remove(patient);
                db.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
            
        }
        public ActionResult Update(int id){
            //var doctors = db.Doctors.FromSqlRaw("SELECT * FROM dbo.Doctors").ToList();

            return View(db.Patients.Where(s => s.Id == id).First());
        }
        [HttpPost]
        public ActionResult UpdatePatient(Patients patient){
            Patients d = db.Patients.Where(s => s.Id == patient.Id).First();
            d.Name = patient.Name;
            d.Phone = patient.Phone;
            db.SaveChanges();
            return RedirectToAction("Index", "Patients");
        }
    }
}