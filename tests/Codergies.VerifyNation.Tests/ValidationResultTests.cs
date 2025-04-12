using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codergies.VerifyNation.Tests;

[TestClass]
public class ValidationResultTests
{
    [TestMethod]
    public void Success_ReturnsValidResult()
    {
        // Act
        var result = ValidationResult.Success();

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result.IsValid);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.ErrorMessages.Count);
    }

    [TestMethod]
    public void Failure_WithSingleError_ReturnsInvalidResult()
    {
        // Arrange
        string errorMessage = "Test error message";

        // Act
        var result = ValidationResult.Failure(errorMessage);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result.IsValid);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, result.ErrorMessages.Count);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(errorMessage, result.ErrorMessages.First());
    }

    [TestMethod]
    public void Failure_WithMultipleErrors_ReturnsInvalidResult()
    {
        // Arrange
        var errorMessages = new List<string>
            {
                "Error 1",
                "Error 2",
                "Error 3"
            };

        // Act
        var result = ValidationResult.Failure(errorMessages);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result.IsValid);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(errorMessages.Count, result.ErrorMessages.Count);
        CollectionAssert.AreEqual(errorMessages, result.ErrorMessages.ToList());
    }
}