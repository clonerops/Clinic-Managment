using _0_Framework.Application;
using ClinicManagment.Application.contract.PatientFile;
using ClinicManagment.Domain.PatientFileAgg;

namespace ClinicManagment.Application
{
    public class PatientFileApplication : IPatientFileApplication
    {
        private readonly IPatientFileRepository _patientFileRepository;

        public PatientFileApplication(IPatientFileRepository patientFileRepository)
        {
            _patientFileRepository = patientFileRepository;
        }

        public OperationResult Create(CreatePatientFile command)
        {
            var operation = new OperationResult();

            if (_patientFileRepository.Exist(x =>
                                             (x.PatientId == command.PatientId) &&
                                             (x.DocumentId == command.DocumentId) &&
                                             (x.DoctorId == command.DoctorId)))
                return operation.Failed("پرونده برای بیمار با پزشک مشخص شده قبلا ایجاد شده است.");

            var patientFile = new PatientFile(11, command.PatientId, command.DocumentId, command.DoctorId,command.Description);
            _patientFileRepository.Create(patientFile);
            _patientFileRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditPatientFile command)
        {
            throw new NotImplementedException();
        }

        public PatientFileViewModel GetBy(long id)
        {
            return _patientFileRepository.GetBy(id);
        }

        public List<PatientFileViewModel> List()
        {
            return _patientFileRepository.List();
        }

        public OperationResult Remove(long id)
        {
            throw new NotImplementedException();
        }

        public OperationResult Restore(long id)
        {
            throw new NotImplementedException();
        }

        public List<PatientFileViewModel> Search(PatientFileSearchModel searchModel)
        {
            return _patientFileRepository.Search(searchModel);
        }
    }
}
