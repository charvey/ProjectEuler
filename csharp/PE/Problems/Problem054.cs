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

            int wins = scores.Count(hs => hs.Item1.Class > hs.Item2.Class ||
                                          (hs.Item1.Class == hs.Item2.Class && hs.Item1.ClassRank > hs.Item2.ClassRank) ||
                                          (hs.Item1.Class == hs.Item2.Class && hs.Item1.ClassRank == hs.Item2.ClassRank &&
                                           hs.Item1.HighRank > hs.Item2.HighRank));

            return wins;
        }

        private readonly List<char> Ranks = new List<char> { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
        private readonly List<char> Suits = new List<char> {'C', 'S', 'H', 'D'};

        private string handstring(Card[] hand)
        {
            return
                hand.Select(c => Ranks[c.Rank] + "" + Suits[(int) c.Suit])
                    .Aggregate("", (h, c) => h + " " + c)
                    .Remove(0, 1);
        }

        HandScore ScoreHand(Card[] hand)
        {
            HandClass handClass = HandClass.HighCard;
            int classRank = 0;

            bool flush = hand.GroupBy(c => c.Suit).Max(g => g.Count()) == 5;
            bool straight = hand.Select(c => c.Rank).Distinct().Count() == 5 &&
                            hand.OrderBy(c => c.Rank).Max(c => c.Rank) - hand.OrderBy(c => c.Rank).Min(c => c.Rank) == 4;

            if (flush && straight && hand.OrderBy(c => c.Rank).Max().Rank == Ranks.Count-1)
            {
                handClass=HandClass.RoyalFlush;
                classRank = Ranks.Count - 1;
            }
            else if(flush&&straight)
            {
             handClass=HandClass.StraightFlush;
                classRank = hand.Max(c => c.Rank);
            }
            else if (hand.GroupBy(c => c.Rank).Max(g => g.Count()) == 4)
            {
                handClass = HandClass.FourKind;
                classRank = hand.GroupBy(c => c.Rank).OrderByDescending(g => g.Count()).First().First().Rank;
            }
            else if (hand.GroupBy(c => c.Rank).Select(g => g.Count()).All(c => c == 2 || c == 3))
            {
                handClass = HandClass.FullHouse;
                classRank = hand.GroupBy(c => c.Rank).OrderByDescending(g => g.Count()).First().First().Rank;
            }
            else if (flush)
            {
                handClass = HandClass.Flush;
                classRank = hand.Max(c => c.Rank);
            }
            else if (straight)
            {
                handClass = HandClass.Straight;
                classRank = hand.Max(c => c.Rank);
            }
            else if (hand.GroupBy(c => c.Rank).Max(g => g.Count()) == 3)
            {
                handClass = HandClass.ThreeKind;
                classRank = hand.GroupBy(c => c.Rank).OrderByDescending(g => g.Count()).First().First().Rank;
            }
            else if (hand.GroupBy(c => c.Rank).Count(g => g.Count() == 2) == 2)
            {
                handClass = HandClass.TwoPair;
                classRank = hand.GroupBy(c => c.Rank).Where(g => g.Count() == 2).OrderByDescending(g => g.First().Rank).First().First().Rank;
            }
            else if (hand.GroupBy(c => c.Rank).Any(g => g.Count() == 2))
            {
                handClass = HandClass.OnePair;
                classRank = hand.GroupBy(c => c.Rank).Where(g => g.Count() == 2).OrderByDescending(g => g.First().Rank).First().First().Rank;
            }

            return new HandScore {Class = handClass, ClassRank = classRank, HighRank = hand.Max(c => c.Rank)};
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
            public HandClass Class;
            public int ClassRank;
            public int HighRank;
        }

        private enum HandClass
        {
            HighCard = 0,
            OnePair = 1,
            TwoPair = 2,
            ThreeKind = 3,
            Straight = 4,
            Flush = 5,
            FullHouse = 6,
            FourKind = 7,
            StraightFlush = 8,
            RoyalFlush = 9
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
