namespace AEF.Core.Definitions.ItemTypes.Archetypes
{
    public abstract class RangerWeapon : Weapon
    {
        #region VARS

        public RangerArchetype rangerArch { get; set; }

        public float statCritChance;

        public float statCritDamage;

        public int statRange;

        public int statStability;

        public int statReload;

        public int magCur;

        public int magMax;

        #endregion

        public override void SetDefaults()
        {
            archetype = Archetype.Ranger;

            base.SetDefaults();
        }

        public override void UpdateInventory(Player player)
        {
            ResetStats(this);

            foreach (Trait t in traitSet_Sel)
            {
                t.StatEffect(null, null, this);
                t.ConditionalEffect(null, null, this);
            }
            base.UpdateInventory(player);
        }

        public override void ResetStats(RangerWeapon r)
        {
            base.ResetStats(r);
        }

        public enum RangerArchetype
        {
            Bow,
            Machine_Gun,
        }
    }
}