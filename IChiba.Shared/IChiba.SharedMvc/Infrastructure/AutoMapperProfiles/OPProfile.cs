using AutoMapper;
using IChiba.Core.Domain.OP;
using IChiba.Core.Infrastructure.Mapper;
using IChiba.SharedMvc.Models.OP;

namespace IChiba.SharedMvc.Infrastructure.AutoMapperProfiles
{
    public class OPProfile : Profile, IOrderedMapperProfile
    {
        public OPProfile()
        {
            #region SPOrder
            CreateMap<SPOrder, SPOrderModel>()
                .ForMember(x => x.CargoSPService, x => x.Ignore())
                .ForMember(x => x.OrderCargoAddServices, x => x.Ignore())
                .ForMember(x => x.OrderDetails, x => x.Ignore())
                .ForMember(x => x.PostOfficeToSend, x => x.Ignore())
                .ForMember(x => x.SelectCargoAddServices, x => x.Ignore())
                .ForMember(x => x.SelectCargoPickupMethods, x => x.Ignore())
                .ForMember(x => x.SelectCargoSPServices, x => x.Ignore())
                .ForMember(x => x.SelectCargoTypes, x => x.Ignore())
                .ForMember(x => x.SelectPostOfficesToSend, x => x.Ignore())
                .ForMember(x => x.SelectCargoShippingMethods, x => x.Ignore())
                .ForMember(x => x.SelectCountries, x => x.Ignore())
                .ForMember(x => x.SelectCustomerSPros, x => x.Ignore())
                .ForMember(x => x.SelectShipperSPros, x => x.Ignore())
                .ForMember(x => x.SelectConsigneeSPros, x => x.Ignore())
                .ForMember(x => x.SelectPickupSPros, x => x.Ignore())
                .ForMember(x => x.SelectCommodities, x => x.Ignore())
                .ForMember(x => x.SelectCountriesOfOrigin, x => x.Ignore())
                .ForMember(x => x.SelectCurrencies, x => x.Ignore())
                .ForMember(x => x.SelectDeclaredCargoClasses, x => x.Ignore())
                .ForMember(x => x.SelectMeasureWeights, x => x.Ignore())
                .ForMember(x => x.StatusText, x => x.Ignore());
            CreateMap<SPOrderModel, SPOrder>()
                //.ForMember(x => x.CargoSPServiceCode, x => x.Ignore())
                //.ForMember(x => x.CustomerCode, x => x.Ignore())
                //.ForMember(x => x.PostOfficeToSendCode, x => x.Ignore())
                .ForMember(x => x.CargoPickupMethodText, x => x.Ignore())
                .ForMember(x => x.CargoShippingMethodText, x => x.Ignore())
                .ForMember(x => x.CargoTypeText, x => x.Ignore())
                .ForMember(x => x.CreatedBy, x => x.Ignore())
                .ForMember(x => x.CreatedByUserName, x => x.Ignore())
                .ForMember(x => x.CreatedOnUtc, x => x.Ignore())
                .ForMember(x => x.UpdatedBy, x => x.Ignore())
                .ForMember(x => x.UpdatedByUserName, x => x.Ignore())
                .ForMember(x => x.UpdatedOnUtc, x => x.Ignore())
                .ForMember(x => x.Deleted, x => x.Ignore())
                .ForMember(x => x.DeletedBy, x => x.Ignore())
                .ForMember(x => x.DeletedByUserName, x => x.Ignore())
                .ForMember(x => x.DeletedOnUtc, x => x.Ignore())
                .ForMember(x => x.OrderCargoAddServices, x => x.Ignore())
                .ForMember(x => x.OrderDetails, x => x.Ignore());
            #endregion

            #region SPOrderCargoAddService
            CreateMap<SPOrderCargoAddService, SPOrderCargoAddServiceModel>()
                .ForMember(x => x.CargoAddService, x => x.Ignore());
            CreateMap<SPOrderCargoAddServiceModel, SPOrderCargoAddService>()
                .ForMember(x => x.Order, x => x.Ignore());
            #endregion

            #region SPOrderDetail
            CreateMap<SPOrderDetail, SPOrderDetailModel>()
                .ForMember(x => x.Commodity, x => x.Ignore())
                .ForMember(x => x.CountryOfOrigin, x => x.Ignore())
                .ForMember(x => x.Currency, x => x.Ignore())
                .ForMember(x => x.MeasureWeight, x => x.Ignore())
                .ForMember(x => x.Order, x => x.Ignore());
            CreateMap<SPOrderDetailModel, SPOrderDetail>()
                //.ForMember(x => x.CommodityCode, x => x.Ignore())
                //.ForMember(x => x.CountryOfOriginCode, x => x.Ignore())
                //.ForMember(x => x.CurrencyCode, x => x.Ignore())
                .ForMember(x => x.DeclaredCargoClassText, x => x.Ignore())
                //.ForMember(x => x.MeasureWeightCode, x => x.Ignore())
                .ForMember(x => x.Order, x => x.Ignore())
                .ForMember(x => x.CreatedBy, x => x.Ignore())
                .ForMember(x => x.CreatedByUserName, x => x.Ignore())
                .ForMember(x => x.CreatedOnUtc, x => x.Ignore())
                .ForMember(x => x.UpdatedBy, x => x.Ignore())
                .ForMember(x => x.UpdatedByUserName, x => x.Ignore())
                .ForMember(x => x.UpdatedOnUtc, x => x.Ignore())
                .ForMember(x => x.Deleted, x => x.Ignore())
                .ForMember(x => x.DeletedBy, x => x.Ignore())
                .ForMember(x => x.DeletedByUserName, x => x.Ignore())
                .ForMember(x => x.DeletedOnUtc, x => x.Ignore());
            #endregion

            //add some generic mapping rules
            ForAllMaps(CommonProfile.AllMapsAction);
        }

        public int Order => 2;
    }
}
