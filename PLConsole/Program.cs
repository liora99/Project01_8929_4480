using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace PLConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IBL blAccess;
            blAccess = BlFactory.GetBL();
            #region adding guest requests
            BE.GuestRequest guestRequest = new BE.GuestRequest();
            //           List

            guestRequest.PrivateName = "Eliora";
            guestRequest.FamilyName = "Sebbag";
            guestRequest.Email = "eliorasebbag@live.fr";
            guestRequest.RegistrationDate = new DateTime(2019, 03, 08);
            guestRequest.EntryDate = new DateTime(2019, 03, 28);
            guestRequest.ReleaseDate = new DateTime(2019, 04, 08);
            guestRequest.Area = "Jerusalem";
            guestRequest.Type = EnumField.Type.Hotel;
            guestRequest.Adult = 1;
            guestRequest.Children = 0;
            guestRequest.Pool = EnumField.Pool.yes;
            guestRequest.Jacuzzi = EnumField.Jacuzzi.not_necessary;
            guestRequest.Parking = EnumField.Parking.yes;
            guestRequest.Garden = EnumField.Garden.no;
            guestRequest.ChildrensAttractions = EnumField.ChildrensAttractions.no;
            guestRequest.GuestRequestKey = 10000001;

            try
            {
                blAccess.AddGuestRequest(guestRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            BE.GuestRequest guestRequest2 = new BE.GuestRequest();
            guestRequest2.PrivateName = "Liora";
            guestRequest2.FamilyName = "Levy ";
            guestRequest2.Email = "lioralevy@live.fr";
            guestRequest2.RegistrationDate = new DateTime(2019, 04, 12);
            guestRequest2.EntryDate = new DateTime(2019, 03, 28);
            guestRequest2.ReleaseDate = new DateTime(2019, 04, 08);
            guestRequest2.Area = "Tel Aviv";
            guestRequest2.Type = EnumField.Type.Zimmer;
            guestRequest2.Adult = 1;
            guestRequest2.Children = 3;
            guestRequest2.Pool = EnumField.Pool.yes;
            guestRequest2.Jacuzzi = EnumField.Jacuzzi.not_necessary;
            guestRequest2.Parking = EnumField.Parking.yes;
            guestRequest2.Garden = EnumField.Garden.no;
            guestRequest2.ChildrensAttractions = EnumField.ChildrensAttractions.no;
            try
            {
                blAccess.AddGuestRequest(guestRequest2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            GuestRequest guestRequest3 = new BE.GuestRequest();

            guestRequest3.PrivateName = "yoel";
            guestRequest3.FamilyName = "levy ";
            guestRequest3.Email = "yoelevy@live.fr";
            guestRequest3.RegistrationDate = new DateTime(2019, 03, 08);
            guestRequest3.EntryDate = new DateTime(2019, 03, 28);
            guestRequest3.ReleaseDate = new DateTime(2019, 04, 08);
            guestRequest3.Area = "haifa";
            guestRequest3.Type = EnumField.Type.appartment;
            guestRequest3.Adult = 1;
            guestRequest3.Children = 0;
            guestRequest3.Pool = EnumField.Pool.yes;
            guestRequest3.Jacuzzi = EnumField.Jacuzzi.not_necessary;
            guestRequest3.Parking = EnumField.Parking.yes;
            guestRequest3.Garden = EnumField.Garden.no;
            guestRequest3.ChildrensAttractions = EnumField.ChildrensAttractions.no;
            try
            {
                blAccess.AddGuestRequest(guestRequest3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            #endregion

            try
            {
                blAccess.UpdateGuestRequest(guestRequest);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            #region add banks
            BankAccount bankbranch1 = new BankAccount();
            bankbranch1.bankname = "Discount";
            bankbranch1.branchNumber = 5689;
            bankbranch1.branchAddress = "Shamgar 21 ";
            bankbranch1.BankCity = "Jerusalem";
            bankbranch1.bankNumber = 1;



            BankAccount bankbranch2 = new BankAccount();
            bankbranch2.bankname = "Leumi";
            bankbranch2.branchNumber = 2345;
            bankbranch2.branchAddress = "Hazon Ich 21 ";
            bankbranch2.BankCity = "Bne Brak";
            bankbranch2.bankNumber = 2;


            BankAccount bankbranch3 = new BankAccount();
            bankbranch3.bankname = "Bank Hapoalim";
            bankbranch3.branchNumber = 7564;
            bankbranch3.branchAddress = "Yaffo 121 ";
            bankbranch3.BankCity = "Jerusalem";
            bankbranch3.bankNumber = 3;



            BankAccount bankbranch4 = new BankAccount();
            bankbranch4.bankname = "Discount";
            bankbranch4.branchNumber = 8796;
            bankbranch4.branchAddress = "rav Franck ";
            bankbranch4.BankCity = "Haifa";
            bankbranch4.bankNumber = 4;

            BankAccount bankbranch5 = new BankAccount();
            bankbranch5.bankname = "Leumi";
            bankbranch5.branchNumber = 7653;
            bankbranch5.branchAddress = "Haturim 87 ";
            bankbranch5.BankCity = "Jerusalem";
            bankbranch5.bankNumber = 5;
            #endregion
            try
            {
                blAccess.AddBankAccount(bankbranch1);
                blAccess.AddBankAccount(bankbranch2);
                blAccess.AddBankAccount(bankbranch3);
                blAccess.AddBankAccount(bankbranch4);
                blAccess.AddBankAccount(bankbranch5);


            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            foreach (var bank in blAccess.GetBankAccounts())
            {
                Console.WriteLine(bank);
            }


            #region add hosting units
            HostingUnit myhostingUnit1 = new HostingUnit();

            myhostingUnit1.Owner = new Host()

            {
                hostKey = 342687,
                PrivateName = "Aviel",
                FamilyName = "Levy",
                phoneNumber = "0534323554",
                mail = "aviellevy@hotmail.com",

                bankAccount = new BankAccount()
                {
                    bankNumber = 895987,
                    bankname = "Hapoalim",
                    branchNumber = 897,
                    branchAddress = "Kanfey Necharim 5",
                    BankCity = "Jerusalem",

                },
                BankAccountNumber = 4535676,
                CollectionClearance = EnumField.CollectionClearance.yes,
            };
            myhostingUnit1.Area = EnumField.Area.north;
            myhostingUnit1.Type = EnumField.Type.appartment;
            myhostingUnit1.Pool = EnumField.Pool.yes;
            myhostingUnit1.Jacuzzi = EnumField.Jacuzzi.no;
            myhostingUnit1.Wifi = EnumField.Wifi.yes;
            myhostingUnit1.Garden = EnumField.Garden.yes;
            myhostingUnit1.ChildrensAttractions = EnumField.ChildrensAttractions.yes;
            myhostingUnit1.HostingUnitName = "Pool house";
            bool[,] Diary1 = new bool[12, 31];

            try
            {
                blAccess.AddHostingUnit(myhostingUnit1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            HostingUnit myhostingUnit2 = new HostingUnit();

            myhostingUnit1.Owner = new Host()

            {
                hostKey = 15187,
                PrivateName = "Maayan",
                FamilyName = "Bouzaglou",
                phoneNumber = "0523243201",
                mail = "mbouzagl@gmail.com",

                bankAccount = new BankAccount()
                {
                    bankNumber = 12345,
                    bankname = "Leumi",
                    branchNumber = 901,
                    branchAddress = "yaffo 109",
                    BankCity = "Jerusalem",
                },
                BankAccountNumber = 678577,
                CollectionClearance = EnumField.CollectionClearance.yes,
            };
            myhostingUnit2.Area = EnumField.Area.south;
            myhostingUnit2.Type = EnumField.Type.Hotel;

            myhostingUnit2.Pool = EnumField.Pool.no;
            myhostingUnit2.Jacuzzi = EnumField.Jacuzzi.yes;
            myhostingUnit2.Wifi = EnumField.Wifi.yes;
            myhostingUnit2.Garden = EnumField.Garden.yes;
            myhostingUnit2.ChildrensAttractions = EnumField.ChildrensAttractions.no;
            myhostingUnit2.HostingUnitName = "Hotel on the Beach ";
            bool[,] Diary2 = new bool[12, 31];

            try
            {
                blAccess.AddHostingUnit(myhostingUnit2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            HostingUnit myhostingUnit3 = new HostingUnit();

            myhostingUnit3.Owner = new Host()

            {
                hostKey = 56546988,
                PrivateName = "Paul",
                FamilyName = "Cohen",
                phoneNumber = "0537147969",
                mail = "paulco@yahoo.com",

                bankAccount = new BankAccount()
                {
                    bankNumber = 123456,
                    bankname = "Discount",
                    branchNumber = 608,
                    branchAddress = "haatasia",
                    BankCity = "Tel Aviv",
                },
                BankAccountNumber = 9876478,
                CollectionClearance = EnumField.CollectionClearance.yes,
            };
            myhostingUnit3.Area = EnumField.Area.north;
            myhostingUnit3.Type = EnumField.Type.Zimmer;
            myhostingUnit3.HostingUnitKey = 10000550;
            myhostingUnit3.Pool = EnumField.Pool.no;
            myhostingUnit3.Jacuzzi = EnumField.Jacuzzi.no;
            myhostingUnit3.Wifi = EnumField.Wifi.yes;
            myhostingUnit3.Garden = EnumField.Garden.yes;
            myhostingUnit3.ChildrensAttractions = EnumField.ChildrensAttractions.yes;
            myhostingUnit3.HostingUnitName = "best appartment";
            bool[,] Diary3 = new bool[12, 31];

            try
            {
                blAccess.AddHostingUnit(myhostingUnit3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            #endregion
            foreach (var unit in blAccess.GetHostingUnits())
            {
                Console.WriteLine(unit);
            }
            try
            {
                myhostingUnit3.Garden = EnumField.Garden.not_necessary;
                blAccess.UpdateHostingUnit(myhostingUnit3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                blAccess.RemoveHostingUnit(myhostingUnit3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            foreach (var unit in blAccess.GetHostingUnits())
            {
                Console.WriteLine(unit);
            }




            #region add and update orders
            Order order1 = new Order();
            order1.HostingUnitKey = 100000001;
            order1.GuestRequestKey = 10000010;
            order1.Status = EnumField.OrderStatus.closed_deal;
            order1.CreateDate = new DateTime(2020, 10, 12);
            order1.OrderDate = new DateTime(2020, 10, 15);
            order1.OrderKey = 100000152;


            Order order2 = new Order();
            order2.HostingUnitKey = 100000002;
            order2.GuestRequestKey = 10000011;
            order2.Status = EnumField.OrderStatus.answer;
            order2.CreateDate = new DateTime(2020, 08, 16);
            order2.OrderDate = new DateTime(2020, 08, 20);
            order2.OrderKey = 100000153;

            Order order3 = new Order();
            order3.HostingUnitKey = 100000003;
            order3.GuestRequestKey = 10000012;
            order3.Status = EnumField.OrderStatus.closed_deal;
            order3.CreateDate = new DateTime(2020, 06, 16);
            order3.OrderDate = new DateTime(2020, 06, 22);
            order3.OrderKey = 10000154;

            try
            {
                blAccess.AddOrder(order1);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            try
            {
                foreach (var order in blAccess.GetOrders())
                {
                    blAccess.UpdateOrder(order);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            try
            {
                foreach (var order in blAccess.GetOrders())
                    Console.WriteLine(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            #endregion


            //            void grouByNumberOfUnt()
            //            {
            //                IEnumerable<IGrouping<int, HostingUnit>> igr = blAccess.GetGroupedByNumberOfUnts();
            //                foreach (var item in igr)
            //                {
            //                    switch (item.Key)
            //                    {
            //                        case 1:
            //                            Console.WriteLine("1 hosting unit :");
            //                            foreach (HostingUnit h in item)
            //                                Console.WriteLine(h.ToString());
            //                            break;
            //                        case 2:
            //                            Console.WriteLine("2 hosting unit : ");
            //                            foreach (HostingUnit h in item)
            //                                Console.WriteLine(h.ToString());
            //                            break;
            //                        case 3:
            //                            Console.WriteLine("3 hosting unit :");
            //                            foreach (HostingUnit h in item)
            //                                Console.WriteLine(h.ToString());
            //                            break;
            //                        case 4:
            //                            Console.WriteLine("4 hosting unit :");
            //                            foreach (HostingUnit h in item)
            //                                Console.WriteLine(h.ToString());
            //                            break;
            //                        case 5:
            //                            Console.WriteLine("5 hosting unit :");
            //                            foreach (HostingUnit h in item)
            //                                Console.WriteLine(h.ToString());
            //                            break;
            //                        default:
            //                            break;
            //                    }
            //                }
            //            }








            //            //try
            //            //{
            //            //    foreach (var guest in blAccess.GetGuestsWithChildrenAndWantToSmoke())
            //            //        Console.WriteLine("wants to smoke and has kids: " + guest);
            //            //}
            //            //catch (Exception e)
            //            //{
            //            //    Console.WriteLine(e);
            //            //}

            //            //try
            //            //{
            //            //    foreach (var host in blAccess.GetHostingUnitList())
            //            //        Console.WriteLine(blAccess.NumberOfSuccessfullOrders(host));
            //            //}
            //            //catch (Exception e)
            //            //{
            //            //    Console.WriteLine(e);
            //            //}


            //            //try
            //            //{
            //            //    foreach (var bank in blAccess.GetBankInJerusalem())
            //            //        Console.WriteLine("Bank in jerusalem:" + bank);
            //            //}
            //            //catch (Exception e)
            //            //{
            //            //    Console.WriteLine(e);
            //            //}
            //            //#region Grouping Tests
            //            //try
            //            //{
            //            //    foreach (var unit in blAccess.GetGroupedByUnitPopularity())
            //            //    {
            //            //        Console.WriteLine("Units grouped by popularity:");
            //            //        foreach (var item in unit)
            //            //        {
            //            //            Console.WriteLine($"\t{item}");
            //            //        }
            //            //    }
            //            //}
            //            //catch (Exception e)
            //            //{
            //            //    Console.WriteLine(e);
            //            //}
            //            //try
            //            //{
            //            //    foreach (var unit in blAccess.GetGroupedByNoTelevisionAndWifi())
            //            //    {
            //            //        Console.WriteLine("Units grouped by having wifi and tv:");
            //            //        foreach (var item in unit)
            //            //        {
            //            //            Console.WriteLine($"\t{item}");
            //            //        }
            //            //    }
            //            //}
            //            //catch (Exception e)
            //            //{
            //            //    Console.WriteLine(e);
            //            //}
            //            //try
            //            //{
            //            //    foreach (var bank in blAccess.GetGroupedByBankName())
            //            //    {
            //            //        Console.WriteLine("Banks grouped by their names:");
            //            //        foreach (var item in bank)
            //            //        {
            //            //            Console.WriteLine($"\t{item}");
            //            //        }
            //            //    }
            //            //}
            //            //catch (Exception e)
            //            //{
            //            //    Console.WriteLine(e);
            //            //}
            //            //try
            //            //{
            //            //    foreach (var unit in blAccess.GetGroupedByUnitArea())
            //            //    {
            //            //        Console.WriteLine("groups units by their area:");
            //            //        foreach (var item in unit)
            //            //        {
            //            //            Console.WriteLine($"\t{item}");
            //            //        }
            //            //    }
            //            //}
            //            //catch (Exception e)
            //            //{
            //            //    Console.WriteLine(e);
            //            //}
            //            //try
            //            //{
            //            //    foreach (var unit in blAccess.GetGroupedByNumberOfUnits())
            //            //    {
            //            //        Console.WriteLine("groups units by their host:");
            //            //        foreach (var item in unit)
            //            //        {
            //            //            Console.WriteLine($"\t{item}");
            //            //        }
            //            //    }
            //            //}
            //            //catch (Exception e)
            //            //{
            //            //    Console.WriteLine(e);
            //            //}

            //            //try
            //            //{
            //            //    foreach (var guest in blAccess.GetGroupedByNumberOfVacations())
            //            //    {
            //            //        Console.WriteLine("groups guests by their vacations:");
            //            //        foreach (var item in guest)
            //            //        {
            //            //            Console.WriteLine($"\t{item}");
            //            //        }
            //            //    }
            //            //}
            //            //catch (Exception e)
            //            //{
            //            //    Console.WriteLine(e);
            //            //}
            //            //#endregion
            //            //Console.ReadKey();
        }
    }
}



     