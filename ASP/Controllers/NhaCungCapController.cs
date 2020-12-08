using ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.Controllers
{
    public class NhaCungCapController : Controller
    {
        // GET: NhaCungCap
        Shop db = new Shop();
        public ActionResult Index()
        {
            return View();
        }
        public   List<NhaCungCap> Get_list()
        {
            return db.NhaCungCaps.ToList();
        }
    }
}