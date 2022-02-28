namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class UriPropertiesTests
{
    [TestMethod]
    public void ThrowIfUriPropertyHttp_WhenUriPropertyIsHttp_ShouldThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("http://www.google.com") };

        // Act
        Action action = () => person.Throw().IfHttp(p => p.Uri);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri scheme should not be http. (Parameter '{nameof(person)}: p => p.Uri')");
    }

    [TestMethod]
    public void ThrowIfUriPropertyHttp_WhenUriPropertyIsHttps_ShouldNotThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("https://www.google.com") };

        // Act
        Action action = () => person.Throw().IfHttp(p => p.Uri);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfUriPropertyNotHttp_WhenUriPropertyIsNotHttp_ShouldThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("https://www.google.com") };

        // Act
        Action action = () => person.Throw().IfNotHttp(p => p.Uri);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri scheme should be http. (Parameter '{nameof(person)}: p => p.Uri')");
    }

    [TestMethod]
    public void ThrowIfUriPropertyNotHttp_WhenUriPropertyIsHttp_ShouldNotThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("http://www.google.com") };

        // Act
        Action action = () => person.Throw().IfNotHttp(p => p.Uri);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfUriPropertyHttps_WhenUriPropertyIsHttps_ShouldThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("https://www.google.com") };

        // Act
        Action action = () => person.Throw().IfHttps(p => p.Uri);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri scheme should not be https. (Parameter '{nameof(person)}: p => p.Uri')");
    }

    [TestMethod]
    public void ThrowIfUriPropertyHttps_WhenUriPropertyIsHttp_ShouldNotThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("http://www.google.com") };

        // Act
        Action action = () => person.Throw().IfHttps(p => p.Uri);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfUriPropertyNotHttps_WhenUriPropertyIsNotHttps_ShouldThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("http://www.google.com") };

        // Act
        Action action = () => person.Throw().IfNotHttps(p => p.Uri);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri scheme should be https. (Parameter '{nameof(person)}: p => p.Uri')");
    }

    [TestMethod]
    public void ThrowIfUriPropertyNotHttps_WhenUriPropertyIsHttps_ShouldNotThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("https://www.google.com") };

        // Act
        Action action = () => person.Throw().IfNotHttps(p => p.Uri);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfUriPropertySchemeEquals_WhenUriPropertySchemeEquals_ShouldThrow()
    {
        // Arrange
        var person = new { Uri = new Uri($"{Uri.UriSchemeGopher}://www.google.com") };

        // Act
        Action action = () => person.Throw().IfScheme(p => p.Uri, Uri.UriSchemeGopher);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri scheme should not be {Uri.UriSchemeGopher}. (Parameter '{nameof(person)}: p => p.Uri')");
    }

    [TestMethod]
    public void ThrowIfUriPropertySchemeEquals_WhenUriPropertySchemeNotEquals_ShouldNotThrow()
    {
        // Arrange
        var person = new { Uri = new Uri($"{Uri.UriSchemeHttp}://www.google.com") };

        // Act
        Action action = () => person.Throw().IfScheme(p => p.Uri, Uri.UriSchemeGopher);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfUriPropertySchemeNotEquals_WhenUriPropertySchemeNotEquals_ShouldThrow()
    {
        // Arrange
        var person = new { Uri = new Uri($"{Uri.UriSchemeHttp}://www.google.com") };

        // Act
        Action action = () => person.Throw().IfSchemeNot(p => p.Uri, Uri.UriSchemeGopher);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri scheme should be {Uri.UriSchemeGopher}. (Parameter '{nameof(person)}: p => p.Uri')");
    }

    [TestMethod]
    public void ThrowIfUriPropertySchemeNotEquals_WhenUriPropertySchemeEquals_ShouldNotThrow()
    {
        // Arrange
        var person = new { Uri = new Uri($"{Uri.UriSchemeGopher}://www.google.com") };

        // Act
        Action action = () => person.Throw().IfSchemeNot(p => p.Uri, Uri.UriSchemeGopher);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfUriPropertyAbsolute_WhenAbsolute_ShouldThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("http://www.google.com") };

        // Act
        Action action = () => person.Throw().IfAbsolute(p => p.Uri);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri should be relative. (Parameter '{nameof(person)}: p => p.Uri')");
    }

    [TestMethod]
    public void ThrowIfUriPropertyAbsolute_WhenRelative_ShouldNotThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("/path/to/file", UriKind.Relative) };

        // Act
        Action action = () => person.Throw().IfAbsolute(p => p.Uri);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfUriPropertyRelative_WhenRelative_ShouldThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("/path/to/file", UriKind.Relative) };

        // Act
        Action action = () => person.Throw().IfRelative(p => p.Uri);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri should be absolute. (Parameter '{nameof(person)}: p => p.Uri')");
    }

    [TestMethod]
    public void ThrowIfUriPropertyRelative_WhenAbsolute_ShouldNotThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("http://www.google.com") };

        // Act
        Action action = () => person.Throw().IfRelative(p => p.Uri);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfUriPropertyNotAbsolute_WhenNotAbsolute_ShouldThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("/path/to/file", UriKind.Relative) };

        // Act
        Action action = () => person.Throw().IfNotAbsolute(p => p.Uri);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri should be absolute. (Parameter '{nameof(person)}: p => p.Uri')");
    }

    [TestMethod]
    public void ThrowIfUriPropertyNotAbsolute_WhenAbsolute_ShouldNotThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("http://www.google.com") };

        // Act
        Action action = () => person.Throw().IfNotAbsolute(p => p.Uri);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfUriPropertyNotRelative_WhenNotRelative_ShouldThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("http://www.google.com") };

        // Act
        Action action = () => person.Throw().IfNotRelative(p => p.Uri);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri should be relative. (Parameter '{nameof(person)}: p => p.Uri')");
    }

    [TestMethod]
    public void ThrowIfUriPropertyNotRelative_WhenRelative_ShouldNotThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("/path/to/file", UriKind.Relative) };

        // Act
        Action action = () => person.Throw().IfNotRelative(p => p.Uri);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfUriPropertyPortEquals_WhenUriPropertyPortEquals_ShouldThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("http://www.google.com:80") };

        // Act
        Action action = () => person.Throw().IfPort(p => p.Uri, 80);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri port should not be 80. (Parameter '{nameof(person)}: p => p.Uri')");
    }

    [TestMethod]
    public void ThrowIfUriPropertyPortEquals_WhenUriPropertyPortNotEquals_ShouldNotThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("http://www.google.com:8080") };

        // Act
        Action action = () => person.Throw().IfPort(p => p.Uri, 80);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfUriPropertyPortNotEquals_WhenUriPropertyPortNotEquals_ShouldThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("http://www.google.com:8080") };

        // Act
        Action action = () => person.Throw().IfPortNot(p => p.Uri, 80);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri port should be 80. (Parameter '{nameof(person)}: p => p.Uri')");
    }

    [TestMethod]
    public void ThrowIfUriPropertyPortNotEquals_WhenUriPropertyPortEquals_ShouldNotThrow()
    {
        // Arrange
        var person = new { Uri = new Uri("http://www.google.com:80") };

        // Act
        Action action = () => person.Throw().IfPortNot(p => p.Uri, 80);

        // Assert
        action.Should().NotThrow();
    }
}