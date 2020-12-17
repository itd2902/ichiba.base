using AutoMapper;
using IChiba.Core.Domain.Master;
using IChiba.Core.Infrastructure.Mapper;
using IChiba.SharedMvc.Models.Master;

namespace IChiba.SharedMvc.Infrastructure.AutoMapperProfiles
{
    public class MasterProfile : Profile, IOrderedMapperProfile
    {
        public MasterProfile()
        {
            #region Airline
            CreateMap<Airline, AirlineModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<AirlineModel, Airline>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region Bank
            CreateMap<Bank, BankModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<BankModel, Bank>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.BankAccounts, x => x.Ignore())
                .ForMember(x => x.BankBranches, x => x.Ignore())
                .ForMember(x => x.SPBillings, x => x.Ignore());
            #endregion

            #region BankAccount
            CreateMap<BankAccount, BankAccountModel>()
                .ForMember(x => x.Bank, x => x.Ignore())
                .ForMember(x => x.BankBranch, x => x.Ignore())
                .ForMember(x => x.Currency, x => x.Ignore())
                .ForMember(x => x.SelectBankBranches, x => x.Ignore())
                .ForMember(x => x.SelectBanks, x => x.Ignore())
                .ForMember(x => x.SelectCurrencies, x => x.Ignore());
            CreateMap<BankAccountModel, BankAccount>()
                .ForMember(x => x.Bank, x => x.Ignore())
                .ForMember(x => x.BankBranch, x => x.Ignore())
                .ForMember(x => x.Currency, x => x.Ignore());
            #endregion

            #region BankBranch
            CreateMap<BankBranch, BankBranchModel>()
                .ForMember(x => x.Bank, x => x.Ignore())
                .ForMember(x => x.Country, x => x.Ignore())
                .ForMember(x => x.District, x => x.Ignore())
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.SelectBanks, x => x.Ignore())
                .ForMember(x => x.SelectCountries, x => x.Ignore())
                .ForMember(x => x.SelectDistricts, x => x.Ignore())
                .ForMember(x => x.SelectStateProvinces, x => x.Ignore())
                .ForMember(x => x.StateProvince, x => x.Ignore());
            CreateMap<BankBranchModel, BankBranch>()
                .ForMember(x => x.Bank, x => x.Ignore())
                .ForMember(x => x.BankAccounts, x => x.Ignore())
                .ForMember(x => x.Country, x => x.Ignore())
                .ForMember(x => x.District, x => x.Ignore())
                .ForMember(x => x.SPBillings, x => x.Ignore())
                .ForMember(x => x.StateProvince, x => x.Ignore());
            #endregion

