using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Context;
using WebApplication4.DAO;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private TemplateContext _context;
        public HomeController(TemplateContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
           ViewBag.Title = "Index";
            if (HttpContext.Session.GetString("user") == null)
            {
                ViewBag.userSession = "false";
            }
            else
            {
                ViewBag.userSession = HttpContext.Session.GetString("user").ToString();
                ViewBag.userName = HttpContext.Session.GetString("userName").ToString();
            }


            SQLConnection conn = new SQLConnection(_context);


           string sql = (" select top 5 t0.ORDEM,t1.ItemCode,t2.ItemName,t1.CardCode,upper(t3.CardName) as CardName,t1.Status,t1.PlannedQty,t1.CmpltQty, COUNT(*)as Workers " +
                         " from ATEEI_SRTP_RG_TEMPO t0 " +
                         " inner join OWOR t1 on t0.ORDEM = t1.DocEntry " +
                         " left join OITM t2 on t1.ItemCode = t2.ItemCode " +
                         " left join OCRD t3 on t3.CardCode = t1.CardCode " +
                         " where TERMINO is null "+
                         " group by t0.ORDEM, t1.ItemCode, t2.ItemName, t1.CardCode, t3.CardName, t1.Status,t1.PlannedQty,t1.CmpltQty order by Workers desc");



             ViewBag.TopOrdensList = conn.Connect(sql);

            ViewBag.sql = sql;



            return View();

            
        }

        public ActionResult Chat(string to ,string from)
        {


            ViewBag.to = to;
            ViewBag.from = from;

            return View();
        }



        /// <summary>
        /// generate Qrcode for printer 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="text"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public ActionResult QrCode(string width,string height,string text,string level)
        {

            ViewBag.w= width;
            ViewBag.h = height;
            ViewBag.text = text;
            ViewBag.level = level;

            return View();
        }







    }
}