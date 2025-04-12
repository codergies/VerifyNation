using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codergies.VerifyNation.Tests;

[TestClass]
public class AlgorithmicValidationRuleTests
{
    [TestMethod]
    public void Validate_WithValidTckn_ReturnsTrue()
    {
        // Arrange
        var rule = new AlgorithmicValidationRule();
        var context = new ValidationContext();
        var validTckn = "10000000146"; // Geçerli TCKN örneði

        // Act
        var result = rule.Validate(context, validTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result);
    }

    [TestMethod]
    public void Validate_WithInvalidTckn_ReturnsFalse()
    {
        // Arrange
        var rule = new AlgorithmicValidationRule();
        var context = new ValidationContext();
        var invalidTckn = "10000000145"; // Geçersiz TCKN örneði (son hane deðiþtirildi)

        // Act
        var result = rule.Validate(context, invalidTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }

    [TestMethod]
    public void Validate_WithInvalidTenthDigit_ReturnsFalse()
    {
        // Arrange
        var rule = new AlgorithmicValidationRule();
        var context = new ValidationContext();
        var invalidTckn = "10000000046"; // Geçersiz TCKN örneði (10. hane deðiþtirildi)

        // Act
        var result = rule.Validate(context, invalidTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }

    [TestMethod]
    public void Validate_WithShortTckn_ReturnsFalse()
    {
        // Arrange
        var rule = new AlgorithmicValidationRule();
        var context = new ValidationContext();
        var shortTckn = "123456789"; // 9 haneli, kýsa TCKN

        // Act
        var result = rule.Validate(context, shortTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }

    [TestMethod]
    public void Validate_WithLongTckn_ReturnsFalse()
    {
        // Arrange
        var rule = new AlgorithmicValidationRule();
        var context = new ValidationContext();
        var longTckn = "1234567890123"; // 13 haneli, uzun TCKN

        // Act
        var result = rule.Validate(context, longTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }

    [TestMethod]
    public void Validate_WithNonDigitCharacters_ReturnsFalse()
    {
        // Arrange
        var rule = new AlgorithmicValidationRule();
        var context = new ValidationContext();
        var nonDigitTckn = "1234567890A"; // Harf içeren TCKN

        // Act
        var result = rule.Validate(context, nonDigitTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }

    [TestMethod]
    public void Validate_WithNullString_ReturnsFalse()
    {
        // Arrange
        var rule = new AlgorithmicValidationRule();
        var context = new ValidationContext();
        string nullTckn = null;

        // Act
        var result = rule.Validate(context, nullTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }

    [TestMethod]
    public void Validate_WithEmptyString_ReturnsFalse()
    {
        // Arrange
        var rule = new AlgorithmicValidationRule();
        var context = new ValidationContext();
        var emptyTckn = string.Empty;

        // Act
        var result = rule.Validate(context, emptyTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }

    [TestMethod]
    public void Validate_WithChangedOddPositions_ReturnsFalse()
    {
        // Arrange
        var rule = new AlgorithmicValidationRule();
        var context = new ValidationContext();
        var invalidTckn = "20000000146"; // Tek pozisyondaki rakam deðiþtirildi

        // Act
        var result = rule.Validate(context, invalidTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }

    [TestMethod]
    public void Validate_WithChangedEvenPositions_ReturnsFalse()
    {
        // Arrange
        var rule = new AlgorithmicValidationRule();
        var context = new ValidationContext();
        var invalidTckn = "12000000146"; // Çift pozisyondaki rakam deðiþtirildi

        // Act
        var result = rule.Validate(context, invalidTckn);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }
}