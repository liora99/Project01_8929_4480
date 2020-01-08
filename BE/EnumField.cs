using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EnumField
    {

        public enum OrderStatus { closed_deal, mail, refused, answer }
        public enum GuestStatus { active, done, expired }
        public enum Type { All, Zimmer, Hotel, Bungalow, appartment }
        public enum Pool { yes, no, required, not_necessary }
        public enum Garden { yes, no, required, not_necessary }
        public enum Parking { yes, no, required, not_necessary }
        public enum Jacuzzi { yes, no, required, not_necessary }
        public enum ChildrensAttractions { yes, no, required, not_necessary }
        public enum Wifi { yes, no, required, not_necessary }
        public enum Area { south, north}
       public enum PaymentClearance { yes, no }
        public enum CollectionClearance { yes, no}

    }
}
