using System;
using System.Runtime.InteropServices.Marshalling;
 
namespace Test                       // LeetCode Daily Challenges
{
    public class Solution
    {
        public int PrefixCount(string[] words, string pref)
        {
            int ans = 0;
            var x = words;

            Console.WriteLine(x[0]);
            foreach (var s in words)
            {
                if (s.Length >= pref.Length && s.Substring(0, pref.Length) == pref)
                    ans++;
            }

            return ans;
        }
    }
    internal class Program { 
        static void Main(string[] args) {
            
        }
    }
}