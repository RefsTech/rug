﻿using Rug.Domain.Championship;
using System.Collections.Generic;
using System.Linq;

namespace Rug.Domain.Services
{
    public class ChampionshipCreator
    {
        public static IEnumerable<Match.Match> CreateMatches(Draw draw)
        {
            var pairings = BergerPairings.PickPairings(draw.Teams.Count);
            var matches = new List<Match.Match>(pairings.Length);

            for (var matchPair = 0; matchPair < pairings.Length / 2; matchPair++)
            {
                matches.Add(
                    new Match.Match(
                        draw.Teams[pairings[matchPair, 0]], 
                        draw.Teams[pairings[matchPair, 1]]));
            }

            return matches.Where(match => match.Away.Id != 0 && match.Home.Id != 0);
        }

        private static class BergerPairings
        {
            public static byte[,] PickPairings(int teamsCount)
            {
                switch (teamsCount)
                {
                    case 3:
                    case 4:
                        return _3or4TeamsPairings;
                    case 5:
                    case 6:
                        return _5or6TeamsPairings;
                    case 7:
                    case 8:
                        return _7or8TeamsPairings;
                    case 9:
                    case 10:
                        return _9or10TeamsPairings;
                    case 11:
                    case 12:
                        return _11or12TeamsPairings;
                    case 13:
                    case 14:
                        return _13or14TeamsPairings;
                    case 15:
                    case 16:
                        return _15or16TeamsPairings;
                    case 17:
                    case 18:
                        return _17or18TeamsPairings;
                    case 19:
                    case 20:
                        return _19or20TeamsPairings;
                    case 21:
                    case 22:
                        return _21or22TeamsPairings;
                    default:
                        return new byte[0, 0];
                }
            }

            private static byte[,] _3or4TeamsPairings =
            {
                {1,4}, {2,3},
                {4,3}, {1,2},
                {2,4}, {3,1}
            };

            private static byte[,] _5or6TeamsPairings =
            {
                {1,6}, {2,5}, {3,4},
                {6,4}, {5,3}, {1,2},
                {2,6}, {3,1}, {4,5},
                {6,5}, {1,4}, {2,3},
                {3,6}, {4,2}, {5,1}
            };

            private static byte[,] _7or8TeamsPairings =
            {
                {1,8}, {2,7}, {3,6}, {4,5},
                {8,5}, {6,4}, {7,3}, {1,2},
                {2,8}, {3,1}, {4,7}, {5,6},
                {8,6}, {7,5}, {1,4}, {2,3},
                {3,8}, {4,2}, {5,1}, {6,7},
                {8,7}, {1,6}, {2,5}, {3,4},
                {4,8}, {5,3}, {6,2}, {7,1}
            };

            private static byte[,] _9or10TeamsPairings =
            {
                {1,10}, {2,9}, {3,8}, {4,7}, {5,6},
                {10,6}, {7,5}, {8,4}, {9,3}, {1,2},
                {2,10}, {3,1}, {4,9}, {5,8}, {6,7},
                {10,7}, {8,6}, {9,5}, {1,4}, {2,3},
                {3,10}, {4,2}, {5,1}, {6,9}, {7,8},
                {10,8}, {9,7}, {1,6}, {2,5}, {3,4},
                {4,10}, {5,3}, {6,2}, {7,1}, {8,9},
                {10,9}, {1,8}, {2,7}, {3,6}, {4,5},
                {5,10}, {6,4}, {7,3}, {8,2}, {9,1}
            };

            private static byte[,] _11or12TeamsPairings =
            {
                {1,12},  {2,11}, {3,10}, {4,9},  {5,8},  {6,7},
                {12,7},  {8,6},  {9,5},  {10,4}, {11,3}, {1,2},
                {2,12},  {3,1},  {4,11}, {5,10}, {6,9},  {7,8},
                {12,8},  {9,7},  {10,6}, {11,5}, {1,4},  {2,3},
                {3,12},  {4,2},  {5,1},  {6,11}, {7,10}, {8,9},
                {12,9},  {10,8}, {11,7}, {1,6},  {2,5},  {3,4},
                {4,12},  {5,3},  {6,2},  {7,1},  {8,11}, {9,10},
                {12,10}, {11,9}, {1,8},  {2,7},  {3,6},  {4,5},
                {5,12},  {6,4},  {7,3},  {8,2},  {9,1},  {10,11},
                {12,11}, {1,10}, {2,9},  {3,8},  {4,7},  {5,6},
                {6,12},  {7,5},  {8,4},  {9,3},  {10,2}, {11,1},
            };

