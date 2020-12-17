using IChiba.Core.Domain.Master;
using IChiba.Core.Domain.OP;
using IChiba.Core.Infrastructure.Mapper;
using IChiba.SharedMvc.Models.Master;
using IChiba.SharedMvc.Models.OP;

namespace IChiba.SharedMvc
{
    public static class MappingExtensions
    {
        #region Master

        #region Airline
        public static AirlineModel ToModel(this Airline entity)
        {
            return AutoMapperConfiguration.Mapper.Map<Airline, AirlineModel>(entity);
        }

        public static Airline ToEntity(this AirlineModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<AirlineModel, Airline>(model);
        }

        public static Airline ToEntity(this AirlineModel model, Airline destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region Bank
        public static BankModel ToModel(this Bank entity)
        {
            return AutoMapperConfiguration.Mapper.Map<Bank, BankModel>(entity);
        }

        public static Bank ToEntity(this BankModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<BankModel, Bank>(model);
        }

        public static Bank ToEntity(this BankModel model, Bank destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region BankAccount
        public static BankAccountModel ToModel(this BankAccount entity)
        {
            return AutoMapperConfiguration.Mapper.Map<BankAccount, BankAccountModel>(entity);
        }

        public static BankAccount ToEntity(this BankAccountModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<BankAccountModel, BankAccount>(model);
        }

        public static BankAccount ToEntity(this BankAccountModel model, BankAccount destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region BankBranch
        public static BankBranchModel ToModel(this BankBranch entity)
        {
            return AutoMapperConfiguration.Mapper.Map<BankBranch, BankBranchModel>(entity);
        }

        public static BankBranch ToEntity(this BankBranchModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<BankBranchModel, BankBranch>(model);
        }

        public static BankBranch ToEntity(this BankBranchModel model, BankBranch destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region CargoAddService
        public static CargoAddServiceModel ToModel(this CargoAddService entity)
        {
            return AutoMapperConfiguration.Mapper.Map<CargoAddService, CargoAddServiceModel>(entity);
        }

        public static CargoAddService ToEntity(this CargoAddServiceModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<CargoAddServiceModel, CargoAddService>(model);
        }

        public static CargoAddService ToEntity(this CargoAddServiceModel model, CargoAddService destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region CargoSPService
        public static CargoSPServiceModel ToModel(this CargoSPService entity)
        {
            return AutoMapperConfiguration.Mapper.Map<CargoSPService, CargoSPServiceModel>(entity);
        }

        public static CargoSPService ToEntity(this CargoSPServiceModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<CargoSPServiceModel, CargoSPService>(model);
        }

        public static CargoSPService ToEntity(this CargoSPServiceModel model, CargoSPService destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region ChargesGroup
        public static ChargesGroupModel ToModel(this ChargesGroup entity)
        {
            return AutoMapperConfiguration.Mapper.Map<ChargesGroup, ChargesGroupModel>(entity);
        }

        public static ChargesGroup ToEntity(this ChargesGroupModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<ChargesGroupModel, ChargesGroup>(model);
        }

        public static ChargesGroup ToEntity(this ChargesGroupModel model, ChargesGroup destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region ChargesType
        public static ChargesTypeModel ToModel(this ChargesType entity)
        {
            return AutoMapperConfiguration.Mapper.Map<ChargesType, ChargesTypeModel>(entity);
        }

        public static ChargesType ToEntity(this ChargesTypeModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<ChargesTypeModel, ChargesType>(model);
        }

        public static ChargesType ToEntity(this ChargesTypeModel model, ChargesType destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region Commodity
        public static CommodityModel ToModel(this Commodity entity)
        {
            return AutoMapperConfiguration.Mapper.Map<Commodity, CommodityModel>(entity);
        }

        public static Commodity ToEntity(this CommodityModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<CommodityModel, Commodity>(model);
        }

        public static Commodity ToEntity(this CommodityModel model, Commodity destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region CommodityGroup
        public static CommodityGroupModel ToModel(this CommodityGroup entity)
        {
            return AutoMapperConfiguration.Mapper.Map<CommodityGroup, CommodityGroupModel>(entity);
        }

        public static CommodityGroup ToEntity(this CommodityGroupModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<CommodityGroupModel, CommodityGroup>(model);
        }

        public static CommodityGroup ToEntity(this CommodityGroupModel model, CommodityGroup destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region Consignee
        public static ConsigneeModel ToModel(this Consignee entity)
        {
            return AutoMapperConfiguration.Mapper.Map<Consignee, ConsigneeModel>(entity);
        }

        public static Consignee ToEntity(this ConsigneeModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<ConsigneeModel, Consignee>(model);
        }

        public static Consignee ToEntity(this ConsigneeModel model, Consignee destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region Country
        public static CountryModel ToModel(this Country entity)
        {
            return AutoMapperConfiguration.Mapper.Map<Country, CountryModel>(entity);
        }

        public static Country ToEntity(this CountryModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<CountryModel, Country>(model);
        }

        public static Country ToEntity(this CountryModel model, Country destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region Currency
        public static CurrencyModel ToModel(this Currency entity)
        {
            return AutoMapperConfiguration.Mapper.Map<Currency, CurrencyModel>(entity);
        }

        public static Currency ToEntity(this CurrencyModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<CurrencyModel, Currency>(model);
        }

        public static Currency ToEntity(this CurrencyModel model, Currency destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region CustomAgent
        public static CustomAgentModel ToModel(this CustomAgent entity)
        {
            return AutoMapperConfiguration.Mapper.Map<CustomAgent, CustomAgentModel>(entity);
        }

        public static CustomAgent ToEntity(this CustomAgentModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<CustomAgentModel, CustomAgent>(model);
        }

        public static CustomAgent ToEntity(this CustomAgentModel model, CustomAgent destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region DeliveryTime
        public static DeliveryTimeModel ToModel(this DeliveryTime entity)
        {
            return AutoMapperConfiguration.Mapper.Map<DeliveryTime, DeliveryTimeModel>(entity);
        }

        public static DeliveryTime ToEntity(this DeliveryTimeModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<DeliveryTimeModel, DeliveryTime>(model);
        }

        public static DeliveryTime ToEntity(this DeliveryTimeModel model, DeliveryTime destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region District
        public static DistrictModel ToModel(this District entity)
        {
            return AutoMapperConfiguration.Mapper.Map<District, DistrictModel>(entity);
        }

        public static District ToEntity(this DistrictModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<DistrictModel, District>(model);
        }

        public static District ToEntity(this DistrictModel model, District destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region EventType
        public static EventTypeModel ToModel(this EventType entity)
        {
            return AutoMapperConfiguration.Mapper.Map<EventType, EventTypeModel>(entity);
        }

        public static EventType ToEntity(this EventTypeModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<EventTypeModel, EventType>(model);
        }

        public static EventType ToEntity(this EventTypeModel model, EventType destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region ForwardingAgent
        public static ForwardingAgentModel ToModel(this ForwardingAgent entity)
        {
            return AutoMapperConfiguration.Mapper.Map<ForwardingAgent, ForwardingAgentModel>(entity);
        }

        public static ForwardingAgent ToEntity(this ForwardingAgentModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<ForwardingAgentModel, ForwardingAgent>(model);
        }

        public static ForwardingAgent ToEntity(this ForwardingAgentModel model, ForwardingAgent destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region GlobalZone
        public static GlobalZoneModel ToModel(this GlobalZone entity)
        {
            return AutoMapperConfiguration.Mapper.Map<GlobalZone, GlobalZoneModel>(entity);
        }

        public static GlobalZone ToEntity(this GlobalZoneModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<GlobalZoneModel, GlobalZone>(model);
        }

        public static GlobalZone ToEntity(this GlobalZoneModel model, GlobalZone destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region Incoterm
        public static IncotermModel ToModel(this Incoterm entity)
        {
            return AutoMapperConfiguration.Mapper.Map<Incoterm, IncotermModel>(entity);
        }

        public static Incoterm ToEntity(this IncotermModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<IncotermModel, Incoterm>(model);
        }

        public static Incoterm ToEntity(this IncotermModel model, Incoterm destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region MeasureDimension
        public static MeasureDimensionModel ToModel(this MeasureDimension entity)
        {
            return AutoMapperConfiguration.Mapper.Map<MeasureDimension, MeasureDimensionModel>(entity);
        }

        public static MeasureDimension ToEntity(this MeasureDimensionModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<MeasureDimensionModel, MeasureDimension>(model);
        }

        public static MeasureDimension ToEntity(this MeasureDimensionModel model, MeasureDimension destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region MeasureWeight
        public static MeasureWeightModel ToModel(this MeasureWeight entity)
        {
            return AutoMapperConfiguration.Mapper.Map<MeasureWeight, MeasureWeightModel>(entity);
        }

        public static MeasureWeight ToEntity(this MeasureWeightModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<MeasureWeightModel, MeasureWeight>(model);
        }

        public static MeasureWeight ToEntity(this MeasureWeightModel model, MeasureWeight destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region PackageType
        public static PackageTypeModel ToModel(this PackageType entity)
        {
            return AutoMapperConfiguration.Mapper.Map<PackageType, PackageTypeModel>(entity);
        }

        public static PackageType ToEntity(this PackageTypeModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<PackageTypeModel, PackageType>(model);
        }

        public static PackageType ToEntity(this PackageTypeModel model, PackageType destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region PaymentMethod
        public static PaymentMethodModel ToModel(this PaymentMethod entity)
        {
            return AutoMapperConfiguration.Mapper.Map<PaymentMethod, PaymentMethodModel>(entity);
        }

        public static PaymentMethod ToEntity(this PaymentMethodModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<PaymentMethodModel, PaymentMethod>(model);
        }

        public static PaymentMethod ToEntity(this PaymentMethodModel model, PaymentMethod destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region PaymentTerm
        public static PaymentTermModel ToModel(this PaymentTerm entity)
        {
            return AutoMapperConfiguration.Mapper.Map<PaymentTerm, PaymentTermModel>(entity);
        }

        public static PaymentTerm ToEntity(this PaymentTermModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<PaymentTermModel, PaymentTerm>(model);
        }

        public static PaymentTerm ToEntity(this PaymentTermModel model, PaymentTerm destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region Port
        public static PortModel ToModel(this Port entity)
        {
            return AutoMapperConfiguration.Mapper.Map<Port, PortModel>(entity);
        }

        public static Port ToEntity(this PortModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<PortModel, Port>(model);
        }

        public static Port ToEntity(this PortModel model, Port destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region PostOffice
        public static PostOfficeModel ToModel(this PostOffice entity)
        {
            return AutoMapperConfiguration.Mapper.Map<PostOffice, PostOfficeModel>(entity);
        }

        public static PostOffice ToEntity(this PostOfficeModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<PostOfficeModel, PostOffice>(model);
        }

        public static PostOffice ToEntity(this PostOfficeModel model, PostOffice destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region Shipper
        public static ShipperModel ToModel(this Shipper entity)
        {
            return AutoMapperConfiguration.Mapper.Map<Shipper, ShipperModel>(entity);
        }

        public static Shipper ToEntity(this ShipperModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<ShipperModel, Shipper>(model);
        }

        public static Shipper ToEntity(this ShipperModel model, Shipper destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region ShippingAgent
        public static ShippingAgentModel ToModel(this ShippingAgent entity)
        {
            return AutoMapperConfiguration.Mapper.Map<ShippingAgent, ShippingAgentModel>(entity);
        }

        public static ShippingAgent ToEntity(this ShippingAgentModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<ShippingAgentModel, ShippingAgent>(model);
        }

        public static ShippingAgent ToEntity(this ShippingAgentModel model, ShippingAgent destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region ShippingLine
        public static ShippingLineModel ToModel(this ShippingLine entity)
        {
            return AutoMapperConfiguration.Mapper.Map<ShippingLine, ShippingLineModel>(entity);
        }

        public static ShippingLine ToEntity(this ShippingLineModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<ShippingLineModel, ShippingLine>(model);
        }

        public static ShippingLine ToEntity(this ShippingLineModel model, ShippingLine destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region SPAddress
        public static SPAddressModel ToModel(this SPAddress entity)
        {
            return AutoMapperConfiguration.Mapper.Map<SPAddress, SPAddressModel>(entity);
        }

        public static SPAddress ToEntity(this SPAddressModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<SPAddressModel, SPAddress>(model);
        }

        public static SPAddress ToEntity(this SPAddressModel model, SPAddress destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region SPCustomer
        public static SPCustomerModel ToModel(this SPCustomer entity)
        {
            return AutoMapperConfiguration.Mapper.Map<SPCustomer, SPCustomerModel>(entity);
        }

        public static SPCustomer ToEntity(this SPCustomerModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<SPCustomerModel, SPCustomer>(model);
        }

        public static SPCustomer ToEntity(this SPCustomerModel model, SPCustomer destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region SPMeasurement
        public static SPMeasurementModel ToModel(this SPMeasurement entity)
        {
            return AutoMapperConfiguration.Mapper.Map<SPMeasurement, SPMeasurementModel>(entity);
        }

        public static SPMeasurement ToEntity(this SPMeasurementModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<SPMeasurementModel, SPMeasurement>(model);
        }

        public static SPMeasurement ToEntity(this SPMeasurementModel model, SPMeasurement destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region SPMoveType
        public static SPMoveTypeModel ToModel(this SPMoveType entity)
        {
            return AutoMapperConfiguration.Mapper.Map<SPMoveType, SPMoveTypeModel>(entity);
        }

        public static SPMoveType ToEntity(this SPMoveTypeModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<SPMoveTypeModel, SPMoveType>(model);
        }

        public static SPMoveType ToEntity(this SPMoveTypeModel model, SPMoveType destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region SPProductType
        public static SPProductTypeModel ToModel(this SPProductType entity)
        {
            return AutoMapperConfiguration.Mapper.Map<SPProductType, SPProductTypeModel>(entity);
        }

        public static SPProductType ToEntity(this SPProductTypeModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<SPProductTypeModel, SPProductType>(model);
        }

        public static SPProductType ToEntity(this SPProductTypeModel model, SPProductType destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region SPSpecialServiceType
        public static SPSpecialServiceTypeModel ToModel(this SPSpecialServiceType entity)
        {
            return AutoMapperConfiguration.Mapper.Map<SPSpecialServiceType, SPSpecialServiceTypeModel>(entity);
        }

        public static SPSpecialServiceType ToEntity(this SPSpecialServiceTypeModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<SPSpecialServiceTypeModel, SPSpecialServiceType>(model);
        }

        public static SPSpecialServiceType ToEntity(this SPSpecialServiceTypeModel model, SPSpecialServiceType destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region StateProvince
        public static StateProvinceModel ToModel(this StateProvince entity)
        {
            return AutoMapperConfiguration.Mapper.Map<StateProvince, StateProvinceModel>(entity);
        }

        public static StateProvince ToEntity(this StateProvinceModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<StateProvinceModel, StateProvince>(model);
        }

        public static StateProvince ToEntity(this StateProvinceModel model, StateProvince destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region Trucker
        public static TruckerModel ToModel(this Trucker entity)
        {
            return AutoMapperConfiguration.Mapper.Map<Trucker, TruckerModel>(entity);
        }

        public static Trucker ToEntity(this TruckerModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<TruckerModel, Trucker>(model);
        }

        public static Trucker ToEntity(this TruckerModel model, Trucker destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region VatPercentage
        public static VatPercentageModel ToModel(this VatPercentage entity)
        {
            return AutoMapperConfiguration.Mapper.Map<VatPercentage, VatPercentageModel>(entity);
        }

        public static VatPercentage ToEntity(this VatPercentageModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<VatPercentageModel, VatPercentage>(model);
        }

        public static VatPercentage ToEntity(this VatPercentageModel model, VatPercentage destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region VatType
        public static VatTypeModel ToModel(this VatType entity)
        {
            return AutoMapperConfiguration.Mapper.Map<VatType, VatTypeModel>(entity);
        }

        public static VatType ToEntity(this VatTypeModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<VatTypeModel, VatType>(model);
        }

        public static VatType ToEntity(this VatTypeModel model, VatType destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region Vendor
        public static VendorModel ToModel(this Vendor entity)
        {
            return AutoMapperConfiguration.Mapper.Map<Vendor, VendorModel>(entity);
        }

        public static Vendor ToEntity(this VendorModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<VendorModel, Vendor>(model);
        }

        public static Vendor ToEntity(this VendorModel model, Vendor destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region Vessel
        public static VesselModel ToModel(this Vessel entity)
        {
            return AutoMapperConfiguration.Mapper.Map<Vessel, VesselModel>(entity);
        }

        public static Vessel ToEntity(this VesselModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<VesselModel, Vessel>(model);
        }

        public static Vessel ToEntity(this VesselModel model, Vessel destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region Ward
        public static WardModel ToModel(this Ward entity)
        {
            return AutoMapperConfiguration.Mapper.Map<Ward, WardModel>(entity);
        }

        public static Ward ToEntity(this WardModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<WardModel, Ward>(model);
        }

        public static Ward ToEntity(this WardModel model, Ward destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region Warehouse
        public static WarehouseModel ToModel(this Warehouse entity)
        {
            return AutoMapperConfiguration.Mapper.Map<Warehouse, WarehouseModel>(entity);
        }

        public static Warehouse ToEntity(this WarehouseModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<WarehouseModel, Warehouse>(model);
        }

        public static Warehouse ToEntity(this WarehouseModel model, Warehouse destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #endregion

        #region OP

        #region SPOrder
        public static SPOrderModel ToModel(this SPOrder entity)
        {
            return AutoMapperConfiguration.Mapper.Map<SPOrder, SPOrderModel>(entity);
        }

        public static SPOrder ToEntity(this SPOrderModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<SPOrderModel, SPOrder>(model);
        }

        public static SPOrder ToEntity(this SPOrderModel model, SPOrder destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region SPOrderCargoAddService
        public static SPOrderCargoAddServiceModel ToModel(this SPOrderCargoAddService entity)
        {
            return AutoMapperConfiguration.Mapper.Map<SPOrderCargoAddService, SPOrderCargoAddServiceModel>(entity);
        }

        public static SPOrderCargoAddService ToEntity(this SPOrderCargoAddServiceModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<SPOrderCargoAddServiceModel, SPOrderCargoAddService>(model);
        }

        public static SPOrderCargoAddService ToEntity(this SPOrderCargoAddServiceModel model, SPOrderCargoAddService destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #region SPOrderDetail
        public static SPOrderDetailModel ToModel(this SPOrderDetail entity)
        {
            return AutoMapperConfiguration.Mapper.Map<SPOrderDetail, SPOrderDetailModel>(entity);
        }

        public static SPOrderDetail ToEntity(this SPOrderDetailModel model)
        {
            return AutoMapperConfiguration.Mapper.Map<SPOrderDetailModel, SPOrderDetail>(model);
        }

        public static SPOrderDetail ToEntity(this SPOrderDetailModel model, SPOrderDetail destination)
        {
            return AutoMapperConfiguration.Mapper.Map(model, destination);
        }
        #endregion

        #endregion
    }
}
