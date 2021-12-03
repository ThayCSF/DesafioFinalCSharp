using BlueBank.System.Application.Commands.Interfaces;
using BlueBank.System.Application.Requests;
using BlueBank.System.Application.Responses;
using BlueBank.System.Domain.OrderManagement.Entities;
using BlueBank.System.Domain.Shared.Interfaces;


namespace BlueBank.System.Application.Commands
{
    public class AddAccountCommand : IAddAccountCommand    
    {
        private readonly IRepository<Account> _repository;
        private readonly IRepository<Customer> _customerRepository;
        public AddAccountCommand(IRepository<Account> repository, IRepository<Customer> customerRepository)
        {
            _repository = repository;
            _customerRepository = customerRepository;
        }
        public AddAccountResponse Handle(AddAccountRequest request)
        {
            var customer = _customerRepository.GetById(request.CustomerId);
            var account = new Account(customer.Name, request.CustomerId, request.Balance );
            _repository.Add(account);
            
            return new AddAccountResponse()
            {
                Id = account.Id,
                CustomerId = account.CustomerId,
                CustomerName = customer.Name,
                Balance = account.Balance
            };
            
        }
    }
}
