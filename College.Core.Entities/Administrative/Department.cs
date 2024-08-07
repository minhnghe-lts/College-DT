using College.Commons;

namespace College.Core.Entities
{
    public class Department : BaseMasterData
    {
        public long? ParentId { get; set; }
        public virtual Department Parent { get; set; }
    }
}
