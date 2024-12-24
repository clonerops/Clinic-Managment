using ClinicManagment.Application.contract.PatientFile;

namespace ClinicManagment.Application.contract.Referral
{
    public class ReferralViewModel
    {
        public long Id { get; set; }
        public string ReferralDate { get; set; }
        public string ReferralReason { get; set; }
        public string ReferralDescription { get; set; }
        public PatientFileViewModel PatientFile { get; set; }
    }
}
