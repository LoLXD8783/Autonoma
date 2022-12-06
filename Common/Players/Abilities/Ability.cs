namespace AEFramework.Common.Players.Abilities
{
    public abstract class Ability
    {
        public string AbilityName { get; set; }

        public string AbilityDescription { get; set; }

        public int energyCost;

        public int energyOverTime;

        public int chargeTimer;
        private int chargeGateLow;
        private int chargeGateMedium;
        private int chargeGateHigh;

        public bool isToggled = false;

        public bool isSelected = false;

        public AbilityType abilityType;
        public ChargeLevel chargeLevel;

        public abstract void AbilityDefaults();

        public virtual bool CanCast(AbilityType type)
        {
            var aPlr = ModContent.GetInstance<AutonomaPlayer>();

            if (type == AbilityType.SINGLE)
            {
                aPlr.currentEnergy -= energyCost;
                return true;

            }
            if (type == AbilityType.TOGGLE) //Either: expire due to loss of energy OR expire due to toggle being set back to false
            {
                while (isToggled)
                {
                    aPlr.currentEnergy -= energyOverTime;
                    if (aPlr.currentEnergy <= 0)
                    {
                        isToggled = false;
                        Main.NewText("[DEBUG]: Toggleable ability has expired due to energy loss.");
                        return false;
                    }
                    return true;
                }
            }
            if (type == AbilityType.CHARGE)
            {
                if (chargeTimer <= chargeGateLow)
                {
                    chargeLevel = ChargeLevel.LOW;
                    return true;
                }
                if (chargeTimer <= chargeGateMedium)
                {
                    chargeLevel = ChargeLevel.MEDIUM;
                    return true;
                }
                if (chargeTimer <= chargeGateHigh)
                {
                    chargeLevel = ChargeLevel.HIGH;
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public enum AbilityType
        {
            SINGLE,
            TOGGLE,
            CHARGE
        }
        public enum ChargeLevel
        {
            LOW,
            MEDIUM,
            HIGH
        }
    }
}