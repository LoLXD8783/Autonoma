namespace AEF.Core.Dictionaries
{
    internal class RarityColors
    {
        public static Dictionary<AEFItem.ItemRarity, Color> rareColors = new()
        {
            { AEFItem.ItemRarity.Common, Color.White },
            { AEFItem.ItemRarity.Uncommon, Color.ForestGreen },
            { AEFItem.ItemRarity.Rare, Color.LightBlue },
            { AEFItem.ItemRarity.Legendary, Color.MediumPurple },
            { AEFItem.ItemRarity.Mythical, Color.Goldenrod },
        };
    }
}
