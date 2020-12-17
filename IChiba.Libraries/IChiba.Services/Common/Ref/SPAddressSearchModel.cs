using IChiba.Core.Domain;

namespace IChiba.Services.Common
{
    public class SPAddressSearchModel
    {
        public string Keywords { get; set; }

        public string LanguageId { get; set; }

        public EntityType EntityType { get; set; }
        
        public string EntityId { get; set; }

        public int Take { get; set; }
    }
}
