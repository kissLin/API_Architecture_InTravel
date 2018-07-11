using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayEasyApi.Models;
using PayEasyApi.Models.requestModels;
using PayEasyApi.Utility.Extensions.SerializerSettings;

namespace PayEasyApi.UI.WebSite.Provider
{
    public class MyValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new StringToXmlValueProvider(controllerContext.HttpContext);
        }

        public class StringToXmlValueProvider : IValueProvider
        {
            private HttpContextBase httpContext;

            public StringToXmlValueProvider(HttpContextBase httpContext)
            {
                this.httpContext = httpContext;
            }

            public bool ContainsPrefix(string prefix)
            {
                return prefix.Contains("C"); //指定如果參數名稱是C，則回傳true
            }

            public ValueProviderResult GetValue(string key)
            {
                if (!ContainsPrefix(key)) { return null; } //參數如果是C，則進行底下轉換
                string _xml = httpContext.Request[key];
                PayEasyApi.Models.requestModels.SendModel.SendXmlModel xml;
                try
                {
                    xml = SerializeTool.DeserializeXml<PayEasyApi.Models.requestModels.SendModel.SendXmlModel>(_xml); //這裡使用一個泛型的XML序列化與反序列化工具，程式碼最後會補上
                }
                catch { xml = null; }
                return new ValueProviderResult(xml, _xml, System.Globalization.CultureInfo.CurrentCulture);
            }
        }
    }
}