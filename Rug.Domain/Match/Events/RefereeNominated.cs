using Rug.Domain.Championship;
using Rug.Domain.Match.MatchReferees;

namespace Rug.Domain.Match.Events
{
    public class RefereeNominated : IEvent
    {
        public RefereeNominated(Match match, Referee.Referee referee, MatchRefereeType matchRefereeType)
        {
            Match = match;
            Referee = referee;
            MatchRefereeType = matchRefereeType;
        }

        public Referee.Referee Referee { get; set; }

        public MatchRefereeType MatchRefereeType { get; set; }

        public Match Match { get; set; }
    }
}