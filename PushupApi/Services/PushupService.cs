using PushupApi.Data;
using PushupApi.Models;

namespace PushupApi.Services;

public class PushupService : IPushupService {
    private readonly IAsyncRepository<User> userRepo;
    private readonly IAsyncRepository<PushupPlan> planRepo;
    private readonly IRounder rounder;

    public PushupService(IAsyncRepository<User> userRepo, IAsyncRepository<PushupPlan> planRepo, Rounder rounder) {
        this.userRepo = userRepo;
        this.planRepo = planRepo;
        this.rounder  = rounder;
    }

    public int ComputeAmountForUser(User user, PushupDay day) {
        float amount = user.MaxPushupCount * day.Percentage;
        return rounder.Round(amount);
    }
}