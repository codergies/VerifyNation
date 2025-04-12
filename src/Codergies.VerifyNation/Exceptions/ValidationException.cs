

namespace Codergies.VerifyNation;

/// <summary>
/// Doğrulama hatası istisnası
/// </summary>
public class ValidationException : Exception
{
    /// <summary>
    /// Hata mesajları
    /// </summary>
    public IReadOnlyList<string> Errors { get; }

    /// <summary>
    /// Doğrulama hatası istisnası oluşturur
    /// </summary>
    /// <param name="message">Hata mesajı</param>
    public ValidationException(string message) : base(message)
    {
        Errors = new List<string> { message };
    }

    /// <summary>
    /// Doğrulama hatası istisnası oluşturur
    /// </summary>
    /// <param name="errors">Hata mesajları</param>
    public ValidationException(IEnumerable<string> errors) : base(string.Join(", ", errors))
    {
        Errors = new List<string>(errors);
    }
}