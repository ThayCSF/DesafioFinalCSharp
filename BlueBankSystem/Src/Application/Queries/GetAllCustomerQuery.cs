using BlueBank.System.Application.Queries.Interfaces;
using BlueBank.System.Application.Requests;
using BlueBank.System.Application.Responses;
using BlueBank.System.Domain.OrderManagement.Entities;
using BlueBank.System.Domain.Shared.Interfaces;
using BlueBank.System.Domain.Shared.Predicates;
using System.Linq;


namespace BlueBank.System.Application.Queries
{
    public class GetAllCustomerQuery : IGetAllCustomerQuery
    {
        private readonly IRepository<Customer> _repository;
        public GetAllCustomerQuery(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        public IQueryable<GetAllCustomerResponse> Handle(GetAllCustomerRequest request)
        {
            var predicate = PredicateBuilder.New<Customer>();
            if (request.IsActive != null) predicate = predicate.And(c => c.IsActive == request.IsActive);            
            return _repository
                .Get(predicate)
                .Select(c => new GetAllCustomerResponse()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Telephone = c.Telephone,
                    IsActive = c.IsActive
                });                        
        }    
    }
}
