namespace ClinicManagment.Application.contract.PatientFile
{
    public class CreatePatientFile
    {
        public int PatientId { get; set; }
        public int DocumentId { get; set; }
        public int DoctorId { get; set; }
        public string Description { get; set; }
    }

}
