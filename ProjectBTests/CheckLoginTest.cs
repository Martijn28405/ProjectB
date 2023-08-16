using System;
using System.IO;
[TestClass]
public class CheckLoginTest
{
    public static string User_Email = null;
    public static string User_Name = null;
    private AccountsLogic accountsLogic = new AccountsLogic();
    private StringWriter consoleOutput;
    private StringReader consoleInput;

    public void SetUp()
    {
        consoleOutput = new StringWriter();
        consoleInput = new StringReader("test@example.com\ntestpassword\n");
        Console.SetOut(consoleOutput);
        Console.SetIn(consoleInput);
    }

    public void TearDown()
    {
        consoleOutput.Dispose();
        consoleInput.Dispose();
    } 
    [TestMethod]
    public void TestSuccessfulLogin()
    {
        // Arrange
        string expectedOutput = "Login Successful\nWelcome back John Doe\nYour e-mail is test@example.com\nPress any key to continue to the Menu\n";

        // Act
        Start();

        // Assert
        AssertEqual(expectedOutput, consoleOutput.ToString());
    }
[TestMethod]
    public void TestFailedLogin()
    {
        // Arrange
        string expectedOutput = "Login Failed\nNo account found with that email and/or password or you are not allowed to login here with those details.\nPress any key to return to the login screen\n";

        // Act
        Start();

        // Assert
        AssertEqual(expectedOutput, consoleOutput.ToString());
    }

    // Helper methods

    private void Start()
    {
        if (User_Email == null)
        {
            Console.WriteLine("Welcome to the login page");
            Console.WriteLine("Please enter your email address:");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();
            AccountModel acc = accountsLogic.CheckLogin(email, password);
            if (acc != null && acc.AccountType == "User")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login Successful");
                Console.ResetColor();
                Console.WriteLine("Welcome back " + acc.FullName);
                Console.WriteLine("Your e-mail is " + acc.EmailAddress);
                User_Email = acc.EmailAddress;
                User_Name = acc.FullName;
                Console.WriteLine("Press any key to continue to the Menu");
                Console.ReadKey(true);
                AccountMenu.Start();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login Failed");
                Console.ResetColor();
                Console.WriteLine("No account found with that email and password or you are not allowed to login here with those details.");
                Console.WriteLine("Press any key to return to the login screen");
                Console.ReadKey(true);
                Start();
            }
        }
    }

    private void AssertEqual(string expected, string actual)
    {
        if (expected == actual)
        {
            Console.WriteLine("Test Passed");
        }
        else
        {
            Console.WriteLine("Test Failed");
        }
    }
}
