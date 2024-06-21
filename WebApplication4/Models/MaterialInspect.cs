using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class MaterialInspect
    {
        string itemCode,itemName,serialNumber,comments,status,cardCode,paramCode,blockReason,firstName, middleName,lastName, expDate,ni,pas,justify;
        decimal quantity, sampleQty;
        int id, invoice, docEntry, lineNum, empId;
        DateTime dateRelease;
      

        public string ItemCode { get => itemCode; set => itemCode = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public string Comments { get => comments; set => comments = value; }
        public string Status { get => status; set => status = value; }
        public string CardCode { get => cardCode; set => cardCode = value; }
        public string ParamCode { get => paramCode; set => paramCode = value; }
        public string BlockReason { get => blockReason; set => blockReason = value; }
        public decimal Quantity { get => quantity; set => quantity = value; }
        public int Id { get => id; set => id = value; }
        public int Invoice { get => invoice; set => invoice = value; }
        public int DocEntry { get => docEntry; set => docEntry = value; }
        public int LineNum { get => lineNum; set => lineNum = value; }
        
     
    
        public string MiddleName { get => middleName; set => middleName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int EmpId { get => empId; set => empId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public DateTime DateRelease { get => dateRelease; set => dateRelease = value; }
        public string ExpDate { get => expDate; set => expDate = value; }
        public decimal SampleQty { get => sampleQty; set => sampleQty = value; }
        public string Ni { get => ni; set => ni = value; }
        public string Pas { get => pas; set => pas = value; }
        public string Justify { get => justify; set => justify = value; }
    }
}
