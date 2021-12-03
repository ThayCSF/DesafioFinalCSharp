using BlueBank.System.Application.Queries.Interfaces;
using BlueBank.System.Application.Requests;
using BlueBank.System.Application.Responses;
using BlueBank.System.Domain.OrderManagement.Entities;
using BlueBank.System.Domain.Shared.Interfaces;


namespace BlueBank.System.Application.Queries
{
    public class GetCustomerByIdQuery : IGetCustomerByIdQuery
    {
        private IRepository<Customer> _repository;
        public GetCustomerByIdQuery(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        public GetCustomerByIdResponse Handle(GetCustomerByIdRequest request)
        {
            var customer = _repository.GetById(request.Id);
            return new GetCustomerByIdResponse()
            {
                Id = customer.Id,
                Name = customer.Name,
                Telephone = customer.Telephone,
                IsActive = customer.IsActive
            };
        }
    }
}