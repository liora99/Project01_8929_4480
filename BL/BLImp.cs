using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using DS;
using System.IO;

namespace BL
{

    class BLImp : IBL
    {
        IDAL d= DalFactory.GetDal();
       

        public void AddGuestRequest(GuestRequest gU)
        {
            if (gU.ReleaseDate > gU.EntryDate)
           
                d.addGuestRequest(gU);
        }


        public void AddBankAccount (BankAccount b)
        {
            d.addBankAccount(b);
        }

        //public bool this[DateTime date]
        //{
        //    get
        //    {
        //        return Diary[date.Month - 1, date.Day - 1];
        //    }
        //    set
        //    {
        //        HostingUnit.Diary[date.Month - 1, date.Day - 1] = value;
        //    }
        //}

        //public bool ApprovedRequest(GuestRequest gR)//shows if the request is accepted or not
        //{
        //    DateTime eDate = gR.EntryDate;
        //    DateTime rDate = gR.ReleaseDate;
        //    bool isFree = true;
        //    DateTime date = eDate;

        //    foreach (var v in d.getHostingUnits())
        //    {
        //        while (date.Day != rDate.Day)// pass on all the days between the entry and release day
        //        {
        //            if (v.Diary[eDate.Day, eDate.Month])
        //                isFree = false;
        //            date = date.AddDays(1); //adding a day 

        //        }
        //        if (isFree)
        //            return true;
        //    }
        //    return false;
        //}
            //if (this[date])//if its busy
            //{
            //    return false;
            //}

            //    ///* after validate order
            //    //while (eDate != rDate)
            //    //{
            //    //    this[eDate] = true;
            //    //    Configuration.totalOccupation++;  //counting the number of 'true' values
            //    //    eDate = eDate.AddDays(1);
            //    //}
            //    //gR.isApproved = true;// if its not occupied the demand is accepted
            //    //*/
            //    //return true; 
            //}

            public bool ApprovedOrder(Order o)//shows if the request is accepted or not
        {
            var guest = d.getGuestRequests().FirstOrDefault(g => g.GuestRequestKey == o.GuestRequestKey);
            if (guest==null)
            {
                Console.WriteLine("the guest doesn't exist!");
                return false;
            }
            DateTime eDate = guest.EntryDate;
            DateTime rDate = guest.ReleaseDate;
            DateTime date = eDate;
            

            var hostingUnit = d.getHostingUnits().FirstOrDefault(h => h.HostingUnitKey == o.HostingUnitKey);
            if (hostingUnit == null)
            {
                Console.WriteLine("the order doesn't exist!");
                return false;
            }

            while (date.Day != rDate.Day)// pass on all the days between the entry and release day
            {
               

                if (hostingUnit.Diary[date.Day - 1, date.Month - 1] == true)//if its busy
                {
                    Console.WriteLine("the request has been rejected!");
                    return false;
                }
                date = date.AddDays(1); //adding a day 
            }

            Console.WriteLine("the request has been approved!");
            return true;
        }

        //public void updateGuestRequest(GuestRequest g)
        //{
        //    if (OrderStatus == EnumField.OrderStatus.closed_deal)
        //    {
        //        guestStatus = EnumField.GuestStatus.done;
        //        //var 
        //        //foreach (Order o in DataSource.orders)
        //        //{
        //        //    if (o.GuestRequestKey == g.GuestRequestKey)
        //        //        guestStatus = EnumField.GuestStatus.expired;
        //        //}

        //    }
        //    //int index = DataSource.guestRequests.FindIndex(n => n.GuestRequestKey == g.GuestRequestKey);
        //    //DataSource.guestRequests[index] = g;
        //}


