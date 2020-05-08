using NUnit.Framework;
using System.Collections.Generic;
using csharp.Constants;

namespace csharp
{
    [TestFixture]
    public class BackStagePassShould
    {
        [TestCase(10, -1, ExpectedResult = 0, TestName = "AfterConcertShouldBeZero")]
        [TestCase(7, 10, ExpectedResult = 9, TestName = "BackStagePassQualityShouldIncrease")]
        [TestCase(10, 9, ExpectedResult = 12, TestName = "9DaysBeforeConcertShouldIncreaseByTwo")]
        [TestCase(10, 10, ExpectedResult = 12, TestName = "10DaysBeforeConcertShouldIncreaseByTwo")]
        [TestCase(10, 5, ExpectedResult = 13, TestName = "5DaysBeforeConcertShouldIncreaseByThree")]
        [TestCase(10, 4, ExpectedResult = 13, TestName = "4DaysBeforeConcertShouldIncreaseByThree")]
        [TestCase(10, 0, ExpectedResult = 0, TestName = "BackStagePassAfterConcertShouldBeZero")]
        [TestCase(49, 9, ExpectedResult = 50, TestName = "QualityShouldNotBeMoreThanFifty")]

        public int BackStageQualityShould(int quality, int sellin)
        {
            Item item = GetItem(ItemName.BackstagePass, quality, sellin);
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
