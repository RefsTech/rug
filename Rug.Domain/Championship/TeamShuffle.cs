using System.Collections.Generic;

namespace Rug.Domain.Championship
{
    public class TeamShuffle
    {
        public TeamShuffle(IDictionary<byte, byte> teamToDrawMapping)
        {
            if (teamToDrawMapping.Values.Count % 2 != 0)
            {
                teamToDrawMapping.Add(new KeyValuePair<byte, byte>(0, 0));
            }

            Teams = teamToDrawMapping;
        }

        public IDictionary<byte, byte> Teams { get; }

    }
}