using Codergies.VerifyNation;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("TC Kimlik Numarası Doğrulama Örneği");
        Console.WriteLine("-----------------------------------");

        // 1. Dependency Injection ile kullanım
        Console.WriteLine("1. Dependency Injection ile kullanım:");
        var serviceProvider = new ServiceCollection()
            .AddTcknValidator()
            .BuildServiceProvider();

        var validator = serviceProvider.GetRequiredService<IValidator<string>>();

        // 2. Doğrudan oluşturma ile kullanım
        Console.WriteLine("\n2. Doğrudan oluşturma ile kullanım:");
        var directValidator = new TcknValidator(RuleFactory.CreateTcknRules());

        // Örnekler
        ValidateSample(validator, "10000000146");  // Geçerli TCKN
        ValidateSample(validator, "12345678901");  // Geçersiz TCKN
        ValidateSample(validator, "1234");         // Geçersiz TCKN (Kısa)
        ValidateSample(validator, "00000000000");  // Geçersiz TCKN (İlk rakam 0)

        Console.WriteLine("\nProgramı sonlandırmak için bir tuşa basın...");
        Console.ReadKey();
    }

    static void ValidateSample(IValidator<string> validator, string tckn)
    {
        var result = validator.Validate(tckn);
        Console.WriteLine($"\nTC Kimlik Numarası: {tckn}");
        Console.WriteLine($"Geçerli mi: {result.IsValid}");

        if (!result.IsValid)
        {
            Console.WriteLine("Hatalar:");
            foreach (var error in result.ErrorMessages)
            {
                Console.WriteLine($"- {error}");
            }
        }
    }
}