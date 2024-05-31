namespace Units;

public interface IUnit
{
    int TakeDamage(IUnit enemy, string typeOfAttack);
    void SetHealth(int health);
    void SetMeleeAttackPower(int power);
    int Cost { get; }
    int Health { get; }
    int MeleeAttackPower { get; }
    int RangeAttackPower { get; }
    int DefencePower { get; }
}
