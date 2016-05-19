using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProKabbddi
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            teams.Add(new Team(1,"Team1"));
            teams.Add(new Team(2, "Team2"));
            teams.Add(new Team(3, "Team3"));
            teams.Add(new Team(4, "Team4"));
            teams.Add(new Team(5, "Team5"));
            //teams.Add(new Team(6, "Team6"));
            //teams.Add(new Team(7, "Team7"));
            //teams.Add(new Team(8, "Team8"));
            //teams.Add(new Team(9, "Team9"));
            //teams.Add(new Team(10, "Team10"));
            //teams.Add(new Team(11, "Team11"));
            ScheduleManager sm = new ScheduleManager();
            //sm.GenerateRoundRobinSchedule(teams);
            sm.GenerateRoundRobinSchedule(teams, 2, true);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
