using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface IDAL
    {
        void addGuestRequest(GuestRequest g);
        void updateGuestRequest(GuestRequest g);

        void addBankAccount(BankAccount b);

        void addHostingUnit(HostingUnit h);
        void updateHostingUnit(HostingUnit h);
        void removeHostingUnit(HostingUnit h);

        void addOrder(Order o);
        void updateOrder(Order o);

        List<GuestRequest> getGuestRequests();
        List<HostingUnit> getHostingUnits();
        List<Order> getOrders();
        List<BankAccount> getBankAccounts();



    }

}
