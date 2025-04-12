using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codergies.VerifyNation.Tests;

[TestClass]
public class ValidationContextTests
{
    [TestMethod]
    public void AddData_AndGetData_WorksCorrectly()
    {
        // Arrange
        var context = new ValidationContext();
        string key = "testKey";
        string value = "testValue";

        // Act
        context.AddData(key, value);
        var retrievedValue = context.GetData<string>(key);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(value, retrievedValue);
    }

    [TestMethod]
    public void HasData_WithExistingKey_ReturnsTrue()
    {
        // Arrange
        var context = new ValidationContext();
        string key = "testKey";
        string value = "testValue";
        context.AddData(key, value);

        // Act
        var result = context.HasData(key);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result);
    }

    [TestMethod]
    public void HasData_WithNonExistingKey_ReturnsFalse()
    {
        // Arrange
        var context = new ValidationContext();
        string key = "nonExistingKey";

        // Act
        var result = context.HasData(key);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
    }

    [TestMethod]
    public void GetData_WithNonExistingKey_ReturnsDefault()
    {
        // Arrange
        var context = new ValidationContext();
        string key = "nonExistingKey";

        // Act
        var result = context.GetData<string>(key);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(default(string), result);
    }

    [TestMethod]
    public void GetData_WithWrongType_ReturnsDefault()
    {
        // Arrange
        var context = new ValidationContext();
        string key = "testKey";
        string value = "testValue";
        context.AddData(key, value);

        // Act
        var result = context.GetData<int>(key);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(default(int), result);
    }

    [TestMethod]
    public void AddData_WithSameKey_OverwritesValue()
    {
        // Arrange
        var context = new ValidationContext();
        string key = "testKey";
        string value1 = "testValue1";
        string value2 = "testValue2";

        // Act
        context.AddData(key, value1);
        context.AddData(key, value2);
        var retrievedValue = context.GetData<string>(key);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(value2, retrievedValue);
    }
}