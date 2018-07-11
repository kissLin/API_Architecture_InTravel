using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableImplement.Models.DataBase;

namespace TableImplement.Models.GetDB
{
    public partial class MsSqlDB : DB, IDataBase
    {
        private Jlogger logger = new Jlogger();
        public MsSqlDB() { }
        public MsSqlDB(string strConn) : base(strConn) { }
    }
}