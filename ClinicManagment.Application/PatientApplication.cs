
using _0_Framework.Application;
using ClinicManagment.Application.contract.Patient;
using ClinicManagment.Domain.PatientAgg;

namespace ClinicManagment.Application
{
    public class PatientApplication : IPatientApplication
    {
        private readonly IPatientRepository _patientRepository;

        public PatientApplication(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public OperationResult Create(CreatePatient command)
        {
            var operation = new OperationResult();

            if (_patientRepository.Exist(x => x.NationalCode == command.NationalCode))
                return operation.Failed("اطلاعات کاربر قبلا در سامانه ذخیره شده است");

            var patient = new Patient(command.FirstName, command.LastName, command.NationalCode,
                command.Mobile, command.WhatsappNumber, command.HomeNumber, command.BirthDate,
                command.Job, command.Education, command.Reagent, command.Gender, command.MaritalStatus,
                command.Address, command.Description);

            _patientRepository.Create(patient);
            _patientRepository.SaveChanges();
            return operation.Succedded();

        }

        public OperationResult Edit(EditPatient command)
        {
            var operation = new OperationResult();

            var patient = _patientRepository.Get(command.Id);

            if (patient == null)
                return operation.Failed("اطلاعات بیمار در سامانه یافت نشد.");

            patient.Edit(command.FirstName, command.LastName, command.NationalCode,
                command.Mobile, command.WhatsappNumber, command.HomeNumber, command.BirthDate,
                command.Job, command.Education, command.Reagent, command.Gender, command.MaritalStatus,
                command.Address, command.Description);

            _patientRepository.SaveChanges();
            return operation.Succedded();
        }

        public PatientViewModel GetBy(int id)
        {
            return _patientRepository.GetBy(id);
        }

        public List<PatientViewModel> Lists()
        {
            return _patientRepository.List();
        }

        public OperationResult Remove(int id)
        {
            var operation = new OperationResult();
            var patient = _patientRepository.Get(id);
            if(patient == null)
                return operation.Failed("اطلاعات بیمار در سامانه یافت نشد.");

            patient.Removed();
            _patientRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(int id)
        {
            var operation = new OperationResult();
            var patient = _patientRepository.Get(id);

            if (patient == null)
                return operation.Failed("اطلاعات بیمار در سامانه یافت نشد.");

            patient.Restore();
            _patientRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<PatientViewModel> Search(PatientSearchModel searchModel)
        {
            return _patientRepository.Search(searchModel);
        }
    }
}
