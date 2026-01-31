using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Domain.Sessions;

namespace Lab5.Infrastructure.Persistence.Repositories;

public class SystemPasswordRepository : ISystemPasswordRepository
{
    private readonly HashSet<SystemPassword> _data = new HashSet<SystemPassword>();

    public void Add(SystemPassword systemPassword)
    {
        _data.Add(systemPassword);
    }

    public IEnumerable<SystemPassword> Query(SystemPasswordQuery query)
    {
        return query.Passwords.Where(x => _data.Contains(x));
    }
}