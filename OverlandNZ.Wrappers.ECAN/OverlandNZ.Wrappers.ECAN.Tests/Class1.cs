using NUnit.Framework;

namespace OverlandNZ.Wrappers.ECAN.Tests;

[TestFixture]
public class QueryGenerationTests
{
    [Test]
    public async Task CanGenerateQuery()
    {
        var client = new EnvironmentalObservationsClient("");

        var response = await client.GetObservations();
        Assert.NotNull(response);
    }
}