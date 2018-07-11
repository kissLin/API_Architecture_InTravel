using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace PayEasyApi.Models.requestModels
{
    [DataContract(Namespace = "")]
    public class PackageModal
    {
        public string OpenId { get; set; }
        public string AppId { get; set; }
        public string IsSubscribe { get; set; }
        public string ProductId { get; set; }
        public string TimeStamp { get; set; }
        public string NonceStr { get; set; }
        public string AppSignature { get; set; }
        public string SignMethod { get; set; }
    }
}
