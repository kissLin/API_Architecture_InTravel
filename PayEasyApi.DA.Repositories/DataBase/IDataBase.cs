using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace TableImplement.Models.DataBase
{
    interface IDataBase
    {
        DataTable Query(string strSQL, Dictionary<string, object> args);
        int Execute(string strSQL, Dictionary<string, object> args);
        object Retrieve(string strSQL, Dictionary<string, object> args);
    }
}