using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;

namespace Codejam
{
    class CreatePairs
    {
        

        int MaximalSum(int[] data)
        {
            
            int sum = 0, leftNegativeInteger=0, leftPositiveInteger=0;
            List<int> dataListOfPositiveIntegers = new List<int>();
            List<int> dataListOfNegativeIntegers = new List<int>();
            List<int> dataListOfZero = new List<int>();
            //Your code goes here
            if (data.Length == 0)
                Console.WriteLine("Enter More than one Value");
            if (data.Length == 1)
                return data[data.Length - 1];
            Array.Sort(data);
            foreach (int element in data)
            {
                if (element > 0)
                {
                    dataListOfPositiveIntegers.Add(element);
                }
                else if (element < 0)
                {
                    dataListOfNegativeIntegers.Add(element);
                }
                else
                {
                    dataListOfZero.Add(element);
                }

            }

            for(int i = 0; i < dataListOfNegativeIntegers.Count; i+=2)
            {
                try
                {
                    sum += (dataListOfNegativeIntegers[i] * dataListOfNegativeIntegers[i + 1]);
                }
                catch (Exception e) {

                    leftNegativeInteger = dataListOfNegativeIntegers[i];
                    sum += leftNegativeInteger * 0;
                    
                }
            }
            for (int i = dataListOfPositiveIntegers.Count-1; i >= 0; i -= 2)
            {
                try
                {
                    if (dataListOfPositiveIntegers.Count == 2)
                        sum += dataListOfPositiveIntegers[i] + dataListOfPositiveIntegers[i - 1];
                    else
                        sum += dataListOfPositiveIntegers[i] * dataListOfPositiveIntegers[i - 1];
                    
                }
                catch (Exception e)
                {
                    leftPositiveInteger = dataListOfPositiveIntegers[i];
                    if (dataListOfZero.Count == 0)
                        sum += dataListOfPositiveIntegers[i] + leftNegativeInteger;
                    else
                        sum += dataListOfPositiveIntegers[i];

                }
            }
            
        return sum;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            CreatePairs createPairs = new CreatePairs();
            do
            {
                int[] data = Array.ConvertAll<string, int>(input.Split(','), delegate (string s) { return Int32.Parse(s); });
                Console.WriteLine(createPairs.MaximalSum(data));
                input = Console.ReadLine();
            } while (input != "*");
        }
        #endregion
    }
}
