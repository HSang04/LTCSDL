using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class Sup
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Sup() { }

        public Sup(string id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}
