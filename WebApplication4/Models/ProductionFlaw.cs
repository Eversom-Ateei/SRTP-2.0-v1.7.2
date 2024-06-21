using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
  
    public class ProductionFlaw
    {
        int id;
        String itemCode;
        int docEntry;
        int user;
        string userName;
        int indicatedUser;
        string indicatedName;
        DateTime eventDate;
        string flaw;
        string userSector;
        string indicatedSector;
        string serialNumber;
        string comments;

        public int Id { get => id; set => id = value; }
        public string ItemCode { get => itemCode; set => itemCode = value; }
        public int DocEntry { get => docEntry; set => docEntry = value; }
        public int User { get => user; set => user = value; }
        public string UserName { get => userName; set => userName = value; }
        public int IndicatedUser { get => indicatedUser; set => indicatedUser = value; }
        public string IndicatedName { get => indicatedName; set => indicatedName = value; }
        public DateTime EventDate { get => eventDate; set => eventDate = value; }
        public string Flaw { get => flaw; set => flaw = value; }
        public string UserSector { get => userSector; set => userSector = value; }
        public string IndicatedSector { get => indicatedSector; set => indicatedSector = value; }
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public string Comments { get => comments; set => comments = value; }
    }
}
