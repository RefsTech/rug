using System;
using Rug.Domain.Championship;
using Rug.Domain.Match.Events;
using Rug.Domain.Match.MatchReferees;
using Rug.Domain.Team;

namespace Rug.Domain.Match
{

    public class Match
    {
        public League.League League { get; internal set; }

        public Team.Team HomeTeam { get; internal set; }

        public Team.Team AwayTeam { get; internal set; }

        public DateTime? StartDate { get; internal set; }

        public Address HallAddress { get; internal set; }

        public MatchReferees.MatchReferees MatchReferees { get; internal set; }

        public void Nominate(MatchRefereeType matchRefereeType, Referee.Referee referee, IPublisher publisher)
        {
            if(HomeTeam == null || AwayTeam == null || !StartDate.HasValue || HallAddress == null)
            {
                throw new MatchNominationException("Match should have Home/Away Teams, StartDate and Hall");
            }

            if(MatchReferees.Contains(referee))
            {
                throw new MatchNominationException("Same Referee cant be on multiple positions");
            }

            if(!referee.CanJudgeLeague(League))
            {
                throw new MatchNominationException("Referee cant judge higher ranked league");
            }

            if(!referee.IsAllowedForNominationOnMatch(this))
            {
                throw new MatchNominationException("Referee is not free on that period of time");
            }

            if(!MatchReferees.CanAddReferee(matchRefereeType))
            {
                throw new MatchNominationException("Referees limit is reached");
            }

            MatchReferees = MatchReferees.Add(matchRefereeType, referee);

            publisher.SendEvent(new RefereeNominated(this, referee, matchRefereeType));
        }
    }
}