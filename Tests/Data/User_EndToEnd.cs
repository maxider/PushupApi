using PushupApi.Data;
using PushupApi.Models;

namespace Tests.Data;

public class User_EndToEnd {
    private readonly AsyncUserRepository repository;

    public User_EndToEnd() {
        repository = new AsyncUserRepository(null);
    }

    [Fact]
    public async Task Test_UserEndToEnd() {
        var saveUser = await repository.Insert(new User() {
            CurrentDayInPlan = 1,
            CurrentPlan      = null,
            MaxPushupCount   = 32,
            Name             = "Kai Uwe"
        });
        var get = await repository.GetById(saveUser.ID);
        Assert.Equal(saveUser, get);
    }
}