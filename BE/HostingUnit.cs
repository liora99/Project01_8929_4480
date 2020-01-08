using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
  public  class HostingUnit
    {
        public string HostArea { get; set; }
        public int HostingUnitKey { get; set; }
        public Host Owner { get; set; }
        public string HostingUnitName { get; set; }
        public bool[,] Diary = new bool[31, 12];
        public bool PaymentAccepted { get; set; }
        public int NumberOfUnits { get; set; }



        public EnumField.Area Area { get; set; }
        public EnumField.Type Type { get; set; }
        public EnumField.Wifi Wifi { get; set; }
        public EnumField.Jacuzzi Jacuzzi { get; set; }

        public EnumField.Pool Pool { get; set; }
        public EnumField.Garden Garden { get; set; }
        public EnumField.GuestStatus Status { get; set; }
        public EnumField.ChildrensAttractions ChildrensAttractions { get; set; }




        public override string ToString()
        {
            return " Hosting Unit : " + HostingUnitName + " Hosting unit key: " + HostingUnitKey + " pool: " + Pool + " jacuzzi: " + Jacuzzi + " wifi: " + Wifi + " Type: " + Type + " Status: " + Status + " garden: " + Garden + " area: " + Area;
             
        } 
    }
}
