using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class ProductionSetupLine
    {
        int id , idAssemblyWorkOrder ;
 string paramCode, description, status, measurement, comments;

        public int Id { get => id; set => id = value; }
        public int IdAssemblyWorkOrder { get => idAssemblyWorkOrder; set => idAssemblyWorkOrder = value; }
        public string ParamCode { get => paramCode; set => paramCode = value; }
        public string Description { get => description; set => description = value; }
        public string Status { get => status; set => status = value; }
        public string Measurement { get => measurement; set => measurement = value; }
        public string Comments { get => comments; set => comments = value; }
    }
}
