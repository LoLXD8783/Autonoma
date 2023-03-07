namespace AEF.Core.Definitions
{
    public abstract class Ability : ModType
    {
        public ModTranslation myName;
        public ModTranslation Description;
        public int ID;

        public int energyCost;

        public int energyOverTime;

        public virtual void SetDefaults()
        {

        }

        protected sealed override void Register()
        {
            ModTypeLookup<Ability>.Register(this);
            myName = LocalizationLoader.GetOrCreateTranslation(Mod, "AbilityName." + myName);
            Description = LocalizationLoader.GetOrCreateTranslation(Mod, "AbilityDesc." + Description);
        }

        public sealed override void SetupContent()
        {
            SetDefaults();

            base.SetupContent();
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
        private static List<Ability> abilityList;

        internal static List<Ability> list 
        {
            get
            {
                if (abilityList == null)
                {
                    abilityList = new List<Ability>();
                }
                return abilityList;
            }
        }

        public static int Register(Ability obj)
        {
            int type = list.Count;
            list.Add(obj);
            return type;
        }

        public static Ability Get(int id)
        {
            if (id < 0 || id >= list.Count)
            {
                return default;
            }
            return abilityList[id];
        }

        public void Load(Mod mod)
        {

        }

        public void Unload()
        {
            list.Clear();
        }
    }
}