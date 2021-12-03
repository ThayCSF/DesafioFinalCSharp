using System;


namespace BlueBank.System.Application.Requests
{
    public class RemoveAccountByIdRequest
    {
        public RemoveAccountByIdRequest(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
