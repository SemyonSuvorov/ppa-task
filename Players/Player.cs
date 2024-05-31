namespace Players;
using Army;
using Units;

public class Player
{
    public IArmy Army { get; private set; }
    public string Name { get; }

    public Player(string name)
    {
        Name = name;
    }

    public void ChooseArmy(IArmyFactory armyFactory)
    {
        Army = armyFactory.CreateArmy();
    }
    public void DisplayArmy()
    {
        Console.WriteLine($"{Name}'s army.");
        Console.WriteLine();
        Army.DisplayArmy();
    }

    public bool IsNotEmpty()
    {
        return Army.Units.Count > 0;
    }
    
    public void Attack(Player enemy)
    {
        Console.WriteLine($"{Name} attacks {enemy.Name}!");
        //buff
        for (var i = 0; i < Army.Units.Count - 1; i++)
        {
            var currentUnit = Army.Units[i];
            var nextUnit = Army.Units[i + 1];

            if (currentUnit is not LightInfantry lightInfantry || currentUnit is Squire) continue;
            var isNextUnitHeavyInfantry = nextUnit is HeavyInfantry || 
                                          (nextUnit is UnitProxy proxy && proxy.GetUnit().ToString() == "Heavy Infantry");

            if (!isNextUnitHeavyInfantry) continue;
            var squireDecorator = new Squire(lightInfantry);
            squireDecorator.CheckAndApplyBuff(Army.Units, i);
            Army.Units[i] = squireDecorator;
        }
        //last unit melee attacks first
        var unitHpLeft = enemy.Army.Units[^1].TakeDamage(Army.Units[^1], "melee");
        if (unitHpLeft == 0)
        {
            Console.WriteLine($"{enemy.Name}'s {enemy.Army.Units[^1]} is dead!");
            enemy.Army.RemoveDeadUnits();
            return;
        }
        //range units attacks (if they can)
        for (var i = 0; i < Army.Units.Count-1; i++)
        {
            var type = Army.Units[i].ToString();
            if (type is not ("Archer" or "Mage") || Army.Units.Count - i > 3) continue;
            unitHpLeft = enemy.Army.Units[^1].TakeDamage(Army.Units[i], "range");
            if (unitHpLeft != 0) continue;
            Console.WriteLine($"{enemy.Name}'s {enemy.Army.Units[^1]} is dead!");
            enemy.Army.RemoveDeadUnits();
            return;
        }
    }
    
}
