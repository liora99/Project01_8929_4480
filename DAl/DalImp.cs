using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    class DalImp : IDAL
    {        
        public void addGuestRequest(GuestRequest gU)
        {
            DataSource.guestRequests.Add(gU);
            Config.AddGuestRequestKey();
        }

        public void addBankAccount (BankAccount b )
        {
            DataSource.BankAccounts.Add(b);
        }

        public void updateGuestRequest(GuestRequest guestRequest)
        {
            int index = DataSource.guestRequests.FindIndex(g => g.GuestRequestKey == guestRequest.GuestRequestKey);
            DataSource.guestRequests[index] = guestRequest;
        }


        public void addHostingUnit(HostingUnit hostingUnit)
        {
            var hU = (from h in DataSource.hostingUnits     
                      where h.HostingUnitKey == hostingUnit.HostingUnitKey
                      select new HostingUnit { HostingUnitKey = h.HostingUnitKey }).FirstOrDefault();
            if(hU == null)
            {
                DataSource.hostingUnits.Add(hostingUnit);
                Config.AddHostingUnitKey();
            }           
        }

        public void updateHostingUnit(HostingUnit hostingUnit)
        {
            int index = DataSource.hostingUnits.FindIndex(g => g.HostingUnitKey == hostingUnit.HostingUnitKey);
            DataSource.hostingUnits[index] = hostingUnit;            
        }

        public void removeHostingUnit(HostingUnit hostingUnit)
        {
           
                var hU = (from h in DataSource.hostingUnits    // yoel avait ecrit au lieu de var ,HostingUnit
                          let findHostingUnit = h.HostingUnitKey == hostingUnit.HostingUnitKey
                          where findHostingUnit
                          select h).First();

                if (hU == null)
                    throw new Exception("Hosting Unit with the same key not found...");
                if (getAllHostingUnit(sc => sc.HostingUnitKey == hostingUnit.HostingUnitKey).Any())
                    throw new Exception("The Hosting Unit exist!!!");
                
                DataSource.hostingUnits.Remove(hU);
                Config.RemoveHostingUnitKey();
            
          
        }

        public IEnumerable<HostingUnit> getAllHostingUnit(Func<HostingUnit, bool> predicate = null)
        {
            if (predicate == null)
                return
                   DataSource.hostingUnits.AsEnumerable();
            return
            DataSource.hostingUnits.Where(predicate);

        }

        public void addOrder(Order o)
        {
            DataSource.orders.Add(o);
            Config.AddOrder();
        }

        public void updateOrder(Order order)
        {
            int index = DataSource.orders.FindIndex(o => o.OrderKey == o.OrderKey);
            DataSource.orders[index].Status = order.Status;
        }


        public List<GuestRequest> getGuestRequests()
        {
            return DataSource.guestRequests;  // ou foreach

        }

        public List<HostingUnit> getHostingUnits()
        {
            return DataSource.hostingUnits;
        }

        public List<Order> getOrders()
        {
            return DataSource.orders;
        }

        public List<BankAccount> getBankAccounts()
        {
            return DataSource.BankAccounts;
        }

       public IEnumerable<BankAccount> AllBanks()
        {
            List<BankAccount> bankAccount = new List<BankAccount>()
            {
                new BankAccount()
                {
                    BankAccountNumber=1,
                    bankname= "leumi",
                    BankCity="Jerusalem",
                    branchAddress="220 Yaffo",
                    branchNumber=109
                },

                new BankAccount()
                {
                    BankAccountNumber=2,
                    bankname= "discount",
                    BankCity="Tel Aviv",
                    branchAddress=" 10 bet hadfous",
                    branchNumber=110
                },

                new BankAccount()
                {
                    BankAccountNumber=3,
                    bankname= "leumi",
                    BankCity="Jerusalem",
                    branchAddress="1 haturim",
                    branchNumber=104
                },

                new BankAccount()
                {
                    BankAccountNumber=4,
                    bankname= "bank hapoalim",
                    BankCity="Jerusalem",
                    branchAddress="7  kanefe nesharim",
                    branchNumber=109
                },
                new BankAccount()
                {
                    BankAccountNumber=1,
                    bankname= "leumi",
                    BankCity="Jerusalem",
                    branchAddress="220 Yaffo",
                    branchNumber=109
                }
            };
            return bankAccount;
        }















    }
}
