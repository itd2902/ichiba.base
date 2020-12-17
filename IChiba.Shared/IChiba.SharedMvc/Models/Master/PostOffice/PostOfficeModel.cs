using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class PostOfficeModel : BaseIChibaEntityModel,
        ILocalizedModel<PostOfficeLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(50)
        public string Name { get; set; } // nvarchar(255)
        public string LocalName { get; set; } // nvarchar(255)
        public string WarehouseId { get; set; } // varchar(50)
        public string Note { get; set; } // nvarchar(max)
        public bool Active { get; set; } // bit

        public WarehouseModel Warehouse { get; set; }

        public IList<PostOfficeLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public PostOfficeModel()
        {
            Active = true;
            Locales = new List<PostOfficeLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class PostOfficeLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class PostOfficeValidator : AbstractValidator<PostOfficeModel>
    {
        public PostOfficeValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Commodities.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Commodities.Fields.Code"), 50));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Commodities.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Commodities.Fields.Name"), 255));

            RuleFor(x => x.LocalName).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.LocalName"), 255));

            RuleFor(x => x.WarehouseId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Warehouse")));
        }
    }
}
