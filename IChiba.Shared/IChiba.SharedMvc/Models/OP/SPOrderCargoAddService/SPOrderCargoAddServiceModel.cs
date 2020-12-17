using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.OP
{
    public partial class SPOrderCargoAddServiceModel : BaseIChibaEntityModel
    {
        public string OrderId { get; set; } // varchar(50)
        public string CargoAddServiceId { get; set; } // varchar(50)
        public string CargoAddServiceCode { get; set; } // varchar(50)

        public SPOrderCargoAddServiceModel CargoAddService { get; set; }
    }
}
