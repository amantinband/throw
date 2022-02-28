namespace Throw;

public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if the <see cref="DateTimeKind"/> of the <see cref="DateTime"/> returned
    /// from the given <paramref name="func"/> is <see cref="DateTimeKind.Utc"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfUtc<TValue>(this in Validatable<TValue> validatable, Func<TValue, DateTime> func, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfKind(func(validatable.Value), DateTimeKind.Utc, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the <see cref="DateTimeKind"/> of the <see cref="DateTime"/> returned
    /// from the given <paramref name="func"/> is not <see cref="DateTimeKind.Utc"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotUtc<TValue>(this in Validatable<TValue> validatable, Func<TValue, DateTime> func, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfNotKind(func(validatable.Value), DateTimeKind.Utc, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the <see cref="DateTimeKind"/> of the <see cref="DateTime"/> returned
    /// from the given <paramref name="func"/> matches the given <paramref name="kind"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfDateTimeKind<TValue>(this in Validatable<TValue> validatable, Func<TValue, DateTime> func, DateTimeKind kind, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfKind(func(validatable.Value), kind, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if the <see cref="DateTimeKind"/> of the <see cref="DateTime"/> returned
    /// from the given <paramref name="func"/> does not match the given <paramref name="kind"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfDateTimeKindNot<TValue>(this in Validatable<TValue> validatable, Func<TValue, DateTime> func, DateTimeKind kind, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfNotKind(func(validatable.Value), kind, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }
}