using System;


namespace BlueBank.System.Application.Responses
{
    public class GetAllAccountResponse
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
    }
}
