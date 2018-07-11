using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PayEasyApi.Models.requestModels.ListTravelTour
{
    [DataContract(Namespace = "")]
    public class ListTravelTour
    {
        [DataMember]
        public string showpage { get; set; }

        [DataMember]
        public string totalpage { get; set; }

        [DataMember]
        public string totalrow { get; set; }

       [XmlElement("OneTravelTour")]
        public OneTravelTour[] OneTravelTour { get; set; }

    }

    public partial class OneTravelTour
    {
        [XmlAttribute]
        public string agency { get; set; }

        [XmlAttribute]
        public int rowcount { get; set; }

        [XmlElement("TourElements")]
        public TourElements TourElements { get; set; }

        [XmlElement("PriceElements")]
        public PriceElements PriceElements { get; set; }
    }

    public partial class PriceElements
    {
        [XmlAttribute]
        public int itemcount { get; set; }

        [XmlElement("item")]
        public Item item { get; set; }
    } 

    public partial class TourElements
    {
        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string group_sn { get; set; }

        [DataMember]
        public string godate { get; set; }

        [DataMember]
        public string tourname { get; set; }

        [DataMember]
        public string tourday { get; set; }

        [DataMember]
        public string tournight { get; set; }

        [DataMember]
        public string departcity { get; set; }

        [DataMember]
        public string departcitycode { get; set; }

        [DataMember]
        public string arrivecity { get; set; }

        [DataMember]
        public string arrivecitycode { get; set; }

        [DataMember]
        public string totalseats { get; set; }

        [DataMember]
        public string oddseates { get; set; }

        [DataMember]
        public string status { get; set; }

    }

    public partial class Item
    {
        [DataMember]
        public string roomname { get; set; }

        [XmlElement("pricedata")]
        public pricedata pricedata { get; set; }
    }

    public partial class pricedata
    {
        [XmlElement("pricedetail")]
        public pricedetail[] pricedetail { get; set; }


    }

    public partial class pricedetail
    {
        [DataMember]
        public string guest { get; set; }

        [DataMember]
        public string price { get; set; }

        [DataMember]
        public string net { get; set; }
    }

}
