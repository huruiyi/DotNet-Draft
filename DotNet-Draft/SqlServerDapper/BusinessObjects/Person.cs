using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlServerDapper.BusinessObjects
{
    public class Person
    {
        public int BusinessEntityId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
