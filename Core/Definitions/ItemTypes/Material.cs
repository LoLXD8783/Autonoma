namespace AEF.Core.Definitions.ItemTypes
{
    public abstract class Material : AEFItem
    {
        public MaterialType MatType { get; set; }

        public override void SetDefaults()
        {

            base.SetDefaults();
        }



        public enum MaterialType
        {
            Basic,
            Blueprint,
            Part,
            Rare
        }
    }
}