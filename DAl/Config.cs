using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public static class Config
    {
        public static void AddHostingUnitKey()
        {
            Configuration.HostingUnitkey++;
        }

        public static int getHostingUnitKey()
        {
            return Configuration.HostingUnitkey;
        }

        public static void AddGuestRequestKey()
        {
            Configuration.guestRequestKey++;
        }

        public static int getGuestRequestKey()
        {
            return Configuration.guestRequestKey;
        }

        public static void AddOrder()
        {
            Configuration.orderKey++;
        }

        public static int getOrder()
        {
            return Configuration.orderKey;
        }

        public static void RemoveHostingUnitKey()
        {
            Configuration.orderKey--;
        }

        public static void AddAmountOfCommision()
        {
            Configuration.money += 10;
        }
        public static void AddTotalOccupation()
        {
            Configuration.totalOccupation++;
        }
    }
}
