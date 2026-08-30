using PhoneNumbers;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Phone.Util.Abstract;

/// <summary>
/// Parses, validates, and formats phone numbers.
/// </summary>
public interface IPhoneUtil
{
    /// <summary>
    /// Parses and validates a dialable string, then formats it as E.164 using libphonenumber.
    /// National numbers must supply <paramref name="defaultRegion"/> (ISO‑3166
    /// alpha‑2, e.g. "US", "GB").  International numbers already starting with
    /// ‘+’ are parsed regardless of region.
    /// </summary>
    /// <param name="phone">The phone number to parse.</param>
    /// <param name="defaultRegion">The ISO 3166-1 alpha-2 region used for a national number.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The validated number in E.164 form.</returns>
    /// <exception cref="NumberParseException">The input is not a valid number
    /// for the given region.</exception>
    /// <exception cref="System.InvalidOperationException">The number parses but is not valid for the resolved region.</exception>
    [Pure]
    ValueTask<string> ToE164(string phone, string defaultRegion = "US", CancellationToken cancellationToken = default);
}
