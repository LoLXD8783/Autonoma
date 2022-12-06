using AEFramework.Content.Buffs.Addictions;

namespace AEFramework.Common.Definitions.Items
{
    public abstract class Enhancement : ModItem
    {
        public string enhancementInternalName;

        public float addictionRate;

        public bool isAddicted = false;

        public EnhancementType EnhancementType;

        public static Dictionary<string, (EnhancementType type, float baseAddictionRate, int baseEffectTime, int addictionDebuff, int baseAddictionTime)> enhancementData;

        public override void SetStaticDefaults()
        {
            if (enhancementData == null)
            {
                enhancementData = new()
                {
                    {"aloe", (EnhancementType.Natural, 0.2f, 1000, ModContent.BuffType<NaturalEnhancementAddiction>(), 20000)},
                    {"atropa", (EnhancementType.Natural, 0.3f, 1000, ModContent.BuffType<NaturalEnhancementAddiction>(), 20000)},
                    {"cordyceps", (EnhancementType.Natural, 0.45f, 1000, ModContent.BuffType<NaturalEnhancementAddiction>(), 20000)},
                };
            }
            base.SetStaticDefaults();
        }

        public override void SaveData(TagCompound tag)
        {
            base.SaveData(tag);
        }

        private void AddictionCheck(Player player)
        {
            float rand = Main.rand.NextFloat(1);

            float bAR = enhancementData[enhancementInternalName].baseAddictionRate;

            addictionRate = bAR;

            int fullTime = enhancementData[enhancementInternalName].baseAddictionTime;

            if (rand > addictionRate)
            {
                player.AddBuff(enhancementData[enhancementInternalName].addictionDebuff, fullTime);
            }
            else
            {
                ApplyEffect();
            }
        }

        public void ApplyEffect()
        {

        }

        public override bool? UseItem(Player player)
        {
            AddictionCheck(player);
            return base.UseItem(player);
        }

        public override void LoadData(TagCompound tag)
        {
            base.LoadData(tag);
        }
    }
    public enum EnhancementType
    {
        Natural,
        Combnination,
        Tech
    }
}