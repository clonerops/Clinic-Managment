namespace ClinicManagment.Application.contract.Referral
{
    public class ReferralSearchModel
    {
        public int PatientId { get; set; }
        public int DocumentId { get; set; }
        public int DoctorId { get; set; }
        public string FromDate { get; set; } = string.Empty;
        public string ToDate { get; set; } = string.Empty;
    }
}
