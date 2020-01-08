using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DS
{
    public class DataSource
    {
        public static List<GuestRequest> guestRequests = new List<GuestRequest>()
        {
            new GuestRequest {GuestRequestKey=10000010, PrivateName = "Eliora", FamilyName="Sebbag", Email="eliorasebbag@live.fr" , ReleaseDate= new DateTime(2019,6,19 ) , EntryDate = new DateTime(2019,6,15), Status=EnumField.GuestStatus.done },
            new GuestRequest{ GuestRequestKey=10000002, PrivateName = "Liora", FamilyName="Levy", Email=" liora_levy_1@hotmail.fr", ReleaseDate= new DateTime(2019,6,14 ) , EntryDate = new DateTime(2019,5,5), Adult=3, Children=1, Jacuzzi=EnumField.Jacuzzi.not_necessary  },//pas sur
            new GuestRequest {GuestRequestKey=10000004, PrivateName = "Yoel", FamilyName="Levy", Email=" yoel_levy_1@hotmail.fr",ReleaseDate= new DateTime(2019,6,27 ) , EntryDate = new DateTime(2019,6,20) }
        };

        public static List<HostingUnit> hostingUnits = new List<HostingUnit>()
        {
            new HostingUnit
            {
            HostingUnitKey = 10000548, Owner= new Host {PrivateName= "Liora", FamilyName="Levy", hostKey=3429845, mail="lioralevy@gmail.com", phoneNumber="0532564120" }, Garden=EnumField.Garden.yes, Area = EnumField.Area.north, Type = EnumField.Type.appartment, Pool = EnumField.Pool.yes,
            Jacuzzi = EnumField.Jacuzzi.no,
            Wifi = EnumField.Wifi.yes,
            ChildrensAttractions = EnumField.ChildrensAttractions.yes,
            HostingUnitName = "Best House"
            },

            new HostingUnit
            {
            HostingUnitKey = 100000012, Owner= new Host {PrivateName= "Yoel",  FamilyName="Levy", hostKey=34298478, mail="yoelevy@gmail.com", phoneNumber="0532343201" }, Garden=EnumField.Garden.no, Area = EnumField.Area.south,
            Type = EnumField.Type.Zimmer,
            Pool = EnumField.Pool.yes,
            Jacuzzi = EnumField.Jacuzzi.yes,
            Wifi = EnumField.Wifi.yes,
            ChildrensAttractions = EnumField.ChildrensAttractions.yes,
            HostingUnitName = "The Wonderful Place"
            },
            new HostingUnit
            {
              HostingUnitKey = 10000550, Owner= new Host {PrivateName= "Eliora" ,FamilyName="Sebbag", hostKey=1518929, mail="eliorasebbag@live.com", phoneNumber="0581236548" }, Garden=EnumField.Garden.yes, Area = EnumField.Area.north,
              Type = EnumField.Type.Hotel,
              Pool = EnumField.Pool.yes,
              Jacuzzi = EnumField.Jacuzzi.yes,
              Wifi = EnumField.Wifi.yes,
              ChildrensAttractions = EnumField.ChildrensAttractions.yes,
              HostingUnitName = "Royal Hotel"
            }
        };

        public static List<Order> orders = new List<Order>()
        {
            new Order {HostingUnitKey= 100000001, GuestRequestKey=10000001, Status=EnumField.OrderStatus.closed_deal,CreateDate= new DateTime(2020,7,6), OrderDate=new DateTime(2020,7,12), OrderKey=200000012  },
            new Order {HostingUnitKey= 10000010, GuestRequestKey=10000003, Status=EnumField.OrderStatus.mail, CreateDate= new DateTime(2020,9,1), OrderDate=new DateTime(2020,9,30), OrderKey=200000012 },
            new Order {HostingUnitKey= 10000011, GuestRequestKey=10000004, Status=EnumField.OrderStatus.refused, CreateDate= new DateTime(2020,6,12), OrderDate=new DateTime(2020,6,30), OrderKey=200000056  },
        };

        public static List<BankAccount> BankAccounts = new List<BankAccount>()
        {
            new BankAccount{bankNumber=11 , branchNumber = 41, BankAccountNumber = 166685,  money =4000},
            new BankAccount{bankNumber=12 , branchNumber = 42, BankAccountNumber = 166686,  money = 5000},
            new BankAccount{bankNumber=13 , branchNumber = 43, BankAccountNumber = 166687,  money = 6000},
        };
    }
}
