using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreYouTheOne
{
    public class Solution
    {
        public Match[] Matches { get; private set; }
        public Boolean IsValid { get; private set; }

        public Solution(Match[] matches)
        {
            Matches = matches;
        }

        public Boolean ValidateMatch(Match match)
        {
            // If this solution is invalid, don't bother checking.
            if (!IsValid)
                return false;

            if (Matches.Contains(match))
                return true;
            else
            {
                IsValid = false;
                return false;
            }
        }

        public Boolean ValidateNonMatch(Match match)
        {
            // If this solution is invalid, don't bother checking.
            if (!IsValid)
                return false;

            if (Matches.Contains(match))
            {
                IsValid = false;
                return false;
            }
            else
                return true;
        }

        public Boolean ValidateSolution(Solution solution, Int32 correctMatches)
        {
            // If this solution is invalid, don't bother checking.
            if (!IsValid)
                return false;

            // Use the Intersect operator to determine what matches are in both solutions
            var matchIntersection = Matches.Intersect(solution.Matches);

            // If matchIntersection == correctMatches, then this solution is valid.
            if (matchIntersection.Count() == correctMatches)
                return true;
            else
            {
                IsValid = false;
                return false;
            }
        }
    }
}
