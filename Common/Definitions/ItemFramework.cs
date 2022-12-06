namespace AEFramework.Common.Definitions
{
    public abstract class ItemFramework : ModItem
    {
        public item_category Category { get; set; }

        public item_expansion Expansion { get; set; }

        public item_rarity Rarity { get; set; }

        public override void SetDefaults()
        {
            Category = item_category.None;
            Expansion = item_expansion.Reawakening;
            Item.height = 20;
            Item.width = 20;
            base.SetDefaults();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {

            base.ModifyTooltips(tooltips);
        }
    }

    #region ENUMS

    public enum item_category
    {
        None,
        Armor,
        Cosmetic,
        Enhancement,
        Material,
        Relic,
        Weapon
    }

    public enum item_expansion
    {
        Reawakening,
        Op_Elemental_Ordnance,
        Op_Rogue_Moon,
        Evil_Within,
        Anniv_One,
        Forewarning,
        Anniv_Two,
        The_First_Wave,
        Anniv_Three,
        The_God_Queen,
        Op_Sundown,
        Op_Nightfall,
        Anniv_Four,
        Eternal_Crusade,
        Op_Freeborn,
        Op_Revelation,
        Anniv_Five
    }

    public enum item_rarity
    {
        Common,
        Uncommon,
        Rare,
        Super_Rare,
        Ultra_Rare,
        Mythical
    }

    #endregion
}