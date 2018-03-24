using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Model
{
    public class Tweet
    {
        public int Id { get; set; }

        public string User { get; set; }

        public DateTime PostDate { get; set; }

        public string Message { get; set; }
    }
}
