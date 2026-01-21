using Lab5.Domain.Accounts;
using SourceKit.Generators.Builder.Annotations;

namespace Lab5.Application.Abstractions.Queries;

[GenerateBuilder]
public sealed partial record AccountQuery(AccountId[] AccountIds);