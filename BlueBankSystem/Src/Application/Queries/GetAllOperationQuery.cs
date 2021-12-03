using BlueBank.System.Application.Queries.Interfaces;
using BlueBank.System.Application.Requests;
using BlueBank.System.Application.Responses;
using BlueBank.System.Domain.OrderManagement.Entities;
using BlueBank.System.Domain.Shared.Interfaces;
using BlueBank.System.Domain.Shared.Predicates;
using System.Linq;


namespace BlueBank.System.Application.Queries
{
    public class GetAllOperationQuery : IGetAllOperationQuery
    {
        private readonly IRepository<Operation> _operationrepository;

        public GetAllOperationQuery(IRepository<Operation> operationrepository)
        {
            _operationrepository = operationrepository;
        }
    
               
        public IQueryable<GetAllOperationResponse> Handle(GetAllOperationRequest request)
        {
            var predicate = PredicateBuilder.New<Operation>();


            if (request.IsActive != null) predicate = predicate.And(operation => operation.IsActive == request.IsActive);
            return _operationrepository


                .Get(predicate)
                .Select(operation => new GetAllOperationResponse()
                {
                    Id = operation.Id,
                    AccountOrigin = operation.AccountOrigin,
                    AccountRecipient = operation.AccountRecipient,
                    Date = operation.Date,
                    Value = operation.Value
                });
        }
    }    
}
