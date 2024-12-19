using _0_Framework.Application;
using ClinicManagment.Application.contract;
using ClinicManagment.Domain.DoctorAgg;

namespace ClinicManagment.Application
{
    public class DoctorApplication : IDoctorApplication
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorApplication(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public OperationResult Create(CreateDoctor command)
        {
            var operation = new OperationResult();

            if (_doctorRepository.Exist(x => x.NationalCode == command.NationalCode))
                return operation.Failed("اطلاعات پزشک قبلا در سامانه ثبت شده است.");

            var doctor =  new Doctor(command.FirstName, command.LastName, 
                command.NationalCode, command.Description, command.Mobile);

            _doctorRepository.Create(doctor);
            _doctorRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Edit(EditDoctor command)
        {
            var operation = new OperationResult();

            var doctor = _doctorRepository.Get(command.Id);

            if (doctor == null)
                return operation.Failed("اطلاعات پزشک در سامانه یافت نشد");

            doctor.Edit(command.FirstName, command.LastName,
                command.NationalCode, command.Description, command.Mobile);

            _doctorRepository.SaveChanges();
            return operation.Succedded();

        }

        public DoctorViewModel GetBy(int id)
        {
            return _doctorRepository.GetBy(id);
        }

        public List<DoctorViewModel> List()
        {
            return _doctorRepository.List();
        }

        public OperationResult Remove(int id)
        {
            var operation = new OperationResult();

            var doctor = _doctorRepository.Get(id);

            if (doctor == null)
                return operation.Failed("اطلاعات پزشک در سامانه یافت نشد");

            doctor.Removed();
            _doctorRepository.SaveChanges();
            return operation.Succedded();

        }

        public OperationResult Restore(int id)
        {
            var operation = new OperationResult();

            var doctor = _doctorRepository.Get(id);

            if (doctor == null)
                return operation.Failed("اطلاعات پزشک در سامانه یافت نشد");

            doctor.Restore();
            _doctorRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<DoctorViewModel> Search(DoctorSearchModel searchModel)
        {
            return _doctorRepository.Search(searchModel);
        }
    }
}
