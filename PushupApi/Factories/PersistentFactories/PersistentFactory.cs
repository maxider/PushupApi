using PushupApi.Data;
using PushupApi.Models;
using UltraLiteDB;

namespace PushupApi.Factories.PersistentFactories;

public class PersistentFactory : IPersistentFactory {
    private readonly IAsyncRepository<User> userRepository;
    private readonly IAsyncRepository<PushupPlan> planRepository;
    private readonly IAsyncRepository<PushupDay> dayRepository;

    public PersistentFactory(IAsyncRepository<User> userRepository, IAsyncRepository<PushupPlan> planRepository, IAsyncRepository<PushupDay> dayRepository) {
        this.userRepository = userRepository;
        this.planRepository = planRepository;
        this.dayRepository = dayRepository;
    }

    public async Task<User> CreateUser(string name, int maxCount, int curDay, PushupPlan? curPlan) {
        var user = new User() {
            Name = name,
            CurrentDayInPlan = curDay,
            CurrentPlan = curPlan,
            MaxPushupCount = maxCount
        };

        return await userRepository.Insert(user);
    }

    public async Task<PushupDay> CreateDay(float percentage, TimeSpan interval, bool isTestDay = false) {
        var day = new PushupDay() {
            Percentage = percentage,
            Interval = interval,
            IsTestDay = isTestDay
        };

        return await dayRepository.Insert(day);
    }

    public async Task<PushupPlan> CreatePlan(IEnumerable<PushupDay> days) {
        var plan = new PushupPlan() {
            Days = days.ToList()
        };

        return await planRepository.Insert(plan);
    }
}