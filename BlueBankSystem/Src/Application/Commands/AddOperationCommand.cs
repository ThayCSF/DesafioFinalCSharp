using BlueBank.System.Application.Commands.Interfaces;
using BlueBank.System.Application.Requests;
using BlueBank.System.Application.Responses;
using BlueBank.System.Domain.OrderManagement.Entities;
using BlueBank.System.Domain.Shared.Interfaces;
using System;


namespace BlueBank.System.Application.Commands
{
    public class AddOperationCommand : IAddOperationCommand
    {
        private readonly IRepository<Account> _repository;
        private readonly IRepository<Operation> _operationRepository;
        public AddOperationCommand(IRepository<Account> repository, IRepository<Operation> operationRepository)
        {
            _repository = repository;
            _operationRepository = operationRepository;
        }

        public AddOperationResponse Handle(AddOperationRequest request)
        {
            var accountOrigin = _repository.GetById(request.AccountOrigin);
            var accountRecipient = _repository.GetById(request.AccountRecipient);

            if (!accountOrigin.IsActive) throw new ArgumentException("A conta está inativo");
            if (!accountRecipient.IsActive) throw new ArgumentException("A conta está inativo");
            if (accountOrigin.Balance < request.Value ) throw new ArgumentException("Sem Saldo suficiente");

            accountOrigin.Balance = accountOrigin.Balance - request.Value;
            accountRecipient.Balance = accountRecipient.Balance + request.Value;

            _repository.Update(accountOrigin);
            _repository.Update(accountRecipient);
            var operation = new Operation(        
               request.AccountOrigin,
               request.AccountRecipient,
               DateTime.Now,
               request.Value
            );
            _operationRepository.Add(operation);

            return new AddOperationResponse()
            {
                Id = operation.Id,
                AccountOrigin = operation.AccountOrigin,
                AccountRecipient = operation.AccountRecipient,
                Date = operation.Date,
                Value = operation.Value
            };
        }
    }
}
