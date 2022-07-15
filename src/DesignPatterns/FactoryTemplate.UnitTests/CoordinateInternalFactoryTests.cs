using FactoryPattern.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryTemplate.UnitTests
{
    [TestClass]
    public class CoordinateInternalFactoryTests
    {
        [TestMethod]
        public void NewFromWkt_ValidWkt_ShouldReturnsCoordinate()
        {
            // Arrange
            string wkt = "POINT (52 28)";

            // Act
            Coordinate result = Coordinate.Factory.NewFromWkt(wkt);

            // Assert
            Assert.AreEqual(52, result.Longitude);
            Assert.AreEqual(28, result.Latitude);
        }

        [TestMethod]
        public void NewFromGeoJson_ValidGeoJson_ShouldReturnsCoordinate()
        {
            // Arrange
            string geojson = @"{
	              'type': 'Feature',
	              'geometry': {
			            'type': 'Point',
	                'coordinates': [52, 28]
  	            }";


            // Act
            Coordinate result = Coordinate.Factory.NewFromGeoJson(geojson);

            // Assert
            Assert.AreEqual(52, result.Longitude);
            Assert.AreEqual(28, result.Latitude);
        }
    }
}
