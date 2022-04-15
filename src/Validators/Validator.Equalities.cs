namespace Throw;

internal static partial class Validator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfNotEquals<TValue>(
        TValue value,
        TValue other,
        string paramName,
        ExceptionCustomizations? exceptionCustomizations = null,
        string? message = null)
        where TValue : notnull
    {
        if (!EqualityComparer<TValue>.Default.Equals(value, other))
        {
            ExceptionThrower.Throw(
                paramName,
                exceptionCustomizations,
                message ?? $"Value should be equal to {other}.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfEquals<TValue>(
        TValue value,
        TValue other,
        string paramName,
        ExceptionCustomizations? exceptionCustomizations = null,
        string? message = null)
        where TValue : notnull
    {
        if (EqualityComparer<TValue>.Default.Equals(value, other))
        {
            ExceptionThrower.Throw(
                paramName,
                exceptionCustomizations,
                message ?? $"Value should not be equal to {other}.");
        }
    }

}