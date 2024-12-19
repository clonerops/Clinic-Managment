
using _0_Framework.Domain;
using ClinicManagment.Domain.PatientFileAgg;

namespace ClinicManagment.Domain.PatientAgg
{
    public class Patient: EntityBase<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Mobile { get; set; }
        public string WhatsappNumber { get; set; }
        public string HomeNumber { get; set; }
        public string BirthDate { get; set; }
        public string Job { get; set; }
        public string Education { get; set; }
        public string Reagent { get; set; }
        public bool Gender { get; set; }
        public bool MaritalStatus { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public List<PatientFile> PatientFiles { get; set; }

        public Patient()
        {
            PatientFiles: new List<PatientFile>();
        }

        public Patient(string firstName, string lastName, string nationalCode,
            string mobile, string whatsappNumber, string homeNumber,
            string birthDate, string job, string education,
            string reagent, bool gender, bool maritalStatus,
            string address, string description)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
            Mobile = mobile;
            WhatsappNumber = whatsappNumber;
            HomeNumber = homeNumber;
            BirthDate = birthDate;
            Job = job;
            Education = education;
            Reagent = reagent;
            Gender = gender;
            MaritalStatus = maritalStatus;
            Address = address;
            Description = description;
        }

        public void Edit(string firstName, string lastName, string nationalCode,
            string mobile, string whatsappNumber, string homeNumber,
            string birthDate, string job, string education,
            string reagent, bool gender, bool maritalStatus,
            string address, string description)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
            Mobile = mobile;
            WhatsappNumber = whatsappNumber;
            HomeNumber = homeNumber;
            BirthDate = birthDate;
            Job = job;
            Education = education;
            Reagent = reagent;
            Gender = gender;
            MaritalStatus = maritalStatus;
            Address = address;
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
