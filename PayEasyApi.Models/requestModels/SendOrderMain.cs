using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PayEasyApi.Models.requestModels
{
    [DataContract(Namespace = "")]
    public class SendOrderMain
    {
        public TourElements TourElements { get; set; }

        public OrderElements OrderElements { get; set; }

        public TravelElements TravelElements { get; set; }
    }


    public partial class TravelElements 
    {

        [XmlAttribute]
        public int itemcount { get; set; }

        [XmlElement("item")]
        public Item[] item { get; set; }
    }

    public partial class TourElements
    {
        [DataMember]
        public string group_sn { get; set; }

        [DataMember]
        public string godate { get; set; }

        [DataMember]
        public string adultcount { get; set; }

        [DataMember]
        public string childcount { get; set; }

        [DataMember]
        public string childnocount { get; set; }

        [DataMember]
        public string addcount { get; set; }

        [DataMember]
        public string babycount { get; set; }

        [DataMember]
        public string allcount { get; set; }
    }

    public partial class OrderElements
    {
        [DataMember]
        public string supplierorderid { get; set; }

        [DataMember]
        public string supplierstatus { get; set; }

        [DataMember]
        public string orderid { get; set; }

        [DataMember]
        public string sendstatus { get; set; }

        [DataMember]
        public string paystatus { get; set; }

        [DataMember]
        public string sendercompany { get; set; }

        [DataMember]
        public string senderopname { get; set; }

        [DataMember]
        public string sendertel { get; set; }

        [DataMember]
        public string senderfax { get; set; }

        [DataMember]
        public string senderemail { get; set; }

        [DataMember]
        public string account { get; set; }

        [DataMember]
        public string memo { get; set; }
    }


    public partial class Item
    {

        [DataMember]
        public string sequence { get; set; }

        [DataMember]
        public string last_cname { get; set; }

        [DataMember]
        public string first_cname { get; set; }

        [DataMember]
        public string last_ename { get; set; }

        [DataMember]
        public string first_ename { get; set; }

        [DataMember]
        public string id { get; set; }

        [DataMember]
        public string passid { get; set; }

        [DataMember]
        public string birthday { get; set; }

        [DataMember]
        public string roomname { get; set; }

        [DataMember]
        public string guest { get; set; }

        [DataMember]
        public string price { get; set; }

        [DataMember]
        public string net { get; set; }

        [DataMember]
        public string orderprice { get; set; }

        [DataMember]
        public string airportprice { get; set; }

        [DataMember]
        public string visaprice { get; set; }
    }
}
