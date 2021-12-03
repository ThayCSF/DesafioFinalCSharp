using BlueBank.System.Application.Requests;
using BlueBank.System.Application.Responses;
using BlueBank.System.Domain.Shared.Handlers;


namespace BlueBank.System.Application.Queries.Interfaces
{
    public interface IGetAccountByIdQuery : IHandler<GetAccountByIdRequest, GetAccountByIdResponse>
    {
    }
}
