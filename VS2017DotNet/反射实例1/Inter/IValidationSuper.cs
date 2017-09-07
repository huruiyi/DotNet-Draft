using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 反射实例1.Inter
{
    public interface IValidationSuper
    {
        string Validate(object obj, string propName);
    }
}
