namespace AEF.Core.Definitions
{
    public abstract class AEFItem : ModItem
    {
        #region VARS

        public ItemRarity rarity { get; set; }

        public ItemSeason season { get; set; }

        public ItemType type { get; set; }

        public bool isClassified;

        #endregion

        public override void SetDefaults()
        {
            rarity = ItemRarity.Common;
            season = ItemSeason.vanilla;
            type = ItemType.none;

            Item.width = 20;
            Item.height = 20;

            Item.lavaWet = false;

            base.SetDefaults();
        }

        public enum ItemRarity
        {
            Common,
            Uncommon,
            Rare,
            Super_Rare,
            Legendary,
            Mythical
        }

        public enum ItemSeason
        {
            vanilla,
            elemental,
            darkmoon,
        }

        public enum ItemType
        {
            none,
            Armor,
            Core,
            Emblem,
            Fragment,
            Weapon
        }
    }
}