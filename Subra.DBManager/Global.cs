using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subra.DBManager
{
    public static class Global
    {
        public enum DBProviderType { SQL_SERVER, ORACLE}

        public static DBProviderType DBProvider { get; set; }

    }
}
