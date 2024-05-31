using Players;

namespace Commands;

public class SelectHealableUnitCommand
{
    private readonly Player _player;
    private readonly int _healerIndex;
    private readonly int _healRange;

    public SelectHealableUnitCommand(Player player, int healerIndex, int healRange = 2)
    {
        _player = player;
        _healerIndex = healerIndex;
        _healRange = healRange;
    }

    public int Execute()
    {
        var i = 0;
        Console.WriteLine("Choose unit you want to heal:");
        Console.WriteLine();
        var healableIndexes = new List<int>();
        foreach (var t in _player.Army.Units)
        {
            if (Math.Abs(_healerIndex - i) < _healRange && _healerIndex != i)
            {
                Console.WriteLine($"{i + 1}: {t.GetType().Name} HP: {t.Health}");
                healableIndexes.Add(i);
            }

            i++;
        }

        var s = Console.ReadLine();
        var c = int.TryParse(s, out var a);

        return !c || !healableIndexes.Contains(a - 1) ? -1 : a - 1;
    }
}

