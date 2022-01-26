namespace HockeyTeamSystem
{
    public class HockeyPlayer : Person
    {
        
        private int _primaryNumber;
        public PlayerPosition Position { get; private set; }

        public int PrimaryNumber
        {
            get { return _primaryNumber; }
            set
            {   // Validate primaryNumber is between 1 and 99
                if (value < 1 || value > 99)
                {
                    throw new ArgumentOutOfRangeException("Hockey Player primary number must be between 1 and 99");
                }
                _primaryNumber = value;
            }

        }
        // Define a fully implemented property for FullName
     
        //Define a greedy constructor
        public HockeyPlayer(string fullName, int primaryNumber, PlayerPosition position) : base(fullName)
        {
         
            PrimaryNumber = primaryNumber;
            Position = position;
        }

        //Override the ToString() method to return a CSV
        public override string ToString()
        {
            return $"{FullName},{PrimaryNumber},{Position}";
        }

    }
}
