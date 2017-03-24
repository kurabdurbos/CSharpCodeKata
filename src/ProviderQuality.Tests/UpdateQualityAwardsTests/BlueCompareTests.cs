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
        public void TestUpdateAwardStandard()
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
        public void TestUpdateAward10OrLessDays()
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
        public void TestUpdateAward5OrLessDays()
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
        public void TestUpdateAwardExceedMaxValue()
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
        public void TestUpdateAwardExpired()
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
        public void TestUpdateAwardInvalidQuality()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueCompare(15,60)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueCompare));
            Assert.IsTrue(app.Awards[0].Quality == 60);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 15);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 50);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 14);
        }

        [TestMethod]
        public void TestUpdateAwardExceedMaxQuality()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueCompare(2,49)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueCompare));
            Assert.IsTrue(app.Awards[0].Quality == 49);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 2);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 50);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 1);
        }


    }
}
