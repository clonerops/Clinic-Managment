namespace ClinicManagment.Application.contract
{
    public class DoctorSearchModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NationalCode { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
    }
}
