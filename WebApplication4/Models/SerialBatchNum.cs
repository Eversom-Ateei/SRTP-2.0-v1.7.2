using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class SerialBatchNum
    {

        string batchNum;
        string uomCode;
        string uomName;
        decimal quantity;
        string itemCode;

        public string BatchNum { get => batchNum; set => batchNum = value; }
        public string UomCode { get => uomCode; set => uomCode = value; }
        public string UomName { get => uomName; set => uomName = value; }
        public decimal Quantity { get => quantity; set => quantity = value; }
        public string ItemCode { get => itemCode; set => itemCode = value; }
    }
}
