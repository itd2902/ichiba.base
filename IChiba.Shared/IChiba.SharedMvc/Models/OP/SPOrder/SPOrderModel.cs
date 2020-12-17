using System;
using System.Collections.Generic;
using FluentValidation;
using IChiba.Core.Domain;
using IChiba.Services.Localization;
using IChiba.SharedMvc.Models.Master;
using IChiba.Web.Framework.Models;
using System.Linq;

namespace IChiba.SharedMvc.Models.OP
{
    public partial class SPOrderModel : BaseIChibaEntityModel
    {
        public string OrderNumber { get; set; } // varchar(100)
        public string CustomerId { get; set; } // varchar(50)
        public string CustomerCode { get; set; } // nvarchar(50)
        public string CustomerName { get; set; } // nvarchar(255)
        public string CustomerEmail { get; set; } // nvarchar(255)
        public string CustomerCountryId { get; set; } // varchar(50)
        public string CustomerStateProvinceId { get; set; } // varchar(50)
        public string CustomerCity { get; set; } // nvarchar(255)
        public string CustomerDistrictId { get; set; } // varchar(50)
        public string CustomerWardId { get; set; } // varchar(50)
        public string CustomerAddress1 { get; set; } // nvarchar(1000)
        public string CustomerAddress2 { get; set; } // nvarchar(1000)
        public string CustomerZipPostalCode { get; set; } // nvarchar(50)
        public string CustomerPhoneNumber { get; set; } // nvarchar(50)
        public string ShipperId { get; set; } // varchar(50)
        public string ShipperCode { get; set; } // nvarchar(50)
        public string ShipperName { get; set; } // nvarchar(255)
        public string ShipperEmail { get; set; } // nvarchar(255)
        public string ShipperCountryId { get; set; } // varchar(50)
        public string ShipperStateProvinceId { get; set; } // varchar(50)
        public string ShipperCity { get; set; } // nvarchar(255)
        public string ShipperDistrictId { get; set; } // varchar(50)
        public string ShipperWardId { get; set; } // varchar(50)
        public string ShipperAddress1 { get; set; } // nvarchar(1000)
        public string ShipperAddress2 { get; set; } // nvarchar(1000)
        public string ShipperZipPostalCode { get; set; } // nvarchar(50)
        public string ShipperPhoneNumber { get; set; } // nvarchar(50)
        public string ShipperFwdAgentId { get; set; } // varchar(50)
        public string ConsigneeId { get; set; } // varchar(50)
        public string ConsigneeCode { get; set; } // nvarchar(50)
        public string ConsigneeName { get; set; } // nvarchar(255)
        public string ConsigneeEmail { get; set; } // nvarchar(255)
        public string ConsigneeCountryId { get; set; } // varchar(50)
        public string ConsigneeStateProvinceId { get; set; } // varchar(50)
        public string ConsigneeCity { get; set; } // nvarchar(255)
        public string ConsigneeDistrictId { get; set; } // varchar(50)
        public string ConsigneeWardId { get; set; } // varchar(50)
        public string ConsigneeAddress1 { get; set; } // nvarchar(1000)
        public string ConsigneeAddress2 { get; set; } // nvarchar(1000)
        public string ConsigneeZipPostalCode { get; set; } // nvarchar(50)
        public string ConsigneePhoneNumber { get; set; } // nvarchar(50)
        public string ConsigneeFwdAgentId { get; set; } // varchar(50)
        public CargoPickupMethod CargoPickupMethod { get; set; } // int
        public string CargoPickupMethodText { get; set; } // nvarchar(255)
        public string PickupName { get; set; } // nvarchar(255)
        public string PickupEmail { get; set; } // nvarchar(255)
        public string PickupCountryId { get; set; } // varchar(50)
        public string PickupStateProvinceId { get; set; } // varchar(50)
        public string PickupCity { get; set; } // nvarchar(255)
        public string PickupDistrictId { get; set; } // varchar(50)
        public string PickupWardId { get; set; } // varchar(50)
        public string PickupAddress1 { get; set; } // nvarchar(1000)
        public string PickupAddress2 { get; set; } // nvarchar(1000)
        public string PickupZipPostalCode { get; set; } // nvarchar(50)
        public string PickupPhoneNumber { get; set; } // nvarchar(50)
        public CargoShippingMethod CargoShippingMethod { get; set; } // int
        public string CargoShippingMethodText { get; set; } // nvarchar(255)
        public CargoType CargoType { get; set; } // int
        public string CargoTypeText { get; set; } // nvarchar(255)
        public int Pieces { get; set; } // int
        public DateTime? SendDate { get; set; } // date
        public string MeasureWeightId { get; set; } // varchar(50)
        public string MeasureWeightCode { get; set; } // nvarchar(50)
        public string CurrencyId { get; set; } // varchar(50)
        public string CurrencyCode { get; set; } // nvarchar(50)
        public string ReferenceNumber { get; set; } // nvarchar(50)
        public string PostOfficeToSendId { get; set; } // varchar(50)
        public string PostOfficeToSendCode { get; set; } // nvarchar(50)
        public string CargoSPServiceId { get; set; } // varchar(50)
        public string CargoSPServiceCode { get; set; } // nvarchar(50)
        public string Note { get; set; } // nvarchar(4000)
        public SPOrderStatus Status { get; set; } // int
        public DateTime? ReceivedDate { get; set; } // datetime
        public string CreatedBy { get; set; } // varchar(50)
        public string CreatedByUserName { get; set; } // nvarchar(255)
        public DateTime CreatedOnUtc { get; set; } // datetime
        public string UpdatedBy { get; set; } // varchar(50)
        public string UpdatedByUserName { get; set; } // nvarchar(255)
        public DateTime? UpdatedOnUtc { get; set; } // datetime
        public bool Deleted { get; set; } // bit
        public string DeletedBy { get; set; } // varchar(50)
        public string DeletedByUserName { get; set; } // nvarchar(255)
        public DateTime? DeletedOnUtc { get; set; } // datetime
        public string StatusText { get; set; }

