using PushupApi.Data;
using PushupApi.Models;

namespace PushupApi.Services;

public class PushupService : IPushupService {
    private readonly IPushupRepository repository;
    private readonly IRounder rounder;

    public PushupService(IPushupRepository repository, Rounder rounder) {
        this.repository = repository;
        this.rounder = rounder;
    }

    public int ComputeAmountForUser(User user, PushupDay day) {
        float amount = user.MaxPushupCount * day.Percentage;
        return rounder.Round(amount);
    }
}