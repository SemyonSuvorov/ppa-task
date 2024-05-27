namespace Units;

public interface IUnit
{
    int TakeDamage(IUnit enemy, string typeOfAttack);
    int Cost { get; }
    int Health { get; }
    int MeleeAttackPower { get; }
    int RangeAttackPower { get; }
    int DefencePower { get; }
}
