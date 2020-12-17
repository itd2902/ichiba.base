using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class ShippingLineModel : BaseIChibaEntityModel,
        ILocalizedModel<ShippingLineLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(50)
        public string SCAC { get; set; } // nvarchar(10)
        public string Name { get; set; } // nvarchar(255)
        public string LocalName { get; set; } // nvarchar(255)
        public string ShippingAgentId { get; set; } // varchar(50)
        public string Website { get; set; } // nvarchar(500)
        public string Note { get; set; } // nvarchar(max)
        public bool Active { get; set; } // bit

        public ShippingAgentModel ShippingAgent { get; set; }
        public IList<ShippingAgentModel> SelectShippingAgents { get; set; }

        public IList<ShippingLineLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public ShippingLineModel()
        {
            Active = true;
            SelectShippingAgents = new List<ShippingAgentModel>();
            Locales = new List<ShippingLineLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class ShippingLineLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class ShippingLineValidator : AbstractValidator<ShippingLineModel>
    {
        public ShippingLineValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.ShippingLines.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.ShippingLines.Fields.Code"), 50));

            RuleFor(x => x.SCAC).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.SCAC")));
            RuleFor(x => x.SCAC).SetValidator(new MaximumLengthValidator(10))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.SCAC"), 10));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.ShippingLines.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.ShippingLines.Fields.Name"), 255));

            RuleFor(x => x.LocalName).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.LocalName"), 255));

            RuleFor(x => x.Website).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Website"), 500));
        }
    }
}
