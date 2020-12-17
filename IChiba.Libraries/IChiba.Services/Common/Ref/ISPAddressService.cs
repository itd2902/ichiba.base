using System.Collections.Generic;
using System.Threading.Tasks;
using IChiba.Core.Domain;
using IChiba.Core.Domain.Master;

namespace IChiba.Services.Common
{
    public partial interface ISPAddressService
    {
        Task<IList<SPAddress>> GetByEntity_SelectAsync(EntityType entityType, string entityId);
        Task<IList<SPAddress>> GetByEntity_SelectAsync(SPAddressSearchModel searchModel);
    }
}
