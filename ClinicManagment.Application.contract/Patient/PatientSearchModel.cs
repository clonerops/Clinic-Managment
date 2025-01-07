namespace ClinicManagment.Application.contract.Patient
{
    public class PatientSearchModel
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NationalCode { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;

    }
}

