using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class ForwardingAgentModel : BaseIChibaEntityModel,
        ILocalizedModel<ForwardingAgentLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(50)
        public string Name { get; set; } // nvarchar(255)
        public string LocalName { get; set; } // nvarchar(255)
        public string IATA { get; set; } // nvarchar(10)
        public string CASS { get; set; } // nvarchar(50)
        public int? StorageFreeDays { get; set; } // int
        public string Website { get; set; } // nvarchar(500)
        public string Note { get; set; } // nvarchar(500)
        public bool Active { get; set; } // bit

        public IList<ForwardingAgentLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public ForwardingAgentModel()
        {
            Active = true;
            Locales = new List<ForwardingAgentLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class ForwardingAgentLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class ForwardingAgentValidator : AbstractValidator<ForwardingAgentModel>
    {
        public ForwardingAgentValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.ForwardingAgents.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.ForwardingAgents.Fields.Code"), 50));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.ForwardingAgents.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.ForwardingAgents.Fields.Name"), 255));

            RuleFor(x => x.LocalName).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.LocalName"), 255));

            RuleFor(x => x.IATA).SetValidator(new MaximumLengthValidator(3))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.IATA"), 3));

            RuleFor(x => x.CASS).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.CASS"), 50));

            RuleFor(x => x.StorageFreeDays).GreaterThanOrEqualTo(0)
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.GreaterThanOrEqualTo"), localizationService.GetResource("Common.Fields.StorageFreeDays"), 0));

            RuleFor(x => x.Website).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Website"), 500));

            RuleFor(x => x.Note).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Note"), 500));
        }
    }
}
