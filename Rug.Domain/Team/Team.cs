﻿namespace Rug.Domain.Team
{
    public class Team
    {
        public Team(byte id)
        {
            Id = id;
        }

        public byte Id { get; }

        public static Team Default => new Team(0);
    }
}