using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codergies.VerifyNation.Tests;

[TestClass]
public class RuleFactoryTests
{
    [TestMethod]
    public void CreateTcknRules_ReturnsCorrectNumberOfRules()
    {
        // Act
        var rules = RuleFactory.CreateTcknRules().ToList();

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(3, rules.Count);
    }

    [TestMethod]
    public void CreateTcknRules_ContainsLengthValidationRule()
    {
        // Act
        var rules = RuleFactory.CreateTcknRules().ToList();

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(rules.Any(r => r is LengthValidationRule));
    }

    [TestMethod]
    public void CreateTcknRules_ContainsFirstDigitValidationRule()
    {
        // Act
        var rules = RuleFactory.CreateTcknRules().ToList();

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(rules.Any(r => r is FirstDigitValidationRule));
    }

    [TestMethod]
    public void CreateTcknRules_ContainsAlgorithmicValidationRule()
    {
        // Act
        var rules = RuleFactory.CreateTcknRules().ToList();

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(rules.Any(r => r is AlgorithmicValidationRule));
    }
}