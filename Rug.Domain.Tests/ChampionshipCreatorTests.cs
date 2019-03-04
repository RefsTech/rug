using Rug.Domain.Team;

namespace Rug.Domain.Tests
{
    using Rug.Domain.Championship;
    using NUnit.Framework;
    using Rug.Domain.Services;
    using System.Collections.Generic;
    using System.Linq;

    public class ChampionshipCreatorTests
    {
        private readonly League.League _testLeague = new League.League { Name = "Test" };
        private readonly Address _testAddress = new Address("TestCity", "TestPostAddress");
        [Test]
        public void CreateMatches_WhenTeamsAreOddNumber_ShouldReturnOnlyValidMatches()
        {
            // Arrange
            var draw = new Draw(new Dictionary<int, Team.Team>
            {
                [1] = new Team.Team("CSKA", _testLeague, _testAddress),
                [2] = new Team.Team("Levski", _testLeague, _testAddress),
                [3] = new Team.Team("Hebar", _testLeague, _testAddress),
                [4] = new Team.Team("Lukoil", _testLeague, _testAddress),
                [5] = new Team.Team("Montana", _testLeague, _testAddress)
            });

            // Act
            var matches = ChampionshipCreator.CreateMatches(draw);

            // Assert
            Assert.That(matches.Count == 10, "Number of matches for 5 teams should be 10");
            Assert.That(matches.Any(match => match.HomeTeam == Team.Team.Default || match.AwayTeam == Team.Team.Default) == false, "There is/are match with invalid team in created matches.");
        }

        [Test]
        public void CreateMatches_WhenTeamsAreEvenNumber_ShouldReturnAllMatches()
        {
            // Arrange
            var draw = new Draw(new Dictionary<int, Team.Team>
            {
                [1] = new Team.Team("CSKA", _testLeague, _testAddress),
                [2] = new Team.Team("Levski", _testLeague, _testAddress),
                [3] = new Team.Team("Hebar", _testLeague, _testAddress),
                [4] = new Team.Team("Lukoil", _testLeague, _testAddress),
                [5] = new Team.Team("Montana", _testLeague, _testAddress),
                [6] = new Team.Team("Pernik", _testLeague, _testAddress)
            });

            // Act
            var matches = ChampionshipCreator.CreateMatches(draw);

            // Assert
            Assert.That(matches.Count == 15, "Number of matches for 6 teams should be 15.");
        }

        [Test]
        public void CreateMatches_WhenTeamsAreShuffled_ShouldReturnSameBergerPairings()
        {
            // Arrange
            var lukoil = new Team.Team("Lukoil", _testLeague, _testAddress);
            var levski = new Team.Team("Levski", _testLeague, _testAddress);
            var hebar = new Team.Team("Hebar", _testLeague, _testAddress);
            var cska = new Team.Team("CSKA", _testLeague, _testAddress);

            var draw = new Draw(new Dictionary<int, Team.Team>
            {
                [1] = lukoil,
                [2] = levski,
                [3] = cska,
                [4] = hebar, 
            });
            var expectedFirst = new Match.Match(home: lukoil, away: hebar);
            var expectedMiddle = new Match.Match(home: lukoil, away: levski);
            var expectedLast = new Match.Match(home: cska, away: lukoil);
            var matchComparer = new Match.MatchEqualityComparer();

            // Act
            var matches = ChampionshipCreator.CreateMatches(draw).ToArray();

            // Assert
            Assert.That(matches.Length == 6, "Number of matches for 4 teams should be 6.");
            Assert.That(matches[0], Is.EqualTo(expectedFirst).Using(matchComparer), "Berger pairings are not constructing correct when teams are drawd.");
            Assert.That(matches[3], Is.EqualTo(expectedMiddle).Using(matchComparer), "Berger pairings are not constructing correct when teams are drawd.");
            Assert.That(matches[5], Is.EqualTo(expectedLast).Using(matchComparer), "Berger pairings are not constructing correct when teams are drawd.");
        }
    }
}