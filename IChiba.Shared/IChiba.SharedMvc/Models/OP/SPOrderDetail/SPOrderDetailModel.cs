using System;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Core.Domain;
using IChiba.Services.Localization;
using IChiba.SharedMvc.Models.Master;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.OP
{
    public partial class SPOrderDetailModel : BaseIChibaEntityModel
    {
        public string OrderId { get; set; } // varchar(50)
        public string CommodityId { get; set; } // varchar(50)
        public string CommodityCode { get; set; } // nvarchar(50)
        public DeclaredCargoClass DeclaredCargoClass { get; set; } // int
        public string DeclaredCargoClassText { get; set; } // nvarchar(255)
        public string HSCode { get; set; } // varchar(100)
        public string SKU { get; set; } // varchar(100)
        public string CountryOfOriginId { get; set; } // varchar(50)
        public string CountryOfOriginCode { get; set; } // nvarchar(50)
        public decimal TotalGrossWeight { get; set; } // decimal(18, 4)
        public string MeasureWeightId { get; set; } // varchar(50)
        public string MeasureWeightCode { get; set; } // nvarchar(50)
        public decimal Quantity { get; set; } // decimal(18, 4)
        public decimal Price { get; set; } // decimal(18, 4)
        public decimal TotalAmount { get; set; } // decimal(18, 4)
        public decimal DeclaredCustomsValue { get; set; } // decimal(18, 4)
        public decimal TotalDeclaredCustomsValue { get; set; } // decimal(18, 4)
        public string CurrencyId { get; set; } // varchar(50)
        public string CurrencyCode { get; set; } // nvarchar(50)
        public string Note { get; set; } // nvarchar(500)
        public string CreatedBy { get; set; } // varchar(50)
        public string CreatedByUserName { get; set; } // nvarchar(255)
        public DateTime CreatedOnUtc { get; set; } // datetime
        public string UpdatedBy { get; set; } // varchar(50)
        public string UpdatedByUserName { get; set; } // nvarchar(255)
        public DateTime? UpdatedOnUtc { get; set; } // datetime
        public bool Deleted { get; set; } // bit
        public string DeletedBy { get; set; } // varchar(50)
        public string DeletedByUserName { get; set; } // nvarchar(255)
        public DateTime? DeletedOnUtc { get; set; } // datetime

        public SPOrderModel Order { get; set; }

        public CommodityModel Commodity { get; set; }

        public CountryModel CountryOfOrigin { get; set; }

        public MeasureWeightModel MeasureWeight { get; set; }

        public CurrencyModel Currency { get; set; }

        public SPOrderDetailModel()
        {

        }
    }

    public partial class SPOrderDetailValidator : AbstractValidator<SPOrderDetailModel>
    {
        public SPOrderDetailValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.OrderId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.SPOrderDetails.Fields.SPOrder")));

            RuleFor(x => x.CommodityId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.SPOrderDetails.Fields.Commodity")));

            RuleFor(x => x.DeclaredCargoClass).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.SPOrderDetails.Fields.DeclaredCargoClass")));
            RuleFor(x => x.DeclaredCargoClass).IsInEnum()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.InValid"), localizationService.GetResource("Admin.SPOrderDetails.Fields.DeclaredCargoClass")));

            RuleFor(x => x.CountryOfOriginId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.CountryOfOrigin")));

            RuleFor(x => x.TotalGrossWeight).GreaterThan(0)
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.GreaterThan"), localizationService.GetResource("Common.Fields.TotalGrossWeight"), 0));

            RuleFor(x => x.MeasureWeightId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.MeasureWeight")));

            RuleFor(x => x.Quantity).GreaterThan(0)
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.GreaterThan"), localizationService.GetResource("Common.Fields.Quantity"), 0));

            RuleFor(x => x.Price).GreaterThan(0)
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.GreaterThan"), localizationService.GetResource("Admin.SPOrderDetails.Fields.Price"), 0));
            RuleFor(x => x.TotalAmount).GreaterThan(0)
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.GreaterThan"), localizationService.GetResource("Admin.SPOrderDetails.Fields.TotalAmount"), 0));

            RuleFor(x => x.DeclaredCustomsValue).GreaterThan(0)
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.GreaterThan"), localizationService.GetResource("Admin.SPOrderDetails.Fields.DeclaredCustomsValue"), 0));
            RuleFor(x => x.TotalDeclaredCustomsValue).GreaterThan(0)
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.GreaterThan"), localizationService.GetResource("Admin.SPOrderDetails.Fields.TotalDeclaredCustomsValue"), 0));

            RuleFor(x => x.CurrencyId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.Currency")));

            RuleFor(x => x.Note).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Note"), 500));
        }
    }
}
