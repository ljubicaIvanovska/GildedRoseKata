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
            if (_item.SellIn < 50)
            {
                _item.Quality = _item.Quality - 1;
            }
            // Item Quality can never be 0
            if (_item.SellIn < 0 && _item.Quality > 1)
            {
                _item.Quality = _item.Quality - 1;
            }
        }
    }
}
