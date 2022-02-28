namespace Throw;

public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the <see cref="DateTimeKind"/> is <see cref="DateTimeKind.Utc"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<DateTime> IfUtc(this in Validatable<DateTime> validatable)
    {
        Validator.ThrowIfKind(validatable.Value, DateTimeKind.Utc, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the <see cref="DateTimeKind"/> is not <see cref="DateTimeKind.Utc"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<DateTime> IfNotUtc(this in Validatable<DateTime> validatable)
    {
        Validator.ThrowIfNotKind(validatable.Value, DateTimeKind.Utc, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the <see cref="DateTimeKind"/> matches the given <paramref name="kind"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<DateTime> IfDateTimeKind(this in Validatable<DateTime> validatable, DateTimeKind kind)
    {
        Validator.ThrowIfKind(validatable.Value, kind, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the <see cref="DateTimeKind"/> does not match the given <paramref name="kind"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<DateTime> IfDateTimeKindNot(this in Validatable<DateTime> validatable, DateTimeKind kind)
    {
        Validator.ThrowIfNotKind(validatable.Value, kind, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }
}