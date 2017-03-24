using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProviderQuality.Console;
using ProviderQuality.Console.Awards;

namespace ProviderQuality.Tests.UpdateQualityAwardsTests
{
    [TestClass]
    public class BlueStarTests
    {
        [TestMethod]
        public void TestUpdateAwardStandard()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueStar(10,20)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueStar));
            Assert.IsTrue(app.Awards[0].Quality == 20);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 10);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 18);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 9);
        }


        [TestMethod]
        public void TestUpdateAwardExpired() 
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueStar(0,20)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueStar));
            Assert.IsTrue(app.Awards[0].Quality == 20);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 0);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 16);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 0);
        }

        [TestMethod]
        public void TestUpdateAwardInvalidQuality()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueStar(4,60)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueStar));
            Assert.IsTrue(app.Awards[0].Quality == 60);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 4);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 48);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 3);
        }


        [TestMethod]
        public void TestUpdateAwardNegitiveQuality()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueStar(4,1)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueStar));
            Assert.IsTrue(app.Awards[0].Quality == 1);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 4);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 0);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 3);
        }
    }
}
