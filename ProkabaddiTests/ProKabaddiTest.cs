using System.Collections.Generic;
using Xunit;
using ProKabbddi;
using System;
using FluentAssertions;

namespace ProkabaddiTests
{
    public class ProkabaddiTest
    {
        [Fact]
        public void ShouldMakeCorrectRoundRobinPairs()
        {
            List<Team> teams = new List<Team>();
            teams.Add(new Team(1, "Team1"));
            teams.Add(new Team(2, "Team2"));
            teams.Add(new Team(3, "Team3"));
            teams.Add(new Team(4, "Team4"));
            teams.Add(new Team(5, "Team5"));
            var sm = new ScheduleManager();
            var actualPairs = sm.MakeRoundRobinPairs(teams);
            var testPairs = new List<Tuple<int, Team, Team>>();
            testPairs.Add(Tuple.Create(1, new Team(2, "Team2"), new Team(4, "Team4")));
            testPairs.Add(Tuple.Create(1, new Team(1, "Team1"), new Team(5, "Team5")));
            testPairs.Add(Tuple.Create(2, new Team(3, "Team3"), new Team(5, "Team5")));
            testPairs.Add(Tuple.Create(2, new Team(2, "Team2"), new Team(1, "Team1")));
            testPairs.Add(Tuple.Create(3, new Team(4, "Team4"), new Team(1, "Team1")));
            testPairs.Add(Tuple.Create(3, new Team(3, "Team3"), new Team(2, "Team2")));
            testPairs.Add(Tuple.Create(4, new Team(5, "Team5"), new Team(2, "Team2")));
            testPairs.Add(Tuple.Create(4, new Team(4, "Team4"), new Team(3, "Team3")));

            actualPairs.Should().BeEquivalentTo(testPairs);
        }
    }
}
