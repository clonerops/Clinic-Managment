using _0_Framework.Domain;
using ClinicManagment.Domain.DoctorAgg;
using ClinicManagment.Domain.DocumentAgg;
using ClinicManagment.Domain.PatientAgg;
using ClinicManagment.Domain.ReferralAgg;

namespace ClinicManagment.Domain.PatientFileAgg
{
    public class PatientFile : EntityBase<long>
    {
        public long FileCode { get; set; }
        public int PatientId { get; set; }
        public int DocumentId { get; set; }
        public int DoctorId { get; set; }
        public string Description { get; set; }

        public Patient Patient { get; set; }
        public Document Document { get; set; }
        public Doctor Doctor { get; set; }
        public List<Referral> Referrals { get; set; }

        public PatientFile ()
        {
            Referrals = new List<Referral>();
        }

        public PatientFile(long fileCode, int patientId, int documentId, int doctorId, string description)
        {
            FileCode = fileCode;
            PatientId = patientId;
            DocumentId = documentId;
            DoctorId = doctorId;
            Description = description;
        }

        public void Edit(int patientId, int documentId, int doctorId, string description)
        {
            PatientId = patientId;
            DocumentId = documentId;
            DoctorId = doctorId;
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
