using IChiba.Core;
using IChiba.Core.Domain;
using IChiba.Services.Localization;
using IdentityModel;
using Microsoft.AspNetCore.Http;

namespace IChiba.Web.Framework
{
    /// <summary>
    /// Represents work context for web application
    /// </summary>
    public partial class WebWorkContext : IWorkContext
    {
        private readonly ILanguageService _languageService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHelper _webHelper;

        public WebWorkContext(
            ILanguageService languageService,
            IHttpContextAccessor httpContextAccessor,
            IWebHelper webHelper)
        {
            _languageService = languageService;
            _httpContextAccessor = httpContextAccessor;
            _webHelper = webHelper;
        }

        private string _languageId;
        public virtual string LanguageId
        {
            get
            {
                if (!string.IsNullOrEmpty(_languageId))
                    return _languageId;

                _languageId = _webHelper.GetHeaderValue(IChibaHeaderNames.LanguageId);
                if (string.IsNullOrWhiteSpace(_languageId))
                {
                    var language = _languageService.GetDefaultLanguage();
                    _languageId = language?.Id;
                }

                return _languageId;
            }
        }

        private string _userId;
        public virtual string UserId
        {
            get
            {
                if (!string.IsNullOrEmpty(_userId))
                    return _userId;

                _userId = _httpContextAccessor.HttpContext.User?.FindFirst(JwtClaimTypes.Subject)?.Value;

                return _userId;
            }
        }

        private string _userName;
        public virtual string UserName
        {
            get
            {
                if (!string.IsNullOrEmpty(_userName))
                    return _userName;

                _userName = _httpContextAccessor.HttpContext.User?.FindFirst(JwtClaimTypes.PreferredUserName)?.Value;

                return _userName;
            }
        }
    }
}
