using BlueBank.System.Application.Requests;
using BlueBank.System.Application.Responses;
using BlueBank.System.Domain.Shared.Handlers;


namespace BlueBank.System.Application.Commands.Interfaces
{
    public interface IRemoveAccountByIdCommand : IHandler<RemoveAccountByIdRequest, RemoveAccountByIdResponse>
    {       
    }
}
