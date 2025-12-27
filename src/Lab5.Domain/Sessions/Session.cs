using Lab5.Domain.ValueObjects;

namespace Lab5.Domain.Sessions;

public class Session
{
    public PinCode PinCode { get; }

    public SessionId Id { get; }
}