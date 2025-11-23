
using ClinicManagment.Application.contract.Referral;

namespace ClinicManagment.Application.contract.PatientFile
{
    public class PatientFileViewModel
    {
        public long Id { get; set; }
        public long FileCode { get; set; }
        public int PatientId { get; set; }
        public string Mobile { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatientName { get; set; }
        public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime CreationDateGr { get; set; }
        public string CreationDate { get; set; }
        public List<ReferralViewModel> Referrals { get; set; }
    }

}
    