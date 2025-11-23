namespace ClinicManagment.Application.contract.PatientFile
{
    public class PatientFileSearchModel
    {
        public long FileCode { get; set; }
        public string Mobile { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }

}
