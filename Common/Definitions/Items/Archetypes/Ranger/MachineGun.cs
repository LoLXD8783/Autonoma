namespace AEFramework.Common.Definitions.Items.Archetypes.Ranger
{
    internal class MachineGun : Weapon
    {
        public SubArchetypes SubArchetype { get; set; }

        public override void SetDefaults()
        {
            Archetype = archetype.Ranger;
            base.SetDefaults();
        }

        public override void DamageFalloff(int range)
        {
            //example calculations:
            //with a range stat of 50, a Semi-Automatic Machine Gun would have a full damage distance of 22 blocks
            //after those 22 rough blocks, the damage begins gradually falling off across 5.5 blocks.
            //after those 5.5, the bullet becomes ineffective.

            //TODO: add another stat which affects the general falloff distance (perhaps high-velocity rounds?)

            float SubArchModifier = 0;

            switch (SubArchetype)
            {
                case SubArchetypes.Automatic:
                    SubArchModifier = 0.19f;
                    break;
                case SubArchetypes.Burst_Fire:
                    SubArchModifier = 0.22f;
                    break;
                case SubArchetypes.Semi_Auto:
                    SubArchModifier = 0.27f;
                    break;
            }

            double fullDamage = range * SubArchModifier * feetConv;

            double falloffEnd = fullDamage * 0.35f; //falloff will always be 35% of the base distance. May reduce.
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var infoLine = new TooltipLine(Mod, "info", $"{SubArchetype.ToString().Replace('_', ' ')} Machine Gun \n");
            tooltips.Insert(1, infoLine);
            base.ModifyTooltips(tooltips);
        }
    }

    public enum SubArchetypes
    {
        Automatic,
        Burst_Fire,
        Semi_Auto,
    }
}