namespace College.Commons
{
    public partial class CommonEnums
    {
        public enum EmployeeContractType
        {
            CollaboratorPartTime,
            CollaboratorFullTime,
            Probationary,
            FixedTerm,
            LongTerm
        }

        public enum EducationLevel
        {
            Basic,
            Intermediate,
            College,
            University
        }

        public enum InterviewResult
        {
            Waiting,
            Passed,
            Failed,
            Pending,
        }


        public enum BenefitType
        {
            Common,

        }

        public enum EmployeeType
        {
            Staff,
            Teacher,
            Mentor,
            Guard,
            Sanitation
        }

        public enum MasterPlanType
        {
            Education,
            Examination,
            Rest
        }
    }
}
