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

        public string Name { get; private set; }

        public static Team Default = new Team("Default", new League.League(), new Address("Default", "Default"));
        
        public League.League League { get; private set; }

        public Address HallAddress { get; private set; }
    }
}