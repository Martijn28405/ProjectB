namespace ProjectBTests;
using ProjectB.Logic;
[TestClass]
public class AccountsLogicTests
{
    [TestMethod]
    public void TestValidateName_WithInvalidName_ReturnsFalse()
    {
        ValidationsLogic validationsLogic = new ValidationsLogic();

        bool result = validationsLogic.ValidateName("John");

        Assert.AreEqual(false, result);
    }

    [TestMethod]
    public void TestValidateName_WithValidName_ReturnsTrue()
    {
        ValidationsLogic validationsLogic = new ValidationsLogic();

        bool result = validationsLogic.ValidateName("John Doe");

        Assert.AreEqual(true, result);
    }

    [TestMethod]
    public void TestValidateEmail_WithInvalidEmail_ReturnsFalse()
    {
        ValidationsLogic validationsLogic = new ValidationsLogic();

        bool result = validationsLogic.ValidateEmail("johndoehotmailcom");

        Assert.AreEqual(false, result);
    }

    [TestMethod]
    public void TestValidateEmail_WithValidEmail_ReturnsTrue()
    {
        ValidationsLogic validationsLogic = new ValidationsLogic();

        bool result = validationsLogic.ValidateEmail("johndoe@hotmail.com");

        Assert.AreEqual(true, result);
    }

    [TestMethod]
    public void TestValidatePassword_WithInvalidPassword_ReturnsFalse()
    {
        // Arrange
        ValidationsLogic validationsLogic = new ValidationsLogic();

        // Act
        bool result = validationsLogic.ValidatePassword("testpassword");

        // Assert
        Assert.AreEqual(false, result);
    }

    [TestMethod]
    public void TestValidatePassword_WithValidPassword_ReturnsTrue()
    {
        ValidationsLogic validationsLogic = new ValidationsLogic();

        bool result = validationsLogic.ValidatePassword("t3stP@ssword");

        Assert.AreEqual(true, result);
    }
}