namespace AEFramework.Common.Definitions.Items
{
    internal class Armor : ItemFramework
    {
        public int statArmorClair;
        public int statArmorAgili;
        public int statArmorRecup;
        public int statArmorDurab;
        public int statArmorStren;

        public override void SetDefaults()
        {
            Category = item_category.Armor;
            base.SetDefaults();
        }

        /// <summary>
        /// Rolls each stat of an armor piece.
        /// </summary>
        public void RollArmorStats()
        {
            /*Stat Roll Sequencing
             * 
             * - Randomly pick first stat:
             * - First stat gets a value between 15-25
             * 
             * - Randomly pick second stat:
             * - Second stat gets a value between 10-20
             * 
             * - Third and fourth get a value between 5-10
             * 
             * - Min to Max stat values: 35, 65 
             */
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var statLine = new TooltipLine(Mod, "armorStats",
                $"CLAIRVOYANCE | {statArmorClair} \n" +
                $"AGILITY | {statArmorAgili} \n" +
                $"RECUPERATION | {statArmorRecup} \n" +
                $"DURABILITY | {statArmorDurab} \n" +
                $"STRENGTH | {statArmorStren} \n");
            tooltips.Add(statLine);

            base.ModifyTooltips(tooltips);
        }

        public override void OnCreate(ItemCreationContext context)
        {
            if (context is RecipeCreationContext r)
            {
                RollArmorStats();
            }
            base.OnCreate(context);
        }
    }

    public enum slot_type
    {
        Head,
        Arms,
        Chest,
        Legs,
    }
}