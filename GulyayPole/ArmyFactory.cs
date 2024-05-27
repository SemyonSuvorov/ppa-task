using Army;

namespace GulyayPole;

public static class ArmyFactory
{
    public static IArmyFactory GetArmyFactory(int choice)
    {
        return choice switch
        {
            1 => new BalancedArmyFactory(),
            2 => new AgileArmyFactory(),
            _ => new BalancedArmyFactory()
        };
    }
}