using Microsoft.Extensions.DependencyInjection;

namespace Codergies.VerifyNation;

/// <summary>
/// Dependency Injection uzantıları
/// </summary>
public static class DependencyInjectionExtensions
{
    /// <summary>
    /// TC Kimlik Numarası doğrulama servislerini ekler
    /// </summary>
    /// <param name="services">Servis koleksiyonu</param>
    public static IServiceCollection AddTcknValidator(this IServiceCollection services)
    {
        // Doğrulama bağlamını ekle
        services.AddScoped<IValidationContext, ValidationContext>();

        // Doğrulama kurallarını ekle
        foreach (var rule in RuleFactory.CreateTcknRules())
        {
            services.AddScoped<IValidationRule<string>>(provider => rule);
        }

        // Doğrulayıcıyı ekle
        services.AddScoped<IValidator<string>>(provider =>
        {
            var rules = provider.GetServices<IValidationRule<string>>();
            var context = provider.GetRequiredService<IValidationContext>();
            return new TcknValidator(rules, context);
        });

        return services;
    }
}