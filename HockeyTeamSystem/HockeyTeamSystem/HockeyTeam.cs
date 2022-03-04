using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTeamSystem
{
    internal class HockeyTeam
    {
        //Define a computed(read-only) property for TotalPoints that sums the points for
        //each HockeyPlayer in the team
        public int TotalPoints 
        { get
            {
                int totalPoints=0;
                foreach(HockeyPlayer currentPlayer in HockeyPlayers)
                {
                    totalPoints += currentPlayer.Points;

                }
                return totalPoints ; 
            } 
        }


        //Define a full-implement property with a backing field for the team name
        private string _teamName; //Define a private backing field for the property
        public string TeamName //Define a read-only property for TeamName
        {
            get { return _teamName; }
            private set
            {
                //Validate the new team name is not null, an empty string, or only whiteSpaces
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Must provide a team name");
                }
                _teamName = value; 
                //Validate the new team name is at least 5 characters length
                if(value.Trim().Length < 5)
                {
                    throw new ArgumentException("Team Name must contains at least 5 characters");
                }
            }
        }
        //Define a auto-implemented property with a private for the team division
        public TeamDivison Divison { get; private set; }

        //Define a auto-implemented readonly property for the HockeyPlayers
        public List<HockeyPlayer> HockeyPlayers { get; } = new List<HockeyPlayer>();
        // Define a read-only property for PlayerCount
        public int PlayerCount
        {
            get { return HockeyPlayers.Count; }
        }

        //Define a readonly property with a private set for the coach
        //The coach property is know as Aggregation/Composition when the
        //field/property is an object not a data type
        public HockeyCoach Coach { get; private set; }

        //Define a greedy constructor that has parameter for the HockeyCoach,
        //Team name, Team Divison and coach

        public HockeyTeam(string teamName, TeamDivison division, HockeyCoach coach)
        {
            TeamName = teamName;
            Divison = division;
            Coach = coach;
        }

        //Define a method to add a player to the team

        public void AddPlayer(HockeyPlayer player)
        {
            //Validate that the player is not null
            if(player == null)
            {
                throw new ArgumentNullException("HockeyTeam add HockeyPlayer is required");
            }

            //Validate that the number of players is less than 23
            if(HockeyPlayers.Count >= 23)
            {
                throw new ArgumentException("Team is full, can not add more player");
            }

            //Vaildate that palyer(by primary number) is not already on the team
            //if(HockeyPlayers.)



            HockeyPlayers.Add(player);
        }

    }
}
