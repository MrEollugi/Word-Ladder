using System;
using System.Collections.Generic;

public class Solution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> wordSet = new HashSet<string>(wordList);
        if (!wordSet.Contains(endWord)) return 0;

        Queue<(string word, int level)> queue = new Queue<(string, int)>();
        queue.Enqueue((beginWord, 1));

        while (queue.Count > 0)
        {
            var (word, level) = queue.Dequeue();

            for (int i = 0; i < word.Length; i++)
            {
                char[] chars = word.ToCharArray();
                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (chars[i] == c) continue;

                    chars[i] = c;
                    string nextWord = new string(chars);

                    if (nextWord == endWord)
                        return level + 1;

                    if (wordSet.Contains(nextWord))
                    {
                        queue.Enqueue((nextWord, level + 1));
                        wordSet.Remove(nextWord);
                    }
                }
            }
        }

        return 0;
    }
}