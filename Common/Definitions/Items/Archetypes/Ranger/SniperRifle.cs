namespace AEFramework.Common.Definitions.Items.Archetypes.Ranger
{
    internal abstract class SniperRifle : Weapon
    {
        public SubArchetypes SubArchetype { get; set; }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var infoLine = new TooltipLine(Mod, "info", $"{SubArchetype} Sniper Rifle \n");
            tooltips.Insert(1, infoLine);
            base.ModifyTooltips(tooltips);
        }

        //Snipers do not undergo Damage Falloff calculations, and thus the method is not necessary here.

        public enum SubArchetypes
        {
            Heavy,
            Lightweight,
        }
    }
}