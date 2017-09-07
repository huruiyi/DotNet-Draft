using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 反射实例1.Inter;

namespace 反射实例1.Attr
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CompareAttribute : Attribute, IValidationSuper
    {
        public CompareAttribute(string otherProperty)
        {
            OtherProperty = otherProperty;
        }

        public string OtherProperty { get; set; }

        public string ErrorMessage { get; set; }

        #region IValidationSuper 成员

        public string Validate(object obj, string propName)
        {
            Type type = obj.GetType();
            object prop1Value = type.InvokeMember(propName, System.Reflection.BindingFlags.GetProperty, null, obj, null);
            object prop2Value = type.InvokeMember(OtherProperty, System.Reflection.BindingFlags.GetProperty, null, obj, null);
            if (prop1Value != null && prop2Value != null)
            {
                if (prop1Value.ToString() == prop2Value.ToString())
                {
                    return string.Empty;
                }
                else
                {
                    return ErrorMessage;
                }
            }
            return prop1Value.Equals(prop2Value) ? string.Empty : ErrorMessage;
        }

        #endregion IValidationSuper 成员
    }
}
