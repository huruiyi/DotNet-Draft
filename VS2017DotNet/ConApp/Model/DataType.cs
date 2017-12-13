using System;

namespace ConApp.Model
{
    public class DataType
    {
        public string TypeName { get; set; }

        public int ByteCount { get; set; }

        public object Min { get; set; }

        public object Max { get; set; }

        public Type Type { get; set; }

        public string TypeFullName { get; set; }
    }
}