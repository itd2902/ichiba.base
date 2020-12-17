using IChiba.Core.Domain;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public class TruckerSearchModel : ISearchModel
    {
        public string Keywords { get; set; }

        public ActiveStatus Status { get; set; }

        public string LanguageId { get; set; }
    }
}
