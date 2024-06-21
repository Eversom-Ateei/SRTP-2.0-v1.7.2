using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication4.Controllers
{
    public class DashboardController : Controller
    {
        // GET: DashBoader
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LineChart()
        {
            return View();
        }
    }
}