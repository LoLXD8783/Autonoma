using AEFramework.Common.Definitions.Items;

namespace AEFramework.Content.Items.Weapons.Ranger.Traits.OriginSlot
{
    /*Origin Traits are:
     * - Conditional or Passive
     * - Normally auto-updated.
     * - Never static increases unless given otherwise.
     */

    internal class origin_HeatVents : Trait
    {
        int usageTimer;

        public override void SetInfo()
        {
            TraitName = "Heat Vents";

            TraitDescription = "Continual firing of this weapon will cause it to overheat, inflicting Flare to combatants.";
            base.SetInfo();
        }

        public override void ConditionalEffect(Weapon w)
        {
            if ((bool)w.UseItem(Main.LocalPlayer)) //if being used
            {
                usageTimer++; //increment usage timer

                if (usageTimer >= 180) //if after 3 seconds still being used...
                {
                    //TODO: Implement Flare buff infliction.
                }
                if (!(bool)w.UseItem(Main.LocalPlayer))
                {
                    usageTimer = 0; //reset to 0 if not being used.
                }
            }
            base.ConditionalEffect(w);
        }
    }
}