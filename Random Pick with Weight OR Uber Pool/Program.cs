using System;

namespace Random_Pick_with_Weight_OR_Uber_Pool
{
    class Program
    {
        static void Main(string[] args)
        {
            var w = new int[] { 1, 3 };
            Solution solution = new Solution(w);
            Console.WriteLine(solution.PickIndex());
            Console.WriteLine(solution.PickIndex());
            Console.WriteLine(solution.PickIndex());
            Console.WriteLine(solution.PickIndex());
            Console.WriteLine(solution.PickIndex());
        }
    }

    // time complexity commented on below.
    public class Solution
    {
        int[] sums;
        int sum = 0;
        // time complexity = O(N)
        public Solution(int[] w)
        {
            sums = new int[w.Length];
            for(int i = 0; i < w.Length; i++)
            {
                sum += w[i];
                sums[i] = sum;
            }
        }

        // time complexity = O(logN)
        public int PickIndex()
        {
            Random rand = new Random();
            double target = sum * rand.NextDouble();
            // perform binary search
            int low = 0;
            int high = sums.Length - 1;
            while (low < high)
            {
                int mid = (high - low) / 2 + low;
                if (sums[mid] < target)
                    low = mid + 1;
                else 
                    high = mid;
            }

            return low;
        }
    }
}
