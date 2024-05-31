namespace Units;

//decorator
public class Squire : Unit, ICloneable
{
    private bool _isBuffApplied;

    public Squire(IUnit lightInfantry)
    {
        var lightInfantry1 = lightInfantry;
        Health = lightInfantry1.Health;
        DefencePower = lightInfantry1.DefencePower;
        MeleeAttackPower = lightInfantry1.MeleeAttackPower;
        Cost = lightInfantry1.Cost;
    }


    private void ApplyBuff(IUnit heavyInfantry)
    {
        if (_isBuffApplied) return;
        heavyInfantry.SetMeleeAttackPower(heavyInfantry.MeleeAttackPower + 5);
        _isBuffApplied = true;
        Console.WriteLine("Light infantry buffs heavy infantry's attack power by 5.");
    }

    private void RemoveBuff(IUnit heavyInfantry)
    {
        if (!_isBuffApplied) return;
        heavyInfantry.SetMeleeAttackPower(heavyInfantry.MeleeAttackPower - 5);
        _isBuffApplied = false;
        Console.WriteLine("Light infantry removes buff from heavy infantry's attack power.");
    }

    public void CheckAndApplyBuff(IList<IUnit> units, int index)
    {
        switch (index)
        {
            case > 0 when units[index + 1] is HeavyInfantry heavyInfantry && !_isBuffApplied:
                ApplyBuff(heavyInfantry);
                break;
            case > 0 when units[index + 1] is UnitProxy proxy
                          && proxy.GetUnit().ToString() == "Heavy Infantry"
                          && !_isBuffApplied:
                ApplyBuff(proxy);
                break;
            default:
            {
                // remove buff in case TODO
                foreach (var unit in units)
                {
                    if (unit is HeavyInfantry hi)
                    {
                        RemoveBuff(hi);
                    }
                }

                break;
            }
        }
    }
    public object Clone()
    {
        return MemberwiseClone();
    }
    public override string ToString() => "LI(Squire)";

}