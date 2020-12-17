using System;
using IChiba.Core.Domain;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class SPAddressModel : BaseIChibaEntityModel
    {
		public string EntityId { get; set; } // varchar(50)
		public EntityType EntityType { get; set; } // int
		public string EntityTypeText { get; set; } // nvarchar(255)
		public int Type { get; set; } // int
		public string AddressName { get; set; } // nvarchar(255)
		public string FullName { get; set; } // nvarchar(255)
		public string Email { get; set; } // nvarchar(255)
		public string Company { get; set; } // nvarchar(255)
		public string CountryId { get; set; } // varchar(50)
		public string StateProvinceId { get; set; } // varchar(50)
		public string City { get; set; } // varchar(50)
		public string DistrictId { get; set; } // varchar(50)
		public string WardId { get; set; } // varchar(50)
		public string Address1 { get; set; } // nvarchar(1000)
		public string Address2 { get; set; } // nvarchar(1000)
		public string ZipPostalCode { get; set; } // nvarchar(50)
		public string PhoneNumber { get; set; } // nvarchar(255)
		public string FaxNumber { get; set; } // nvarchar(255)
		public string Note { get; set; } // nvarchar(500)
		public bool IsLocalLanguage { get; set; } // bit
		public DateTime CreatedOnUtc { get; set; } // datetime

		public CountryModel Country { get; set; }

		public DistrictModel District { get; set; }

		public StateProvinceModel StateProvince { get; set; }

		public WardModel Ward { get; set; }
	}
}
