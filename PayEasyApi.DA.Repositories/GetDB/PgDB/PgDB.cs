using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableImplement.Models.DataBase;

namespace TableImplement.Models.GetDB
{
    public partial class PgDB : DB, IDataBase
    {
        private Jlogger logger=new Jlogger();
        public PgDB() { }
        public PgDB(string strConn) : base(strConn) { }
    }
}