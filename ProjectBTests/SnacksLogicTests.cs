namespace ProjectBTests;
using ProjectB.Logic;
[TestClass]
public class DeleteSnackTest
{
    DeleteSnackLogic deleteSnackLogic;
    private List<SnackModel> snacks;

    [TestInitialize]
    public void Setup()
    {
        deleteSnackLogic = new DeleteSnackLogic();
        snacks = new List<SnackModel>
        {
            new SnackModel("1",0.5),
            new SnackModel("2",1.5),
            new SnackModel("3",2.5)
        };
        deleteSnackLogic.snacks = snacks;
    }
    [TestMethod]
    public void DeleteMovies_ExistingMovie_RemovesMovieFromList()
    {
        // Arrange
        string SnackToDelete = "1";

        // Act
        deleteSnackLogic.DeleteSnack(SnackToDelete);

        // Assert
        CollectionAssert.DoesNotContain(deleteSnackLogic.snacks, SnackToDelete);
    }
    [TestMethod]
    public void DeleteMovies_NonExistingMovie_KeepsMovieListUnchanged()
    {
        // Arrange
        string movieToDelete = "Non-existing Movie";

        // Act
        deleteSnackLogic.DeleteSnack(movieToDelete);

        // Assert
        CollectionAssert.AreEquivalent(snacks, deleteSnackLogic.snacks);
    }
}