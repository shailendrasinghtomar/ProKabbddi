using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProKabbddi
{
    public class Team
    {
        public int Score { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public Team(int teamId, string teamName) {
            ID = teamId;
            Name = teamName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var team = obj as Team;
            if (team == null)
                return false;
            return (ID == team.ID || Name == team.Name);
        }
    }
}
