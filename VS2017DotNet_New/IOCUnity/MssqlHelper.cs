using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCUnity
{
    public class MssqlHelper : ISqlHelper
    {
        public string SqlConnection()
        {
            return "this mssql.";
        }
    }
}
