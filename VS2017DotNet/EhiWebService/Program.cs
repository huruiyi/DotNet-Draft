using EhiWebService.EhiService;
using System.Xml.Serialization;
using TC.Flight.CommonToolsLibrary.Tools;

namespace EhiWebService
{
    #region 2.1

    #region ggq

    //[XmlRoot("Result")]
    //public class Response
    //{
    //    [XmlElement("Result")]
    //    public Result result { get; set; }
    //}

    //[XmlRoot("Result")]
    //public class Result
    //{
    //    [XmlAttribute("Code")]
    //    public string Code { get; set; }

    //    [XmlText]
    //    public string result { get; set; }
    //}

    #endregion ggq

    //public class GetCitiesListRequest
    //{
    //}

    //[XmlRoot("GetCitiesListResponse")]
    //public class GetCitiesListResponse
    //{
    //    public Result Result { get; set; }

    //    [XmlArray("CitiesList"), XmlArrayItem("City")]
    //    public City[] CitiesList { get; set; }
    //}
    //public class Result
    //{
    //    [XmlAttribute("Code")]
    //    public string Code { get; set; }

    //    [XmlText]
    //    public string Value { get; set; }
    //}

    //[XmlRoot("City")]
    //public class City
    //{
    //    [XmlAttribute("PinYin")]
    //    public string PinYin { get; set; }

    //    [XmlAttribute("HasOutService")]
    //    public string HasOutService { get; set; }

    //    [XmlText]
    //    public string Value { get; set; }
    //}

    #endregion 2.1

    #region 4.1

    [XmlRoot("GetCarTypesListResponse")]
    public class GetCarTypesListResponse
    {
        public Result Result { get; set; }

        [XmlArray("CarTypesList")]
        [XmlArrayItem("CarType")]
        public CarType[] CarTypesList { get; set; }
    }

    public class Result
    {
        [XmlAttribute("Code")]
        public string Code { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    public class CarType
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }

        [XmlAttribute("PicturePath")]
        public string PicturePath { get; set; }

        [XmlAttribute("MaxPassenger")]
        public string MaxPassenger { get; set; }

        [XmlAttribute("IsNewDriverCar")]
        public string IsNewDriverCar { get; set; }

        [XmlAttribute("Carriage")]
        public string Carriage { get; set; }

        [XmlAttribute("Gear")]
        public string Gear { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Brand")]
        public Brand Brand { get; set; }

        [XmlElement("Stock")]
        public Stock Stock { get; set; }

        [XmlElement("GuaranteeFee")]
        public GuaranteeFee GuaranteeFee { get; set; }

        [XmlArray("Prices"), XmlArrayItem("Price")]
        public Price[] Prices { get; set; }
    }

    public class Brand
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    public class Stock
    {
        [XmlAttribute("IsStoreStock")]
        public string IsStoreStock { get; set; }

        [XmlAttribute("StoreId")]
        public string StoreId { get; set; }

        [XmlAttribute("IsCityStock")]
        public string IsCityStock { get; set; }
    }

