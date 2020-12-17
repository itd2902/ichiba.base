using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class ChargesTypeModel : BaseIChibaEntityModel,
        ILocalizedModel<ChargesTypeLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(50)
        public string Name { get; set; } // nvarchar(255)
        public string LocalName { get; set; } // nvarchar(255)
        public string ChargesGroupId { get; set; } // varchar(50)
        public string MeasurementId { get; set; } // varchar(50)
        public string ContainerMeasurementId { get; set; } // varchar(50)
        public string VatTypeId { get; set; } // varchar(50)
        public string Description { get; set; } // nvarchar(max)
        public bool IsReceivable { get; set; } // bit
        public string ReceivableCurrencyId { get; set; } // varchar(50)
        public bool IsPayable { get; set; } // bit
        public string PayableCurrencyId { get; set; } // varchar(50)
        public bool IsCustoms { get; set; } // bit
        public bool IsExpense { get; set; } // bit
        public bool IsPickup { get; set; } // bit
        public bool IsDelivery { get; set; } // bit
        public bool Air { get; set; } // bit
        public bool Ocean { get; set; } // bit
        public bool Inland { get; set; } // bit
        public bool ForQuote { get; set; } // bit
        public bool ForShipment { get; set; } // bit
        public bool ForMaster { get; set; } // bit
        public bool ForCustoms { get; set; } // bit
        public bool ForExport { get; set; } // bit
        public bool ForImport { get; set; } // bit
        public bool ForDomestic { get; set; } // bit
        public bool ForDrop { get; set; } // bit
        public bool Active { get; set; } // bit
        public int DisplayOrder { get; set; } // int

        public ChargesGroupModel ChargesGroup { get; set; }
        public IList<ChargesGroupModel> SelectChargesGroups { get; set; }

        public SPMeasurementModel ContMeasurement { get; set; }
        public IList<SPMeasurementModel> SelectContMeasures { get; set; }

        public SPMeasurementModel Measurement { get; set; }
        public IList<SPMeasurementModel> SelectMeasures { get; set; }

        public CurrencyModel PayCurrency { get; set; }
        public IList<CurrencyModel> SelectPayCurrencies { get; set; }

        public CurrencyModel RecvCurrency { get; set; }
        public IList<CurrencyModel> SelectRecvCurrencies { get; set; }

        public VatTypeModel VatType { get; set; }
        public IList<VatTypeModel> SelectVatTypes { get; set; }

        public IList<ChargesTypeLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public ChargesTypeModel()
        {
            Active = true;
            DisplayOrder = 1;
            SelectChargesGroups = new List<ChargesGroupModel>();
            SelectContMeasures = new List<SPMeasurementModel>();
            SelectMeasures = new List<SPMeasurementModel>();
            SelectPayCurrencies = new List<CurrencyModel>();
            SelectRecvCurrencies = new List<CurrencyModel>();
            SelectVatTypes = new List<VatTypeModel>();
            Locales = new List<ChargesTypeLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class ChargesTypeLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class ChargesTypeValidator : AbstractValidator<ChargesTypeModel>
    {
        public ChargesTypeValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.ChargesTypes.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.ChargesTypes.Fields.Code"), 50));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.ChargesTypes.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.ChargesTypes.Fields.Name"), 255));

            RuleFor(x => x.LocalName).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.LocalName"), 255));

            RuleFor(x => x.MeasurementId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.SPMeasurement")));

            RuleFor(x => x.DisplayOrder).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.DisplayOrder")));
        }
    }
}
