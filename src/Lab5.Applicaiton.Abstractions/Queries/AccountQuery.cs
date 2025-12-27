using Lab5.Domain.Accounts;
using SourceKit.Generators.Builder.Annotations;

namespace Lab5.Applicaiton.Abstractions.Queries;

[GenerateBuilder]
public sealed partial record AccountQuery(AccountId[] AccountIds);