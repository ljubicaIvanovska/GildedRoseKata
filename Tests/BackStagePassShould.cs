using NUnit.Framework;
using System.Collections.Generic;
using csharp.Constants;

namespace csharp
{
    [TestFixture]
    public class BackStagePassShould
    {
        [Test]
        public void BackStagePassQualityShouldIncrease()
        {
            int quality = 7;
            int increase = 1;
            IList<Item> items = new List<Item> { new Item { Name = ItemName.BackstagePass, 
                                                            SellIn = 10, 
                                                            Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality + increase, items[0].Quality);
        }
        [Test]
        public void BackStagePassSellinShouldDecreasesAfterUpdate()
        {
            int sellin = 10;
            IList<Item> items = new List<Item> { new Item { Name = ItemName.BackstagePass,
                                                            SellIn = sellin,
                                                            Quality = 20 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(sellin - 1, items[0].SellIn);
        }

        [Test]
        public void BackStagePassQualityShouldNotBeMoreThanFifty()
        {
            int quality = 100;
            int daysBeforeConcert = 9;
            int increase = 1;
            IList<Item> items = new List<Item> { new Item { Name = ItemName.BackstagePass, 
                                                            SellIn = daysBeforeConcert, 
                                                            Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(50, items[0].Quality);
        }

        [Test]
        public void BackStagePass9DaysBeforeConcertSHouldIncreaseByOne()
        {
            int quality = 10;
            int daysBeforeConcert = 9;
            IList<Item> items = new List<Item> { new Item { Name = ItemName.BackstagePass, 
                                                            SellIn = daysBeforeConcert, 
                                                            Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality + 1, items[0].Quality);
        }
        [Test]
        public void BackStagePass4DaysBeforeConcertShouldIncreaseByTwo()
        {
            int quality = 10;
            int daysBeforeConcert = 4;
            IList<Item> items = new List<Item> { new Item { Name = ItemName.BackstagePass, 
                                                            SellIn = daysBeforeConcert, 
                                                            Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality + 2, items[0].Quality);
        }
        [Test]
        public void BackStagePassAfterConcertShouldBeZero()
        {
            int quality = 10;
            IList<Item> items = new List<Item> { new Item { Name = ItemName.BackstagePass, 
                                                            SellIn = -1, 
                                                            Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
        }
    }
}
