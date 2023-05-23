using System.Diagnostics;
using ProjectB.Logic;

[TestClass]
public class DeleteMovieTest
{
    private DeleteMoviesLogic deleteMoviesLogic;
    private List<MovieModel> movies;
    
    [TestInitialize]
    public void Setup()
    {
        deleteMoviesLogic = new DeleteMoviesLogic();
        movies = new List<MovieModel>
        {
            new MovieModel(1,"Movie 1","Test1","Test1","Test1","Test1",135,null),
            new MovieModel(1,"Movie 2",null,null,null,null,150,null),
            new MovieModel(1,"Movie 3",null,null,null,null,150,null)
        };
        deleteMoviesLogic.movies = movies;
    }
    [TestMethod]
    public void DeleteMovies_ExistingMovie_RemovesMovieFromList()
    {
        // Arrange
        string movieToDelete = "Movie 2";

        // Act
        deleteMoviesLogic.DeleteMovies(movieToDelete);

        // Assert
        CollectionAssert.DoesNotContain(deleteMoviesLogic.movies, movieToDelete);
    }
    [TestMethod]
    public void DeleteMovies_NonExistingMovie_KeepsMovieListUnchanged()
    {
        // Arrange
        string movieToDelete = "Non-existing Movie";

        // Act
        deleteMoviesLogic.DeleteMovies(movieToDelete);

        // Assert
        CollectionAssert.AreEquivalent(movies, deleteMoviesLogic.movies);
    }
    
}