using Players;
using Units;

namespace GulyayPole;

public class CloneUnitCommand: ICommand
{
    private readonly Player _player;
    private bool _isTerminating;
    public CloneUnitCommand(Player player)
    {
        _player = player;
        _isTerminating = false;
    }

    public void Execute()
    {
        Console.Clear();

        if (!_player.Army.Units.Any(unit => unit is Mage))
        {
            Console.WriteLine();
            Console.WriteLine("You have no mage!");
            Console.WriteLine();
            _isTerminating = false;
            return;
        }

        var selectMageCommand = new SelectMageCommand(_player);
        var mageIndex = selectMageCommand.Execute();

        switch (mageIndex)
        {
            case -1:
                Console.Clear();
                Console.WriteLine("Invalid selection or Mage is in the front line.");
                Console.WriteLine();
                _isTerminating = false;
                return;
            case 0:
                Console.Clear();
                Console.WriteLine("Mage can't clone while in the front line!");
                Console.WriteLine();
                _isTerminating = false;
                return;
        }

        var selectCloneableUnitCommand = new SelectCloneableUnitCommand(_player, mageIndex);
        Console.Clear();
        var cloneIndex = selectCloneableUnitCommand.Execute();

        if (cloneIndex == -1)
        {
            Console.Clear();
            Console.WriteLine("Invalid selection or no cloneable unit in range.");
            Console.WriteLine();
            _isTerminating = false;
            return;
        }

        if (_player.Army.Units[mageIndex] is not Mage mage ||
            _player.Army.Units[cloneIndex] is not ICloneable unitToClone) return;
        if (unitToClone.Clone() is not IUnit clone) return;
        _player.Army.Units.Insert(0, clone);
        Console.Clear();
        Console.WriteLine($"Mage cloned {unitToClone.GetType().Name}");
        _isTerminating = true;
    }

    public bool IsTerminating => _isTerminating;
}