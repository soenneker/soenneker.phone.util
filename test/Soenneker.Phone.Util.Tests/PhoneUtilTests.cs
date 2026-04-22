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
}
