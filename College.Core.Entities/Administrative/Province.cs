using System.ComponentModel.DataAnnotations;

namespace College.Core.Entities
{
    public class Province
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string FullName { get; set; }
        public string FullNameEn { get; set; }
        public string CodeName { get; set; }
        public string AdministrativeUnitId { get; set; }
        public virtual AdministrativeUnit AdministrativeUnit { get; set; }
        public string AdministrativeRegionId { get; set; }
        public virtual AdministrativeRegion AdministrativeRegion { get; set; }
    }
}
