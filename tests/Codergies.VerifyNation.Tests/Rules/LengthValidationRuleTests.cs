using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codergies.VerifyNation.Tests;

[TestClass]
public class LengthValidationRuleTests
{
    [TestMethod]
    public void Validate_WithCorrectLength_ReturnsTrue()
    {
        // Arrange
        var rule = new LengthValidationRule();
        var context = new ValidationContext();
        var validLengthTckn = "12345678901"; // 11 haneli

        // Act
        var result = rule.Validate(context, validLengthTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result);
    }

    [TestMethod]
    public void Validate_WithTooShortTckn_ReturnsFalse()
    {
        // Arrange
        var rule = new LengthValidationRule();
        var context = new ValidationContext();
        var tooShortTckn = "1234567890"; // 10 haneli

        // Act
        var result = rule.Validate(context, tooShortTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }

    [TestMethod]
    public void Validate_WithTooLongTckn_ReturnsFalse()
    {
        // Arrange
        var rule = new LengthValidationRule();
        var context = new ValidationContext();
        var tooLongTckn = "123456789012"; // 12 haneli

        // Act
        var result = rule.Validate(context, tooLongTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }

    [TestMethod]
    public void Validate_WithNonDigitCharacters_ReturnsFalse()
    {
        // Arrange
        var rule = new LengthValidationRule();
        var context = new ValidationContext();
        var nonDigitTckn = "1234567890A"; // Harf içeriyor

        // Act
        var result = rule.Validate(context, nonDigitTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }
    [TestMethod]
    public void Validate_WithNullOrEmpty_ReturnsFalse()
    {
        // Arrange
        var rule = new LengthValidationRule();
        var context = new ValidationContext();

        // Act - Null
        var resultNull = rule.Validate(context, null);

        // Act - Empty
        var resultEmpty = rule.Validate(context, string.Empty);

        // Act - Whitespace
        var resultWhitespace = rule.Validate(context, "   ");

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(resultNull);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(resultEmpty);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(resultWhitespace);
    }
}
