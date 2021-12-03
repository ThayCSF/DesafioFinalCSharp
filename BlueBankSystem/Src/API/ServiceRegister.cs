using BlueBank.System.Application.Commands;
using BlueBank.System.Application.Commands.Interfaces;
using BlueBank.System.Application.Queries;
using BlueBank.System.Application.Queries.Interfaces;
using BlueBank.System.Domain.Shared.Interfaces;
using BlueBank.System.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace BlueBank.System.Services.API
{
    public class ServiceRegister
    {
        public static void Register(IServiceCollection services)
        {
            RegisterQueries(services);
            RegisterRepositories(services);
            RegisterCommands(services);
        }
        public static void RegisterCommands(IServiceCollection services)
        {
            services.AddScoped<IUpdateCustomerCommand, UpdateCustomerCommand>();
            services.AddScoped<IUpdateAccountCommand, UpdateAccountCommand>();
            services.AddScoped<IAddCustomerCommand, AddCustomerCommand>();
            services.AddScoped<IAddAccountCommand, AddAccountCommand>();
            services.AddScoped<IRemoveCustomerByIdCommand, RemoveCustomerByIdCommand>();
            services.AddScoped<IRemoveAccountByIdCommand, RemoveAccountByIdCommand>();
            services.AddScoped<IAddOperationCommand, AddOperationCommand>();
            services.AddScoped(typeof(IChangeStatusCommand<>), typeof(ChangeStatusCommand<>));
        }
        public static void RegisterQueries(IServiceCollection services)
        {
            services.AddScoped<IGetCustomerByIdQuery, GetCustomerByIdQuery>();
            services.AddScoped<IGetAccountByIdQuery, GetAccountByIdQuery>();
            services.AddScoped<IGetAllCustomerQuery, GetAllCustomerQuery>();           
            services.AddScoped<IGetAllAccountQuery, GetAllAccountQuery>();
            services.AddScoped<IGetAllOperationQuery, GetAllOperationQuery>();
            
        }
        public static void RegisterRepositories(IServiceCollection services)
        {            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
