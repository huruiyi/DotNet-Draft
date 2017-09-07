using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 反射实例1.Attr
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class RequiredAttribute : Attribute, Inter.IValidate
    {
        public string ErrorMessage { get; set; }

        public RequiredAttribute()
        {
        }

        public RequiredAttribute(string msg)
        {
            ErrorMessage = msg;
        }

        #region IValidate 成员

        public string Validate(object value)
        {
            if (value == null || value.ToString() == "")
            {
                return this.ErrorMessage;
            }
            return string.Empty;
        }

        #endregion IValidate 成员
    }
}
