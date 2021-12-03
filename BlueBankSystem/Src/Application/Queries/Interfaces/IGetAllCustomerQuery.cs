using BlueBank.System.Application.Requests;
using BlueBank.System.Application.Responses;
using BlueBank.System.Domain.Shared.Handlers;
using System.Linq;


namespace BlueBank.System.Application.Queries.Interfaces
{
    public interface IGetAllCustomerQuery : IHandler<GetAllCustomerRequest, IQueryable<GetAllCustomerResponse>>
    {
    }
}
