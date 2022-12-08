namespace PushupApi.Models;

public class PushupPlan {
    public int ID { get; set; }
    public List<PushupDay> Days { get; set; }
}