            private static byte[,] _13or14TeamsPairings =
            {
                {1,14},  {2,13},  {3,12},  {4,11},  {5,10},  {6,9},   {7,8},
                {14,8},  {9,7},   {10,6},  {11,5},  {12,4},  {13,3},  {1,2},
                {2,14},  {3,1},   {4,13},  {5,12},  {6,11},  {7,10},  {8,9},
                {14,9},  {10,8},  {11,7},  {12,6},  {13,5},  {1,4},   {2,3},
                {3,14},  {4,2},   {5,1},   {6,13},  {7,12},  {8,11},  {9,10},
                {14,10}, {11,9},  {12,8},  {13,7},  {1,6},   {2,5},   {3,4},
                {4,14},  {5,3},   {6,2},   {7,1},   {8,13},  {9,12},  {10,11},
                {14,11}, {12,10}, {13,9},  {1,8},   {2,7},   {3,6},   {4,5},
                {5,14},  {6,4},   {7,3},   {8,2},   {9,1},   {10,13}, {11,12},
                {14,12}, {13,11}, {1,10},  {2,9},   {3,8},   {4,7},   {5,6},
                {6,14},  {7,5},   {8,4},   {9,3},   {10,2},  {11,1},  {12,13},
                {14,13}, {1,12},  {2,11},  {3,10},  {4,9},   {5,8},   {6,7},
                {7,14},  {8,6},   {9,5},   {10,4},  {11,3},  {12,2},  {13,1}
            };

            private static byte[,] _15or16TeamsPairings =
            {
                {1,16},  {2,15},   {3,14},   {4,13},  {5,12},  {6,11},   {7,10},   {8,9},
                {16,9},  {10,8},   {11,7},   {12,6},  {13,5},  {14,4},   {15,3},   {1,2},
                {2,16},  {3,1},    {4,15},   {5,14},  {6,13},  {7,12},   {8,11},   {9,10},
                {16,10}, {11,9},   {12,8},   {13,7},  {14,6},  {15,5},   {1,4},    {2,3},
                {3,16},  {4,2},    {5,1},    {6,15},  {7,14},  {8,13},   {9,12},   {10,11},
                {16,11}, {12,10},  {13,9},   {14,8},  {15,7},  {1,6},    {2,5},    {3,4},
                {4,16},  {5,3},    {6,2},    {7,1},   {8,15},  {9,14},   {10,13},  {11,12},
                {16,12}, {13,11},  {14,10},  {15,9},  {1,8},   {2,7},    {3,6},    {4,5},
                {5,16},  {6,4},    {7,3},    {8,2},   {9,1},   {10,15},  {11,14},  {12,13},
                {16,13}, {14,12},  {15,11},  {1,10},  {2,9},   {3,8},    {4,7},    {5,6},
                {6,16},  {7,5},    {8,4},    {9,3},   {10,2},  {11,1},   {12,15},  {13,14},
                {16,14}, {15,13},  {1,12},   {2,11},  {3,10},  {4,9},    {5,8},    {6,7},
                {7,16},  {8,6},    {9,5},    {10,4},  {11,3},  {12,2},   {13,1},   {14,15},
                {16,15}, {1,14},   {2,13},   {3,12},  {4,11},  {5,10},   {6,9},    {7,8},
                {8,16},  {9,7},    {10,6},   {11,5},  {12,4},  {13,3},   {14,2},   {15,1},
            };

