namespace Throw;

internal static partial class Validator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfTypesEqual(
        Type type,
        Type other,
        string paramName,
        ExceptionCustomizations? exceptionCustomizations)
    {
        if (type == other)
        {
            ExceptionThrower.Throw(
                paramName,
                exceptionCustomizations,
                $"Parameter should not be of type '{other.Name}'.");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void ThrowIfTypesNotEqual(
        Type type,
        Type other,
        string paramName,
        ExceptionCustomizations? exceptionCustomizations)
    {
        if (type != other)
        {
            ExceptionThrower.Throw(
                paramName,
                exceptionCustomizations,
                $"Parameter should be of type '{other.Name}'.");
        }
    }
}