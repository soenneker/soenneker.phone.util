using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Phone.Util.Abstract;
using Soenneker.Utils.Libphonenumber.Registrars;

namespace Soenneker.Phone.Util.Registrars;

/// <summary>
/// A utility library for phone related operations
/// </summary>
public static class PhoneUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IPhoneUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddPhoneUtilAsSingleton(this IServiceCollection services)
    {
        services.AddLibphonenumberUtilAsSingleton().TryAddSingleton<IPhoneUtil, PhoneUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IPhoneUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddPhoneUtilAsScoped(this IServiceCollection services)
    {
        services.AddLibphonenumberUtilAsSingleton().TryAddScoped<IPhoneUtil, PhoneUtil>();

        return services;
    }
}
