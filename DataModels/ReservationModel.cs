using System.Text.Json.Serialization;
public class ReservationModel
{
    [JsonPropertyName("Week")]
    public int Week { get; set; }


    public ReservationModel(int week)
    {
        Week = week;
    }
}