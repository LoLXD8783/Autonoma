namespace AEFramework
{
	public class AEFramework : Mod
    {
        public override void PostSetupContent()
        {
            var meth = typeof(ModLoader).GetMethod("DisableMod", BindingFlags.Static | BindingFlags.NonPublic);
            Task.Run(() =>
            {
                Logger.Debug("[AEF]: Checking for blacklisted mods...");
                bool anyDisabled = false;
                for (int i = 1; i < ModLoader.Mods.Length; i++)
                {
                    if (!Whitelist.Contains(ModLoader.Mods[i].Name))
                    {
                        anyDisabled = true;
                        meth.Invoke(null, new object[] { ModLoader.Mods[i].Name });
                        Logger.Debug($"- {ModLoader.Mods[i].Name} has been disabled.");
                    }
                }
                if (!anyDisabled) return;
                while (Main.menuMode != 0) { }
                Main.menuMode = 10006;
            }); 
            base.PostSetupContent();
        }

        public static readonly string[] Whitelist =
        {
            "RecipeBrowser",
            "CheatSheet",
            "AEFramework"
        };
    }
}