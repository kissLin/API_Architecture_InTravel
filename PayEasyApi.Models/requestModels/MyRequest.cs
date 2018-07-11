using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayEasyApi.Models.requestModels
{
    [DataContract(Namespace = "")]
    public class MyRequest
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        public OrderElements TourElements { get; set; }
    }

    [DataContract(Namespace = "")]
    public partial class OrderElements
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
}
