using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class ProductionTool
    {
        int id;
        string toolCod;
        string dscription;
        Int16 department;
        string sttsMntnance;

        public int Id { get => id; set => id = value; }
        public string ToolCod { get => toolCod; set => toolCod = value; }
        public string Dscription { get => dscription; set => dscription = value; }
        public Int16 Department { get => department; set => department = value; }
        public string SttsMntnance { get => sttsMntnance; set => sttsMntnance = value; }
    }
}
