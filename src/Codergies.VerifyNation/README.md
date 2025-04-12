# VerifyNation

Republic of Turkey Identity Number (TCKN) is a lightweight and extensible .NET library developed to perform authentication.

[![NuGet](https://img.shields.io/nuget/v/VerifyNation.svg)](https://www.nuget.org/packages/VerifyNation/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/VerifyNation.svg)](https://www.nuget.org/packages/VerifyNation/)

## Features

- TCKN standard algorithmic validation
- TCKN length and first digit check
- Extensible validation rules
- .NET 9.0+ support
- Easy integration with Dependency Injection
- Full unit test coverage

## Installation

Using Package Manager Console:

```
Install-Package VerifyNation
```

Using the .NET CLI:

```
dotnet add package VerifyNation
```

## Usage

### Basic Usage

```csharp
using VerifyNation;

// Validation process
string tckn = "10000000146";
var validator = new VerifyNation.Core.TcknValidator();
var result = validator.Validate(tckn);

if (result.IsValid)
{
    Console.WriteLine("TCKN is valid.");
}
else
{
    Console.WriteLine("TCKN is invalid: " + string.Join(", ", result.ErrorMessages));
}
```

### Use with Dependency Injection

```csharp
// Startup.cs or Program.cs
using VerifyNation.Extensions;

// Extension on IServiceCollection
services.AddTcknValidator();

// In Controller or Service class
public class MyService
{
    private readonly IValidator<string> _tcknValidator;

    public MyService(IValidator<string> tcknValidator)
    {
        _tcknValidator = tcknValidator;
    }

    public void ValidateTckn(string tckn)
    {
        var result = _tcknValidator.Validate(tckn);
        // ...processes
    }
}
```

### Error Handling

```csharp
using VerifyNation.Exceptions;

try
{
    var validator = new VerifyNation.Core.TcknValidator();
    var result = validator.ValidateWithException("invalid-tckn");
        // Works on successful verification
}
catch (ValidationException ex)
{
    // Works in case of error
    Console.WriteLine($"Validation error: {ex.Message}");
    Console.WriteLine($"Errors: {string.Join(", ", ex.Errors)}");
}
```

## Validation Rules

TcknValidator includes the following validation rules:

1. **Length Check**: TCKN must have 11 digits and all characters must be digits.
2. **First Digit Check**: The first digit of the TCKN cannot be 0.
3. **Algorithmic Verification**: 
   - The algorithmically calculated result of the first 10 digits must yield the 11th digit.
   - The algorithmically calculated result of the first 9 digits must give the 10th digit.

## Add Custom Validation Rules

```csharp
using VerifyNation.Abstract;
using VerifyNation.Core;

// Defining a custom rule
public class CustomTcknRule : IValidationRule<string>
{
    public bool Validate(IValidationContext context, string input)
    {
        // Custom validation logic
        return true; // or false
    }
}

// Using the special rule
var validator = new TcknValidator.Core.TcknValidator();
validator.AddRule(new CustomTcknRule());
var result = validator.Validate("10000000146");
```

## License

This project is licensed under the MIT license. For more information, see [LICENSE](LICENSE).

## Contribution

To contribute, please open an issue or submit a pull request.