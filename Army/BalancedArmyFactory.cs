using Units;

namespace Army;

public class BalancedArmyFactory : IArmyFactory
{
    public IArmy CreateArmy()
    {
        var army = new Army();
        army.Units.Add(UnitFactory.CreateUnit("archer"));
        army.Units.Add(UnitFactory.CreateUnit("archer"));
        army.Units.Add(UnitFactory.CreateUnit("light"));
        army.Units.Add(UnitFactory.CreateUnit("healer"));
        army.Units.Add(UnitFactory.CreateUnit("heavy"));
        return army;
    }
}