using ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        Shop db = new Shop();
        public List<SanPham> Get_list(int id)
        {
            var listSPById = db.SanPhams.Where(x=>(x.MaNCC==id || x.MaDM==id)).ToList();
            return listSPById;
        }
    }
}