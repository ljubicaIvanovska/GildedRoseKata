using NUnit.Framework;
using System.Collections.Generic;
using csharp.Constants;

namespace csharp
{
    [TestFixture]
    public class RegularItemShould
    {

        [TestCase(7, 10, ExpectedResult = 6, TestName = "RegularItemQualityShouldDecreaseByOne")]
        [TestCase(51, 10, ExpectedResult = 50, TestName = "RegularItemQualityShouldBeMax50")]
        [TestCase(30, 100, ExpectedResult = 29, TestName = "RegularItemQualityShouldDecreaseByOne")]
        [TestCase(0, 10, ExpectedResult = 0, TestName = "RegularItemQualityShouldNotBeNegative")]
        public int RegularItemQualityShould(int quality, int sellin)
        {
            Item item = GetItem("Any Other Name", quality, sellin);
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
