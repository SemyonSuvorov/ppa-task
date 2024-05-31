using Players;

namespace Commands;


public class ShowArmyCommand : ICommand
{
    private readonly Player _player;

    public ShowArmyCommand(Player player)
    {
        _player = player;
    }

    public void Execute()
    {
        Console.Clear();
        _player.DisplayArmy();
        Console.WriteLine();
    }

    public bool IsTerminating => false;
}
