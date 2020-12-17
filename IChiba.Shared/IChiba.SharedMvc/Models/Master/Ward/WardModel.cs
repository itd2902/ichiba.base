using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class WardModel : BaseIChibaEntityModel,
        ILocalizedModel<WardLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(50)
        public string Name { get; set; } // nvarchar(255)
        public string ShortName { get; set; } // nvarchar(100)
        public string CountryId { get; set; } // varchar(50)
        public string StateProvinceId { get; set; } // varchar(50)
        public string DistrictId { get; set; } // varchar(50)
        public string Note { get; set; } // nvarchar(500)
        public bool Active { get; set; } // bit

        public CountryModel Country { get; set; }
        public IList<CountryModel> SelectCountries { get; set; }

        public DistrictModel District { get; set; }
        public IList<DistrictModel> SelectDistricts { get; set; }

        public StateProvinceModel StateProvince { get; set; }
        public IList<StateProvinceModel> SelectStateProvinces { get; set; }

        public IList<WardLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public WardModel()
        {
            Active = true;
            SelectCountries = new List<CountryModel>();
            SelectDistricts = new List<DistrictModel>();
            SelectStateProvinces = new List<StateProvinceModel>();
            Locales = new List<WardLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class WardLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class WardValidator : AbstractValidator<WardModel>
    {
        public WardValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Countries.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Countries.Fields.Code"), 50));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Countries.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Countries.Fields.Name"), 255));

            RuleFor(x => x.ShortName).SetValidator(new MaximumLengthValidator(100))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.ShortName"), 100));

            RuleFor(x => x.Note).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Note"), 500));

            RuleFor(x => x.CountryId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Country")));

            RuleFor(x => x.StateProvinceId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.StateProvince")));

            RuleFor(x => x.DistrictId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.District")));
        }
    }
}
