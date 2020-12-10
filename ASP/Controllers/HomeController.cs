using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.Models;

namespace ASP.Controllers
{
    public class HomeController : Controller
    {
        dbContext db = new dbContext();   
        // GET: Home
        public ActionResult Index()
        {
            List<NhaCungCap> ncc = db.NhaCungCaps.ToList();
            List<SanPham> sp = db.SanPhams.ToList();  
            List<SanPham> spSale = db.SanPhams.OrderByDescending(x=>x.Sale).Take(8).ToList();
            ViewBag.sp = sp;
            ViewBag.spSale = spSale;
            return View("Home",ncc);
        }
        public ActionResult Header()
        {
            List<NhaCungCap> ncc = db.NhaCungCaps.ToList();
            List<DanhMuc> dm = db.DanhMucs.ToList();
            ViewBag.dm = dm;
            return View(ncc);
        }
        public ActionResult Detail(int id)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.ID == id);
            List<SanPham> listSP = db.SanPhams.Where(x => (x.MaNCC == sp.MaNCC && x.ID!=id)).ToList();
            NhaCungCap ncc = db.NhaCungCaps.FirstOrDefault(x => x.ID == sp.MaNCC);
            DanhMuc dm = db.DanhMucs.FirstOrDefault(x => x.ID == sp.MaDM);
            ViewBag.ncc = ncc;
            ViewBag.dm = dm;
            ViewBag.sp = sp;
            ViewBag.listSP = listSP;
            return View();
        }
    }
}