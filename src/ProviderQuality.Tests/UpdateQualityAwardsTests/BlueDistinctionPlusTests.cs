using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProviderQuality.Console;
using ProviderQuality.Console.Awards;

namespace ProviderQuality.Tests.UpdateQualityAwardsTests
{
    [TestClass]
    public class BlueDistinctionPlusTests
    {
        [TestMethod]
        public void TestUpdateAwardStandard() 
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueDistinctionPlus(10,80)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueDistinctionPlus));
            Assert.IsTrue(app.Awards[0].Quality == 80);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 10);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 80);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 9);
        }


        [TestMethod]
        public void TestUpdateAwardExpired() 
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueDistinctionPlus(0,80)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueDistinctionPlus));
            Assert.IsTrue(app.Awards[0].Quality == 80);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 0);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 80);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 0);
        }

        [TestMethod]
        public void TestUpdateAwardInvalidQuality()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueDistinctionPlus(0,50)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueDistinctionPlus));
            Assert.IsTrue(app.Awards[0].Quality == 50);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 0);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 80);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 0);
        }
    }
}
