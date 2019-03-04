namespace Rug.Domain.Team
{
    public class Team
    {
        public Team(string name, League.League league, Address hallAddress)
        {
            Name = name;
            League = league;
            HallAddress = hallAddress;
        }

        public string Name { get; }

        public League.League League { get; }

        public Address HallAddress { get; }
    }
}