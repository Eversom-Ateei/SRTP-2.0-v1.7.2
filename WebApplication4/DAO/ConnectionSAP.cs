
using Newtonsoft.Json;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.DAO
{
    public class ConnectionSAP
    {

        private static SAPbobsCOM.Company company;
        public static Company Connect()
        {
            try
            {
                 company = new SAPbobsCOM.Company();
                 
                 company.CompanyDB = Startup.cfs.GetSection("ConnectionSAP").GetSection("CompanyDB").Value;
                 company.DbServerType = BoDataServerTypes.dst_MSSQL2008;
                 company.Server = Startup.cfs.GetSection("ConnectionSAP").GetSection("Server").Value;
                 company.DbUserName = Startup.cfs.GetSection("ConnectionSAP").GetSection("DbUserName").Value; ;
                 company.DbPassword = Startup.cfs.GetSection("ConnectionSAP").GetSection("DbPassword").Value; ;
                 company.UserName = Startup.cfs.GetSection("ConnectionSAP").GetSection("UserName").Value; ;
                 company.Password = Startup.cfs.GetSection("ConnectionSAP").GetSection("Password").Value; ;
                 company.LicenseServer = Startup.cfs.GetSection("ConnectionSAP").GetSection("LicenseServer").Value; ;
                 company.UseTrusted = true;
                
                if(company.Connect() == 0)
                {
                }
                else
                {

                    company.Disconnect();
                }
              


                return company;
            }
            catch (Exception e)
            {

                return company;

            }
           
        }
    }
}
