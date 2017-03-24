﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProviderQuality.Console;
using ProviderQuality.Console.Awards;

namespace ProviderQuality.Tests.UpdateQualityAwardsTests
{
    [TestClass]
    public class BlueFirstTests
    {
        [TestMethod]
        public void TestDailyProcessStandard()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueFirst(10,20)               
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueFirst));
            Assert.IsTrue(app.Awards[0].Quality == 20);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 10);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 21);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 9);
        }

        [TestMethod]
        public void TestDailyProcessExpired()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueFirst(0,20)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueFirst));
            Assert.IsTrue(app.Awards[0].Quality == 20);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 0);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 22);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 0);
        }

        [TestMethod]
        public void TestDailyProcessOver50()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueFirst(5,50)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueFirst));
            Assert.IsTrue(app.Awards[0].Quality == 50);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 5);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 50);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 4);
        }

        [TestMethod]
        public void TestDailyProcessExample()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new BlueFirst(2,0)
                    
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(BlueFirst));
            Assert.IsTrue(app.Awards[0].Quality == 0);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 2);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 1);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 1);
        }

    }
}
