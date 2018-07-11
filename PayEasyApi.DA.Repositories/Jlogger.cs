using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace TableImplement.Models
{
    public class Jlogger
    {
        public ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Jlogger() { }
    }
}