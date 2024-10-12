using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class CalculateFile
    {
        public static void ProcessFiles()
        {
            var input = File.ReadAllLines("INPUT.TXT");

            var numbers = input[0].Split().Select(int.Parse).ToArray();
            int n = numbers.Length;

            int[,] dp = new int[n, n];


            for (int i = 0; i < n; i++)
            {
                dp[i, i] = numbers[i];
            }

            for (int len = 2; len <= n; len++)
            {
                for (int i = 0; i <= n - len; i++)
                {
                    int j = i + len - 1;
                    dp[i, j] = Math.Max(
                        numbers[i] - dp[i + 1, j],  
                        numbers[j] - dp[i, j - 1]   
                    );
                }
            }

            int result;
            if (dp[0, n - 1] > 0)
                result = 1;
            else if (dp[0, n - 1] < 0)
                result = 2;
            else
                result = 0;

            File.WriteAllText("OUTPUT.TXT", result.ToString());
        }
    }
}
