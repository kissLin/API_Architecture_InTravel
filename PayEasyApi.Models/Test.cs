using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayEasyApi.Models
{
    public class Test
    {
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Root
        {

            private byte aField;

            private string bField;

            private string cField;

            private string dField;

            /// <remarks/>
            public byte A
            {
                get
                {
                    return this.aField;
                }
                set
                {
                    this.aField = value;
                }
            }

            /// <remarks/>
            public string B
            {
                get
                {
                    return this.bField;
                }
                set
                {
                    this.bField = value;
                }
            }

            /// <remarks/>
            public string C
            {
                get
                {
                    return this.cField;
                }
                set
                {
                    this.cField = value;
                }
            }

            /// <remarks/>
            public string D
            {
                get
                {
                    return this.dField;
                }
                set
                {
                    this.dField = value;
                }
            }
        }


    }
}