            private static byte[,] _17or18TeamsPairings =
            {
                {1,18},  {2,17},  {3,16},   {4,15},  {5,14},  {6,13},   {7,12},   {8,11},   {9,10 },
                {18,10}, {11,9},  {12,8},   {13,7},  {14,6},  {15,5},   {16,4},   {17,3},   {1,2 },
                {2,18},  {3,1 },  {4,17},   {5,16},  {6,15},  {7,14},   {8,13},   {9,12},   {10,11 },
                {18,11}, {12,10}, {13,9},   {14,8},  {15,7},  {16,6},   {17,5},   {1,4 },   {2,3 },
                {3,18},  {4,2 },  {5,1 },   {6,17},  {7,16},  {8,15},   {9,14},   {10,13},  {11,12 },
                {18,12}, {13,11}, {14,10},  {15,9},  {16,8},  {17,7},   {1,6 },   {2,5 },   {3,4 },
                {4,18},  {5,3 },  {6,2 },   {7,1 },  {8,17},  {9,16},   {10,15},  {11,14},  {12,13 },
                {18,13}, {14,12}, {15,11},  {16,10}, {17,9},  {1,8 },   {2,7 },   {3,6 },   {4,5 },
                {5,18},  {6,4 },  {7,3 },   {8,2 },  {9,1 },  {10,17},  {11,16},  {12,15},  {13,14 },
                {18,14}, {15,13}, {16,12},  {17,11}, {1,10},  {2,9 },   {3,8 },   {4,7 },   {5,6 },
                {6,18},  {7,5 },  {8,4 },   {9,3 },  {10,2},  {11,1},   {12,17},  {13,16},  {14,15 },
                {18,15}, {16,14}, {17,13},  {1,12},  {2,11},  {3,10},   {4,9 },   {5,8 },   {6,7 },
                {7,18},  {8,6 },  {9,5 },   {10,4},  {11,3},  {12,2},   {13,1},   {14,17},  {15,16 },
                {18,16}, {17,15}, {1,14},   {2,13},  {3,12},  {4,11},   {5,10},   {6,9 },   {7,8 },
                {8,18},  {9,7 },  {10,6},   {11,5},  {12,4},  {13,3},   {14,2},   {15,1},   {16,17 },
                {18,17}, {1,16},  {2,15},   {3,14},  {4,13},  {5,12},   {6,11},   {7,10},   {8,9 },
                {9,18},  {10,8},  {11,7},   {12,6},  {13,5},  {14,4},   {15,3},   {16,2},   {17,1 },
            };

            private static byte[,] _19or20TeamsPairings =
            {
               {1,20},   {2,19},   {3,18},   {4,17},   {5,16},   {6,15},   {7,14},   {8,13},   {9,12},   {10,11},
               {20,11},  {12,10},  {13,9},   {14,8},   {15,7},   {16,6},   {17,5},   {18,4},   {19,3},   {1,2},
               {2,20},   {3,1},    {4,19},   {5,18},   {6,17},   {7,16},   {8,15},   {9,14},   {10,13},  {11,12},
               {20,12},  {13,11},  {14,10},  {15,9},   {16,8},   {17,7},   {18,6},   {19,5},   {1,4},    {2,3},
               {3,20},   {4,2},    {5,1},    {6,19},   {7,18},   {8,17},   {9,16},   {10,15},  {11,14},  {12,13},
               {20,13},  {14,12},  {15,11},  {16,10},  {17,9},   {18,8},   {19,7},   {1,6},    {2,5},    {3,4},
               {4,20},   {5,3},    {6,2},    {7,1},    {8,19},   {9,18},   {10,17},  {11,16},  {12,15},  {13,14},
               {20,14},  {15,13},  {16,12},  {17,11},  {18,10},  {19,9},   {1,8},    {2,7},    {3,6},    {4,5},
               {5,20},   {6,4},    {7,3},    {8,2},    {9,1},    {10,19},  {11,18},  {12,17},  {13,16},  {14,15},
               {20,15},  {16,14},  {17,13},  {18,12},  {19,11},  {1,10},   {2,9},    {3,8},    {4,7},    {5,6},
               {6,20},   {7,5},    {8,4},    {9,3},    {10,2},   {11,1},   {12,19},  {13,18},  {14,17},  {15,16},
               {20,16},  {17,15},  {18,14},  {19,13},  {1,12},   {2,11},   {3,10},   {4,9},    {5,8},    {6,7},
               {7,20},   {8,6},    {9,5},    {10,4},   {11,3},   {12,2},   {13,1},   {14,19},  {15,18},  {16,17},
               {20,17},  {18,16},  {19,15},  {1,14},   {2,13},   {3,12},   {4,11},   {5,10},   {6,9},    {7,8},
               {8,20},   {9,7},    {10,6},   {11,5},   {12,4},   {13,3},   {14,2},   {15,1},   {16,19},  {17,18},
               {20,18},  {19,17},  {1,16},   {2,15},   {3,14},   {4,13},   {5,12},   {6,11},   {7,10},   {8,9},
               {9,20},   {10,8},   {11,7},   {12,6},   {13,5},   {14,4},   {15,3},   {16,2},   {17,1},   {18,19},
               {20,19},  {1,18},   {2,17},   {3,16},   {4,15},   {5,14},   {6,13},   {7,12},   {8,11},   {9,10},
               {10,20},  {11,9},   {12,8},   {13,7},   {14,6},   {15,5},   {16,4},   {17,3},   {18,2},   {19,1},
            };

