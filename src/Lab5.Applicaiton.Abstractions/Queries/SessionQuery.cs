using Lab5.Domain.Sessions;
using SourceKit.Generators.Builder.Annotations;

namespace Lab5.Applicaiton.Abstractions.Queries;

[GenerateBuilder]
public sealed partial record SessionQuery(SessionId[] SessionIds);