using System.Collections.Generic;
using System.Linq;

namespace ConApp.Model
{
    public class PersonClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
    }

    public class IndexClass
    {
        public List<PersonClass> ListPerson { get; set; }

        public PersonClass this[int id]
        {
            get { return ListPerson.First(m => m.Id == id); }
        }
    }
}