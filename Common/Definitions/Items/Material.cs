namespace AEFramework.Common.Definitions.Items
{
    public abstract class Material : ItemFramework
    {
        public item_MaterialType MaterialType { get; set; }

        public override void SetDefaults()
        {
            Category = item_category.Material;
            base.SetDefaults();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            //TODO: Variable tooltip display for different kinds of materials
            base.ModifyTooltips(tooltips);
        }
    }

    public enum item_MaterialType
    {
        Blueprint,
        Rare,
        World
    }
}