            private static byte[,] _21or22TeamsPairings =
            {
               {1,22},   {2,21},   {3,20},   {4,19},   {5,18},   {6,17},   {7,16},   {8,15},   {9,14},   {10,13},  {11,12},
               {22,12},  {13,11},  {14,10},  {15,9},   {16,8},   {17,7},   {18,6},   {19,5},   {20,4},   {21,3},   {1,2},
               {2,22},   {3,1},    {4,21},   {5,20},   {6,19},   {7,18},   {8,17},   {9,16},   {10,15},  {11,14},  {12,13},
               {22,13},  {14,12},  {15,11},  {16,10},  {17,9},   {18,8},   {19,7},   {20,6},   {21,5},   {1,4},    {2,3},
               {3,22},   {4,2},    {5,1},    {6,21},   {7,20},   {8,19},   {9,18},   {10,17},  {11,16},  {12,15},  {13,14},
               {22,14},  {15,13},  {16,12},  {17,11},  {18,10},  {19,9},   {20,8},   {21,7},   {1,6},    {2,5},    {3,4},
               {4,22},   {5,3},    {6,2},    {7,1},    {8,21},   {9,20},   {10,19},  {11,18},  {12,17},  {13,16},  {14,15},
               {22,15},  {16,14},  {17,13},  {18,12},  {19,11},  {20,10},  {21,9},   {1,8},    {2,7},    {3,6},    {4,5},
               {5,22},   {6,4},    {7,3},    {8,2},    {9,1},    {10,21},  {11,20},  {12,19},  {13,18},  {14,17},  {15,16},
               {22,16},  {17,15},  {18,14},  {19,13},  {20,12},  {21,11},  {1,10},   {2,9},    {3,8},    {4,7},    {5,6},
               {6,22},   {7,5},    {8,4},    {9,3},    {10,2},   {11,1},   {12,21},  {13,20},  {14,19},  {15,18},  {16,17},
               {22,17},  {18,16},  {19,15},  {20,14},  {21,13},  {1,12},   {2,11},   {3,10},   {4,9},    {5,8},    {6,7},
               {7,22},   {8,6},    {9,5},    {10,4},   {11,3},   {12,2},   {13,1},   {14,21},  {15,20},  {16,19},  {17,18},
               {22,18},  {19,17},  {20,16},  {21,15},  {1,14},   {2,13},   {3,12},   {4,11},   {5,10},   {6,9},    {7,8},
               {8,22},   {9,7},    {10,6},   {11,5},   {12,4},   {13,3},   {14,2},   {15,1},   {16,21},  {17,20},  {18,19},
               {22,19},  {20,18},  {21,17},  {1,16},   {2,15},   {3,14},   {4,13},   {5,12},   {6,11},   {7,10},   {8,9},
               {9,22},   {10,8},   {11,7},   {12,6},   {13,5},   {14,4},   {15,3},   {16,2},   {17,1},   {18,21},  {19,20},
               {22,20},  {21,19},  {1,18},   {2,17},   {3,16},   {4,15},   {5,14},   {6,13},   {7,12},   {8,11},   {9,10},
               {10,22},  {11,9},   {12,8},   {13,7},   {14,6},   {15,5},   {16,4},   {17,3},   {18,2},   {19,1},   {20,21},
               {22,21},  {1,20},   {2,19},   {3,18},   {4,17},   {5,16},   {6,15},   {7,14},   {8,13},   {9,12},   {10,11},
               {11,22},  {12,10},  {13,9},   {14,8},   {15,7},   {16,6},   {17,5},   {18,4},   {19,3},   {20,2},   {21,1},
            };
        }
    }
}
