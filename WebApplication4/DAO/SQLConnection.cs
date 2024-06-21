using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Web;
using WebApplication4.Context;

namespace WebApplication4.DAO
{
    public class SQLConnection
    {
        private TemplateContext _context;
        public SQLConnection(TemplateContext context)
        {

            _context = context;

        }

            public System.Data.Common.DbDataReader Connect(string query)
            {
            System.Data.Common.DbDataReader res = null;
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();

                command.CommandText = query;

                if (_context.Database.GetDbConnection().State == ConnectionState.Open)
                {
                }
                else
                {
                    _context.Database.OpenConnection();
                }

                 res = command.ExecuteReader();

              
            }
            catch(Exception e)
            {
                Console.WriteLine(query);
            }
            return res;
               
            }
        

        public  void SqlNonQuery(string commandSql)
        {
            _context.Database.SetCommandTimeout(600);
            _context.Database.CloseConnection();
            _context.Database.OpenConnection();
            _context.Database.ExecuteSqlCommand(commandSql);

            _context.Database.CloseConnection();

        }
        public void CloseConnection()
        {
            _context.Database.GetDbConnection().CreateCommand().Cancel();
        }
    }
}