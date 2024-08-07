using College.Commons;
using static College.Commons.CommonEnums;

namespace College.Core.Entities
{
    public class BasePersonalProfile : BaseEntitySoftDeletable
    {
        #region Personal Info
        public string FullName { get; set; }
        public string DoB { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        #endregion

        #region Address
        public string ProvinceCode { get; set; }
        public virtual Province Province { get; set; }
        public string DistrictCode { get; set; }
        public virtual District District { get; set; }
        public string WardCode { get; set; }
        public virtual Ward Ward { get; set; }
        public string Address { get; set; }
        #endregion

        #region Education Process
        public EducationLevel EducationLevel { get; set; }
        #endregion
    }
}
