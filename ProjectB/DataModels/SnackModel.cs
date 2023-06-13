using System.Text.Json.Serialization;
public class SnackModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("NameFood")]
    public string NameFood { get; set; }
    [JsonPropertyName("Descreption")]
    public string Description { get; set; }
    [JsonPropertyName("PriceFood")]

    public double PriceFood { get; set; }

    public SnackModel(string nameFood, string description, double priceFood)
    {

        NameFood = nameFood;
        Description = description;
        PriceFood = priceFood;
    }
}