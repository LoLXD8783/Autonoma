namespace AEF.Core.Definitions.ItemTypes.Archetypes
{
    public abstract class KnightWeapon : Weapon
    {
        #region VARS

        public KnightArchetype KnightArch { get; set; }

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

        public override void ResetStats(KnightWeapon knight)
        {
            knight.statAttackRange = statAttackRange;
            knight.statAttackSpeed = statAttackSpeed;
            knight.statBreakChance = statBreakChance;
            knight.statComboDamage = statComboDamage;
            knight.statHeavyDamage = statHeavyDamage;
            base.ResetStats(knight);
        }

        public enum KnightArchetype 
        { 
            Gauntlets,
            Greatsword,
        }
    }
}