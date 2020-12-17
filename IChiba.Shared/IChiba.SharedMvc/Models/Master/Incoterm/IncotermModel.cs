using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Core.Domain;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class IncotermModel : BaseIChibaEntityModel,
        ILocalizedModel<IncotermLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(255)
        public string Name { get; set; } // nvarchar(255)
        public string LocalName { get; set; } // nvarchar(255)
        public IncotermPaymentMethod FreightPaymentMethod { get; set; } // int
        /// <summary>
        /// FreightPaymentMethod Text
        /// </summary>
        public string FreightPMText { get; set; }
        public IncotermPaymentMethod OtherChargesPaymentMethod { get; set; } // int
        /// <summary>
        /// OtherChargesPaymentMethod Text
        /// </summary>
        public string OtherChargesPMText { get; set; }
        public string Note { get; set; } // nvarchar(max)
        public bool Active { get; set; } // bit

        /// <summary>
        /// SelectFreightPaymentMethods
        /// </summary>
        public IList<IChibaListItem> SelectFreightPMs { get; set; }

        /// <summary>
        /// SelectOtherChargesPaymentMethods
        /// </summary>
        public IList<IChibaListItem> SelectOtherChargesPMs { get; set; }

        public IList<IncotermLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public IncotermModel()
        {
            Active = true;
            SelectFreightPMs = new List<IChibaListItem>();
            SelectOtherChargesPMs = new List<IChibaListItem>();
            Locales = new List<IncotermLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class IncotermLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class IncotermValidator : AbstractValidator<IncotermModel>
    {
        public IncotermValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Incoterms.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Incoterms.Fields.Code"), 50));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Incoterms.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Incoterms.Fields.Name"), 255));

            RuleFor(x => x.LocalName).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.LocalName"), 255));

            RuleFor(x => x.FreightPaymentMethod).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Incoterms.Fields.FreightPaymentMethod")));
            RuleFor(x => x.FreightPaymentMethod).IsInEnum()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.InValid"), localizationService.GetResource("Admin.Incoterms.Fields.FreightPaymentMethod")));

            RuleFor(x => x.OtherChargesPaymentMethod).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Incoterms.Fields.OtherChargesPaymentMethod")));
            RuleFor(x => x.OtherChargesPaymentMethod).IsInEnum()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.InValid"), localizationService.GetResource("Admin.Incoterms.Fields.OtherChargesPaymentMethod")));

            RuleFor(x => x.Note).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Note"), 500));
        }
    }
}
