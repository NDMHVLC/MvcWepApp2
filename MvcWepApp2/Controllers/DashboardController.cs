using MvcWepApp2.Core;
using MvcWepApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWepApp2.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [SessionControl]
        public ActionResult Index()
        {
            return View();            
        }
        public ActionResult RollCall()
        {
            DersProgrami dersProgrami = new DersProgrami();
            dersProgrami.OgretmenKodu = Session["Kullanici"].ToString();
            return View(dersProgrami.ListeGetir());
        }
        [HttpPost]
        public JsonResult OgrenciListesiGetir(int sinifId)
        {
            Ogrenci ogrenci = new Ogrenci();    
            ogrenci.SinifId = sinifId;
            return Json(ogrenci.OgrencileriGetirSinifId());            
        }
    }
}