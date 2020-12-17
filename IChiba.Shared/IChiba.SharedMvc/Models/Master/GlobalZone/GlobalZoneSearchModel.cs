using IChiba.Core.Domain;

namespace IChiba.SharedMvc.Models.Master
{
    public class GlobalZoneSearchModel
    {
        public string Keywords { get; set; }

        public ActiveStatus Status { get; set; }

        public string LanguageId { get; set; }
    }
}
