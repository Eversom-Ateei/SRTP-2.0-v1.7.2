using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Context;
using WebApplication4.DAO;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ProductionFlawController : Controller
    {
        private TemplateContext _context;

        public ProductionFlawController(TemplateContext context)
        {
            _context = context;
        }

        // GET: ProductionFlawController
        public ActionResult ProductionFlaw(string serialNumber,int docEntry,string resource,int posId)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                ViewBag.userSession = "false";
            }
            else
            {

                var userInfo2 = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));

                string user = userInfo2.EmpID.ToString();
                ViewBag.userSession = user;
                ViewBag.userName = userInfo2.FirstName;

                SQLConnection conn = new SQLConnection(_context);

                ViewBag.serial = serialNumber;
                ViewBag.docEntry = docEntry;
                ViewBag.resource = resource;
                ViewBag.posId = posId;

                var result = conn.Connect("SELECT * FROM ATEEI_SRTP_ProductionFlaw T0 LEFT JOIN OITM T1 ON T0.ItemCode = T1.ItemCode WHERE T0.SerialNumber = '" + serialNumber + "'");
                ViewBag.data = result;


            }

            return View();
        }

        
    }
}
