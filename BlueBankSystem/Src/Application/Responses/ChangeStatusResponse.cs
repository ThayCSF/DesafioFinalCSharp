using System;


namespace BlueBank.System.Application.Responses
{
    public class ChangeStatusResponse    
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
