using PushupApi.Models;

namespace PushupApi.Factories.PersistentFactories;

public interface IPersistentFactory {
    public Task<User> CreateUser(string name, int maxCount, int curDay, PushupPlan? curPlan);
    public Task<PushupDay> CreateDay(float percentage, TimeSpan interval, bool isTestDay = false);
    public Task<PushupPlan> CreatePlan(IEnumerable<PushupDay> days);
}