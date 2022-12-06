using PushupApi.Data;
using PushupApi.Models;
using PushupApi.Services;

namespace Tests;

public class PushupServiceTests {
    [Fact]
    public void AmountComputation() {
        var repo = new MockRepository();
        Rounder rounder = new Rounder();
        PushupService service = new PushupService(repo, rounder);

        var maxPushupCount = 24;
        var percentage = .25f;
        User user = new User() { MaxPushupCount = maxPushupCount };
        PushupDay day = new PushupDay() { Percentage = percentage };

        var result = service.ComputeAmountForUser(user, day);
        Assert.Equal(rounder.Round(maxPushupCount * percentage), result);
    }
}

public class MockRepository : IPushupRepository {
}