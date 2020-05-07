namespace csharp.Items
{
    public class AgedBrieQualityUpdater : IUpdateItemQuality
    {
        private Item _item { get; set; }

        public AgedBrieQualityUpdater(Item itemtem)
        {
            _item = itemtem;
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

            _item.Quality +=  1;
        }
    }
}
