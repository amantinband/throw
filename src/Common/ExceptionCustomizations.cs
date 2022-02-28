namespace Throw;

public struct ExceptionCustomizations
{
    public OneOf<string, Type, Func<Exception>, Func<string, Exception>> Customization { get; }

    public ExceptionCustomizations(OneOf<string, Type, Func<Exception>, Func<string, Exception>> customization)
    {
        this.Customization = customization;
    }

    public static implicit operator ExceptionCustomizations(string s) => new(s);
    public static implicit operator ExceptionCustomizations(Type type) => new(type);
    public static implicit operator ExceptionCustomizations(Func<Exception> func) => new(func);
    public static implicit operator ExceptionCustomizations(Func<string, Exception> func) => new(func);
    public static implicit operator ExceptionCustomizations(OneOf<string, Type, Func<Exception>, Func<string, Exception>> customizations) => new(customizations);
}