namespace Throw;

internal static partial class Validator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfLongerThan(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, int length)
    {
        if (value.Length > length)
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String should not be longer than {length} characters.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfShorterThan(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, int length)
    {
        if (value.Length < length)
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String should not be shorter than {length} characters.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfEmpty(string value, string paramName, ExceptionCustomizations? exceptionCustomizations)
    {
        if (value.Length == 0)
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, "String should not be empty.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfNullOrEmpty(string? value, string paramName, ExceptionCustomizations? exceptionCustomizations)
    {
        if (string.IsNullOrEmpty(value))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, "String should not be null or empty.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfNullOrWhiteSpace(string? value, string paramName, ExceptionCustomizations? exceptionCustomizations)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, "String should not be null or whitespace.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfWhiteSpace(string value, string paramName, ExceptionCustomizations? exceptionCustomizations)
    {
        if (value.All(char.IsWhiteSpace))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, "String should not be white space only.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfEquals(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, string otherString, StringComparison comparisonType)
    {
        if (string.Equals(value, otherString, comparisonType))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String should not be equal to '{otherString}' (comparison type: '{comparisonType}').");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfNotEquals(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, string otherString, StringComparison comparisonType)
    {
        if (!string.Equals(value, otherString, comparisonType))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String should be equal to '{otherString}' (comparison type: '{comparisonType}').");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfLengthEquals(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, int length)
    {
        if (value.Length == length)
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String length should not be equal to {length}.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfLengthNotEquals(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, int length)
    {
        if (value.Length != length)
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String length should be equal to {length}.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfEndsWith(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, string str)
    {
        if (value.EndsWith(str))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String should not end with '{str}'.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfNotEndsWith(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, string str)
    {
        if (!value.EndsWith(str))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String should end with '{str}'.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfStartsWith(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, string str)
    {
        if (value.StartsWith(str))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String should not start with '{str}'.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfNotStartsWith(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, string str)
    {
        if (!value.StartsWith(str))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String should start with '{str}'.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfContains(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, string otherString, StringComparison comparisonType)
    {
        if (value.Contains(otherString, comparisonType))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String should not contain '{otherString}' (comparison type: '{comparisonType}').");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfNotContains(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, string otherString, StringComparison comparisonType)
    {
        if (!value.Contains(otherString, comparisonType))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String should contain '{otherString}' (comparison type: '{comparisonType}').");
        }
    }
}