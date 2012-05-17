using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE.Problems
{
    class Problem054:Problem
    {
        public override int Number
        {
            get { return 054; }
        }

        public override ValueType Solve()
        {
            var cards = GetFileLines("http://projecteuler.net/project/poker.txt").Select(l => l.Split(' ').Select(ParseCard));
            var hands = cards.Select(cs => new Tuple<Card[], Card[]>(cs.Take(5).ToArray(), cs.Skip(5).Take(5).ToArray()));
            var scores = hands.Select(h => new Tuple<HandScore, HandScore>(ScoreHand(h.Item1), ScoreHand(h.Item2)));
            int wins = scores.Count(hs => hs.Item1.Class > hs.Item2.Class || (hs.Item1.Class == hs.Item2.Class && hs.Item1.HighRank > hs.Item2.HighRank));

            return wins;
        }

        private readonly List<char> Ranks = new List<char> {'2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A'};
        private readonly List<char> Suits = new List<char> {'C', 'S', 'H', 'D'};

        HandScore ScoreHand(Card[] hand)
        {
            return new HandScore();
        }

        Card ParseCard(string c)
        {
            Card d;
            d.Rank = Ranks.IndexOf(c[0]);
            d.Suit = (Suit) Suits.IndexOf(c[1]);
            return d;
        }

        private struct HandScore
        {
            public int Class;
            public int HighRank;
        }

        private enum Suit
        {
            Club=0,Spade=1,Heart=2,Diamond=3
        }

        private struct Card
        {
            public Suit Suit;
            public int Rank;
        }
    }
}
