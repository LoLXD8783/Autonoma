namespace AEF.Core.Definitions.ItemTypes
{
    public abstract class Armor : AEFItem
    {
        public ArmorSlotType ArmorType { get; set; }

        public int Defense;

        public int[] Stats;

        public override void SetDefaults()
        {
            type = ItemType.Armor;

            base.SetDefaults();
        }

        public virtual void RollStats()
        {
            Stats = new int[5];

            switch (Rarity)
            {
                case ItemRarity.Common:
                case ItemRarity.Uncommon:
                    int rand = Main.rand.Next(0, 30);
                    Stats[0] += ArmorStatRolls.statDict[rand].agility;
                    Stats[1] += ArmorStatRolls.statDict[rand].endurance;
                    Stats[2] += ArmorStatRolls.statDict[rand].recuperation;
                    Stats[3] += ArmorStatRolls.statDict[rand].clairvoyance;
                    Stats[4] += ArmorStatRolls.statDict[rand].luck;
                    break;
                case ItemRarity.Rare:

                    break;
                case ItemRarity.Legendary:
                    break;
                case ItemRarity.Mythical:
                    break;
            }
        }

        public override void UpdateEquip(Player player)
        {
            ModContent.GetInstance<BasePlayer>().Stats.Agility += Stats[0];
            ModContent.GetInstance<BasePlayer>().Stats.Endurance += Stats[1];
            ModContent.GetInstance<BasePlayer>().Stats.Recuperation += Stats[2];
            ModContent.GetInstance<BasePlayer>().Stats.Clairvoyance += Stats[3];
            ModContent.GetInstance<BasePlayer>().Stats.Luck += Stats[4];

            base.UpdateEquip(player);
        }

        public enum ArmorSlotType
        {
            Head,
            Arms,
            Chest,
            Legs,
            Class
        }
    }
}