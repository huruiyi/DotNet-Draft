using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Model
{
    class VolatileDef
    {
        public volatile int i;

        public void Test(int _i)
        {
            i = _i;
        }
    }
}
