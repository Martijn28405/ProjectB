using System.Text.Json.Serialization;


class ManagerAccountModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("emailAddress")]
    public string EmailAddress { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; }

    public ManagerAccountModel(string emailAddress, string password, string fullName)
    {
        EmailAddress = emailAddress;
        Password = password;
        FullName = fullName;
    }

}