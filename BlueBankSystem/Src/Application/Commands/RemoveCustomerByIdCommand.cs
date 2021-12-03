using BlueBank.System.Application.Commands.Interfaces;
using BlueBank.System.Application.Requests;
using BlueBank.System.Application.Responses;
using BlueBank.System.Domain.OrderManagement.Entities;
using BlueBank.System.Domain.Shared.Interfaces;
using BlueBank.System.Domain.Shared.Commands;


namespace BlueBank.System.Application.Commands
{
    public class RemoveCustomerByIdCommand : CommandBase<Customer>, IRemoveCustomerByIdCommand
    {    
        public RemoveCustomerByIdCommand(IRepository<Customer> repository) : base (repository)
        {            
        }
        public RemoveCustomerByIdResponse Handle(RemoveCustomerByIdRequest request)
        {
            var customer = repository.GetById(request.Id);
            customer.IsActive = false;
            repository.Update(customer);
            return new RemoveCustomerByIdResponse() { IsActive = customer.IsActive};
        }        
    }
}
