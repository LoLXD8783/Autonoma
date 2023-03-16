namespace AEF.Core.Definitions
{
    public abstract class AEFNPC : ModNPC
    {
        public NPCRace NpcRace { get; set; }

        public bool isBroken;

        public int ShieldsCur;

        public int ShieldsMax;

        public static List<AEFItem> LootPool;

        public int[] Resistances;   

        /// <summary>
        /// Checks (manually) whether this NPC is dead.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsDead()
        {
            return false;
        }

        /// <summary>
        /// Allows you to add items to this NPC's loot pool.
        /// </summary>
        /// <param name="lootPool"></param>
        public virtual void ConfigureLootPool(List<AEFItem> lootPool) 
        {

        }

        /// <summary>
        /// Allows you to make things happen when this NPC dies.
        /// </summary>
        public virtual void OnDeath()
        {

        }

        #region CONTACT REMOVAL
        public override bool? CanBeHitByItem(Player player, Item item) => false;

        public override bool CanHitPlayer(Player target, ref int cooldownSlot) => false;

        //and just like that, contact damage is gone!!!!!!!111!1

        //Not really, but it's a start to getting rid of this mental illness.
        #endregion

        public override void Load()
        {
            ConfigureLootPool(LootPool);
            base.Load();
        }

        public enum NPCRace
        {
            Machina,
            Plagueborn,
            Xothian
        }
    }
}