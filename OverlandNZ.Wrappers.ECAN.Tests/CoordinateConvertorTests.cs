using NUnit.Framework;

namespace OverlandNZ.Wrappers.ECAN.Tests;

[TestFixture]
public class CoordinateConvertorTests
{
    [Test]
    public void NZTM_Coordinates_For_Waiau_Uwha_River_At_Malings_Pass_Are_Valid()
    {
        // Arrange
        double nztmX = 1571070;
        double nztmY = 5325807;

        // Act
        (double Latitude, double Longitude) result = CoordinateConvertor.ConvertNZTMToLatLong(nztmX, nztmY);

        // Assert
        Assert.AreEqual(-42.21936658, result.Latitude, 0.00001);
        Assert.AreEqual(172.64947386, result.Longitude, 0.00001);
    }
}