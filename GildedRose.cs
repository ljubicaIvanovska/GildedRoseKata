using System.Collections.Generic;
using csharp.Items;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> items)
        {
            this.Items = items;
        }
        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var itemUpdater = QualityUpdaterFactory.GetQualityUpdater(item);
                itemUpdater.UpdateItemQuality();
            }
        }
    }
}
