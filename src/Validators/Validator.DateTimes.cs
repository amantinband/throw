namespace Throw;

internal static partial class Validator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfNotKind(
        DateTime value,
        DateTimeKind kind,
        string paramName,
        ExceptionCustomizations? exceptionCustomizations = null)
    {
        if (value.Kind != kind)
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"Value should be {kind}.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfKind(
        DateTime value,
        DateTimeKind kind,
        string paramName,
        ExceptionCustomizations? exceptionCustomizations = null)
    {
        if (value.Kind == kind)
        {
            ExceptionThrower.Throw(paramName, exceptionCustomizations, $"Value should not be {kind}.");
        }
    }
}