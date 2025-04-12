

namespace Codergies.VerifyNation;

/// <summary>
/// TC Kimlik Numarası doğrulayıcı
/// </summary>
public class TcknValidator : IValidator<string>
{
    private readonly IEnumerable<IValidationRule<string>> _rules;
    private readonly IValidationContext _context;

    /// <summary>
    /// TC Kimlik Numarası doğrulayıcı oluşturur
    /// </summary>
    /// <param name="rules">Doğrulama kuralları</param>
    /// <param name="context">Doğrulama bağlamı</param>
    public TcknValidator(IEnumerable<IValidationRule<string>> rules, IValidationContext context = null)
    {
        _rules = rules ?? throw new System.ArgumentNullException(nameof(rules));
        _context = context ?? new ValidationContext();
    }

    /// <summary>
    /// TC Kimlik Numarasını doğrular
    /// </summary>
    /// <param name="input">TC Kimlik Numarası</param>
    /// <returns>Doğrulama sonucu</returns>
    public ValidationResult Validate(string input)
    {
        var errorMessages = new List<string>();

        foreach (var rule in _rules)
        {
            if (!rule.Validate(_context, input))
            {
                errorMessages.Add(rule.ErrorMessage);
            }
        }

        return errorMessages.Any()
            ? ValidationResult.Failure(errorMessages)
            : ValidationResult.Success();
    }

    /// <summary>
    /// TC Kimlik Numarası geçerli mi kontrolü yapar
    /// </summary>
    /// <param name="input">TC Kimlik Numarası</param>
    /// <returns>Geçerli ise true, değilse false</returns>
    public bool IsValid(string input)
    {
        return Validate(input).IsValid;
    }

    /// <summary>
    /// TC Kimlik Numarasını doğrular, geçersiz ise istisna fırlatır
    /// </summary>
    /// <param name="input">TC Kimlik Numarası</param>
    /// <exception cref="ValidationException">Doğrulama hatası durumunda fırlatılır</exception>
    public void ValidateAndThrow(string input)
    {
        var result = Validate(input);
        if (!result.IsValid)
        {
            throw new ValidationException(result.ErrorMessages);
        }
    }
}
