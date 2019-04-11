using _190410_BlogV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _190410_BlogV1.Areas.AdminPaneli.Controllers
{
    public class EtiketlerController : Controller
    {

        Bloghi304DBEntities db = new Bloghi304DBEntities();

        // GET: AdminPaneli/Etiketler
        public ActionResult EtiketlerIndex()
        {
            return View(db.Etiketler.ToList());
        }
        public ActionResult EtiketEkleIndex()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult EtiketEkleIndex(string EtiketAdi)
        {
            EtiketEkle(EtiketAdi);
            return View();
        }

        public int EtiketEkle(string etiketadi)
        {
            Etiketler ekle = new Etiketler();
            ekle.EtiketAdi = etiketadi;

            db.Etiketler.Add(ekle);

            int sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}