        public void UpdateGuestRequest(GuestRequest g)
        {
            var order = (from o in d.getOrders()
                         where o.GuestRequestKey == g.GuestRequestKey
                         select o).FirstOrDefault();
            if (order == null)
                throw new KeyNotFoundException("Guest Request doesn't exist");

            if (order.Status == EnumField.OrderStatus.closed_deal)
                g.Status = EnumField.GuestStatus.done;
            else
                order.Status = EnumField.OrderStatus.refused;

          
            if (order.Status == EnumField.OrderStatus.refused && g.Status == EnumField.GuestStatus.expired)
                throw new Exception("Request is Closed");

            var gU = (from o in d.getGuestRequests()
                      where o.GuestRequestKey == g.GuestRequestKey
                      select o).FirstOrDefault();

            if (!g.PrivateName.Equals(gU.PrivateName) || !g.FamilyName.Equals(gU.FamilyName))
                  throw new KeyNotFoundException("we can't change your information");
            if (g.EntryDate != gU.EntryDate || g.ReleaseDate != gU.ReleaseDate)
            {
                g.EntryDate = gU.EntryDate;
                g.ReleaseDate = gU.ReleaseDate;
            }
            if (g.Area != gU.Area || g.SubArea != gU.SubArea)
            {
                g.Area = gU.Area;
                g.SubArea = gU.SubArea;
            }
            if (g.Jacuzzi != gU.Jacuzzi)
            {
                g.Jacuzzi = gU.Jacuzzi;
                //Console.WriteLine("we changed the Jacuzzi");
            }

            if (g.Pool != gU.Pool)
                g.Pool  = gU.Pool;

            // lio qui a fait , la 7eme
            //il faut verfifizr sil veut changer sa date et son endroit simo
        }


        //public void addHostingUnit(HostingUnit h)
        //{
        //    if (DataSource.hostingUnits.Find(i => i.HostingUnitKey == h.HostingUnitKey) == null)
        //    {
        //        DataSource.hostingUnits.Add(h);
        //        Config.AddHostingUnitKey();
        //    }
        //    else Console.WriteLine("the hostingUnit already exists.");



        //

        public void AddHostingUnit(HostingUnit h)
        {
            d.addHostingUnit(h);
            d.getHostingUnits().Add(h);
            
        }

        //public void updateHostingUnit(HostingUnit h)
        //{
        //    foreach (var v in DataSource.orders)
        //    {
        //        if (v.Status == EnumField.OrderStatus.closed_deal)
        //        {
        //            if (v.HostingUnitKey == h.HostingUnitKey)
        //            {
        //                foreach (var b in DataSource.guestRequests)
        //                {
        //                    if (b.GuestRequestKey == v.GuestRequestKey)
        //                    {
        //                        for (DateTime t = b.EntryDate; t < b.ReleaseDate; t.AddDays(1))
        //                        {
        //                            h.Diary[t.Day, t.Month] = true;
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        //d.updateHostingUnit(h);
        //    }
        //}


        public void UpdateHostingUnit(HostingUnit h)
        {

            var ord = d.getOrders().FirstOrDefault(o => o.HostingUnitKey == h.HostingUnitKey); //ca pas sur
            d.addOrder(ord);

            var it = (from newH in d.getHostingUnits()
                      where h.HostingUnitKey == newH.HostingUnitKey
                      select newH).FirstOrDefault();
            if (h.Owner != it.Owner)
                h.Owner = it.Owner;

            if (h.Jacuzzi != it.Jacuzzi)
            {
                h.Jacuzzi = it.Jacuzzi;
                Console.WriteLine("the jacuzzi changed");
            }

            if (h.Garden != it.Garden)
            {
                h.Garden = it.Garden;
                Console.WriteLine("the garden changed");
            }

            // nouveau liora pas sur de moi a verifier 
        }

        //public void removeHostingUnit(HostingUnit hostingUnit)
        //{
        //    if (CheckRemove(value))
        //    {
        //        var hU = (from h in DataSource.hostingUnits    // yoel avait ecrit au lieu de var ,HostingUnit
        //                  where h.HostingUnitKey == hostingUnit.HostingUnitKey
        //                  select h).First();
        //        DataSource.hostingUnits.Remove(hU);
        //        Config.RemoveHostingUnitKey();
        //    }
        //}

        public void RemoveHostingUnit(HostingUnit hostingUnit)
        {

            if (d.getHostingUnits().Any(x => x.HostingUnitKey == hostingUnit.HostingUnitKey))
                throw new InvalidOperationException(string.Format("HostingUnit" + hostingUnit.HostingUnitKey + "doesn't exist"));
           



        }


        //public void addOrder(Order o)
        //{
        //    if (d.getOrders().Find(i => i.OrderKey == o.OrderKey) == null)
        //    {

        //        if (o.Status == EnumField.OrderStatus.mail)
        //        {
        //            Console.WriteLine("we sent you an Email with the details of your reservation.");

