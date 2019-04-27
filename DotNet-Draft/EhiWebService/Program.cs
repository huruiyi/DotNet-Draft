using System.Xml.Serialization;

namespace EhiWebService
{
    #region 2.1

    #region ggq

    [XmlRoot("Result")]
    public class Response
    {
        [XmlElement("Result")]
        public Result result { get; set; }
    }

    [XmlRoot("Result")]
    public class Result
    {
        [XmlAttribute("Code")]
        public string Code { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    #endregion ggq

    [XmlRoot("GetCitiesListResponse")]
    public class GetCitiesListResponse
    {
        public Result Result { get; set; }

        [XmlArray("CitiesList"), XmlArrayItem("City")]
        public City[] CitiesList { get; set; }
    }

    [XmlRoot("City")]
    public class City
    {
        [XmlAttribute("PinYin")]
        public string PinYin { get; set; }

        [XmlAttribute("HasOutService")]
        public string HasOutService { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

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

    public class CarType
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }

        [XmlAttribute("PicturePath")]
        public string PicturePath { get; set; }

        [XmlAttribute("MaxPassenger")]
        public string MaxPassenger { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Brand")]
        public Brand Brand { get; set; }

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
        }
    }
}