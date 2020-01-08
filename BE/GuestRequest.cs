using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class GuestRequest
    {
        public string Area { get; set; }
        public TimeSpan Duration
        {
            get
            {
                return ReleaseDate.Subtract(EntryDate);
            }

        }
        public int GuestRequestKey { get; set; }
        public EnumField.GuestStatus guestStatus{get;set; }
        public string FamilyName

        { get; set; }
        public bool IsApproved { get; set; }
        public string PrivateName

        { get; set; }

        public string Email

        { get; set; }

        public DateTime RegistrationDate

        { get; set; }

        public DateTime ReleaseDate

        { get; set; }

        public DateTime EntryDate

        { get; set; }

        public int Adult

        { get; set; }

        public int Children { get; set; }
        public string SubArea { get; set; }
        public EnumField.Type Type { get; set; }
        public EnumField.Jacuzzi Jacuzzi { get; set; }
        public EnumField.Parking Parking { get; set; }
        public EnumField.Wifi  Wifi{ get; set; }

        public EnumField.Pool Pool { get; set; }
        public EnumField.Garden Garden { get; set; }
        public EnumField.GuestStatus Status { get; set; }
        public EnumField.ChildrensAttractions ChildrensAttractions { get; set; }

         
        public override string ToString()
        {
            return " Guest Request: area: " + Area + " GuestRequestKey: " + GuestRequestKey + " GuestStatus: " + guestStatus + " FamilyName: " + FamilyName + " PrivateName: " + PrivateName + " Email: " + Email + " RegistrationDate: " + RegistrationDate + " ReleaseDate: " + ReleaseDate + " EntryDate: " + " Adult" + " Children: " + Children + " SubArea: " + SubArea + " Type: " + Type + " Jacuzzi: " + Jacuzzi + " Parking: " + Parking + " Wifi: " + Wifi + " Pool" + Pool + " Garden: " + Garden + " Status: " + Status + " ChildrensAttractions: " + ChildrensAttractions;
              
        }


    }
}
