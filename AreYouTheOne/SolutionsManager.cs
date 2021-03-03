using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreYouTheOne
{
    public class SolutionsManager
    {
        public Contestant[] Contestants { get; private set; }
        public Int32 Groups { get; private set; }

        public List<Solution> Solutions { get; private set; }
        public List<Solution> ValidSolutions { get; private set; }

        public SolutionsManager(Contestant[] contestants, Int32 group)
        {
            Contestants = contestants;
            Groups = group;

            Solutions = new List<Solution>();
            ValidSolutions = new List<Solution>();
        }

        #region Generating Solutions

        public void GenerateSolutions()
        {
            if (Groups == Groups.Heterosexual)
                Generate2GroupSolutions();
            else
                Generate1GroupSolutions();

            ValidSolutions = Solutions;
        }

        private void Generate2GroupSolutions()
        {
            // Seperate the contestants by group.
            List<Contestant> group1 = Contestants.Where(c => c.Group == 1).ToList();
            List<Contestant> group2 = Contestants.Where(c => c.Group == 2).ToList();

            // Hold the shorter list constant, and permute through the longer list.
            var shorterList = group1.Count < group2.Count ? group1 : group2;
            var longerList = group1.Count < group2.Count ? group2 : group1;
            Permute(shorterList, longerList, 0, longerList.Count);
        }

        private void Permute(List<Contestant> shorterList, List<Contestant> longerList, Int32 l, Int32 r)
        {
            if (l == r)
            {
                Match[] matches = new Match[shorterList.Count];
                for (Int32 indexShorterList = 0; indexShorterList < shorterList.Count; indexShorterList++)
                    matches[indexShorterList] = new Match(shorterList[indexShorterList], longerList[indexShorterList]);
                Solutions.Add(new Solution(matches));
            }
            else
            {
                for (Int32 indexLongerList = l; indexLongerList <= r; indexLongerList++)
                {
                    Swap(longerList, l, indexLongerList);
                    Permute(shorterList, longerList, l + 1, r);
                    Swap(longerList, l, indexLongerList);
                }
            }
        }

        private void Swap(List<Contestant> contestants, Int32 i, Int32 j)
        {
            var temp = contestants[i];
            contestants[i] = contestants[j];
            contestants[j] = temp;
        }

        private void Generate1GroupSolutions()
        {

        }

        #endregion

        #region Pruning Solutions

        public void AddMatch(Match match)
        {
            foreach (var solution in ValidSolutions)
                solution.ValidateMatch(match);

            List<Solution> remainingValidSolutions = ValidSolutions.Where(s => s.IsValid).ToList();
            ValidSolutions = remainingValidSolutions;
        }

        public void AddNonMatch(Match match)
        {
            foreach (var solution in ValidSolutions)
                solution.ValidateNonMatch(match);

            List<Solution> remainingValidSolutions = ValidSolutions.Where(s => s.IsValid).ToList();
            ValidSolutions = remainingValidSolutions;
        }

        public void AddPartialSolution(Solution partialSolution, Int32 correctMatches)
        {
            foreach (var solution in ValidSolutions)
                solution.ValidateSolution(partialSolution, correctMatches);

            List<Solution> remainingValidSolutions = ValidSolutions.Where(s => s.IsValid).ToList();
            ValidSolutions = remainingValidSolutions;
        }

        #endregion

        public Int32[,] CalculateMatches()
        {

        }

        public IEnumerable<Solution> GetRemainingSolutions()
        {
            return Solutions.Where(s => s.IsValid);
        }
    }
}
