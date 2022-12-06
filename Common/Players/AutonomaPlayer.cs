using AEFramework.Common.Players.Abilities;

namespace AEFramework.Common.Players
{
    public abstract class AutonomaPlayer : ModPlayer
    {
        //HANDLES: Stats, stat calculations, ability stats, those stat calcs, and saving

        //ability specifications, classes, subclasses, are handled separately.

        //AGILITY: Affects movement speed, jump height, ranger dodge, etc.
        //CLAIRVO: Affects energy regen, effectiveness, mana regen, etc.
        //DURABIL: Affects damage resistance, shield cap, etc.
        //RECUPER: Affects 
        //STRENGT: Affects 

        #region VARS

        public bool isSprinting;

        public PlayerClass PlayerClass { get; set; }

        public int agilityStat;
        public int clairvoyanceStat;
        public int durabilityStat;
        public int recuperationStat;
        public int strengthStat;

        public int abilityStrength;
        public int abilityEffectiveness;
        public int abilityRange;
        public int currentEnergy;
        public int maxEnergy;

        public Ability[] subclassAbilities;

        public int playerLevel;
        public int currentExperience;
        private int nextLevelReq;
        private int totalExperience;

        private static readonly int baseExperience = 1000;
        private static readonly int experienceCap = 21464000;

        #endregion

        public override void SaveData(TagCompound tag)
        {
            tag[nameof(clairvoyanceStat)] = clairvoyanceStat;
            tag[nameof(agilityStat)] = agilityStat;
            tag[nameof(recuperationStat)] = recuperationStat;
            tag[nameof(durabilityStat)] = durabilityStat;

            tag[nameof(currentEnergy)] = currentEnergy;
            tag[nameof(currentExperience)] = currentExperience;

            tag[nameof(PlayerClass)] = PlayerClass.ToString();

            base.SaveData(tag);
        }

        public override void ResetEffects()
        {
            isSprinting = false;
            base.ResetEffects();
        }

        public void ClassStatCalculation()
        {
            if (agilityStat > 100)
            {
                agilityStat = 100;
            }
            if (clairvoyanceStat > 100)
            {
                clairvoyanceStat = 100;
            }
            if (durabilityStat > 100)
            {
                durabilityStat = 100;
            }
            if (recuperationStat > 100)
            {
                recuperationStat = 100;
            }

            int agilityLevel = (int)Math.Floor((double)(durabilityStat / 10));
            int clairvoyanceLevel = (int)Math.Floor((double)(clairvoyanceStat / 10));
            int durabilityLevel = (int)Math.Floor((double)(durabilityStat / 10));
            int recuperationLevel = (int)Math.Floor((double)(recuperationStat / 10));
        }

        #region ABILITY HANDLING
        public void AbilityEnergyRegen()
        {
            int oneSec = 60;
            if (currentEnergy < maxEnergy)
            {
                oneSec--;
                if (oneSec <= 0)
                {
                    currentEnergy += 1;
                    oneSec = 60;
                }
            }
            if (currentEnergy >= maxEnergy)
            {
                currentEnergy = maxEnergy;
            }
        }

        public abstract void SetAbilities();

        public virtual void CastAbility()
        {
            foreach(Ability a in subclassAbilities)
            {
                if (a.isSelected && KeybindSystem.CastAbilityKeybind.JustPressed)
                {
                    Main.NewText($"{Player.name} has cast {a.AbilityName}!");
                    if (a.abilityType == Ability.AbilityType.TOGGLE) a.isToggled ^= true;
                    a.CanCast(a.abilityType);
                }
                if (a.isSelected && KeybindSystem.CastAbilityKeybind.Current && a.abilityType == Ability.AbilityType.CHARGE)
                {
                    a.chargeTimer++;
                    if (KeybindSystem.CastAbilityKeybind.JustReleased && a.chargeTimer > 0)
                    {
                        a.CanCast(a.abilityType);
                        Main.NewText($"{Player.name} has cast {a.AbilityName} with strength {a.chargeLevel}!");
                    }
                }
            }
        }

        public void SelectAbility()
        {
            if (KeybindSystem.SelectFirstKeybind.JustPressed)
            {
                SetState(true, false, false, false);
                Main.NewText("[DEBUG]: 1st Ability " + subclassAbilities[0].AbilityName + " has been selected.");
            }
            if (KeybindSystem.SelectSecondKeybind.JustPressed)
            {
                SetState(false, true, false, false);
                Main.NewText("[DEBUG]: 2nd Ability " + subclassAbilities[1].AbilityName + " has been selected.");
            }
            if (KeybindSystem.SelectThirdKeybind.JustPressed)
            {
                SetState(false, false, true, false);
                Main.NewText("[DEBUG]: 3rd Ability " + subclassAbilities[2].AbilityName + " has been selected.");
            }
            if (KeybindSystem.SelectFourthKeybind.JustPressed)
            {
                SetState(false, false, false, true);
                Main.NewText("[DEBUG]: 4th Ability " + subclassAbilities[3].AbilityName + " has been selected.");
            }
        }

        public void SetState(bool setState1, bool setState2, bool setState3, bool setState4)
        {
            subclassAbilities[0].isSelected = setState1;
            subclassAbilities[1].isSelected = setState2;
            subclassAbilities[2].isSelected = setState3;
            subclassAbilities[3].isSelected = setState4;
        }
        #endregion

        #region EXPERIENCE HANDLING
        public void ExperienceCalculation()
        {
            if (totalExperience == experienceCap)
            {
                totalExperience = experienceCap;
            }
            else
            {
                nextLevelReq = (1 + playerLevel) ^ 2 * baseExperience;
                if (currentExperience >= nextLevelReq)
                {
                    playerLevel++;
                    currentExperience = 0;
                    OnLevelUp();
                    Main.NewText($"{Player.name} has reached level {playerLevel}!");
                    Main.NewText($"[DEBUG]: Next level requirement: {nextLevelReq}");
                }
            }
        }

        public static void OnLevelUp()
        {
            Main.NewText("[DEBUG]: This is to test if this function works.");
            Main.NewText("[DEBUG]: If you are reading this... congrats! It worked. Sorta.");

            //Introduce level up reward screen UI here
        }
        #endregion

        public static void StatModifiers()
        {

        }

        public void Sprint(ModKeybind sKB)
        {
            if (sKB.Current)
            {
                Player.moveSpeed += 0.25f;
                isSprinting = true;
            }
        }

        public override void PostUpdate()
        {
            
            AbilityEnergyRegen();
            Sprint(KeybindSystem.SprintKeybind);
            ClassStatCalculation();
            ExperienceCalculation();
            base.PostUpdate();
        }

        public override void LoadData(TagCompound tag)
        {
            clairvoyanceStat = tag.Get<int>(nameof(clairvoyanceStat));
            agilityStat = tag.Get<int>(nameof(agilityStat));
            recuperationStat = tag.Get<int>(nameof(recuperationStat));
            durabilityStat = tag.Get<int>(nameof(durabilityStat));

            currentEnergy = tag.Get<int>(nameof(currentEnergy));
            currentExperience = tag.Get<int>(nameof(currentExperience));

            string className = tag.GetString(nameof(PlayerClass));
            if (Enum.TryParse(typeof(PlayerClass), className, out object result))
            {
                PlayerClass = (PlayerClass)result;
            }

            base.LoadData(tag);
        }
    }
    public enum PlayerClass
    {
        Knight,
        Mage,
        Ranger,
    }

    public enum AbilityCycle
    {
        First,
        Second,
        Third,
        Fourth
    }
}