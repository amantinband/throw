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
    internal static void ThrowIfWhiteSpace(string value, string paramName, ExceptionCustomizations? exceptionCustomizations)
    {
        if (value.All(char.IsWhiteSpace))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, "String should not be white space only.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfEqualsIgnoreCase(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, string otherString)
    {
        if (string.Equals(value, otherString, StringComparison.OrdinalIgnoreCase))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String should not be equal to '{otherString}' (case insensitive).");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfNotEqualsIgnoreCase(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, string otherString)
    {
        if (!string.Equals(value, otherString, StringComparison.OrdinalIgnoreCase))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String should be equal to '{otherString}' (case insensitive).");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfEquals(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, string otherString)
    {
        if (string.Equals(value, otherString, StringComparison.Ordinal))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String should not be equal to '{otherString}'.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfNotEquals(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, string otherString)
    {
        if (!string.Equals(value, otherString, StringComparison.Ordinal))
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String should be equal to '{otherString}'.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void IfLengthEquals(string value, string paramName, ExceptionCustomizations? exceptionCustomizations, int length)
    {
        if (value.Length == length)
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"String length should not be equal to '{length}'.");
        }
    }
}