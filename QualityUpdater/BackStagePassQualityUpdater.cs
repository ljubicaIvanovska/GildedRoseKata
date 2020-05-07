using csharp.Items;

namespace csharp
{
    public class BackStagePassQualityUpdater : IUpdateItemQuality
    {
        private Item _item { get; set; }

        public BackStagePassQualityUpdater(Item item)
        {
            _item = item;
        }
        public void UpdateItemQuality()
        {
            _item.SellIn -= 1;

            // Quality can never be negative for item
            if (_item.Quality < 0)
            {
                _item.Quality = 0;
                return;
            }

            // Quality can never be more than 50 for item
            if (_item.Quality >= 50)
            {
                _item.Quality = 50;
                return;
            }
            if (_item.SellIn < 0)
            {
                _item.Quality = 0;
                return;
            }
            if (_item.SellIn < 11)
            {
                _item.Quality +=  1;
            }
            if (_item.SellIn < 6)
            {
                _item.Quality += 1;
            }
        }
    }
}
