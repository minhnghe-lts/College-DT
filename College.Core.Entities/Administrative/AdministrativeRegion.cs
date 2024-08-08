using College.Commons;
using System.ComponentModel.DataAnnotations;

namespace College.Core.Entities
{
    public class AdministrativeRegion : BaseEntity
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string CodeName { get; set; }
        public string CodeNameEn { get; set; }
    }
}
