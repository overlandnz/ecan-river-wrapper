using NUnit.Framework;

namespace OverlandNZ.Wrappers.ECAN.Tests;

[TestFixture]
public class EnvironmentalObservationsClientTests
{
    [Test]
    public void Test_That_Time_Values_Get_Set()
    {
        var client = new EnvironmentalObservationsClient("");
        var query = client.GenerateQuery(new DateTime(2023, 11, 22, 22, 0, 0));

        Assert.That(query.Contains("2023-11-22 22:00:00"));
        Assert.That(query.Contains("2023-11-22 22:59:59"));
    }
}