        public PostOfficeModel PostOfficeToSend { get; set; }
        public IList<PostOfficeModel> SelectPostOfficesToSend { get; set; }

        public CargoSPServiceModel CargoSPService { get; set; }
        public IList<CargoSPServiceModel> SelectCargoSPServices { get; set; }

        public IList<IChibaListItem> SelectCargoPickupMethods { get; set; }

        public IList<IChibaListItem> SelectCargoShippingMethods { get; set; }

        public IList<IChibaListItem> SelectCargoTypes { get; set; }

        public IList<CargoAddServiceModel> SelectCargoAddServices { get; set; }

        public IList<CountryModel> SelectCountries { get; set; }

        public IList<StateProvinceModel> SelectCustomerSPros { get; set; }

        public IList<StateProvinceModel> SelectShipperSPros { get; set; }

        public IList<StateProvinceModel> SelectConsigneeSPros { get; set; }

        public IList<StateProvinceModel> SelectPickupSPros { get; set; }

        public IList<SPOrderCargoAddServiceModel> OrderCargoAddServices { get; set; }

        public IList<SPOrderDetailModel> OrderDetails { get; set; }

        public IList<CommodityModel> SelectCommodities { get; set; }

        public IList<CountryModel> SelectCountriesOfOrigin { get; set; }

        public IList<MeasureWeightModel> SelectMeasureWeights { get; set; }

        public IList<CurrencyModel> SelectCurrencies { get; set; }

        public IList<IChibaListItem> SelectDeclaredCargoClasses { get; set; }

        public SPOrderModel()
        {
            SelectPostOfficesToSend = new List<PostOfficeModel>();
            SelectCargoSPServices = new List<CargoSPServiceModel>();
            SelectCargoPickupMethods = new List<IChibaListItem>();
            SelectCargoShippingMethods = new List<IChibaListItem>();
            SelectCargoTypes = new List<IChibaListItem>();
            SelectCargoAddServices = new List<CargoAddServiceModel>();
            SelectCountries = new List<CountryModel>();
            SelectCustomerSPros = new List<StateProvinceModel>();
            SelectShipperSPros = new List<StateProvinceModel>();
            SelectConsigneeSPros = new List<StateProvinceModel>();
            SelectPickupSPros = new List<StateProvinceModel>();
            OrderCargoAddServices = new List<SPOrderCargoAddServiceModel>();
            OrderDetails = new List<SPOrderDetailModel>(); SelectCommodities = new List<CommodityModel>();
            SelectCountriesOfOrigin = new List<CountryModel>();
            SelectMeasureWeights = new List<MeasureWeightModel>();
            SelectCurrencies = new List<CurrencyModel>();
            SelectDeclaredCargoClasses = new List<IChibaListItem>();
        }
    }

    public partial class SPOrderValidator : AbstractValidator<SPOrderModel>
    {
        public SPOrderValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.CustomerId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.SPOrders.Fields.SPCustomer")));
            RuleFor(x=>x.OrderDetails).Must(collection=>collection.Count>0)
                .WithMessage(localizationService.GetResource("Common.Validators.SPOrders.NoData"));

            RuleFor(x => x.CargoPickupMethod).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.SPOrders.Fields.CargoPickupMethod")));
            RuleFor(x => x.CargoPickupMethod).IsInEnum()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.InValid"), localizationService.GetResource("Admin.SPOrders.Fields.CargoPickupMethod")));

            RuleFor(x => x.CargoShippingMethod).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.SPOrders.Fields.CargoShippingMethod")));
            RuleFor(x => x.CargoShippingMethod).IsInEnum()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.InValid"), localizationService.GetResource("Admin.SPOrders.Fields.CargoShippingMethod")));

            RuleFor(x => x.CargoType).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.SPOrders.Fields.CargoType")));
            RuleFor(x => x.CargoType).IsInEnum()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Objects.InValid"), localizationService.GetResource("Admin.SPOrders.Fields.CargoType")));

            RuleFor(x => x.CurrencyId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.Currency")));

            RuleFor(x => x.MeasureWeightId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.MeasureWeight")));

            RuleFor(x => x.PostOfficeToSendId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.SPOrders.Fields.PostOfficeToSend")));

            RuleFor(x => x.CargoSPServiceId).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.SPOrders.Fields.CargoSPService")));
        }
    }
}
