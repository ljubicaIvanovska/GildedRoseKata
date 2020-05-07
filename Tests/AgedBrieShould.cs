using NUnit.Framework;
using System.Collections.Generic;
using csharp.Constants;

namespace csharp
{
    [TestFixture]
    public class AgedBrieShould
    {
        [Test]
        public void AgedBrieQualityShouldIncreaseByOne()
        {
            int quality = 7;
            IList<Item> items = new List<Item> { new Item { Name = ItemName.AgedBrie, 
                                                            SellIn = 10, 
                                                            Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality + 1, items[0].Quality);
        }
     
        [Test]
        public void AgedBrieQualityShouldBeMax50()
        {
            int quality = 50;
            IList<Item> items = new List<Item> { new Item { Name = ItemName.AgedBrie, 
                                                            SellIn = 10, 
                                                            Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality, items[0].Quality);
        }
        [Test]
        public void AgedBrieQualityShouldNotBeNegative()
        {
            int quality = -1;
            IList<Item> items = new List<Item> { new Item { Name = ItemName.AgedBrie, 
                                                            SellIn = 10, 
                                                            Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
        }
        [Test]
        public void AgedBrieSellinDecreasesAfterUpdate()
        {
            int sellin = 10;
            IList<Item> items = new List<Item> { new Item { Name = ItemName.AgedBrie,
                SellIn = sellin,
                Quality = 20 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(sellin-1, items[0].SellIn);
        }
    }
}
