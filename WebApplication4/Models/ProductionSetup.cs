using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class ProductionSetup
    {
        int id, docEntry,createdByUser;
        string resource;
        DateTime startDate, endDate;     
        double compltQty;

        public int Id { get => id; set => id = value; }
        public int DocEntry { get => docEntry; set => docEntry = value; }
        public int CreatedByUser { get => createdByUser; set => createdByUser = value; }
        public string Resource { get => resource; set => resource = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        [Column(TypeName = "decimal(19,6)")]
        public double CompltQty { get => compltQty; set => compltQty = value; }
     

    }
}
