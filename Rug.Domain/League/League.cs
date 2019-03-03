using System;
using Rug.Domain.Referee;

namespace Rug.Domain.League
{
    public class League
    {
        public string Name { get; set; }

        public RefereeCategory MinRefereeCategoryRequired { get; set; }

        internal bool CanBeJudgedByRefereeCategory(RefereeCategory refereeCategory)
        {
            return refereeCategory <= MinRefereeCategoryRequired;
        }
    }
}