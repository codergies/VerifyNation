
namespace Codergies.VerifyNation;

/// <summary>
/// Doğrulama bağlamı arayüzü
/// </summary>
public interface IValidationContext
{
    /// <summary>
    /// Bağlama veri ekler
    /// </summary>
    /// <typeparam name="TValue">Eklenecek verinin tipi</typeparam>
    /// <param name="key">Verinin anahtarı</param>
    /// <param name="value">Verinin değeri</param>
    void AddData<TValue>(string key, TValue value);

    /// <summary>
    /// Bağlamdan veri alır
    /// </summary>
    /// <typeparam name="TValue">Alınacak verinin tipi</typeparam>
    /// <param name="key">Verinin anahtarı</param>
    /// <returns>Verinin değeri</returns>
    TValue GetData<TValue>(string key);

    /// <summary>
    /// Bağlamda belirtilen anahtar var mı kontrolü yapar
    /// </summary>
    /// <param name="key">Kontrol edilecek anahtar</param>
    /// <returns>Anahtar var ise true, değilse false</returns>
    bool HasData(string key);
}