namespace ClinicManagment.Application.contract.Patient
{
    public class PatientReportBasedOfReferralCountSearchModel
    {
        public int? Code { get; set; }
        public int? DocumentId { get; set; }
        public int? FromReferral { get; set; }
        public int? ToReferral { get; set; }
        public string FromDate { get; set; } = string.Empty;
        public string ToDate { get; set; } = string.Empty;

    }
}

