using System.ComponentModel.DataAnnotations;

namespace College.Commons
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }

    public class BaseEntitySoftDeletable : BaseEntity
    {
        public bool IsDeleted { get; set; }
    }

    public class BaseMasterData : BaseEntitySoftDeletable
    {
        public string Name { get; set; }
    }
}
