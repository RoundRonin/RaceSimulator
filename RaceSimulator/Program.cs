using RaceSimulator.Presentation.Interfaces;
using RaceSimulator.Presentation.CLI;
using RaceSimulator.RaceLogic;
using RaceSimulator.Transportation.Abstractions;

const int TICK_TIME_MS = 1000;

IPrinter printer = new CommandLinePrinter();

RaceLogic raceLogic = new(printer, TICK_TIME_MS);
CLI cli = new CLI(printer);
IReciever<AbstractVehicle> recieverCLI = cli as IReciever<AbstractVehicle>;
IInformer informerCLI = cli as IInformer;

// Cast check, just in case. For the future
if (recieverCLI == null || informerCLI == null)
{
    throw new InvalidOperationException("CLI instance does not implement the required interfaces");
}

printer.PrintFormattedLine("Welcome", "Welcome to the Racing Simulator!");

recieverCLI.GetParams(raceLogic);
recieverCLI.GetObject(raceLogic);

raceLogic.StartSimulation();
if (raceLogic.Result == null)
{
    printer.PrintFormattedLine("Error", "Something went wrong during the simulation");
} 
else
{
    informerCLI.DisplayWinner(raceLogic.Result);
}
    