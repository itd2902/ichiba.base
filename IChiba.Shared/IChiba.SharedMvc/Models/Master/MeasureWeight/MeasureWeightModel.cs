using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class MeasureWeightModel : BaseIChibaEntityModel,
        ILocalizedModel<MeasureWeightLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(50)
        public string Name { get; set; } // nvarchar(255)
        public decimal Ratio { get; set; } // decimal(18, 8)
        public string Note { get; set; } // nvarchar(500)
        public bool Active { get; set; } // bit
        public int DisplayOrder { get; set; } // int

        public IList<MeasureWeightLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public MeasureWeightModel()
        {
            Active = true;
            DisplayOrder = 1;
            Locales = new List<MeasureWeightLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class MeasureWeightLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class MeasureWeightValidator : AbstractValidator<MeasureWeightModel>
    {
        public MeasureWeightValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.MeasureWeights.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.MeasureWeights.Fields.Name"), 50));

            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.MeasureWeights.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.MeasureWeights.Fields.Code"), 50));

            RuleFor(x => x.Ratio).GreaterThan(0)
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.GreaterThan"), localizationService.GetResource("Common.Fields.Ratio"), 0));

            RuleFor(x => x.Note).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Note"), 500));

            RuleFor(x => x.DisplayOrder).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.DisplayOrder")));
        }
    }
}
