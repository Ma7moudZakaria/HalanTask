namespace Halan.Domain.Shared
{
    public class EntityTrackerBase : BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
