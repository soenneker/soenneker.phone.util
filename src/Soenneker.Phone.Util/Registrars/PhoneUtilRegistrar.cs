using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Phone.Util.Abstract;
using Soenneker.Utils.Libphonenumber.Registrars;

namespace Soenneker.Phone.Util.Registrars;

/// <summary>
/// Registers the phone-number utility and shared libphonenumber provider.
/// </summary>
public static class PhoneUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IPhoneUtil"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddPhoneUtilAsSingleton(this IServiceCollection services)
    {
        services.AddLibphonenumberUtilAsSingleton().TryAddSingleton<IPhoneUtil, PhoneUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IPhoneUtil"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddPhoneUtilAsScoped(this IServiceCollection services)
    {
        services.AddLibphonenumberUtilAsSingleton().TryAddScoped<IPhoneUtil, PhoneUtil>();

        return services;
    }
}
