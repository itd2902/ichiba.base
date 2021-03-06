﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class PaymentMethodModel : BaseIChibaEntityModel,
        ILocalizedModel<PaymentMethodLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(50)
        public string Name { get; set; } // nvarchar(255)
        public bool EnabledARPay { get; set; } // bit
        public bool EnabledAPPay { get; set; } // bit
        public string Note { get; set; } // nvarchar(500)
        public bool Active { get; set; } // bit
        public int DisplayOrder { get; set; } // int

        public IList<PaymentMethodLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public PaymentMethodModel()
        {
            Active = true;
            DisplayOrder = 1;
            Locales = new List<PaymentMethodLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class PaymentMethodLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class PaymentMethodValidator : AbstractValidator<PaymentMethodModel>
    {
        public PaymentMethodValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.PaymentMethods.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.PaymentMethods.Fields.Code"), 50));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.PaymentMethods.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.PaymentMethods.Fields.Name"), 255));

            RuleFor(x => x.Note).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Note"), 500));

            RuleFor(x => x.DisplayOrder).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.DisplayOrder")));
        }
    }
}
