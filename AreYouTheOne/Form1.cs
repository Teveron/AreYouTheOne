using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreYouTheOne
{
    public partial class Form1 : Form
    {
        private readonly String[] Boys = { "Adam", "Chris S", "Chris T", "Dillan", "Dre", "Ethan", "Joey", "John", "Ryan", "Wesley" };
        private readonly String[] Girls = { "Amber", "Ashleigh", "Brittany", "Coleysia", "Jacy", "Jessica", "Kayla", "Paige", "Shanley", "Simone" };
        private readonly Int32[] Initial = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //private readonly Int32[] Initial = { 0, 1, 2, 3 };

        private List<Solution> Solutions;
        private List<Solution> ValidSolutions;
        private List<Solution> InvalidSolutions;

        private Int32[,] Probabilities;

        private Int32 CellWidth;
        private Int32 HeaderWidth;


        public Form1()
        {
            InitializeComponent();

            Solutions = new List<Solution>();
            ValidSolutions = new List<Solution>();
            InvalidSolutions = new List<Solution>();
            Probabilities = new Int32[Initial.Length, Initial.Length];

            CellWidth = Boys.Max(name => name.Length) + 2;
            HeaderWidth = Girls.Max(name => name.Length);

            GeneratePermutations(Initial);

            AddMatch(2, 8, false);
            AddPartialSolution(new int[] { 8, 1, 0, 3, 4, 2, 9, 6, 5, 7 }, 2);

            AddMatch(5, 5, false);
            AddPartialSolution(new int[] { 5, 4, 6, 9, 7, 3, 8, 2, 0, 1 }, 4);

            AddMatch(7, 9, false);
            AddPartialSolution(new int[] { 5, 4, 0, 3, 9, 7, 8, 1, 6, 3 }, 2);

            AddMatch(3, 5, false);
            AddPartialSolution(new int[] { 0, 2, 8, 3, 6, 9, 5, 1, 7, 4 }, 2);

            AddMatch(4, 1, false);
            AddMatch(3, 3, true);
            AddPartialSolution(new int[] { 5, 8, 4, 3, 7, 6, 9, 2, 0, 1 }, 5);

            AddMatch(2, 7, true);

            CalculateProbabilities();
            RedrawProbabilities();
        }


        private void AddMatchButton_Click(Object sender, EventArgs e)
        {
            if (AddMatchTextBox.Text != "")
            {
                String[] matchArray = AddMatchTextBox.Text.Split(',');
                AddMatch(Convert.ToInt32(matchArray[0]), Convert.ToInt32(matchArray[1]), Convert.ToBoolean(matchArray[2]));
            }

            AddMatchTextBox.Text = "";

            CalculateProbabilities();
            RedrawProbabilities();
        }

        private void AddPartialSolutionButton_Click(Object sender, EventArgs e)
        {
            if (AddPartialSolutionTextBox.Text != "")
            {
                String[] partialSolutionInfo = AddPartialSolutionTextBox.Text.Split(',');

                Int32[] partialSolution = new Int32[Initial.Length];
                for (Int32 i = 0; i < Initial.Length; i++)
                {
                    int boy = Convert.ToInt32(partialSolutionInfo[i].Substring(0, 1));
                    int girl = Convert.ToInt32(partialSolutionInfo[i].Substring(1, 1));
                    partialSolution[girl] = boy;
                }

                Int32 partialSolutionCorrect = Convert.ToInt32(partialSolutionInfo.Last());

                AddPartialSolution(partialSolution, partialSolutionCorrect);
            }

            AddPartialSolutionTextBox.Text = "";

            CalculateProbabilities();
            RedrawProbabilities();
        }

        private void QuitButton_Click(Object sender, EventArgs e)
        {
            Close();
        }


        private void AddMatch(Int32 boy, Int32 girl, Boolean matched)
        {
            List<Tuple<Solution, Boolean>> solutionValidity = new List<Tuple<Solution, Boolean>>();

            foreach (Solution solution in ValidSolutions)
                solutionValidity.Add(new Tuple<Solution, Boolean>(solution, solution.IsValid(boy, girl, matched)));

            ValidSolutions = new List<Solution>();
            foreach (Solution solution in solutionValidity.Where(s => s.Item2).Select(s => s.Item1))
                ValidSolutions.Add(solution);
        }

        private void AddPartialSolution(Int32[] matches, Int32 correctMatches)
        {
            List<Tuple<Solution, Boolean>> solutionValidity = new List<Tuple<Solution, Boolean>>();

            foreach (Solution solution in ValidSolutions)
                solutionValidity.Add(new Tuple<Solution, Boolean>(solution, solution.IsValid(matches, correctMatches)));

            ValidSolutions = new List<Solution>();
            foreach (Solution solution in solutionValidity.Where(s => s.Item2).Select(s => s.Item1))
                ValidSolutions.Add(solution);
        }


        private void CalculateProbabilities()
        {
            Probabilities = new Int32[Initial.Length, Initial.Length];

            foreach (Solution solution in ValidSolutions)
                for (Int32 i = 0; i < Initial.Length; i++)
                    Probabilities[i, solution.Matches[i]]++;
        }

        private void RedrawProbabilities2()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(' ', HeaderWidth);

            for (Int32 i = 0; i < Initial.Length; i++)
                sb.Append(Boys[i].PadLeft(CellWidth));
            sb.AppendLine();

            for (Int32 i = 0; i < Initial.Length; i++)
            {
                sb.Append(Girls[i].PadLeft(HeaderWidth));

                Int32 total = 0;

                for (Int32 j = 0; j < Initial.Length; j++)
                    total += Probabilities[i, j];

                for (Int32 j = 0; j < Initial.Length; j++)
                    sb.Append(Probabilities[i, j].ToString().PadLeft(CellWidth));

                sb.AppendLine();
            }

            ProbabilitiesLabel.Text = sb.ToString();
        }

        private void RedrawProbabilities()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(' ', HeaderWidth);

            for (Int32 i = 0; i < Initial.Length; i++)
                sb.Append(Boys[i].PadLeft(CellWidth));
            sb.AppendLine();

            for (Int32 i = 0; i < Initial.Length; i++)
            {
                sb.Append(Girls[i].PadLeft(HeaderWidth));

                Int32 total = 0;

                for (Int32 j = 0; j < Initial.Length; j++)
                    total += Probabilities[i, j];

                for (Int32 j = 0; j < Initial.Length; j++)
                    sb.Append(Math.Round((100.0 * Probabilities[i, j] / total), 1).ToString().PadLeft(CellWidth));

                sb.AppendLine();
            }

            ProbabilitiesLabel.Text = sb.ToString();
        }


        #region Generating permutations

        private void GeneratePermutations(Int32[] initial)
        {
            Permute(initial, 0, initial.Length - 1);
        }

        private void Permute(Int32[] i, Int32 l, Int32 r)
        {
            if (l == r)
                ValidSolutions.Add(new Solution(i));
            else
            {
                for (Int32 iI = l; iI <= r; iI++)
                {
                    Swap(i, l, iI);
                    Permute(i, l + 1, r);
                    Swap(i, l, iI);
                }
            }
        }

        public void Swap(Int32[] ia, Int32 i, Int32 j)
        {
            Int32 temp = ia[i];
            ia[i] = ia[j];
            ia[j] = temp;
        }

        #endregion
    }
}
