namespace Units;

public class UnitProxy : Unit
{
    private readonly IUnit _unit;
    private readonly Action<string> _logAction;
    private readonly Action _notificationAction;

    public UnitProxy(IUnit unit, Action<string> logAction, Action notificationAction)
    {
        _unit = unit;
        _logAction = logAction;
        _notificationAction = notificationAction;
        Health = _unit.Health;
        MeleeAttackPower = _unit.MeleeAttackPower;
        RangeAttackPower =  _unit.RangeAttackPower;
        DefencePower = _unit.DefencePower;
        Cost = _unit.Cost;
    }

    public override int TakeDamage(IUnit enemy, string typeOfAttack)
    {
        var hpLeft = _unit.TakeDamage(enemy, typeOfAttack);
        Health = hpLeft;
        if (Health != 0) return Health;
        _notificationAction.Invoke();
        _logAction.Invoke($"Unit of type {_unit} has died.");
        return Health;
    }

    public override void SetHealth(int value)
    {
        _unit.SetHealth(value);
    }

    public override void SetMeleeAttackPower(int value)
    {
        MeleeAttackPower = value;
        _unit.SetMeleeAttackPower(value);
    }
    public IUnit GetUnit() => _unit;

    public override string ToString() => $"{_unit}(Log)";
}