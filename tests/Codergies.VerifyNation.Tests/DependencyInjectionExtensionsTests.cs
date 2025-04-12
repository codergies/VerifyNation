using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codergies.VerifyNation.Tests;

[TestClass]
public class DependencyInjectionExtensionsTests
{
    [TestMethod]
    public void AddTcknValidator_RegistersServices()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddTcknValidator();
        var serviceProvider = services.BuildServiceProvider();

        // Assert
        var validator = serviceProvider.GetService<IValidator<string>>();
        var context = serviceProvider.GetService<IValidationContext>();
        var rules = serviceProvider.GetServices<IValidationRule<string>>();

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(validator);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(context);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(rules != null && rules.GetEnumerator().MoveNext()); // En az bir kural var
    }

    [TestMethod]
    public void AddTcknValidator_RegistersCorrectImplementations()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddTcknValidator();
        var serviceProvider = services.BuildServiceProvider();

        // Assert
        var validator = serviceProvider.GetService<IValidator<string>>();
        var context = serviceProvider.GetService<IValidationContext>();

        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(validator, typeof(TcknValidator));
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(context, typeof(ValidationContext));
    }

    [TestMethod]
    public void AddTcknValidator_CanResolveAndValidate()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddTcknValidator();
        var serviceProvider = services.BuildServiceProvider();

        // Act
        var validator = serviceProvider.GetRequiredService<IValidator<string>>();
        var validResult = validator.Validate("10000000146"); // Geçerli TCKN
        var invalidResult = validator.Validate("00000000000"); // Geçersiz TCKN

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(validResult.IsValid);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(invalidResult.IsValid);
    }
}