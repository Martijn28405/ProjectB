using System.Text.Json.Serialization;
public class ShoppingCartModel
{
    [JsonPropertyName("NameFood")]
    public string NameFood { get; set; }
    [JsonPropertyName("PriceFood")]
    public double PriceFood { get; set; }
    [JsonPropertyName("Amount")]
    public int Amount { get; set; }

    public ShoppingCartModel(string nameFood, double priceFood, int amount)
    {
        NameFood = nameFood;
        PriceFood = priceFood;
        Amount = amount;
    }
}
