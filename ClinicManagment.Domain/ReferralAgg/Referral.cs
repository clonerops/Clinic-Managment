using _0_Framework.Domain;
using ClinicManagment.Domain.PatientFileAgg;

namespace ClinicManagment.Domain.ReferralAgg
{
    public class Referral : EntityBase<long>
    {
        public string ReferralDate { get; set; }
        public string ReferralReason { get; set; }
        public string ReferralDescription { get; set; }
        public long PatientFileId { get; set; }
        public PatientFile PatientFile { get; set; }

        public Referral(string referralDate, string referralReason, 
            string referralDescription, long patientFileId)
        {
            ReferralDate = referralDate;
            ReferralReason = referralReason;
            ReferralDescription = referralDescription;
            PatientFileId = patientFileId;
        }

        public void Edit(string referralDate, string referralReason,
            string referralDescription, long patientFileId)
        {
            ReferralDate = referralDate;
            ReferralReason = referralReason;
            ReferralDescription = referralDescription;
            PatientFileId = patientFileId;
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
