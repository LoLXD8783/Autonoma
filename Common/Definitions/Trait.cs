using AEFramework.Common.Definitions.Items;

namespace AEFramework.Common.Definitions
{
    public abstract class Trait
    {
        /// <summary>
        /// The name of this trait.
        /// </summary>
        public string TraitName { get; set; }

        /// <summary>
        /// The description of this trait.
        /// </summary>
        public string TraitDescription { get; set; }

        /// <summary>
        /// Sets the basic info for this trait such as name, description, etc.
        /// </summary>
        public virtual void SetInfo()
        {

        }

        /// <summary>
        /// The stat additive effect of this trait.
        /// </summary>
        /// <param name="w">The weapon this trait affects.</param>
        public virtual void TraitEffect(Weapon w)
        {

        }

        /// <summary>
        /// The conditional effect for this trait. (Damage bonus on kill, extra range after repeated fire, etc.)
        /// </summary>
        /// <param name="w">The weapon this trait affects.</param>
        public virtual void ConditionalEffect(Weapon w)
        {

        }
    }

    public class TraitLoader : ILoadable
    {
        private static List<Trait> traitList;

        internal static List<Trait> List
        {
            get
            {
                if (traitList == null)
                {
                    traitList = new List<Trait>();
                }
                return traitList;
            }
        }
        public static int Register(Trait obj)
        {
            int type = List.Count;
            List.Add(obj);
            return type;
        }
        public static Trait Get(int id)
        {
            if (id < 0 || id >= List.Count)
            {
                return default;
            }
            return List[id];
        }
        public void Load(Mod mod)
        {

        }
        public void Unload()
        {
            List.Clear();
        }
    }

    public class Placeholder : Trait
    {
        public override void SetInfo()
        {
            TraitName = "RANDOM";
            TraitDescription = "This weapon will roll with random traits.";
            base.SetInfo();
        }
    }
}