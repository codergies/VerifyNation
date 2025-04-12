using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codergies.VerifyNation.Tests;

[TestClass]
public class FirstDigitValidationRuleTests
{
    [TestMethod]
    public void Validate_WithNonZeroFirstDigit_ReturnsTrue()
    {
        // Arrange
        var rule = new FirstDigitValidationRule();
        var context = new ValidationContext();
        var validTckn = "12345678901"; // Ýlk hane 1

        // Act
        var result = rule.Validate(context, validTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result);
    }

    [TestMethod]
    public void Validate_WithZeroFirstDigit_ReturnsFalse()
    {
        // Arrange
        var rule = new FirstDigitValidationRule();
        var context = new ValidationContext();
        var invalidTckn = "02345678901"; // Ýlk hane 0

        // Act
        var result = rule.Validate(context, invalidTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }

    [TestMethod]
    public void Validate_WithEmptyString_ReturnsFalse()
    {
        // Arrange
        var rule = new FirstDigitValidationRule();
        var context = new ValidationContext();
        var emptyTckn = string.Empty;

        // Act
        var result = rule.Validate(context, emptyTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }

    [TestMethod]
    public void Validate_WithNullString_ReturnsFalse()
    {
        // Arrange
        var rule = new FirstDigitValidationRule();
        var context = new ValidationContext();
        string nullTckn = null;

        // Act
        var result = rule.Validate(context, nullTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }

    [TestMethod]
    public void Validate_WithSingleCharacter_ReturnsTrue()
    {
        // Arrange
        var rule = new FirstDigitValidationRule();
        var context = new ValidationContext();
        var singleCharTckn = "1"; // Sadece bir karakter ama 0 deðil

        // Act
        var result = rule.Validate(context, singleCharTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result);
    }

    [TestMethod]
    public void Validate_WithSingleZeroCharacter_ReturnsFalse()
    {
        // Arrange
        var rule = new FirstDigitValidationRule();
        var context = new ValidationContext();
        var singleZeroTckn = "0"; // Sadece bir karakter ve 0

        // Act
        var result = rule.Validate(context, singleZeroTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }
}