namespace Rug.Domain.Team
{
    public class Team
    {
        public string Name { get; private set; }

        public League.League League { get; set; }

        public Address HallAddress { get; set; }
    }
}