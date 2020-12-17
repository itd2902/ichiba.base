using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Core.Domain;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class PaymentTermModel : BaseIChibaEntityModel,
        ILocalizedModel<PaymentTermLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(255)
        public string Name { get; set; } // nvarchar(255)
        public string LocalName { get; set; } // nvarchar(255)
        public bool CurrentMonth { get; set; } // bit
        public PaymentFromDateType FromDateType { get; set; } // int
        public string FromDateTypeText { get; set; }
        public int? Days { get; set; } // int
        public string Description { get; set; } // nvarchar(max)
        public bool Active { get; set; } // bit
        public int DisplayOrder { get; set; } // int

        public IList<IChibaListItem> SelectFromDateTypes { get; set; }

        public IList<PaymentTermLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public PaymentTermModel()
        {
            Active = true;
            SelectFromDateTypes = new List<IChibaListItem>();
            Locales = new List<PaymentTermLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class PaymentTermLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class PaymentTermValidator : AbstractValidator<PaymentTermModel>
    {
        public PaymentTermValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.PaymentTerms.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.PaymentTerms.Fields.Code"), 50));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.PaymentTerms.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.PaymentTerms.Fields.Name"), 255));

            RuleFor(x => x.LocalName).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.LocalName"), 255));

            RuleFor(x => x.FromDateType).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.PaymentTerms.Fields.FromDateType")));
            RuleFor(x => x.FromDateType).IsInEnum()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.InValid"), localizationService.GetResource("Admin.PaymentTerms.Fields.FromDateType")));

            RuleFor(x => x.Days).GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.GreaterThanOrEqualTo"), localizationService.GetResource("Common.Fields.Days"), 0));

            RuleFor(x => x.Description).SetValidator(new MaximumLengthValidator(1000))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Description"), 1000));

            RuleFor(x => x.DisplayOrder).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.DisplayOrder")));
        }
    }
}
