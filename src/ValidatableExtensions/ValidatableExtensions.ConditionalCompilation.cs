namespace Throw;

using System.Diagnostics;

/// <summary>
/// Extension methods for controlling whether the "throw" rule will be ignored by the compiler.
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Removes the entire "throw" rule when the build is not debug.
    /// </summary>
    [Conditional("DEBUG")]
    public static void OnlyInDebug<TValue>(this in Validatable<TValue> validatable)
        where TValue : notnull
    {
    }
}