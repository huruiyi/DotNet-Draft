using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Token.Models
{
    public class TextAttribute : Attribute
    {
        public TextAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
