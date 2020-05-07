using csharp.Constants;

namespace csharp.Items
{
    public class QualityUpdaterFactory
    {
        public static IUpdateItemQuality GetQualityUpdater(Item item)
        {
            switch (item.Name)
            {
                case ItemName.AgedBrie:
                    return new AgedBrieQualityUpdater(item);
                case ItemName.Surfuras:
                    return new SulfurasQualityUpdater(item);
                case ItemName.BackstagePass:
                    return new BackStagePassQualityUpdater(item);
                case ItemName.Conjured:
                    return new ConjuredeQualityUpdater(item);
                default:
                    return new RegularItemQualityUpdater(item);
            }
        }
    }
}
