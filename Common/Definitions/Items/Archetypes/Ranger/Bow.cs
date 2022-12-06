namespace AEFramework.Common.Definitions.Items.Archetypes.Ranger
{
    public abstract class Bow : Weapon
    {
        public SubArchetypes SubArchetype { get; set; }

        public int chargeCur;
        public int chargeTime;

        public override void SetDefaults()
        {
            Archetype = archetype.Ranger;
            base.SetDefaults();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var infoLine = new TooltipLine(Mod, "info", $"{SubArchetype} Bow \n");
            tooltips.Insert(1, infoLine);

            var chargeTimeStat = new TooltipLine(Mod, "bowCharge", $"{chargeTime / 60}s Draw Time");
            tooltips.Add(chargeTimeStat);
            base.ModifyTooltips(tooltips);
        }

        //Bow damage calculation is relative to charge time, and thus, is not subject to falloff.

        //Range INSTEAD becomes accuracy, and thus calculates the derivation from your shot point.

        public enum SubArchetypes
        {
            Compound,
            Long,
            Recurve
        }
    }
}