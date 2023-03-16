namespace AEF.Core.Definitions
{
    public abstract class AEFBuff : ModBuff
    {
        public BuffType EffectType { get; set; }

        public Texture2D BorderTexture;

        public Texture2D IconTexture;

        public bool IsStackable;

        public int BuffStack;

        public int BuffTime;

        public float StackModifier;

        private float EffectModifier;

        public override bool PreDraw(SpriteBatch spriteBatch, int buffIndex, ref BuffDrawParams drawParams) => false;

        public override void PostDraw(SpriteBatch spriteBatch, int buffIndex, BuffDrawParams drawParams)
        {
            //Custom draw

            switch (EffectType)
            {
                case BuffType.Buff:
                    BorderTexture = (Texture2D)ModContent.Request<Texture2D>("AEF/Assets/Textures/Buff/Border/buffborder_positive");
                    //Positive icon
                    break;
                case BuffType.Debuff:
                    BorderTexture = (Texture2D)ModContent.Request<Texture2D>("AEF/Assets/Textures/Buff/Border/buffborder_negative");
                    //Negative icon
                    break;
            }

            //Draw code

            //Grab icon and draw
        }

        public override bool ReApply(Player player, int time, int buffIndex)
        {
            if (IsStackable)
            {
                BuffStack += 1;

                EffectModifier += (StackModifier * BuffStack);

                time = BuffTime;

                return true;
            }

            return true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.buffTime[player.FindBuffIndex(Type)] == 0)
            {
                BuffStack = 0;

                EffectModifier = 0f;

                OnClear(player);
            }

            base.Update(player, ref buffIndex);
        }

        /// <summary>
        /// Makes things happen when this buff is cleared from the player.
        /// </summary>
        /// <param name="player"></param>
        public virtual void OnClear(Player player)
        {

        }
        /// <summary>
        /// Makes things happen when this buff is cleared from an NPC (useful for aftereffects)
        /// </summary>
        /// <param name="npc"></param>
        public virtual void OnClear(NPC npc)
        {

        }

        public enum BuffType
        {
            Buff,
            Debuff
        }
    }
}