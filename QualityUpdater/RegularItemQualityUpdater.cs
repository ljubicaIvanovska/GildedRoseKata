namespace csharp.Items
{
    public class RegularItemQualityUpdater : IUpdateItemQuality
    {
        private Item _item { get; set; }

        public RegularItemQualityUpdater(Item item)
        {
            _item = item;
        }

        public void UpdateItemQuality()
        {
            _item.SellIn -= 1;
            // Quality can never be negative for item
            if (_item.Quality <= 0)
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
            
            _item.Quality = _item.Quality - 1;
            
            // Item Quality decreases twice after sell in passes
            if (_item.SellIn < 0 && _item.Quality > 1)
            {
                _item.Quality = _item.Quality - 1;
            }
        }
    }
}
