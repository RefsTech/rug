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
}