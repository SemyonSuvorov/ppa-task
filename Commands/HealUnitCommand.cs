using Players;
using Units;

namespace Commands;

public class HealUnitCommand : ICommand
{
    private readonly Player _player;
    private const int HealSize = 5;

    public HealUnitCommand(Player player)
    {
        _player = player;
        IsTerminating = false;
    }
    public void Execute() 
    {
        Console.Clear();

        if (!_player.Army.Units.Any(unit => unit is Healer))
        {
            Console.WriteLine("You have no healer!");
            Console.WriteLine();
            IsTerminating = false;
            return;
        }

        var selectHealerCommand = new SelectUnitCommand<Healer>(_player);
        var healerIndex = selectHealerCommand.Execute();

        switch (healerIndex)
        {
            case -1:
                Console.Clear();
                Console.WriteLine("Invalid selection or Healer is in the front line.");
                Console.WriteLine();
                IsTerminating = false;
                return;
            case 0:
                Console.Clear();
                Console.WriteLine("Healer can't heal while in the front line!");
                Console.WriteLine();
                IsTerminating = false;
                return;
        }

        var selectHealableUnitCommand = new SelectHealableUnitCommand(_player, healerIndex);
        Console.Clear();
        var healIndex = selectHealableUnitCommand.Execute();

        if (healIndex == -1)
        {
            Console.Clear();
            Console.WriteLine("Invalid selection or no healable unit in range.");
            Console.WriteLine();
            IsTerminating = false;
            return;
        }

        if (_player.Army.Units[healerIndex] is not Healer) return;
        if (_player.Army.Units[healIndex] is not Unit target) return;
        Console.Clear();
        var amount = 0;
        if(target.Health < 100)
        {
            target.SetHealth(target.Health + HealSize);
            if(target.Health > 100)
            {
                amount = HealSize - (target.Health - 100);
            }
            else
            {
                amount = HealSize;
            }
        }
        Console.WriteLine($"Healer has healed {target.GetType().Name} by {amount} HP");
        Console.WriteLine($"Current {target.GetType().Name} HP = {target.Health}");
        IsTerminating = true;
    }
    public bool IsTerminating { get; private set; }
}

