namespace AEF.Content.Traits.origin
{
    internal class origin_KeepTempo : Trait
    {
        public override void SetDefaults()
        {
            myName = "Keeping Tempo";
            Description = "";

            base.SetDefaults();
        }

        public override void ConditionalEffect(KnightWeapon k, MageWeapon m, RangerWeapon r)
        {


            base.ConditionalEffect(k, m, r);
        }
    }
}