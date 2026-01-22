using Lab5.Application.Abstractions.Queries;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Abstractions.Repositories;

public interface ISystemPasswordRepository
{
    void Add(SystemPassword systemPassword);

    IEnumerable<SystemPassword> Query(SystemPasswordQuery query);
}