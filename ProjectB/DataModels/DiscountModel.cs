using System.Text.Json.Serialization;
public class DiscountModel
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }
    [JsonPropertyName("Discription")]
    public string Discription { get; set; }
    [JsonPropertyName("NameFood")]
    public string NameFood { get; set; }
    [JsonPropertyName("PriceFood")]
    public double PriceFood { get; set; }

    public DiscountModel(int id, string discription, string nameFood, double priceFood)
    {
        Id = id;
        Discription = discription;
        NameFood = nameFood;
        PriceFood = priceFood;
    }
}