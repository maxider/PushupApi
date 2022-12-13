using PushupApi.Data;
using PushupApi.Factories.PersistentFactories;
using PushupApi.Models;

namespace Tests.Factories;

public class PersistentFactory_EndToEnd {
    private readonly IPersistentFactory factory;
    private readonly IAsyncRepository<User> userRepo;
    private readonly IAsyncRepository<PushupPlan> planRepo;
    private readonly IAsyncRepository<PushupDay> dayRepo;

    public PersistentFactory_EndToEnd() {
        planRepo = new AsyncPlanRepository();
        userRepo = new AsyncUserRepository(planRepo);
        dayRepo = new AsyncDayRepository();
        this.factory = new PersistentFactory(userRepo, planRepo, dayRepo);
    }

    [Fact]
    public async Task CreateUser_ShouldReturnAndPersistUser() {
        var name = "Test name one";
        int day = 10;
        int maxCount = 42;
        var user = await factory.CreateUser(name, maxCount, day, null);
        Assert.Equal(10, user.CurrentDayInPlan);
        Assert.Equal(name, user.Name);
        Assert.Null(user.CurrentPlan);
        Assert.NotEqual(0, user.ID);
        var get = await userRepo.GetById(user.ID);
        Assert.Equal(user, get);
    }

    [Fact]
    public async Task CreatePlan_ShouldReturnAndPersistPlan() {
        var day = await factory.CreateDay(.25f, TimeSpan.FromSeconds(3));
        var plan = await factory.CreatePlan(new[] { day });
        Assert.NotEqual(0, plan.ID);
        var get = await planRepo.GetById(plan.ID);
        Assert.Equal(get.Days.First(), day);
    }

    [Fact]
    public async Task CreateDay_ShouldReturnAndPersistDay() {
        var percentage = 0.25f;
        var interval = TimeSpan.FromSeconds(3);
        var day = await factory.CreateDay(percentage, interval);
        var get = await dayRepo.GetById(day.ID);
        Assert.NotNull(get);
        Assert.NotEqual(0, get.ID);
        Assert.Equal(percentage, get.Percentage);
        Assert.Equal(interval, get.Interval);
        Assert.False(get.IsTestDay);
    }

    [Fact]
    public async Task InsertDayInPlan_ShouldPersistDay() {
        var day = await factory.CreateDay(.25f, TimeSpan.FromSeconds(6));
        var get_day = await dayRepo.GetById(day.ID);
        Assert.Equal(day, get_day);
        var plan = await factory.CreatePlan(new[] { day });
        var get_plan = await planRepo.GetById(plan.ID);
        Assert.Equal(get_day, get_plan.Days.First());
        Assert.Equal(get_plan, get_plan);
    }

    [Fact]
    public async Task FullChain_ShouldPersistEverything() {
        var day = await factory.CreateDay(.25f, TimeSpan.FromSeconds(5));
        Assert.NotEqual(0, day.ID);
        var plan = await factory.CreatePlan(new[] { day });
        Assert.NotEqual(0, plan.ID);
        var user = await factory.CreateUser("Uwe kai Dude", 154, 42, plan);
        Assert.NotEqual(0, user.ID);

        var get_user = await userRepo.GetById(user.ID);
        Assert.Equal(plan, get_user.CurrentPlan);
        Assert.Equal(day, get_user.CurrentPlan?.Days.First());
    }
}