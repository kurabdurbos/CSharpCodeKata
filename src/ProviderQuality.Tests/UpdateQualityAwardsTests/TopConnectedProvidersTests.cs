﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProviderQuality.Console;
using ProviderQuality.Console.Awards;

namespace ProviderQuality.Tests.UpdateQualityAwardsTests
{
    [TestClass]
    public class TopConnectedProvidersTests
    {
        [TestMethod]
        public void TestDailyProcessStandard()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new TopConnectedProviders(10,20)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(TopConnectedProviders));
            Assert.IsTrue(app.Awards[0].Quality == 20);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 10);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 19);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 9);
        }

        [TestMethod]
        public void TestDailyProcessExpired()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new TopConnectedProviders(0,20)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(TopConnectedProviders));
            Assert.IsTrue(app.Awards[0].Quality == 20);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 0);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 18);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 0);
        }

        [TestMethod]
        public void TestDailyProcessNegitiveQuality()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new TopConnectedProviders(5,0)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(TopConnectedProviders));
            Assert.IsTrue(app.Awards[0].Quality == 0);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 5);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 0);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 4);
        }


        [TestMethod]
        public void TestDailyProcessNegitiveExpiresIn()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new TopConnectedProviders(0,0)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(TopConnectedProviders));
            Assert.IsTrue(app.Awards[0].Quality == 0);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 0);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 0);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 0);
        }


        [TestMethod]
        public void TestDailyProcessQualityOver50()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new TopConnectedProviders(5,55)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(TopConnectedProviders));
            Assert.IsTrue(app.Awards[0].Quality == 55);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 5);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 49);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 4);
        }

        [TestMethod]
        public void TestDailyProcessOfTopConnectedProviderss_Example()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new TopConnectedProviders(3,6)
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].GetType() == typeof(TopConnectedProviders));
            Assert.IsTrue(app.Awards[0].Quality == 6);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 3);

            app.UpdateAwards();

            Assert.IsTrue(app.Awards[0].Quality == 5);
            Assert.IsTrue(app.Awards[0].ExpiresIn == 2);
        }

    }
}