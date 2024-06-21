using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class ReceiptOfGoods
    {
        int docEntry, invoice;
        string cardName,firstName;
        DateTime docDate;
        

        public int DocEntry { get => docEntry; set => docEntry = value; }
        public int Invoice { get => invoice; set => invoice = value; }
        public string CardName { get => cardName; set => cardName = value; }
    
        public DateTime DocDate { get => docDate; set => docDate = value; }
        public string FirstName { get => firstName; set => firstName = value; }
    }
}
