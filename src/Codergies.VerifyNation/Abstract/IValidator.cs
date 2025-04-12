

namespace Codergies.VerifyNation;

/// <summary>
/// Generic doğrulama arayüzü
/// </summary>
/// <typeparam name="T">Doğrulanacak nesne tipi</typeparam>
public interface IValidator<T>
{
    /// <summary>
    /// Verilen nesneyi doğrular
    /// </summary>
    /// <param name="input">Doğrulanacak nesne</param>
    /// <returns>Doğrulama sonucunu içeren ValidationResult nesnesi</returns>
    ValidationResult Validate(T input);

    /// <summary>
    /// Verilen nesne geçerli mi kontrolü yapar
    /// </summary>
    /// <param name="input">Doğrulanacak nesne</param>
    /// <returns>Geçerli ise true, değilse false</returns>
    bool IsValid(T input);
}