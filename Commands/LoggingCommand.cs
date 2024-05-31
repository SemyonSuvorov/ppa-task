using Players;
using Units;

namespace Commands;

public class LoggingCommand : ICommand
{
    private readonly Player _player;

    public LoggingCommand(Player player)
    {
        _player = player;
    }

    public void Execute()
    {
        Console.Clear();
        var selectUnitCommand = new SelectUnitCommand<IUnit>(_player);
        var unitIndex = selectUnitCommand.Execute();
        if (unitIndex == -1)
        {
            Console.Clear();
            Console.WriteLine("Invalid selection");
            Console.WriteLine();
            return;
        }

        if (_player.Army.Units[unitIndex] is UnitProxy proxy)
        {
            var newUnit = proxy.GetUnit();
            _player.Army.Units[unitIndex] = newUnit;
            Console.Clear();
            Console.WriteLine($"Stopped logging {newUnit}");
            Console.WriteLine();
        }
        else
        {
            var newProxy = new UnitProxy(_player.Army.Units[unitIndex], LogToFile, NotifyUser);
            _player.Army.Units[unitIndex] = newProxy;
            Console.Clear();
            Console.WriteLine($"Started Logging {newProxy.GetUnit()}");
            Console.WriteLine();
        }
    }
    private static void NotifyUser()
    {
        Console.WriteLine("A unit has died!");
        Console.Beep();
        var originalForegroundColor = Console.ForegroundColor;
        var originalBackgroundColor = Console.BackgroundColor;

        const ConsoleColor flashColor = ConsoleColor.Red;
        
        Console.Clear();
        Console.BackgroundColor = flashColor;
        Console.Clear();
        Thread.Sleep(120); 

        Console.BackgroundColor = originalBackgroundColor;
        Console.Clear();
        Console.ForegroundColor = originalForegroundColor;
    }
    private static void LogToFile(string message)
    {
        File.AppendAllText("unit_log.txt", message + Environment.NewLine);
    }
    public bool IsTerminating => false;
}