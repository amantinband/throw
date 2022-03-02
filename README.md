<div align="center">

<img src="assets/icon.png" alt="drawing" width="700px"/>

[![NuGet](https://img.shields.io/nuget/v/Throw.svg)](https://www.nuget.org/packages/Throw) [![NuGet](https://img.shields.io/nuget/dt/Throw.svg)](https://www.nuget.org/packages/Throw)

[![GitHub contributors](https://img.shields.io/github/contributors/mantinband/throw)](https://GitHub.com/mantinband/throw/graphs/contributors/) [![GitHub Stars](https://img.shields.io/github/stars/mantinband/throw.svg)](https://github.com/mantinband/throw/stargazers) [![GitHub license](https://img.shields.io/github/license/mantinband/throw)](https://github.com/mantinband/throw/blob/main/LICENSE)

---

### A simple, fluent, extensible, and fully customizable library for throwing exceptions using .NET 6+
`dotnet add package throw`

---

</div>

- [Getting started](#getting-started)
  - [Basic examples](#basic-examples)
  - [Verbose exception messages out of the box](#verbose-exception-messages-out-of-the-box)
  - [Super customizable everything](#super-customizable-everything)
  - [Give it a star ⭐!](#give-it-a-star-)
- [Nullable vs non-nullable types](#nullable-vs-non-nullable-types)
- [Customize everything](#customize-everything)
  - [How customizing the exception affects the chained rules](#how-customizing-the-exception-affects-the-chained-rules)
  - [Exception customizations](#exception-customizations)
    - [1. `Throw()`](#1-throw)
    - [2. `Throw("My custom message")`](#2-throwmy-custom-message)
    - [3. `Throw(() => new MyException())`](#3-throw--new-myexception)
    - [4. `Throw(paramName => new MyException($"Param: {paramName}")`](#4-throwparamname--new-myexceptionparam-paramname)
- [Usage](#usage)
  - [Common types](#common-types)
    - [Booleans](#booleans)
    - [Nullable value types (`bool?`, `int?`, `double?`, `DateTime?` etc.)](#nullable-value-types-bool-int-double-datetime-etc)
    - [Strings](#strings)
    - [Collections (`IEnumerable`, `IEnumerable<T>`, `ICollection`, `ICollection<T>`, `IList`, etc.)](#collections-ienumerable-ienumerablet-icollection-icollectiont-ilist-etc)
    - [DateTime](#datetime)
    - [Enums](#enums)
    - [Equalities (non-nullables)](#equalities-non-nullables)
    - [Uris](#uris)
    - [Comparable (`int`, `double`, `decimal`, `long`, `float`, `short`, `DateTime`, `DateOnly`, `TimeOnly` etc.)](#comparable-int-double-decimal-long-float-short-datetime-dateonly-timeonly-etc)
  - [Nested properties](#nested-properties)
    - [Boolean properties](#boolean-properties)
    - [String properties](#string-properties)
    - [Collection properties](#collection-properties)
    - [DateTime properties](#datetime-properties)
    - [Enum properties](#enum-properties)
    - [property equalities](#property-equalities)
    - [Uri properties](#uri-properties)
    - [Comparable properties](#comparable-properties)
- [Extensibility](#extensibility)
- [Upcoming features](#upcoming-features)
- [Contribution](#contribution)
- [Credits](#credits)
- [License](#license)

---

# Getting started

## Basic examples

This 🤨

```csharp
record User(string FirstName, string LastName, string? Email);

void SendEmail(User user)
{
    // 👇🏼 Guard clauses 👇🏼
    if (string.IsNullOrWhiteSpace(user.FirstName))
    {
        throw new ArgumentException("Name is required", nameof(user));
    }

    if (string.IsNullOrWhiteSpace(user.LastName))
    {
        throw new ArgumentException("Last name is required", nameof(user));
    }

    if (user.Email == null)
    {
        throw new ArgumentNullException(nameof(user), "Email is required");
    }

    if (user.Email.Length > 100)
    {
        throw new ArgumentOutOfRangeException(nameof(user), user.Email.Length, "Email is too long");
    }

    // 👇🏼 Actual logic 👇🏼
    if (!emailService.TrySendEmail(user))
    {
        throw new EmailException("Email could not be sent");
    }
}
```

Turns into this 😎

```csharp
record User(string FirstName, string LastName, string? Email);

void SendEmail(User user)
{
    // 👇🏼 Guard clauses 👇🏼
    user.Throw()
        .IfWhiteSpace(user => user.FirstName)
        .IfWhiteSpace(user => user.LastName)
        .IfNull(user => user.Email)
        .IfLongerThan(user => user.Email!, 100);

    // 👇🏼 Actual logic 👇🏼
    emailService.TrySendEmail(user)
        .Throw(() => new EmailException("Email could not be sent."))
        .IfFalse();
}
```

---

Cast back to original type 👇🏼

This 🤨

```csharp
if (!Enum.IsDefined(humorLevel))
{
    throw new ArgumentOutOfRangeException("Humor level should be defined in enum.", humorLevel, nameof(humorLevel));
}

if (humorLevel == HumorLevel.ExtremelyFunny)
{
    throw new ArgumentException("Humor level is way too high.", nameof(humorLevel));
}

_humorLevel = humorLevel;
```

Turns into this 😎

```csharp
_humorLevel = humorLevel
    .Throw().IfOutOfRange()
    .Throw("Humor level is way too high.").IfEquals(HumorLevel.ExtremelyFunny);
```

---

## Verbose exception messages out of the box

```csharp
// System.ArgumentException: Value should not meet condition (condition: 'user => user.FavoriteBrowser == Browser.Chrome'). (Parameter 'user')
user.Throw().IfTrue(user => user.FavoriteBrowser == Browser.Chrome);
```

```csharp
// System.ArgumentOutOfRangeException: Value should not be less than 18. (Parameter 'user: user => user.Age')\n Actual value was 5.
user.Throw().IfLessThan(user => user.Age, 18);
```

```csharp
// System.ArgumentException: String should not be empty. (Parameter 'user: user => user.Name')
user.Throw().IfEmpty(user => user.Name);
```

## Super customizable everything

Custom messages

```csharp
// System.ArgumentOutOfRangeException: User doesn't meet age requirements. (Parameter 'user: user => user.Age')\n Actual value was 5.
user.Throw("User doesn't meet age requirements.")
    .IfLessThan(user => user.Age, 18)
    .IfGreaterThan(user => user.Age, 30);
```

Custom exceptions

```csharp
// AgeException: User doesn't meet age requirements.
user.Throw(() => new AgeException("User doesn't meet age requirements."))
    .IfLessThan(user => user.Age, 18)
    .IfGreaterThan(user => user.Age, 30);
```

Switch exceptions in the middle and it will apply to following rules

```csharp
user.Throw(() => new AgeException("User doesn't meet age requirements."))
        .IfLessThan(user => user.Age, 18)
        .IfGreaterThan(user => user.Age, 30)
    .Throw("Browser isn't supported.")
        .IfTrue(user => user.FavoriteBrowser == Browser.Chrome)
    .Throw("Uri isn't good.")
        .IfAbsolute(user => user.FavoriteWebsite)
        .IfPort(user => user.FavoriteWebsite, 80)
    .Throw(paramName => new ServiceException(paramName: paramName, message: "User didn't meet requirements."))
        .IfNull(user => user.Friends)
        .IfEmpty(user => user.Friends!)
        .IfCountGreaterThan(user => user.Friends!, 5)
        .IfHasNullElements(user => user.Friends!);
```

## Give it a star ⭐!

Loving it? Show your support by giving this project a star!

# Nullable vs non-nullable types

This library is designed to work best with [nullable reference types feature](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references) enabled.

The `Throw()` method is the entry method for all non-nullable types:

```csharp
string name = "hello";
name.Throw().IfLongerThan(10);
```

And `ThrowIfNull()` for any nullable type:

```csharp
string? name = "hello";
name.ThrowIfNull();
```

Trying to use `Throw()` on a nullable type will give a warning

```csharp
string? name = null;
name.Throw() // warning CS8714: The type 'string?' cannot be used as type parameter 'TValue' in the generic type or method 'ValidatableCreationExtensions.Throw<TValue>(TValue, ExceptionCustomizations?, string?)'. Nullability of type argument 'string?' doesn't match 'notnull' constraint.
    .IfEmpty();
```

After validating the nullable type isn't null, all the regular non-nullable rules can be used

```csharp
name.ThrowIfNull()
    .IfEmpty()
    .IfLongerThan(3);
```

The expression can be implicitly cast to the non-nullable type of the original nullable type


```csharp
string? name = "Amichai";
string nonNullableName = name.ThrowIfNull()
    .IfEmpty()
    .IfLongerThan(10);
```

or

```csharp
int? a = 5;
int b = a.ThrowIfNull();
```

# Customize everything

## How customizing the exception affects the chained rules

If you have customized the exception, any rule that throws an exception will use the customization. For example:

```csharp
// Default behavior:
name.Throw()
    .IfEmpty() // System.ArgumentException: String should not be empty. (Parameter 'name')
    .IfWhiteSpace() // System.ArgumentException: String should not be white space only. (Parameter 'name')
    .IfLongerThan(3) // System.ArgumentException: String should not be longer than 3 characters. (Parameter 'name')
    .IfShorterThan(10); // System.ArgumentException: String should not be shorter than 10 characters. (Parameter 'name')

// Customized behavior:
name.Throw(paramName => throw new MyCustomException($"Param name: {paramName}."))
    .IfEmpty() // MyCustomException: Param name: name.
    .IfWhiteSpace() // MyCustomException: Param name: name.
    .IfLongerThan(3) // MyCustomException: Param name: name.
    .IfShorterThan(10); // MyCustomException: Param name: name.
```

At any point, you can change the exception customization, and it will apply for all the rules that follow. For example:

```csharp
name.Throw("String should not be empty or white space only.")
        .IfEmpty() // System.ArgumentException: String should not be empty or white space only. (Parameter 'name')
        .IfWhiteSpace() // System.ArgumentException: String should not be empty or white space only. (Parameter 'name')
    .Throw("String should not be between 3 and 10 characters long.")
        .IfLongerThan(3) // System.ArgumentException: String should not be between 3 and 10 characters long. (Parameter 'name')
        .IfShorterThan(10); // System.ArgumentException: String should not be between 3 and 10 characters long. (Parameter 'name')
```

To go back to the default exception, simply use the `Throw()` method. For example:

```csharp
name.Throw("String should not be empty or white space only.")
        .IfEmpty() // System.ArgumentException: String should not be empty or white space only. (Parameter 'name')
        .IfWhiteSpace() // System.ArgumentException: String should not be empty or white space only. (Parameter 'name')
    .Throw()
        .IfLongerThan(3) // System.ArgumentException: String should not be longer than 3 characters. (Parameter 'name')
        .IfShorterThan(10); // System.ArgumentException: String should not be shorter than 10 characters. (Parameter 'name')
```

## Exception customizations

### 1. `Throw()`

Each rule has a default behavior. If you don't customize the exception, the default behavior will be used.

Use the `Throw()` or `ThrowIfNull()` method to throw the default exception

```csharp
// ArgumentNullException: Value cannot be null. (Parameter 'nullableValue')
nullableValue.ThrowIfNull();

// System.ArgumentOutOfRangeException: Value should not be less than 2/28/2042 4:41:46 PM. (Parameter 'dateTime')\n Actual value was 2/28/2022 4:41:46 PM.
dateTime.Throw().IfLessThan(DateTime.Now.AddYears(20));

// ArgumentException: Value should not be true (Parameter 'isGood')
isGood.Throw().IfTrue();

// System.ArgumentException: String should not be empty. (Parameter 'name')
name.Throw().IfEmpty();

// System.ArgumentOutOfRangeException: Value should not be greater than 0. (Parameter 'number')\n Actual value was 5.
number.Throw().IfPositive();
```

### 2. `Throw("My custom message")`

Pass a custom exception message to the `Throw()` or `ThrowIfNull()` method

```csharp
// System.ArgumentNullException: My custom message (Parameter 'nullableValue')
nullableValue.ThrowIfNull("My custom message");

// System.ArgumentOutOfRangeException: My custom message (Parameter 'dateTime')\n Actual value was 3/1/2022 10:47:15 AM.
dateTime.Throw("My custom message").IfLessThan(DateTime.Now.AddYears(20));

// System.ArgumentException: My custom message (Parameter 'isGood')
isGood.Throw("My custom message").IfTrue();

// System.ArgumentException: My custom message (Parameter 'name')
name.Throw("My custom message").IfEmpty();

// System.ArgumentOutOfRangeException: My custom message (Parameter 'number')\n Actual value was 5.
number.Throw("My custom message").IfPositive();
```

### 3. `Throw(() => new MyException())`

Pass a custom exception thrower to the `Throw()` or `ThrowIfNull()` method

```csharp
// MyCustomException: Exception of type 'MyCustomException' was thrown.
nullableValue.ThrowIfNull(() => throw new MyCustomException());

// MyCustomException: Exception of type 'MyCustomException' was thrown.
dateTime.Throw(() => throw new MyCustomException()).IfLessThan(DateTime.Now.AddYears(20));

// MyCustomException: Exception of type 'MyCustomException' was thrown.
isGood.Throw(() => throw new MyCustomException()).IfTrue();

// MyCustomException: Exception of type 'MyCustomException' was thrown.
name.Throw(() => throw new MyCustomException()).IfEmpty();

// MyCustomException: Exception of type 'MyCustomException' was thrown.
number.Throw(() => throw new MyCustomException()).IfPositive();
```

### 4. `Throw(paramName => new MyException($"Param: {paramName}")`

Pass a custom exception thrower to the `Throw()` or `ThrowIfNull()` method, that takes the parameter name as a parameter

This comes in handy in scenarios like this:

```csharp
void SendEmail(User user)
{
    user.Throw(paramName => new UserException(message: "Cannot send email since user details are invalid.", paramName: paramName))
        .IfWhiteSpace(user => user.FirstName) // UserException: Cannot send email since user details are invalid. (Parameter 'user: user => user.FirstName')
        .IfWhiteSpace(user => user.LastName) // UserException: Cannot send email since user details are invalid. (Parameter 'user: user => user.LastName')
        .IfNull(user => user.Email) // UserException: Cannot send email since user details are invalid. (Parameter 'user: user => user.Email')
        .IfLongerThan(user => user.Email!, 100); // UserException: Cannot send email since user details are invalid. (Parameter 'user: user => user.Email!')

    emailService.TrySendEmail(user)
        .Throw(() => new EmailException("Email could not be sent."))
        .IfFalse();
}
```
```csharp
// MyCustomException: Param name: nullableValue.
nullableValue.ThrowIfNull(paramName => throw new MyCustomException($"Param name: {paramName}."));

// MyCustomException: Param name: dateTime.
dateTime.Throw(paramName => throw new MyCustomException($"Param name: {paramName}.")).IfLessThan(DateTime.Now.AddYears(20));

// MyCustomException: Param name: isGood.
isGood.Throw(paramName => throw new MyCustomException($"Param name: {paramName}.")).IfTrue();

// MyCustomException: Param name: name.
name.Throw(paramName => throw new MyCustomException($"Param name: {paramName}.")).IfEmpty();

// MyCustomException: Param name: number.
number.Throw(paramName => throw new MyCustomException($"Param name: {paramName}.")).IfPositive();
```

# Usage

## Common types

### Booleans

```csharp
value.Throw().IfTrue(); // ArgumentException: Value should not be true (Parameter 'value')
value.Throw().IfFalse(); // ArgumentException: Value should be true (Parameter 'value')

// Any method which returns bool can inline it's exception throwing logic.
Enum.TryParse("Unexpected value", out EmployeeType value)
    .Throw()
    .IfFalse(); // System.ArgumentException: Value should be true. (Parameter 'Enum.TryParse("Unexpected value", out EmployeeType value)')
```

### Nullable value types (`bool?`, `int?`, `double?`, `DateTime?` etc.)

```csharp
bool? value = null;

value.ThrowIfNull(); // ArgumentNullException: Value cannot be null. (Parameter 'value')

// After validating `ThrowIfNull`, any of the regular value type extensions can be used.
value.ThrowIfNull() // ArgumentNullException: Value cannot be null. (Parameter 'value')
    .IfTrue(); // ArgumentException: Value should not be true (Parameter 'value')

// The returned value from `ThrowIfNull` can be implicitly cast to the original non-nullable type.
bool nonNullableValue = value.ThrowIfNull(); // ArgumentNullException: Value cannot be null. (Parameter 'value')

```

### Strings

```csharp
name.Throw().IfEmpty(); // System.ArgumentException: String should not be empty. (Parameter 'name')
name.Throw().IfWhiteSpace(); // System.ArgumentException: String should not be white space only. (Parameter 'name')
name.Throw().IfShorterThan(10); // System.ArgumentException: String should not be shorter than 10 characters. (Parameter 'name')
name.Throw().IfLongerThan(3); // System.ArgumentException: String should not be longer than 3 characters. (Parameter 'name')
name.Throw().IfEquals("Amichai"); // System.ArgumentException: String should not be equal to 'Amichai'. (Parameter 'name')
name.Throw().IfEqualsIgnoreCase("AMICHAI"); // System.ArgumentException: String should not be equal to 'AMICHAI' (case insensitive). (Parameter 'name')
name.Throw().IfNotEquals("Dan"); // System.ArgumentException: String should be equal to 'Dan'. (Parameter 'name')
name.Throw().IfNotEqualsIgnoreCase("Dan"); // System.ArgumentException: String should be equal to 'Dan' (case insensitive). (Parameter 'name')
```

### Collections (`IEnumerable`, `IEnumerable<T>`, `ICollection`, `ICollection<T>`, `IList`, etc.)

*Important note: if the collection is a non-evaluated expression, the expression will be evaluated.*

```csharp
collection.Throw().IfHasNullElements(); // System.ArgumentException: Collection should not have null elements. (Parameter 'collection')
collection.Throw().IfEmpty(); // System.ArgumentException: Collection should not be empty. (Parameter 'collection')
collection.Throw().IfNotEmpty(); // System.ArgumentException: Collection should be empty. (Parameter 'collection')
collection.Throw().IfCountLessThan(5); // System.ArgumentException: Collection count should not be less than 5. (Parameter 'collection')
collection.Throw().IfCountGreaterThan(1); // System.ArgumentException: Collection count should not be greater than 1. (Parameter 'collection')
collection.Throw().IfCountEquals(0); // System.ArgumentException: Collection count should not be equal to 0. (Parameter 'collection')
collection.Throw().IfCountNotEquals(0); // System.ArgumentException: Collection count should be equal to 0. (Parameter 'collection')
```

### DateTime

```csharp
dateTime.Throw().IfUtc(); // System.ArgumentException: Value should not be Utc. (Parameter 'dateTime')
dateTime.Throw().IfNotUtc(); // System.ArgumentException: Value should be Utc. (Parameter 'dateTime')
dateTime.Throw().IfDateTimeKind(DateTimeKind.Unspecified); // System.ArgumentException: Value should not be Unspecified. (Parameter 'dateTime')
dateTime.Throw().IfDateTimeKindNot(DateTimeKind.Local); // System.ArgumentException: Value should be Local. (Parameter 'dateTime')
dateTime.Throw().IfGreaterThan(DateTime.Now.AddYears(-20)); // System.ArgumentOutOfRangeException: Value should not be greater than 2/28/2002 4:41:19 PM. (Parameter 'dateTime')
dateTime.Throw().IfLessThan(DateTime.Now.AddYears(20)); // System.ArgumentOutOfRangeException: Value should not be less than 2/28/2042 4:41:46 PM. (Parameter 'dateTime')
dateTime.Throw().IfEquals(other); // System.ArgumentException: Value should not be equal to 2/28/2022 4:44:39 PM. (Parameter 'dateTime')
```

### Enums

```csharp
employeeType.Throw().IfOutOfRange(); // System.ArgumentOutOfRangeException: Value should be defined in enum. (Parameter 'employeeType')
employeeType.Throw().IfEquals(EmployeeType.FullTime); // System.ArgumentException: Value should not be equal to FullTime. (Parameter 'employeeType')
```

### Equalities (non-nullables)

```csharp
dateTime.Throw().IfDefault(); // System.ArgumentException: Value should not be default. (Parameter 'dateTime')
dateTime.Throw().IfNotDefault(); // System.ArgumentException: Value should be default. (Parameter 'dateTime')
```

### Uris

```csharp
uri.Throw().IfHttps(); // System.ArgumentException: Uri scheme should not be https. (Parameter 'uri')
uri.Throw().IfNotHttps(); // System.ArgumentException: Uri scheme should be https. (Parameter 'uri')
uri.Throw().IfHttp(); // System.ArgumentException: Uri scheme should not be http. (Parameter 'uri')
uri.Throw().IfNotHttp(); // System.ArgumentException: Uri scheme should be http. (Parameter 'uri')
uri.Throw().IfScheme(Uri.UriSchemeHttp); // System.ArgumentException: Uri scheme should not be http. (Parameter 'uri')
uri.Throw().IfSchemeNot(Uri.UriSchemeFtp); // System.ArgumentException: Uri scheme should be ftp. (Parameter 'uri')
uri.Throw().IfPort(800); // System.ArgumentException: Uri port should not be 80. (Parameter 'uri')
uri.Throw().IfPortNot(8080); // System.ArgumentException: Uri port should be 8080. (Parameter 'uri')
uri.Throw().IfAbsolute(); // System.ArgumentException: Uri should be relative. (Parameter 'uri')
uri.Throw().IfRelative(); // System.ArgumentException: Uri should be absolute. (Parameter 'uri')
uri.Throw().IfNotAbsolute(); // System.ArgumentException: Uri should be absolute. (Parameter 'uri')
uri.Throw().IfNotRelative(); // System.ArgumentException: Uri should be relative. (Parameter 'uri')
```

### Comparable (`int`, `double`, `decimal`, `long`, `float`, `short`, `DateTime`, `DateOnly`, `TimeOnly` etc.)

```csharp
number.Throw().IfPositive(); // System.ArgumentOutOfRangeException: Value should not be greater than 0. (Parameter 'number')\n Actual value was 5.
number.Throw().IfNegative(); // System.ArgumentOutOfRangeException: Value should not be less than 0. (Parameter 'number')\n Actual value was -5.
number.Throw().IfEquals(5); // System.ArgumentException: Value should not be not be equal to 5. (Parameter 'number')
number.Throw().IfNotEquals(3); // System.ArgumentException: Value should be equal to 3. (Parameter 'number')
number.Throw().IfLessThan(10); // System.ArgumentOutOfRangeException: Value should not be less than 10. (Parameter 'number')\n Actual value was 5.
number.Throw().IfGreaterThan(3); // System.ArgumentOutOfRangeException: Value should not be greater than 3. (Parameter 'number')\n Actual value was 5.
number.Throw().IfOutOfRange(0, 5); // System.ArgumentOutOfRangeException: Value should be between 0 and 5. (Parameter 'number')\n Actual value was -5.
```

## Nested properties

### Boolean properties

```csharp
person.Throw().IfTrue(p => p.IsFunny); // System.ArgumentException: Value should not meet condition (condition: 'person => person.IsFunny'). (Parameter 'person')
person.Throw().IfFalse(p => p.IsFunny); // System.ArgumentException: Value should meet condition (condition: 'person => person.IsFunny'). (Parameter 'person')

// We can inline the exception throwing logic with the method call.
Person person = GetPerson().Throw().IfTrue(person => person.Age < 18); // System.ArgumentException: Value should not meet condition (condition: 'person => person.Age < 18'). (Parameter 'GetPerson()')
```

### String properties

```csharp
person.Throw().IfEmpty(p => p.Name); // System.ArgumentException: String should not be empty. (Parameter 'person: p => p.Name')
person.Throw().IfWhiteSpace(p => p.Name); // System.ArgumentException: String should not be white space only. (Parameter 'person: p => p.Name')
person.Throw().IfShorterThan(p => p.Name, 10); // System.ArgumentException: String should not be shorter than 10 characters. (Parameter 'person: p => p.Name')
person.Throw().IfLongerThan(p => p.Name, 3); // System.ArgumentException: String should not be longer than 3 characters. (Parameter 'person: p => p.Name')
person.Throw().IfEquals(p => p.Name, "Amichai"); // System.ArgumentException: String should not be equal to 'Amichai'. (Parameter 'person: p => p.Name')
person.Throw().IfEqualsIgnoreCase(p => p.Name, "AMICHAI"); // System.ArgumentException: String should not be equal to 'AMICHAI' (case insensitive). (Parameter 'person: p => p.Name')
person.Throw().IfNotEquals(p => p.Name, "Dan"); // System.ArgumentException: String should be equal to 'Dan'. (Parameter 'person: p => p.Name')
person.Throw().IfNotEqualsIgnoreCase(p => p.Name, "Dan"); // System.ArgumentException: String should be equal to 'Dan' (case insensitive). (Parameter 'person: p => p.Name')
```

### Collection properties

```csharp
person.Throw().IfHasNullElements(p => p.Friends); // System.ArgumentException: Collection should not have null elements. (Parameter 'person: p => p.Friends')
person.Throw().IfEmpty(p => p.Friends); // System.ArgumentException: Collection should not be empty. (Parameter 'person: p => p.Friends')
person.Throw().IfNotEmpty(p => p.Friends); // System.ArgumentException: Collection should be empty. (Parameter 'person: p => p.Friends')
person.Throw().IfCountLessThan(p => p.Friends, 5); // System.ArgumentException: Collection count should not be less than 5. (Parameter 'person: p => p.Friends')
person.Throw().IfCountGreaterThan(p => p.Friends, 1); // System.ArgumentException: Collection count should not be greater than 1. (Parameter 'person: p => p.Friends')
person.Throw().IfCountEquals(p => p.Friends, 0); // System.ArgumentException: Collection count should not be equal to 0. (Parameter 'person: p => p.Friends')
person.Throw().IfCountNotEquals(p => p.Friends, 0); // System.ArgumentException: Collection count should be equal to 0. (Parameter 'person: p => p.Friends')
```

### DateTime properties

```csharp
person.Throw().IfUtc(p => p.DateOfBirth); // System.ArgumentException: Value should not be Utc. (Parameter 'person: p => p.DateOfBirth')
person.Throw().IfNotUtc(p => p.DateOfBirth); // System.ArgumentException: Value should be Utc. (Parameter 'person: p => p.DateOfBirth')
person.Throw().IfDateTimeKind(p => p.DateOfBirth, DateTimeKind.Unspecified); // System.ArgumentException: Value should not be Unspecified. (Parameter 'person: p => p.DateOfBirth')
person.Throw().IfDateTimeKindNot(p => p.DateOfBirth, DateTimeKind.Local); // System.ArgumentException: Value should be Local. (Parameter 'person: p => p.DateOfBirth')
person.Throw().IfGreaterThan(p => p.DateOfBirth, DateTime.Now.AddYears(-20)); // System.ArgumentOutOfRangeException: Value should not be greater than 2/28/2002 4:41:19 PM. (Parameter 'person: p => p.DateOfBirth')
person.Throw().IfLessThan(p => p.DateOfBirth, DateTime.Now.AddYears(20)); // System.ArgumentOutOfRangeException: Value should not be less than 2/28/2042 4:41:46 PM. (Parameter 'person: p => p.DateOfBirth')
person.Throw().IfEquals(p => p.DateOfBirth, other); // System.ArgumentException: Value should not be equal to 2/28/2022 4:45:12 PM. (Parameter 'person: p => p.DateOfBirth')
```

### Enum properties

```csharp
person.Throw().IfOutOfRange(p => p.EmployeeType); // System.ArgumentOutOfRangeException: Value should be defined in enum. (Parameter 'person: p => p.EmployeeType')
person.Throw().IfEquals(p => p.EmployeeType, EmployeeType.FullTime); // System.ArgumentException: Value should not be equal to FullTime. (Parameter 'person: p => p.EmployeeType')
```

### property equalities

```csharp
person.Throw().IfDefault(p => p.DateOfBirth); // System.ArgumentException: Value should not be default. (Parameter 'person: p => p.DateOfBirth')
person.Throw().IfNotDefault(p => p.DateOfBirth); // System.ArgumentException: Value should be default. (Parameter 'person: p => p.DateOfBirth')
person.Throw().IfNull(p => p.MiddleName); // System.ArgumentNullException: Value cannot be null. (Parameter 'person: p => p.MiddleName')
person.Throw().IfNotNull(p => p.MiddleName); // System.ArgumentException: Value should be null. (Parameter 'person: p => p.MiddleName')
```

### Uri properties

```csharp
person.Throw().IfHttps(p => p.Website); // System.ArgumentException: Uri scheme should not be https. (Parameter 'person: p => p.Website')
person.Throw().IfNotHttps(p => p.Website); // System.ArgumentException: Uri scheme should be https. (Parameter 'person: p => p.Website')
person.Throw().IfHttp(p => p.Website); // System.ArgumentException: Uri scheme should not be http. (Parameter 'person: p => p.Website')
person.Throw().IfNotHttp(p => p.Website); // System.ArgumentException: Uri scheme should be http. (Parameter 'person: p => p.Website')
person.Throw().IfScheme(p => p.Website, Uri.UriSchemeHttp); // System.ArgumentException: Uri scheme should not be http. (Parameter 'person: p => p.Website')
person.Throw().IfSchemeNot(p => p.Website, Uri.UriSchemeFtp); // System.ArgumentException: Uri scheme should be ftp. (Parameter 'person: p => p.Website')
person.Throw().IfPort(p => p.Website, 800); // System.ArgumentException: Uri port should not be 80. (Parameter 'person: p => p.Website')
person.Throw().IfPortNot(p => p.Website, 8080); // System.ArgumentException: Uri port should be 8080. (Parameter 'person: p => p.Website')
person.Throw().IfAbsolute(p => p.Website); // System.ArgumentException: Uri should be relative. (Parameter 'person: p => p.Website')
person.Throw().IfRelative(p => p.Website); // System.ArgumentException: Uri should be absolute. (Parameter 'person: p => p.Website')
person.Throw().IfNotAbsolute(p => p.Website); // System.ArgumentException: Uri should be absolute. (Parameter 'person: p => p.Website')
person.Throw().IfNotRelative(p => p.Website); // System.ArgumentException: Uri should be relative. (Parameter 'person: p => p.Website')
```

### Comparable properties

```csharp
person.Throw().IfPositive(p => p.Age); // System.ArgumentOutOfRangeException: Value should not be greater than 0. (Parameter 'person: p => p.Age')\n Actual value was 5.
person.Throw().IfNegative(p => p.Age); // System.ArgumentOutOfRangeException: Value should not be less than 0. (Parameter 'person: p => p.Age')\n Actual value was -5.
person.Throw().IfEquals(p => p.Age, 5); // System.ArgumentException: Value should not be not be equal to 5. (Parameter 'person: p => p.Age')
person.Throw().IfNotEquals(p => p.Age, 3); // System.ArgumentException: Value should be equal to 3. (Parameter 'person: p => p.Age')
person.Throw().IfLessThan(p => p.Age, 10); // System.ArgumentOutOfRangeException: Value should not be less than 10. (Parameter 'person: p => p.Age')\n Actual value was 5.
person.Throw().IfGreaterThan(p => p.Age, 3); // System.ArgumentOutOfRangeException: Value should not be greater than 3. (Parameter 'person: p => p.Age')\n Actual value was 5.
person.Throw().IfOutOfRange(p => p.Age, 0, 5); // System.ArgumentOutOfRangeException: Value should be between 0 and 5. (Parameter 'person: p => p.Age')\n Actual value was -5.
```

# Extensibility

You can easily extend the library by adding your own rules.

Here is a simple example:

```csharp
"foo".Throw().IfFoo(); // System.ArgumentException: String shouldn't equal 'foo' (Parameter '"foo"')
```

```csharp
namespace Throw
{
    public static class ValidatableExtensions
    {
        public static ref readonly Validatable<string> IfFoo(this in Validatable<string> validatable)
        {
            if (string.Equals(validatable.Value, "foo", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("String shouldn't equal 'foo'", validatable.ParamName);
            }

            return ref validatable;
        }
    }
}
```

Another example:

```csharp
user.Throw().IfUsesFacebookOnChrome();
```

```csharp
namespace Throw
{
    public static class ValidatableExtensions
    {
        public static ref readonly Validatable<User> IfUsesFacebookOnChrome(this in Validatable<User> validatable)
        {
            if (validatable.Value.FavoriteBrowser == Browser.Chrome && validatable.Value.FavoriteWebsite == new Uri("https://facebook.com"))
            {
                throw new UserException("User shouldn't use Facebook on Chrome!");
            }

            return ref validatable;
        }
    }
}
```

If you want to use the exception customizations in your extension. You can use the `ExceptionThrower` class which knows how to create the appropriate exception based on the customizations. For example:

```csharp
namespace Throw
{
    public static class ValidatableExtensions
    {
        public static ref readonly Validatable<User> IfUsesFacebookOnChrome(this in Validatable<User> validatable)
        {
            if (validatable.Value.FavoriteBrowser == Browser.Chrome && validatable.Value.FavoriteWebsite == new Uri("https://facebook.com"))
            {
                ExceptionThrower.Throw(validatable.ParamName, validatable.ExceptionCustomizations, "User shouldn't be using Facebook on Chrome.");
            }

            return ref validatable;
        }
    }
}
```

This will behave as following:

```csharp
user.Throw()
    .IfUsesFacebookOnChrome(); // System.ArgumentException: User shouldn't be using Facebook on Chrome. (Parameter 'user')
```

```csharp
user.Throw("A different message.")
    .IfUsesFacebookOnChrome(); // System.ArgumentException: A different message. (Parameter 'user')
```

```csharp
user.Throw(() => new Exception("A different exception."))
    .IfUsesFacebookOnChrome(); // System.Exception: A different exception.
```

```csharp
user.Throw(paramName => new Exception($"A different exception. Param name: '{paramName}'"))
    .IfUsesFacebookOnChrome(); // System.Exception: A different exception. Param name: 'user'
```

# Upcoming features

- Conditional compilation: An optional way to remove the validations from the release build
- Move extension methods: Many more rules to come! Please contribute!

# Contribution

Contributions are super welcome!
Please go ahead and open an issue with any idea, bug, or feature request.

We are trying to be the fastest validation library, so if you have any suggestions on how to improve the runtime speed, share them with us.

# Credits

- [Dawn.Guard](https://github.com/safakgur/guard) - An awesome, fast, and intuitive guard clause library for C#. Was a great inspiration for this library.

# License

This project is licensed under the terms of the [MIT](https://github.com/mantinband/github-contribution-art/blob/main/LICENSE) license.