
using _0_Framework.Application;
using ClinicManagment.Application.contract.Patient;
using ClinicManagment.Domain.PatientAgg;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;

namespace ClinicManagment.Application
{
    public class PatientApplication : IPatientApplication
    {
        private static int _lastPatientCode = 1000; // مقدار اولیه شمارنده
        private readonly IPatientRepository _patientRepository;

        public PatientApplication(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public OperationResult<PatientViewModel> Create(CreatePatient command)
        {
            var operation = new OperationResult<PatientViewModel>();

            if (_patientRepository.Exist(x => x.NationalCode == command.NationalCode))
                return operation.Failed("اطلاعات کاربر قبلا در سامانه ذخیره شده است");

            int newPatientCode = Interlocked.Increment(ref _lastPatientCode);

            var patient = new Patient(newPatientCode, command.FirstName, command.LastName, command.NationalCode,
                command.Mobile, command.WhatsappNumber, command.HomeNumber, command.BirthDate,
                command.Job, command.Education, command.Reagent, command.Gender, command.MaritalStatus,
                command.Address, command.Description);

            _patientRepository.Create(patient);
            _patientRepository.SaveChanges();

            var patientViewModel = new PatientViewModel
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Code = patient.Code,
            };

            return operation.Succedded(patientViewModel);

        }

        public OperationResult<PatientViewModel> Edit(EditPatient command)
        {
            var operation = new OperationResult<PatientViewModel>();

            var patient = _patientRepository.Get(command.Id);

            if (patient == null)
                return operation.Failed("اطلاعات بیمار در سامانه یافت نشد.");

            patient.Edit(command.FirstName, command.LastName, command.NationalCode,
                command.Mobile, command.WhatsappNumber, command.HomeNumber, command.BirthDate,
                command.Job, command.Education, command.Reagent, command.Gender, command.MaritalStatus,
                command.Address, command.Description);

            _patientRepository.SaveChanges();


            var patientViewModel = new PatientViewModel
            {
                Id = patient.Id
            };

            return operation.Succedded(patientViewModel);
        }

        public PatientViewModel GetBy(int id)
        {
            return _patientRepository.GetBy(id);
        }

        public List<PatientViewModel> Lists()
        {
            return _patientRepository.List();
        }

        public OperationResult<PatientViewModel> Remove(int id)
        {
            var operation = new OperationResult<PatientViewModel>();
            var patient = _patientRepository.Get(id);
            if(patient == null)
                return operation.Failed("اطلاعات بیمار در سامانه یافت نشد.");

            patient.Removed();
            _patientRepository.SaveChanges();
            var patientViewModel = new PatientViewModel
            {
                Id = patient.Id
            };

            return operation.Succedded(patientViewModel);
        }

        public OperationResult<PatientViewModel> Restore(int id)
        {
            var operation = new OperationResult<PatientViewModel>();
            var patient = _patientRepository.Get(id);

            if (patient == null)
                return operation.Failed("اطلاعات بیمار در سامانه یافت نشد.");

            patient.Restore();
            _patientRepository.SaveChanges();
            var patientViewModel = new PatientViewModel
            {
                Id = patient.Id
            };

            return operation.Succedded(patientViewModel);
        }

        public List<PatientViewModel> Search(PatientSearchModel searchModel)
        {
            return _patientRepository.Search(searchModel);
        }

        public List<PatientViewModel> PatientReport(PatientReportSearchModel searchModel)
        {
            return _patientRepository.PatientReport(searchModel);
        }

        public List<PatientViewModel> PatientReportBasedOfReferralCount(PatientReportBasedOfReferralCountSearchModel searchModel)
        {
            return _patientRepository.PatientReportBasedOfReferralCount(searchModel);            
        }

        public OperationResult<byte[]> PatientExcelList(PatientSearchModel searchModel)
        {
            var operation = new OperationResult<byte[]>();
            var patients = _patientRepository.Search(searchModel);

            var columns = new List<string> { "FirstName", "LastName", "NationalCode", "Mobile" };

            var columnHeaders = new Dictionary<string, string> { 
                { "FirstName", "نام" }, 
                { "LastName", "نام خانوادگی" }, 
                { "NationalCode", "کد ملی" }, 
                { "Mobile", "موبایل" }, 
            };

            var excelFile = ExcelClosedXmlHelper.GenrateExcelClosedXml<PatientViewModel>(patients, "Patients", columns, columnHeaders);

            return operation.Succedded(excelFile);
        }

        public OperationResult<byte[]> PatientReportExcel(PatientReportSearchModel searchModel)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                var operation = new OperationResult<byte[]>();
                var columns = new List<string> { "FirstName", "LastName", "NationalCode", "Mobile" };

                var patients = _patientRepository.PatientReport(searchModel);

                var worksheet = package.Workbook.Worksheets.Add("Patients");


                var columnHeaders = new Dictionary<string, string> {
                    { "FirstName", "نام" },
                    { "LastName", "نام خانوادگی" },
                    { "NationalCode", "کد ملی" },
                    { "Mobile", "موبایل" },
                };

                for (var i = 0; i < columns.Count; i++) 
                { 
                    worksheet.Cells[1, i + 1].Value = columnHeaders[columns[i]]; 
                }

                for (int i = 0; i < patients.Count; i++) 
                { 
                    worksheet.Cells[i + 2, 1].Value = patients[i].FirstName; 
                    worksheet.Cells[i + 2, 2].Value = patients[i].LastName; 
                    worksheet.Cells[i + 2, 3].Value = patients[i].NationalCode; 
                    worksheet.Cells[i + 2, 4].Value = patients[i].Mobile; 
                }
                worksheet.Cells.AutoFitColumns(); 
                byte[] excelFile = package.GetAsByteArray();

                //    var excelFile = ExcelClosedXmlHelper.GenrateExcelClosedXml<PatientViewModel>(patients, "Patients", columns, columnHeaders);

                return operation.Succedded(excelFile);

            }


        }

        public OperationResult<byte[]> PatientReportBasedOfReferralCountExcel(PatientReportBasedOfReferralCountSearchModel searchModel)
        {
            var operation = new OperationResult<byte[]>();
            var patients = _patientRepository.PatientReportBasedOfReferralCount(searchModel);

            var columns = new List<string> { "FirstName", "LastName", "NationalCode", "Mobile" };

            var columnHeaders = new Dictionary<string, string> {
                { "FirstName", "نام" },
                { "LastName", "نام خانوادگی" },
                { "NationalCode", "کد ملی" },
                { "Mobile", "موبایل" },
            };

            var excelFile = ExcelClosedXmlHelper.GenrateExcelClosedXml<PatientViewModel>(patients, "Patients", columns, columnHeaders);

            return operation.Succedded(excelFile);

        }
    }
}
