using Players;

namespace GulyayPole;

public class AttackCommand : ICommand
{
    private readonly Player _player;
    private readonly Player _enemy;

    public AttackCommand(Player player, Player enemy)
    {
        _player = player;
        _enemy = enemy;
    }

    public void Execute()
    {
        Console.Clear();
        _player.Attack(_enemy);
        Console.WriteLine();
    }

    public bool IsTerminating => true;
}