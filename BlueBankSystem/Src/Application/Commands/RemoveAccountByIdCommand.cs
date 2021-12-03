using BlueBank.System.Application.Commands.Interfaces;
using BlueBank.System.Application.Requests;
using BlueBank.System.Application.Responses;
using BlueBank.System.Domain.OrderManagement.Entities;
using BlueBank.System.Domain.Shared.Interfaces;
using BlueBank.System.Domain.Shared.Commands;


namespace BlueBank.System.Application.Commands
{
    public class RemoveAccountByIdCommand : CommandBase<Account>, IRemoveAccountByIdCommand
    {
        public RemoveAccountByIdCommand(IRepository<Account> repository) : base(repository)
        {
        }
        public RemoveAccountByIdResponse Handle(RemoveAccountByIdRequest request)
        {
            var account = repository.GetById(request.Id);
            account.IsActive = false;
            repository.Update(account);
            return new RemoveAccountByIdResponse() { IsActive = account.IsActive };
        }
    }
}
