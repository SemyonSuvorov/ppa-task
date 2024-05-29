namespace Players;
using Army;

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
        //last unit attacks first
        var unitHpLeft = enemy.Army.Units[^1].TakeDamage(Army.Units[^1], "melee");
        //range units attacks (if they can)
        for (var i = 0; i < Army.Units.Count-1; i++)
        {
            if (Army.Units[i].GetType().Name == "Archer" & Army.Units.Count - i <= 3)
            {
                unitHpLeft = enemy.Army.Units[^1].TakeDamage(Army.Units[i], "range");
            }
        }
        
        if (unitHpLeft >= 1) return;
        Console.WriteLine($"{enemy.Name}'s {enemy.Army.Units[^1].GetType().Name} is dead!");
        enemy.Army.RemoveDeadUnits();
    }
    
}
