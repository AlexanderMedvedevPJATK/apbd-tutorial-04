using Xunit;

namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        //Arrange
        var userService = new UserService();
            
        //Act
        var result = userService.AddUser(
            null,
            "Smith",
            "smith@email.com",
            DateTime.Parse("2002-01-01"),
            3
        );
        
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        //Arrange
        var userService = new UserService();
        
        //Act
        var result = userService.AddUser(
            "John",
            "Smith",
            "smithemailcom",
            DateTime.Parse("2002-01-01"),
            3
        );
        
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        //Arrange
        var userService = new UserService();
            
        //Act
        var result = userService.AddUser(
            "John",
            "Smith",
            "smith@email.com",
            DateTime.Parse("2003-06-01"),
            3
        );
        
        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        //Arrange
        var userService = new UserService();
            
        //Act
        var result = userService.AddUser(
            "John",
            "Malewski",
            "smith@email.com",
            DateTime.Parse("2001-06-01"),
            2
        );
        
        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        //Arrange
        var userService = new UserService();
            
        //Act
        var result = userService.AddUser(
            "John",
            "Smith",
            "smith@email.com",
            DateTime.Parse("2001-06-01"),
            3
        );
        
        //Assert
        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        //Arrange
        var userService = new UserService();
            
        //Act
        var result = userService.AddUser(
            "John",
            "Kwiatkowski",
            "smith@email.com",
            DateTime.Parse("2001-06-01"),
            5
        );
        
        //Assert
        Assert.True(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        //Arrange
        var userService = new UserService();
            
        //Act
        var result = userService.AddUser(
            "John",
            "Kowalski",
            "smith@email.com",
            DateTime.Parse("2001-06-01"),
            1
        );
        
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist()
    {
        // ??? How can user not exist if we are creating it in this method?
    }

    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        //Arrange
        var userService = new UserService();
            
        //Act
        Action action = () => userService.AddUser(
            "John",
            "Andrzejewicz",
            "andrzejewicz@andrzejewicz.com",
            DateTime.Parse("2001-06-01"),
            6
        );
        
        //Assert
        Assert.Throws<ArgumentException>(action);
    }
    
    [Fact]
    public void AddUser_ThrowsArgumentExceptionWhenClientDoesNotExist()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        Action action = () => userService.AddUser(
            "Jan", 
            "Someone", 
            "someone@someone.pl", 
            DateTime.Parse("2000-01-01"),
            100
        );

        // Assert
        Assert.Throws<ArgumentException>(action);
    }
}