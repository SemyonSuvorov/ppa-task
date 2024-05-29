namespace Units;

public abstract class Unit : IUnit
{
    public int Health { get; protected set; }
    public int MeleeAttackPower { get; protected set; }
    public int RangeAttackPower { get; protected set; }
    public int DefencePower { get; protected set; }
    public int Cost { get; protected set; }

    
    public int TakeDamage(IUnit enemy, string typeOfAttack)
    {
        Console.WriteLine();
        switch (typeOfAttack)
        {
            case "melee":
                Health -= enemy.MeleeAttackPower - DefencePower;
                Console.WriteLine($"{enemy.GetType().Name} melee attacks {this.GetType().Name} with attack power = {enemy.MeleeAttackPower}!");
                break;
            case "range":
                Health -= enemy.RangeAttackPower - DefencePower;
                Console.WriteLine($"{enemy.GetType().Name} range attacks {this.GetType().Name} with attack power = {enemy.RangeAttackPower}!");
                break;
        }

        if (Health < 0) Health = 0;
        Console.WriteLine($"{GetType().Name}'s health left: {Health}");
        return Health;
    }
}