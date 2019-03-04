namespace Rug.Domain.Match.MatchReferees
{
    public class MatchReferee
    {
        public MatchReferee(MatchRefereeType matchRefereeType, Referee.Referee referee)
        {
            MatchRefereeType = matchRefereeType;
            Referee = referee;
        }

        public MatchRefereeType MatchRefereeType { get; }

        public Referee.Referee Referee { get; }
    }
}