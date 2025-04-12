

namespace Codergies.VerifyNation;

/// <summary>
/// Doğrulama bağlamı uygulaması
/// </summary>
public class ValidationContext : IValidationContext
{
    private readonly Dictionary<string, object> _data = new Dictionary<string, object>();

    /// <summary>
    /// Bağlama veri ekler
    /// </summary>
    /// <typeparam name="TValue">Eklenecek verinin tipi</typeparam>
    /// <param name="key">Verinin anahtarı</param>
    /// <param name="value">Verinin değeri</param>
    public void AddData<TValue>(string key, TValue value)
    {
        _data[key] = value;
    }

    /// <summary>
    /// Bağlamdan veri alır
    /// </summary>
    /// <typeparam name="TValue">Alınacak verinin tipi</typeparam>
    /// <param name="key">Verinin anahtarı</param>
    /// <returns>Verinin değeri</returns>
    public TValue GetData<TValue>(string key)
    {
        if (_data.TryGetValue(key, out var value) && value is TValue typedValue)
        {
            return typedValue;
        }

        return default;
    }

    /// <summary>
    /// Bağlamda belirtilen anahtar var mı kontrolü yapar
    /// </summary>
    /// <param name="key">Kontrol edilecek anahtar</param>
    /// <returns>Anahtar var ise true, değilse false</returns>
    public bool HasData(string key)
    {
        return _data.ContainsKey(key);
    }
}