using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetcodeProblems
{
    public class MayChallenges
    {
        /*
         First Bad Version - You are a product manager and currently leading a team to develop a new product. 
         Unfortunately, the latest version of your product fails the quality check. 
         Since each version is developed based on the previous version, all the versions after a bad version are also bad.
         Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, 
         which causes all the following ones to be bad.
         You are given an API bool isBadVersion(version) which will return whether version is bad.
         Implement a function to find the first bad version. You should minimize the number of calls to the API.
         
         */
        /* The isBadVersion API is defined in the parent class VersionControl.
        bool IsBadVersion(int version); */
        public int FirstBadVersion(int n)
        {
            //solved using binary search
            int left = 1;
            int right = n;
            while (left < right)
            {
                int mid = left + (right - left) / 2; //(right - left) is for large inputs to prevent overflow
                if (IsBadVersion(mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }
        bool IsBadVersion(int version)
        {
            return true;
        }

        /*You're given strings J representing the types of stones that are jewels, 
         * and S representing the stones you have.  Each character in S is a type of stone you have.  
         * You want to know how many of the stones you have are also jewels.
         * The letters in J are guaranteed distinct, and all characters in J and S are letters. 
         * Letters are case sensitive, so "a" is considered a different type of stone from "A".*/
        public int NumJewelsInStones(string J, string S)
        {
            int numberOfJ = 0;
            char[] stones = S.ToCharArray();
            HashSet<char> jewels = new HashSet<char>(J.ToCharArray());
            foreach (char s in stones)
            {
                if (jewels.Contains(s))
                {
                    numberOfJ++;
                }
            }
            return numberOfJ;
        }

        /*
         Given an arbitrary ransom note string and another string containing letters from all the magazines,
         write a function that will return true if the ransom note can be constructed from the magazines ; 
         otherwise, it will return false.
         Each letter in the magazine string can only be used once in your ransom note.
         Note: You may assume that both strings contain only lowercase letters. canConstruct("a", "b") -> false, canConstruct("aa", "ab") -> false
         canConstruct("aa", "aab") -> true
         */
        public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> ransomByCount = new Dictionary<char, int>();
            foreach (char letter in ransomNote)
            {
                if (!ransomByCount.ContainsKey(letter))
                {
                    ransomByCount.Add(letter, 1);
                }
                else
                {
                    ransomByCount[letter]++;
                }
            }

            foreach (char letter in magazine)
            {
                if (ransomByCount.ContainsKey(letter))
                {
                    ransomByCount[letter]--;
                }
            }
            return !ransomByCount.Values.Any(v => v > 0);
        }

        /*Number complement: 
         * Given a positive integer, output its complement number. The complement strategy is to flip the bits of its binary representation. */
        public int FindComplement(int num)
        {
            int count = 0;

            int j = num;
            while (j != 0)
            {
                j = j / 2;
                count++;
            }
            int ans = Convert.ToInt32(Math.Pow(2, count) - 1);

            return num ^ ans;
        }

        public int FindComplementSolutionTwo(int num)
        {
            int power = 1;
            int res = 0;
            while (num > 0)
            {
                res += (num % 2 ^ 1) * power;
                power <<= 1;
                num >>= 1;
            }
            return res;
        }

        /*Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.*/
        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i])) map[s[i]]++;
                else map.Add(s[i], 1);
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (map[s[i]] == 1) return i;
            }

            return -1;
        }
    }
}
