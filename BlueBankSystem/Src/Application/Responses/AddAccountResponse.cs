using System;


namespace BlueBank.System.Application.Responses
{
    public class AddAccountResponse
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal Balance { get; set; }
    }
}
