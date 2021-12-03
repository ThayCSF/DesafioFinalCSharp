using System;


namespace BlueBank.System.Application.Requests
{
    public class AddOperationRequest
    {
        public Guid AccountOrigin { get; set; }
        public Guid AccountRecipient { get; set; }        
        public decimal Value { get; set; }
    }
}
