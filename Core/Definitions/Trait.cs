namespace AEF.Core.Definitions
{
    public abstract class Trait : ILoadable
    {
        public string TraitName;

        public string TraitDescription;

        public int ID;

        /// <summary>
        /// Returns the ID of this trait.
        /// </summary>
        /// <typeparam name="T">The Trait you're grabbing the ID for</typeparam>
        /// <returns></returns>
        public static int GetID<T>() where T : Trait
        {
            int myKey = TraitLoader.TraitList.IndexOf(ModContent.GetInstance<T>());
            return myKey;
        }

        /// <summary>
        /// Registers this trait to the database. <para></para>
        /// Must be called in <see cref="Trait.SetDefaults"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        protected static void Register<T>() where T : Trait
        {
            TraitLoader.TraitList.Add(ModContent.GetInstance<T>());
            //WriteToDebug "Trait [ID] registered successfully."
        }

        public virtual void SetDefaults()
        {

        }

        void ILoadable.Load(Mod mod)
        {
            SetDefaults();
        }

        void ILoadable.Unload()
        {

        }
        
        /// <summary>
        /// Makes things happen when this trait is on a weapon. <para></para>
        /// Handles static trait increases and conditional effects (such as kill counts) <para></para>
        /// See <see cref="Weapon.UpdateInventory(Player)"/> for more information of how this method is called. <para></para>
        /// See <see cref="Random.TraitEffect(Weapon)"/> for an example of how this method is used.
        /// </summary>
        /// <param name="weapon"></param>
        public virtual void TraitEffect(Weapon weapon)
        {

        }
    }

    public class TraitLoader : ModSystem
    {
        public static List<Trait> TraitList;

        public override void Load()
        {
            TraitList = new List<Trait>();
        }

        public override void Unload()
        {
            TraitList.Clear();
        }
    }

    public class Random : Trait
    {
        public override void SetDefaults()
        {
            TraitName = "RANDOM";

            TraitDescription = "Description";

            Register<Random>();
            base.SetDefaults();
        }

        public override void TraitEffect(Weapon weapon)
        {
            //weapon.statImpact += 5;

            //while (tempTimer > 0 && thisBuff (some bool)) {
            //  weapon.statImpact += 10;
            //  tempTimer--;
            //}

            //Due to how this method is called in updateInventory, we can use it like an updater.

            //Applies to:
            // - timers
            // - kill counts
            // - random tick-based checks
            // - variable resetting

            base.TraitEffect(weapon);
        }
    }
}