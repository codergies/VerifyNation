

namespace Codergies.VerifyNation;

/// <summary>
/// TC Kimlik Numarası ilk hane doğrulama kuralı
/// </summary>
public class FirstDigitValidationRule : IValidationRule<string>
{
    /// <summary>
    /// Kuralın adı
    /// </summary>
    public string Name => "FirstDigitRule";

    /// <summary>
    /// Hata mesajı
    /// </summary>
    public string ErrorMessage => "TC Kimlik Numarasının ilk hanesi 0 olamaz.";

    /// <summary>
    /// TC Kimlik Numarası ilk hanesini doğrular
    /// </summary>
    /// <param name="context">Doğrulama bağlamı</param>
    /// <param name="input">TC Kimlik Numarası</param>
    /// <returns>Geçerli ise true, değilse false</returns>
    public bool Validate(IValidationContext context, string input)
    {
        if (string.IsNullOrWhiteSpace(input) || input.Length < 1)
        {
            return false;
        }

        // İlk hane 0 olmamalıdır
        return input[0] != '0';
    }
}