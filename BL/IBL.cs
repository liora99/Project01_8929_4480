using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
    {       
        void AddGuestRequest(GuestRequest g);
        void UpdateGuestRequest(GuestRequest g);

        void AddBankAccount(BankAccount b);

        bool ApprovedOrder(Order o);

        bool CheckRemove(Order value);
        void AddHostingUnit(HostingUnit h);
        void UpdateHostingUnit(HostingUnit h);
        void RemoveHostingUnit(HostingUnit h);

        void AddOrder(Order o);
        void UpdateOrder(Order o);

        List<GuestRequest> GetGuestRequests();
        List<HostingUnit> GetHostingUnits();
        List<Order> GetOrders();

        List<BankAccount> GetBankAccounts();
        List<BankAccount> BankAccounts();

        List<HostingUnit> DateAvalaible(DateTime entryDate, int duration);
        int NumOfDays(params DateTime[] dates);
        List<Order> OpenOrders(int days);
        List<GuestRequest> GetGuestsPartialListByPredicate(Func<GuestRequest, bool> func);

        int NumberOfOrdersFinal(HostingUnit unit);

        void RegroupArea(GuestRequest gr);
        void RegroupPerson(GuestRequest gr);
        void RegroupHostArea(HostingUnit gr);
        void RegroupHostingUnit(HostingUnit h);

      //  bool ApprovedRequest(GuestRequest g);
        bool AcceptedPayment(Order o);
        bool Debits(BankAccount b);
        int NumberOfGuestOrders(GuestRequest guest);

        void Mail(GuestRequest Gr, Order O);
        void DontClose(GuestRequest GR, Host h, HostingUnit hu);
        void ClosingDeal(Order O, GuestRequest GR, HostingUnit hu);

        //IEnumerable<IGrouping<EnumField.Area, GuestRequest>> GetGroupedByArea();
        //IEnumerable<IGrouping<int, GuestRequest>> GetGroupedByNumberOfVacations();
        //IEnumerable<IGrouping<int, HostingUnit>> GetGroupedByNumberOfUnts();
        //IEnumerable<IGrouping<EnumField.Area, HostingUnit>> GetGroupedByUnitArea();

    }
}
 