        //        }
        //        DataSource.orders.Add(o);
        //        Config.AddOrderKey();
        //    }
        //    else Console.WriteLine("the order already exists.");
        //}

        public void AddOrder(Order o)
        {
            if (!ApprovedOrder(o))
            {
                throw new Exception("Request is refused");
            }
            d.addOrder(o);
            Console.WriteLine("The order has been added successfully!");

        }



        //public void UpdateOrder(Order o)
        //{
        //    if (acceptedPayment(o))
        //    {
        //        o.Status = EnumField.OrderStatus.mail;
        //    }

        //    if (o.Status == EnumField.OrderStatus.closed_deal)
        //    {
        //        foreach (var v in DataSource.guestRequests)
        //        {
        //            if (o.GuestRequestKey == v.GuestRequestKey)
        //            {
        //                TimeSpan d = v.Duration;
        //                while (d)
        //                {
        //                    Config.AddAmountOfCommision();

        //                }
        //            }

        //        }



        //    }

        //    // pas sur de pouvoir faire return pour que la valeur du enum ne change jamais
        //}

        public void UpdateOrder(Order o)
        {

            var order = (from or in d.getOrders()
                         where or.HostingUnitKey == o.HostingUnitKey
                         select or).FirstOrDefault();
            if (o.Status != order.Status && AcceptedPayment(order) && o.Status != EnumField.OrderStatus.closed_deal)
            {
                o.Status = EnumField.OrderStatus.mail;
            }
            if (o.Status != order.Status && o.Status != EnumField.OrderStatus.closed_deal)
            {
                o.Status = order.Status;
            }
            else
                throw new Exception("you cannot change the status");
            if (o.Status == EnumField.OrderStatus.closed_deal)
            {
                var guest = d.getGuestRequests().FirstOrDefault(g => g.GuestRequestKey == o.GuestRequestKey);
                DateTime eDate = guest.EntryDate;
                DateTime rDate = guest.EntryDate;
                DateTime date = eDate;

                var hostingUnit = d.getHostingUnits().FirstOrDefault(h => h.HostingUnitKey == o.HostingUnitKey);

                while (eDate != rDate)
                {
                    hostingUnit.Diary[date.Month - 1, date.Day - 1] = true;
                    Configuration.totalOccupation++;  //counting the number of 'true' values
                    eDate = eDate.AddDays(1);
                }
            }
        }

        public void ClosingDeal(Order O, GuestRequest GR, HostingUnit hu)
        {
            TimeSpan dt = GR.ReleaseDate.Date - GR.EntryDate.Date;
            int x = int.Parse(dt.ToString());
            int y = x * 10;

            if (O.Status == EnumField.OrderStatus.closed_deal)
            {

                GR.Status = EnumField.GuestStatus.active;
                Console.WriteLine("you have to pay" + y + "shekel to the site");
                throw new Exception("your Status can't change");

            }
            if (GR.Status == EnumField.GuestStatus.active)
            {


                for (int i = 0; i < x; i++)
                {
                    int month = int.Parse(GR.EntryDate.Month.ToString());
                    int day = int.Parse(GR.EntryDate.Day.ToString());
                    hu.Diary[day + i, month] = false;
                }


            }
        }
       public void DontClose(GuestRequest GR, Host h, HostingUnit hu)
        {
            while (GR.Status != EnumField.GuestStatus.active && GR.Status != EnumField.GuestStatus.expired)
            {
                hu.PaymentAccepted = true;
                throw new ArgumentException(" you can't delete a Hosting Unit Exception");

            }
        }

        public bool AcceptedPayment(Order o)
        {
            var hostingUnit = d.getHostingUnits().FirstOrDefault(h => h.HostingUnitKey == o.HostingUnitKey);
            return hostingUnit == null ? false : hostingUnit.PaymentAccepted;
        }

        public void Mail(GuestRequest Gr, Order O)
        {
            if (O.Status == EnumField.OrderStatus.mail)
                throw new Exception("information order:" + O);
        }

        public List<BankAccount> BankAccounts()
        {
            return DataSource.BankAccounts;
        }

        //public List<GuestRequest> GetGuestRequests()
        //{
        //    List<GuestRequest> list = new List<GuestRequest>();
        //    foreach (GuestRequest request in d.getGuestRequests())
        //    {

