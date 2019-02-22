namespace Rug.Domain.Tests
{
    using NUnit.Framework;
    using Rug.Domain.Championship;
    using Rug.Domain.Services;
    using System.Collections.Generic;

    public class ChampionshipCreatorTests
    {
        private readonly ChampionshipCreator _sut = new ChampionshipCreator();

        [Test]
        public void Create_WhenTeamShuffleIsCorrect_ShouldReturnValidChampionshipMatches()
        {
            ChampionshipCreator.Create(new TeamShuffle(new Dictionary<byte, byte>()
            {
                [1] = 1, [2] = 2, [3] = 3, [4] = 4, [5] = 5
            }));
        }
    }
}