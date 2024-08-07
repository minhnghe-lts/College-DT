using College.Commons;

namespace College.Core.Entities
{
    public class AdministrativeRegion : BaseEntity
    {
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string CodeName { get; set; }
        public string CodeNameEn { get; set; }
    }
}
