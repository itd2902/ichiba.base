using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Core.Domain;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class WarehouseModel : BaseIChibaEntityModel,
        ILocalizedModel<WarehouseLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(50)
        public string Name { get; set; } // nvarchar(255)
        public string LocalName { get; set; } // nvarchar(255)
        public WarehouseType Type { get; set; } // int
        public string TerminalCode { get; set; } // nvarchar(50)
        public bool IsInternal { get; set; } // bit
        public string CurrencyId { get; set; } // varchar(50)
        public string CurrencyCode { get; set; } // nvarchar(50)
        public string MeasureDimensionId { get; set; } // varchar(50)
        public string MeasureDimensionCode { get; set; } // nvarchar(50)
        public string MeasureWeightId { get; set; } // varchar(50)
        public string MeasureWeightCode { get; set; } // nvarchar(50)
        public string Note { get; set; } // nvarchar(max)
        public bool Active { get; set; } // bit

        public IList<WarehouseLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public WarehouseModel()
        {
            Active = true;
            Locales = new List<WarehouseLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class WarehouseLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class WarehouseValidator : AbstractValidator<WarehouseModel>
    {
        public WarehouseValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Warehouses.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Warehouses.Fields.Code"), 50));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Warehouses.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Warehouses.Fields.Name"), 255));

            RuleFor(x => x.LocalName).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.LocalName"), 255));

            RuleFor(x => x.Type).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.WarehouseType")));
            RuleFor(x => x.Type).IsInEnum()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.InValid"), localizationService.GetResource("Common.Fields.WarehouseType")));

            RuleFor(x => x.TerminalCode).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Warehouses.Fields.TerminalCode"), 50));

            RuleFor(x => x.CurrencyId).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.WarehouseType")));
            RuleFor(x => x.CurrencyId).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Currency"), 50));

            RuleFor(x => x.CurrencyCode).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.WarehouseType")));
            RuleFor(x => x.CurrencyCode).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Currencies.Fields.CurrencyCode"), 50));

            RuleFor(x => x.Type).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.WarehouseType")));
            RuleFor(x => x.MeasureDimensionId).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.MeasureDimension"), 50));

            RuleFor(x => x.Type).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.WarehouseType")));
            RuleFor(x => x.MeasureDimensionCode).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.MeasureDimensions.Fields.TerminalCode"), 50));

            RuleFor(x => x.Type).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.WarehouseType")));
            RuleFor(x => x.MeasureWeightId).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.MeasureWeight"), 50));

            RuleFor(x => x.Type).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.WarehouseType")));
            RuleFor(x => x.MeasureWeightCode).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Warehouses.MeasureWeights.TerminalCode"), 50));
        }
    }
}
