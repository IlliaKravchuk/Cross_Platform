using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public static class CalculateFile
    {
        public static void ProcessFiles()
        {
            int[] arr = { 0 };
            int l = 0;
            int count;
            try
            {
                string[] lines = File.ReadAllLines
                    ("INPUT.TXT");
                l = int.Parse(lines[0].Split(' ')[0]);
                count = int.Parse(lines[0].Split(' ')[1]);
                if (count > 100 || l > 3200)
                    throw new Exception("Incorrect input L or N");
                arr = new int[count];
                string[] stringArr = lines[1].Split(' ');
                if (count != stringArr.Length)
                    throw new Exception("Incorrect massive length(massive has less or more values)");
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = int.Parse(stringArr[i]);
                    if (arr[i] > 32767 || arr[i] < -32768)
                        throw new Exception("Incorrect value in massive");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            arr = arr.Distinct().ToArray();
            Array.Sort(arr);
            int coef1 = 2 * l;
            while (coef1 != 0)
            {
                coef1 -= l;
                int i = 0;
                while (arr.Length - 2 > i)
                {
                    int coef2 = coef1 - l;
                    int j = 1;
                    while (j <= arr.Length - 1)
                    {
                        if (arr[i] + coef1 > arr[j] - coef2)
                            if (coef2 == 0)
                                coef2 = l;
                            else
                                break;
                        if (arr[i] + coef1 == arr[j] - coef2)
                        {
                            arr = arr.Where((source, index) => index != j).ToArray();
                            if (coef2 == l)
                                break;
                            coef2 = l;
                        }
                        else
                            j++;
                    }
                    i++;
                }
            }
            File.WriteAllText("OUTPUT.TXT", Convert.ToString(arr.Length-1));
        }
    }
}
