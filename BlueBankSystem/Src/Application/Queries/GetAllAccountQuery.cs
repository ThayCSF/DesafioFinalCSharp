using BlueBank.System.Application.Queries.Interfaces;
using BlueBank.System.Application.Requests;
using BlueBank.System.Application.Responses;
using BlueBank.System.Domain.OrderManagement.Entities;
using BlueBank.System.Domain.Shared.Interfaces;
using BlueBank.System.Domain.Shared.Predicates;
using System.Linq;


namespace BlueBank.System.Application.Queries
{
    public class GetAllAccountQuery : IGetAllAccountQuery
    {
        private readonly IRepository<Account> repository;
        public GetAllAccountQuery(IRepository<Account> repository)
        {
            this.repository = repository;
        }
        public IQueryable<GetAllAccountResponse> Handle(GetAllAccountRequest request)
        {
            var predicate = PredicateBuilder.New<Account>();
            return repository
                .Get()
                .Select(a => new GetAllAccountResponse
                {
                    Id = a.Id,
                    CustomerId = a.CustomerId,
                    CustomerName = a.CustomerName,
                    Balance = a.Balance,
                    IsActive = a.IsActive

                });
        }
    }
}
