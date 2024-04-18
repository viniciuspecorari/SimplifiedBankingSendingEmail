using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedBankingSendingEmail.Models
{
    public class TransactionNotifyEmail
    {
        public Guid TransactionId { get; set; }
        public string PayerName { get; set; }
        public string PayeeEmail { get; set; }
        public decimal Value { get; set; }
        public DateTime TransactionCreatedAt { get; set; }
    }
}
