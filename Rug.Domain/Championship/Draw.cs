using System.Collections.Generic;

namespace Rug.Domain.Championship
{
    public class Draw
    {
        public Draw(IDictionary<int, byte> teamToDrawMapping)
        {
            if (teamToDrawMapping.Values.Count % 2 != 0)
            {
                teamToDrawMapping.Add(new KeyValuePair<int, byte>(teamToDrawMapping.Values.Count + 1, 0));
            }

            Teams = teamToDrawMapping;
        }

        public IDictionary<int, byte> Teams { get; }

    }
}