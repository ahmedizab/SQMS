using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subra.DBManager.Models
{
    public class DBType
    {
        public object Varchar {
            get
            {
                return  (Global.DBProvider== Global.DBProviderType.ORACLE ? (object)OracleType.VarChar : (object)System.Data.SqlDbType.VarChar);
            }
        }

        public object Number
        {
            get
            {
                return OracleType.Number;
            }
        }

        public object DateTime
        {
            get
            {
                return OracleType.DateTime;
            }
        }
    }
}

