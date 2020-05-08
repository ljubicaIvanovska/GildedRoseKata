using NUnit.Framework;
using System.Collections.Generic;
using csharp.Constants;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            string itemName = "foo";
            IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(itemName, Items[0].Name);
        }

        [Test]
    public void RegularItemQualitySucess()
    {
        int quality = 7;
        string itemName = "foo";
        IList<Item> items = new List<Item> { new Item { Name = itemName, SellIn = 10, Quality = quality } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.AreEqual(quality - 1, items[0].Quality);
    }

        [Test]
        public void SellByDatePassed_QualityDegradesTwiceFast()
        {
            int quality = 7;
            string itemName = "foo";
            int increase = -2;
            IList<Item> items = new List<Item> { new Item { Name = itemName, SellIn = -2, Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality + increase, items[0].Quality);
        }
        [Test]
        public void AgedBrie_QualityIncrease()
        {
            int quality = 7;
            int increase = 1;
            string itemName = "Aged Brie";
            IList<Item> items = new List<Item> { new Item { Name = itemName, SellIn = 10, Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality + increase, items[0].Quality);
        }
        [Test]
        public void SulfurasQualityAlwaysEighty()
        {
            int quality = 80;
            string itemName = "Sulfuras, Hand of Ragnaros";
            IList<Item> items = new List<Item> { new Item { Name = itemName, SellIn = 10, Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality, items[0].Quality);
        }
        [Test]
        public void QualityIsMax50()
        {
            int quality = 50;
            string itemName = ItemName.AgedBrie;
            IList<Item> items = new List<Item> { new Item { Name = itemName, SellIn = 10, Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality, items[0].Quality);
        }
        [Test]
        public void BackStagePass9DaysBeforeConcertQualityAboveFifty()
        {
            int quality = 100;
            int daysBeforeConcert = 9;
            int increase = 1;
            string itemName = ItemName.BackstagePass;
            IList<Item> items = new List<Item> { new Item { Name = itemName, SellIn = daysBeforeConcert, Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality+2, items[0].Quality);
        }

        [Test]
        public void BackStagePass9DaysBeforeConcert()
        {
            int quality = 10;
            int daysBeforeConcert = 0;
            int increase = 1;
            string itemName = "Backstage passes to a TAFKAL80ETC concert";
            IList<Item> items = new List<Item> { new Item { Name = itemName, SellIn = daysBeforeConcert, Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
        }
        [Test]
        public void BackStagePass4DaysBeforeConcert()
        {
            int quality = 10;
            int daysBeforeConcert = 4;
            int increase = 2;
            string itemName = "Backstage passes to a TAFKAL80ETC concert";
            IList<Item> items = new List<Item> { new Item { Name = itemName, SellIn = daysBeforeConcert, Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality + increase, items[0].Quality);
        }
        [Test]
        public void BackStagePassAfterConcert()
        {
            int quality = 10;
            string itemName = "Backstage passes to a TAFKAL80ETC concert";
            IList<Item> items = new List<Item> { new Item { Name = itemName, SellIn = -1, Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
        }
    }
}
