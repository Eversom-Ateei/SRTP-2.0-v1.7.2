using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class User
    {
        int empID;
        string firstName;
        string middleName;
        string lastName;

        public string FirstName { get => firstName; set => firstName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int EmpID { get => empID; set => empID = value; }
    }
}