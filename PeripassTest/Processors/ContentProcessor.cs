

using PeripassTest.Models;

namespace PeripassTest.Processors
{
    internal static class ContentProcessor
    {
        internal static TargetResult ProcessContent(List<string> content)
        {
            List<string> targetWords = content.Where(e => e.Length == 6).Distinct().ToList();

            // words of different length to be combined to generate the target words
            List<string> parts = content.Where(e => e.Length < 6).ToList();

            List<string> result = new();

            foreach (string targetWord in targetWords)
            {
                List<string> targetWordParts = parts.Where(e => targetWord.Contains(e)).Distinct().ToList();

                string longestPart = targetWordParts.OrderByDescending(e => e.Length).First();

                List<string> theRest = targetWordParts.Where(e => e.Length + longestPart.Length <= 6).ToList();

                foreach (string item in theRest)
                {
                    if (longestPart + item == targetWord || item + longestPart == targetWord)
                    {
                        result.Add(targetWord);
                        break;
                    }
                }

                // The above solution works for this input. You have the target words(6 characters word) and
                // for every target word you have 5 characters word that misses only one character to get the target word.
                // The one character is missing either from the beginning of the word or from the end of the word.
                // If I had more time, I could write more codes for other cases like if you would combine 6 single characters to make the target word.
            }

            TargetResult targetResult = new()
            {
                TargetWords = targetWords,
                Results = result
            };

            return targetResult;

        }

    }
}
