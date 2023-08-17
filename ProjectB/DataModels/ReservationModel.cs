using System.Text.Json.Serialization;
public class ReservationModel
{
    [JsonPropertyName("Seat")]
    public List<string> Seat { get; set; }

    [JsonPropertyName("EmailAddress")]
    public string EmailAddress { get; set; }
    [JsonPropertyName("Movie")]
    public string Movie { get; set; }
    [JsonPropertyName("Start Time")]
    public DateTime StartTime { get; set; }
    [JsonPropertyName("Duration")]
    public int Duration { get; set; }

    public ReservationModel(List<string> seat, string emailAddress, string movie, DateTime startTime, int duration)
    {
        Seat = seat;
        EmailAddress = emailAddress;
        Movie = movie;
        StartTime = startTime;
        Duration = duration;
    }
}
