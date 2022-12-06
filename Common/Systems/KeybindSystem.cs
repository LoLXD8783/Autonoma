using Microsoft.Xna.Framework.Input;
using Terraria.ModLoader;

namespace AEFramework.Common.Systems
{
    public class KeybindSystem : ModSystem
    {
        #region KEYBIND DEFINITIONS
        public static ModKeybind SprintKeybind { get; private set; } //implements sprinting

        public static ModKeybind RankUpKeybind { get; private set; } //used for weapon rank ups

        public static ModKeybind CastAbilityKeybind { get; private set; } //used for casting abilities, alternate usage of "quick cast"

        public static ModKeybind SelectFirstKeybind { get; private set; } //

        public static ModKeybind SelectSecondKeybind { get; private set; } //

        public static ModKeybind SelectThirdKeybind { get; private set; } //

        public static ModKeybind SelectFourthKeybind { get; private set; } //

        public static ModKeybind ParryKeybindKeybind { get; private set; } //

        public static ModKeybind ReloadKeybind { get; private set; } //reload keybind for rangers
        #endregion

        public override void Load()
        {
            SprintKeybind = KeybindLoader.RegisterKeybind(Mod, "Sprint", Keys.LeftShift);
            RankUpKeybind = KeybindLoader.RegisterKeybind(Mod, "Rank Up Weapon", Keys.LeftAlt);
            CastAbilityKeybind = KeybindLoader.RegisterKeybind(Mod, "Cast Ability", Keys.F);
            SelectFirstKeybind = KeybindLoader.RegisterKeybind(Mod, "Select First Ability", Keys.D1);
            SelectSecondKeybind = KeybindLoader.RegisterKeybind(Mod, "Select Second Ability", Keys.D2);
            SelectThirdKeybind = KeybindLoader.RegisterKeybind(Mod, "Select Third Ability", Keys.D3);
            SelectFourthKeybind = KeybindLoader.RegisterKeybind(Mod, "Select Fourth Ability", Keys.D4);
            ReloadKeybind = KeybindLoader.RegisterKeybind(Mod, "Reload Weapon", Keys.R);
            base.Load();
        }

        public override void Unload()
        {
            SprintKeybind = null;
            RankUpKeybind = null;
            CastAbilityKeybind = null;
            SelectFirstKeybind = null;
            SelectSecondKeybind = null;
            SelectThirdKeybind = null;
            SelectFourthKeybind = null;
            ReloadKeybind = null;
            base.Unload();
        }
    }
}