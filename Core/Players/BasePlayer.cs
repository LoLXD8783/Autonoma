namespace AEF.Core.Players
{
    public class BasePlayer : ModPlayer
    {
        public PlayerClass playerClass { get; set; }

        public int XPCur;

        public int PlayerLevel;

        public int XPLevelReq;

        public int XPTotal;

        public virtual void OnLevelUp()
        {

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