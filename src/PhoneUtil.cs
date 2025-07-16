using PhoneNumbers;
using Soenneker.Extensions.ValueTask;
using Soenneker.Phone.Util.Abstract;
using Soenneker.Utils.Libphonenumber.Abstract;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Phone.Util;

/// <inheritdoc cref="IPhoneUtil"/>
public sealed class PhoneUtil: IPhoneUtil
{
    private readonly ILibphonenumberUtil _libPhoneNumberUtil;

    public PhoneUtil(ILibphonenumberUtil libPhoneNumberUtil)
    {
        _libPhoneNumberUtil = libPhoneNumberUtil;
    }

    public async ValueTask<string> ToE164(string phone, string defaultRegion = "US", CancellationToken cancellationToken = default)
    {
        PhoneNumberUtil util = await _libPhoneNumberUtil.Get(cancellationToken).NoSync();

        PhoneNumber parsed = util.Parse(phone, defaultRegion);

        return util.Format(parsed, PhoneNumberFormat.E164);  // always “+CCxxxxxxxx”
    }
}
