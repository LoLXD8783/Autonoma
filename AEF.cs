namespace AEF
{
	public class AEF : Mod
	{
        public override void Load()
        {
            base.Load();
        }

        public override void PostSetupContent()
        {
            RunWhiteList();
            base.PostSetupContent();
        }

        public void SetScreenTitle()
        {
            string[] titles =
            {
                "AEF | Welcome!",
                "AEF | Welcome Back, Terrarian",
                "AEF | Welcome Back",
                "AEF | Starset's My Favorite Band",
                "AEF | 777",
                "AEF | Been to the Cloud District lately?",
                "AEF | I mean it's alright, like",
                "AEF | Event Horizon Games made me",
                "AEF | :3",
                "AEF | You reading these?!",
                "AEF | Flashback to a couple years ago and this was impossible!",
                "AEF | (psst... click a corner in the options menu!)",
                "AEF | Just a reminder to be nice to eachother :)",
                "AEF | ",
                "AEF | "
            };

            int rand = Main.rand.Next(0, titles.Length + 1);

            Main.instance.Window.Title = titles[rand];
        }

        private void RunWhiteList()
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
        }

        public static readonly string[] Whitelist =
        {
            "RecipeBrowser",
            "CheatSheet",
            "AEF"
        };

    }
}