using RaceSimulator.Presentation.Interfaces;
using RaceSimulator.Presentation.CLI;
using RaceSimulator.RaceLogic;
using RaceSimulator.Transportation;
using RaceSimulator.Transportation.Abstractions;


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

// Temp solution to generate vehicles automatically
List<int> vehicleTypes = raceType switch
{
    1 => [1, 2],
    2 => [3, 4],
    3 => [1, 2, 3, 4],
    _ => throw new ArgumentException("Invalid race type")
};

foreach (var vehicleType in vehicleTypes)
{
    race.RegisterVehicle(VehicleFactory.CreateVehicle(vehicleType));
}

AbstractVehicle winner = race.StartRace();
informerCLI.DisplayWinner(winner);