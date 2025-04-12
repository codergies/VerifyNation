using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codergies.VerifyNation.Tests;

[TestClass]
public class ValidationExceptionTests
{
    [TestMethod]
    public void Constructor_WithSingleError_CreatesExceptionWithSingleError()
    {
        // Arrange
        string errorMessage = "Test error message";

        // Act
        var exception = new ValidationException(errorMessage);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(errorMessage, exception.Message);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, exception.Errors.Count);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(errorMessage, exception.Errors.First());
    }

    [TestMethod]
    public void Constructor_WithMultipleErrors_CreatesExceptionWithMultipleErrors()
    {
        // Arrange
        var errorMessages = new List<string>
            {
                "Error 1",
                "Error 2",
                "Error 3"
            };
        string combinedErrorMessage = "Error 1, Error 2, Error 3";

        // Act
        var exception = new ValidationException(errorMessages);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(combinedErrorMessage, exception.Message);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(errorMessages.Count, exception.Errors.Count);
        CollectionAssert.AreEqual(errorMessages, exception.Errors.ToList());
    }

    [TestMethod]
    public void Constructor_WithEmptyErrorList_CreatesExceptionWithNoErrors()
    {
        // Arrange
        var errorMessages = new List<string>();

        // Act
        var exception = new ValidationException(errorMessages);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(string.Empty, exception.Message);
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, exception.Errors.Count);
    }
}