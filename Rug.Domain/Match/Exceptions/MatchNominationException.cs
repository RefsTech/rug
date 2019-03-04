using System;

namespace Rug.Domain.Match
{
    public class MatchNominationException : Exception
    {
        public MatchNominationException(string message) : base(message)
        {
        }
    }
}