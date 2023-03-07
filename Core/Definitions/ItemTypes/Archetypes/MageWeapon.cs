namespace AEF.Core.Definitions.ItemTypes.Archetypes
{
    public abstract class MageWeapon : Weapon
    {
        public MageArchetype mageArch { get; set; }

        public float statStatusChance;

        public int statCastRange;

        public int statStatusDuration;

        public override void SetDefaults()
        {

            base.SetDefaults();
        }

        public override void UpdateInventory(Player player)
        {
            ResetStats(this);

            foreach (Trait t in traitSet_Sel)
            {
                t.StatEffect(null, this, null);
                t.ConditionalEffect(null, this, null);
            }
            base.UpdateInventory(player);
        }

        public override void ResetStats(MageWeapon m)
        {
            base.ResetStats(m);
        }

        public enum MageArchetype 
        { 
            Gloves,
            Staff
        }
    }
}