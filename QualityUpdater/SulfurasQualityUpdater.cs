namespace csharp.Items
{
    public class SulfurasQualityUpdater: IUpdateItemQuality
    {
        private Item _item { get; set; }

        public SulfurasQualityUpdater(Item item)
        {
            _item = item;
        }

        public void UpdateItemQuality()
        {
            _item.Quality = 80;
            _item.SellIn -= 1;
        }
    }
}
