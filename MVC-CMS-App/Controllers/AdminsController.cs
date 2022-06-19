using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVC_CMS_App.Traits;
using MVC_CMS_App.Models;

namespace MVC_CMS_App
{
    public class AdminsController : Controller
    {
        DbConnection db = new DbConnection();
        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdmin(Admins admin)
        {
            db.Admins.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index", "Admins");
        }
        [HttpPost]
        public bool Delete(int id){
            try
            {
                Admins admin = db.Admins.Where(s => s.Id == id).First();
                db.Admins.Remove(admin);
                db.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }

        }
        public ActionResult Update(int id){
            return View(db.Admins.Where(s => s.Id == id).First());
        }
        [HttpPost]
        public ActionResult Updateadmin(Admins admin){
            Admins d = db.Admins.Where(s => s.Id == admin.Id).First();
            d.Name = admin.Name;
            d.Phone = admin.Phone;
            db.SaveChanges();
            return RedirectToAction("Index", "Admins");
        }
    }
}