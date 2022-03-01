namespace Throw;

/// <summary>
/// Extension methods <see cref="Uri"/>s.
/// </summary>
public static partial class ValidatableExtensions
{
    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> is <see cref="Uri.UriSchemeHttp"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<Uri> IfHttp(this in Validatable<Uri> validatable)
    {
        Validator.ThrowIfScheme(validatable.Value, Uri.UriSchemeHttp, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> is not <see cref="Uri.UriSchemeHttp"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<Uri> IfNotHttp(this in Validatable<Uri> validatable)
    {
        Validator.ThrowIfSchemeNot(validatable.Value, Uri.UriSchemeHttp, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> is <see cref="Uri.UriSchemeHttps"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<Uri> IfHttps(this in Validatable<Uri> validatable)
    {
        Validator.ThrowIfScheme(validatable.Value, Uri.UriSchemeHttps, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> is not <see cref="Uri.UriSchemeHttps"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<Uri> IfNotHttps(this in Validatable<Uri> validatable)
    {
        Validator.ThrowIfSchemeNot(validatable.Value, Uri.UriSchemeHttps, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> matches the given <paramref name="scheme"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<Uri> IfScheme(this in Validatable<Uri> validatable, string scheme)
    {
        Validator.ThrowIfScheme(validatable.Value, scheme, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> does not match the given <paramref name="scheme"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<Uri> IfSchemeNot(this in Validatable<Uri> validatable, string scheme)
    {
        Validator.ThrowIfSchemeNot(validatable.Value, scheme, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> is absolute.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<Uri> IfAbsolute(this in Validatable<Uri> validatable)
    {
        Validator.ThrowIfAbsolute(validatable.Value, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> is relative.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<Uri> IfRelative(this in Validatable<Uri> validatable)
    {
        Validator.ThrowIfRelative(validatable.Value, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> is not absolute.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<Uri> IfNotAbsolute(this in Validatable<Uri> validatable)
    {
        Validator.ThrowIfRelative(validatable.Value, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if scheme of the <see cref="Uri"/> is not relative.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<Uri> IfNotRelative(this in Validatable<Uri> validatable)
    {
        Validator.ThrowIfAbsolute(validatable.Value, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if port of the <see cref="Uri"/> matches the given <paramref name="port"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<Uri> IfPort(this in Validatable<Uri> validatable, int port)
    {
        Validator.ThrowIfPort(validatable.Value, port, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }

    /// <summary>
    /// Throws an exception if port of the <see cref="Uri"/> does not match the given <paramref name="port"/>.
    /// </summary>
    /// <remarks>
    /// The default exception thrown is an <see cref="ArgumentException"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref readonly Validatable<Uri> IfPortNot(this in Validatable<Uri> validatable, int port)
    {
        Validator.ThrowIfPortNot(validatable.Value, port, validatable.ParamName, validatable.ExceptionCustomizations);

        return ref validatable;
    }
}