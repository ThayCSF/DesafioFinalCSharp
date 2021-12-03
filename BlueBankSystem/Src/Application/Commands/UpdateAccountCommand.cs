using BlueBank.System.Application.Commands.Interfaces;
using BlueBank.System.Application.Requests;
using BlueBank.System.Application.Responses;
using BlueBank.System.Domain.OrderManagement.Entities;
using BlueBank.System.Domain.Shared.Commands;
using BlueBank.System.Domain.Shared.Interfaces;
using System;


namespace BlueBank.System.Application.Commands
{
    public class UpdateAccountCommand : CommandBase<Account>, IUpdateAccountCommand
    {
        public UpdateAccountCommand(IRepository<Account> repository) : base(repository)
        {
        }
        public UpdateAccountResponse Handle(UpdateAccountRequest request)
        {
            var account = repository.GetById(request.Id);
            if (!account.IsActive) throw new ArgumentException("A conta está inativo");
            
            account.Balance = request.Balance;
            repository.Update(account);

            return new UpdateAccountResponse()
            {
                Id = account.Id,
                CustomerId = account.CustomerId,
                Balance = account.Balance
            };
        }
    }
}
