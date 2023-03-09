namespace AEF.Core.Definitions
{
    public class Ability : ModType, TagSerializable, ILoadable
    {
        public AbilityType Type { get; set; }

        public ChargeState State { get; set; }

        public string myName;

        public string Description;

        public int energyCost;

        public int energyOverTime;

        public TagCompound SerializeData()
        {
            return new TagCompound
            {
                ["name"] = myName,
            };
        }

        private static Func<TagCompound, Ability> DESERIALIZER => 
            static (TagCompound tag) =>
            {
                return new Ability()
                {
                    myName = tag.GetString("name")
                };
            };

        public static Ability DeserializeData(TagCompound tag)
        {
            return DESERIALIZER.Invoke(tag);
        }

        public virtual void SetDefaults()
        {

        }

        public sealed override void SetupContent()
        {
            SetDefaults();
            base.SetupContent();
        }

        protected sealed override void Register()
        {
            ModTypeLookup<Ability>.Register(this);
        }

        public override void Load()
        {
            base.Load();
        }

        public override void Unload()
        {
            base.Unload();
        }

        public enum AbilityType
        {
            SINGLE,
            TOGGLE,
            CHARGE
        }

        public enum ChargeState
        {
            LOW,
            MEDIUM,
            HIGH
        }

    }

    public class AbilityLoader : ILoadable
    {
        private static List<Ability> AbilityList;

        void ILoadable.Load(Mod mod)
        {
            AbilityList = new List<Ability>();

            foreach (Type t in mod.Code.GetTypes())
            {
                if (t.IsSubclassOf(typeof(Ability)))
                {
                    AbilityList.Add((Ability)Activator.CreateInstance(t));
                }
            }
        }

        void ILoadable.Unload()
        {
            AbilityList.Clear();
        }
    }
}