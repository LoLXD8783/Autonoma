namespace AEF.Core.Helpers
{
    public static class UIHelper 
    {


        public static int GetFreeInvSlot(Player Player)
        {
            for (int i = 0; i < 49; i++)
            {
                Item Item = Player.inventory[i];

                if (Item is null || Item.IsAir)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}