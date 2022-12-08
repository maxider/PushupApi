using PushupApi.Models;
using PushupApi.Services;

namespace Tests;

public class PushupServiceTests {
    [Fact]
    public void AmountComputation() {
        var repo = new MockRepository();
        Rounder rounder = new Rounder();
        PushupService service = new PushupService(repo,repo, rounder);

        var maxPushupCount = 24;
        var percentage = .25f;
        User user = new User() { MaxPushupCount         = maxPushupCount };
        PushupPlan pushupPlan = new PushupPlan() { Days = new List<PushupDay>() { new PushupDay() { IsTestDay = false, Percentage = .25f } } };

        var result = service.ComputeAmountForUser(user, pushupPlan.Days.First());
        Assert.Equal(rounder.Round(maxPushupCount * percentage), result);
    }
}