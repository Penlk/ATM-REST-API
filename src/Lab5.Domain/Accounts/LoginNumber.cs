using System.ComponentModel.DataAnnotations;

namespace Lab5.Domain.Accounts;

public sealed record LoginNumber([Length(6, 6)] string Number);