    public class GuaranteeFee
    {
        [XmlAttribute("Unit")]
        public string Unit { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    public class Price
    {
        [XmlAttribute("Purpose")]
        public string Purpose { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Amount")]
        public Amount Amount { get; set; }
    }

    public class Amount
    {
        [XmlAttribute("Quantity")]
        public string Quantity { get; set; }

        [XmlAttribute("UnitPrice")]
        public string UnitPrice { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    #endregion 4.1

    internal static class Program
    {
        private static void Main()
        {
            #region 2. 地址相关接口

            #region 1)GetCitiesList 读取城市列表

            //var client = new EhiServiceClient();
            //string strs = Serializer.ObjectToXML(new GetCitiesListRequest());

            //var ehiServiceRequestData = new EhiServiceRequestData
            //{
            //    UserName = "100001",
            //    Password = "123456",
            //    RequestContent = strs
            //    //RequestContent = @"<GetCitiesListRequest></GetCitiesListRequest>"
            //};
            //string str = client.GetCitiesList(ehiServiceRequestData);
            //GetCitiesListResponse getCitiesListResponse = Serializer.XMLToObject<GetCitiesListResponse>(str);
            //client.Close();

            #region XmlDocument取值

            //XmlDocument xmlDocument = new XmlDocument();
            //xmlDocument.LoadXml(str);
            //XmlNodeList xmlNodeList = xmlDocument.SelectNodes("GetCitiesListResponse/Result");
            //string resultText = xmlNodeList[0].InnerText;
            //string code = xmlNodeList[0].Attributes["Code"].Value;
            //foreach (XmlNode node in xmlNodeList)
            //{
            //    string resultInnerText = node.InnerText;
            //    string s = node.Attributes[0].Value;
            //}
            //XmlNodeList xmlNode = xmlDocument.SelectSingleNode("GetCitiesListResponse/CitiesList").ChildNodes;
            //for (int i = 0; i < xmlNode.Count; i++)
            //{
            //    string text = xmlNode[i].InnerText;
            //    string pinyin = xmlNode[i].Attributes["PinYin"].Value;
            //    string hasOutService = xmlNode[i].Attributes["HasOutService"].Value;
            //}

            #endregion XmlDocument取值

            #endregion 1)GetCitiesList 读取城市列表

            #region 2)GetServiceAreasList 读取送车上门区域列表

            //                        var client = new EhiServiceClient();
            //                        var ehiServiceRequestData = new EhiServiceRequestData
            //                        {
            //                            UserName = "100001",
            //                            Password = "123456",
            //                            RequestContent = @"<GetServiceAreasListRequest>
            //                                                                <City Id='1'>上海</City>
            //                                                              </GetServiceAreasListRequest>"
            //                        };
            //                        string str = client.GetServiceAreasList(ehiServiceRequestData);
            //                        client.Close();

            #endregion 2)GetServiceAreasList 读取送车上门区域列表

            #region 3)GetDistrictsList 读取行政区列表

            //            var client = new EhiServiceClient();
            //            var ehiServiceRequestData = new EhiServiceRequestData
            //            {
            //                UserName = "100001",
            //                Password = "123456",
            //                RequestContent = @"<GetDistrictsListRequest>
            //                                                    <City Id='1'>上海</City>
            //                                                  </GetDistrictsListRequest>"
            //            };
            //            string str = client.GetDistrictsList(ehiServiceRequestData);
            //            client.Close();

            #endregion 3)GetDistrictsList 读取行政区列表

            #region 4)GetStoresList 读取门店列表

            var client0 = new EhiServiceClient();
            var ehiServiceRequestData0 = new EhiServiceRequestData
            {
                UserName = "100001",
                Password = "123456",
                RequestContent = @"<GetStoresListRequest>
                                                <City>上海</City>
                                                <District>徐汇区</District>
                                                <BusinessDistrict>徐家汇</BusinessDistrict>
                                                <Store Id='3'/>
                                                </GetStoresListRequest>"
            };
            string str0 = client0.GetStoresList(ehiServiceRequestData0);
            client0.Close();

            #endregion 4)GetStoresList 读取门店列表

            #endregion 2. 地址相关接口

            #region 3. 用户相关接口  ？

            #region 1)RegisterUser 注册新用户（驾驶证格式问题？）

            //            var client = new EhiServiceClient();
            //            var ehiServiceRequestData = new EhiServiceRequestData
            //            {
            //                UserName = "100001",
            //                Password = "123456",
            //                RequestContent = @"
            //                                                                    <RegisterUserRequest>
            //                                                                        <User>
            //                                                                        <MobilePhoneNo>13911111111</MobilePhoneNo>
            //                                                                        <Password>111111</Password>
            //                                                                        <Name>测试</Name>
            //                                                                        <Gendor>男</Gendor>
            //                                                                        <IdCard Type='1'>34157894612345691</IdCard>
            //                                                                        <Email>test@1hai.cn</Email>
            //                                                                        <DrivingLicense>
            //                                                                                <LicenseNo>310010360000</LicenseNo>
            //                                                                                <LicenseFileNo>430103198801270010</LicenseFileNo>
            //                                                                                <IssueDate>2009-08-03</IssueDate>
            //                                                                        </DrivingLicense>
            //                                                                        </User>
            //                                                                    </RegisterUserRequest>"
            //            };
            //            string str = client.RegisterUser(ehiServiceRequestData);
            //            client.Close();

            #endregion 1)RegisterUser 注册新用户（驾驶证格式问题？）

            #region 2)UserLogin  获取用户信息(参数格式错误)

            //            var client = new EhiServiceClient();
            //            var ehiServiceRequestData = new EhiServiceRequestData
            //            {
            //                UserName = "100001",
            //                Password = "123456",
            //                RequestContent = @"<GetUserInfoRequest>
            //                                                    <User>
            //                                                    <UserMark>15311111111</UserMark>
            //                                                    </User >
            //                                                 </GetUserInfoRequest>"
            //            };
            //            string str = client.UserLogin(ehiServiceRequestData);
            //            client.Close();

            #endregion 2)UserLogin  获取用户信息(参数格式错误)

            #endregion 3. 用户相关接口  ？

            #region 4. 车型相关接口

            #region 1)GetCarTypesList 读取车型列表

            var client = new EhiServiceClient();
            var ehiServiceRequestData = new EhiServiceRequestData
            {
                UserName = "100001",
                Password = "123456",
                RequestContent = @"<GetCarTypesListRequest>
                                                                                                    <QueryBuilder HasBaseRateDetails='N'>
                                                                                                    <PickUpDateTime>2015-04-29 18:00 </PickUpDateTime>
                                                                                                    <ReturnDateTime>2015-04-30 08:00 </ReturnDateTime>
                                                                                                    <Search By='Store'>
                                                                                                    <City Id='1'>上海</City>
                                                                                                    <PickUpStoreList>
                                                                                                    <Store Id='3'/>
                                                                                                    <Store Id='183'/>
                                                                                                    </PickUpStoreList>
                                                                                                    </Search>
                                                                                                    </QueryBuilder>
                                                                                                </GetCarTypesListRequest>"
            };
            string str = client.GetCarTypesList(ehiServiceRequestData);
            var obj = Serializer.XMLToObject<GetCarTypesListResponse>(str);
            client.Close();

            #endregion 1)GetCarTypesList 读取车型列表

            #endregion 4. 车型相关接口

            #region 5. 订单相关接口

            #region 1)CalculateOrderPrice 计算订单价格 计算订单价格

            //            var client = new EhiServiceClient();
            //            var ehiServiceRequestData = new EhiServiceRequestData
            //            {
            //                UserName = "100001",
            //                Password = "123456",
            //                RequestContent = @"
            //<CalculateOrderPriceRequest>
            //<User>
            //<IdCard Type='1'>34157894612345691</IdCard>
            //</User>
            //<Order>
            //<PickUpDateTime>2014-07-16 18:00</PickUpDateTime>
            //<ReturnDateTime>2014-07-18 08:00</ReturnDateTime>
            //<PickupAddress IsOutService='N'>
            //<City Id='1'>上海</City>
            //<Store Id='3'/>
            //</PickupAddress>
            //<ReturnAddress IsOutService='Y'>
            //<City Id='1'>上海</City>
            //<Store Id='0'/>
            //<OutService>
            //<Area Id='1'>内环以内</Area>
            //<Address>漕溪北路88号</Address>
            //</OutService>
            //</ReturnAddress>
            //<CarType Id='23'/>
            //<AddedServices>
            //<AddedService Id='203' />
            //<AddedService Id='208'/>
            //</AddedServices>
            //<Discounts>
            //<Discount Id ='183' />
            //</Discounts >
            //</Order>
            //</CalculateOrderPriceRequest>"
            //            };
            //            string str = client.CalculateOrderPrice(ehiServiceRequestData);
            //            client.Close();

            #endregion 1)CalculateOrderPrice 计算订单价格 计算订单价格

            #region 2)CreateOrder 新建订单

            //            var client = new EhiServiceClient();
            //            var ehiServiceRequestData = new EhiServiceRequestData
            //            {
            //                UserName = "100001",
            //                Password = "123456",
            //                RequestContent = @"
            //                                        <CreateOrderRequest>
            //                                        <User>
            //                                        <IdCard Type='1'>34157894612345691</IdCard>
            //                                        </User>
            //                                        <Order>
            //                                        <PickUpDateTime>2014-07-16 08:00</PickUpDateTime>
            //                                        <ReturnDateTime>2014-07-18 08:00</ReturnDateTime>
            //                                        <PickupAddress IsOutService='N'>
            //                                        <City Id='1'>上海</City>
            //                                        <Store Id='3'/>
            //                                        </PickupAddress>
            //                                        <ReturnAddress IsOutService='N'>
            //                                        <City Id='1'>上海</City>
            //                                        <Store Id='0'/>
            //                                        <OutService>
            //                                        <Area Id='1'>内环以内</Area>
            //                                        <Address>漕溪北路88号</Address>
            //                                        </OutService>
            //                                        </ReturnAddress>
            //                                        <CarType Id='23'/>
            //                                        <AddedServices>
            //                                        <AddedService Id='203' />
            //                                        <AddedService Id='208'/>
            //                                        </AddedServices>
            //                                        <Discounts>
            //                                        <Discount Id ='183' />
            //                                        </Discounts>
            //                                        <Payment Type='S'/>
            //                                        <Invoice>
            //                                        <Title>测试</Title>
            //                                        <Province>上海</Province>
            //                                        <City>徐汇区</City>
            //                                        <Address>漕溪北路88号2601室</Address>
            //                                        <Recipient>测试</Recipient>
            //                                        <ZipCode>200000</ZipCode>
            //                                        </Invoice>
            //                                        <ChannelOrderId>1234567890</ChannelOrderId>
            //                                        </Order>
            //                                        </CreateOrderRequest>"
            //            };
            //            string str = client.CreateOrder(ehiServiceRequestData);
            //            client.Close();

            #endregion 2)CreateOrder 新建订单

            #region 3)CancleOrder 取消订单

            //            var client = new EhiServiceClient();
            //            var ehiServiceRequestData = new EhiServiceRequestData
            //            {
            //                UserName = "100001",
            //                Password = "123456",
            //                RequestContent = @"<CancleOrderRequest>
            //                                                        <Order>
            //                                                        <Id>1101123456</Id>
            //                                                        </Order>
            //                                                 </CancleOrderRequest>"

            //            };
            //            string str = client.CancleOrder(ehiServiceRequestData);
            //            client.Close();

            #endregion 3)CancleOrder 取消订单

            #region 4)GetOrdersList 读取订单列表 读取订单列表

            //            var client = new EhiServiceClient();
            //            var ehiServiceRequestData = new EhiServiceRequestData
            //            {
            //                UserName = "100001",
            //                Password = "123456",
            //                RequestContent = @"<GetOrdersListRequest>
            //                                                    <User>
            //                                                    <IdCard Type='1'>34157894612345691</IdCard>
            //                                                    </User>
            //                                                    <Order>
            //                                                    <Status Code='R'>预约中</Status>
            //                                                    </Order>
            //                                                    <PickUpDateTime Max="" Min=""/>
            //                                                    <BookingDateTime Max="" Min=""/>
            //                                                    <Paging PageSize="" CurrentPage=""/>
            //                                                    </GetOrdersListRequest>"

            //            };
            //            string str = client.GetOrdersList(ehiServiceRequestData);
            //            client.Close();

            #endregion 4)GetOrdersList 读取订单列表 读取订单列表

            #region 5) 读取订单详情 读取订单详情

            //            var client = new EhiServiceClient();
            //            var ehiServiceRequestData = new EhiServiceRequestData
            //            {
            //                UserName = "100001",
            //                Password = "123456",
            //                RequestContent = @"<GetOrderDetailRequest>
            //                                                    <Order>
            //                                                    <Id>1100123456</Id>
            //                                                    </Order>
            //                                                 </GetOrderDetailRequest>"

            //            };
            //            string str = client.GetOrderDetail(ehiServiceRequestData);
            //            client.Close();

            #endregion 5) 读取订单详情 读取订单详情

            #region 6) 支付结果通知 支付结果通知

            //            var client = new EhiServiceClient();
            //            var ehiServiceRequestData = new EhiServiceRequestData
            //            {
            //                UserName = "100001",
            //                Password = "123456",
            //                RequestContent = @"<GetOrderDetailRequest>
            //                                                    <Order>
            //                                                    <Id>1100123456</Id>
            //                                                    </Order>
            //                                                 </GetOrderDetailRequest>"

            //            };
            //            string str = client.GetOrderDetail(ehiServiceRequestData);
            //            client.Close();

            #endregion 6) 支付结果通知 支付结果通知

            #endregion 5. 订单相关接口
        }
    }
}