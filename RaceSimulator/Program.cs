using RaceSimulator.Presentation.Interfaces;
using RaceSimulator.Presentation.CLI;
using RaceSimulator.RaceLogic;
using RaceSimulator.Transportation;
using RaceSimulator.Transportation.Abstractions;

const int TICK_TIME_MS = 1000;

IPrinter printer = new CommandLinePrinter();

RaceLogic raceLogic = new(printer, TICK_TIME_MS);
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

printer.PrintFormattedLine("Distance", "The distance is going to be...");
printer.PrintFormattedLine("Distance", distance.ToString());
raceLogic.SetSimulationParams(distance);

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
    raceLogic.RegisterObject(VehicleFactory.CreateVehicle(vehicleType));
}

raceLogic.StartSimulation();
if (raceLogic.Result == null)
{
    printer.PrintFormattedLine("Error", "Something went wrong during the simulation");
} 
else
{
    informerCLI.DisplayWinner(raceLogic.Result);
}
    