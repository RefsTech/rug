namespace Rug.Domain.Tests
{
    using NUnit.Framework;
    using Rug.Domain.Championship;
    using Rug.Domain.Services;
    using System.Collections.Generic;
    using System.Linq;

    public class ChampionshipCreatorTests
    {
        [Test]
        public void CreateMatches_WhenTeamsAreOddNumber_ShouldReturnOnlyValidMatches()
        {
            // Arrange
            var draw = new Draw(new Dictionary<int, byte>()
            {
                // [drawNumber] = teamId
                [1] = 1, [2] = 2, [3] = 3, [4] = 4, [5] = 5
            });

            // Act
            var matches = ChampionshipCreator.CreateMatches(draw).ToArray();

            // Assert
            Assert.That(matches.Length == 10, "Number of matches for 5 teams should be 10");
            Assert.That(matches.Any(match => match.Home.Id == 0 || match.Away.Id == 0) == false, "There is/are match with invalid team in created matches.");
        }

        [Test]
        public void CreateMatches_WhenTeamsAreEvenNumber_ShouldReturnAllMatches()
        {
            // Arrange
            var draw = new Draw(new Dictionary<int, byte>()
            {
                // [drawNumber] = teamId
                [1] = 1, [2] = 2, [3] = 3, [4] = 4, [5] = 5, [6] = 6
            });

            // Act
            var matches = ChampionshipCreator.CreateMatches(draw);

            // Assert
            Assert.That(matches.Count() == 15, "Number of matches for 6 teams should be 15.");
        }

        [Test]
        public void CreateMatches_WhenTeamsAreShuffled_ShouldReturnSameBergerPairings()
        {
            // Arrange
            var draw = new Draw(new Dictionary<int, byte>()
            {
                // [drawNumber] = teamId
                [1] = 4, [2] = 2, [3] = 1, [4] = 3
            });
            var expectedFirst = new Match.Match(home: new Team.Team(4), away: new Team.Team(3));
            var expectedMiddle = new Match.Match(home: new Team.Team(4), away: new Team.Team(2));
            var expectedLast = new Match.Match(home: new Team.Team(1), away: new Team.Team(4));
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