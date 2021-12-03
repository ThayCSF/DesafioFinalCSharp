using BlueBank.System.Application.Commands.Interfaces;
using BlueBank.System.Application.Requests;
using BlueBank.System.Application.Responses;
using BlueBank.System.Domain.Shared.Entities;
using BlueBank.System.Domain.Shared.Interfaces;


namespace BlueBank.System.Application.Commands
{
    public class ChangeStatusCommand<TEntity> : IChangeStatusCommand<TEntity> where TEntity : Entity


    {
        private IRepository<TEntity> _repository;

        public ChangeStatusCommand(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public ChangeStatusResponse Handle(ChangeStatusRequest request)
        {
            var entity = _repository.GetById(request.Id);
            entity.IsActive = request.IsActive;
            _repository.Update(entity);
            return new ChangeStatusResponse() { Id = entity.Id, IsActive = entity.IsActive };
        }
    }
}
