namespace IChiba.Caching
{
    public static partial class MasterCacheKeys
    {
        public static class Airlines
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.airline.all-{0}";
            public static string PrefixCacheKey => "ichiba.airline.";
        }

        public static class Banks
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.bank.all-{0}";
            public static string PrefixCacheKey => "bank.bank.";
        }

        public static class BankAccounts
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.bankaccount.all-{0}";
            public static string PrefixCacheKey => "ichiba.bankaccount.";
        }

        public static class BankBranches
        {
            // {0}: bankId
            public static string ByBankIdCacheKey => "ichiba.bankbranch.bybankid-{0}";
            public static string PrefixCacheKey => "ichiba.bankbranch.";
        }

        public static class CargoAddServices
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.cargoaddservice.all-{0}";
            public static string PrefixCacheKey => "bank.cargoaddservice.";
        }

        public static class CargoSPServices
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.cargospservice.all-{0}";
            public static string PrefixCacheKey => "bank.cargospservice.";
        }

        public static class ChargesGroups
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.chargesgroup.all-{0}";
            public static string PrefixCacheKey => "bank.chargesgroup.";
        }

        public static class ChargesTypes
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.chargestype.all-{0}";
            public static string PrefixCacheKey => "bank.chargestype.";
        }

        public static class Commodities
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.commodity.all-{0}";
            public static string PrefixCacheKey => "ichiba.commodity.";
        }

        public static class CommodityGroups
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.commoditygroup.all-{0}";
            public static string PrefixCacheKey => "ichiba.commoditygroup.";
        }

        public static class Consignees
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.consignee.all-{0}";
            public static string PrefixCacheKey => "ichiba.consignee.";
        }

        public static class Countries
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.country.all-{0}";
            public static string PrefixCacheKey => "ichiba.country.";
        }

        public static class Currencies
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.currency.all-{0}";
            public static string PrefixCacheKey => "ichiba.currency.";
        }

        public static class CustomAgents
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.customagent.all-{0}";
            public static string PrefixCacheKey => "ichiba.customagent.";
        }

        public static class DeliveryTimes
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.deliverytime.all-{0}";
            public static string PrefixCacheKey => "ichiba.deliverytime.";
        }

        public static class Districts
        {
            // {0}: stateProvinceId
            public static string ByStateProvinceIdCacheKey => "ichiba.district.bystateprovinceid-{0}";
            public static string PrefixCacheKey => "ichiba.district.";
        }

        public static class EventTypes
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.eventtype.all-{0}";
            public static string PrefixCacheKey => "ichiba.eventtype.";
        }

        public static class ForwardingAgents
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.forwardingagent.all-{0}";
            public static string PrefixCacheKey => "ichiba.forwardingagent.";
        }

        public static class GlobalZones
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.globalzone.all-{0}";
            public static string PrefixCacheKey => "ichiba.globalzone.";
        }

        public static class Incoterms
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.incoterm.all-{0}";
            public static string PrefixCacheKey => "ichiba.incoterm.";
        }

        public static class MeasureDimensions
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.measuredimension.all-{0}";
            public static string PrefixCacheKey => "ichiba.measuredimension.";
        }

        public static class MeasureWeights
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.measureweight.all-{0}";
            public static string PrefixCacheKey => "ichiba.measureweight.";
        }

        public static class PackageTypes
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.packagetype.all-{0}";
            public static string PrefixCacheKey => "ichiba.packagetype.";
        }

        public static class PaymentMethods
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.paymentmethod.all-{0}";
            public static string PrefixCacheKey => "ichiba.paymentmethod.";
        }

        public static class PaymentTerms
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.paymentterm.all-{0}";
            public static string PrefixCacheKey => "ichiba.paymentterm.";
        }

        public static class Ports
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.port.all-{0}";
            public static string PrefixCacheKey => "ichiba.port.";
        }

        public static class PostOffices
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.postoffice.all-{0}";
            public static string PrefixCacheKey => "ichiba.postoffice.";
        }

        public static class Shippers
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.shipper.all-{0}";
            public static string PrefixCacheKey => "ichiba.shipper.";
        }

        public static class ShippingAgents
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.shippingagent.all-{0}";
            public static string PrefixCacheKey => "ichiba.shippingagent.";
        }

        public static class ShippingLines
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.shippingline.all-{0}";
            public static string PrefixCacheKey => "ichiba.shippingline.";
        }

        public static class SPAddresses
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.spaddress.all-{0}";
            public static string PrefixCacheKey => "ichiba.spaddress.";
        }

        public static class SPCustomers
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.spcustomer.all-{0}";
            public static string PrefixCacheKey => "ichiba.spcustomer.";
        }

        public static class SPMeasurements
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.spmeasurement.all-{0}";
            public static string PrefixCacheKey => "ichiba.spmeasurement.";
        }

        public static class SPMoveTypes
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.spmovetype.all-{0}";
            public static string PrefixCacheKey => "ichiba.spmovetype.";
        }

        public static class SPProductTypes
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.spproducttype.all-{0}";
            public static string PrefixCacheKey => "ichiba.spproducttype.";
        }

        public static class SPSpecialServiceTypes
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.spspecialservicetype.all-{0}";
            public static string PrefixCacheKey => "ichiba.spspecialservicetype.";
        }

        public static class StateProvinces
        {
            // {0}: countryId
            public static string ByCountryIdCacheKey => "ichiba.stateprovince.bycountryid-{0}";
            public static string PrefixCacheKey => "ichiba.stateprovince.";
        }

        public static class Truckers
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.trucker.all-{0}";
            public static string PrefixCacheKey => "ichiba.trucker.";
        }

        public static class VatPercentages
        {
            // {0}: vatTypeId
            public static string ByCountryIdCacheKey => "ichiba.vatpercentage.byvattypeid-{0}";
            public static string PrefixCacheKey => "ichiba.vatpercentage.";
        }

        public static class VatTypes
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.vattype.all-{0}";
            public static string PrefixCacheKey => "ichiba.vattype.";
        }

        public static class Vendors
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.vendor.all-{0}";
            public static string PrefixCacheKey => "ichiba.vendor.";
        }

        public static class Vessels
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.vessel.all-{0}";
            public static string PrefixCacheKey => "ichiba.vessel.";
        }

        public static class Wards
        {
            // {0}: districtId
            public static string ByDistrictIdCacheKey => "ichiba.ward.bydistrictid-{0}";
            public static string PrefixCacheKey => "ichiba.ward.";
        }

        public static class Warehouses
        {
            // {0}: showHidden
            public static string AllCacheKey => "ichiba.warehouse.all-{0}";
            public static string PrefixCacheKey => "ichiba.warehouse.";
        }

        #region System

        public static class Settings
        {
            /// <summary>
            /// Gets a key for caching
            /// </summary>
            public static string AllAsDictionaryCacheKey => "ichiba.setting.all.as.dictionary";

            /// <summary>
            /// Gets a key for caching
            /// </summary>
            public static string AllCacheKey => "ichiba.setting.all";

            /// <summary>
            /// Gets a key pattern to clear cache
            /// </summary>
            public static string PrefixCacheKey => "ichiba.setting.";
        }

        #endregion
    }
}
