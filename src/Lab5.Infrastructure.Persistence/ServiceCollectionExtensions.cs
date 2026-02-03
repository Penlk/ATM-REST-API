using Lab5.Application.Abstractions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Sessions;
using Lab5.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Infrastructure.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(
        this IServiceCollection collection,
        string systemPassword)
    {
        collection.AddScoped<IPersistenceContext, PersistenceContext>();

        collection.AddSingleton<IAccountRepository, AccountRepository>();
        collection.AddSingleton<IAdminSessionRepository, AdminSessionRepository>();
        collection.AddSingleton<IUserSessionRepository, UserSessionRepository>();
        collection.AddSingleton<IOperationHistoryRepository, OperationHistoryRepository>();
        collection.AddSingleton<ISystemPasswordRepository, SystemPasswordRepository>(_ =>
        {
            var repository = new SystemPasswordRepository();
            repository.Add(new SystemPassword(systemPassword));

            return repository;
        });

        return collection;
    }
}