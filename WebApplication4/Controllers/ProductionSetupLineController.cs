using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Context;
using WebApplication4.DAO;

namespace WebApplication4.Controllers
{
    public class ProductionSetupLineController : Controller
    {
        // GET: ProductionSetupLineController
        private TemplateContext _context;

        public ProductionSetupLineController(TemplateContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }        
       

    }
}
