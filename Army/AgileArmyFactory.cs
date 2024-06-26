using Units;

namespace Army;


public class AgileArmyFactory : IArmyFactory
{
    public IArmy CreateArmy()
    {
        var army = new Army();
        army.Units.Add(UnitFactory.CreateUnit("mage"));
        army.Units.Add(UnitFactory.CreateUnit("light"));
        army.Units.Add(UnitFactory.CreateUnit("archer"));
        army.Units.Add(UnitFactory.CreateUnit("light"));
        army.Units.Add(UnitFactory.CreateUnit("heavy"));
        return army;
    }
}