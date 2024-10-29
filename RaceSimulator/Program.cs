using RaceSimulator.Presentation.Interfaces;
using RaceSimulator.Presentation.CLI;
using RaceSimulator.RaceLogic;
using RaceSimulator.Transportation;


IPrinter printer = new CommandLinePrinter();

CLI cli = new CLI(printer);
IReciever recieverCLI = cli as IReciever;
IInformer informerCLI = cli as IInformer;

// Cast check, just in case. For the future
if (recieverCLI == null || informerCLI == null)
{
    throw new InvalidOperationException("CLI instance does not implement the required interfaces");
}


printer.PrintFormattedLine("Welcome", "Welcome to the Racing Simulator!");

double distance = recieverCLI.GetRaceDistance();
int raceType = recieverCLI.GetRaceType();

RaceLogic race = new(distance, printer);

List<string> vehicleTypes = raceType switch
{
    1 => new List<string> { "Centaur", "SevenLeagueBoots" },
    2 => new List<string> { "MagicCarpet", "BabaYagasStupa" },
    3 => new List<string> { "Centaur", "SevenLeagueBoots", "MagicCarpet", "BabaYagasStupa" },
    _ => throw new ArgumentException("Invalid race type")
};

foreach (var vehicleType in vehicleTypes)
{
    race.RegisterVehicle(VehicleFactory.CreateVehicle(vehicleType));
}

Vehicle winner = race.StartRace();
informerCLI.DisplayWinner(winner);