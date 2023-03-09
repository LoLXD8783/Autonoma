namespace AEF.Core.Definitions
{
    public class Trait : ModType, TagSerializable, ILoadable
    {
        public string myName;

        public string Description;

        public TagCompound SerializeData()
        {
            return new TagCompound()
            {
                ["name"] = myName
            };
        }

        private static Func<TagCompound, Trait> DESERIALIZER => 
            static (TagCompound tag) => 
            {
                return new Trait()
                {
                    myName = tag.Get<string>("name")
                };
            };

        public static Trait DeserializeData(TagCompound tag)
        {
            return DESERIALIZER.Invoke(tag);
        }

        public virtual void SetDefaults()
        {

        }

        public virtual void ConditionalEffect(KnightWeapon k, MageWeapon m, RangerWeapon r)
        {

        }

        public virtual void StatEffect(KnightWeapon k, MageWeapon m, RangerWeapon r)
        {

        }

        public override string ToString()
        {
            return myName.ToString().ToLower().Trim('\'').Replace(' ', '_');
        }

        protected sealed override void Register()
        {
            ModTypeLookup<Trait>.Register(this);
        }

        public sealed override void SetupContent()
        {
            SetDefaults();
            base.SetupContent();
        }

        public override void Load()
        {

        }

        public override void Unload()
        {

        }
    }

    public class TraitLoader : ILoadable
    {
        private static List<Trait> TraitList;

        void ILoadable.Load(Mod mod)
        {
            TraitList = new List<Trait>();

            foreach (Type t in mod.Code.GetTypes())
            {
                if (t.IsSubclassOf(typeof(Trait)))
                {
                    TraitList.Add((Trait)Activator.CreateInstance(t));
                }
            }
        }

        void ILoadable.Unload()
        {
            TraitList.Clear();
        }
    }
}