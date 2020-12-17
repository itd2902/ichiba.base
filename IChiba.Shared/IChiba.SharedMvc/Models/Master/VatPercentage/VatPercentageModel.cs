using System;
using FluentValidation;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class VatPercentageModel : BaseIChibaEntityModel
    {
        public string VatTypeId { get; set; } // varchar(50)
        public DateTime FromDate { get; set; } // datetime
        public decimal Percentage { get; set; } // decimal(18, 4)

        public VatTypeModel VatType { get; set; }
    }

    public partial class VatPercentageValidator : AbstractValidator<VatPercentageModel>
    {
        public VatPercentageValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.VatTypeId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.VatType")));

            RuleFor(x => x.FromDate).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.FromDate")));

            RuleFor(x => x.Percentage).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.Percentage")));
            RuleFor(x => x.Percentage).GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.GreaterThanOrEqualTo"), localizationService.GetResource("Common.Fields.Percentage"), 0));
        }
    }
}
