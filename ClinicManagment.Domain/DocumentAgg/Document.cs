using _0_Framework.Domain;
using ClinicManagment.Domain.PatientFileAgg;

namespace ClinicManagment.Domain.DocumentAgg
{
    public class Document : EntityBase<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PatientFile> PatientFiles { get; set; }

        public Document()
        {
            PatientFiles = new List<PatientFile>();
        }
        public Document(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Edit(string name, string description)
        {
            Name = name;
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
