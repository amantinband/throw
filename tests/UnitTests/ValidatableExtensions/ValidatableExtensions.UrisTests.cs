namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class UrisTests
{
    [TestMethod]
    public void ThrowIfHttp_WhenHttp_ShouldThrow()
    {
        // Arrange
        var uri = new Uri("http://www.google.com");

        // Act
        Action action = () => uri.Throw().IfHttp();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri scheme should not be http. (Parameter '{nameof(uri)}')");
    }

    [TestMethod]
    public void ThrowIfHttp_WhenHttps_ShouldNotThrow()
    {
        // Arrange
        var uri = new Uri("https://www.google.com");

        // Act
        Action action = () => uri.Throw().IfHttp();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotHttp_WhenNotHttp_ShouldThrow()
    {
        // Arrange
        var uri = new Uri("https://www.google.com");

        // Act
        Action action = () => uri.Throw().IfNotHttp();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri scheme should be http. (Parameter '{nameof(uri)}')");
    }

    [TestMethod]
    public void ThrowIfNotHttp_WhenHttp_ShouldNotThrow()
    {
        // Arrange
        var uri = new Uri("http://www.google.com");

        // Act
        Action action = () => uri.Throw().IfNotHttp();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfHttps_WhenHttps_ShouldThrow()
    {
        // Arrange
        var uri = new Uri("https://www.google.com");

        // Act
        Action action = () => uri.Throw().IfHttps();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri scheme should not be https. (Parameter '{nameof(uri)}')");
    }

    [TestMethod]
    public void ThrowIfHttps_WhenHttp_ShouldNotThrow()
    {
        // Arrange
        var uri = new Uri("http://www.google.com");

        // Act
        Action action = () => uri.Throw().IfHttps();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotHttps_WhenNotHttps_ShouldThrow()
    {
        // Arrange
        var uri = new Uri("http://www.google.com");

        // Act
        Action action = () => uri.Throw().IfNotHttps();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri scheme should be https. (Parameter '{nameof(uri)}')");
    }

    [TestMethod]
    public void ThrowIfNotHttps_WhenHttps_ShouldNotThrow()
    {
        // Arrange
        var uri = new Uri("https://www.google.com");

        // Act
        Action action = () => uri.Throw().IfNotHttps();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfSchemeEquals_WhenEquals_ShouldThrow()
    {
        // Arrange
        var uri = new Uri($"{Uri.UriSchemeFtp}://www.google.com");

        // Act
        Action action = () => uri.Throw().IfScheme(Uri.UriSchemeFtp);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri scheme should not be {Uri.UriSchemeFtp}. (Parameter '{nameof(uri)}')");
    }

    [TestMethod]
    public void ThrowIfSchemeEquals_WhenNotEquals_ShouldNotThrow()
    {
        // Arrange
        var uri = new Uri($"{Uri.UriSchemeHttp}://www.google.com");

        // Act
        Action action = () => uri.Throw().IfScheme(Uri.UriSchemeFtp);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfSchemeNotEquals_WhenNotEquals_ShouldThrow()
    {
        // Arrange
        var uri = new Uri($"{Uri.UriSchemeHttp}://www.google.com");

        // Act
        Action action = () => uri.Throw().IfSchemeNot(Uri.UriSchemeFtp);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri scheme should be {Uri.UriSchemeFtp}. (Parameter '{nameof(uri)}')");
    }

    [TestMethod]
    public void ThrowIfSchemeNotEquals_WhenEquals_ShouldNotThrow()
    {
        // Arrange
        var uri = new Uri($"{Uri.UriSchemeFtp}://www.google.com");

        // Act
        Action action = () => uri.Throw().IfSchemeNot(Uri.UriSchemeFtp);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfAbsolute_WhenAbsolute_ShouldThrow()
    {
        // Arrange
        var uri = new Uri("http://www.google.com");

        // Act
        Action action = () => uri.Throw().IfAbsolute();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri should be relative. (Parameter '{nameof(uri)}')");
    }

    [TestMethod]
    public void ThrowIfAbsolute_WhenNotAbsolute_ShouldNotThrow()
    {
        // Arrange
        var uri = new Uri("/path/to/file", UriKind.Relative);

        // Act
        Action action = () => uri.Throw().IfAbsolute();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfRelative_WhenRelative_ShouldThrow()
    {
        // Arrange
        var uri = new Uri("/path/to/file", UriKind.Relative);

        // Act
        Action action = () => uri.Throw().IfRelative();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri should be absolute. (Parameter '{nameof(uri)}')");
    }

    [TestMethod]
    public void ThrowIfRelative_WhenNotRelative_ShouldNotThrow()
    {
        // Arrange
        var uri = new Uri("http://www.google.com");

        // Act
        Action action = () => uri.Throw().IfRelative();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotAbsolute_WhenNotAbsolute_ShouldThrow()
    {
        // Arrange
        var uri = new Uri("/path/to/file", UriKind.Relative);

        // Act
        Action action = () => uri.Throw().IfNotAbsolute();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri should be absolute. (Parameter '{nameof(uri)}')");
    }

    [TestMethod]
    public void ThrowIfNotAbsolute_WhenAbsolute_ShouldNotThrow()
    {
        // Arrange
        var uri = new Uri("http://www.google.com");

        // Act
        Action action = () => uri.Throw().IfNotAbsolute();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfNotRelative_WhenNotRelative_ShouldThrow()
    {
        // Arrange
        var uri = new Uri("http://www.google.com");

        // Act
        Action action = () => uri.Throw().IfNotRelative();

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri should be relative. (Parameter '{nameof(uri)}')");
    }

    [TestMethod]
    public void ThrowIfNotRelative_WhenRelative_ShouldNotThrow()
    {
        // Arrange
        var uri = new Uri("/path/to/file", UriKind.Relative);

        // Act
        Action action = () => uri.Throw().IfNotRelative();

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPortEquals_WhenPortEquals_ShouldThrow()
    {
        // Arrange
        var uri = new Uri("http://www.google.com:80");

        // Act
        Action action = () => uri.Throw().IfPort(80);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri port should not be 80. (Parameter '{nameof(uri)}')");
    }

    [TestMethod]
    public void ThrowIfPortEquals_WhenNotEquals_ShouldNotThrow()
    {
        // Arrange
        var uri = new Uri("http://www.google.com:8080");

        // Act
        Action action = () => uri.Throw().IfPort(80);

        // Assert
        action.Should().NotThrow();
    }

    [TestMethod]
    public void ThrowIfPortNotEquals_WhenNotEquals_ShouldThrow()
    {
        // Arrange
        var uri = new Uri("http://www.google.com:8080");

        // Act
        Action action = () => uri.Throw().IfPortNot(80);

        // Assert
        action.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage($"Uri port should be 80. (Parameter '{nameof(uri)}')");
    }

    [TestMethod]
    public void ThrowIfPortNotEquals_WhenEquals_ShouldNotThrow()
    {
        // Arrange
        var uri = new Uri("http://www.google.com:80");

        // Act
        Action action = () => uri.Throw().IfPortNot(80);

        // Assert
        action.Should().NotThrow();
    }
}