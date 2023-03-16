namespace AEF.Core.Players
{
    public class BasePlayer : ModPlayer
    {
        public PlayerClass playerClass { get; set; }

        public int XPCur;

        public int PlayerLevel;

        public int XPLevelReq;

        public int XPTotal;

        public (
            int Agility,
            int Endurance,
            int Recuperation,
            int Clairvoyance,
            int Luck)
            Stats;

        public float AbilityDuration;

        public float AbilityEfficiency;

        public float AbilityRange;

        public float AbilityStrength;

        public int EnergyCur;

        public int EnergyMax;

        public virtual void EnergyRegen()
        {

        }

        public virtual void OnLevelUp()
        {

        }

        public virtual void ResetStats()
        {
            Stats.Agility = 0;
            Stats.Endurance = 0;
            Stats.Recuperation = 0;
            Stats.Clairvoyance = 0;
            Stats.Luck = 0;

            AbilityDuration = 1f;
            AbilityEfficiency = 1f;
            AbilityRange = 1f;
            AbilityStrength = 1f;
        }

        public override void PostUpdate()
        {

            base.PostUpdate();
        }

        public override void SaveData(TagCompound tag)
        {
            tag[nameof(XPCur)] = XPCur;
            tag[nameof(XPTotal)] = XPTotal;

            tag[nameof(PlayerLevel)] = PlayerLevel;

            base.SaveData(tag);
        }

        public override void LoadData(TagCompound tag)
        {
            XPCur = tag.Get<int>(nameof(XPCur));
            XPTotal = tag.Get<int>(nameof(XPTotal));

            PlayerLevel = tag.Get<int>(nameof(PlayerLevel));

            base.LoadData(tag);
        }

        public enum PlayerClass
        {
            None,
            Knight,
            Mage,
            Ranger
        }
    }
}