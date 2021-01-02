using ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        dbContext db = new dbContext();
        private const string CartSession = "CartSession";
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(long spId,int tong)
        {
            var sp = new SanPham();
            sp = db.SanPhams.FirstOrDefault(x => x.ID == spId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.SanPham.ID == spId))
                {
                    foreach(var item in list)
                    {
                        if (item.SanPham.ID == spId)
                        {
                            item.Tong += tong;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.SanPham = sp;
                    item.Tong = tong;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.SanPham = sp;
                item.Tong = tong;
                var list = new List<CartItem>();
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
    }
}