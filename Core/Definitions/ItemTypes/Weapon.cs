namespace AEF.Core.Definitions.ItemTypes
{
    public abstract class Weapon : AEFItem
    {
        /*"Why switch from array to nested list?"
         * In general, lists are far easier to use and are more malleable when it comes to multi-trait selectability.
         * 
         * Alternative ideas -=-
         * Make traits into "Mods" and have them be equippables. (this involves UI. fml)
         */

        #region VARS

        public Archetype archetype { get; set; }

        public int statImpact;

        /// <summary>
        /// A nested list to contain every trait this weapon has. <para></para>
        /// First list contains a set of lists <para></para>
        /// Each list contains 1-3 perks, first, second, third, fourth and origin, respectively.
        /// </summary>
        public List<List<Trait>> traitSet;

        private static List<Trait> TraitPool;

        public Trait[] traitSet_Sel;

        #endregion

        public override ModItem Clone(Item newEntity)
        {
            Weapon clone = (Weapon)base.Clone(newEntity);
            clone.traitSet = new List<List<Trait>>(traitSet.Count);
            for (int i = 0; i < clone.traitSet.Count; i++)
            {
                clone.traitSet.Add(new List<Trait>(traitSet[i].Count));
                for (int j = 0; j < clone.traitSet[i].Count; j++)
                {
                    clone.traitSet[i][j] = traitSet[i][j];
                }
            }

            return clone;
        }

        public override void Load()
        {
            traitSet = new()
            {
                new List<Trait>
                {

                },
                new List<Trait>
                {

                },
                new List<Trait>
                {

                },
                new List<Trait>
                {

                },
                new List<Trait>
                {

                }
            };

            SetTraitPool(TraitPool, archetype);

            base.Load();
        }

        public override void SetDefaults()
        {
            statImpact = 0;
            base.SetDefaults();
        }

        public override void UpdateInventory(Player player)
        {
            ResetStats(this);

            base.UpdateInventory(player);
        }

        public virtual void ResetStats(Weapon w)
        {
            w.statImpact = statImpact;
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