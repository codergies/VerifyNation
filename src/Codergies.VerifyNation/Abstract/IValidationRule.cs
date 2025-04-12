

namespace Codergies.VerifyNation;

/// <summary>
/// Doğrulama kuralı arayüzü
/// </summary>
/// <typeparam name="T">Doğrulanacak nesne tipi</typeparam>
public interface IValidationRule<T>
{
    /// <summary>
    /// Kuralın adı
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Hata mesajı
    /// </summary>
    string ErrorMessage { get; }

    /// <summary>
    /// Verilen nesneyi doğrular
    /// </summary>
    /// <param name="context">Doğrulama bağlamı</param>
    /// <param name="input">Doğrulanacak nesne</param>
    /// <returns>Geçerli ise true, değilse false</returns>
    bool Validate(IValidationContext context, T input);
}