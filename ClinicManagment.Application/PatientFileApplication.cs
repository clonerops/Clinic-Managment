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

            int initialNumber = 1001;

            var existingFiles = _patientFileRepository
                .List()
                .Where(x => x.DocumentId == command.DocumentId)
                .OrderByDescending(x => x.FileCode)
                .FirstOrDefault();

            int fileNumber = existingFiles != null ? (int)existingFiles.FileCode + 1 : initialNumber;

            var patientFile = new PatientFile(fileNumber, command.PatientId, command.DocumentId, command.DoctorId, command.Description);
            _patientFileRepository.Create(patientFile);
            _patientFileRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditPatientFile command)
        {
            var operation = new OperationResult();

            var patientFile = _patientFileRepository
                .ListPatientFile()
                .Where(x =>
                        (x.PatientId == command.PatientId) &&
                        (x.DocumentId == command.DocumentId) &&
                        (x.DoctorId == command.DoctorId))
                .FirstOrDefault();

            if(patientFile == null)
                return operation.Failed("پرونده ای برای ویرایش یافت نشد.");

            patientFile.Edit(command.PatientId, command.DocumentId, command.DoctorId, command.Description);
            _patientFileRepository.SaveChanges();

            return operation.Succedded();

        }

        public PatientFileViewModel GetBy(long id)
        {
            return _patientFileRepository.GetBy(id);
        }

        public List<PatientFileViewModel> List()
        {
            return _patientFileRepository.List();
        }

        public OperationResult Remove(int patientId, int documentId, int doctorId)
        {
            var operation = new OperationResult();

            var patientFile = _patientFileRepository
            .ListPatientFile()
                .Where(x =>
                        (x.PatientId == patientId) &&
                        (x.DocumentId == documentId) &&
                        (x.DoctorId == doctorId))
                .FirstOrDefault();

            if (patientFile == null)
                return operation.Failed("پرونده ای برای حذف یافت نشد.");

            patientFile.Removed();
            _patientFileRepository .SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(int patientId, int documentId, int doctorId)
        {
            var operation = new OperationResult();

            var patientFile = _patientFileRepository
            .ListPatientFile()
                .Where(x =>
                        (x.PatientId == patientId) &&
                        (x.DocumentId == documentId) &&
                        (x.DoctorId == doctorId))
                .FirstOrDefault();

            if (patientFile == null)
                return operation.Failed("پرونده ای برای حذف یافت نشد.");

            patientFile.Restore();
            _patientFileRepository.SaveChanges();

            return operation.Succedded();
        }

        public List<PatientFileViewModel> Search(PatientFileSearchModel searchModel)
        {
            return _patientFileRepository.Search(searchModel);
        }
    }
}
