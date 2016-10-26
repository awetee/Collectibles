namespace Tee.Collectibles.Common.Entities
{
    public class Collectible : IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsShared { get; set; }
        public virtual CollectibleType Type { get; set; }
        public int TypeId { get; set; }
    }
}