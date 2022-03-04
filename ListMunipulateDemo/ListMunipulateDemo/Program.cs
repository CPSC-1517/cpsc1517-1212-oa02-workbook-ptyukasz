// See https://aka.ms/new-console-template for more information
using ListMunipulateDemo;
using static System.Console;
using System.Text.Json;

Console.WriteLine("Hello, World!");
//Create a new custom class named HockeyPlayer with auto-implement properties for:
//1) player name
//2) games played
//3) goals
//4) assists 
//5) a derived property to compute the 
//6) points(goals + assists)

//Create a new HockeyTeam insrance
HockeyTeam hockeyTeam = new HockeyTeam("Niu");
//Display all the players in the team
foreach(var players in hockeyTeam.Players)
{
    WriteLine(players);
}
//Remove players started a index 5
WriteLine();
WriteLine("After remove the result are:");
var splitTeam = hockeyTeam.RemovePlayersAt(5);
//Display all the player left in the team
foreach(var players in hockeyTeam.Players)
{
    WriteLine(players);
}

WriteLine();
WriteLine("Player got removed are:");
//Display all the player removed from the team
foreach(var players in splitTeam)
{
    WriteLine(players);
}

HockeyTeam naitHockeyTeam = new HockeyTeam("Nait");
WriteLine();
WriteLine("After remove by name the result are:");
var splitByName = naitHockeyTeam.RemovePlayersByName("Zach hyman");
//There should be now 3 player left in the team
foreach( var player in naitHockeyTeam.Players)
{
    WriteLine(player);
}

WriteLine();

WriteLine("Removed players are:");
foreach(var players in splitByName)
{
    WriteLine(players);
}

//Serialize all the hockey players left after removing players at index 5 to a CSV file
//Serialize all the hockey players removed started at index 5 to a JSON file
//Deserialize all the hockeyPlayers read from the CSV file
//Deserialize all the hockeyPlayers removed from the JSON file

//Write to a JSON file all the properties of the Edmonton Oliers hockey team
HockeyTeam oilers = new HockeyTeam("Edmonton Oliers");

//Define a JSON file path
const string hockeyTeamJSONFilePath = "../../../Oliers.json";

//Create a method of write to JSON file
WriteHockeyTeamToJsonFile(oilers, hockeyTeamJSONFilePath);

static void WriteHockeyTeamToJsonFile(HockeyTeam currentTeam, string jsonFilePath)
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
            WriteIndented = true,
            //IncludeFields = true // not needed cuz no fileds in hockey team
        };
        string jsonString = JsonSerializer.Serialize<HockeyTeam>(currentTeam, options);
        File.WriteAllText(jsonFilePath, jsonString);
        WriteLine($"Successfully created JSON file at {Path.GetFullPath(jsonFilePath)}");
    }
    catch (Exception ex)
    {
        WriteLine($"Error writing to JSON file with exception {ex.Message}");
    }
}

//Read from the JSON file we just created
try
{
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };
    string jsonString = File.ReadAllText(hockeyTeamJSONFilePath);
    HockeyTeam deserailizedTeam = JsonSerializer.Deserialize<HockeyTeam>(jsonString,options);
    Console.WriteLine("Json deserialization successful");
    Console.WriteLine(deserailizedTeam.TeamName);
    foreach(HockeyPlayer currentPlayer in deserailizedTeam.Players)
    {
        Console.WriteLine(currentPlayer.ToString());
    }
}
catch(Exception ex)
{
    Console.WriteLine($"JSON read not successfully with exception: {ex.Message}");
}







