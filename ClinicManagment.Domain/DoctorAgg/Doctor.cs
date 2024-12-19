using _0_Framework.Domain;
using ClinicManagment.Domain.PatientFileAgg;

namespace ClinicManagment.Domain.DoctorAgg
{
    public class Doctor : EntityBase<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
        public string Description { get; set; }
        public List<PatientFile> PatientFiles { get; set; }

        public Doctor()
        {
            PatientFiles = new List<PatientFile>();
        }

        public Doctor(string firstName, string lastName, string nationalCode, 
            string mobile, string description)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
            Mobile = mobile;
            Description = description;
        }


        public void Edit(string firstName, string lastName, string nationalCode,
            string mobile, string description)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
            Mobile = mobile;
            Description = description;
        }

        public void Removed()
        {
            IsDeleted = true;
        }

        public void Restore()
        {
            IsDeleted = false;
        }
    }

    
}
