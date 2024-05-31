using Players;

namespace Commands;

public class SelectCloneableUnitCommand
{
    private readonly Player _player;
    private readonly int _mageIndex;
    private readonly int _cloneRange;

    public SelectCloneableUnitCommand(Player player, int mageIndex, int cloneRange = 2)
    {
        _player = player;
        _mageIndex = mageIndex;
        _cloneRange = cloneRange;
    }

    public int Execute()
    {
        var i = 0;
        Console.WriteLine("Choose unit you want to clone:");
        Console.WriteLine();
        var cloneableIndexes = new List<int>();
        foreach (var t in _player.Army.Units)
        {
            if (t is ICloneable && Math.Abs(_mageIndex - i) < _cloneRange && _mageIndex != i)
            {
                Console.WriteLine($"{i + 1}: {t.GetType().Name} HP: {t.Health}");
                cloneableIndexes.Add(i);
            }

            i++;
        }

        var s = Console.ReadLine();
        var c = int.TryParse(s, out var a);

        return !c || !cloneableIndexes.Contains(a - 1) ? -1 : a - 1;
    }
}