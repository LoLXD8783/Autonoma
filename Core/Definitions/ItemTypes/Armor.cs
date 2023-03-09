namespace AEF.Core.Definitions.ItemTypes
{
    public abstract class Armor : AEFItem
    {
        public ArmorType armorType { get; set; }

        public override void SetDefaults()
        {
            type = ItemType.Armor;

            base.SetDefaults();
        }

        public enum ArmorType
        {
            Head,
            Arms,
            Chest,
            Legs,
            Class
        }
    }
}