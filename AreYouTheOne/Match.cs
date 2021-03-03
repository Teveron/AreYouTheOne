using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreYouTheOne
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class Match
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        public Contestant Contestant1 { get; private set; }
        public Contestant Contestant2 { get; private set; }

        public Match(Contestant contestant1, Contestant contestant2)
        {
            Contestant1 = contestant1;
            Contestant2 = contestant2;
        }

        public override bool Equals(object obj)
        {
            // Check if obj is a Match (versus some other class).
            if (obj is Match match)
            {
                // Check if both contestants are the same.
                return (Contestant1 == match.Contestant1 && Contestant2 == match.Contestant2) ||
                    (Contestant1 == match.Contestant2 && Contestant2 == match.Contestant1);
            }
            else
                return false;
        }
    }
}
