using Lab5.Application.Contracts.SystemPasswords.Operations;

namespace Lab5.Application.Contracts.SystemPasswords;

public interface ISystemPasswordService
{
    CreateSystemPassword.Response CreateSystemPassword(CreateSystemPassword.Request request);
}