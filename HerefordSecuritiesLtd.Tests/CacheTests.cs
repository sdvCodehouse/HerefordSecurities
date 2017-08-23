using System;
using HerefordSecuritiesLtd.Models;
using HerefordSecuritiesLtd.Services;
using NUnit.Framework;

namespace HerefordSecuritiesLtd.Tests
{
    [TestFixture]
    public class CacheTests
    {

        [Test]
        public void SiteCache_WhenKeyAdded_HasKeyIsTrue()
        {
            CachingService.AddToCache("test", new object());

            Assert.That(CachingService.HasKey("test"), Is.True);
        }

        [Test]
        public void GetFromCache_WhenAddItemToCache_ItemCanBeRetrieved()
        {
            CachingService.AddToCache("test", new IndexViewModel());

            Assert.That(CachingService.GetFromCache<IndexViewModel>("test"), Is.Not.Null);
            Assert.That(CachingService.GetFromCache<IndexViewModel>("test"), Is.TypeOf<IndexViewModel>());
        }

        [TearDown]
        public void TearDown()
        {
            CachingService.RemoveFromCache("test");
        }
    }
}
