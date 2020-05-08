using NUnit.Framework;
using System.Collections.Generic;
using csharp.Constants;

namespace csharp
{
    [TestFixture]
    public class SulfurasShould
    {

        [TestCase(1, 10, ExpectedResult = 80, TestName = "QualityShouldAlwaysBe80")]
        [TestCase(50, 10, ExpectedResult = 80, TestName = "QualityShouldAlwaysBe80_Test2")]
        [TestCase(7, 10, ExpectedResult = 80, TestName = "QualityShouldAlwaysBe80_Test3")]
        [TestCase(12, 10, ExpectedResult = 80, TestName = "QualityShouldAlwaysBe80_Test4")]
        public int SulfurasQualityShould(int quality, int sellin)
        {
            Item item = GetItem(ItemName.Surfuras, quality, sellin);
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
