namespace Throw;

/// <summary>
/// The exception customizations.
/// Contains a discriminated union of all possible exception customization options.
/// </summary>
public struct ExceptionCustomizations
{
    /// <summary>
    /// A discriminated union of all possible exception customization options.
    /// </summary>
    public OneOf<string, Type, Func<Exception>, Func<string, Exception>> Customization { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionCustomizations"/> class.
    /// </summary>
    public ExceptionCustomizations(OneOf<string, Type, Func<Exception>, Func<string, Exception>> customization)
    {
        this.Customization = customization;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionCustomizations"/> class.
    /// The customization will be the given <paramref name="message"/>.
    /// </summary>
    public static implicit operator ExceptionCustomizations(string message) => new(message);

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionCustomizations"/> class.
    /// The customization will be an exception of the given <paramref name="type"/>.
    /// </summary>
    public static implicit operator ExceptionCustomizations(Type type) => new(type);

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionCustomizations"/> class.
    /// The customization will be the given exception returning <paramref name="func"/>.
    /// </summary>
    public static implicit operator ExceptionCustomizations(Func<Exception> func) => new(func);

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionCustomizations"/> class.
    /// The customization will be the given exception returning <paramref name="func"/>.
    /// </summary>
    public static implicit operator ExceptionCustomizations(Func<string, Exception> func) => new(func);

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionCustomizations"/> class.
    /// The customization will match the given <paramref name="customizations"/>.
    /// </summary>
    public static implicit operator ExceptionCustomizations(OneOf<string, Type, Func<Exception>, Func<string, Exception>> customizations) => new(customizations);
}