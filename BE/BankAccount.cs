using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BankAccount
    {
        public int bankNumber { get; set; }
        
        public string bankname { get; set; }
        public int money { get; set; }
        public int branchNumber { get; set; }

        public string branchAddress { get; set; }

        public string BankCity { get; set; }

        public int BankAccountNumber { get; set; }
        
        public override string ToString()
        {
            return " Bank Number: " + bankNumber + " bank name: " + bankname + " money: " + money + " branch number: " + branchNumber + " branchAddress: " + branchAddress + " BankCity:" + BankCity + " BankAccountNumber: " + BankAccountNumber;
        }

    }
}
