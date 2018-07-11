using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace PayEasyApi.Models.requestModels
{
    [DataContract(Namespace = "")]
    public class SendModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0}不可為空")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "{0}長度必須為{2}")]
        public string A { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0}不可為空")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "{0}長度必須為{2}")]
        public string B { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "xml不可為空，請檢查格式是否正確")]
        public SendXmlModel C { get; set; }

        //這個類別就是將XML貼上之後所產生的，格式相同就可序列化成字串或反序列化回該類別的物件
        [Serializable]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute("Root", Namespace = "", IsNullable = false)]
        public partial class SendXmlModel
        {
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }
            public string D { get; set; }
        }
    }
}
