﻿namespace ClinicManagment.Application.contract.Patient
{
    public class PatientReportSearchModel
    {
        public int? Code { get; set; }
        public int? DocumentId { get; set; }
        public string FromDate { get; set; } = string.Empty;
        public string ToDate { get; set; } = string.Empty;
    }
    public class PatientExcelListSearchModel
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}

