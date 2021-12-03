using System;


namespace BlueBank.System.Application.Requests
{
    public class GetAccountByIdRequest
    {
        public GetAccountByIdRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; } 
    }

}
