namespace Units;

public abstract class Unit : IUnit
{
    public int Health { get; protected set; }
    public int MeleeAttackPower { get; protected set; }
    public int RangeAttackPower { get; protected init; }
    public int DefencePower { get; protected init; }
    public int Cost { get; protected init; }

    
    public virtual int TakeDamage(IUnit enemy, string typeOfAttack)
    {
        Console.WriteLine();
        switch (typeOfAttack)
        {
            case "melee":
                Health -= enemy.MeleeAttackPower - DefencePower;
                Console.WriteLine($"{enemy} melee attacks {this} with attack power = {enemy.MeleeAttackPower}!");
                break;
            case "range":
                Health -= enemy.RangeAttackPower - DefencePower;
                Console.WriteLine($"{enemy} range attacks {this} with attack power = {enemy.RangeAttackPower}!");
                break;
        }

        if (Health < 0) Health = 0;
        Console.WriteLine($"{this}'s health left: {Health}");
        return Health;
    }

    public virtual void SetMeleeAttackPower(int power)
    {
        MeleeAttackPower = power;
    }
    
    public virtual void SetHealth(int health)
    {
        Health = health;
    }
}