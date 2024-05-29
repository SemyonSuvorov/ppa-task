using Units;

namespace Army;


public class AgileArmyFactory : IArmyFactory
{
    public IArmy CreateArmy()
    {
        var army = new Army
        {
            HasMage = true
        };
        army.Units.Add(UnitFactory.CreateUnit("archer"));
        army.Units.Add(UnitFactory.CreateUnit("light"));
        army.Units.Add(UnitFactory.CreateUnit("mage"));
        army.Units.Add(UnitFactory.CreateUnit("mage"));
        return army;
    }
}