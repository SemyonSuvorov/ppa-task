using Players;
using Units;

namespace GulyayPole;

public class SelectMageCommand
{
    private readonly Player _player;

    public SelectMageCommand(Player player)
    {
        _player = player;
    }

    public int Execute()
    {
        var i = 1;
        Console.WriteLine("Choose a mage:");
        Console.WriteLine();
        var mageIndexes = new List<int>();

        foreach (var t in _player.Army.Units)
        {
            if (t is Mage)
            {
                Console.WriteLine($"{i}: {t.GetType().Name} HP: {t.Health}");
                mageIndexes.Add(i);
            }

            i++;
        }

        var s = Console.ReadLine();
        var c = int.TryParse(s, out var a);

        return !c || !mageIndexes.Contains(a) || a == _player.Army.Units.Count ? -1 : a - 1;
    }
}