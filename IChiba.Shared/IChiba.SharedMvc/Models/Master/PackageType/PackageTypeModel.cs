using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class PackageTypeModel : BaseIChibaEntityModel,
        ILocalizedModel<PackageTypeLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(50)
        public string Name { get; set; } // nvarchar(255)
        public string LocalName { get; set; } // nvarchar(255)
        public decimal? TEU { get; set; } // decimal(18, 4)
        public int? ContainerSize { get; set; } // int
        public decimal? Volume { get; set; } // decimal(18, 4)
        public string PrintAs { get; set; } // nvarchar(20)
        public bool IsContainer { get; set; } // bit
        public bool Refrigerated { get; set; } // bit
        public bool Vehicle { get; set; } // bit
        public bool Air { get; set; } // bit
        public bool Ocean { get; set; } // bit
        public bool Inland { get; set; } // bit
        public string Note { get; set; } // nvarchar(500)
        public bool Active { get; set; } // bit

        public IList<PackageTypeLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public PackageTypeModel()
        {
            Active = true;
            Locales = new List<PackageTypeLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class PackageTypeLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class PackageTypeValidator : AbstractValidator<PackageTypeModel>
    {
        public PackageTypeValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.PackageTypes.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.PackageTypes.Fields.Code"), 50));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.PackageTypes.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.PackageTypes.Fields.Name"), 255));

            RuleFor(x => x.LocalName).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.LocalName"), 255));

            RuleFor(x => x.PrintAs).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.PrintAs")));
            RuleFor(x => x.PrintAs).SetValidator(new MaximumLengthValidator(20))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.PrintAs"), 20));

            RuleFor(x => x.Note).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Note"), 500));
        }
    }
}