            #region CargoAddService
            CreateMap<CargoAddService, CargoAddServiceModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<CargoAddServiceModel, CargoAddService>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region CargoSPService
            CreateMap<CargoSPService, CargoSPServiceModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<CargoSPServiceModel, CargoSPService>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region ChargesGroup
            CreateMap<ChargesGroup, ChargesGroupModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<ChargesGroupModel, ChargesGroup>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.ChargesTypes, x => x.Ignore());
            #endregion

            #region ChargesType
            CreateMap<ChargesType, ChargesTypeModel>()
                .ForMember(x => x.ChargesGroup, x => x.Ignore())
                .ForMember(x => x.ContMeasurement, x => x.Ignore())
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.Measurement, x => x.Ignore())
                .ForMember(x => x.PayCurrency, x => x.Ignore())
                .ForMember(x => x.RecvCurrency, x => x.Ignore())
                .ForMember(x => x.VatType, x => x.Ignore())
                .ForMember(x => x.SelectChargesGroups, x => x.Ignore())
                .ForMember(x => x.SelectContMeasures, x => x.Ignore())
                .ForMember(x => x.SelectMeasures, x => x.Ignore())
                .ForMember(x => x.SelectPayCurrencies, x => x.Ignore())
                .ForMember(x => x.SelectRecvCurrencies, x => x.Ignore())
                .ForMember(x => x.SelectVatTypes, x => x.Ignore());
            CreateMap<ChargesTypeModel, ChargesType>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.ChargesGroup, x => x.Ignore())
                .ForMember(x => x.ContMeasurement, x => x.Ignore())
                .ForMember(x => x.Measurement, x => x.Ignore())
                .ForMember(x => x.PayCurrency, x => x.Ignore())
                .ForMember(x => x.RecvCurrency, x => x.Ignore())
                .ForMember(x => x.VatType, x => x.Ignore());
            #endregion

            #region Commodity
            CreateMap<Commodity, CommodityModel>()
                .ForMember(x => x.CommodityGroup, x => x.Ignore())
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.SelectCommodityGroups, x => x.Ignore());
            CreateMap<CommodityModel, Commodity>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.CommodityGroup, x => x.Ignore());
            #endregion

            #region CommodityGroupGroup
            CreateMap<CommodityGroup, CommodityGroupModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<CommodityGroupModel, CommodityGroup>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.Commodities, x => x.Ignore());
            #endregion

            #region Consignee
            CreateMap<Consignee, ConsigneeModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.PaymentTerm, x => x.Ignore())
                .ForMember(x => x.SelectPaymentTerms, x => x.Ignore());
            CreateMap<ConsigneeModel, Consignee>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.PaymentTerm, x => x.Ignore());
            #endregion

            #region Country
            CreateMap<Country, CountryModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.SelectGlobalZones, x => x.Ignore());
            CreateMap<CountryModel, Country>()
                .ForMember(x => x.BankBranches, x => x.Ignore())
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.Districts, x => x.Ignore())
                .ForMember(x => x.GlobalZone, x => x.Ignore())
                .ForMember(x => x.Ports, x => x.Ignore())
                .ForMember(x => x.SPAddresses, x => x.Ignore())
                .ForMember(x => x.StateProvinces, x => x.Ignore())
                .ForMember(x => x.Vessels, x => x.Ignore())
                .ForMember(x => x.Wards, x => x.Ignore());
            #endregion

            #region Currency
            CreateMap<Currency, CurrencyModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.SelectDisplayLocales, x => x.Ignore());
            CreateMap<CurrencyModel, Currency>()
                .ForMember(x => x.BankAccounts, x => x.Ignore())
                .ForMember(x => x.CurrencyCode, x => x.Ignore())
                .ForMember(x => x.PayChargesTypes, x => x.Ignore())
                .ForMember(x => x.RecvChargesTypes, x => x.Ignore())
                .ForMember(x => x.SPBillings, x => x.Ignore());
            #endregion

            #region CustomAgent
            CreateMap<CustomAgent, CustomAgentModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<CustomAgentModel, CustomAgent>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region DeliveryTime
            CreateMap<DeliveryTime, DeliveryTimeModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.SelectTimeUnits, x => x.Ignore())
                .ForMember(x => x.TimeUnitText, x => x.Ignore());
            CreateMap<DeliveryTimeModel, DeliveryTime>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region District
            CreateMap<District, DistrictModel>()
                .ForMember(x => x.Country, x => x.Ignore())
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.SelectCountries, x => x.Ignore())
                .ForMember(x => x.SelectStateProvinces, x => x.Ignore())
                .ForMember(x => x.StateProvince, x => x.Ignore());
            CreateMap<DistrictModel, District>()
                .ForMember(x => x.BankBranches, x => x.Ignore())
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.Country, x => x.Ignore())
                .ForMember(x => x.SPAddresses, x => x.Ignore())
                .ForMember(x => x.StateProvince, x => x.Ignore())
                .ForMember(x => x.Wards, x => x.Ignore());
            #endregion

            #region EventType
            CreateMap<EventType, EventTypeModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<EventTypeModel, EventType>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region ForwardingAgent
            CreateMap<ForwardingAgent, ForwardingAgentModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<ForwardingAgentModel, ForwardingAgent>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region GlobalZone
            CreateMap<GlobalZone, GlobalZoneModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<GlobalZoneModel, GlobalZone>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region Incoterm
            CreateMap<Incoterm, IncotermModel>()
                .ForMember(x => x.FreightPMText, x => x.Ignore())
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.OtherChargesPMText, x => x.Ignore())
                .ForMember(x => x.SelectFreightPMs, x => x.Ignore())
                .ForMember(x => x.SelectOtherChargesPMs, x => x.Ignore());
            CreateMap<IncotermModel, Incoterm>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region MeasureDimension
            CreateMap<MeasureDimension, MeasureDimensionModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<MeasureDimensionModel, MeasureDimension>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region MeasureWeight
            CreateMap<MeasureWeight, MeasureWeightModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<MeasureWeightModel, MeasureWeight>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region PackageType
            CreateMap<PackageType, PackageTypeModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<PackageTypeModel, PackageType>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region PaymentMethod
            CreateMap<PaymentMethod, PaymentMethodModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<PaymentMethodModel, PaymentMethod>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region PaymentTerm
            CreateMap<PaymentTerm, PaymentTermModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.FromDateTypeText, x => x.Ignore())
                .ForMember(x => x.SelectFromDateTypes, x => x.Ignore());
            CreateMap<PaymentTermModel, PaymentTerm>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.Consignees, x => x.Ignore())
                .ForMember(x => x.SPBillings, x => x.Ignore())
                .ForMember(x => x.Shippers, x => x.Ignore())
                .ForMember(x => x.SPCustomers, x => x.Ignore());
            #endregion

            #region Port
            CreateMap<Port, PortModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.SelectCountries, x => x.Ignore())
                .ForMember(x => x.SelectStateProvinces, x => x.Ignore());
            CreateMap<PortModel, Port>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.Country, x => x.Ignore())
                .ForMember(x => x.StateProvince, x => x.Ignore());
            #endregion

            #region PostOffice
            CreateMap<PostOffice, PostOfficeModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.Warehouse, x => x.Ignore());
            CreateMap<PostOfficeModel, PostOffice>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.Warehouse, x => x.Ignore());
            #endregion

            #region Shipper
            CreateMap<Shipper, ShipperModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.PaymentTerm, x => x.Ignore())
                .ForMember(x => x.SelectPaymentTerms, x => x.Ignore());
            CreateMap<ShipperModel, Shipper>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.PaymentTerm, x => x.Ignore());
            #endregion

            #region ShippingAgent
            CreateMap<ShippingAgent, ShippingAgentModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<ShippingAgentModel, ShippingAgent>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.ShippingLines, x => x.Ignore());
            #endregion

            #region ShippingLine
            CreateMap<ShippingLine, ShippingLineModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.SelectShippingAgents, x => x.Ignore())
                .ForMember(x => x.ShippingAgent, x => x.Ignore());
            CreateMap<ShippingLineModel, ShippingLine>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.ShippingAgent, x => x.Ignore());
            #endregion

            #region SPAddress
            CreateMap<SPAddress, SPAddressModel>()
                .ForMember(x => x.Country, x => x.Ignore())
                .ForMember(x => x.District, x => x.Ignore())
                .ForMember(x => x.StateProvince, x => x.Ignore())
                .ForMember(x => x.Ward, x => x.Ignore());
            CreateMap<SPAddressModel, SPAddress>()
                .ForMember(x => x.Country, x => x.Ignore())
                .ForMember(x => x.District, x => x.Ignore())
                .ForMember(x => x.StateProvince, x => x.Ignore())
                .ForMember(x => x.Ward, x => x.Ignore());
            #endregion

            #region SPCustomer
            CreateMap<SPCustomer, SPCustomerModel>()
                .ForMember(x => x.Addresses, x => x.Ignore())
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.PaymentTerm, x => x.Ignore())
                .ForMember(x => x.SelectPaymentTerms, x => x.Ignore());
            CreateMap<SPCustomerModel, SPCustomer>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.PaymentTerm, x => x.Ignore());
            #endregion

            #region SPMeasurement
            CreateMap<SPMeasurement, SPMeasurementModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<SPMeasurementModel, SPMeasurement>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.ChargesTypes, x => x.Ignore())
                .ForMember(x => x.ContChargesTypes, x => x.Ignore());
            #endregion

            #region SPMoveType
            CreateMap<SPMoveType, SPMoveTypeModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<SPMoveTypeModel, SPMoveType>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region SPProductType
            CreateMap<SPProductType, SPProductTypeModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<SPProductTypeModel, SPProductType>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region SPSpecialServiceType
            CreateMap<SPSpecialServiceType, SPSpecialServiceTypeModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<SPSpecialServiceTypeModel, SPSpecialServiceType>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region StateProvince
            CreateMap<StateProvince, StateProvinceModel>()
                .ForMember(x => x.Country, x => x.Ignore())
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.SelectCountries, x => x.Ignore());
            CreateMap<StateProvinceModel, StateProvince>()
                .ForMember(x => x.BankBranches, x => x.Ignore())
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.Country, x => x.Ignore())
                .ForMember(x => x.Districts, x => x.Ignore())
                .ForMember(x => x.Ports, x => x.Ignore())
                .ForMember(x => x.SPAddresses, x => x.Ignore())
                .ForMember(x => x.Wards, x => x.Ignore());
            #endregion

            #region Trucker
            CreateMap<Trucker, TruckerModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<TruckerModel, Trucker>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region VatPercentage
            CreateMap<VatPercentage, VatPercentageModel>()
                .ForMember(x => x.VatType, x => x.Ignore());
            CreateMap<VatPercentageModel, VatPercentage>()
                .ForMember(x => x.VatType, x => x.Ignore());
            #endregion

            #region VatType
            CreateMap<VatType, VatTypeModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<VatTypeModel, VatType>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.ChargesTypes, x => x.Ignore())
                .ForMember(x => x.SPBillings, x => x.Ignore())
                .ForMember(x => x.VatPercentages, x => x.Ignore());
            #endregion

            #region Vendor
            CreateMap<Vendor, VendorModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<VendorModel, Vendor>()
                .ForMember(x => x.Code, x => x.Ignore());
            #endregion

            #region Vessel
            CreateMap<Vessel, VesselModel>()
                .ForMember(x => x.Country, x => x.Ignore())
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.SelectCountries, x => x.Ignore());
            CreateMap<VesselModel, Vessel>()
                .ForMember(x => x.Country, x => x.Ignore());
            #endregion

            #region Ward
            CreateMap<Ward, WardModel>()
                .ForMember(x => x.Country, x => x.Ignore())
                .ForMember(x => x.District, x => x.Ignore())
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore())
                .ForMember(x => x.SelectCountries, x => x.Ignore())
                .ForMember(x => x.SelectStateProvinces, x => x.Ignore())
                .ForMember(x => x.SelectDistricts, x => x.Ignore())
                .ForMember(x => x.StateProvince, x => x.Ignore());
            CreateMap<WardModel, Ward>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.Country, x => x.Ignore())
                .ForMember(x => x.District, x => x.Ignore())
                .ForMember(x => x.SPAddresses, x => x.Ignore())
                .ForMember(x => x.StateProvince, x => x.Ignore());
            #endregion

            #region Warehouse
            CreateMap<Warehouse, WarehouseModel>()
                .ForMember(x => x.LocaleLabels, x => x.Ignore())
                .ForMember(x => x.Locales, x => x.Ignore());
            CreateMap<WarehouseModel, Warehouse>()
                .ForMember(x => x.Code, x => x.Ignore())
                .ForMember(x => x.PostOffices, x => x.Ignore());
            #endregion

            //add some generic mapping rules
            ForAllMaps(CommonProfile.AllMapsAction);
        }

        public int Order => 1;
    }
}
