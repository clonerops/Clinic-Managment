namespace ClinicManagment.Application.contract.Referral
{
    public class CreateReferral
    {
        public string ReferralDate { get; set; }
        public string ReferralReason { get; set; }
        public string ReferralDescription { get; set; }
        public long PatientFileId { get; set; }
    }
}
