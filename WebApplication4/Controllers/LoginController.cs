using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using WebApplication4.Context;
using WebApplication4.DAO;

using WebApplication4.Models;
using WebApplication4.Util;

namespace WebApplication4.Controllers
{
    public class LoginController : Controller
    {
        private TemplateContext _context;

        public LoginController(TemplateContext context)
        {

            _context = context;

        }



        // GET: Login
        public ActionResult Index()
        {
            
            return View();
        }
       
        public ActionResult Login(int id)
        {          
            User user = new User();
            List <User> users= new List<User>();
            var userInfo = new User();

            users =  _context.Users.FromSqlRaw("select empID, firstName, middleName, lastName from OHEM where empID ="+id+"").ToList();            

            foreach (User u in users)
            {
                userInfo.FirstName= u.FirstName;
                userInfo.EmpID = u.EmpID;
                HttpContext.Session.SetString("userName", u.FirstName);
                HttpContext.Session.SetInt32("user", u.EmpID);
                HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(userInfo));
                var userInfo2 = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));  
            }

            return View();
        }
        public void Logout()
        {

            HttpContext.Session.Remove("user");   

        }
        public ActionResult UserChats()
        {
                        
            List<User> userss = new List<User>();           

            userss = _context.Users.FromSqlRaw("select empID, firstName, middleName, lastName from OHEM").ToList();
            

            foreach (User us in userss.ToList())
            {
                
                userss.Add(us);
            }


            ViewBag.users = userss;


            return View();

        }



        public string ChatView(string user)
        {
            User userInfo2 = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
            
           

            return userInfo2.EmpID.ToString();
        }



    }
}