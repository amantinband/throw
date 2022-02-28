namespace Throw;

public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> returned from the given <paramref name="func"/> is <see cref="Uri.UriSchemeHttp"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfHttp<TValue>(this in Validatable<TValue> validatable, Func<TValue, Uri> func, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfScheme(func(validatable.Value), Uri.UriSchemeHttp, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> returned from the given <paramref name="func"/> is not <see cref="Uri.UriSchemeHttp"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotHttp<TValue>(this in Validatable<TValue> validatable, Func<TValue, Uri> func, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfSchemeNot(func(validatable.Value), Uri.UriSchemeHttp, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> returned from the given <paramref name="func"/> is <see cref="Uri.UriSchemeHttps"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfHttps<TValue>(this in Validatable<TValue> validatable, Func<TValue, Uri> func, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfScheme(func(validatable.Value), Uri.UriSchemeHttps, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> returned from the given <paramref name="func"/> is not <see cref="Uri.UriSchemeHttps"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotHttps<TValue>(this in Validatable<TValue> validatable, Func<TValue, Uri> func, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfSchemeNot(func(validatable.Value), Uri.UriSchemeHttps, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> returned from the given <paramref name="func"/> matches the given <paramref name="scheme"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfScheme<TValue>(this in Validatable<TValue> validatable, Func<TValue, Uri> func, string scheme, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfScheme(func(validatable.Value), scheme, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> returned from the given <paramref name="func"/> does not match the given <paramref name="scheme"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfSchemeNot<TValue>(this in Validatable<TValue> validatable, Func<TValue, Uri> func, string scheme, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfSchemeNot(func(validatable.Value), scheme, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> returned from the given <paramref name="func"/> is absolute.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfAbsolute<TValue>(this in Validatable<TValue> validatable, Func<TValue, Uri> func, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfAbsolute(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> returned from the given <paramref name="func"/> is relative.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfRelative<TValue>(this in Validatable<TValue> validatable, Func<TValue, Uri> func, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfRelative(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> returned from the given <paramref name="func"/> is not relative.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotRelative<TValue>(this in Validatable<TValue> validatable, Func<TValue, Uri> func, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfAbsolute(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> returned from the given <paramref name="func"/> is not absolute.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfNotAbsolute<TValue>(this in Validatable<TValue> validatable, Func<TValue, Uri> func, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfRelative(func(validatable.Value), $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if port of the <see cref="Uri"/> returned from the given <paramref name="func"/> matches the given <paramref name="port"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfPort<TValue>(this in Validatable<TValue> validatable, Func<TValue, Uri> func, int port, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfPort(func(validatable.Value), port, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if port of the <see cref="Uri"/> returned from the given <paramref name="func"/> does not match the given <paramref name="port"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<TValue> IfPortNot<TValue>(this in Validatable<TValue> validatable, Func<TValue, Uri> func, int port, [CallerArgumentExpression("func")] string? funcName = null)
        where TValue : notnull
    {
        Validator.ThrowIfPortNot(func(validatable.Value), port, $"{validatable.ParamName}: {funcName}", validatable.ExceptionCustomizations);

        return ref validatable;
    }
}