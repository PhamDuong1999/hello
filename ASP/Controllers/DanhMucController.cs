using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.Models;

namespace ASP.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
        Shop db = new Shop();
        public List<DanhMuc> Get_List(int id)
        {
            return db.DanhMucs.Where(x => x.ID == id).ToList();
        }
    }
}