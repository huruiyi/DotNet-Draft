using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCUnity
{
    public class MyOtherHelper : IOtherHelper
    {
        private ISqlHelper sql;

        public MyOtherHelper(ISqlHelper sql)
        {
            this.sql = sql;
        }

        public string GetSqlConnection()
        {
            return this.sql.SqlConnection();
        }
    }
}
