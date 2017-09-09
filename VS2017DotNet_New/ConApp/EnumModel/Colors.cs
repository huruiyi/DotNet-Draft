using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.EnumModel
{
    [Flags]
    public enum Colors
    {
        Red = 1,
        Green = 2,
        Blue = 4,
        Yellow = 8
    };
}
