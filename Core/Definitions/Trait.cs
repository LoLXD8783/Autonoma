namespace AEF.Core.Definitions
{
    public abstract class Trait : ModType
    {
        public ModTranslation myName;
        public ModTranslation Description;
        public int ID;

        public virtual string iconTexture => "";

        public Trait trait => this;

        public virtual void SetDefaults()
        {
            myName.SetDefault("");
            Description.SetDefault("");
        }

        public virtual void ConditionalEffect(KnightWeapon k, MageWeapon m, RangerWeapon r)
        {

        }

        public virtual void StatEffect(KnightWeapon k, MageWeapon m, RangerWeapon r)
        {

        }

        protected sealed override void Register()
        {
            ModTypeLookup<Trait>.Register(this);
            myName = LocalizationLoader.GetOrCreateTranslation(Mod, "TraitName." + myName);
            Description = LocalizationLoader.GetOrCreateTranslation(Mod, "TraitDescription." + Description);


        }

        public sealed override void SetupContent()
        {
            SetDefaults();

            base.SetupContent();
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
}