        //        list.Add(request);
        //    }
        //    foreach (var x in list)
        //    {
        //        var requestList = from request in d.getGuestRequests()
        //                          where request.GuestRequestKey == x.GuestRequestKey
        //                          orderby request.GuestRequestKey
        //                          select new GuestRequest();
        //        list = requestList.ToList();
        //    }
        //    return list;

        //}

        ////public List<HostingUnit> GetHostingUnits()
        //{
        //    List<HostingUnit> list = new List<HostingUnit>();
        //    foreach (HostingUnit item in d.getHostingUnits())
        //    {

        //        list.Add(item);
        //    }
        //    foreach (var x in list)
        //    {
        //        var HUList = from unit in d.getHostingUnits()
        //                     where unit.HostingUnitKey == x.HostingUnitKey
        //                     orderby unit.HostingUnitKey
        //                     select new HostingUnit();
        //        list = HUList.ToList();
        //    }
        //    return list;
        //}

        //public List<Order> GetOrders()
        //{
        //    List<Order> list = new List<Order>();
        //    foreach (Order order in d.getOrders())
        //    {

        //        list.Add(order);
        //    }
        //    foreach (var x in list)
        //    {
        //        var orderList = from order in d.getOrders()
        //                        where order.OrderKey == x.OrderKey
        //                        orderby order.OrderKey
        //                        select new Order();
        //        list = orderList.ToList();
        //    }
        //    return list;
        //}


        //bool CheckRemove(EnumField.GuestStatus value)  // pour verifier si il est actif jai pas le droit de le supprimer
        //{
        //    if (value == EnumField.GuestStatus.active)
        //        return false;
        //    return true;
        //}

        public bool CheckRemove(Order value)  // pour verifier si il est actif jai pas le droit de le supprimer
        {
            var order = (from or in d.getGuestRequests()
                         where or.GuestRequestKey == value.GuestRequestKey
                         select or).FirstOrDefault();
            if (order==null)
            {
                Console.WriteLine("doesn exist");
                    return false;
            }
            if (order.Status == EnumField.GuestStatus.active)
                return false;
            return true;
        }


        //public IEnumerable<IGrouping<EnumField.Area, HostingUnit>> GetGroupedByUnitArea()
        //{
        //    try
        //    {
        //        return from unit in GetHostingUnits()
        //               orderby unit.HostingUnitKey
        //               group unit by unit.Area
        //                    into g
        //               orderby g.Key
        //               select g;
        //    }
        //    catch (DirectoryNotFoundException e)
        //    {
        //        throw e;
        //    }
        //}

        //public IEnumerable<IGrouping<int, HostingUnit>> GetGroupedByNumberOfUnits()
        //{
        //    try
        //    {
        //        return from host in GetHostingUnits()
        //               orderby host.HostingUnitKey
        //               group host by host.NumberOfUnits
        //                    into g
        //               orderby g.Key
        //               select g;
        //    }
        //    catch (DirectoryNotFoundException e)
        //    {
        //        throw e;
        //    }
        //}

       


        //public void RegroupArea(GuestRequest gr)
        //{
        //    var usersGroupedByArea = DataSource.guestRequests.GroupBy(user => user.Area);
        //    foreach (var group in usersGroupedByArea)
        //    {
        //        Console.WriteLine("Users from " + group.Key + ":");
        //        foreach (var user in group)
        //            Console.WriteLine("* " + user.PrivateName);
        //    }

        //}

        //public void RegroupPerson(GuestRequest gr)
        //{
        //    var usersGroupedByPerson = DataSource.guestRequests.GroupBy(user => user.Adult + user.Children);//jcp si ca marche de faire plus
        //    foreach (var group in usersGroupedByPerson)
        //    {
        //        Console.WriteLine("Users from " + group.Key + ":");
        //        foreach (var user in group)
        //            Console.WriteLine("* " + user.PrivateName);
        //    }

        //}
        //public void RegroupHostingUnit(HostingUnit h)
        //{
        //    var usersGroupedByHostingUnit = DataSource.hostingUnits.GroupBy(user => user.HostingUnitKey);
        //    foreach (var group in usersGroupedByHostingUnit)
        //    {
        //        Console.WriteLine("Users from " + group.Key + ":");
        //        foreach (var user in group)
        //            Console.WriteLine("* " + user.Owner.PrivateName);
        //    }

