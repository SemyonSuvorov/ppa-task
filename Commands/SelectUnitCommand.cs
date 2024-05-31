using Players;
using Units;

namespace GulyayPole;

public class SelectUnitCommand<T> where T : IUnit
{
    private readonly Player _player;

    public SelectUnitCommand(Player player)
    {
        _player = player;
    }

    public int Execute()
    {
        var i = 1;
        Console.WriteLine($"Choose a {typeof(T).Name}:");
        Console.WriteLine();
        var unitIndexes = new List<int>();

        foreach (var t in _player.Army.Units)
        {
            if (t is T)
            {
                Console.WriteLine($"{i}: {t} HP: {t.Health}");
                unitIndexes.Add(i);
            }

            i++;
        }

        var s = Console.ReadLine();
        var c = int.TryParse(s, out var a);
        if (typeof(T).Name == "IUnit" && a == _player.Army.Units.Count)
        {
            return a - 1;
        }
        return !c || !unitIndexes.Contains(a) || a == _player.Army.Units.Count ? -1 : a - 1;
    }
}