


using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codergies.VerifyNation.Tests;

[TestClass]
public class TcknValidatorTests
{
    [TestMethod]
    public void IsValid_WithValidTckn_ReturnsTrue()
    {
        // Arrange
        var validator = new TcknValidator(RuleFactory.CreateTcknRules());
        var validTckn = "10000000146"; // Geçerli TCKN örneði

        // Act
        var result = validator.IsValid(validTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsValid_WithInvalidTckn_ReturnsFalse()
    {
        // Arrange
        var validator = new TcknValidator(RuleFactory.CreateTcknRules());
        var invalidTckn = "12345678901"; // Geçersiz TCKN örneði

        // Act
        var result = validator.IsValid(invalidTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }

    [TestMethod]
    public void Validate_WithValidTckn_ReturnsSuccessResult()
    {
        // Arrange
        var validator = new TcknValidator(RuleFactory.CreateTcknRules());
        var validTckn = "10000000146"; // Geçerli TCKN örneði

        // Act
        var result = validator.Validate(validTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result.IsValid);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.ErrorMessages.Count);
    }

    [TestMethod]
    public void Validate_WithInvalidTckn_ReturnsFailureResult()
    {
        // Arrange
        var validator = new TcknValidator(RuleFactory.CreateTcknRules());
        var invalidTckn = "12345678901"; // Geçersiz TCKN örneði

        // Act
        var result = validator.Validate(invalidTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result.IsValid);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result.ErrorMessages.Count > 0);
    }

    [TestMethod]
    public void ValidateAndThrow_WithValidTckn_DoesNotThrow()
    {
        // Arrange
        var validator = new TcknValidator(RuleFactory.CreateTcknRules());
        var validTckn = "10000000146"; // Geçerli TCKN örneði

        // Act & Assert
        // Hata fýrlatýlmazsa test baþarýlý olur
        try
        {
            validator.ValidateAndThrow(validTckn);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(true); // No exception means success
        }
        catch
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Exception was thrown for valid TCKN");
        }
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void ValidateAndThrow_WithInvalidTckn_ThrowsValidationException()
    {
        // Arrange
        var validator = new TcknValidator(RuleFactory.CreateTcknRules());
        var invalidTckn = "12345678901"; // Geçersiz TCKN örneði

        // Act
        // Hata fýrlatýlýrsa test baþarýlý olur
        validator.ValidateAndThrow(invalidTckn);
    }
}