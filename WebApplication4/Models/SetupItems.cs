using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class SetupItems
    {
        int id;
        string itemCode;
        string batchNum;
        double quantity;
        int posId;
        int idRgSetup;

        public int Id { get => id; set => id = value; }
        public string ItemCode { get => itemCode; set => itemCode = value; }
        public string BatchNum { get => batchNum; set => batchNum = value; }
        public double Quantity { get => quantity; set => quantity = value; }
        public int PosId { get => posId; set => posId = value; }
        public int IdRgSetup { get => idRgSetup; set => idRgSetup = value; }
    }
    
}
