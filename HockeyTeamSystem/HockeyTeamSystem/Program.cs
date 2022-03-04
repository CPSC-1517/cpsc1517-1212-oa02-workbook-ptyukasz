// See https://aka.ms/new-console-template for more information
using HockeyTeamSystem;
using static System.Console;
using System.Text.Json;


//Define a constant fot the location of players CSV file
const string HockeyPlayerCsvFile = "../../../HockeyPlayer.csv";
const string HockeyTeamJsonFile = "../../../HockeyTeam.json";

//WriteLine("Creating CSV file for hockey players.");
//CreateHockeyPlayersCSVFile();
HockeyTeam currentTeam = ReadHockeyPlayerCSVFile(HockeyPlayerCsvFile);
DispalyHockeyTeam(currentTeam);
WeiteHockeyTeamToJsonFile(currentTeam,HockeyTeamJsonFile);
currentTeam = ReadHockeyTeamFromJsonFile(HockeyTeamJsonFile);
DispalyHockeyTeam(currentTeam);


//Create a method to create hockey player to a csv file
static void CreateHockeyPlayersCSVFile()
{
    try
    {

        //Create a new hockeyCoach instance for the team
        HockeyCoach coach = new HockeyCoach("Dave Tippet", "May 28, 2019");
        //WriteLine(coach);
        //Create players for the team
        HockeyPlayer palyer1 = new HockeyPlayer("Leon Draisaitl", 29, PlayerPosition.Center, 29, 30);
        //WriteLine(palyer1);
        HockeyPlayer palyer2 = new HockeyPlayer("Connor McDavid", 97, PlayerPosition.Center, 20, 37);
        //WriteLine(palyer2);
        HockeyPlayer palyer3 = new HockeyPlayer("Ryan Nugent-Hopkins", 93, PlayerPosition.Center, 3, 24);
        //WriteLine(palyer3);
        HockeyPlayer palyer4 = new HockeyPlayer("Jesse Puljujarvi", 13, PlayerPosition.RightWing, 10, 15);
        //WriteLine(palyer4);
        //Create a hockey team
        HockeyTeam team1 = new HockeyTeam("Edmonton Oilers", TeamDivison.Pacific, coach);
        //Add players tp the hockey team
        team1.AddPlayer(palyer1);
        team1.AddPlayer(palyer2);
        team1.AddPlayer(palyer3);
        team1.AddPlayer(palyer4);

        
        //Write the list of hockey players to a csv file
        //Step1: Create a csv line for each hockey player and add it to a list of string
        List<string> csvLines = new List<string>();
        foreach (HockeyPlayer currentPlayer in team1.HockeyPlayers)
        {
            csvLines.Add(currentPlayer.ToString());
        }
        //Step2: Write all the lines in the list of string values to a file
        File.WriteAllLines(HockeyPlayerCsvFile, csvLines);
        
        /*
        //Another way to write list into CSV file
        using(StreamWriter sw = new StreamWriter(HockeyPlayerCsvFile))
        {
            foreach(HockeyPlayer player in team1.HockeyPlayers)
            {
                sw.WriteLine(player.ToString());
            }
            sw.Close();// it would be better to close it 
        }
        */

        //Step3: 
        WriteLine($"Successfully created csv file at:{Path.GetFullPath(HockeyPlayerCsvFile)}");
    }
    catch (Exception ex)
    {
        WriteLine($"Error writing to CSV file with exception: {ex.Message}");
    }
}

//create a method to read hockey player from a csv file
static HockeyTeam ReadHockeyPlayerCSVFile(string csvFilePath)
{
    HockeyCoach coach1 = new HockeyCoach("Dave Tippet", "May 28,2019");
    HockeyTeam team1 = new("Edmonton Oilers", TeamDivison.Pacific, coach1);

    try
    {
        // Read all the lines from the file and retuan an array of string values for each line
        string[] allLinesArray = File.ReadAllLines(HockeyPlayerCsvFile);
        foreach (string line in allLinesArray)
        {
            try
            {
                HockeyPlayer currentPlayer = null;
                bool success = HockeyPlayer.TryParse(line, out currentPlayer);
                if (success)
                {
                    team1.AddPlayer(currentPlayer);
                }
            }
            catch(FormatException ex)
            {
                WriteLine($"Format exception: {ex.Message}");
            }
            catch(ArgumentNullException ex)
            {
                WriteLine($"Argument null exception:{ex.Message}");
            }
            catch(Exception ex)
            {
                WriteLine($"Error parsing date line with Exception:{ex.Message}");
            }
        }
    }
    catch(Exception ex)
    {
        WriteLine($"Error reading from file with excepthion:{ex.Message}");
    }

    return team1;
}

//Create a method to display hockey team
static void DispalyHockeyTeam(HockeyTeam currentTeam)
{
    if (currentTeam == null)
    {
        WriteLine("There are no hockey team to process display");
    }
    else
    {
        WriteLine($"coach: {currentTeam.Coach}");
        if(currentTeam.HockeyPlayers.Count == 0)
        {
            WriteLine($"There are no player in {currentTeam.TeamName}");
        }
        else
        {
            WriteLine($"Hoeckey players for {currentTeam.TeamName}");
            foreach(HockeyPlayer currentPlayers in currentTeam.HockeyPlayers)
            {
                WriteLine($"Hockey Player: {currentPlayers.ToString()}");
            }
        }
    }

}

/*
//Read the list of hockey players from the CSV file
try
{
    WriteLine("Reading from csv file");
    string[] csvLineArray = File.ReadAllLines(HockeyPlayerCsvFile);
    foreach (string line in csvLineArray)
    {
        HockeyPlayer currentPlayer = null;
        bool parseSuccess = HockeyPlayer.TryParse(line, out currentPlayer);
        WriteLine(currentPlayer);
    }
}
catch (Exception ex)
{
    WriteLine(ex);
}
*/

//*************JSON******************//
static void WeiteHockeyTeamToJsonFile(HockeyTeam currentTeam, string jsonFilePath)
{
    try
    {
        //Make sure you add the namespaces System.Text.Json
        /*
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;
        options.IncludeFields = true;
        */
        //Short cut 
        JsonSerializerOptions options = new JsonSerializerOptions
        {
           // WriteIndented = true,
            IncludeFields = true,
        };
        string jsonString = JsonSerializer.Serialize<HockeyTeam>(currentTeam, options);
        File.WriteAllText(jsonFilePath,jsonString);
        WriteLine($"Successfully created JSON file at {Path.GetFullPath(jsonFilePath)}");
    }
    catch (Exception ex)
    {
        WriteLine($"Error writing to JSON file with exception {ex.Message}");
    }
}

static HockeyTeam ReadHockeyTeamFromJsonFile (string jsonFilePath)
{
    HockeyTeam currentTeam = null;
    try
    {
        string jsonString = File.ReadAllText(jsonFilePath);
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };
        //currentTeam = JsonSerializer.Deserialize<HockeyTeam>(jsonString, options);
        //solution of JS error of can not serialize a read-only property
        currentTeam = Newtonsoft.Json.JsonConvert.DeserializeObject<HockeyTeam>(jsonString, new Newtonsoft.Json.JsonSerializerSettings()
        {
            ConstructorHandling = Newtonsoft.Json.ConstructorHandling.AllowNonPublicDefaultConstructor
        });


        DispalyHockeyTeam(currentTeam);
    }
    catch(Exception ex)
    {
        WriteLine($"Error reading from json file with exception: {ex.Message}");
    }
    return currentTeam;
}