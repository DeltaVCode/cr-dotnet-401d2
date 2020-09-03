using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Xunit;

namespace Demo.Tests
{
    public class Lab09GeoJsonTests
    {
        [Fact]
        public void Can_read_file()
        {
            // Arrange
            string fileName = "data.json";
            string data = File.ReadAllText(fileName);
            Assert.NotEmpty(data);

            // Act
            // Install-Package Newtonsoft.Json
            RootObject root = JsonConvert.DeserializeObject<RootObject>(data);

            // Assert
            Assert.Equal("FeatureCollection", root.type);

            Assert.NotEmpty(root.features);
        }
    }

    internal class RootObject
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        // TODO: geometry, properties
    }
}