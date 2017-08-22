using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            CachingService.InsertToCache("test", DateTime.Now);

            Assert.That(CachingService.HasKey("test"), Is.True);
        }

        [Test]
        public void GetFromCache_WhenAddItemToCache_ItemCanBeRetrieved()
        {
            CachingService.InsertToCache("test", new IndexViewModel());

            Assert.That(CachingService.GetFromCache<IndexViewModel>("test"), Is.Not.Null);
            Assert.That(CachingService.GetFromCache<IndexViewModel>("test"), Is.TypeOf<IndexViewModel>());
        }

        [TearDown]
        public void TearDown()
        {
            CachingService.Cache.Remove("test");
        }
    }
}
