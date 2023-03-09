using MonoMod.Cil;
using Mono.Cecil.Cil;

namespace AEF
{
    internal partial class MenuIL : Mod
    {
        private void Load()
        {
            IL.Terraria.Main.DrawMenu += DrawMenu_Patch;
        }

        private void DrawMenu_Patch(ILContext il)
        {
            ILCursor cur = new(il);
            ILLabel ifEnd = null;
            var mode = typeof(Main).GetField(nameof(Main.menuMode));
            if (!cur.TryGotoNext(i => i.MatchLdsfld(mode),
                i => i.MatchLdcI4(-7),
                i => i.MatchBneUn(out ifEnd)))
            {
                Logger.Info("Draw menu's patch failed");
                return;
            }
            if (ifEnd == null)
            {
                Logger.Info("Draw menu's patch's label is null");
                return;
            }

            ILLabel nonce = il.DefineLabel();

            int start = cur.Index;
            cur.GotoLabel(ifEnd);
            int end = cur.Index;
            cur.Goto(start);

            cur.Emit(OpCodes.Br, nonce);
            cur.Goto(end);
            cur.MarkLabel(nonce);

            var focus = typeof(Main).GetField("focusMenu", BindingFlags.NonPublic | BindingFlags.Instance);
            var sel_Menu = typeof(Main).GetField("sel_Menu", BindingFlags.NonPublic | BindingFlags.Instance);

        }

        private void Unload()
        {
            IL.Terraria.Main.DrawMenu -= DrawMenu_Patch;
        }
    }
}
