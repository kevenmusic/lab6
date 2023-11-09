using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary6;
using static ClassLibrary6.InternetTrafficManager;

namespace UnitTestProject6
{
    [TestClass]
    public class InternetTrafficManagerTests
    {
        [TestMethod]
        public void TestTotalTrafficOnDate()
        {
            // Arrange
            InternetTrafficManager.InternetTraffic[] testData = new InternetTrafficManager.InternetTraffic[]
            {
                new InternetTrafficManager.InternetTraffic(new DateTime(2023, 11, 5), InternetTrafficManager.ProtocolType.HTTP, 100),
                new InternetTrafficManager.InternetTraffic(new DateTime(2023, 11, 6), InternetTrafficManager.ProtocolType.HTTP, 150),
                new InternetTrafficManager.InternetTraffic(new DateTime(2023, 11, 6), InternetTrafficManager.ProtocolType.FTP, 200)
            };
            TrafficAnalyzer analyzer = new TrafficAnalyzer(testData);

            // Act
            double result = analyzer.TotalTrafficOnDate(new DateTime(2023, 11, 5));

            // Assert
            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void TestAverageTrafficPerDay()
        {
            // Arrange
            InternetTrafficManager.InternetTraffic[] testData = new InternetTrafficManager.InternetTraffic[]
            {
                new InternetTrafficManager.InternetTraffic(new DateTime(2023, 11, 5), InternetTrafficManager.ProtocolType.HTTP, 100),
                new InternetTrafficManager.InternetTraffic(new DateTime(2023, 11, 6), InternetTrafficManager.ProtocolType.HTTP, 150),
                new InternetTrafficManager.InternetTraffic(new DateTime(2023, 11, 6), InternetTrafficManager.ProtocolType.FTP, 200)
            };
            TrafficAnalyzer analyzer = new TrafficAnalyzer(testData);

            // Act
            double result = analyzer.AverageTrafficPerDay(InternetTrafficManager.ProtocolType.HTTP, new DateTime(2023, 11, 5), new DateTime(2023, 11, 6));

            // Assert
            Assert.AreEqual(125, result);
        }
    }
}
