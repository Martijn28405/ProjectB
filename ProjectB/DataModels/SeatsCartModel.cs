namespace ProjectB.DataModels;
using System.Text.Json.Serialization;
public class SeatsCartModel
{
    [JsonPropertyName("SeatColor")]
    public string SeatColor { get; set; }
    [JsonPropertyName("TotalPrice")]
    public double TotalPrice { get; set; }

    public SeatsCartModel(string seatColor, double totalPrice)
    {
        SeatColor = seatColor;
        TotalPrice = totalPrice;
    }
}