﻿using SCCBakery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCCBakery.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.AProduct.Take(5).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "SCC Bakery";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "SCC Bakery location";

            return View();
        }
    }
}