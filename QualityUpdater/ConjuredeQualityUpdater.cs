namespace csharp.Items
{
    public class ConjuredeQualityUpdater : IUpdateItemQuality
    {
        private Item _item { get; set; }

        public ConjuredeQualityUpdater(Item item)
        {
            _item = item;
        }

        public void UpdateItemQuality()
        {
            _item.SellIn--;

            if (_item.Quality < 3)
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

            _item.Quality = _item.Quality - 2;

        }
    }
}
