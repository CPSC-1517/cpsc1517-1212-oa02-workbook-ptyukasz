using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTeamSystem
{
    public class HockeyPlayer : Person 
    {
        //backing fileds, used for store values
        private int _primaryNumber;

        //auto implement, only could be changed by constructor. Can not be changed out side the class
        public PlayerPosition Position { get; private set; }
        //Define properties with private set for Goals, Assists
        public int Goals { get; private set; }
        public int Assists { get; private set; }

        //Define a read-only property for Points (Goals + Assists)
        public int Points { get { return Goals + Assists; } }


        //Fully implement property
        public int PrimaryNumber 
        { 
            get { return _primaryNumber; }
            private set 
            {  //Validate PrimaryNumber is between 1 and 99
                if(value<1 || value > 99)
                {
                    throw new ArgumentException("HockeyPlayer primary number must be between 1 and 99");
                }
                _primaryNumber = value; 
            }
        }

        //Define a fully-implemented property for FullName
        //with readonly information
        //Validate FullName is not null, not empty, and not a whitespace
        //Validate FullName contains at minimun 3 characters
        /*
        public string FullName
        {
            get { return _fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Must provide a name");
                }
                if (value.Trim().Length < 3)//Trim white space
                {
                    throw new ArgumentException("Must longer than 3 character");
                }
                _fullName = value.Trim();
            }
        }
        */
        //Define an greedy constructor

        public HockeyPlayer(string fullName, int primaryNumber, PlayerPosition position,
            int goals, int assists) : base(fullName)
        {
            PrimaryNumber = primaryNumber;
            Position = position;
            Goals = goals;
            Assists = assists;
        }

        //override the ToString() method to return a CSV
        public override string ToString()
        {
            return $"{FullName},{PrimaryNumber},{Position},{Goals},{Assists}";
        }
        //A static (class-level) method can be accessd ditectly without creating an instance
        //obeject for the class. For example we can:
        //HockeyPlayer currentPlayer = HockeyPlayer.Parse("...")
        public static HockeyPlayer Parse(string csvLineText)
        {
            const char Delimeter = ',';
            string[] tokens = csvLineText.Split(Delimeter);
            //There should be 5 values in the tokens
            if(tokens.Length != 5)
            {
                throw new FormatException($"");
            }
            return new HockeyPlayer
                (fullName:tokens[0],
                primaryNumber:int.Parse(tokens[1]),
                position:(PlayerPosition)Enum.Parse(typeof(PlayerPosition),tokens[2]),
                goals:int.Parse(tokens[3]),
                assists:int.Parse(tokens[4]));
        }

        public static bool TryParse(string csvLineText, out HockeyPlayer player)
        {
            bool success = false;
            try
            {
                player = Parse(csvLineText);
                success = true;
            }
            catch (FormatException ex)
            {
                throw new FormatException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"TryParse HockeyPlayer {ex.Message}");
            }
            return success;
        }
    }
}
