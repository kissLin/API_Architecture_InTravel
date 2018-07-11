using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PayEasyApi.Models.requestModels
{
    [DataContract(Namespace = "")]
    public class ProductTest
    {
        public string NonceStr { get; set; }
    }


}
