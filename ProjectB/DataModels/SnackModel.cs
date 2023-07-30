using System.Text.Json.Serialization;
public class SnackModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("NameFood")]
    public string NameFood { get; set; }
    [JsonPropertyName("Description")]
    public string Description { get; set; }
    [JsonPropertyName("PriceFood")]
    public double PriceFood { get; set; }

    public SnackModel(int id, string nameFood, string description, double priceFood)
    {
        Id = id;
        NameFood = nameFood;
        Description = description;
        PriceFood = priceFood;
    }
}
