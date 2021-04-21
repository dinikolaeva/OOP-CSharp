using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            var command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    var info = command.Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                    if (info[0] == "Team")
                    {
                        var team = new Team(info[1]);
                        teams.Add(team);
                    }
                    else if (info[0] == "Add")
                    {
                        var currentTeam = info[1];

                        if (teams.Any(t => t.Name == info[1]))
                        {
                            var player = info[2];
                            var endurance = double.Parse(info[3]);
                            var sprint = double.Parse(info[4]);
                            var dribble = double.Parse(info[5]);
                            var passing = double.Parse(info[6]);
                            var shooting = double.Parse(info[7]);

                            var newPlayer = new Player(player, endurance, sprint, dribble, passing, shooting);
                            teams.Where(t => t.Name == currentTeam).FirstOrDefault().AddPlayer(newPlayer);
                        }
                        else
                        {
                            Console.WriteLine($"Team {currentTeam} does not exist.");
                        }
                    }
                    else if (info[0] == "Remove")
                    {
                        var currentTeam = info[1];
                        var player = info[2];

                        if (teams.Any(t => t.Name == currentTeam))
                        {
                            if (teams.Where(t => t.Name == currentTeam)
                                     .FirstOrDefault().RemovePlayer(player))
                            {
                                teams.Where(t => t.Name == currentTeam)
                                     .FirstOrDefault().RemovePlayer(player);
                            }
                            else
                            {
                                Console.WriteLine($"Player {player} is not in {currentTeam} team.");
                            }
                        }
                    }
                    else if (info[0] == "Rating")
                    {
                        var currentTeam = info[1];

                        if (teams.Any(t => t.Name == currentTeam))
                        {
                            Console.WriteLine($"{currentTeam} - {teams.Where(t => t.Name == currentTeam).FirstOrDefault().Rating}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {currentTeam} does not exist.");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                command = Console.ReadLine();
            }
        }
    }
}
