using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class BankModel : BaseIChibaEntityModel,
        ILocalizedModel<BankLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(50)
        public string Name { get; set; } // nvarchar(255)
        public string ShortName { get; set; } // nvarchar(100)
        public string SwiftCode { get; set; } // nvarchar(50)
        public string Logo { get; set; } // nvarchar(max)
        public string Note { get; set; } // nvarchar(500)
        public bool Active { get; set; } // bit
        public int DisplayOrder { get; set; } // int

        public IList<BankLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public BankModel()
        {
            Active = true;
            DisplayOrder = 1;
            Locales = new List<BankLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class BankLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class BankValidator : AbstractValidator<BankModel>
    {
        public BankValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Banks.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Banks.Fields.Code"), 50));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Banks.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Banks.Fields.Name"), 255));

            RuleFor(x => x.ShortName).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.ShortName")));
            RuleFor(x => x.ShortName).SetValidator(new MaximumLengthValidator(100))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.ShortName"), 100));

            RuleFor(x => x.SwiftCode).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.SwiftCode"), 50));

            RuleFor(x => x.Note).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Note"), 500));

            RuleFor(x => x.DisplayOrder).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.DisplayOrder")));
        }
    }
}
