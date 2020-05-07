using NUnit.Framework;
using System.Collections.Generic;
using csharp.Constants;

namespace csharp
{
    [TestFixture]
    public class RegularItemShould
    {
        [Test]
        public void RegularItemQualityShouldDecreaseByOne()
        {
            int quality = 7;
            IList<Item> items = new List<Item> { new Item { Name = "Any Item Name", 
                                                            SellIn = 10, 
                                                            Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality -1, items[0].Quality);
        }
     
        [Test]
        public void RegularItemQualityShouldBeMax50()
        {
            int quality = 50;
            IList<Item> items = new List<Item> { new Item { Name = "Laundry Soap", 
                                                            SellIn = 10, 
                                                            Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality, items[0].Quality);
        }
        [Test]
        public void RegularItemQualityShouldNotBeNegative()
        {
            int quality = -1;
            IList<Item> items = new List<Item> { new Item { Name = ItemName.AgedBrie, 
                                                            SellIn = 10, 
                                                            Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
        }
    }
}
