using IChiba.Core.Domain;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public class WardSearchModel : ISearchModel
    {
        public string Keywords { get; set; }

        public string CountryId { get; set; }

        public string StateProvinceId { get; set; }

        public string DistrictId { get; set; }

        public ActiveStatus Status { get; set; }

        public string LanguageId { get; set; }
    }
}
