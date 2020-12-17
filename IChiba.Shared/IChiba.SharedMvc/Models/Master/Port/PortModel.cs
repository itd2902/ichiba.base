using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class PortModel : BaseIChibaEntityModel,
        ILocalizedModel<PortLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(50)
        public string Name { get; set; } // nvarchar(255)
        public string ShortName { get; set; } // nvarchar(100)
        public string LocalName { get; set; } // nvarchar(255)
        public string Note { get; set; } // nvarchar(500)
        public bool Active { get; set; } // bit
        public int DisplayOrder { get; set; } // int
        public string CountryId { get; set; } // varchar(50)
        public string StateProvinceId { get; set; } // varchar(50)
        public bool Air { get; set; } // bit
        public bool Ocean { get; set; } // bit
        public bool Inland { get; set; } // bit

        public CountryModel Country { get; set; }
        public IList<CountryModel> SelectCountries { get; set; }

        public StateProvinceModel StateProvince { get; set; }
        public IList<StateProvinceModel> SelectStateProvinces { get; set; }

        public IList<PortLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public PortModel()
        {
            Active = true;
            DisplayOrder = 1;
            Air = false;
            Ocean = false;
            Inland = false;
            SelectCountries = new List<CountryModel>();
            SelectStateProvinces = new List<StateProvinceModel>();
            Locales = new List<PortLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class PortLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class PortValidator : AbstractValidator<PortModel>
    {
        public PortValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Ports.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Ports.Fields.Code"), 50));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Ports.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Ports.Fields.Name"), 255));

            RuleFor(x => x.ShortName).SetValidator(new MaximumLengthValidator(100))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.ShortName"), 100));

            RuleFor(x => x.LocalName).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.LocalName"), 255));

            RuleFor(x => x.Note).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Note"), 500));

            RuleFor(x => x.DisplayOrder).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.DisplayOrder")));
        }
    }
}
