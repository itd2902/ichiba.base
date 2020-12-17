using IChiba.Core.Domain;

namespace IChiba.SharedMvc.Models.Master
{
    public class SPAddressSearchModel
    {
        public string Keywords { get; set; }

        public ActiveStatus Status { get; set; }

        public string LanguageId { get; set; }
    }
}
