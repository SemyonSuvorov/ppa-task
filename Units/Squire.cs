namespace Units;

//decorator
public class Squire : Unit, ICloneable
{
    private readonly IUnit _lightInfantry;
    private bool _isBuffApplied;

    public Squire(IUnit lightInfantry)
    {
        _lightInfantry = lightInfantry;
        Health = _lightInfantry.Health;
        DefencePower = _lightInfantry.DefencePower;
        MeleeAttackPower = _lightInfantry.MeleeAttackPower;
        Cost = _lightInfantry.Cost;
    }


    public void ApplyBuff(HeavyInfantry heavyInfantry)
    {
        if (!_isBuffApplied)
        {
            heavyInfantry.SetMeleeAttackPower(heavyInfantry.MeleeAttackPower + 5);
            _isBuffApplied = true;
            Console.WriteLine("Light infantry buffs heavy infantry's attack power by 5.");
        }
    }

    public void RemoveBuff(HeavyInfantry heavyInfantry)
    {
        if (_isBuffApplied)
        {
            heavyInfantry.SetMeleeAttackPower(heavyInfantry.MeleeAttackPower - 5);
            _isBuffApplied = false;
            Console.WriteLine("Light infantry removes buff from heavy infantry's attack power.");
        }
    }

    public void CheckAndApplyBuff(IList<IUnit> units, int index)
    {
        if (index > 0 && units[index + 1] is HeavyInfantry heavyInfantry && !_isBuffApplied)
        {
            ApplyBuff(heavyInfantry);
        }
        else
        {
            // remove buff in case TODO
            foreach (var unit in units)
            {
                if (unit is HeavyInfantry hi)
                {
                    RemoveBuff(hi);
                }
            }
        }
    }
    public object Clone()
    {
        return MemberwiseClone();
    }
}