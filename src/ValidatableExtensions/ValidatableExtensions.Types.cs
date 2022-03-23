namespace Throw;

public partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if type of the value is <see cref="T"/>
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IImplicitlyTypedValidatable IfType<T>(this IImplicitlyTypedValidatable validatable)
    {
        Validator.ThrowIfType<T>(
            validatable.Type,
            validatable.ParamName,
            validatable.ExceptionCustomizations);
        return validatable;
    }

    /// <summary>
    /// Throws an exception if type of the value is not <see cref="T"/>
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IImplicitlyTypedValidatable IfNotType<T>(this IImplicitlyTypedValidatable validatable)
    {
        Validator.ThrowIfNotType<T>(
            validatable.Type,
            validatable.ParamName,
            validatable.ExceptionCustomizations);
        return validatable;
    }
}