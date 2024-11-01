using RaceSimulator.Presentation.Interfaces;
using RaceSimulator.Presentation.CLI;
using RaceSimulator.Race;
using RaceSimulator.Transportation.Abstractions;
using RaceSimulator.Utils;
using RaceSimulator.Transportation;
using RaceSimulator.Weather.Interfaces;

const int TICK_TIME_MS = 1000;

// Execute expensive code once during execution
var raceTypes = RaceHelper.GetAllRaceTypes();
var vehicleTypes = VehicleHelper.GetAllVehicleTypes();
var weatherTypes = WeatherHelper.GetAllWeatherTypes();

IPrinter printer = new CommandLinePrinter();

// Create factories
RaceFactory raceFactory = new(raceTypes, printer, TICK_TIME_MS);
VehicleFactory vehicleFactory = new(vehicleTypes);
WeatherFactory weatherFactory = new(weatherTypes);

// Create command line interface
CLI cli = new(printer);

printer.PrintFormattedLine("Info", "Welcome to the Racing Simulator!");

RaceLogic raceLogic = cli.GetRace(raceFactory);
IWeatherState weatherState = cli.GetWeatherState(weatherFactory);
raceLogic.SetWeatherState(weatherState);

cli.GetParams(raceLogic);
cli.GetObject(vehicleFactory, raceLogic);


raceLogic.StartSimulation();
if (raceLogic.Result == null)
{
    printer.PrintFormattedLine("Error", "Something went wrong during the simulation");
} 
else
{
    cli.DisplayWinner(raceLogic.Result);
}
    