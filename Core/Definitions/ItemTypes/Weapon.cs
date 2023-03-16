namespace AEF.Core.Definitions.ItemTypes
{
    public abstract class Weapon : AEFItem
    {
        #region VARS

        //NOTE: I am aware of possibly bad programming practices by consolidating all of the weapon's stats here instead of segmenting them off.
        //HOWEVER: I do not care, and this makes it miles easier to directly update and handle stats, as well as Kitbash weapons (which hold a combo of both)
        //ALONGSIDE THIS: 

        public Archetype archetype { get; set; }

        public int stat_Impact;

        /*KNIGHT STATS*/

        public float statBreakChance;

        public float statAttackSpeed;

        public float statAttackRange;

        public float statComboDamage;

        public int statHeavyDamage;

        public int statCombo;

        /*RANGER STATS*/

        public float statCritChance;

        public float statCritDamage;

        public int statRange;

        public int statStability;

        public int statReload;

        public int magCur;

        public int magMax;

        /*MAGE STATS*/

        public float statCastSpeed;

        public float statCastRange;

        public float statStatusChance;

        public int statStatusDuration;

        public List<Trait> FirstSlot;
        public List<Trait> SecondSlot;
        public List<Trait> ThirdSlot;
        public List<Trait> FourthSlot;
        public List<Trait> OriginSlot;

        private static List<Trait> TraitPool;

        public Trait[] traitSet_Sel;

        #endregion

        public override ModItem Clone(Item newEntity)
        {
            Weapon clone = (Weapon)base.Clone(newEntity);

            clone.FirstSlot = new List<Trait>(FirstSlot.Count);
            for (int i = 0; i < FirstSlot.Count; i++)
            {
                clone.FirstSlot[i] = FirstSlot[i];
            }

            clone.SecondSlot = new List<Trait>(SecondSlot.Count);
            for (int i = 0; i < SecondSlot.Count; i++)
            {
                clone.SecondSlot[i] = SecondSlot[i];
            }

            clone.ThirdSlot = new List<Trait>(ThirdSlot.Count);
            for (int i = 0; i < FirstSlot.Count; i++)
            {
                clone.ThirdSlot[i] = ThirdSlot[i];
            }

            clone.FourthSlot = new List<Trait>(FourthSlot.Count);
            for (int i = 0; i < FourthSlot.Count; i++)
            {
                clone.FourthSlot[i] = FourthSlot[i];
            }

            clone.OriginSlot = new List<Trait>(OriginSlot.Count);
            for (int i = 0; i < FirstSlot.Count; i++)
            {
                clone.OriginSlot[i] = OriginSlot[i];
            }

            return clone;
        }

        public override void Load()
        {
            SetTraitPool(TraitPool, archetype);

            base.Load();
        }

        public override void SetDefaults()
        {
            type = ItemType.Weapon;
            stat_Impact = 0;
            base.SetDefaults();
        }

        public override void OnCreate(ItemCreationContext context)
        {
            //ON ITEM CREATION:
            // - Roll Traits in each Slot, pull from TraitPool
            // - Set each of TraitSet_Sel's traits to the first in each slot as default.

            traitSet_Sel[0] = FirstSlot[0];
            traitSet_Sel[1] = SecondSlot[0];
            traitSet_Sel[2] = ThirdSlot[0];
            traitSet_Sel[3] = FourthSlot[0];
            traitSet_Sel[4] = OriginSlot[0];
            base.OnCreate(context);
        }

        public override void UpdateInventory(Player player)
        {
            ResetStats(this);

            foreach (Trait t in traitSet_Sel) //we only want to update the selected traits from each list.
            {
                t.StatEffect(this);
                t.ConditionalEffect(this);
            }

            base.UpdateInventory(player);
        }

        /// <summary>
        /// Resets the stats of this weapon. <para></para>
        /// Resets to previously set DEFAULTS, not 0.
        /// </summary>
        /// <param name="weapon"></param>
        public virtual void ResetStats(Weapon weapon)
        {
            weapon.stat_Impact = stat_Impact;

            weapon.statAttackRange = statAttackRange;
            weapon.statAttackSpeed = statAttackSpeed;
            weapon.statBreakChance = statBreakChance;
            weapon.statCombo = statCombo;
            weapon.statComboDamage = statComboDamage;
            weapon.statHeavyDamage = statHeavyDamage;

            weapon.statCritChance = statCritChance;
            weapon.statCritDamage = statCritDamage;
            weapon.statRange = statRange;
            weapon.statReload = statReload;
            weapon.statStability = statStability;
            weapon.magMax = magMax;

            weapon.statCastRange = statCastRange;
            weapon.statCastSpeed = statCastSpeed;
            weapon.statStatusChance = statStatusChance;
            weapon.statStatusDuration = statStatusDuration;

        }
        public virtual void ResetStats(KnightWeapon knight)
        {

        }
        public virtual void ResetStats(MageWeapon magic)
        {

        }
        public virtual void ResetStats(RangerWeapon range)
        {

        }

        /// <summary>
        /// Allows you to configure a set of traits.
        /// </summary>
        /// <param name="pool">The pool of traits</param>
        /// <param name="type">Add based on specific archetype</param>
        public virtual void SetTraitPool(List<Trait> pool, Archetype type)
        {
            
        }

        public enum Archetype
        {
            Knight,
            Mage,
            Ranger
        }
    }
}