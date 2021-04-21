using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;
        private int rating;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public int Rating
        {
            get
            {
                if (players.Count > 0)
                {
                    return (int)Math.Round((players.Sum(x => x.Stat) / players.Count));
                }
                else
                {
                    return 0;
                }
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public bool RemovePlayer(string player)
        {
            if (players.Any(p => p.Name == player))
            {
                players.RemoveAll(p => p.Name == player);
                return true;
            }
            return false;
        }
    }
}
