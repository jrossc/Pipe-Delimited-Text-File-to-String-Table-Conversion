using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_pipe_delimiter_assigner
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = ConvertToTextTable(File.ReadAllLines(@"<Enter path to pipe-delimited text file here>"));
        }

        static string ConvertToTextTable(string[] lines)
        {

            int highestCount = 0;
            string wordWithHighestcount = "";
            StringBuilder sb = new StringBuilder();
            List<string[]> stringArrList = new List<string[]>();

            /* ----------------------------------------------------------------------
             * Get the length of the word with the highest length
             * -----------------------------------------------------------------------
             */

            GetLengthofWordWithHighestLength(lines, ref highestCount, ref wordWithHighestcount, stringArrList);

            /* ----------------------------------------------------------------------
             * If highest length is an odd number, add 1
             * -----------------------------------------------------------------------
             */

            if (highestCount % 2 == 1)
            {
                highestCount = highestCount + 1;
            }

            /* ----------------------------------------------------------------------
             * Start the string builder operation once the highest count is retrieved
             * -----------------------------------------------------------------------
             */

            PerformStringTableConversion(highestCount, sb, stringArrList);

            string final = sb.ToString();
            return final;
        }

        private static void GetLengthofWordWithHighestLength(string[] lines, ref int highestCount, ref string wordWithHighestcount, List<string[]> stringArrList)
        {
            foreach (string line in lines)
            {
                var listLine = line.Split('|');
                stringArrList.Add(listLine);
            }

            foreach (var stringArr in stringArrList)
            {
                foreach (var word in stringArr)
                {
                    int wordLength = word.Length;
                    if (wordLength > highestCount)
                    {
                        wordWithHighestcount = word;
                        highestCount = word.Length;
                    }
                }
            }
        }

        private static void PerformStringTableConversion(int highestCount, StringBuilder sb, List<string[]> stringArrList)
        {
            foreach (var stringArr in stringArrList)
            {
                StringBuilder sbperRow = new StringBuilder();

                foreach (var word in stringArr)
                {
                    int wordLength = word.Length;
                    int trailingSpaceLength = highestCount - wordLength;

                    if (trailingSpaceLength > 0)
                    {
                        for (int i = 1; i <= trailingSpaceLength / 2; i++)
                        {
                            sb.Append(" ");
                            sbperRow.Append(" ");
                        }
                    }

                    sb.Append(word);
                    sbperRow.Append(word);

                    if (trailingSpaceLength > 0)
                    {
                        for (int i = 1; i <= trailingSpaceLength / 2; i++)
                        {
                            sb.Append(" ");
                            sbperRow.Append(" ");
                        }
                    }

                    if (wordLength % 2 == 0)
                    {
                        sb.Append("|");
                        sbperRow.Append("|");
                    }
                    else if (wordLength % 2 == 1)
                    {
                        sb.Append(" |");
                        sbperRow.Append(" |");
                    }
                }

                sb.Append(Environment.NewLine);
                string row = sbperRow.ToString();

                foreach (char s in row)
                {
                    if (s.Equals('|'))
                    {
                        sb.Append("+");
                    }
                    else
                    {
                        sb.Append("-");
                    }
                }
                sb.Append(Environment.NewLine);
            }
        }
    }
}
