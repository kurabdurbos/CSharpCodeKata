using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProviderQuality.Console;
using ProviderQuality.Console.Awards;


namespace ProviderQuality.Tests.UpdateQualityAwardsTests
{
    [TestClass]
    public class BlueCompareTests
    {
        [TestMethod]
        public void TestDailyProcessStandard()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueCompare(20,20)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueCompare));
            Assert.IsTrue(app.Awards[0].Quality == 20);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 20);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 21);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 19);
        }

        [TestMethod]
        public void TestDailyProcess10OrLessDays()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueCompare(10,20)               
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueCompare));
            Assert.IsTrue(app.Awards[0].Quality == 20);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 10);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 22);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 9);
        }


        [TestMethod]
        public void TestDailyProcess5OrLessDays()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueCompare(5,20)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueCompare) );
            Assert.IsTrue(app.Awards[0].Quality == 20);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 5);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 23);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 4);
        }


        [TestMethod]
        public void TestDailyProcessOver50()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueCompare(5,50)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueCompare) );
            Assert.IsTrue(app.Awards[0].Quality == 50);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 5);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 50);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 4);
        }


        [TestMethod]
        public void TestDailyProcessofExpired()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueCompare(0,44)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueCompare));
            Assert.IsTrue(app.Awards[0].Quality == 44);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 0);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 0);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 0);
        }


        [TestMethod]
        public void TestDailyProcessofExample()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueCompare(15,20)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueCompare));
            Assert.IsTrue(app.Awards[0].Quality == 20);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 15);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 21);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 14);
        }

    }
}
