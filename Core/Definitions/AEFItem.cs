namespace AEF.Core.Definitions
{
    public abstract class AEFItem : ModItem
    {
        #region VARS

        public ItemOrigin Origin { get; set; }

        public ItemRarity Rarity { get; set; }

        public ItemSeason Season { get; set; }

        public ItemType type { get; set; }

        /// <summary>
        /// Whether or not this item has a glowmask. <para></para>
        /// Set to null by default.
        /// </summary>
        public Texture2D Glowmask = null;

        public bool isClassified;

        #endregion

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {

            var rarityLine = new TooltipLine(Mod, "item_rarity", $"{Rarity.ToString().ToUpper()}");

            rarityLine.OverrideColor = RarityColors.rareColors[Rarity];

            var typeLine = new TooltipLine(Mod, "item_type", $"{Type.ToString().ToUpper()}");

            tooltips.Insert(1, rarityLine);
            tooltips.Insert(2, typeLine);

            base.ModifyTooltips(tooltips);
        }

        public override void SetDefaults()
        {

            Item.width = 20;
            Item.height = 20;

            Item.lavaWet = false;

            base.SetDefaults();
        }

        #region WORLD / INV DRAWING

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) => false;
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI) => false;

        public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {

            base.PostDrawInWorld(spriteBatch, lightColor, alphaColor, rotation, scale, whoAmI);
        }

        #endregion

        public enum ItemOrigin
        {
            None,

            ActivityMachinaOffensive,

            DungeonStarSiphon,

            FactionBlacksmiths,
            FactionEccentrics,
            FactionExiles,
            FactionResistance,
            FactionSavvy,

            IncursionSongOfRevelation,

            PlanetKheimon,
            PlanetTerraria,
            PlanetThaumas,
            PlanetVulcan
        }

        public enum ItemRarity
        {
            Common,
            Uncommon,
            Rare,
            Legendary,
            Mythical
        }

        public enum ItemSeason
        {
            Vanilla,
            Elemental,
            DarkMoon,
        }

        public enum ItemType
        {
            Armor,
            Core,
            Emblem,
            Fragment,
            Miscellaneous,
            Weapon
        }
    }
}