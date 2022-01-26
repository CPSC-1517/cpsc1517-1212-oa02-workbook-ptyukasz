// See https://aka.ms/new-console-template for more information

using HockeyTeamSystem;

//Test with valid FullName, PrimaryNumber, Position
HockeyPlayer player1 = new("Connor McDavid", 97, PlayerPosition.Center);
HockeyCoach coach = new("Guy Fieri", "Dec21");
HockeyTeam team = new("Oilers", TeamDivision.Atlantic, coach);
Console.WriteLine(player1); // The HocketPlayer.ToString() will be invoked indirectly

// Test with invalid PrimaryNumber
try
{
    HockeyPlayer player2 = new(null, 0, PlayerPosition.Center);
    Console.WriteLine("Test position failed");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
//test with null for FullName

try
{
    HockeyPlayer player2 = new("    Connor McDavid  ", 100, PlayerPosition.Center);
    Console.WriteLine("Test position failed");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
// Test with whitespaces for FullName
try
{
    HockeyPlayer player2 = new("          ", 100, PlayerPosition.Center);
    Console.WriteLine("Test position failed");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
