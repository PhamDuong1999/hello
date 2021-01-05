using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.Models;
using PagedList;

namespace ASP.Controllers
{
    public class HomeController : Controller
    {
        dbContext db = new dbContext();
        // GET: Home
        public ActionResult Header()
        {
            List<NhaCungCap> ncc = db.NhaCungCaps.ToList();
            List<DanhMuc> dm = db.DanhMucs.ToList();
            ViewBag.dm = dm;
            return PartialView(ncc);

        }
        public ActionResult HomeBody()
        {
            List<NhaCungCap> ncc = db.NhaCungCaps.ToList();
            List<SanPham> sp = db.SanPhams.ToList();
            List<SanPham> spSale = db.SanPhams.OrderByDescending(x => x.Sale).Take(8).ToList();
            ViewBag.sp = sp;
            ViewBag.spSale = spSale;
            return PartialView("HomeBody", ncc);
        }
        public ActionResult Detail(int id)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.ID == id);
            List<SanPham> listSP = db.SanPhams.Where(x => (x.MaNCC == sp.MaNCC && x.ID != id)).ToList();
            NhaCungCap ncc = db.NhaCungCaps.FirstOrDefault(x => x.ID == sp.MaNCC);
            DanhMuc dm = db.DanhMucs.FirstOrDefault(x => x.ID == sp.MaDM);
            ViewBag.ncc = ncc;
            ViewBag.dm = dm;
            ViewBag.sp = sp;
            ViewBag.listSP = listSP;
            return PartialView("Detail");
        }
        public ActionResult ListSanPhamTH(int id, int op = -1, int page = 1,int pageSize=8)
        {
            List<SanPham> ListSP = new List<SanPham>();
            if (op == -1)
            {
                ListSP = db.SanPhams.Where(x =>x.MaNCC == id).ToList();
            }
            if (op == 1)
            {
                ListSP = db.SanPhams.Where(x => (x.DonGia*(100-x.Sale)/100 < 1000000) && x.MaNCC == id).ToList();
            }
            if (op == 2)
            {
                ListSP = db.SanPhams.Where(x => (x.DonGia*(100-x.Sale)/100 >= 1000000 && x.DonGia * (100-x.Sale) / 100 < 3000000) && x.MaNCC == id).ToList();
            }
            if (op == 3)
            {
                ListSP = db.SanPhams.Where(x => (x.DonGia * (100-x.Sale) / 100 >= 3000000 && x.DonGia * (100-x.Sale) / 100 < 5000000) && x.MaNCC == id).ToList();
            }
            if (op == 4)
            {
                ListSP = db.SanPhams.Where(x => (x.DonGia * (100-x.Sale) / 100 >= 5000000 && x.DonGia * (100 - x.Sale) / 100 < 7000000) && x.MaNCC == id).ToList();
            }
            if (op == 5)
            {
                ListSP = db.SanPhams.Where(x => (x.DonGia * (100 - x.Sale) / 100 >= 7000000) &&x.MaNCC == id).ToList();
            }
            NhaCungCap ncc = db.NhaCungCaps.FirstOrDefault(x => x.ID == id);
            ViewBag.id = id;
            ViewBag.ncc = ncc;
            ViewBag.listSP = ListSP;
            return PartialView("ListSanPhamTH",ListSP.ToPagedList(page,pageSize));
        }
        public ActionResult ListSanPhamDM(int id,int op=-1, int page = 1, int pageSize = 1)
        {
            List<SanPham> ListSP = null;
            if (op == -1)
            {
                ListSP = db.SanPhams.Where(x => x.MaDM == id).ToList();
            }
            if (op == 1)
            {
                ListSP = db.SanPhams.Where(x => (x.DonGia * (100 - x.Sale) / 100 < 1000000) && x.MaDM == id).ToList();
            }
            if (op == 2)
            {
                ListSP = db.SanPhams.Where(x => (x.DonGia * (100 - x.Sale) / 100 >= 1000000 && x.DonGia * (100 - x.Sale) / 100 < 3000000) && x.MaDM == id).ToList();
            }
            if (op == 3)
            {
                ListSP = db.SanPhams.Where(x => (x.DonGia * (100 - x.Sale) / 100 >= 3000000 && x.DonGia * (100 - x.Sale) / 100 < 5000000) && x.MaDM == id).ToList();
            }
            if (op == 4)
            {
                ListSP = db.SanPhams.Where(x => (x.DonGia * (100 - x.Sale) / 100 >= 5000000 && x.DonGia * (100 - x.Sale) / 100 < 7000000) && x.MaDM == id).ToList();
            }
            if (op == 5)
            {
                ListSP = db.SanPhams.Where(x => (x.DonGia * (100 - x.Sale)/100 >= 7000000) && x.MaDM == id).ToList();
            }
            DanhMuc dm = db.DanhMucs.FirstOrDefault(x => x.ID == id);
            ViewBag.dm = dm;
            ViewBag.id = id;
            return PartialView("ListSanPhamDM", ListSP.ToPagedList(page, pageSize));
        }
        public ActionResult Search(string key,int op=-1, int page = 1, int pageSize = 8)
        {
            List<SanPham> ListSP = null;
            if (op == -1)
            {
                ListSP = db.SanPhams.Where(x => x.TenSP.ToLower().Contains(key.ToLower().Trim())).ToList();
            }
            if (op == 1)
            {
                ListSP = db.SanPhams.Where(x => (x.DonGia * (100 - x.Sale) / 100 < 1000000) && x.TenSP.ToLower().Contains(key.ToLower().Trim())).ToList();
            }
            if (op == 2)
            {
                ListSP = db.SanPhams.Where(x => (x.DonGia * (100 - x.Sale) / 100 >= 1000000 && x.DonGia * (100 - x.Sale) / 100 < 3000000) && x.TenSP.ToLower().Contains(key.ToLower().Trim())).ToList();
            }
            if (op == 3)
            {
                ListSP = db.SanPhams.Where(x => (x.DonGia * (100 - x.Sale) / 100 >= 3000000 && x.DonGia * (100 - x.Sale) / 100 < 5000000) && x.TenSP.ToLower().Contains(key.ToLower().Trim())).ToList();
            }
            if (op == 4)
            {
                ListSP = db.SanPhams.Where(x => (x.DonGia * (100 - x.Sale) / 100 >= 5000000 && x.DonGia * (100 - x.Sale) / 100 < 7000000) && x.TenSP.ToLower().Contains(key.ToLower().Trim())).ToList();
            }
            if (op == 5)
            {
                ListSP = db.SanPhams.Where(x => (x.DonGia * (100 - x.Sale) / 100 >= 7000000) && x.TenSP.ToLower().Contains(key.ToLower().Trim())).ToList();
            }
            ViewBag.Key = key;
            ViewBag.ListSP = ListSP;
            return PartialView("ListSanPham");
        }
        private const string CartSession = "CartSession";
        public ActionResult GioHang()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(int spId, int sl)
        {
            var sp = new SanPham();
            sp = db.SanPhams.FirstOrDefault(x => x.ID == spId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.SanPham.ID == spId))
                {
                    foreach (var item in list)
                    {
                        if (item.SanPham.ID == spId)
                        {
                            item.Sl += sl;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.SanPham = sp;
                    item.Sl = sl;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.SanPham = sp;
                item.Sl = sl;
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("GioHang");
        }
    }
}