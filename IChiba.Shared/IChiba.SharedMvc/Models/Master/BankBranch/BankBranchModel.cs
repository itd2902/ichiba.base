using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class BankBranchModel : BaseIChibaEntityModel,
        ILocalizedModel<BankBranchLocalizedModel>
    {
        public string BankId { get; set; } // varchar(50)
        public string Name { get; set; } // nvarchar(255)
        public string SwiftCode { get; set; } // nvarchar(50)
        public string Address { get; set; } // nvarchar(1000)
        public string CountryId { get; set; } // varchar(50)
        public string StateProvinceId { get; set; } // varchar(50)
        public string DistrictId { get; set; } // varchar(50)
        public bool Active { get; set; } // bit

        public BankModel Bank { get; set; }
        public IList<BankModel> SelectBanks { get; set; }

        public CountryModel Country { get; set; }
        public IList<CountryModel> SelectCountries { get; set; }

        public DistrictModel District { get; set; }
        public IList<DistrictModel> SelectDistricts { get; set; }

        public StateProvinceModel StateProvince { get; set; }
        public IList<StateProvinceModel> SelectStateProvinces { get; set; }

        public IList<BankBranchLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public BankBranchModel()
        {
            Active = true;
            SelectBanks = new List<BankModel>();
            SelectCountries = new List<CountryModel>();
            SelectDistricts = new List<DistrictModel>();
            SelectStateProvinces = new List<StateProvinceModel>();
            Locales = new List<BankBranchLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class BankBranchLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class BankBranchValidator : AbstractValidator<BankBranchModel>
    {
        public BankBranchValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.BankBranches.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.BankBranches.Fields.Name"), 255));

            RuleFor(x => x.SwiftCode).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.SwiftCode"), 50));

            RuleFor(x => x.Address).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Address"), 500));

            RuleFor(x => x.BankId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Bank")));
        }
    }
}
