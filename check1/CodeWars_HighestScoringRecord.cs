using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    public interface IScoreCounter<T>
    {
        public T FindHighestScore();
    }
    public static class ScoreCounterHelper
    {
        public static int GetScore(string word)
        {
            int score = 0;
            foreach (char c in word)
            {
                score += c - 'a' + 1;
            }
            return score;
        }
    }

    public class ScoreCounter : IScoreCounter<string>
    {
        List<string> words;
        public ScoreCounter(string str)
        {
            var splitted = str.Split(" ");
            words = new List<string>();

            foreach (var item in splitted)
            {
                words.Add(item);
            }
        }

        public string FindHighestScore()
        {
            var query = words.Select(x => new { Word = x, Score = ScoreCounterHelper.GetScore(x)}).OrderByDescending(y => y.Score).First();

            return query.Word;
        }

    }

    public class ScoreCounterX2 : IScoreCounter<string>
    {
        List<string> words;

        private static string GetRandomString()
        {
            Random random = new Random();

            return random.Next().ToString();
            
        }
        public ScoreCounterX2(string str)
        {
            words = new List<string>();

            foreach (var item in str.Split(" "))
            {
                words.Add(item + GetRandomString());
            }
        }
        public string FindHighestScore()
        {
            var query = words.Select(x => new { Word = x, Score = ScoreCounterHelper.GetScore(x) }).OrderByDescending(y => y.Score).First();

            return query.Word;
        }
    }


    internal class CodeWars_HighestScoringRecord
    {
        public static string High(string s)
        {
            IScoreCounter<string> scoreCounter = new ScoreCounter(s);
            return scoreCounter.FindHighestScore();
        }
    }
}
