using System.Text.Json.Serialization;
public class SnackModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("NameFood")]
    public string NameFood { get; set; }
    [JsonPropertyName("PriceFood")]
    public double PriceFood { get; set; }

    public SnackModel(string nameFood, double priceFood)
    {
        NameFood = nameFood;
        PriceFood = priceFood;
    }
}