using NUnit.Framework;
using System.Collections.Generic;
using csharp.Constants;

namespace csharp
{
    [TestFixture]
    public class SulfurasShould
    {
        [Test]
        public void SulfurasShouldAlwaysHaveQuality80()
        {
            int quality = 7;
            IList<Item> items = new List<Item> { new Item { Name = ItemName.Surfuras, 
                                                            SellIn = 10, 
                                                            Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual(quality -1, items[0].Quality);
        }
    }
}
