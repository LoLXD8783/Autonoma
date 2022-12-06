namespace AEFramework.Common.Players.Abilities.Mage.Cleric
{
    public class Absorbance : Ability
    {
        public override void AbilityDefaults()
        {
            AbilityName = "Absorbance";
            AbilityDescription = "Cast to summon a shield of energy, absorbing incoming damage and returning it for health.";

            abilityType = AbilityType.SINGLE;

            energyCost = 50;
        }
    }
}