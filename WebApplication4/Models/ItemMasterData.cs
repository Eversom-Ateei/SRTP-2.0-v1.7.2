using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class ItemMasterData
    {
        string itemCode, itemName, comments, firmName, partNumber, posId, manSerNum, manBtchNum;

        public string ItemCode { get => itemCode; set => itemCode = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public string Comments { get => comments; set => comments = value; }
        public string FirmName { get => firmName; set => firmName = value; }
        public string PartNumber { get => partNumber; set => partNumber = value; }
        public string PosId { get => posId; set => posId = value; }
        public string ManSerNum { get => manSerNum; set => manSerNum = value; }
        public string ManBtchNum { get => manBtchNum; set => manBtchNum = value; }
    }
}
