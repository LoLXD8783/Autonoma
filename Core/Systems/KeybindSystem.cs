namespace AEF.Core.Systems
{
    internal class KeybindSystem : ModSystem
    {
        public static ModKeybind KB_Sprint { get; private set; }

        public static ModKeybind KB_Reload { get; private set; }

        public override void Load()
        {
            base.Load();
        }

        public override void Unload()
        {
            base.Unload();
        }
    }
}