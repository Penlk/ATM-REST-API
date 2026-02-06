using Lab5.Application.Abstractions;
using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Contracts.SystemPasswords;
using Lab5.Application.Contracts.SystemPasswords.Operations;
using Lab5.Domain.Sessions;

namespace Lab5.Application.Services;

public class SystemPasswordService : ISystemPasswordService
{
    private readonly IPersistenceContext _context;

    public SystemPasswordService(IPersistenceContext context)
    {
        _context = context;
    }

    public CreateSystemPassword.Response CreateSystemPassword(CreateSystemPassword.Request request)
    {
        var adminSessionKey = new AdminSessionKey(request.AdminSession);
        AdminSessionQuery adminSessionQuery = new AdminSessionQuery.Builder().WithSessionKey(adminSessionKey).Build();

        AdminSession? admin = _context.AdminSessions.Query(adminSessionQuery).SingleOrDefault();

        if (admin is null)
        {
            return new CreateSystemPassword.Response.Failure("Could not find admin session");
        }

        _context.SystemPasswords.Add(new SystemPassword(request.Password));

        return new CreateSystemPassword.Response.Successfully();
    }
}