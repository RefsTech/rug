using System.Collections.Generic;

namespace Rug.Domain.Match
{
    public class Match
    {
        public Match(Team.Team home, Team.Team away)
        {
            Home = home;
            Away = away;
        }

        public Team.Team Home { get; }

        public Team.Team Away { get; }
    }

    public class MatchEqualityComparer : IEqualityComparer<Match>
    {
        public bool Equals(Match first, Match second)
        {
            if (object.ReferenceEquals(first, second)) return true;
            if (object.ReferenceEquals(first, null) || object.ReferenceEquals(second, null)) return false;

            return first.Home.Id == second.Home.Id && first.Away.Id == second.Away.Id;
        }
        public int GetHashCode(Match match)
            => match.Home.Id.GetHashCode() ^ match.Away.Id.GetHashCode();
    }
}