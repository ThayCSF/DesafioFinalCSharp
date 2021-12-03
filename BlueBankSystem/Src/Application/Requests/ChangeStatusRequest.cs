using System;


namespace BlueBank.System.Application.Requests
{
    public class ChangeStatusRequest
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
