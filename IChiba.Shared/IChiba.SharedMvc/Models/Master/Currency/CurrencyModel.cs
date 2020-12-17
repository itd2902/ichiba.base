using System;
using System.Collections.Generic;
using System.Globalization;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Core.Domain;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class CurrencyModel : BaseIChibaEntityModel,
        ILocalizedModel<CurrencyLocalizedModel>
    {
        public string Name { get; set; } // nvarchar(50)
        public string CurrencyCode { get; set; } // nvarchar(5)
        public decimal Rate { get; set; } // decimal(18, 8)
        public string DisplayLocale { get; set; } // nvarchar(50)
        public string CustomFormatting { get; set; } // nvarchar(50)
        public bool Published { get; set; } // bit
        public int DisplayOrder { get; set; } // int
        public DateTime CreatedOnUtc { get; set; } // datetime
        public DateTime UpdatedOnUtc { get; set; } // datetime

        public IList<IChibaListItem> SelectDisplayLocales { get; set; }

        public IList<CurrencyLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public CurrencyModel()
        {
            Published = true;
            SelectDisplayLocales = new List<IChibaListItem>();
            Locales = new List<CurrencyLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class CurrencyLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class CurrencyValidator : AbstractValidator<CurrencyModel>
    {
        public CurrencyValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Currencies.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Currencies.Fields.Name"), 50));

            RuleFor(x => x.CurrencyCode).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Currencies.Fields.CurrencyCode")));
            RuleFor(x => x.CurrencyCode).SetValidator(new MaximumLengthValidator(5))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Currencies.Fields.CurrencyCode"), 5));

            RuleFor(x => x.Rate).GreaterThan(0)
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.GreaterThan"), localizationService.GetResource("Admin.Currencies.Fields.Rate"), 0));

            RuleFor(x => x.DisplayLocale)
                .Must(x =>
                {
                    try
                    {
                        if (String.IsNullOrEmpty(x))
                            return true;
                        var culture = new CultureInfo(x);
                        return culture != null;
                    }
                    catch
                    {
                        return false;
                    }
                })
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.InValid"), localizationService.GetResource("Admin.Currencies.Fields.DisplayLocale")));

            RuleFor(x => x.CustomFormatting).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Currencies.Fields.CustomFormatting"), 50));

            RuleFor(x => x.DisplayOrder).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.DisplayOrder")));
        }
    }
}
