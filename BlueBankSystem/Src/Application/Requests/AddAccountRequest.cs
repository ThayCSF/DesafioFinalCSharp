using System;


namespace BlueBank.System.Application.Requests
{
    public class AddAccountRequest
    {
        public Guid CustomerId { get; set; }
        public decimal Balance { get; set; }
    }
}
