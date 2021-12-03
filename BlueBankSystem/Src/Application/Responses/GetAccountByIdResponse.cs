using System;


namespace BlueBank.System.Application.Responses
{
    public class GetAccountByIdResponse
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string  CustomerName { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
    }
}
