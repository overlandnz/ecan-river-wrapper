using DotSpatial.Projections;

namespace OverlandNZ.Wrappers.ECAN;

public static class CoordinateConvertor
{
    public static (double Latitude, double Longitude) ConvertNZTMToLatLong(double nztmX, double nztmY)
    {
        // Define the NZTM projection (EPSG:2193)
        ProjectionInfo nztmProjection = ProjectionInfo.FromEpsgCode(2193);

        // Define the WGS84 projection (EPSG:4326)
        ProjectionInfo wgs84Projection = ProjectionInfo.FromEpsgCode(4326);

        // Define the coordinate arrays
        double[] xy = new double[2] { nztmX, nztmY };
        double[] z = new double[1] { 0 };

        // Perform the re-projection
        Reproject.ReprojectPoints(xy, z, nztmProjection, wgs84Projection, 0, 1);

        // Return the latitude and longitude
        return (xy[1], xy[0]);
    }
}