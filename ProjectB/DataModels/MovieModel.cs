using System.Text.Json.Serialization;
public class MovieModel
{
    [JsonPropertyName("Week")]
    public int Week { get; set; }
    [JsonPropertyName("Movie Title")]
    public string MovieTitle { get; set; }
    [JsonPropertyName("Director")]
    public string Director { get; set; }
    [JsonPropertyName("Information")]
    public string Information { get; set; }
    [JsonPropertyName("Genre")]
    public string Genre { get; set; }
    [JsonPropertyName("Target Audience")]
    public string TargetAudience { get; set; }
    [JsonPropertyName("Play Time In Minutes")]
    public int PlayTimeInMinutes { get; set; }
    [JsonPropertyName("Times Playing")]
    public List<DateTime> StartTime { get; set; }

    public MovieModel(int week,
        string movietitle,
        string director,
        string information,
        string genre,
        string targetAudience,
        int playTimeInMinutes,
        List<DateTime> startTime)
    {
        Week = week;
        MovieTitle = movietitle;
        Director = director;
        Information = information;
        Genre = genre;
        TargetAudience = targetAudience;
        PlayTimeInMinutes = playTimeInMinutes;
        StartTime = startTime;
    }
}