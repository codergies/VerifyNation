

namespace Codergies.VerifyNation;

/// <summary>
/// TC Kimlik Numarası uzunluk doğrulama kuralı
/// </summary>
public class LengthValidationRule : IValidationRule<string>
{
    /// <summary>
    /// Kuralın adı
    /// </summary>
    public string Name => "TCKNLengthRule";

    /// <summary>
    /// Hata mesajı
    /// </summary>
    public string ErrorMessage => "TC Kimlik Numarası 11 haneli olmalıdır.";

    /// <summary>
    /// TC Kimlik Numarası uzunluğunu doğrular
    /// </summary>
    /// <param name="context">Doğrulama bağlamı</param>
    /// <param name="input">TC Kimlik Numarası</param>
    /// <returns>Geçerli ise true, değilse false</returns>
    public bool Validate(IValidationContext context, string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        // TCKN 11 haneli olmalıdır
        if (input.Length != 11)
        {
            return false;
        }

        // TCKN sadece rakamlardan oluşmalıdır
        foreach (char c in input)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }

        return true;
    }
}