

namespace Codergies.VerifyNation;

/// <summary>
/// Doğrulama kuralları fabrikası
/// </summary>
public static class RuleFactory
{
    /// <summary>
    /// Tüm TC Kimlik Numarası doğrulama kurallarını oluşturur
    /// </summary>
    /// <returns>TC Kimlik Numarası doğrulama kuralları</returns>
    public static IEnumerable<IValidationRule<string>> CreateTcknRules()
    {
        return new List<IValidationRule<string>>
                {
                    new LengthValidationRule(),
                    new FirstDigitValidationRule(),
                    new AlgorithmicValidationRule()
                };
    }
}