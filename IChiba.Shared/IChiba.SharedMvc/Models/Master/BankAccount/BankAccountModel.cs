using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class BankAccountModel : BaseIChibaEntityModel
    {
        public string AccountMasterId { get; set; } // varchar(50)
        public string BankId { get; set; } // varchar(50)
        public string BankBranchId { get; set; } // varchar(50)
        public string AccountNumber { get; set; } // nvarchar(50)
        public string CurrencyId { get; set; } // varchar(50)
        public string Name { get; set; } // nvarchar(255)
        public string LocalName { get; set; } // nvarchar(255)
        public string IBAN { get; set; } // nvarchar(50)
        public string VatNumber { get; set; } // nvarchar(50)
        public string Note { get; set; } // nvarchar(500)
        public bool Active { get; set; } // bit

        public BankModel Bank { get; set; }
        public IList<BankModel> SelectBanks { get; set; }

        public BankBranchModel BankBranch { get; set; }
        public IList<BankBranchModel> SelectBankBranches { get; set; }

        public CurrencyModel Currency { get; set; }
        public IList<CurrencyModel> SelectCurrencies { get; set; }

        public BankAccountModel()
        {
            Active = true;
            SelectBanks = new List<BankModel>();
            SelectBankBranches = new List<BankBranchModel>();
            SelectCurrencies = new List<CurrencyModel>();
        }
    }

    public partial class BankAccountValidator : AbstractValidator<BankAccountModel>
    {
        public BankAccountValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.AccountNumber).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.AccountNumber")));
            RuleFor(x => x.AccountNumber).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.AccountNumber"), 50));

            RuleFor(x => x.BankId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Bank")));

            RuleFor(x => x.Note).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Note"), 500));
        }
    }
}
