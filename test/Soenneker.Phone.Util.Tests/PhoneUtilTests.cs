using Soenneker.Phone.Util.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Phone.Util.Tests;

[Collection("Collection")]
public sealed class PhoneUtilTests : FixturedUnitTest
{
    private readonly IPhoneUtil _util;

    public PhoneUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IPhoneUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
