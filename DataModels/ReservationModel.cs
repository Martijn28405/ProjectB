using System.Text.Json.Serialization;
public class ReservationModel
{
    [JsonPropertyName("Row")]
    public int Row { get; set; }

    [JsonPropertyName("Seat")]
    public int Seat { get; set; }
    [JsonPropertyName("EmailAddress")]
    public string EmailAddress { get; set; }
    [JsonPropertyName("Movie")]
    public string Movie { get; set; }
    [JsonPropertyName("Time")]
    public int Time { get; set; }

    public ReservationModel(int row, int seat, string emailAddress, string movie, int time)
    {
        Row = row;
        Seat = seat;
        EmailAddress = emailAddress;
        Movie = movie;
        Time = time;
    }
}