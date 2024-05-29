using Players;
using Units;

namespace GulyayPole;

public class HealUnitCommand : ICommand
{
    private readonly Player _player;
    private bool _isTerminating;
    private int _healSize = 5;
    public HealUnitCommand(Player player)
    {
        _player = player;
        _isTerminating = false;
    }
    public void Execute() 
    {
        Console.Clear();

        if (!_player.Army.Units.Any(unit => unit is Healer))
        {
            Console.WriteLine("You have no healer!");
            Console.WriteLine();
            _isTerminating = false;
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
                _isTerminating = false;
                return;
            case 0:
                Console.Clear();
                Console.WriteLine("Healer can't heal while in the front line!");
                Console.WriteLine();
                _isTerminating = false;
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
            _isTerminating = false;
            return;
        }

        if (_player.Army.Units[healerIndex] is not Healer healer) return;
        if (_player.Army.Units[healIndex] is not Unit target) return;
        Console.Clear();
        int amount = 0;
        if(target.Health < 100)
        {
            target.SetHealth(target.Health + _healSize);
            if(target.Health > 100)
            {
                amount = _healSize - (target.Health - 100);
            }
            else
            {
                amount = _healSize;
            }
        }
        Console.WriteLine($"Healer has healed {target.GetType().Name} by {amount} HP");
        Console.WriteLine($"Current {target.GetType().Name} HP = {target.Health}");
        _isTerminating = true;
    }
    public bool IsTerminating => _isTerminating;
}

