using NUnit.Framework;
using System.Collections.Generic;
using csharp.Constants;

namespace csharp
{
    [TestFixture]
    public class ConjuredShould
    {
        [TestCase(1, 10, ExpectedResult = 0, TestName = "QualityShouldNotBeNegative")]
        [TestCase(50, 10, ExpectedResult = 50, TestName = "QualityShouldBeMax50")]
        [TestCase(7, 10, ExpectedResult = 5, TestName = "QualityDecreasesTwice")]
        [TestCase(12, 10, ExpectedResult = 10, TestName = "QualityDecreasesTwice")]
        public int ConjuredQualityShould(int quality, int sellin)
        {
            Item item = GetItem(ItemName.Conjured, quality, sellin);
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
    }
}
