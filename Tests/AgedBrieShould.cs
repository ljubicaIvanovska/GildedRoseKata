using NUnit.Framework;
using System.Collections.Generic;
using csharp.Constants;

namespace csharp
{
    [TestFixture]
    public class AgedBrieShould
    {
        [TestCase(7, 10, ExpectedResult = 8, TestName = "AgedBrieQualityShouldIncreaseByOne")]
        [TestCase(-1, 10, ExpectedResult = 0, TestName = "QualityShouldNotBeNegative")]
        [TestCase(49, 9, ExpectedResult = 50, TestName = "QualityShouldNotBeMoreThanFifty")]

        public int AgedBrieQualityShould(int quality, int sellin)
        {
            Item item = GetItem(ItemName.AgedBrie, quality, sellin);
            IList<Item> items = new List<Item> { item };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            return items[0].Quality;
        }
        private Item GetItem(string name, int quality, int sellin)
        {
            return new Item
            {
                Name = name,
                SellIn = sellin,
                Quality = quality
            };
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
