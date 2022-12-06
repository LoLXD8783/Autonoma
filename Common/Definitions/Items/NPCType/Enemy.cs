namespace AEFramework.Common.Definitions.Items.NPCType
{
    public abstract class Enemy : NPCFramework
    {
        public npc_Faction Faction { get; set; }

        public int enemy_Level;

        public int enemy_Allegiances;

        public override void SetDefaults()
        {
            Faction = npc_Faction.None;
            base.SetDefaults();
        }

        public void CalculateResistances()
        {
            //TODO: Implement elemental stuff.
            switch (Faction)
            {
                case npc_Faction.Elysian: break;
                case npc_Faction.Hybrid: break;
                case npc_Faction.Machina: break;
                case npc_Faction.Plagueborn: break;
                case npc_Faction.Xothian: break;
            }
        }
    }

    public enum npc_Faction
    {
        None,
        Elysian,
        Hybrid,
        Machina,
        Plagueborn,
        Xothian
    }

    public enum npc_SubFaction
    {
        None,
        machina_Pressure_Sect,
        machina_Flare_Sect, //
    }
}