using System;
using System.Collections.Generic;
using System.Linq;

namespace ProKabbddi
{
    public class ScheduleManager
    {
        /// <summary>
        /// Mathod to return round robin schedule with restrictionConsequtiveDay playing for team. and number of matches per day. 
        /// </summary>
        /// <param name="teams"></param>
        /// <param name="numberOfMatchesPerDay"></param>
        /// <param name="restrictConsecutiveDayPlaying"></param>
        public void GenerateRoundRobinSchedule(List<Team> teams, int numberOfMatchesPerDay, bool restrictConsecutiveDayPlaying = true)
        {
            Queue<Tuple<int, Team, Team>> matches = new Queue<Tuple<int, Team, Team>>(MakeRoundRobinPairs(teams));
            List<Tuple<int, Team, Team>> singleDayMatches = new List<Tuple<int, Team, Team>>();
            List<Tuple<int, Team, Team>> lastDayMatches = new List<Tuple<int, Team, Team>>();
            int days = 1;
            int index = 0;
            while (matches.Count > 0)
            {
                Team team1, team2;
                if (index % numberOfMatchesPerDay == 0)
                {
                    singleDayMatches.Clear();
                    foreach (Tuple<int, Team, Team> t in lastDayMatches)
                    {
                        singleDayMatches.Add(t);
                    }
                    lastDayMatches.Clear();
                    Console.WriteLine("Day : " + days);
                    days++;
                }
                
                Tuple<int, Team, Team> match = matches.Dequeue();
                
                team1 = match.Item2;
                team2 = match.Item3;
                              
                bool isConsecutive =false;   
                if (restrictConsecutiveDayPlaying)
                {
                    // second condition is for, if the number of match per day is more then violate the consecutive condition 
                    if (index >= numberOfMatchesPerDay && singleDayMatches.Count < teams.Count/2)
                    {
                        foreach (Tuple<int, Team, Team> t in singleDayMatches)
                        {
                            if (t.Item2.ID.Equals(team1.ID) || t.Item2.ID.Equals(team1.ID) || t.Item3.ID.Equals(team2.ID) || t.Item3.ID.Equals(team2.ID))
                            {
                                isConsecutive = true;
                                matches.Enqueue(match);
                            }
                        }
                    }
                }
                if (!isConsecutive)
                {
                    lastDayMatches.Add(match);
                    singleDayMatches.Add(match);
                    Console.WriteLine(team1.Name + "  VS  " + team2.Name); index++;
                }
            }
        }
        /// <summary>
        /// Method to schedule round robin matches for each ground, each team matches (in case of even number of teams). Normal schedule.
        /// </summary>
        /// <param name="teams"></param>
        /// <param name="restrictConsecutiveDayPlaying"></param>
        public void GenerateRoundRobinSchedule(List<Team> teams)
        {
            Queue<Tuple<int, Team, Team>> matches = new Queue<Tuple<int, Team, Team>>(MakeRoundRobinPairs(teams));
            int index = 0;
            Team team1, team2;
            while (matches.Count > 0)
            {
                Tuple<int, Team, Team> match = matches.Dequeue();
                
                if (match.Item1 != index)
                {
                    Console.WriteLine("Day : " + match.Item1);
                    index++;
                }
                team1 = match.Item2;
                team2 = match.Item3;
                Console.WriteLine(team1.Name + "  VS  " + team2.Name);
            }
        }
        /// <summary>
        /// Make teams match pairs 
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>
        public List<Tuple<int, Team, Team>> MakeRoundRobinPairs(List<Team> teams)
        {
            var matchPairList = new List<Tuple<int, Team, Team>>();
            int rounds = teams.Count - 1;
            bool isEven = teams.Count % 2 == 0 ? true : false;
            int maxMatchesInADay = isEven ? teams.Count / 2 : (teams.Count - 1) / 2;

            for (int i = 0; i < rounds; i++)
            {
                //Console.WriteLine("Round " + (i + 1) + " :");

                for (int j = 1; j <= (isEven ? maxMatchesInADay - 1 : maxMatchesInADay); j++)
                {
                    Team team1 = teams[maxMatchesInADay - j];
                    Team team2 = teams[maxMatchesInADay + j];
                    matchPairList.Add(Tuple.Create((i + 1), team1, team2));
                    //Console.WriteLine(teams[maxMatchesInADay - j] + " VS " + teams[maxMatchesInADay + j]);
                }
                if (isEven)
                {
                    //Console.WriteLine(teams[0] + " VS " + teams[maxMatchesInADay]);
                    matchPairList.Add(Tuple.Create((i + 1), teams[0], teams[maxMatchesInADay]));
                }
                teams = RotateArray(teams);
                //Console.WriteLine();
            }
            return matchPairList;
        }
        /// <summary>
        /// Rotate the teams one position.
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>
        private static List<Team> RotateArray(List<Team> teams)
        {
            Team first = teams.First();
            teams.RemoveAt(0);
            teams.Add(first);
            return teams;
        }
        
    }
}
