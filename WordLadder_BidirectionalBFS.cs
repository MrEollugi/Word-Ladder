using System;
using System.Collections.Generic;

public class Solution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> wordSet = new HashSet<string>(wordList);
        if (!wordSet.Contains(endWord)) return 0;

        HashSet<string> beginSet = new HashSet<string> { beginWord };
        HashSet<string> endSet = new HashSet<string> { endWord };
        HashSet<string> visited = new HashSet<string>();

        int level = 1;

        while (beginSet.Count > 0 && endSet.Count > 0)
        {
            if (beginSet.Count > endSet.Count)
            {
                var temp = beginSet;
                beginSet = endSet;
                endSet = temp;
            }

            HashSet<string> nextLevel = new HashSet<string>();

            foreach (string word in beginSet)
            {
                char[] chars = word.ToCharArray();

                for (int i = 0; i < chars.Length; i++)
                {
                    char originalChar = chars[i];

                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        if (c == originalChar) continue;

                        chars[i] = c;
                        string nextWord = new string(chars);

                        if (endSet.Contains(nextWord))
                            return level + 1;

                        if (wordSet.Contains(nextWord) && !visited.Contains(nextWord))
                        {
                            nextLevel.Add(nextWord);
                            visited.Add(nextWord);
                        }
                    }

                    chars[i] = originalChar;
                }
            }

            beginSet = nextLevel;
            level++;
        }

        return 0;
    }
}
