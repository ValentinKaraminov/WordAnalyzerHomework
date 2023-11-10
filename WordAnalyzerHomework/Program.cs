using System.Text;

namespace WordAnalyzerHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static string RemovePunctuation(string word)
            {
                StringBuilder cleanWord = new StringBuilder();
                foreach (char c in word)
                {
                    if (char.IsLetterOrDigit(c))
                    {
                        cleanWord.Append(c);
                    }
                }
                return cleanWord.ToString();
            }
            static string[] GetWords(string text)
            {
                string[] parts = text.Split(new[] { ' ', '\t', '\n', '\r', '\f', '\v' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> validWords = new List<string>();
                foreach (var part in parts)
                {
                    string cleanedWord = RemovePunctuation(part);
                    if (cleanedWord.Length >= 3)
                    {
                        validWords.Add(cleanedWord);
                    }
                }
                return validWords.ToArray();
            }
            static int CountWords(string text)
            {
                string[] words = GetWords(text);
                return words.Length;
            }
            static string FindShortestWord(string text)
            {
                string[] words = GetWords(text);
                if (words.Length == 0)
                    return string.Empty;

                string shortestWord = words[0];
                foreach (var word in words)
                {
                    if (word.Length < shortestWord.Length)
                    {
                        shortestWord = word;
                    }
                }
                return shortestWord;
            }
            static string FindLongestWord(string text)
            {
                string[] words = GetWords(text);
                if (words.Length == 0)
                    return string.Empty;

                string longestWord = words[0];
                foreach (var word in words)
                {
                    if (word.Length > longestWord.Length)
                    {
                        longestWord = word;
                    }
                }
                return longestWord;
            }
            static double CalculateAverageWordLength(string text)
            {
                string[] words = GetWords(text);
                if (words.Length == 0)
                    return 0.0;

                double totalLength = 0;
                foreach (var word in words)
                {
                    totalLength += word.Length;
                }
                return totalLength / words.Length;
            }
            static List<string> FindMostCommonWords(string text, int count)
            {
                string[] words = GetWords(text);
                Dictionary<string, int> wordCounts = new Dictionary<string, int>();
                foreach (var word in words)
                {
                    if (wordCounts.ContainsKey(word))
                    {
                        wordCounts[word]++;
                    }
                    else
                    {
                        wordCounts[word] = 1;
                    }
                }
                List<string> mostCommonWords = new List<string>();
                for (int i = 0; i < count; i++)
                {
                    string mostCommonWord = null;
                    int highestCount = 0;
                    foreach (var kvp in wordCounts)
                    {
                        if (kvp.Value > highestCount && !mostCommonWords.Contains(kvp.Key))
                        {
                            highestCount = kvp.Value;
                            mostCommonWord = kvp.Key;
                        }
                    }
                    if (mostCommonWord != null)
                    {
                        mostCommonWords.Add(mostCommonWord);
                    }
                }
                return mostCommonWords;
            }
            static List<string> FindLeastCommonWords(string text, int count)
            {
                string[] words = GetWords(text);
                Dictionary<string, int> wordCounts = new Dictionary<string, int>();

                foreach (var word in words)
                {
                    if (wordCounts.ContainsKey(word))
                    {
                        wordCounts[word]++;
                    }
                    else
                    {
                        wordCounts[word] = 1;
                    }
                }
                List<string> leastCommonWords = new List<string>();
                for (int i = 0; i < count; i++)
                {
                    string leastCommonWord = null;
                    int lowestCount = int.MaxValue;
                    foreach (var kvp in wordCounts)
                    {
                        if (kvp.Value < lowestCount && !leastCommonWords.Contains(kvp.Key))
                        {
                            lowestCount = kvp.Value;
                            leastCommonWord = kvp.Key;
                        }
                    }
                    if (leastCommonWord != null)
                    {
                        leastCommonWords.Add(leastCommonWord);
                    }
                }
                return leastCommonWords;
            }
            static void Main(string[] args)
            {
                string filePath = @"/Users/dimitardjurov/Downloads/Raja_Hristova_-_Mini-knizhka_za_lichnite_finansi_-_4334-b.txt";
                string text = File.ReadAllText(filePath);
                int numWords = CountWords(text);
                string shortestWord = FindShortestWord(text);
                string longestWord = FindLongestWord(text);
                double averageWordLength = CalculateAverageWordLength(text);
                List<string> mostCommonWords = FindMostCommonWords(text, 5);
                List<string> leastCommonWords = FindLeastCommonWords(text, 5);
                Console.WriteLine($"1. Number of words: {numWords}");
                Console.WriteLine($"2. Shortest word: {shortestWord}");
                Console.WriteLine($"3. Longest word: {longestWord}");
                Console.WriteLine($"4. Average word length: {averageWordLength:F2}");
                Console.WriteLine("5. Five most common words:");
                foreach (var word in mostCommonWords)
                {
                    Console.WriteLine($"   - {word}");
                }
                Console.WriteLine("6. Five least common words:");
                foreach (var word in leastCommonWords)
                {
                    Console.WriteLine($"   - {word}");
                }
            }
}