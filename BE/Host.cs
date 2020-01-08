namespace BE
{
    public class Host
    {

        public int BankAccountNumber { get; set; }
        public int hostKey { get; set; }

        public string FamilyName { get; set; }

        public string PrivateName { get; set; }

        public string phoneNumber { get; set; }

        public string mail { get; set; }

        public BankAccount bankAccount { get; set; }

        public EnumField.CollectionClearance CollectionClearance { get; set; }

        public override string ToString()

        {

            return " host key:" + hostKey + " family name: " + FamilyName + " private name: " + PrivateName + " phone number: " + phoneNumber + " mail: " + mail + " bank account details: " + bankAccount + " collection clearance: " + CollectionClearance;

        }
    }
}
