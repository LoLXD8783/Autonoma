namespace AEF.Core.Definitions.ItemTypes.Archetypes
{
    public abstract class KnightWeapon : Weapon
    {
        #region VARS

        public KnightArchetype knightArch { get; set; }

        public float statBreakChance;

        public float statAttackSpeed;

        public float statAttackRange;

        public float statComboDamage;

        public int statHeavyDamage;

        public int statCombo;

        #endregion

        public override void SetDefaults()
        {
            statAttackRange = 0F;
            statAttackSpeed = 0F;
            statBreakChance = 0F;
            statComboDamage = 0F;
            statHeavyDamage = 0;
            statCombo = 0;

            base.SetDefaults();
        }

        public override void UpdateInventory(Player player)
        {
            ResetStats(this);

            foreach (Trait t in traitSet_Sel)
            {
                t.StatEffect(this, null, null);
                t.ConditionalEffect(this, null, null);
            }

            base.UpdateInventory(player);
        }

        public override void ResetStats(KnightWeapon k)
        {
            k.statAttackRange = statAttackRange;
            k.statAttackSpeed = statAttackSpeed;
            k.statBreakChance = statBreakChance;
            k.statComboDamage = statComboDamage;
            k.statHeavyDamage = statHeavyDamage;
            base.ResetStats(k);
        }

        public enum KnightArchetype 
        { 
            Gauntlets,
            Greatsword,
        }
    }
}