namespace Throw.UnitTests.ValidatableExtensions;

[TestClass]
public class ConditionalCompilationTests
{
    [TestMethod]
    public void ThrowOnlyInDebug_WhenPresent_ShouldThrowOnlyInDebugBuild()
    {
        // Arrange
        var person = new { BirthDate = DateTime.UtcNow };

        // Act
        Action action = () => person.Throw().IfUtc(p => p.BirthDate).OnlyInDebug();

        // Assert
#if DEBUG
        action.Should()
                .ThrowExactly<ArgumentException>()
                .WithMessage($"Value should not be Utc. (Parameter '{nameof(person)}: p => p.BirthDate')");
#else
        action.Should().NotThrow();
#endif
    }
}