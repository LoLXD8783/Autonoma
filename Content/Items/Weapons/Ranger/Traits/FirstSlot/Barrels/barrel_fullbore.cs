namespace AEFramework.Content.Items.Weapons.Ranger.Traits.FirstSlot.Barrels
{
    internal class barrel_fullbore : Trait
    {
        public override void SetInfo()
        {
            TraitName = "Full Bore";
            TraitDescription = 
                "This barrel is optimized for range. \n" +
                "- Increases range \n" +
                "- Decreases handling \n";
            base.SetInfo();
        }

        public override void ConditionalEffect(Weapon w)
        {
            w.statRange += 10;
            w.statHandling -= 10;
            base.ConditionalEffect(w);
        }
    }
}