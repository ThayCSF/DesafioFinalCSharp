using System;


namespace BlueBank.System.Application.Requests
{
    public class UpdateCustomerRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
    }
}
