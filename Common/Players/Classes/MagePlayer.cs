using AEFramework.Common.Players.Abilities;
using AEFramework.Common.Players.Abilities.Mage.Cleric;

namespace AEFramework.Common.Players.Classes
{
    public class MagePlayer : AutonomaPlayer
    {
        public Ability[] clericAbilities =
        {
            ModContent.GetInstance<Absorbance>()
        };

        public MageSubclasses SelectedSubclass
        {
            get { 
                return SelectedSubclass; 
            }
            set { 
                SelectedSubclass = value;
                SetAbilities();
            }
        }

        public override void SaveData(TagCompound tag)
        {
            tag[nameof(SelectedSubclass)] = SelectedSubclass.ToString();
            base.SaveData(tag);
        }

        public override void SetAbilities()
        {
            if (PlayerClass == PlayerClass.Mage)
            {
                switch (SelectedSubclass)
                {
                    case MageSubclasses.Cleric:
                        for (int i = 0; i < subclassAbilities.Length; i++)
                        {
                            subclassAbilities[i] = clericAbilities[i];
                        }
                        Main.NewText("[DEBUG]: Abilities set.");
                        break;
                    case MageSubclasses.Warlock:

                        break;
                }
            }
        }

        public override void LoadData(TagCompound tag)
        {
            string subClassName = tag.GetString(nameof(SelectedSubclass));
            if (Enum.TryParse(typeof(MageSubclasses), subClassName, out object result))
            {
                SelectedSubclass = (MageSubclasses)result;
            }
            base.LoadData(tag);
        }

        public enum MageSubclasses
        {
            None,
            Cleric,
            Warlock,
        };
    }
}