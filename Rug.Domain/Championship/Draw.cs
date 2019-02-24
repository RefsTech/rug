using System.Collections.Generic;

namespace Rug.Domain.Championship
{
    public class Draw
    {
        public Draw(IDictionary<int, Team.Team> teamToDrawMapping)
        {
            if (teamToDrawMapping.Values.Count % 2 != 0)
            {
                teamToDrawMapping.Add(new KeyValuePair<int, Team.Team>(teamToDrawMapping.Values.Count + 1, Team.Team.Default));
            }

            Teams = teamToDrawMapping;
        }

        public IDictionary<int, Team.Team> Teams { get; }

    }
}