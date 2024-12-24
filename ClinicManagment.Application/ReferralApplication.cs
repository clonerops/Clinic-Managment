using _0_Framework.Application;
using ClinicManagment.Application.contract.Referral;
using ClinicManagment.Domain.ReferralAgg;

namespace ClinicManagment.Application
{
    public class ReferralApplication : IReferralApplication
    {
        private readonly IReferralRepository _referralRepository;

        public ReferralApplication(IReferralRepository referralRepository)
        {
            _referralRepository = referralRepository;
        }

        public OperationResult Create(CreateReferral command)
        {
            var operation = new OperationResult();

            var referral = new Referral(command.ReferralDate, command.ReferralReason,
                command.ReferralDescription, command.PatientFileId);

            _referralRepository.Create(referral);
            _referralRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditReferral command)
        {
            var operation = new OperationResult();

            var referral = _referralRepository.Get(command.Id);

            if(referral == null)
                return operation.Failed("مراجعه ای جهت ویرایش یافت نشد");

            referral.Edit(command.ReferralDate, command.ReferralReason, 
                command.ReferralDescription, command.PatientFileId);

            _referralRepository.SaveChanges();

            return operation.Succedded();

        }

        public List<ReferralViewModel> List()
        {
            return _referralRepository.List();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            var referral = _referralRepository.Get(id);

            if (referral == null)
                return operation.Failed("مراجعه ای جهت حذف یافت نشد");

            referral.Removed();
            _referralRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();

            var referral = _referralRepository.Get(id);

            if (referral == null)
                return operation.Failed("مراجعه ای جهت برگرداندن یافت نشد");

            referral.Restore();
            _referralRepository.SaveChanges();

            return operation.Succedded();
        }
    }
}
