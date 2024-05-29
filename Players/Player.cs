namespace Players;
using Army;
using Units;

public class Player
{
    public IArmy Army { get; set; }
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
        for (int i = 0; i < Army.Units.Count-1; i++)
        {
            if (Army.Units[i] is LightInfantry lightInfantry && Army.Units[i] is not Squire && Army.Units[i+1] is HeavyInfantry)
            {
                var squireDecorator = new Squire(lightInfantry);
                squireDecorator.CheckAndApplyBuff(Army.Units, i);
                Army.Units[i] = squireDecorator;
            }
        }
        //last unit melee attacks first
        var unitHpLeft = enemy.Army.Units[^1].TakeDamage(Army.Units[^1], "melee");
        //range units attacks (if they can)
        for (var i = 0; i < Army.Units.Count-1; i++)
        {
            var type = Army.Units[i].GetType().Name;
            if ((type == "Archer" || type == "Mage") && Army.Units.Count - i <= 3)
            {
                unitHpLeft = enemy.Army.Units[^1].TakeDamage(Army.Units[i], "range");
            }
        }
        
        if (unitHpLeft >= 1) return;
        Console.WriteLine($"{enemy.Name}'s {enemy.Army.Units[^1].GetType().Name} is dead!");
        enemy.Army.RemoveDeadUnits();
    }
    
}
