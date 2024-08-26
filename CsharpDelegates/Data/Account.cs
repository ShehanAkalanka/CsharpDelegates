using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpDelegates.Data
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public decimal AvailableBalance { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public override string ToString()
        {
            return $"Id:{Id} AccountNumber: {AccountNumber} Available Balance {AvailableBalance}";
        }
    }
}
