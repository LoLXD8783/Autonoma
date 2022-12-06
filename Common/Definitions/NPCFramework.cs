namespace AEFramework.Common.Definitions
{
    public abstract class NPCFramework : ModNPC
    {
        public NPCType NPCType { get; set; }

        public override void SetDefaults()
        {
            NPC.damage = 0;
            base.SetDefaults();
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            return false;
        }

        public override bool? CanHitNPC(NPC target)
        {
            //TODO: Implement Ally / Faction damage logic.
            return false;
        }
    }

    public enum NPCType
    {
        Ally,
        Hostile,
        Vendor
    }
}