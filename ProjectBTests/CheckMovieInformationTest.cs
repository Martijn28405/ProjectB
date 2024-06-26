using ProjectB.Logic;
[TestClass]
// DEZE TEST GEMAAKT DOOR LUCA
public class CheckMovieInformationTest
{
    private CheckMovieInformation checkMovieInformation;
    private List<MovieModel> movies;

    [TestInitialize]
    public void Setup()
    {
        checkMovieInformation = new CheckMovieInformation();
        movies = new List<MovieModel>
        {
            new MovieModel(1,2,"Test1","Test1","Test1","Test1","Test1",135,null),
            new MovieModel(1,1,"F",null,null,"horror",null,150,null),
            new MovieModel(1,1,"Film 3",null,null,null,null,150,null)
        };
        checkMovieInformation.movies = movies;
    }
    [TestMethod]
    public void CheckMovieInformaiton()
    {
        // Arrange
        // Welke input je in de  method stopt van CheckMovieInformaiton
        string movieInformation = "Film 2";

        // Act
        // Welke method je wilt gebruken
        var result = checkMovieInformation.MovieInformation(movieInformation);

        // Assert
        // Eerst in de haakjes krijgt het resultaat en op de tweede plek de gewenste resultaat
        Assert.Equals(result, "horror");


    }
    [TestMethod]
    public void CheckMovieInformaitonIsWright()
    {
        // Arrange
        string movieinformation = "Non-existing Movie";

        // Act
        var result = checkMovieInformation.MovieInformation(movieinformation);

        // Assert
        Assert.Equals(result, "Movie not found");
    }

}