using ClinicManagment.Application.contract.PatientFile;

namespace ClinicManagment.Application.contract.Patient
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public int Code { get; set; }
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
        public bool IsDeleted { get; set; }
        public List<PatientFileViewModel> PatientFiles { get; set; }
    }
}

