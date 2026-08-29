using PhoneNumbers;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Phone.Util.Abstract;

/// <summary>
/// A utility library for phone related operations
/// </summary>
public interface IPhoneUtil
{
    /// <summary>
    /// Converts any dialable string to strict “+E.164” using libphonenumber.
    /// National numbers must supply <paramref name="defaultRegion"/> (ISO‑3166
    /// alpha‑2, e.g. "US", "GB").  International numbers already starting with
    /// ‘+’ are parsed regardless of region.
    /// </summary>
    /// <param name="phone">Phone for the to e operation.</param>
    /// <param name="defaultRegion">Default Region for the to e operation.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the text returned by to E.</returns>
    /// <exception cref="NumberParseException">The input is not a valid number
    /// for the given region.</exception>
    [Pure]
    ValueTask<string> ToE164(string phone, string defaultRegion = "US", CancellationToken cancellationToken = default);
}
