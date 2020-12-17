using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class SPMoveTypeModel : BaseIChibaEntityModel,
        ILocalizedModel<SPMoveTypeLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(50)
        public string Name { get; set; } // nvarchar(255)
        public string LocalName { get; set; } // nvarchar(255)
        public bool Air { get; set; } // bit
        public bool Ocean { get; set; } // bit
        public bool Inland { get; set; } // bit
        public bool Active { get; set; } // bit

        public IList<SPMoveTypeLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public SPMoveTypeModel()
        {
            Active = true;
            Locales = new List<SPMoveTypeLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class SPMoveTypeLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class SPMoveTypeValidator : AbstractValidator<SPMoveTypeModel>
    {
        public SPMoveTypeValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.SPMoveTypes.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.SPMoveTypes.Fields.Code"), 50));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.SPMoveTypes.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.SPMoveTypes.Fields.Name"), 255));

            RuleFor(x => x.LocalName).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.LocalName"), 255));
        }
    }
}
