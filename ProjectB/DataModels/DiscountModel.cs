using System.Text.Json.Serialization;
public class DiscountModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("Discription")]
    public string Discription { get; set; }
    [JsonPropertyName("NameFood")]
    public string NameFood { get; set; }
    [JsonPropertyName("PriceFood")]
    public double PriceFood { get; set; }

    public DiscountModel(string discription, string nameFood, double priceFood)
    {
        Discription = discription;
        NameFood = nameFood;
        PriceFood = priceFood;
    }
}