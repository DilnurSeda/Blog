using _190410_BlogV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _190410_BlogV1.Areas.AdminPaneli.Controllers
{
    public class KategorilerController : Controller
    {
        Bloghi304DBEntities db = new Bloghi304DBEntities();

        // GET: AdminPaneli/Kategoriler
        public ActionResult KategorilerIndex()
        {
            return View(db.Kategoriler.ToList());
        }
        public ActionResult KategoriEkleIndex()
        {
            return View();
        }
        public ActionResult KategoriGuncelleIndex(int KategorilerID)
        {

            return View(KategoriBul(KategorilerID));
        }

        [HttpPost]
        public ActionResult KategoriEkleIndex(string KategoriAdi,string Aciklama)
        {
            KategoriEkle(KategoriAdi, Aciklama);
            return View();
        }
        
        public int KategoriEkle(string kategoriadi,string aciklama)
        {
            Kategoriler ekle = new Kategoriler();
            ekle.KategoriAdi = kategoriadi;
            ekle.Aciklama = aciklama;

            db.Kategoriler.Add(ekle);

            int sonuc = db.SaveChanges();
            if (sonuc>0)
            {
                return 1;
            }
            return 0;
        }
        [HttpPost]
        public ActionResult KategoriGuncelleIndex(int KategorilerID, string KategoriAdi, string Aciklama)
        {
            KategoriGuncelle(KategorilerID, KategoriAdi, Aciklama);
            return View();
        }

        public Kategoriler KategoriBul(int KategorilerID)
        {
            return db.Kategoriler.Where(k => k.KategorilerID == KategorilerID).FirstOrDefault();
        }

        public int KategoriGuncelle(int kategorilerid, string kategoriadi, string aciklama)
        {
            Kategoriler guncelle = db.Kategoriler.Where(k => k.KategorilerID == kategorilerid).FirstOrDefault();
            if (guncelle != null)
            {
                guncelle.KategorilerID = kategorilerid;
                guncelle.KategoriAdi = kategoriadi;
                guncelle.Aciklama = aciklama;

                int gncSonuc = db.SaveChanges();
                if (gncSonuc > 0)
                {
                    return 1;
                }
            }
            return 0;
        }





    }
}