namespace IChiba.Core.Domain
{
    /// <summary>
    /// Trạng thái đơn hàng
    /// </summary>
    public enum SPOrderStatus
    {
        /// <summary>
        /// Chờ tiếp nhận
        /// </summary>
        PendingReceive = 0,
        /// <summary>
        /// Đã tiếp nhận - Chưa xử lý
        /// </summary>
        ReceivedProcessing = 10,
        /// <summary>
        /// Đã tiếp nhận - Đã xử lý
        /// </summary>
        ReceivedProcessed = 20,
        /// <summary>
        /// Hoàn thành
        /// </summary>
        Complete = 100,
        /// <summary>
        /// Đã hủy
        /// </summary>
        Cancelled = 50,
    }

    /// <summary>
    /// Phân loại hàng hóa khai báo XNK
    /// </summary>
    public enum DeclaredCargoClass
    {
        /// <summary>
        /// Hàng thông thường
        /// </summary>
        General = 0,
        /// <summary>
        /// Tài liệu
        /// </summary>
        Document = 10,
        /// <summary>
        /// Hàng cồng kềnh
        /// </summary>
        HeavyOrOutsized = 110,
        /// <summary>
        /// Hàng dễ vỡ
        /// </summary>
        Fragile = 120,
        /// <summary>
        /// Hàng nguy hiểm
        /// </summary>
        Dangerous = 140,
    }

    /// <summary>
    /// Hình thức vận chuyển hàng hóa XNK
    /// </summary>
    public enum CargoShippingMethod
    {
        /// <summary>
        /// Hàng không
        /// </summary>
        Air = 1,
        /// <summary>
        /// Hàng hải
        /// </summary>
        Ocean = 2,
        /// <summary>
        /// Nội địa
        /// </summary>
        Inland = 3
    }

    /// <summary>
    /// Loại hàng hóa XNK
    /// </summary>
    public enum CargoType
    {
        /// <summary>
        /// Hàng thông thường
        /// </summary>
        General = 0,
        /// <summary>
        /// Hàng TMĐT
        /// </summary>
        ECommerce = 20
    }

    /// <summary>
    /// Hình thức pickup hàng hóa XNK
    /// </summary>
    public enum CargoPickupMethod
    {
        /// <summary>
        /// Thu gom
        /// </summary>
        Consolidation = 10,
        /// <summary>
        /// Tự vận chuyển
        /// </summary>
        SelfShipping = 20
    }

    /// <summary>
    /// Hình thức thanh toán cước vận chuyển Incoterm
    /// </summary>
    public enum IncotermPaymentMethod
    {
        /// <summary>
        /// Người mua trả cước tại cảng nhập/đến
        /// </summary>
        Collect = 10,
        /// <summary>
        /// Shipper trả trước tại cảng xuất/load
        /// </summary>
        Prepaid = 20
    }

    /// <summary>
    /// Tính ngày đến hạn thanh toán dựa vào ngày này
    /// </summary>
    public enum PaymentFromDateType
    {
        InvoiceDate = 10,
        OperationalDate = 20,
        ShipmentDate = 30
    }

    /// <summary>
    /// Loại Warehouse
    /// </summary>
    public enum WarehouseType
    {
        /// <summary>
        /// Ngoại quan
        /// </summary>
        Bonded = 10,
        /// <summary>
        /// Kho tập kết hàng lẻ vào Container
        /// </summary>
        CFS = 20,
        /// <summary>
        /// Kho đầu cuối
        /// </summary>
        Terminal = 30
    }

    /// <summary>
    /// Đơn vị thời gian giao hàng
    /// </summary>
    public enum DeliveryTimeUnit
    {
        /// <summary>
        /// Giờ
        /// </summary>
        Hours = 10,
        /// <summary>
        /// Ngày
        /// </summary>
        Days = 20,
        /// <summary>
        /// Tuần
        /// </summary>
        Weeks = 30,
    }

    /// <summary>
    /// Loại địa chỉ
    /// </summary>
    public enum AddressType
    {
        /// <summary>
        /// Địa chỉ chính
        /// </summary>
        Main = 0,
        /// <summary>
        /// Địa chỉ hóa đơn
        /// </summary>
        Billing = 10,
        /// <summary>
        /// Địa chỉ pickup
        /// </summary>
        PickupDelivery = 20,
        /// <summary>
        /// Địa chỉ khác
        /// </summary>
        Others = 99
    }

    /// <summary>
    /// Loại Entity
    /// </summary>
    public enum EntityType
    {
        Bank = 10,
        BankAccount = 20,
        BankBranch = 30,
        Airline = 40,
        CargoAddService = 50,
        CargoSPService = 55,
        ChargesGroup = 60,
        ChargesType = 70,
        Commodity = 80,
        CommodityGroup = 85,
        Consignee = 90,
        Country = 100,
        CustomAgent = 110,
        DeliveryTime = 120,
        District = 130,
        EventType = 140,
        ForwardingAgent = 150,
        GlobalZone = 160,
        Incoterm = 170,
        MeasureDimension = 180,
        MeasureWeight = 190,
        PackageType = 200,
        PaymentMethod = 210,
        PaymentTerm = 220,
        Port = 230,
        QuantityUnit = 240,
        Shipper = 250,
        ShippingAgent = 260,
        ShippingLine = 270,
        SPCustomer = 280,
        SPMeasurement = 290,
        SPMoveType = 300,
        SPProductType = 310,
        SPSpecialServiceType = 330,
        StateProvince = 340,
        Trucker = 350,
        User = 360,
        VatPercentage = 370,
        VatType = 380,
        Vendor = 390,
        Vessel = 400,
        Ward = 410,
        SPAddress = 420,
        SPBilling = 430,
        Currency = 440,
        GenericAttribute = 450,
        Language = 460,
        LocaleStringResource = 470,
        LocalizedProperty = 480,
        PostOffice = 490,
        Warehouse = 500,
    }

    ///// <summary>
    ///// Partner Type
    ///// </summary>
    //public enum PartnerType
    //{
    //    /// <summary>
    //    /// Agent
    //    /// </summary>
    //    Agent = 10,
    //    /// <summary>
    //    /// Custom Agent
    //    /// </summary>
    //    CustomAgent = 20,
    //    /// <summary>
    //    /// Shipping Agent
    //    /// </summary>
    //    ShippingAgent = 30,
    //    /// <summary>
    //    /// Vendor
    //    /// </summary>
    //    Vendor = 40
    //}

    /// <summary>
    /// Trạng thái kích hoạt
    /// </summary>
    public enum ActiveStatus
    {
        /// <summary>
        /// Kích hoạt
        /// </summary>
        Activated = 1,
        /// <summary>
        /// Ngừng kích hoạt
        /// </summary>
        Deactivated = 2
    }

    /// <summary>
    /// Prepare for Model CRUD
    /// </summary>
    public enum PrepareFor
    {
        Create = 1,
        Details = 2,
        Edit = 3
    }
}
