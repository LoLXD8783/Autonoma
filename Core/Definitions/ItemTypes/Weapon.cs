namespace AEF.Core.Definitions.ItemTypes
{
    public abstract class Weapon : AEFItem
    {
        #region VARS

        public Archetype archetype { get; set; }

        public int stat_Impact;

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

        public override void UpdateInventory(Player player)
        {
            ResetStats(this);

            base.UpdateInventory(player);
        }

        public virtual void ResetStats(Weapon w)
        {
            w.stat_Impact = stat_Impact;
        }
        public virtual void ResetStats(KnightWeapon k)
        {

        }
        public virtual void ResetStats(MageWeapon m)
        {

        }
        public virtual void ResetStats(RangerWeapon r)
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