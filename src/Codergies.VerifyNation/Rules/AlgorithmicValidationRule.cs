

namespace Codergies.VerifyNation;

/// <summary>
/// TC Kimlik Numarası algoritma doğrulama kuralı
/// </summary>
public class AlgorithmicValidationRule : IValidationRule<string>
{
    /// <summary>
    /// Kuralın adı
    /// </summary>
    public string Name => "TCKNAlgorithmRule";

    /// <summary>
    /// Hata mesajı
    /// </summary>
    public string ErrorMessage => "TC Kimlik Numarası algoritması geçersizdir.";

    /// <summary>
    /// TC Kimlik Numarası algoritmasını doğrular
    /// </summary>
    /// <param name="context">Doğrulama bağlamı</param>
    /// <param name="input">TC Kimlik Numarası</param>
    /// <returns>Geçerli ise true, değilse false</returns>
    public bool Validate(IValidationContext context, string input)
    {
        if (string.IsNullOrWhiteSpace(input) || input.Length != 11)
        {
            return false;
        }

        try
        {
            // TCKN'yi sayısal diziye dönüştür
            int[] digits = new int[11];
            for (int i = 0; i < 11; i++)
            {
                digits[i] = int.Parse(input[i].ToString());
            }

            // 10. hane kontrolü: İlk 9 hanenin toplamının mod 10'u
            int sumOfFirst9 = 0;
            for (int i = 0; i < 9; i++)
            {
                sumOfFirst9 += digits[i];
            }
            if (sumOfFirst9 % 10 != digits[9])
            {
                return false;
            }

            // 11. hane kontrolü: İlk 10 hanenin toplamının mod 10'u
            int sumOfFirst10 = 0;
            for (int i = 0; i < 10; i++)
            {
                sumOfFirst10 += digits[i];
            }
            if (sumOfFirst10 % 10 != digits[10])
            {
                return false;
            }

            // Tek ve çift indeksli rakamların toplamları kontrolü
            int oddSum = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
            int evenSum = digits[1] + digits[3] + digits[5] + digits[7];

            // (OddSum * 7 - EvenSum) % 10 = 10. hane
            if ((oddSum * 7 - evenSum) % 10 != digits[9])
            {
                return false;
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}