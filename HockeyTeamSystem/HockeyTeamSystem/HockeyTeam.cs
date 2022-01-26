using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTeamSystem
{
    public class HockeyTeam 
    {
        //Define a fully-implemented property with a backing field for the team name
        private string _teamName; // Define a private backing field for the propety
        public string TeamName // Define a readonly property for TeamName
        { 
            get { return _teamName; }
            private set 
            {   //Validate the new team name is not null, and empty string, or only white spaces
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentNullException("HocketName TeamName is required");
                }

                // Validate the new team name contains 5 or more characters
                if (value.Trim().Length < 5) 
                {
                    throw new ArgumentException("HockeyTeam TeamName must contain 5 or more characters");
                }
                _teamName = value; 
            }
        }
        //Define an auto-implemented property with a private set for the Team Division

        public TeamDivision Division { get; private set; }

        //Define an auto-implemented readonly property for the HockeyPlayers
        public List<HockeyPlayer> HockeyPlayers { get; } = new List<HockeyPlayer>();
        // Define a read-only property for PlayerCount 
        public int PlayerCount 
        {
        
            get { return HockeyPlayers.Count; }
        
        }

        // Define a readonly property with a private set for the coach
        // The Coach property is known as  Aggregation/Composition when the field/property
        //is an Object and not a value type
        public HockeyCoach Coach { get; private set; }

        //Define a greedy constructor that has a parameter for the
        //team name, team division, and coach 
        public HockeyTeam(string teamName, TeamDivision division,HockeyCoach coach) 
        { 
           TeamName = teamName;
            Division = division;
            Coach = coach;
        }
        //Define a method to add a player to the team
        public void AddPlayer(HockeyPlayer player )  
        {   //Validate that the player is not null
            if (player == null)
            {
                throw new ArgumentException("HockeyTeam and HockeyPlayer is required");
            }
            // Validate that the number of players is less than 23
            if (PlayerCount > 23)
            {
                throw new ArgumentException(" Player Count must be less than 23");
            }
            //Validate that the player( by primary number) is not already on the team
            foreach (var item in HockeyPlayers)
            {
                if (player.PrimaryNumber == item.PrimaryNumber) 
                {
                    throw new ArgumentException("Player is already on the team");
                }
            }
                 
          
           
            HockeyPlayers.Add(player);
        }
        public override string ToString()
        {
            return $"{TeamName},{Division},{Coach}";
        }

    }
}
