# BinaryTreePath
Solution for finding odd-even paths through a binary tree

Task:

You will have a triangle (which is a binary tree) input below and you need to find the maximum sum of the numbers per the given rules below:
1. You will start from the top and move downwards to an adjacent number as in below.
2. You are only allowed to walk downwards and diagonally.
3. You should walk over the numbers as evens and odds subsequently. Suppose that you are on an even number the next number you walk must be odd, or if you are stepping over an odd number the next number must be even. In other words, the final path would be like
Odd -> even -> odd -> even …
4. You must reach to the bottom of the pyramid.
Your goal is to find the maximum sum if you walk the path. Assume that there is at least 1 valid path to the bottom. If there are multiple paths giving the same sum, you can choose any of them.

Solution:

(Created as C# console application)

1. Create manually or read from file matrix that represents pyramid.

2. Iterate through matrix inserting each in a tree based on previous rules.
  (Node contains int value, its position in pyramid and child nodes if any)
 
3. To find the max path recursively step through nodes based on even/odd rule to create only valid paths saving memory,
  tree object holds Path object that has its value, path and has ability to display its details.
  
4. Once all valid paths are checked, the Max Path displays its data in the console.
