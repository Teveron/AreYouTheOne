using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreYouTheOne
{
    public class Contestant
    {
        public String Name { get; private set; }
        public Int32 Group { get; private set; }

        public Contestant(String name, Int32 group)
        {
            Name = name;
            Group = group;
        }
    }
}
