﻿using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
