using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace WebApplication4.Controllers
{
    public class PlanController : Controller
    {
        // GET: Plan
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HelloWorld()
        {

            List<string> ret = new List<string>();
            for (int i = 0; i < 100000; i++)
            {
                ret.Add("teste");
                ret.Add("tes236");
            }
            ViewBag.Message = "ssss";
            ViewBag.Table = ret;
           
            return View();
        }


        public void createtable()
        {
           
           
            
        }
    }
}