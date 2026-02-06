using Lab5.Application.Abstractions;
using Lab5.Application.Abstractions.Queries;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Application.Services;
using Lab5.Domain.Accounts;
using Lab5.Domain.Sessions;
using Lab5.Domain.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BaseTests
{
    [Fact]
    public void SuccessfullyWithDrawMoney()
    {
        // Arrange
        var account = new Account(new AccountId(1), new Money(100), new PinCode("1234"));
        var userSession = new UserSession(UserSessionKey.NextKey, new AccountId(1));

        IPersistenceContext persistenceContext = Substitute.For<IPersistenceContext>();
        persistenceContext.UserSessions.Query(Arg.Any<UserSessionQuery>()).Returns([userSession]);
        persistenceContext.Accounts.Query(Arg.Any<AccountQuery>()).Returns([account]);

        var request = new WithDrawAccountBalance.Request(userSession.Key.Id, 30);

        // Act
        WithDrawAccountBalance.Response response =
            new AccountService(persistenceContext).WithDrawAccountBalance(request);

        // Assert
        WithDrawAccountBalance.Response.Successfully successfully =
            Assert.IsType<WithDrawAccountBalance.Response.Successfully>(response);

        Assert.Equal(70, successfully.Balance);
    }

    [Fact]
    public void FailureWithDrawMoney()
    {
        // Arrange
        var account = new Account(new AccountId(1), new Money(20), new PinCode("1234"));
        var userSession = new UserSession(UserSessionKey.NextKey, new AccountId(1));

        IPersistenceContext persistenceContext = Substitute.For<IPersistenceContext>();
        persistenceContext.UserSessions.Query(Arg.Any<UserSessionQuery>()).Returns([userSession]);
        persistenceContext.Accounts.Query(Arg.Any<AccountQuery>()).Returns([account]);

        var request = new WithDrawAccountBalance.Request(userSession.Key.Id, 30);

        // Act
        WithDrawAccountBalance.Response response =
            new AccountService(persistenceContext).WithDrawAccountBalance(request);

        // Assert
        Assert.IsType<WithDrawAccountBalance.Response.Failure>(response);
    }

    [Fact]
    public void SuccessfullyReplenish()
    {
        // Arrange
        var account = new Account(new AccountId(1), new Money(20), new PinCode("1234"));
        var userSession = new UserSession(UserSessionKey.NextKey, new AccountId(1));

        IPersistenceContext persistenceContext = Substitute.For<IPersistenceContext>();
        persistenceContext.UserSessions.Query(Arg.Any<UserSessionQuery>()).Returns([userSession]);
        persistenceContext.Accounts.Query(Arg.Any<AccountQuery>()).Returns([account]);

        var request = new ReplenishAccountBalance.Request(userSession.Key.Id, 30);

        // Act
        ReplenishAccountBalance.Response response =
            new AccountService(persistenceContext).ReplenishAccountBalance(request);

        // Assert
        ReplenishAccountBalance.Response.Successfully successfully =
            Assert.IsType<ReplenishAccountBalance.Response.Successfully>(response);

        Assert.Equal(50, successfully.Balance);
    }
}