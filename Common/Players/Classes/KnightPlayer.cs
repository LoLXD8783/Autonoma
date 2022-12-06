namespace AEFramework.Common.Players.Classes
{
    public class KnightPlayer : AutonomaPlayer
    {
        public int currentStamina;
        public int maxStamina;

        public KnightSubclasses selectedSubclass = KnightSubclasses.None;

        public override void SetAbilities()
        {
            
        }

        public void StaminaUsage()
        {

        }

        public override void SaveData(TagCompound tag)
        {
            base.SaveData(tag);
        }

        public override void LoadData(TagCompound tag)
        {
            base.LoadData(tag);
        }

        public enum KnightSubclasses
        {
            None,
            Paladin,
            Berserker
        }
    }
}