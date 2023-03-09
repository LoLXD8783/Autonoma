namespace AEF.Content.Traits.origin
{
    internal class origin_Disassembler : Trait
    {
        public override void SetDefaults()
        {
            myName = "Machina Disassembler";

            Description = 
                "MACHINA OFFENSIVE ORIGIN TRAIT \n" +
                "Increases this weapon's damage against Machina enemies. \n\n" +
                "Also increases: \n" +
                "- Knight = Increased Break Chance \n" +
                "- Mage = Increased Status Chance and Duration \n" +
                "- Ranger = Increased Crit Chance and Damage";
            base.SetDefaults();
        }

        public override void ConditionalEffect(KnightWeapon k, MageWeapon m, RangerWeapon r)
        {
            //if this weapon is hitting a Machina enemy, increase impact and increase respective stat

            

            base.ConditionalEffect(k, m, r);
        }
    }
}