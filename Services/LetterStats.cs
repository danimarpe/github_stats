using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace github_stats.Services
{
    public class LetterStats
    {
        Dictionary<char, int> stats;

        public LetterStats(byte[] content) {
            string contentString = System.Text.Encoding.Default.GetString(content).ToLower();
            stats = contentString.GroupBy(c => c)
                .Select(c => new KeyValuePair<char, int>(c.Key, c.Count())).ToDictionary();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, stats);
        }

    }
}
