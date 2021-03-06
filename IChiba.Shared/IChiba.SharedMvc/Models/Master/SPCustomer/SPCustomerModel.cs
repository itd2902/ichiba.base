﻿using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class SPCustomerModel : BaseIChibaEntityModel,
        ILocalizedModel<SPCustomerLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(50)
        public string Name { get; set; } // nvarchar(255)
        public string LocalName { get; set; } // nvarchar(255)
        public string VatNumber { get; set; } // nvarchar(50)
        public string PaymentTermId { get; set; } // varchar(50)
        public int? StorageFreeDays { get; set; } // int
        public string Website { get; set; } // nvarchar(500)
        public bool Active { get; set; } // bit

        public PaymentTermModel PaymentTerm { get; set; }
        public IList<PaymentTermModel> SelectPaymentTerms { get; set; }

        public IList<SPAddressModel> Addresses { get; set; }

        public IList<SPCustomerLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public SPCustomerModel()
        {
            Active = true;
            SelectPaymentTerms = new List<PaymentTermModel>();
            Addresses = new List<SPAddressModel>();
            Locales = new List<SPCustomerLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class SPCustomerLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class SPCustomerValidator : AbstractValidator<SPCustomerModel>
    {
        public SPCustomerValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.SPCustomers.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.SPCustomers.Fields.Code"), 50));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.SPCustomers.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.SPCustomers.Fields.Name"), 255));

            RuleFor(x => x.LocalName).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.LocalName"), 255));

            RuleFor(x => x.VatNumber).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.VatNumber"), 50));

            RuleFor(x => x.StorageFreeDays).GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.GreaterThanOrEqualTo"), localizationService.GetResource("Common.Fields.StorageFreeDays"), 0));

            RuleFor(x => x.Website).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Website"), 500));
        }
    }
}
