using BlueBank.System.Domain.Shared.Entities;
using System;


namespace BlueBank.System.Domain.OrderManagement.Entities
{
    public class Account : Entity
    {
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal Balance { get; set; }
        public Account(string customerName, Guid customerId, decimal balance)
        {
            CustomerId = customerId;
            Balance = balance;
            CustomerName = customerName;
        }
    }
}
