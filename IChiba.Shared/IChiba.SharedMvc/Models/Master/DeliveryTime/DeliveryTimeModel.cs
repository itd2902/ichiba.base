using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Core.Domain;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class DeliveryTimeModel : BaseIChibaEntityModel,
        ILocalizedModel<DeliveryTimeLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(50)
        public string Name { get; set; } // nvarchar(255)
        public decimal MinValue { get; set; } // decimal(18, 4)
        public decimal? MaxValue { get; set; } // decimal(18, 4)
        public DeliveryTimeUnit TimeUnit { get; set; } // int
        public string TimeUnitText { get; set; }
        public string Note { get; set; } // nvarchar(500)
        public bool Active { get; set; } // bit
        public int DisplayOrder { get; set; } // int

        public IList<IChibaListItem> SelectTimeUnits { get; set; }

        public IList<DeliveryTimeLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public DeliveryTimeModel()
        {
            Active = true;
            DisplayOrder = 1;
            SelectTimeUnits = new List<IChibaListItem>();
            Locales = new List<DeliveryTimeLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class DeliveryTimeLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class DeliveryTimeValidator : AbstractValidator<DeliveryTimeModel>
    {
        public DeliveryTimeValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.DeliveryTimes.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.DeliveryTimes.Fields.Code"), 50));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.DeliveryTimes.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.DeliveryTimes.Fields.Name"), 255));

            RuleFor(x => x.MinValue).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.DeliveryTimes.Fields.MinValue")));
            RuleFor(x => x.MinValue).GreaterThan(0)
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.GreaterThan"), localizationService.GetResource("Admin.DeliveryTimes.Fields.MinValue"), 0));
            
            RuleFor(x => x.MaxValue).GreaterThan(0)
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.GreaterThan"), localizationService.GetResource("Admin.DeliveryTimes.Fields.MaxValue"), 0));

            RuleFor(x => x.TimeUnit).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.DeliveryTimeUnit")));
            RuleFor(x => x.TimeUnit).IsInEnum()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.InValid"), localizationService.GetResource("Common.Fields.DeliveryTimeUnit")));

            RuleFor(x => x.Note).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Note"), 500));

            RuleFor(x => x.DisplayOrder).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.DisplayOrder")));
        }
    }
}
