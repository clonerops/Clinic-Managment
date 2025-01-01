namespace ClinicManagment.Application.contract.Patient
{
    public class PatientReportSearchModel
    {
        public int? DocumentId { get; set; }
        public string FromDate { get; set; } = string.Empty;
        public string ToDate { get; set; } = string.Empty;
    }

    public class PatientReportBasedOfReferralCountSearchModel
    {
        public int? DocumentId { get; set; }
        public int? FromReferral { get; set; }
        public int? ToReferral { get; set; }
        public string FromDate { get; set; } = string.Empty;
        public string ToDate { get; set; } = string.Empty;

    }
}

