using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class ProductInspect
    {
        int docEntry, timeRegisterID;
        string itemCode, itemName;
        DateTime endTimeRegister;
        decimal openQty ,quantity;

        public int DocEntry { get => docEntry; set => docEntry = value; }
        public int TimeRegisterID { get => timeRegisterID; set => timeRegisterID = value; }
        public string ItemCode { get => itemCode; set => itemCode = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public DateTime EndTimeRegister { get => endTimeRegister; set => endTimeRegister = value; }
        public decimal OpenQty { get => openQty; set => openQty = value; }
        public decimal Quantity { get => quantity; set => quantity = value; }
    }
}
