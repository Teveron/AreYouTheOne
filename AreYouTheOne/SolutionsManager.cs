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
            Solutions = new List<Solution>();

            if (Groups == 1)
                Generate1GroupSolutions();
            else
                Generate2GroupSolutions();

            ValidSolutions = Solutions;
        }

        private void Generate1GroupSolutions()
        {
            Permute(Contestants, 0, Contestants.Length);
        }

        private void Permute(Contestant[] contestants, Int32 l, Int32 r)
        {
            if (l == r)
            {
                Match[] matches = new Match[contestants.Length / 2];
                for (Int32 indexContestants = 0; indexContestants < contestants.Length; indexContestants++)
                    matches[indexContestants] = new Match(contestants[indexContestants], contestants[indexContestants + 1]);
                Solutions.Add(new Solution(matches));
            }
            else
            {
                for (Int32 indexLongerList = l; indexLongerList <= r; indexLongerList++)
                {
                    Swap(contestants, l, indexLongerList);
                    Permute(contestants, contestants, l + 2, r);
                    Swap(contestants, l, indexLongerList);
                }
            }
        }

        private void Generate2GroupSolutions()
        {
            // Seperate the contestants by group.
            Contestant[] group1 = Contestants.Where(c => c.Group == 1).ToArray();
            Contestant[] group2 = Contestants.Where(c => c.Group == 2).ToArray();

            // Hold the shorter list constant, and permute through the longer list.
            var shorterList = group1.Length < group2.Length ? group1 : group2;
            var longerList = group1.Length < group2.Length ? group2 : group1;
            Permute(shorterList, longerList, 0, longerList.Length);
        }

        private void Permute(Contestant[] shorterList, Contestant[] longerList, Int32 l, Int32 r)
        {
            if (l == r)
            {
                Match[] matches = new Match[shorterList.Length];
                for (Int32 indexShorterList = 0; indexShorterList < shorterList.Length; indexShorterList++)
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

        private void Swap(Contestant[] contestants, Int32 i, Int32 j)
        {
            var temp = contestants[i];
            contestants[i] = contestants[j];
            contestants[j] = temp;
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

        //public Int32[,] CalculateMatches()
        //{

        //}

        public IEnumerable<Solution> GetRemainingSolutions()
        {
            return Solutions.Where(s => s.IsValid);
        }
    }
}
