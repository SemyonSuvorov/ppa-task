using Players;

namespace GulyayPole;

public static class CommandFactory
{
    public static ICommand GetCommand(int choice, Player player, Player enemy)
    {
        return choice switch
        {
            1 => new AttackCommand(player, enemy),
            2 => new ShowArmyCommand(player),
            3 => new CloneUnitCommand(player),
            _ => new InvalidCommand()
        };
    }
}