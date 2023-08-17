namespace ProjectB.DataModels;
using System.Text.Json.Serialization;
public class SeatsCartModel
{
    [JsonPropertyName("Seat")]
    public List<string> Seat { get; set; }
    [JsonPropertyName("TotalPrice")]
    public double TotalPrice { get; set; }
    [JsonPropertyName("MovieName")]
    public string MovieName { get; set; }
    public SeatsCartModel(List<string> seat, string movieName, double totalPrice)
    {
        Seat = seat;
        MovieName = movieName;
        TotalPrice = totalPrice;
    }
}