        //}

        //public void RegroupHostArea(HostingUnit gr)
        //{
        //    var usersGroupedByHostArea = DataSource.hostingUnits.GroupBy(user => user.HostArea);
        //    foreach (var group in usersGroupedByHostArea)
        //    {
        //        Console.WriteLine("Users from " + group.Key + ":");
        //        foreach (var user in group)
        //            Console.WriteLine("* " + user.HostingUnitKey);
        //    }

        //}

        public List<HostingUnit> DateAvalaible(DateTime EntryDate, int duration)
        {
            List<HostingUnit> hostingUnitAvailable = null;
            DateTime endDate = EntryDate.AddDays(duration);
            bool isFree = true;
            DateTime firstDate = EntryDate;
            foreach (var v in DataSource.hostingUnits)
            {
                while (firstDate != endDate)
                {
                    if (v.Diary[firstDate.Day, firstDate.Month])
                        isFree = false;
                    firstDate.AddDays(1);
                }
                if (isFree)
                    hostingUnitAvailable.Add(v);
            }
            return hostingUnitAvailable;
        }

        public List<Order> OpenOrders(int days)
        {
            try
            {
                List<Order> list = new List<Order>();
                foreach (var order in d.getOrders())
                {
                    if (order.Status == EnumField.OrderStatus.mail || order.Status == EnumField.OrderStatus.closed_deal)
                    {
                        if (DateTime.Now.Day - order.CreateDate.Day >= days)
                        {
                            list.Add(order);
                        }
                    }

                }
                return list;
            }
            catch (DirectoryNotFoundException e)
            {
                throw e;
            }
        }

        public int NumberOfOrdersFinal(HostingUnit unit)
        {
            try
            {
                return d.getOrders().Count(y => y.HostingUnitKey == unit.HostingUnitKey && y.Status == EnumField.OrderStatus.answer);
            }
            catch (DirectoryNotFoundException e)
            {
                throw e;
            }
        }

        public List<GuestRequest> GetGuestsPartialListByPredicate(Func<GuestRequest, bool> func)
        {
            try
            {
                var patialGuestList = (from item in d.getGuestRequests() where func(item) orderby item.FamilyName, item.PrivateName select item).ToList();
                return patialGuestList;
            }
            catch (DirectoryNotFoundException e)
            {
                throw e;
            }
        }

        public int NumOfDays(params DateTime[] dates)
        {
            try
            {
                if (dates.Length == 1)
                {
                    if (dates[0] >= DateTime.Now)
                        return (dates[0] - DateTime.Now).Days;
                    else
                        return (DateTime.Now - dates[0]).Days;
                }
                else
                if (dates.Length == 2)
                {
                    if (dates[1] >= dates[0])
                        return (dates[1] - dates[0]).Days;
                    else
                        return (dates[0] - dates[1]).Days;
                }
                else
                {
                    return 0;
                }
            }
            catch (DirectoryNotFoundException e)
            {
                throw e;
            }
        }
        public int NumberOfGuestOrders(GuestRequest guest)
        {
            try
            {
                return d.getOrders().Count(y => y.GuestRequestKey == guest.GuestRequestKey);
            }
            catch (DirectoryNotFoundException e)
            {
                throw e;
            }
        }

        public bool Debits(BankAccount b)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(EnumField o)
        {
            throw new NotImplementedException();
        }

        public List<BankAccount> GetBankAccounts()
        {
            return DataSource.BankAccounts;
        }

        public void RegroupArea(GuestRequest gr)
        {
            throw new NotImplementedException();
        }

        public void RegroupPerson(GuestRequest gr)
        {
            throw new NotImplementedException();
        }

        public void RegroupHostArea(HostingUnit gr)
        {
            throw new NotImplementedException();
        }

        public void RegroupHostingUnit(HostingUnit h)
        {
            throw new NotImplementedException();
        }

        public List<GuestRequest> GetGuestRequests()
        {
            return DataSource.guestRequests;
        }

        public List<HostingUnit> GetHostingUnits()
        {
            return DataSource.hostingUnits;
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<IGrouping<EnumField.Area, GuestRequest>> GetGroupedByArea()
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<IGrouping<int, GuestRequest>> GetGroupedByNumberOfVacations()
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<IGrouping<int, HostingUnit>> GetGroupedByNumberOfUnts()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
