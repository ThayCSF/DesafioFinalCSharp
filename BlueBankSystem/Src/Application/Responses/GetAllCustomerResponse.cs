using System;


namespace BlueBank.System.Application.Responses
{
    public class GetAllCustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public bool IsActive { get; set;}       
    }
}
