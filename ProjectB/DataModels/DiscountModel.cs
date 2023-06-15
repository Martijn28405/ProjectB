using System.Text.Json.Serialization;
public class DiscountModel
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }
    [JsonPropertyName("Description")]
    public string Description { get; set; }
    [JsonPropertyName("NameFood")]
    public string NameFood { get; set; }
    [JsonPropertyName("PriceFood")]
    public double PriceFood { get; set; }

    public DiscountModel(int id, string description, string nameFood, double priceFood)
    {
        Id = id;
        Description = description;
        NameFood = nameFood;
        PriceFood = priceFood;
    }
}