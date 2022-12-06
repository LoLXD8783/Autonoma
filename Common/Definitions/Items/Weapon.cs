using System.Runtime.CompilerServices;

namespace AEFramework.Common.Definitions.Items
{
    public abstract class Weapon : ItemFramework
    {
        #region VARIABLES

        public int statImpact;

        public float critChance;
        public float criDamage;

        public float statChance;
        public int statDur;

        public int statLunge;
        public int statGuard;
        public int statParry;
        public int statCounter;

        public int statRange;
        public int statStability;
        public int statHandling;
        public int statReload;

        public int baseReload;
        private int totalSpeed;

        public int statMagMax;
        public int magCur;
        public int statReservesMax;
        public int resCur;

        public const double feetConv = 3.2804;

        #endregion

        #region OTHER

        public Trait[] traitPool =
        {
            ModContent.GetInstance<Placeholder>(),
        };

        public Trait[] traitSet =
        {
            ModContent.GetInstance<Placeholder>(),
            ModContent.GetInstance<Placeholder>(),
            ModContent.GetInstance<Placeholder>(),
            ModContent.GetInstance<Placeholder>(),
            ModContent.GetInstance<Placeholder>()
        };

        public archetype Archetype { get; set; }

        #endregion

        public override ModItem Clone(Item item)
        {
            Weapon clone = (Weapon)base.Clone(item);
            clone.traitSet = (Trait[])traitSet.Clone();
            return clone;
        }

        public override void SetDefaults()
        {
            Category = item_category.Weapon;
            base.SetDefaults();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            //TODO: Implement proper check for mismatched player class.

            var archLine = new TooltipLine(Mod, "archetype", $"{Archetype} Weapon");
            tooltips.Add(archLine);

            var traitLines = new TooltipLine(Mod, "traits",
                $"{traitSet[0].TraitName} \n" +
                $"{traitSet[1].TraitName} \n" +
                $"{traitSet[2].TraitName} \n" +
                $"{traitSet[3].TraitName} \n" +
                $"{traitSet[4].TraitName} \n" +
                $"{traitSet[5].TraitName} \n" +
                $"{traitSet[6].TraitName} \n");

            base.ModifyTooltips(tooltips);
        }

        /// <summary>
        /// Randomly rolls traits for a weapon between four separate sections of traitPool. Origin traits are always the last element in the array.
        /// </summary>
        public void RollPerks(int min1, int max1, int min2, int max2, int min3, int max3, int min4, int max4, int min5, int max5, int min6, int max6)
        {
            int rand1 = Main.rand.Next(min1, max1 + 1);
            int rand2 = Main.rand.Next(min2, max2 + 1);
            int rand3 = Main.rand.Next(min3, max3 + 1);
            int rand4 = Main.rand.Next(min4, max4 + 1);
            int rand5 = Main.rand.Next(min5, max5 + 1);
            int rand6 = Main.rand.Next(min6, max6 + 1);

            traitSet[0] = traitPool[rand1];
            traitSet[1] = traitPool[rand2];
            traitSet[2] = traitPool[rand3];
            traitSet[3] = traitPool[rand4];
            traitSet[4] = traitPool[rand5];
            traitSet[5] = traitPool[rand6];
            traitSet[6] = traitPool.Last(); //origin traits are ALWAYS the last trait in the set.
        }

        /// <summary>
        /// Handles passive stat additives.
        /// </summary>
        private void StatAdditives()
        {
            foreach (Trait t in traitSet)
            {
                t.TraitEffect(this);
            }
        }

        #region KNIGHT METHODS

        /*KNIGHT WEAPON METHODS*/

        public virtual void MeleeLunge()
        {

        }

        #endregion

        #region RANGER METHODS

        /*RANGER WEAPON METHODS*/

        public virtual void DamageFalloff(int range)
        {

        }

        private int CalculatedReloadSpeed(int reloadSpeed, int baseReload)
        {
            return baseReload - (baseReload * (reloadSpeed / 100) - 30);
        }

        public void Reload(Player player, ModKeybind rKB)
        {
            if ((bool)UseItem(player))
            {
                magCur--;
                if (magCur <= 0 || magCur > 0 && rKB.JustPressed)
                {
                    totalSpeed--;
                    if (totalSpeed <= 0)
                    {
                        if (resCur < statMagMax)
                        {
                            magCur = resCur;
                            resCur = 0;
                        }
                        magCur = statMagMax;
                        resCur -= statMagMax;
                    }
                }
            }
        }

        #endregion

        #region MAGE METHODS

        /*MAGE WEAPON METHODS*/

        #endregion

        public override void UpdateInventory(Player player)
        {
            foreach (Trait t in traitSet)
            {
                t.ConditionalEffect(this);
            }

            if (Archetype == archetype.Ranger)
            {
                totalSpeed = CalculatedReloadSpeed(statReload, baseReload);

                DamageFalloff(statRange);

                Reload(player, KeybindSystem.ReloadKeybind);
            }

            base.UpdateInventory(player);
        }

        public override void OnCreate(ItemCreationContext context)
        {
            if (context is RecipeCreationContext c)
            {
                StatAdditives();
            }
            base.OnCreate(context);
        }

        public override void SaveData(TagCompound tag)
        {
            base.SaveData(tag);
        }

        public override void LoadData(TagCompound tag)
        {
            StatAdditives();
            base.LoadData(tag);
        }
    }

    public enum archetype
    {
        Knight,
        Mage,
        Ranger,
    }
}