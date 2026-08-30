using System;
using System.Threading.Tasks;
using Soenneker.Phone.Util.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Phone.Util.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class PhoneUtilTests : HostedUnitTest
{
    private readonly IPhoneUtil _util;

    public PhoneUtilTests(Host host) : base(host)
    {
        _util = Resolve<IPhoneUtil>(true);
    }

    [Test]
    public void Default()
    {

    }

    [Test]
    public async ValueTask ToE164_validates_and_formats_numbers()
    {
        string formatted = await _util.ToE164("(415) 555-2671", "US");
        await Assert.That(formatted).IsEqualTo("+14155552671");

        bool invalidThrown = false;

        try
        {
            await _util.ToE164("123", "US");
        }
        catch (InvalidOperationException)
        {
            invalidThrown = true;
        }

        await Assert.That(invalidThrown).IsTrue();
    }
}
