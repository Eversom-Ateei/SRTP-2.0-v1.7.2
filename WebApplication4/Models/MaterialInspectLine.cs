using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class MaterialInspectLine
    {
        int id, id_MaterialInspect, sampleNumber;
        string description, measurement, comments, status, reason, paramId, firstName, middleName, lastName, toolCod, mark, minimun, maximun;
        decimal blockQty, quantity, sampleQty;
        DateTime dateRelease;
        


        public string ParamId { get => paramId; set => paramId = value; }
        public string Description { get => description; set => description = value; }
        public string Measurement { get => measurement; set => measurement = value; }
        public string Comments { get => comments; set => comments = value; }
        public string Status { get => status; set => status = value; }
        public string Reason { get => reason; set => reason = value; }
        [Column(TypeName = "decimal(19,6)")]
        public decimal BlockQty { get => blockQty; set => blockQty = value; }
        [Column(TypeName = "decimal(19,6)")]
        public decimal Quantity { get => quantity; set => quantity = value; }
       
        public int Id_MaterialInspect { get => id_MaterialInspect; set => id_MaterialInspect = value; }
        public int Id { get => id; set => id = value; }
     
        public string MiddleName { get => middleName; set => middleName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public DateTime DateRelease { get => dateRelease; set => dateRelease = value; }
        public string ToolCod { get => toolCod; set => toolCod = value; }
        public int SampleNumber { get => sampleNumber; set => sampleNumber = value; }
        public string Mark { get => mark; set => mark = value; }
        public string Minimun { get => minimun; set => minimun = value; }
        public string Maximun { get => maximun; set => maximun = value; }
        public decimal SampleQty { get => sampleQty; set => sampleQty = value; }
    }
}
