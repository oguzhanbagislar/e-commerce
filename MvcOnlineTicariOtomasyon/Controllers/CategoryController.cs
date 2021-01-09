using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Kategori

        Context db = new Context();
        public ActionResult Index()
        {
            var categoryList = db.Kategoris.ToList();
            return View(categoryList);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Kategori k)
        {
            db.Kategoris.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }        
        public ActionResult DeleteCategory(int id)
        {
            var category = db.Kategoris.Find(id);
            db.Kategoris.Remove(category);           
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var category = db.Kategoris.Find(id);
            return View("GetCategory",category);
        }
        public ActionResult UpdateCategory(Kategori k)
        {
            var category = db.Kategoris.Find(k.KategoriId);
            category.KategoriAd = k.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}