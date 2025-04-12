
namespace Codergies.VerifyNation;

/// <summary>
/// Doğrulama sonucunu temsil eden sınıf
/// </summary>
public class ValidationResult
{
    /// <summary>
    /// Doğrulama başarılı mı
    /// </summary>
    public bool IsValid { get; }

    /// <summary>
    /// Hata mesajları listesi
    /// </summary>
    public IReadOnlyList<string> ErrorMessages { get; }

    /// <summary>
    /// Başarılı doğrulama sonucu oluşturur
    /// </summary>
    public static ValidationResult Success() => new ValidationResult(true, new List<string>());

    /// <summary>
    /// Başarısız doğrulama sonucu oluşturur
    /// </summary>
    /// <param name="errorMessages">Hata mesajları</param>
    public static ValidationResult Failure(IEnumerable<string> errorMessages) =>
        new ValidationResult(false, new List<string>(errorMessages));

    /// <summary>
    /// Başarısız doğrulama sonucu oluşturur
    /// </summary>
    /// <param name="errorMessage">Hata mesajı</param>
    public static ValidationResult Failure(string errorMessage) =>
        new ValidationResult(false, new List<string> { errorMessage });

    private ValidationResult(bool isValid, IReadOnlyList<string> errorMessages)
    {
        IsValid = isValid;
        ErrorMessages = errorMessages;
    }
}