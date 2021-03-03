using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreYouTheOne
{
    public class Solution
    {
        public Int32[] Matches { get; private set; }

        public Solution(Int32[] matches)
        {
            Matches = new int[matches.Length];

            for (var i = 0; i < matches.Length; i++)
                Matches[i] = matches[i];
        }

        public Boolean IsValid(Int32 match, Int32 index, Boolean matched)
        {
            return !((match == Matches[index]) ^ matched);
        }

        public Boolean IsValid(Int32[] matches, Int32 correctMatches)
        {
            Int32 sameMatches = 0;

            for (Int32 matchIndex = 0; matchIndex < Matches.Length; matchIndex++)
                if (Matches[matchIndex] == matches[matchIndex])
                    sameMatches++;

            return sameMatches == correctMatches;
        }
    }
}
